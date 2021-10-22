using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class DataGridBoolColumnEx : System.Windows.Forms.DataGridBoolColumn
    {
        public osf.DataGridBoolColumn M_Object;
    }

    public class DataGridBoolColumn : DataGridColumnStyle
    {
        public ClDataGridBoolColumn dll_obj;
        public DataGridBoolColumnEx M_DataGridBoolColumn;

        public DataGridBoolColumn()
        {
            M_DataGridBoolColumn = new DataGridBoolColumnEx();
            M_DataGridBoolColumn.M_Object = this;
            base.M_DataGridColumnStyle = M_DataGridBoolColumn;
        }

        public DataGridBoolColumn(osf.DataGridBoolColumn p1)
        {
            M_DataGridBoolColumn = p1.M_DataGridBoolColumn;
            M_DataGridBoolColumn.M_Object = this;
            base.M_DataGridColumnStyle = M_DataGridBoolColumn;
        }

        public DataGridBoolColumn(System.Windows.Forms.DataGridBoolColumn p1)
        {
            M_DataGridBoolColumn = (DataGridBoolColumnEx)p1;
            M_DataGridBoolColumn.M_Object = this;
            base.M_DataGridColumnStyle = M_DataGridBoolColumn;
        }
    }

    [ContextClass ("КлСтильКолонкиБулево", "ClDataGridBoolColumn")]
    public class ClDataGridBoolColumn : AutoContext<ClDataGridBoolColumn>
    {
        public ClDataGridBoolColumn()
        {
            DataGridBoolColumn DataGridBoolColumn1 = new DataGridBoolColumn();
            DataGridBoolColumn1.dll_obj = this;
            Base_obj = DataGridBoolColumn1;
        }
		
        public ClDataGridBoolColumn(DataGridBoolColumn p1)
        {
            DataGridBoolColumn DataGridBoolColumn1 = p1;
            DataGridBoolColumn1.dll_obj = this;
            Base_obj = DataGridBoolColumn1;
        }
        
        public DataGridBoolColumn Base_obj;
        
        [ContextProperty("Выравнивание", "Alignment")]
        public int Alignment
        {
            get { return (int)Base_obj.Alignment; }
            set { Base_obj.Alignment = value; }
        }

        [ContextProperty("ИмяОтображаемого", "MappingName")]
        public string MappingName
        {
            get { return Base_obj.MappingName; }
            set { Base_obj.MappingName = value; }
        }

        [ContextProperty("ТекстЗаголовка", "HeaderText")]
        public string HeaderText
        {
            get { return Base_obj.HeaderText; }
            set { Base_obj.HeaderText = value; }
        }

        [ContextProperty("ТолькоЧтение", "ReadOnly")]
        public bool ReadOnly
        {
            get { return Base_obj.ReadOnly; }
            set { Base_obj.ReadOnly = value; }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
            set { Base_obj.Width = value; }
        }
        
        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
    }
}
