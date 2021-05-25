using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class LinkArea
    {
        public ClLinkArea dll_obj;
        public System.Windows.Forms.LinkArea M_LinkArea;

        public LinkArea(System.Windows.Forms.LinkArea p1)
        {
            M_LinkArea = p1;
            OneScriptForms.AddToHashtable(M_LinkArea, this);
        }

        public LinkArea(int p1, int p2)
        {
            M_LinkArea = new System.Windows.Forms.LinkArea(p1, p2);
            OneScriptForms.AddToHashtable(M_LinkArea, this);
        }

        public LinkArea(osf.LinkArea p1)
        {
            M_LinkArea = p1.M_LinkArea;
            OneScriptForms.AddToHashtable(M_LinkArea, this);
        }

        //Свойства============================================================

        public bool IsEmpty
        {
            get { return M_LinkArea.IsEmpty; }
        }

        public int Length
        {
            get { return M_LinkArea.Length; }
            set { M_LinkArea.Length = value; }
        }

        public int Start
        {
            get { return M_LinkArea.Start; }
            set { M_LinkArea.Start = value; }
        }

        //Методы============================================================

    }

    [ContextClass ("КлОбластьСсылки", "ClLinkArea")]
    public class ClLinkArea : AutoContext<ClLinkArea>
    {

        public ClLinkArea(int p1, int p2)
        {
            LinkArea LinkArea1 = new LinkArea(p1, p2);
            LinkArea1.dll_obj = this;
            Base_obj = LinkArea1;
        }
		
        public ClLinkArea(LinkArea p1)
        {
            LinkArea LinkArea1 = p1;
            LinkArea1.dll_obj = this;
            Base_obj = LinkArea1;
        }
		
        public ClLinkArea(System.Windows.Forms.LinkArea p1)
        {
            LinkArea LinkArea1 = new LinkArea(p1);
            LinkArea1.dll_obj = this;
            Base_obj = LinkArea1;
        }

        public LinkArea Base_obj;

        //Свойства============================================================

        [ContextProperty("Длина", "Length")]
        public int Length
        {
            get { return Base_obj.Length; }
            set { Base_obj.Length = value; }
        }

        [ContextProperty("Начало", "Start")]
        public int Start
        {
            get { return Base_obj.Start; }
            set { Base_obj.Start = value; }
        }

        [ContextProperty("Пусто", "IsEmpty")]
        public bool IsEmpty
        {
            get { return Base_obj.IsEmpty; }
        }

        //Методы============================================================

    }
}
