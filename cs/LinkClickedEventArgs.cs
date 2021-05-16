using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class LinkClickedEventArgs : EventArgs
    {
        public new ClLinkClickedEventArgs dll_obj;
        public string LinkText = "";

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлСсылкаНажатаАрг", "ClLinkClickedEventArgs")]
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

        //Свойства============================================================

        [ContextProperty("ТекстСсылки", "LinkText")]
        public string LinkText
        {
            get { return Base_obj.LinkText; }
        }

        //Методы============================================================

    }
}
