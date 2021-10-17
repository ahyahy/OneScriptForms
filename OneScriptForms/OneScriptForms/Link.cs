using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class LinkEx : System.Windows.Forms.LinkLabel.Link
    {
        public osf.Link M_Object;
    }

    public class Link
    {
        public ClLink dll_obj;
        public LinkEx M_Link;

        public Link()
        {
            M_Link = new LinkEx();
            M_Link.M_Object = this;
        }

        public Link(osf.Link p1)
        {
            M_Link = p1.M_Link;
            M_Link.M_Object = this;
        }

        public Link(System.Windows.Forms.LinkLabel.Link p1)
        {
            M_Link = (LinkEx)p1;
            M_Link.M_Object = this;
        }

        //Свойства============================================================

        public string Description
        {
            get { return M_Link.Description; }
            set { M_Link.Description = value; }
        }

        public bool Enabled
        {
            get { return M_Link.Enabled; }
            set { M_Link.Enabled = value; }
        }

        public int Length
        {
            get { return M_Link.Length; }
            set { M_Link.Length = value; }
        }

        public object LinkData
        {
            get { return M_Link.LinkData; }
            set { M_Link.LinkData = value; }
        }

        public string Name
        {
            get { return M_Link.Name; }
            set { M_Link.Name = value; }
        }

        public int Start
        {
            get { return M_Link.Start; }
            set { M_Link.Start = value; }
        }

        public bool Visited
        {
            get { return M_Link.Visited; }
            set { M_Link.Visited = value; }
        }

        //Методы============================================================

    }

    [ContextClass ("КлСсылка", "ClLink")]
    public class ClLink : AutoContext<ClLink>
    {
        private ClCollection tag = new ClCollection();

        public ClLink()
        {
            Link Link1 = new Link();
            Link1.dll_obj = this;
            Base_obj = Link1;
        }
		
        public ClLink(Link p1)
        {
            Link Link1 = p1;
            Link1.dll_obj = this;
            Base_obj = Link1;
        }
        
        public ClLink(System.Windows.Forms.LinkLabel.Link p1)
        {
            Link Link1 = new Link(p1);
            Link1.dll_obj = this;
            Base_obj = Link1;
        }

        public Link Base_obj;

        //Свойства============================================================

        [ContextProperty("Данные", "LinkData")]
        public IValue LinkData
        {
            get { return OneScriptForms.RevertObj(Base_obj.LinkData); }
            set { Base_obj.LinkData = value; }
        }

        [ContextProperty("Длина", "Length")]
        public int Length
        {
            get { return Base_obj.Length; }
            set { Base_obj.Length = value; }
        }

        [ContextProperty("Доступность", "Enabled")]
        public bool Enabled
        {
            get { return Base_obj.Enabled; }
            set { Base_obj.Enabled = value; }
        }

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
            set { Base_obj.Name = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("Начало", "Start")]
        public int Start
        {
            get { return Base_obj.Start; }
            set { Base_obj.Start = value; }
        }

        [ContextProperty("Описание", "Description")]
        public string Description
        {
            get { return Base_obj.Description; }
            set { Base_obj.Description = value; }
        }

        [ContextProperty("Посещена", "Visited")]
        public bool Visited
        {
            get { return Base_obj.Visited; }
            set { Base_obj.Visited = value; }
        }

        //Методы============================================================

    }
}
