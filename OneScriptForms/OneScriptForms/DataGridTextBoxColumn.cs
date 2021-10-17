using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class DataGridTextBoxColumnEx : System.Windows.Forms.DataGridTextBoxColumn
    {
        public osf.DataGridTextBoxColumn M_Object;
    }

    public class DataGridTextBoxColumn : DataGridColumnStyle
    {
        public ClDataGridTextBoxColumn dll_obj;
        public DataGridTextBoxColumnEx M_DataGridTextBoxColumn;

        public DataGridTextBoxColumn()
        {
            M_DataGridTextBoxColumn = new DataGridTextBoxColumnEx();
            M_DataGridTextBoxColumn.M_Object = this;
            base.M_DataGridColumnStyle = (System.Windows.Forms.DataGridColumnStyle)M_DataGridTextBoxColumn;
        }

        public DataGridTextBoxColumn(osf.DataGridTextBoxColumn p1)
        {
            M_DataGridTextBoxColumn = p1.M_DataGridTextBoxColumn;
            M_DataGridTextBoxColumn.M_Object = this;
            base.M_DataGridColumnStyle = M_DataGridTextBoxColumn;
        }

        public DataGridTextBoxColumn(System.Windows.Forms.DataGridTextBoxColumn p1)
        {
            M_DataGridTextBoxColumn = (DataGridTextBoxColumnEx)p1;
            M_DataGridTextBoxColumn.M_Object = this;
            base.M_DataGridColumnStyle = (System.Windows.Forms.DataGridColumnStyle)M_DataGridTextBoxColumn;
        }

        //Свойства============================================================

        public osf.DataGridTextBox TextBox
        {
            get { return new DataGridTextBox((System.Windows.Forms.DataGridTextBox)M_DataGridTextBoxColumn.TextBox); }
        }

        //Методы============================================================

    }

    [ContextClass ("КлСтильКолонкиПолеВвода", "ClDataGridTextBoxColumn")]
    public class ClDataGridTextBoxColumn : AutoContext<ClDataGridTextBoxColumn>
    {

        public ClDataGridTextBoxColumn()
        {
            DataGridTextBoxColumn DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn1.dll_obj = this;
            Base_obj = DataGridTextBoxColumn1;
        }
		
        public ClDataGridTextBoxColumn(DataGridTextBoxColumn p1)
        {
            DataGridTextBoxColumn DataGridTextBoxColumn1 = p1;
            DataGridTextBoxColumn1.dll_obj = this;
            Base_obj = DataGridTextBoxColumn1;
        }
        
        public DataGridTextBoxColumn Base_obj;

        //Свойства============================================================

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

        [ContextProperty("ПолеВвода", "TextBox")]
        public ClDataGridTextBox TextBox
        {
            get { return new ClDataGridTextBox(Base_obj.TextBox); }
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

        //Методы============================================================

        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
    }
}
