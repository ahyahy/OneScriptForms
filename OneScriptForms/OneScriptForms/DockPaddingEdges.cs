using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class DockPaddingEdges
    {
        public ClDockPaddingEdges dll_obj;
        public System.Windows.Forms.ScrollableControl.DockPaddingEdges M_DockPaddingEdges;

        public DockPaddingEdges(osf.DockPaddingEdges p1)
        {
            M_DockPaddingEdges = p1.M_DockPaddingEdges;
            OneScriptForms.AddToHashtable(M_DockPaddingEdges, this);
        }

        public DockPaddingEdges(System.Windows.Forms.ScrollableControl.DockPaddingEdges p1)
        {
            M_DockPaddingEdges = p1;
            OneScriptForms.AddToHashtable(M_DockPaddingEdges, this);
        }

        public int All
        {
            get { return M_DockPaddingEdges.All; }
            set { M_DockPaddingEdges.All = value; }
        }

        public int Bottom
        {
            get { return M_DockPaddingEdges.Bottom; }
            set { M_DockPaddingEdges.Bottom = value; }
        }

        public int Left
        {
            get { return M_DockPaddingEdges.Left; }
            set { M_DockPaddingEdges.Left = value; }
        }

        public int Right
        {
            get { return M_DockPaddingEdges.Right; }
            set { M_DockPaddingEdges.Right = value; }
        }

        public int Top
        {
            get { return M_DockPaddingEdges.Top; }
            set { M_DockPaddingEdges.Top = value; }
        }
    }

    [ContextClass ("КлЗаполнениеГраниц", "ClDockPaddingEdges")]
    public class ClDockPaddingEdges : AutoContext<ClDockPaddingEdges>
    {
        public ClDockPaddingEdges(DockPaddingEdges p1)
        {
            DockPaddingEdges DockPaddingEdges1 = p1;
            DockPaddingEdges1.dll_obj = this;
            Base_obj = DockPaddingEdges1;
        }

        public DockPaddingEdges Base_obj;
        
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
        
    }
}
