using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System;
using ScriptEngine.HostedScript.Library.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using osf;

namespace osfMultiTcp
{
    public class TCPClientSSL
    {
        public TsTCPClientSSL dll_obj;
        public System.Text.Encoding Encoding { get; set; } = System.Text.Encoding.UTF8;
        public System.Net.Sockets.TcpClient M_TcpClient;
        public string MessageReceived;
        public string pathCertificateCrt;
        public string hostname;
        public SslStream sslStream;
        public SemaphoreSlim WriteLock { get; } = new SemaphoreSlim(1, 1); // Семафор для синхронизации записи

        public TCPClientSSL()
        {
            M_TcpClient = new System.Net.Sockets.TcpClient();
            this.ClientReceived += TCPClient_ClientReceived;
        }

        public TCPClientSSL(string HostName, int port, string path_certificate_crt)
        {
            M_TcpClient = new System.Net.Sockets.TcpClient(HostName, port);
            this.ClientReceived += TCPClient_ClientReceived;

            pathCertificateCrt = path_certificate_crt;

            sslStream = new SslStream(
                M_TcpClient.GetStream(),
                false,
                new RemoteCertificateValidationCallback(ValidateCertificate),
                null);

            try
            {
                sslStream.AuthenticateAsClient(HostName);
            }
            catch (Exception ex)
            {
                Utils.GlobalContext().Echo("Ошибка аутентификации клиента: " + ex.StackTrace);
            }
        }

        public bool ValidateCertificate(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if (pathCertificateCrt != null)
            {
                // Cравниваем с ожидаемым сертификатом.
                var expectedCert = new X509Certificate2(pathCertificateCrt);
                return certificate.GetCertHashString() == expectedCert.GetCertHashString();
            }
            else
            {
                // Для самоподписанных сертификатов просто проверяем, что он есть.
                if (sslPolicyErrors == SslPolicyErrors.None)
                {
                    return true;
                }
            }
            return false;
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
                OneScriptMultithreadedTCPServer.Event = args;
                OneScriptMultithreadedTCPServer.ExecuteEvent(dll_obj.ClientReceived);
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

        public void Connect(string _hostname, int portNo, string path_certificate_crt)
        {
            hostname = _hostname;
            pathCertificateCrt = path_certificate_crt;
            M_TcpClient.Connect(hostname, portNo);

            sslStream = new SslStream(
                M_TcpClient.GetStream(),
                false,
                new RemoteCertificateValidationCallback(ValidateCertificate),
                null);

            try
            {
                sslStream.AuthenticateAsClient(hostname);
            }
            catch (Exception ex)
            {
                Utils.GlobalContext().Echo("Ошибка аутентификации клиента: " + ex.StackTrace);
            }
        }

        public SslStream GetSslStream()
        {
            return sslStream;
        }

        public async void Send(BinaryDataBuffer message)
        {
            if (!M_TcpClient.Connected)
            {
                Utils.GlobalContext().Echo("Ошибка отправки текста: Клиентотключен.");
                return;
            }

            await WriteLock.WaitAsync();
            try
            {
                var data = message.Bytes;
                await sslStream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Utils.GlobalContext().Echo("Ошибка отправки буфера двоичных данных: " + ex.Message);
            }
            finally
            {
                WriteLock.Release();
            }
        }

        public async void Send(string message)
        {
            if (!M_TcpClient.Connected)
            {
                Utils.GlobalContext().Echo("Ошибка отправки текста: Клиентотключен.");
                return;
            }

            await WriteLock.WaitAsync();
            try
            {
                var data = Encoding.GetBytes(message.EndsWith("\n") ? message : message + "\n");
                await sslStream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Utils.GlobalContext().Echo("Ошибка отправки текста: " + ex.Message);
            }
            finally
            {
                WriteLock.Release();
            }
        }
    }

    [ContextClass("ТсTCPКлиентSSL", "TsTCPClientSSL")]
    public class TsTCPClientSSL : AutoContext<TsTCPClientSSL>
    {
        public TsTCPClientSSL()
        {
            TCPClientSSL TCPClientSSL1 = new TCPClientSSL();
            TCPClientSSL1.dll_obj = this;
            Base_obj = TCPClientSSL1;
        }

        public TsTCPClientSSL(string HostName, int port, string path_certificate_crt = null)
        {
            TCPClientSSL TCPClientSSL1 = new TCPClientSSL(HostName, port, path_certificate_crt);
            TCPClientSSL1.dll_obj = this;
            Base_obj = TCPClientSSL1;
        }

        public TCPClientSSL Base_obj;

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
        public void Connect(string p1, int p2, string path_certificate_crt = "certificate.crt")
        {
            Base_obj.Connect(p1, p2, path_certificate_crt);
        }

        [ContextMethod("ПолучитьПотокSSL", "GetStreamSSL")]
        public TsSslStreamWrapper GetStreamSSL()
        {
            try
            {
                var sslStream = Base_obj.GetSslStream();
                if (sslStream != null)
                {
                    TsSslStreamWrapper wrapper = new TsSslStreamWrapper(sslStream);
                    return wrapper;
                }
                return null;
            }
            catch (Exception ex)
            {
                Utils.GlobalContext().Echo("Ошибка получения потока: " + ex.Message);
                return null;
            }
        }
    }
}
