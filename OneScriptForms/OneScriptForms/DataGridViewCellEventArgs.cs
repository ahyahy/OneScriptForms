using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class DataGridViewCellEventArgs : EventArgs
    {
        public new ClDataGridViewCellEventArgs dll_obj;
        public int ColumnIndex;
        public int RowIndex;

    }

    [ContextClass ("КлЯчейкаТаблицыАрг", "ClDataGridViewCellEventArgs")]
    public class ClDataGridViewCellEventArgs : AutoContext<ClDataGridViewCellEventArgs>
    {
        public ClDataGridViewCellEventArgs()
        {
            DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
            DataGridViewCellEventArgs1.dll_obj = this;
            Base_obj = DataGridViewCellEventArgs1;
        }
		
        public ClDataGridViewCellEventArgs(DataGridViewCellEventArgs p1)
        {
            DataGridViewCellEventArgs DataGridViewCellEventArgs1 = p1;
            DataGridViewCellEventArgs1.dll_obj = this;
            Base_obj = DataGridViewCellEventArgs1;
        }
        
        public DataGridViewCellEventArgs Base_obj;
        
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
        
    }
}
