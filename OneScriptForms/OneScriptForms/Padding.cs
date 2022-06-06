using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class Padding
    {
        public ClPadding dll_obj;
        public System.Windows.Forms.Padding M_Padding;

        public Padding()
        {
            M_Padding = System.Windows.Forms.Padding.Empty;
        }

        public Padding(int p1)
        {
            M_Padding = new System.Windows.Forms.Padding(p1);
        }

        public Padding(int p1, int p2, int p3, int p4)
        {
            M_Padding = new System.Windows.Forms.Padding(p1, p2, p3, p4);
        }

        public Padding(osf.Padding p1)
        {
            M_Padding = p1.M_Padding;
        }

        public Padding(System.Windows.Forms.Padding p1)
        {
            M_Padding = p1;
        }

        public int All
        {
            get { return M_Padding.All; }
            set { M_Padding.All = value; }
        }

        public int Bottom
        {
            get { return M_Padding.Bottom; }
            set { M_Padding.Bottom = value; }
        }

        public int Horizontal
        {
            get { return M_Padding.Horizontal; }
        }

        public int Left
        {
            get { return M_Padding.Left; }
            set { M_Padding.Left = value; }
        }

        public int Right
        {
            get { return M_Padding.Right; }
            set { M_Padding.Right = value; }
        }

        public osf.Size Size
        {
            get { return new Size(M_Padding.Size); }
        }

        public int Top
        {
            get { return M_Padding.Top; }
            set { M_Padding.Top = value; }
        }

        public int Vertical
        {
            get { return M_Padding.Vertical; }
        }
    }

    [ContextClass ("КлЗаполнение", "ClPadding")]
    public class ClPadding : AutoContext<ClPadding>
    {
        public ClPadding()
        {
            Padding Padding1 = new Padding();
            Padding1.dll_obj = this;
            Base_obj = Padding1;
        }
		
        public ClPadding(int p1)
        {
            Padding Padding1 = new Padding(p1);
            Padding1.dll_obj = this;
            Base_obj = Padding1;
        }

        public ClPadding(int p1, int p2, int p3, int p4)
        {
            Padding Padding1 = new Padding(p1, p2, p3, p4);
            Padding1.dll_obj = this;
            Base_obj = Padding1;
        }

        public ClPadding(Padding p1)
        {
            Padding Padding1 = p1;
            Padding1.dll_obj = this;
            Base_obj = Padding1;
        }

        public Padding Base_obj;
        
        [ContextProperty("Вертикаль", "Vertical")]
        public int Vertical
        {
            get { return Base_obj.Vertical; }
        }

        [ContextProperty("Верх", "Top")]
        public int Top
        {
            get { return Base_obj.Top; }
            set { Base_obj.Top = value; }
        }

        [ContextProperty("Все", "All")]
        public int All
        {
            get { return Base_obj.All; }
            set { Base_obj.All = value; }
        }

        [ContextProperty("Горизонталь", "Horizontal")]
        public int Horizontal
        {
            get { return Base_obj.Horizontal; }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
            get { return Base_obj.Left; }
            set { Base_obj.Left = value; }
        }

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
            get { return Base_obj.Bottom; }
            set { Base_obj.Bottom = value; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
            get { return Base_obj.Right; }
            set { Base_obj.Right = value; }
        }

        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
        }
        
    }
}
