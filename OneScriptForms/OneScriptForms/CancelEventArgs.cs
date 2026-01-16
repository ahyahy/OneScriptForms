using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class CancelEventArgs : EventArgs
    {
        public bool Cancel = false;
        public new ClCancelEventArgs dll_obj;

    }

    [ContextClass("КлОтменаАрг", "ClCancelEventArgs")]
    public class ClCancelEventArgs : AutoContext<ClCancelEventArgs>
    {
        public ClCancelEventArgs()
        {
            CancelEventArgs CancelEventArgs1 = new CancelEventArgs();
            CancelEventArgs1.dll_obj = this;
            Base_obj = CancelEventArgs1;
        }

        public ClCancelEventArgs(CancelEventArgs p1)
        {
            CancelEventArgs CancelEventArgs1 = p1;
            CancelEventArgs1.dll_obj = this;
            Base_obj = CancelEventArgs1;
        }

        public CancelEventArgs Base_obj;

        [ContextProperty("Отмена", "Cancel")]
        public bool Cancel
        {
            get { return Base_obj.Cancel; }
            set { Base_obj.Cancel = value; }
        }

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

    }
}
