using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewCellCancelEventArgs : CancelEventArgs
    {
        public new ClDataGridViewCellCancelEventArgs dll_obj;
        public int ColumnIndex;
        public int RowIndex;

    }

    [ContextClass ("КлЯчейкаОтменаАрг", "ClDataGridViewCellCancelEventArgs")]
    public class ClDataGridViewCellCancelEventArgs : AutoContext<ClDataGridViewCellCancelEventArgs>
    {
        public ClDataGridViewCellCancelEventArgs()
        {
            DataGridViewCellCancelEventArgs DataGridViewCellCancelEventArgs1 = new DataGridViewCellCancelEventArgs();
            DataGridViewCellCancelEventArgs1.dll_obj = this;
            Base_obj = DataGridViewCellCancelEventArgs1;
        }
		
        public ClDataGridViewCellCancelEventArgs(DataGridViewCellCancelEventArgs p1)
        {
            DataGridViewCellCancelEventArgs DataGridViewCellCancelEventArgs1 = p1;
            DataGridViewCellCancelEventArgs1.dll_obj = this;
            Base_obj = DataGridViewCellCancelEventArgs1;
        }
        
        public DataGridViewCellCancelEventArgs Base_obj;
        
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

        [ContextProperty("Отмена", "Cancel")]
        public bool Cancel
        {
            get { return Base_obj.Cancel; }
            set { Base_obj.Cancel = value; }
        }
        
    }
}
