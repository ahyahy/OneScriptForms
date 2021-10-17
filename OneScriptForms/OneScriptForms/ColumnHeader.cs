using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class ColumnHeaderEx : System.Windows.Forms.ColumnHeader
    {
        public osf.ColumnHeader M_Object;
    }

    public class ColumnHeader
    {
        public ClColumnHeader dll_obj;
        public ColumnHeaderEx M_ColumnHeader;
        public int SortType;

        public ColumnHeader()
        {
            M_ColumnHeader = new ColumnHeaderEx();
            M_ColumnHeader.M_Object = this;
            SortType = 0;
        }

        public ColumnHeader(osf.ColumnHeader p1)
        {
            M_ColumnHeader = p1.M_ColumnHeader;
            M_ColumnHeader.M_Object = this;
            SortType = 0;
        }

        public ColumnHeader(string text, int width, System.Windows.Forms.HorizontalAlignment alignment)
        {
            M_ColumnHeader = new ColumnHeaderEx();
            if (text is string)
            {
                M_ColumnHeader.Text = text;
            }
            M_ColumnHeader.Width = width;
            M_ColumnHeader.TextAlign = (System.Windows.Forms.HorizontalAlignment)alignment;
            M_ColumnHeader.M_Object = this;
            SortType = 0;
        }

        public ColumnHeader(System.Windows.Forms.ColumnHeader p1)
        {
            M_ColumnHeader = (ColumnHeaderEx)p1;
            M_ColumnHeader.M_Object = this;
            SortType = 0;
        }

        //Свойства============================================================

        public int Index
        {
            get { return M_ColumnHeader.Index; }
        }

        public string Text
        {
            get { return M_ColumnHeader.Text; }
            set { M_ColumnHeader.Text = value; }
        }

        public int TextAlign
        {
            get { return (int)M_ColumnHeader.TextAlign; }
            set { M_ColumnHeader.TextAlign = (System.Windows.Forms.HorizontalAlignment)value; }
        }

        public int Width
        {
            get { return M_ColumnHeader.Width; }
            set { M_ColumnHeader.Width = value; }
        }

        //Методы============================================================

    }

    [ContextClass ("КлКолонка", "ClColumnHeader")]
    public class ClColumnHeader : AutoContext<ClColumnHeader>
    {

        public ClColumnHeader()
        {
            ColumnHeader ColumnHeader1 = new ColumnHeader();
            ColumnHeader1.dll_obj = this;
            Base_obj = ColumnHeader1;
        }

        public ClColumnHeader(ColumnHeader p1)
        {
            ColumnHeader ColumnHeader1 = p1;
            ColumnHeader1.dll_obj = this;
            Base_obj = ColumnHeader1;
        }

        public ClColumnHeader(string p1, int p2, int p3)
        {
            ColumnHeader ColumnHeader1 = new ColumnHeader(p1, p2, (System.Windows.Forms.HorizontalAlignment)p3);
            ColumnHeader1.dll_obj = this;
            Base_obj = ColumnHeader1;
        }

        public ColumnHeader Base_obj;

        //Свойства============================================================

        [ContextProperty("ВыравниваниеТекста", "TextAlign")]
        public int TextAlign
        {
            get { return (int)Base_obj.TextAlign; }
            set { Base_obj.TextAlign = value; }
        }

        [ContextProperty("Индекс", "Index")]
        public int Index
        {
            get { return Base_obj.Index; }
        }

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("ТипСортировки", "SortType")]
        public int SortType
        {
            get { return (int)Base_obj.SortType; }
            set { Base_obj.SortType = value; }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
            set { Base_obj.Width = value; }
        }

        //Методы============================================================

    }
}
