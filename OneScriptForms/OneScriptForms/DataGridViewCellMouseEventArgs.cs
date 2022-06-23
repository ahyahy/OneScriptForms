using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class DataGridViewCellMouseEventArgs : MouseEventArgs
    {
        public new ClDataGridViewCellMouseEventArgs dll_obj;
        public int ColumnIndex;
        public int RowIndex;

    }

    [ContextClass ("КлЯчейкаТаблицыМышьАрг", "ClDataGridViewCellMouseEventArgs")]
    public class ClDataGridViewCellMouseEventArgs : AutoContext<ClDataGridViewCellMouseEventArgs>
    {
        public ClDataGridViewCellMouseEventArgs()
        {
            DataGridViewCellMouseEventArgs DataGridViewCellMouseEventArgs1 = new DataGridViewCellMouseEventArgs();
            DataGridViewCellMouseEventArgs1.dll_obj = this;
            Base_obj = DataGridViewCellMouseEventArgs1;
        }
		
        public ClDataGridViewCellMouseEventArgs(DataGridViewCellMouseEventArgs p1)
        {
            DataGridViewCellMouseEventArgs DataGridViewCellMouseEventArgs1 = p1;
            DataGridViewCellMouseEventArgs1.dll_obj = this;
            Base_obj = DataGridViewCellMouseEventArgs1;
        }
        
        public DataGridViewCellMouseEventArgs Base_obj;
        
        [ContextProperty("Игрек", "Y")]
        public int Y
        {
            get { return Base_obj.Y; }
        }

        [ContextProperty("Икс", "X")]
        public int X
        {
            get { return Base_obj.X; }
        }

        [ContextProperty("ИндексКолонки", "ColumnIndex")]
        public int ColumnIndex
        {
            get { return Base_obj.ColumnIndex; }
        }

        [ContextProperty("ИндексСтроки", "RowIndex")]
        public int RowIndex
        {
            get { return Base_obj.RowIndex; }
        }

        [ContextProperty("Кнопка", "Button")]
        public int Button
        {
            get { return (int)Base_obj.Button; }
        }

        [ContextProperty("Нажатия", "Clicks")]
        public int Clicks
        {
            get { return Base_obj.Clicks; }
        }
        
    }
}
