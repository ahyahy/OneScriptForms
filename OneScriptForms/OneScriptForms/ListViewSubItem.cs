using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class ListViewSubItem
    {
        public ClListViewSubItem dll_obj;
        public System.Windows.Forms.ListViewItem.ListViewSubItem M_ListViewSubItem;

        public ListViewSubItem(osf.ListViewSubItem p1)
        {
            M_ListViewSubItem = p1.M_ListViewSubItem;
            OneScriptForms.AddToHashtable(M_ListViewSubItem, this);
        }

        public ListViewSubItem(string p1 = "")
        {
            M_ListViewSubItem = new System.Windows.Forms.ListViewItem.ListViewSubItem();
            M_ListViewSubItem.Text = p1;
            OneScriptForms.AddToHashtable(M_ListViewSubItem, this);
        }

        public ListViewSubItem(System.Windows.Forms.ListViewItem.ListViewSubItem p1)
        {
            M_ListViewSubItem = p1;
            OneScriptForms.AddToHashtable(M_ListViewSubItem, this);
        }

        public osf.Color BackColor
        {
            get { return new Color(M_ListViewSubItem.BackColor); }
            set
            {
                M_ListViewSubItem.BackColor = value.M_Color;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Font Font
        {
            get { return new Font(M_ListViewSubItem.Font); }
            set { M_ListViewSubItem.Font = value.M_Font; }
        }

        public osf.Color ForeColor
        {
            get { return new Color(M_ListViewSubItem.ForeColor); }
            set { M_ListViewSubItem.ForeColor = value.M_Color; }
        }

        public object Tag
        {
            get { return M_ListViewSubItem.Tag; }
            set
            {
                M_ListViewSubItem.Tag = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public string Text
        {
            get { return M_ListViewSubItem.Text; }
            set
            {
                M_ListViewSubItem.Text = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }
    }

    [ContextClass("КлПодэлементСпискаЭлементов", "ClListViewSubItem")]
    public class ClListViewSubItem : AutoContext<ClListViewSubItem>
    {
        private ClColor backColor;
        private ClFont font;
        private ClColor foreColor;
        private ClCollection tag = new ClCollection();

        public ClListViewSubItem(string text = "")
        {
            ListViewSubItem ListViewSubItem1 = new ListViewSubItem(text);
            ListViewSubItem1.dll_obj = this;
            Base_obj = ListViewSubItem1;
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
        }

        public ClListViewSubItem(ListViewSubItem p1)
        {
            ListViewSubItem ListViewSubItem1 = p1;
            ListViewSubItem1.dll_obj = this;
            Base_obj = ListViewSubItem1;
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
        }

        public ListViewSubItem Base_obj;

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }

        [ContextProperty("ОсновнойЦвет", "ForeColor")]
        public ClColor ForeColor
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                Base_obj.ForeColor = value.Base_obj;
            }
        }

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("ЦветФона", "BackColor")]
        public ClColor BackColor
        {
            get { return backColor; }
            set
            {
                backColor = value;
                Base_obj.BackColor = value.Base_obj;
            }
        }

        [ContextProperty("Шрифт", "Font")]
        public ClFont Font
        {
            get
            {
                if (font != null)
                {
                    return font;
                }
                return new ClFont(Base_obj.Font);
            }
            set
            {
                font = value;
                Base_obj.Font = value.Base_obj;
            }
        }

    }
}
