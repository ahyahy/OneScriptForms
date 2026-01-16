using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class Cursor
    {
        public ClCursor dll_obj;
        public System.Windows.Forms.Cursor M_Cursor;

        public Cursor()
        {
            M_Cursor = System.Windows.Forms.Cursor.Current;
            OneScriptForms.AddToHashtable(M_Cursor, this);
        }

        public Cursor(osf.Cursor p1)
        {
            M_Cursor = p1.M_Cursor;
            OneScriptForms.AddToHashtable(M_Cursor, this);
        }

        public Cursor(System.Windows.Forms.Cursor p1)
        {
            M_Cursor = p1;
            OneScriptForms.AddToHashtable(M_Cursor, this);
        }

        public osf.Cursor Current
        {
            get { return new Cursor(System.Windows.Forms.Cursor.Current); }
            set { System.Windows.Forms.Cursor.Current = value.M_Cursor; }
        }

        public osf.Point Position
        {
            get { return new Point(System.Windows.Forms.Cursor.Position); }
            set { System.Windows.Forms.Cursor.Position = value.M_Point; }
        }

        public osf.Size Size
        {
            get { return new Size(M_Cursor.Size); }
        }
    }

    [ContextClass("КлКурсор", "ClCursor")]
    public class ClCursor : AutoContext<ClCursor>
    {
        public ClCursor()
        {
            Cursor Cursor1 = new Cursor();
            Cursor1.dll_obj = this;
            Base_obj = Cursor1;
        }

        public ClCursor(Cursor p1)
        {
            Cursor Cursor1 = p1;
            Cursor1.dll_obj = this;
            Base_obj = Cursor1;
        }

        public Cursor Base_obj;

        [ContextProperty("Позиция", "Position")]
        public ClPoint Position
        {
            get { return (ClPoint)OneScriptForms.RevertObj(Base_obj.Position); }
            set { Base_obj.Position = value.Base_obj; }
        }

        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
        }

        [ContextProperty("Текущий", "Current")]
        public ClCursor Current
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.Current); }
        }

    }
}
