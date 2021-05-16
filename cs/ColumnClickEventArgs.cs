using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class ColumnClickEventArgs : EventArgs
    {
        public new ClColumnClickEventArgs dll_obj;
        public int Column = -1;

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлКолонкаНажатиеАрг", "ClColumnClickEventArgs")]
    public class ClColumnClickEventArgs : AutoContext<ClColumnClickEventArgs>
    {

        public ClColumnClickEventArgs()
        {
            ColumnClickEventArgs ColumnClickEventArgs1 = new ColumnClickEventArgs();
            ColumnClickEventArgs1.dll_obj = this;
            Base_obj = ColumnClickEventArgs1;
        }
		
        public ClColumnClickEventArgs(ColumnClickEventArgs p1)
        {
            ColumnClickEventArgs ColumnClickEventArgs1 = p1;
            ColumnClickEventArgs1.dll_obj = this;
            Base_obj = ColumnClickEventArgs1;
        }
        
        public ColumnClickEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Колонка", "Column")]
        public int Column
        {
            get { return Base_obj.Column; }
        }

        //Методы============================================================

    }
}
