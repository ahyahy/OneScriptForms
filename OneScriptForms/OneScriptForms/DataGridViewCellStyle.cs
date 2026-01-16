using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class DataGridViewCellStyle
    {
        public ClDataGridViewCellStyle dll_obj;
        public System.Windows.Forms.DataGridViewCellStyle M_DataGridViewCellStyle;

        public DataGridViewCellStyle()
        {
            M_DataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            OneScriptForms.AddToHashtable(M_DataGridViewCellStyle, this);
        }

        public DataGridViewCellStyle(osf.DataGridViewCellStyle p1)
        {
            M_DataGridViewCellStyle = p1.M_DataGridViewCellStyle;
            OneScriptForms.AddToHashtable(M_DataGridViewCellStyle, this);
        }

        public DataGridViewCellStyle(System.Windows.Forms.DataGridViewCellStyle p1)
        {
            M_DataGridViewCellStyle = p1;
            OneScriptForms.AddToHashtable(M_DataGridViewCellStyle, this);
        }

        public int Alignment
        {
            get { return (int)M_DataGridViewCellStyle.Alignment; }
            set { M_DataGridViewCellStyle.Alignment = (System.Windows.Forms.DataGridViewContentAlignment)value; }
        }

        public osf.Color BackColor
        {
            get { return new Color(M_DataGridViewCellStyle.BackColor); }
            set { M_DataGridViewCellStyle.BackColor = value.M_Color; }
        }

        public osf.Font Font
        {
            get { return new Font(M_DataGridViewCellStyle.Font); }
            set { M_DataGridViewCellStyle.Font = value.M_Font; }
        }

        public osf.Color ForeColor
        {
            get { return new Color(M_DataGridViewCellStyle.ForeColor); }
            set { M_DataGridViewCellStyle.ForeColor = value.M_Color; }
        }

        public osf.Padding Padding
        {
            get { return new Padding(M_DataGridViewCellStyle.Padding); }
            set { M_DataGridViewCellStyle.Padding = value.M_Padding; }
        }

        public osf.Color SelectionBackColor
        {
            get { return new Color(M_DataGridViewCellStyle.SelectionBackColor); }
            set { M_DataGridViewCellStyle.SelectionBackColor = value.M_Color; }
        }

        public osf.Color SelectionForeColor
        {
            get { return new Color(M_DataGridViewCellStyle.SelectionForeColor); }
            set { M_DataGridViewCellStyle.SelectionForeColor = value.M_Color; }
        }

        public int WrapMode
        {
            get { return (int)M_DataGridViewCellStyle.WrapMode; }
            set { M_DataGridViewCellStyle.WrapMode = (System.Windows.Forms.DataGridViewTriState)value; }
        }
    }

    [ContextClass("КлСтильЯчейки", "ClDataGridViewCellStyle")]
    public class ClDataGridViewCellStyle : AutoContext<ClDataGridViewCellStyle>
    {
        private ClColor backColor;
        private ClFont font;
        private ClColor foreColor;
        private ClColor selectionBackColor;
        private ClColor selectionForeColor;
        private ClCollection tag = new ClCollection();

        public ClDataGridViewCellStyle()
        {
            DataGridViewCellStyle DataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle1.dll_obj = this;
            Base_obj = DataGridViewCellStyle1;
            foreColor = new ClColor(Base_obj.ForeColor);
            selectionForeColor = new ClColor(Base_obj.SelectionForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            selectionBackColor = new ClColor(Base_obj.SelectionBackColor);
        }

        public ClDataGridViewCellStyle(DataGridViewCellStyle p1)
        {
            DataGridViewCellStyle DataGridViewCellStyle1 = p1;
            DataGridViewCellStyle1.dll_obj = this;
            Base_obj = DataGridViewCellStyle1;
            foreColor = new ClColor(Base_obj.ForeColor);
            selectionForeColor = new ClColor(Base_obj.SelectionForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            selectionBackColor = new ClColor(Base_obj.SelectionBackColor);
        }

        public DataGridViewCellStyle Base_obj;

        [ContextProperty("Выравнивание", "Alignment")]
        public int Alignment
        {
            get { return (int)Base_obj.Alignment; }
            set { Base_obj.Alignment = value; }
        }

        [ContextProperty("Заполнение", "Padding")]
        public ClPadding Padding
        {
            get { return new ClPadding(Base_obj.Padding); }
            set { Base_obj.Padding = value.Base_obj; }
        }

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

        [ContextProperty("ОсновнойЦветВыделенного", "SelectionForeColor")]
        public ClColor SelectionForeColor
        {
            get { return selectionForeColor; }
            set
            {
                selectionForeColor = value;
                Base_obj.SelectionForeColor = value.Base_obj;
            }
        }

        [ContextProperty("Перенос", "WrapMode")]
        public int WrapMode
        {
            get { return (int)Base_obj.WrapMode; }
            set { Base_obj.WrapMode = value; }
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

        [ContextProperty("ЦветФонаВыделенного", "SelectionBackColor")]
        public ClColor SelectionBackColor
        {
            get { return selectionBackColor; }
            set
            {
                selectionBackColor = value;
                Base_obj.SelectionBackColor = value.Base_obj;
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
