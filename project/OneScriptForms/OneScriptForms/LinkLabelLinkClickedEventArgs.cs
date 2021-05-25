using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class LinkLabelLinkClickedEventArgs : EventArgs
    {
        public int Button;
        public new ClLinkLabelLinkClickedEventArgs dll_obj;
        public osf.Link Link;

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлНадписьСсылкаСсылкаНажатаАрг", "ClLinkLabelLinkClickedEventArgs")]
    public class ClLinkLabelLinkClickedEventArgs : AutoContext<ClLinkLabelLinkClickedEventArgs>
    {

        public ClLinkLabelLinkClickedEventArgs()
        {
            LinkLabelLinkClickedEventArgs LinkLabelLinkClickedEventArgs1 = new LinkLabelLinkClickedEventArgs();
            LinkLabelLinkClickedEventArgs1.dll_obj = this;
            Base_obj = LinkLabelLinkClickedEventArgs1;
        }
		
        public ClLinkLabelLinkClickedEventArgs(LinkLabelLinkClickedEventArgs p1)
        {
            LinkLabelLinkClickedEventArgs LinkLabelLinkClickedEventArgs1 = p1;
            LinkLabelLinkClickedEventArgs1.dll_obj = this;
            Base_obj = LinkLabelLinkClickedEventArgs1;
        }
        
        public LinkLabelLinkClickedEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Кнопка", "Button")]
        public int Button
        {
            get { return (int)Base_obj.Button; }
        }

        [ContextProperty("Ссылка", "Link")]
        public ClLink Link
        {
            get { return (ClLink)OneScriptForms.RevertObj(Base_obj.Link); }
        }

        //Методы============================================================

    }
}
