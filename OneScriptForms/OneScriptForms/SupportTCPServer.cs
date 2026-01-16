using ScriptEngine.HostedScript.Library;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections.Concurrent;
using System;
using ScriptEngine.HostedScript.Library.Binary;
using System.Collections.Generic;
using System.Threading;
using System.Collections;
using osf;

namespace osfMultiTcp
{
    [ContextClass("МногопоточныйTCPСерверДляОдноСкрипта", "OneScriptMultithreadedTCPServer")]
    public class OneScriptMultithreadedTCPServer : AutoContext<OneScriptMultithreadedTCPServer>
    {
        public static IValue EventAction = null;
        public static ConcurrentQueue<dynamic> EventQueue = new ConcurrentQueue<dynamic>();

        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor()
        {
            return new OneScriptMultithreadedTCPServer();
        }

        [ContextMethod("ОбработатьПриОтключенииКлиента", "ProcessingClientDisconnected")]
        public void ProcessingClientDisconnected(TsEventArgs args)
        {
            OneScriptForms.ProcessingClientDisconnected(args);
        }

        [ContextMethod("ОбработатьПриОшибкеСервера", "ProcessingErrorServer")]
        public void ProcessingErrorServer(TsEventArgs args)
        {
            OneScriptForms.ProcessingErrorServer(args);
        }

        [ContextMethod("ОбработатьПриПодключенииКлиента", "ProcessingClientConnected")]
        public void ProcessingClientConnected(TsEventArgs args)
        {
            OneScriptForms.ProcessingClientConnected(args);
        }

        [ContextMethod("ОбработатьСерверПолучилДанные", "ProcessingServerReceived")]
        public void ProcessingServerReceived(TsEventArgs args)
        {
            OneScriptForms.ProcessingServerReceived(args);
        }

        [ContextMethod("Кодировка", "Encoding")]
        public ClEncoding Encoding()
        {
            return new ClEncoding();
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
            get { return Event; }
        }

        public bool goOn = true;
        [ContextProperty("Продолжать", "GoOn")]
        public bool GoOn
        {
            get { return goOn; }
            set { goOn = value; }
        }

        [ContextMethod("ПолучитьСобытие", "DoEvents")]
        public DelegateAction DoEvents()
        {
            while (EventQueue.Count == 0)
            {
                System.Threading.Thread.Sleep(7);
            }

            IValue Action1 = EventHandling();
            if (Action1.GetType() == typeof(TsAction))
            {
                return DelegateAction.Create(((TsAction)Action1).Script, ((TsAction)Action1).MethodName);
            }
            return (DelegateAction)Action1;
        }

        public IValue EventHandling()
        {
            dynamic EventArgs1;
            EventQueue.TryDequeue(out EventArgs1);
            Event = EventArgs1;
            EventAction = EventArgs1.EventAction;
            return EventAction;
        }

        [ContextProperty("НоваяСтрока", "NewLine")]
        public string NewLine
        {
            get { return Utils.NewLine; }
        }

        [ContextMethod("МногопоточныйСервер", "MultithreadedServer")]
        public TsMultithreadedTCPServer MultithreadedTCPServer(int port)
        {
            return new TsMultithreadedTCPServer(port);
        }

        public static void ExecuteEvent(dynamic dll_objEvent)
        {
            if (dll_objEvent == null)
            {
                return;
            }
            if (dll_objEvent.GetType() == typeof(DelegateAction))
            {
                try
                {
                    ((DelegateAction)dll_objEvent).CallAsProcedure(0, null);
                }
                catch { }
            }
            else if (dll_objEvent.GetType() == typeof(TsAction))
            {
                TsAction Action1 = ((TsAction)dll_objEvent);
                IRuntimeContextInstance script = Action1.Script;
                string method = Action1.MethodName;
                ReflectorContext reflector = new ReflectorContext();
                try
                {
                    reflector.CallMethod(script, method, null);
                }
                catch { }
            }
            else
            {
                //System.Windows.Forms.MessageBox.Show("Обработчик события " + dll_objEvent.ToString() + " задан неверным типом.", "Обработчик события контрола", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxDefaultButton.Button1);
            }
            Event = null;
        }
    }

    public enum ServerState
    {
        Stopped,
        Starting,
        Running,
        Stopping,
        StoppedWithError
    }

    public class ByteBufferPool
    {
        private readonly ConcurrentQueue<byte[]> _pool = new ConcurrentQueue<byte[]>();
        private readonly int _bufferSize;
        private long _totalAllocations; // Для мониторинга.

        public ByteBufferPool(int bufferSize)
        {
            _bufferSize = bufferSize;
        }

        // Взять буфер из пула (если есть) или создать новый.
        public byte[] Rent()
        {
            if (_pool.TryDequeue(out var buffer))
            {
                Interlocked.Increment(ref _totalAllocations);
                return buffer;
            }

            // Пул пуст — создаём новый буфер.
            var newBuffer = new byte[_bufferSize];
            Interlocked.Increment(ref _totalAllocations);
            return newBuffer;
        }

        // Вернуть буфер в пул.
        public void Return(byte[] buffer)
        {
            if (buffer.Length != _bufferSize)
            {
                throw new ArgumentException("Буфер имеет неверный размер");
            }

            _pool.Enqueue(buffer);
        }

        // Метод для очистки пула (опционально)
        public void Clear()
        {
            while (_pool.TryDequeue(out _)) { }
        }

        // Текущий размер пула (для мониторинга).
        public int Count => _pool.Count;

        // Общее число аллокаций (для анализа эффективности).
        public long TotalAllocations => _totalAllocations;
    }

    public static class Helper
    {
        public static dynamic GetEventParameter(dynamic dll_objEvent)
        {
            if (dll_objEvent != null)
            {
                dynamic eventType = dll_objEvent.GetType();
                if (eventType == typeof(DelegateAction))
                {
                    return null;
                }
                else if (eventType == typeof(TsAction))
                {
                    return ((TsAction)dll_objEvent).Parameter;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }

    [ContextClass("ТсСостояниеСервера", "TsServerState")]
    public class TsMultithreadedTCPServerState : AutoContext<TsMultithreadedTCPServerState>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_stopped = 0; // 0 Сервер остановлен пользователем.
        private int m_starting = 1; // 1 Сервер запускается.
        private int m_running = 2; // 2 Сервер запущен.
        private int m_stopping = 3; // 3 Сервер останавливается.
        private int m_stoppedWithError = 4; // 4 Сервер остановлен из за ошибки.

        private List<IValue> _list;

        public int Count()
        {
            return _list.Count;
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IValue>)_list).GetEnumerator();
        }

        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return (item as IValue);
            }
        }

        [ContextProperty("Количество", "Count")]
        public int CountProp
        {
            get { return _list.Count; }
        }

        [ContextMethod("Получить", "Get")]
        public IValue Get(int index)
        {
            return _list[index];
        }

        [ContextMethod("Имя")]
        public string NameRu(decimal p1)
        {
            return namesRu.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        [ContextMethod("Name")]
        public string NameEn(decimal p1)
        {
            return namesEn.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        private static readonly Dictionary<decimal, string> namesRu = new Dictionary<decimal, string>
        {
            {1, "Запускается"},
            {2, "Запущен"},
            {3, "Останавливается"},
            {0, "Остановлен"},
            {4, "ОстановленСОшибкой"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Starting"},
            {2, "Running"},
            {3, "Stopping"},
            {0, "Stopped"},
            {4, "StoppedWithError"},
        };

        public TsMultithreadedTCPServerState()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Running));
            _list.Add(ValueFactory.Create(Starting));
            _list.Add(ValueFactory.Create(Stopped));
            _list.Add(ValueFactory.Create(StoppedWithError));
            _list.Add(ValueFactory.Create(Stopping));
        }

        [ContextProperty("Запускается", "Starting")]
        public int Starting
        {
            get { return m_starting; }
        }

        [ContextProperty("Запущен", "Running")]
        public int Running
        {
            get { return m_running; }
        }

        [ContextProperty("Останавливается", "Stopping")]
        public int Stopping
        {
            get { return m_stopping; }
        }

        [ContextProperty("Остановлен", "Stopped")]
        public int Stopped
        {
            get { return m_stopped; }
        }

        [ContextProperty("ОстановленСОшибкой", "StoppedWithError")]
        public int StoppedWithError
        {
            get { return m_stoppedWithError; }
        }
    }

    [ContextClass("ТсДействие", "TsAction")]
    public class TsAction : AutoContext<TsAction>
    {
        public TsAction(IRuntimeContextInstance script, string methodName, IValue param = null)
        {
            Script = script;
            MethodName = methodName;
            Parameter = param;
        }

        [ContextProperty("ИмяМетода", "MethodName")]
        public string MethodName { get; set; }

        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter { get; set; }

        [ContextProperty("Сценарий", "Script")]
        public IRuntimeContextInstance Script { get; set; }
    }

    [ContextClass("ТсАргументыСобытия", "TsEventArgs")]
    public class TsEventArgs : AutoContext<TsEventArgs>
    {
        public TsEventArgs()
        {
        }

        public TsEventArgs(BinaryDataBuffer p1)
        {
            data = p1;
        }
        public TsEventArgs(TsEventArgs p1)
        {
            data = p1.Data;
            clientId = p1.ClientId;
            serverError = p1.ServerError;
            parameter = p1.Parameter;
        }

        public IValue parameter;
        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter
        {
            get { return parameter; }
        }

        public string serverError = null;
        [ContextProperty("ОшибкаСервера", "ServerError")]
        public string ServerError
        {
            get { return serverError; }
        }

        public BinaryDataBuffer data = null;
        [ContextProperty("Данные", "Data")]
        public BinaryDataBuffer Data
        {
            get { return data; }
        }

        public string clientId = null;
        [ContextProperty("ИдентификаторКлиента", "ClientId")]
        public string ClientId
        {
            get { return clientId; }
        }

        public TsAction eventAction;
        public TsAction EventAction
        {
            get { return eventAction; }
        }
    }
}
