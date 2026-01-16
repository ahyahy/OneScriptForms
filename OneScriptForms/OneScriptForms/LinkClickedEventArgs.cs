using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class LinkClickedEventArgs : EventArgs
    {
        public new ClLinkClickedEventArgs dll_obj;
        public string LinkText = "";

    }

    [ContextClass("КлСсылкаНажатаАрг", "ClLinkClickedEventArgs")]
    public class ClLinkClickedEventArgs : AutoContext<ClLinkClickedEventArgs>
    {
        public ClLinkClickedEventArgs()
        {
            LinkClickedEventArgs LinkClickedEventArgs1 = new LinkClickedEventArgs();
            LinkClickedEventArgs1.dll_obj = this;
            Base_obj = LinkClickedEventArgs1;
        }

        public ClLinkClickedEventArgs(LinkClickedEventArgs p1)
        {
            LinkClickedEventArgs LinkClickedEventArgs1 = p1;
            LinkClickedEventArgs1.dll_obj = this;
            Base_obj = LinkClickedEventArgs1;
        }

        public LinkClickedEventArgs Base_obj;

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

        [ContextProperty("ТекстСсылки", "LinkText")]
        public string LinkText
        {
            get { return Base_obj.LinkText; }
        }

    }
}
