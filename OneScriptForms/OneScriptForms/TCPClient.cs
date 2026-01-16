using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System;
using ScriptEngine.HostedScript.Library.Binary;
using System.Text;
using System.Threading.Tasks;
using osf;

namespace osfMultiTcp
{
    public class TCPClient
    {
        public TsTCPClient dll_obj;
        public System.Text.Encoding Encoding { get; set; } = System.Text.Encoding.UTF8;
        public System.Net.Sockets.TcpClient M_TcpClient;
        public string MessageReceived;

        public TCPClient()
        {
            M_TcpClient = new System.Net.Sockets.TcpClient();
            this.ClientReceived += TCPClient_ClientReceived;
        }

        public TCPClient(string HostName, int port)
        {
            M_TcpClient = new System.Net.Sockets.TcpClient(HostName, port);
            this.ClientReceived += TCPClient_ClientReceived;
        }

        public TCPClient(System.Net.Sockets.TcpClient p1)
        {
            M_TcpClient = p1;
            this.ClientReceived += TCPClient_ClientReceived;
        }

        private void TCPClient_ClientReceived(object sender, TsEventArgs e)
        {
            if (dll_obj?.ClientReceived != null)
            {
                var args = new TsEventArgs
                {
                    eventAction = dll_obj.ClientReceived,
                    parameter = Helper.GetEventParameter(dll_obj.ClientReceived),
                    data = e.Data
                };
                OneScriptForms.Event = args;
                OneScriptForms.ExecuteEvent(dll_obj.ClientReceived);
            }
        }

        public event EventHandler<TsEventArgs> ClientReceived;
        public void OnClientReceived(BinaryDataBuffer p1)
        {
            var handler = ClientReceived;
            if (handler != null)
            {
                handler(this, new TsEventArgs(p1));
            }
        }

        public bool Connected
        {
            get { return M_TcpClient.Connected; }
        }

        public void Close()
        {
            M_TcpClient.Close();
        }

        public void Connect(string hostname, int portNo)
        {
            M_TcpClient.Connect(hostname, portNo);
        }

        public System.Net.Sockets.NetworkStream GetStream()
        {
            return M_TcpClient.GetStream();
        }

        public async void Send(BinaryDataBuffer message)
        {
            if (!M_TcpClient.Connected)
            {
                Utils.GlobalContext().Echo("Ошибка отправки текста: Клиентотключен.");
                return;
            }

            try
            {
                var stream = M_TcpClient.GetStream();
                var data = message.Bytes;
                await stream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Utils.GlobalContext().Echo("Ошибка отправки буфера двоичных данных: " + ex.Message);
            }
        }

        public async void Send(string message)
        {
            if (!M_TcpClient.Connected)
            {
                Utils.GlobalContext().Echo("Ошибка отправки текста: Клиентотключен.");
                return;
            }

            try
            {
                var stream = M_TcpClient.GetStream();
                var data = Encoding.GetBytes(message.EndsWith("\n") ? message : message + "\n");
                await stream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Utils.GlobalContext().Echo("Ошибка отправки текста: " + ex.Message);
            }
        }
    }

    [ContextClass("ТсTCPКлиент", "TsTCPClient")]
    public class TsTCPClient : AutoContext<TsTCPClient>
    {
        public TsTCPClient()
        {
            TCPClient TCPClient1 = new TCPClient();
            TCPClient1.dll_obj = this;
            Base_obj = TCPClient1;
        }

        public TsTCPClient(string HostName, int port)
        {
            TCPClient TCPClient1 = new TCPClient(HostName, port);
            TCPClient1.dll_obj = this;
            Base_obj = TCPClient1;
        }

        public TsTCPClient(osfMultiTcp.TCPClient p1)
        {
            TCPClient TCPClient1 = p1;
            TCPClient1.dll_obj = this;
            Base_obj = TCPClient1;
        }

        public osfMultiTcp.TCPClient Base_obj;

        [ContextProperty("КлиентПолучилДанные", "ClientReceived")]
        public TsAction ClientReceived { get; set; }

        [ContextMethod("ОбработатьКлиентПолучилДанные", "ProcessingClientReceived")]
        public void ProcessingClientReceived(BinaryDataBuffer p1)
        {
            OneScriptForms.ProcessingClientReceived(p1);
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

        [ContextProperty("Подключен", "Connected")]
        public bool Connected
        {
            get { return Base_obj.Connected; }
        }

        [ContextMethod("Закрыть", "Close")]
        public void Close()
        {
            Base_obj.Close();
        }

        [ContextMethod("Отправить", "Send")]
        public void Send(IValue p1)
        {
            if (Utils.IsType<BinaryDataBuffer>(p1))
            {
                _ = Task.Run(() =>
                {
                    Base_obj.Send((BinaryDataBuffer)p1);
                });
            }
            else
            {
                _ = Task.Run(() =>
                {
                    Base_obj.Send(p1.AsString());
                });
            }
        }

        [ContextMethod("Подключить", "Connect")]
        public void Connect(string p1, int p2)
        {
            Base_obj.Connect(p1, p2);
        }

        [ContextMethod("ПолучитьПоток", "GetStream")]
        public TsNetworkStream GetStream()
        {
            try
            {
                return new TsNetworkStream(Base_obj.GetStream());
            }
            catch
            {
                return null;
            }
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
    }
}
