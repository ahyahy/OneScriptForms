using ScriptEngine.HostedScript.Library;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections.Concurrent;
using System;
using ScriptEngine.HostedScript.Library.Binary;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using osf;

namespace osfMultiTcp
{
    public class MultithreadedTCPServer : IDisposable
    {
        public TsMultithreadedTCPServer dll_obj;
        private static long _lastClientId;
        private volatile ServerState _state = ServerState.Stopped;
        private readonly object _stateLock = new object();
        public ServerState State => _state;
        private int maxMessageSize = 1024 * 1024 * 128; // 128 MB Ограничение на размер принимаемого сообщения.
        private readonly ByteBufferPool _bufferPool = new ByteBufferPool(1024);
        private int maxClients = 1500; // Ограничение на количество подключаемых клиентов.
        public int ActiveClients => _clients.Count; // Количество активных клиентов.
        private TcpListener _listener;
        private ConcurrentDictionary<string, TcpClient> _clients = new ConcurrentDictionary<string, TcpClient>();
        private CancellationTokenSource _cts;
        private bool _isRunning;
        public int Port { get; set; } = 8080;
        public System.Text.Encoding Encoding { get; set; } = System.Text.Encoding.UTF8;
        public TimeSpan HeartbeatInterval { get; set; } = TimeSpan.FromSeconds(10); // Интервал проверки активности клиента.
        public event Action<string> OnClientConnected;
        public event Action<string> OnClientDisconnected;
        public event Action<string, BinaryDataBuffer> OnMessageReceived;
        public event Action<string> OnServerError;

        public MultithreadedTCPServer(int port)
        {
            Port = port;
            OnClientConnected += MultithreadedTCPServer_OnClientConnected;
            OnClientDisconnected += MultithreadedTCPServer_OnClientDisconnected;
            OnMessageReceived += MultithreadedTCPServer_OnMessageReceived;
            OnServerError += MultithreadedTCPServer_OnServerError;
        }

        private void MultithreadedTCPServer_OnServerError(string obj)
        {
            if (dll_obj?.ServerError != null)
            {
                var args = new TsEventArgs
                {
                    eventAction = dll_obj.ServerError,
                    parameter = Helper.GetEventParameter(dll_obj.ServerError),
                    serverError = obj
                };
                OneScriptMultithreadedTCPServer.EventQueue.Enqueue(args);
            }
        }

        private void MultithreadedTCPServer_OnMessageReceived(string arg1, BinaryDataBuffer arg2)
        {
            if (dll_obj?.MessageReceived != null)
            {
                var args = new TsEventArgs
                {
                    eventAction = dll_obj.MessageReceived,
                    parameter = Helper.GetEventParameter(dll_obj.MessageReceived),
                    clientId = arg1,
                    data = arg2
                };
                OneScriptMultithreadedTCPServer.EventQueue.Enqueue(args);
            }
        }

        private void MultithreadedTCPServer_OnClientDisconnected(string obj)
        {
            if (dll_obj?.ClientDisconnected != null)
            {
                var args = new TsEventArgs
                {
                    eventAction = dll_obj.ClientDisconnected,
                    parameter = Helper.GetEventParameter(dll_obj.ClientDisconnected),
                    clientId = obj
                };
                OneScriptMultithreadedTCPServer.EventQueue.Enqueue(args);
            }
        }

        private void MultithreadedTCPServer_OnClientConnected(string obj)
        {
            if (dll_obj?.ClientConnected != null)
            {
                var args = new TsEventArgs
                {
                    eventAction = dll_obj.ClientConnected,
                    parameter = Helper.GetEventParameter(dll_obj.ClientConnected),
                    clientId = obj
                };
                OneScriptMultithreadedTCPServer.EventQueue.Enqueue(args);
            }
        }

        public async Task StartAsync(CancellationToken externalToken = default)
        {
            lock (_stateLock)
            {
                if (_state != ServerState.Stopped && _state != ServerState.StoppedWithError)
                {
                    throw new InvalidOperationException($"Сервер уже работает. Текущее состояние: {_state}");
                }
                _state = ServerState.Starting;
            }

            _isRunning = true;

            // Объединяем внешний и внутренний токены отмены.
            _cts = CancellationTokenSource.CreateLinkedTokenSource(externalToken);

            _listener = new TcpListener(IPAddress.Any, Port);
            _listener.Start(100); // backlog для ожидающих подключений.

            _state = ServerState.Running;
            Utils.GlobalContext().Echo("Многопоточный TCP сервер запущен на порт " + Port);
            OneScriptForms.multiServerUploaded = true;

            try
            {
                var acceptTasks = new List<Task>();

                // Запускаем несколько задач для приема подключений.
                int acceptLoops = Math.Max(1, System.Environment.ProcessorCount / 2); // Оптимальное количество.
                for (int i = 0; i < acceptLoops; i++)
                {
                    acceptTasks.Add(AcceptClientsLoopAsync(_cts.Token));
                }

                // Ожидаем завершения всех задач или отмены.
                await Task.WhenAll(acceptTasks).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                OnServerError?.Invoke("Сервер остановлен по запросу");
            }
            catch (Exception ex)
            {
                _state = ServerState.StoppedWithError;
                OnServerError?.Invoke("Ошибка сервера: " + ex.Message);
                throw;
            }
            finally
            {
                _state = ServerState.Stopped;
                CleanupResources();
            }
        }

        private async Task AcceptClientsLoopAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested && _isRunning)
            {
                try
                {
                    var client = await _listener.AcceptTcpClientAsync().ConfigureAwait(false);

                    if (token.IsCancellationRequested)
                    {
                        client.Close();
                        break;
                    }

                    // Ограничение количества одновременных подключений.
                    if (_clients.Count >= MaxClients)
                    {
                        await SendRejectionAndClose(client, "Сервер перегружен");
                        continue;
                    }

                    // Настраиваем таймауты клиента.
                    client.ReceiveTimeout = 30000;
                    client.SendTimeout = 10000;

                    // Запустим задачу взаимодействия с клиентом так, чтобы она не блокировала подключение новых клиентов.
                    _ = HandleClientAsync(client, token).ContinueWith(t =>
                    {
                        if (t.IsFaulted)
                        {
                            OnServerError?.Invoke("Ошибка обработки клиента: " + t.Exception?.InnerException?.Message);
                        }
                    }, TaskContinuationOptions.OnlyOnFaulted);
                }
                catch (ObjectDisposedException)
                {
                    // Сервер прослушивания был остановлен.
                    break;
                }
                catch (SocketException ex) when (ex.SocketErrorCode == SocketError.Interrupted)
                {
                    // Прервано вызовом Stop().
                    break;
                }
                catch (Exception ex)
                {
                    if (!token.IsCancellationRequested)
                    {
                        OnServerError?.Invoke("Ошибка приёма клиента: " + ex.Message);
                    }
                }
            }
        }

        private async Task SendRejectionAndClose(TcpClient client, string message)
        {
            try
            {
                var data = Encoding.GetBytes($"ERROR: {message}\n");
                await client.GetStream().WriteAsync(data, 0, data.Length);
                await Task.Delay(100); // Даем время на отправку.
            }
            catch { }
            finally
            {
                client.Close();
            }
        }

        private async Task HandleClientAsync(TcpClient client, CancellationToken token)
        {
            var clientId = Convert.ToString(Interlocked.Increment(ref _lastClientId));

            if (!_clients.TryAdd(clientId, client))
            {
                client.Close();
                return;
            }

            var clientCts = CancellationTokenSource.CreateLinkedTokenSource(token);

            try
            {
                OnClientConnected?.Invoke(clientId);

                if (CheckClientActivity)
                {
                    // Запускаем пингование клиента (heartbeat) в фоне.
                    var heartbeatTask = HeartbeatLoopAsync(client, clientId, clientCts.Token);

                    // Основной цикл чтения.
                    await ReadLoopAsync(client, clientId, clientCts.Token).ConfigureAwait(false);

                    // Отменяем пингование клиента (heartbeat).
                    clientCts.Cancel();

                    // Ожидаем завершения пингования клиента (heartbeat) с обработкой исключений.
                    await heartbeatTask.ContinueWith(t =>
                    {
                        if (t.IsFaulted)
                        {
                            OnServerError?.Invoke("Ошибка heartbeat для клиента " + clientId + ": " + t.Exception?.Message);
                        }
                    }, TaskContinuationOptions.OnlyOnFaulted);
                }
                else
                {
                    // Основной цикл чтения.
                    await ReadLoopAsync(client, clientId, clientCts.Token).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                OnServerError?.Invoke("Ошибка в обработке клиента " + clientId + ": " + ex.Message);
            }
            finally
            {
                // Важно: всегда освобождаем ресурсы.
                clientCts.Dispose();

                _clients.TryRemove(clientId, out _);
                OnClientDisconnected?.Invoke(clientId);

                try
                {
                    client.Close();
                }
                catch { }
            }
        }

        private async Task ReadLoopAsync(TcpClient client, string clientId, CancellationToken token)
        {
            var stream = client.GetStream();
            var buffer = _bufferPool.Rent();
            var sb = new StringBuilder();

            try
            {
                while (!token.IsCancellationRequested && client.Connected)
                {
                    try
                    {
                        // Читаем входящие данные
                        BinaryDataBuffer bdb = new BinaryDataBuffer(new byte[0]);
                        int bytesRead = 0;
                        do
                        {
                            bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token).ConfigureAwait(false);
                            bdb = bdb.Concat((new BinaryDataBuffer(buffer)).Read(0, bytesRead));

                            // Ограничение на размер сообщения.
                            if (bdb.Size > maxMessageSize)
                            {
                                await SendRejectionAndClose(client, "Превышен размер сообщения");
                                bdb = new BinaryDataBuffer(new byte[0]);
                                OnServerError?.Invoke("Превышен размер сообщения для клиента " + clientId + ". Клиент отключен.");
                                break;
                            }
                        } while (bytesRead == buffer.Length);

                        if (bdb?.Count() > 0)
                        {
                            // Вызываем обработчик данных
                            try
                            {
                                OnMessageReceived?.Invoke(clientId, bdb);
                            }
                            catch (Exception ex)
                            {
                                OnServerError?.Invoke("Ошибка обработки сообщения: " + ex.Message);
                            }
                        }
                    }
                    catch (IOException ex) when (ex.InnerException is SocketException)
                    {
                        break; // Соединение разорвано.
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        OnServerError?.Invoke("Ошибка чтения от клиента " + clientId + ": " + ex.Message);
                        break;
                    }
                }
            }
            finally
            {
                _bufferPool.Return(buffer);
            }
        }

        private async Task HeartbeatLoopAsync(TcpClient client, string clientId, CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested && client.Connected)
                {
                    await Task.Delay(HeartbeatInterval, token).ConfigureAwait(false);

                    if (token.IsCancellationRequested)
                    {
                        break;
                    }

                    // Пытаемся отправить PING, не проверяя заранее соединение.
                    var success = await SendAsync(clientId, $"PING|{DateTime.Now:o}\n").ConfigureAwait(false);

                    if (!success)
                    {
                        OnServerError?.Invoke("Клиент " + clientId + " не ответил на отправленный PING");
                        break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Нормальное завершение по токену.
            }
            catch (Exception ex)
            {
                OnServerError?.Invoke("Ошибка на отправленный PING для клиента " + clientId + ": " + ex.Message);
            }
        }

        // Отправить строку в сообщении конкретному клиенту.
        public async Task<bool> SendAsync(string clientId, string message)
        {
            if (!_clients.TryGetValue(clientId, out var client) || !client.Connected)
            {
                return false;
            }

            try
            {
                var stream = client.GetStream();
                var data = Encoding.GetBytes(message.EndsWith("\n") ? message : message + "\n");
                await stream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                OnServerError?.Invoke("Ошибка отправки клиенту " + clientId + ": " + ex.Message);
                // При ошибке отправки удаляем клиента.
                _clients.TryRemove(clientId, out _);
                return false;
            }
        }

        // Отправить байты в сообщении конкретному клиенту.
        public async Task<bool> SendAsync(string clientId, BinaryDataBuffer message)
        {
            if (!_clients.TryGetValue(clientId, out var client) || !client.Connected)
            {
                return false;
            }

            try
            {
                var stream = client.GetStream();
                var data = message.Bytes;
                await stream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                OnServerError?.Invoke("Ошибка отправки клиенту " + clientId + ": " + ex.Message);
                // При ошибке отправки удаляем клиента.
                _clients.TryRemove(clientId, out _);
                return false;
            }
        }

        // Отправить строку всем клиентам.
        public async Task BroadcastAsync(string message)
        {
            var data = Encoding.GetBytes(message.EndsWith("\n") ? message : message + "\n");
            var failedClients = new List<string>();

            foreach (var kvp in _clients)
            {
                try
                {
                    if (kvp.Value.Connected)
                    {
                        await kvp.Value.GetStream().WriteAsync(data, 0, data.Length).ConfigureAwait(false);
                    }
                    else
                    {
                        failedClients.Add(kvp.Key);
                    }
                }
                catch
                {
                    failedClients.Add(kvp.Key);
                }
            }

            // Удаляем отвалившихся клиентов.
            foreach (var clientId in failedClients)
            {
                _clients.TryRemove(clientId, out _);
            }
        }

        // Отправить байты всем клиентам.
        public async Task BroadcastAsync(BinaryDataBuffer message)
        {
            var data = message.Bytes;
            var failedClients = new List<string>();

            foreach (var kvp in _clients)
            {
                try
                {
                    if (kvp.Value.Connected)
                    {
                        await kvp.Value.GetStream().WriteAsync(data, 0, data.Length).ConfigureAwait(false);
                    }
                    else
                    {
                        failedClients.Add(kvp.Key);
                    }
                }
                catch
                {
                    failedClients.Add(kvp.Key);
                }
            }

            // Удаляем отвалившихся клиентов.
            foreach (var clientId in failedClients)
            {
                _clients.TryRemove(clientId, out _);
            }
        }

        public async Task StopAsync(TimeSpan? gracefulTimeout = null)
        {
            var timeout = gracefulTimeout ?? TimeSpan.FromSeconds(30);

            lock (_stateLock)
            {
                if (_state != ServerState.Running && _state != ServerState.Starting)
                {
                    return;
                }

                _state = ServerState.Stopping;
            }

            Utils.GlobalContext().Echo("Начало выключения сервера...");

            // 1. Останавливаем прием новых подключений.
            _isRunning = false;

            // 2. Останавливаем сервер прослушивания.
            try
            {
                _listener?.Stop();
            }
            catch { }

            // 3. Уведомляем все задачи о необходимости завершения.
            _cts?.Cancel();

            // 4. Мягкое (Graceful) закрытие существующих подключений.
            await GracefulDisconnectClientsAsync(timeout).ConfigureAwait(false);

            // 5. Принудительное завершение оставшихся подключений.
            ForceDisconnectAllClients();

            // 6. Очистка ресурсов.
            CleanupResources();

            _state = ServerState.Stopped;
            Utils.GlobalContext().Echo("Сервер полностью остановлен");
        }

        private async Task GracefulDisconnectClientsAsync(TimeSpan timeout)
        {
            if (_clients.IsEmpty)
            {
                return;
            }

            var gracefulTasks = new List<Task>();
            var disconnectMessage = Encoding.GetBytes("SERVER_SHUTDOWN\n");

            // Отправляем уведомление о завершении всем клиентам.
            foreach (var kvp in _clients)
            {
                var task = Task.Run(async () =>
                {
                    try
                    {
                        await SendRawAsync(kvp.Value, disconnectMessage);
                        // Даем время клиенту обработать сообщение.
                        await Task.Delay(1000);
                    }
                    catch { }
                });

                gracefulTasks.Add(task);
            }

            // Ожидаем завершения отправки уведомлений или таймаута.
            try
            {
                var timeoutTask = Task.Delay(timeout);
                var completedTask = await Task.WhenAny(Task.WhenAll(gracefulTasks), timeoutTask);

                if (completedTask == timeoutTask)
                {
                    Utils.GlobalContext().Echo("Время задержки выключения закончилось (" + timeout.TotalSeconds + " сек). Отключаем принудительно.");
                }
            }
            catch { }
        }

        private void ForceDisconnectAllClients()
        {
            foreach (var client in _clients.Values)
            {
                try
                {
                    // Отправляем TCP RST вместо мягкого (graceful) закрытия.
                    client.Client.LingerState = new LingerOption(true, 0);
                    client.Close();
                }
                catch { }
            }

            _clients.Clear();
        }

        private async Task SendRawAsync(TcpClient client, byte[] data)
        {
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
            {
                try
                {
                    if (client.Connected)
                    {
                        await client.GetStream().WriteAsync(data, 0, data.Length, cts.Token)
                            .ConfigureAwait(false);
                    }
                }
                catch (OperationCanceledException)
                {
                    // Таймаут отправки.
                    OnServerError?.Invoke("Таймаут отправки сообщения");
                    throw;
                }
                catch (Exception ex)
                {
                    OnServerError?.Invoke("Ошибка отправки: " + ex.Message);
                    throw;
                }
            }
        }

        // Добавляем метод CleanupResources.
        private void CleanupResources()
        {
            try
            {
                _listener?.Stop();

                // Очищаем пул буферов (если нужно).
                // _bufferPool.Clear();

                // Очищаем токены отмены.
                _cts?.Dispose();
            }
            catch (Exception ex)
            {
                OnServerError?.Invoke("Ошибка при очистке ресурсов: " + ex.Message);
            }
        }

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                try
                {
                    // Если сервер работает, останавливаем его.
                    if (_state == ServerState.Running || _state == ServerState.Starting)
                    {
                        var stopTask = StopAsync(TimeSpan.FromSeconds(5));
                        if (!stopTask.Wait(TimeSpan.FromSeconds(10)))
                        {
                            OnServerError?.Invoke("Таймаут при остановке сервера");
                        }
                    }

                    _cts?.Dispose();
                    _listener?.Stop();

                    // Очищаем клиентов.
                    foreach (var client in _clients.Values)
                    {
                        try
                        {
                            client?.Close();
                        }
                        catch { }
                    }
                    _clients.Clear();
                }
                catch (Exception ex)
                {
                    OnServerError?.Invoke("Ошибка при освобождении ресурсов: " + ex.Message);
                }
            }

            _disposed = true;
        }

        ~MultithreadedTCPServer()
        {
            Dispose(false);
        }

        public int MaxMessageSize
        {
            get { return maxMessageSize; }
            set { maxMessageSize = value; }
        }

        public int MaxClients
        {
            get { return maxClients; }
            set { maxClients = value; }
        }

        private bool checkClientActivity = false;
        public bool CheckClientActivity
        {
            get { return checkClientActivity; }
            set { checkClientActivity = value; }
        }
    }

    [ContextClass("ТсМногопоточныйTCPСервер", "TsMultithreadedTCPServer")]
    public class TsMultithreadedTCPServer : AutoContext<TsMultithreadedTCPServer>
    {
        public TsMultithreadedTCPServer(int port)
        {
            MultithreadedTCPServer MultithreadedTCPServer1 = new MultithreadedTCPServer(port);
            MultithreadedTCPServer1.dll_obj = this;
            Base_obj = MultithreadedTCPServer1;
        }

        public MultithreadedTCPServer Base_obj;

        [ContextMethod("ОтправитьКлиенту", "SendToClient")]
        public void SendToClient(string p1, IValue p2)
        {
            if (Utils.IsType<BinaryDataBuffer>(p2))
            {
                _ = Task.Run(() =>
                {
                    Base_obj.SendAsync(p1, (BinaryDataBuffer)p2).ConfigureAwait(false);
                });
            }
            else
            {
                _ = Task.Run(() =>
                {
                    Base_obj.SendAsync(p1, p2.AsString()).ConfigureAwait(false);
                });
            }
        }

        [ContextMethod("ОтправитьВсем", "SendToAll")]
        public void SendToAll(IValue p1)
        {
            if (Utils.IsType<BinaryDataBuffer>(p1))
            {
                _ = Task.Run(() =>
                {
                    Base_obj.BroadcastAsync((BinaryDataBuffer)p1).ConfigureAwait(false);
                });
            }
            else
            {
                _ = Task.Run(() =>
                {
                    Base_obj.BroadcastAsync(p1.AsString()).ConfigureAwait(false);
                });
            }
        }

        [ContextProperty("ПроверятьАктивностьКлиента", "CheckClientActivity")]
        public bool CheckClientActivity
        {
            get { return Base_obj.CheckClientActivity; }
            set { Base_obj.CheckClientActivity = value; }
        }

        [ContextMethod("Начать", "Start")]
        public async void Start()
        {
            try
            {
                var cts = new CancellationTokenSource();

                try
                {
                    // Запуск сервера.
                    var serverTask = Base_obj.StartAsync(cts.Token);

                    // Мониторинг состояния.
                    _ = Task.Run(async () =>
                    {
                        while (!cts.Token.IsCancellationRequested)
                        {
                            await Task.Delay(5000);
                        }
                    });

                    // Ожидаем завершения сервера.
                    await serverTask;
                }
                catch (TaskCanceledException)
                {
                    Utils.GlobalContext().Echo("Сервер остановлен по запросу пользователя");
                }
                catch (Exception ex)
                {
                    Utils.GlobalContext().Echo("Критическая ошибка: " + ex.Message);
                }
            }
            catch (Exception e)
            {
                Utils.GlobalContext().Echo("Ошибка. На порт " + Base_obj.Port + " сервер уже запущен. " +
                    System.Environment.NewLine + e.Message);
                OneScriptForms.multiServerError = true;
            }
        }

        [ContextMethod("Остановить", "Stop")]
        public async void Stop()
        {
            await Base_obj.StopAsync();
        }

        [ContextProperty("ПриПодключенииКлиента", "ClientConnected")]
        public TsAction ClientConnected { get; set; }

        [ContextProperty("ПриОтключенииКлиента", "ClientDisconnected")]
        public TsAction ClientDisconnected { get; set; }

        [ContextProperty("СерверПолучилДанные", "MessageReceived")]
        public TsAction MessageReceived { get; set; }

        [ContextProperty("ПриОшибкеСервера", "ServerError")]
        public TsAction ServerError { get; set; }

        [ContextProperty("КоличествоАктивныхКлиентов", "ActiveClientsNumber")]
        public int ActiveClientsNumber
        {
            get { return Base_obj.ActiveClients; }
        }

        [ContextProperty("СостояниеСервера", "ServerState")]
        public int ServerState
        {
            get { return (int)Base_obj.State; }
        }

        [ContextProperty("МаксимальныйРазмерСообщения", "MaxMessageSize")]
        public int MaxMessageSize
        {
            get { return Base_obj.MaxMessageSize; }
            set { Base_obj.MaxMessageSize = value; }
        }

        [ContextProperty("МаксимальноеКоличествоПодключений", "MaxClients")]
        public int MaxClients
        {
            get { return Base_obj.MaxClients; }
            set { Base_obj.MaxClients = value; }
        }

        [ContextProperty("Кодировка", "Encoding")]
        public ClEncoding Encoding
        {
            get
            {
                osf.Encoding Encoding1 = new osf.Encoding();
                Encoding1.M_Encoding = Base_obj.Encoding;
                return new ClEncoding(Encoding1);
            }
            set { Base_obj.Encoding = value.Base_obj.M_Encoding; }
        }

        private int heartbeatInterval = 10;
        [ContextProperty("ИнтервалПроверки", "HeartbeatInterval")]
        public int HeartbeatInterval
        {
            get { return heartbeatInterval; }
            set
            {
                heartbeatInterval = value;
                Base_obj.HeartbeatInterval = TimeSpan.FromSeconds(heartbeatInterval);
            }
        }

        [ContextMethod("Действие", "Action")]
        public TsAction Action(IRuntimeContextInstance script, string methodName, IValue param = null)
        {
            return new TsAction(script, methodName, param);
        }

        public static IValue Event = null;
        [ContextProperty("АргументыСобытия", "EventArgs")]
        public IValue EventArgs
        {
            get { return OneScriptMultithreadedTCPServer.Event; }
        }

        public bool goOn = true;
        [ContextProperty("Продолжать", "GoOn")]
        public bool GoOn
        {
            get { return ServerBase.goOn; }
            set { ServerBase.goOn = value; }
        }

        public static IValue EventAction = null;
        public static ConcurrentQueue<dynamic> EventQueue = new ConcurrentQueue<dynamic>();
        [ContextMethod("ПолучитьСобытие", "DoEvents")]
        public DelegateAction DoEvents()
        {
            while (OneScriptMultithreadedTCPServer.EventQueue.Count == 0)
            {
                System.Threading.Thread.Sleep(7);
            }

            IValue Action1 = ServerBase.EventHandling();
            if (Action1.GetType() == typeof(TsAction))
            {
                return DelegateAction.Create(((TsAction)Action1).Script, ((TsAction)Action1).MethodName);
            }
            return (DelegateAction)Action1;
        }

        public static OneScriptMultithreadedTCPServer serverBase = null;
        public OneScriptMultithreadedTCPServer ServerBase
        {
            get { return serverBase; }
            set
            {
                if (serverBase == null)
                {
                    serverBase = value;
                }
            }
        }

        [ContextMethod("ОбработатьПриПодключенииКлиента", "ProcessingClientConnected")]
        public void ProcessingClientConnected(TsEventArgs args)
        {
            ServerBase.ProcessingClientConnected(args);
        }

        [ContextMethod("ОбработатьСерверПолучилДанные", "ProcessingServerReceived")]
        public void ProcessingServerReceived(TsEventArgs args)
        {
            ServerBase.ProcessingServerReceived(args);
        }

        [ContextMethod("ОбработатьПриОтключенииКлиента", "ProcessingClientDisconnected")]
        public void ProcessingClientDisconnected(TsEventArgs args)
        {
            ServerBase.ProcessingClientDisconnected(args);
        }

        [ContextMethod("ОбработатьПриОшибкеСервера", "ProcessingErrorServer")]
        public void ProcessingErrorServer(TsEventArgs args)
        {
            ServerBase.ProcessingErrorServer(args);
        }
    }
}
