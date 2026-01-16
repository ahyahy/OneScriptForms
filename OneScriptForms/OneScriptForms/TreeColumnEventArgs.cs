using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class TreeColumnEventArgs : osf.EventArgs
    {
        public new ClTreeColumnEventArgs dll_obj;
        public osf.TreeColumn column;

        public TreeColumnEventArgs(Aga.Controls.Tree.TreeColumn col)
        {
            column = ((TreeColumnEx)col).M_Object;
        }

        public osf.TreeColumn Column
        {
            get { return column; }
        }
    }

    [ContextClass("КлКолонкаДереваЗначенийАрг", "ClTreeColumnEventArgs")]
    public class ClTreeColumnEventArgs : AutoContext<ClTreeColumnEventArgs>
    {
        public ClTreeColumnEventArgs(osf.TreeColumnEventArgs p1)
        {
            TreeColumnEventArgs TreeColumnEventArgs1 = p1;
            TreeColumnEventArgs1.dll_obj = this;
            Base_obj = TreeColumnEventArgs1;
        }

        public TreeColumnEventArgs Base_obj;

        [ContextProperty("Колонка", "Column")]
        public ClTreeColumn Column
        {
            get { return Base_obj.Column.dll_obj; }
        }

        [ContextProperty("Отправитель", "Sender")]
        public IValue Sender
        {
            get { return OneScriptForms.RevertObj(Base_obj.Sender); }
        }

        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter
        {
            get { return (IValue)Base_obj.Parameter; }
        }

    }
}
