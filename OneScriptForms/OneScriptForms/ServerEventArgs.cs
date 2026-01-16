using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.HostedScript.Library.Binary;
using osfMultiTcp;

namespace osf
{
    public class ServerEventArgs : EventArgs
    {
        public new ClServerEventArgs dll_obj;
        public string serverError = null;
        public string clientId = null;
        public BinaryDataBuffer data = null;

        public ServerEventArgs()
        {
        }

        public ServerEventArgs(TsEventArgs args)
        {
            serverError = args.ServerError;
            clientId = args.ClientId;
            data = args.Data;
        }

        public ServerEventArgs(BinaryDataBuffer p1)
        {
            data = p1;
        }
    }

    [ContextClass("КлСобытиеСервераАрг", "ClServerEventArgs")]
    public class ClServerEventArgs : AutoContext<ClServerEventArgs>
    {
        public ClServerEventArgs()
        {
            ServerEventArgs ServerEventArgs1 = new ServerEventArgs();
            ServerEventArgs1.dll_obj = this;
            Base_obj = ServerEventArgs1;
        }

        public ClServerEventArgs(ServerEventArgs p1)
        {
            ServerEventArgs ServerEventArgs1 = p1;
            ServerEventArgs1.dll_obj = this;
            Base_obj = ServerEventArgs1;
        }

        public ServerEventArgs Base_obj;

        [ContextProperty("Отправитель", "Sender")]
        public IValue Sender
        {
            get { return OneScriptForms.RevertObj(Base_obj.Sender); }
        }

        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter
        {
            get { return (IValue)Base_obj.Parameter; }
        }

        [ContextProperty("ОшибкаСервера", "ServerError")]
        public string ServerError
        {
            get { return Base_obj.serverError; }
        }

        [ContextProperty("ИдентификаторКлиента", "ClientId")]
        public string ClientId
        {
            get { return Base_obj.clientId; }
        }

        [ContextProperty("Данные", "Data")]
        public BinaryDataBuffer Data
        {
            get { return Base_obj.data; }
        }
    }
}
