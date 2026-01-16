using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridTextBoxColumnEx : System.Windows.Forms.DataGridTextBoxColumn
    {
        public osf.DataGridTextBoxColumn M_Object;
    }

    public class DataGridTextBoxColumn : DataGridColumnStyle
    {
        public ClDataGridTextBoxColumn dll_obj;
        public string DoubleClick;
        public DataGridTextBoxColumnEx M_DataGridTextBoxColumn;

        public DataGridTextBoxColumn()
        {
            M_DataGridTextBoxColumn = new DataGridTextBoxColumnEx();
            M_DataGridTextBoxColumn.M_Object = this;
            base.M_DataGridColumnStyle = (System.Windows.Forms.DataGridColumnStyle)M_DataGridTextBoxColumn;
            M_DataGridTextBoxColumn.TextBox.DoubleClick += TextBox_DoubleClick;
            M_DataGridTextBoxColumn.TextBox.MouseDown += TextBox_MouseDown;
            DoubleClick = "";
        }

        public DataGridTextBoxColumn(osf.DataGridTextBoxColumn p1)
        {
            M_DataGridTextBoxColumn = p1.M_DataGridTextBoxColumn;
            M_DataGridTextBoxColumn.M_Object = this;
            base.M_DataGridColumnStyle = M_DataGridTextBoxColumn;
            M_DataGridTextBoxColumn.TextBox.DoubleClick += TextBox_DoubleClick;
            M_DataGridTextBoxColumn.TextBox.MouseDown += TextBox_MouseDown;
            DoubleClick = "";
        }

        public DataGridTextBoxColumn(System.Windows.Forms.DataGridTextBoxColumn p1)
        {
            M_DataGridTextBoxColumn = (DataGridTextBoxColumnEx)p1;
            M_DataGridTextBoxColumn.M_Object = this;
            base.M_DataGridColumnStyle = (System.Windows.Forms.DataGridColumnStyle)M_DataGridTextBoxColumn;
            M_DataGridTextBoxColumn.TextBox.DoubleClick += TextBox_DoubleClick;
            M_DataGridTextBoxColumn.TextBox.MouseDown += TextBox_MouseDown;
            DoubleClick = "";
        }

        public osf.DataGridTextBox TextBox
        {
            get { return new DataGridTextBox((System.Windows.Forms.DataGridTextBox)M_DataGridTextBoxColumn.TextBox); }
        }

        public void TextBox_DoubleClick(object sender, System.EventArgs e)
        {
            if (DoubleClick.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = DoubleClick;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(dll_obj.DoubleClick);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(dll_obj.DoubleClick);
            }
        }

        public void TextBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (System.DateTime.Now < OneScriptForms.gridMouseDownTime.AddMilliseconds(System.Windows.Forms.SystemInformation.DoubleClickTime))
            {
                if (DoubleClick.Length > 0)
                {
                    EventArgs EventArgs1 = new EventArgs();
                    EventArgs1.EventString = DoubleClick;
                    EventArgs1.Sender = this;
                    EventArgs1.Parameter = OneScriptForms.GetEventParameter(dll_obj.DoubleClick);
                    ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                    OneScriptForms.Event = ClEventArgs1;
                    OneScriptForms.ExecuteEvent(dll_obj.DoubleClick);
                }
            }
        }
    }

    [ContextClass("КлСтильКолонкиПолеВвода", "ClDataGridTextBoxColumn")]
    public class ClDataGridTextBoxColumn : AutoContext<ClDataGridTextBoxColumn>
    {
        private IValue _DoubleClick;

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

        [ContextProperty("Выравнивание", "Alignment")]
        public int Alignment
        {
            get { return (int)Base_obj.Alignment; }
            set { Base_obj.Alignment = value; }
        }

        [ContextProperty("ДвойноеНажатие", "DoubleClick")]
        public IValue DoubleClick
        {
            get { return _DoubleClick; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _DoubleClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.DoubleClick = "DelegateActionDoubleClick";
                }
                else
                {
                    _DoubleClick = value;
                    Base_obj.DoubleClick = "osfActionDoubleClick";
                }
            }
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

        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
    }
}
