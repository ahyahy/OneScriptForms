using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class DataGridCell
    {
        public ClDataGridCell dll_obj;
        public System.Windows.Forms.DataGridCell M_DataGridCell;

        public DataGridCell(System.Windows.Forms.DataGridCell p1)
        {
            M_DataGridCell = p1;
            OneScriptForms.AddToHashtable(M_DataGridCell, this);
        }

        public DataGridCell(int p1, int p2)
        {
            M_DataGridCell = new System.Windows.Forms.DataGridCell(p1, p2);
            M_DataGridCell.RowNumber = p1;
            M_DataGridCell.ColumnNumber = p2;
            OneScriptForms.AddToHashtable(M_DataGridCell, this);
        }

        public DataGridCell(osf.DataGridCell p1)
        {
            M_DataGridCell = p1.M_DataGridCell;
            OneScriptForms.AddToHashtable(M_DataGridCell, this);
        }

        //Свойства============================================================

        public int ColumnNumber
        {
            get { return M_DataGridCell.ColumnNumber; }
            set
            {
                M_DataGridCell.ColumnNumber = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int RowNumber
        {
            get { return M_DataGridCell.RowNumber; }
            set
            {
                M_DataGridCell.RowNumber = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        //Методы============================================================

    }

    [ContextClass ("КлЯчейкаСеткиДанных", "ClDataGridCell")]
    public class ClDataGridCell : AutoContext<ClDataGridCell>
    {

        public ClDataGridCell(int p1, int p2)
        {
            DataGridCell DataGridCell1 = new DataGridCell(p1, p2);
            DataGridCell1.dll_obj = this;
            Base_obj = DataGridCell1;
        }
		
        public ClDataGridCell(DataGridCell p1)
        {
            DataGridCell DataGridCell1 = p1;
            DataGridCell1.dll_obj = this;
            Base_obj = DataGridCell1;
        }

        public DataGridCell Base_obj;

        //Свойства============================================================

        [ContextProperty("НомерКолонки", "ColumnNumber")]
        public int ColumnNumber
        {
            get { return Base_obj.ColumnNumber; }
            set { Base_obj.ColumnNumber = value; }
        }

        [ContextProperty("НомерСтроки", "RowNumber")]
        public int RowNumber
        {
            get { return Base_obj.RowNumber; }
            set { Base_obj.RowNumber = value; }
        }

        //Методы============================================================

    }
}
