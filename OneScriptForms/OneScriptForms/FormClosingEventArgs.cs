using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class FormClosingEventArgs : CancelEventArgs
    {
        public new ClFormClosingEventArgs dll_obj;
        public int CloseReason;

        public FormClosingEventArgs(System.Windows.Forms.CloseReason p1, bool p2)
        {
            CloseReason = (int)p1;
            Cancel = p2;
        }
    }

    [ContextClass("КлПриЗакрытииФормыАрг", "ClFormClosingEventArgs")]
    public class ClFormClosingEventArgs : AutoContext<ClFormClosingEventArgs>
    {
        public ClFormClosingEventArgs()
        {
            FormClosingEventArgs FormClosingEventArgs1 = new FormClosingEventArgs(System.Windows.Forms.CloseReason.None, true);
            FormClosingEventArgs1.dll_obj = this;
            Base_obj = FormClosingEventArgs1;
        }

        public ClFormClosingEventArgs(FormClosingEventArgs p1)
        {
            FormClosingEventArgs FormClosingEventArgs1 = p1;
            FormClosingEventArgs1.dll_obj = this;
            Base_obj = FormClosingEventArgs1;
        }

        public FormClosingEventArgs Base_obj;

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

        [ContextProperty("ПричинаЗакрытия", "CloseReason")]
        public int CloseReason
        {
            get { return (int)Base_obj.CloseReason; }
        }

    }
}
