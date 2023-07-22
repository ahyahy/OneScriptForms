using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewCheckBoxColumnEx : System.Windows.Forms.DataGridViewCheckBoxColumn
    {
        public osf.DataGridViewCheckBoxColumn M_Object;

        public DataGridViewCheckBoxColumnEx() : base()
        {
            this.CellTemplate = new DataGridViewCheckBoxCellEx();
        }
    }

    public class DataGridViewCheckBoxColumn : DataGridViewColumn
    {
        public new ClDataGridViewCheckBoxColumn dll_obj;
        private DataGridViewCheckBoxColumnEx M_DataGridViewCheckBoxColumn;

        public DataGridViewCheckBoxColumn()
        {
            M_DataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumnEx();
            M_DataGridViewCheckBoxColumn.M_Object = this;
            base.M_DataGridViewColumn = M_DataGridViewCheckBoxColumn;
        }

        public DataGridViewCheckBoxColumn(DataGridViewCheckBoxColumnEx p1)
        {
            M_DataGridViewCheckBoxColumn = p1;
            M_DataGridViewCheckBoxColumn.M_Object = this;
            base.M_DataGridViewColumn = M_DataGridViewCheckBoxColumn;
        }

        public DataGridViewCheckBoxColumn(osf.DataGridViewCheckBoxColumn p1)
        {
            M_DataGridViewCheckBoxColumn = p1.M_DataGridViewCheckBoxColumn;
            M_DataGridViewCheckBoxColumn.M_Object = this;
            base.M_DataGridViewColumn = M_DataGridViewCheckBoxColumn;
        }

        public object FalseValue
        {
            get { return M_DataGridViewCheckBoxColumn.FalseValue; }
            set { M_DataGridViewCheckBoxColumn.FalseValue = value; }
        }

        public int FlatStyle
        {
            get { return (int)M_DataGridViewCheckBoxColumn.FlatStyle; }
            set { M_DataGridViewCheckBoxColumn.FlatStyle = (System.Windows.Forms.FlatStyle)value; }
        }

        public object IndeterminateValue
        {
            get { return M_DataGridViewCheckBoxColumn.IndeterminateValue; }
            set { M_DataGridViewCheckBoxColumn.IndeterminateValue = value; }
        }

        public bool ThreeState
        {
            get { return M_DataGridViewCheckBoxColumn.ThreeState; }
            set { M_DataGridViewCheckBoxColumn.ThreeState = value; }
        }

        public object TrueValue
        {
            get { return M_DataGridViewCheckBoxColumn.TrueValue; }
            set { M_DataGridViewCheckBoxColumn.TrueValue = value; }
        }
    }

    [ContextClass ("КлКолонкаФлажок", "ClDataGridViewCheckBoxColumn")]
    public class ClDataGridViewCheckBoxColumn : AutoContext<ClDataGridViewCheckBoxColumn>
    {
        private ClCollection tag = new ClCollection();

        public ClDataGridViewCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            DataGridViewCheckBoxColumn1.dll_obj = this;
            Base_obj = DataGridViewCheckBoxColumn1;
        }
		
        public ClDataGridViewCheckBoxColumn(DataGridViewCheckBoxColumn p1)
        {
            DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn1 = p1;
            DataGridViewCheckBoxColumn1.dll_obj = this;
            Base_obj = DataGridViewCheckBoxColumn1;
        }
        
        public DataGridViewCheckBoxColumn Base_obj;
        
        [ContextProperty("ВесЗаполнения", "FillWeight")]
        public IValue FillWeight
        {
            get { return ValueFactory.Create((Convert.ToDecimal(Base_obj.FillWeight))); }
            set { Base_obj.FillWeight = Convert.ToSingle(value.AsNumber()); }
        }
        
        [ContextProperty("Выбран", "Selected")]
        public bool Selected
        {
            get { return Base_obj.Selected; }
            set { Base_obj.Selected = value; }
        }

        [ContextProperty("ЗаголовокКолонки", "HeaderCell")]
        public ClDataGridViewColumnHeaderCell HeaderCell
        {
            get { return (ClDataGridViewColumnHeaderCell)OneScriptForms.RevertObj(Base_obj.HeaderCell); }
            set { Base_obj.HeaderCell = value.Base_obj; }
        }

        [ContextProperty("Закреплено", "Frozen")]
        public bool Frozen
        {
            get { return Base_obj.Frozen; }
            set { Base_obj.Frozen = value; }
        }

        [ContextProperty("ИзменяемыйРазмер", "Resizable")]
        public int Resizable
        {
            get { return (int)Base_obj.Resizable; }
            set { Base_obj.Resizable = value; }
        }

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
            set { Base_obj.Name = value; }
        }

        [ContextProperty("ИмяСвойстваДанных", "DataPropertyName")]
        public string DataPropertyName
        {
            get { return Base_obj.DataPropertyName; }
            set { Base_obj.DataPropertyName = value; }
        }

        [ContextProperty("Индекс", "Index")]
        public int Index
        {
            get { return Base_obj.Index; }
        }

        [ContextProperty("ИндексОтображения", "DisplayIndex")]
        public int DisplayIndex
        {
            get { return Base_obj.DisplayIndex; }
            set { Base_obj.DisplayIndex = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("МинимальнаяШирина", "MinimumWidth")]
        public int MinimumWidth
        {
            get { return Base_obj.MinimumWidth; }
            set { Base_obj.MinimumWidth = value; }
        }

        [ContextProperty("Отображается", "Displayed")]
        public bool Displayed
        {
            get { return Base_obj.Displayed; }
        }

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
        }

        [ContextProperty("ПлоскийСтиль", "FlatStyle")]
        public int FlatStyle
        {
            get { return (int)Base_obj.FlatStyle; }
            set { Base_obj.FlatStyle = value; }
        }

        [ContextProperty("РежимАвтоРазмера", "AutoSizeMode")]
        public int AutoSizeMode
        {
            get { return (int)Base_obj.AutoSizeMode; }
            set { Base_obj.AutoSizeMode = value; }
        }

        [ContextProperty("РежимСортировки", "SortMode")]
        public int SortMode
        {
            get { return (int)Base_obj.SortMode; }
            set { Base_obj.SortMode = value; }
        }

        [ContextProperty("СоответствиеДляНеопределено", "IndeterminateValue")]
        public IValue IndeterminateValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.IndeterminateValue); }
            set { Base_obj.IndeterminateValue = value; }
        }

        [ContextProperty("СоответствиеДляНеПомечен", "FalseValue")]
        public IValue FalseValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.FalseValue); }
            set { Base_obj.FalseValue = value; }
        }

        [ContextProperty("СоответствиеДляПомечен", "TrueValue")]
        public IValue TrueValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.TrueValue); }
            set { Base_obj.TrueValue = value; }
        }

        [ContextProperty("СтильЯчейки", "DefaultCellStyle")]
        public ClDataGridViewCellStyle DefaultCellStyle
        {
            get { return (ClDataGridViewCellStyle)OneScriptForms.RevertObj(Base_obj.DefaultCellStyle); }
            set { Base_obj.DefaultCellStyle = value.Base_obj; }
        }

        [ContextProperty("Таблица", "DataGridView")]
        public ClDataGridView DataGridView
        {
            get { return (ClDataGridView)OneScriptForms.RevertObj(Base_obj.DataGridView); }
        }

        [ContextProperty("ТекстЗаголовка", "HeaderText")]
        public string HeaderText
        {
            get { return Base_obj.HeaderText; }
            set { Base_obj.HeaderText = value; }
        }

        [ContextProperty("ТекстПодсказки", "ToolTipText")]
        public string ToolTipText
        {
            get { return Base_obj.ToolTipText; }
            set { Base_obj.ToolTipText = value; }
        }

        [ContextProperty("ТолькоЧтение", "ReadOnly")]
        public bool ReadOnly
        {
            get { return Base_obj.ReadOnly; }
            set { Base_obj.ReadOnly = value; }
        }

        [ContextProperty("ТриСостояния", "ThreeState")]
        public bool ThreeState
        {
            get { return Base_obj.ThreeState; }
            set { Base_obj.ThreeState = value; }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
            set { Base_obj.Width = value; }
        }

        [ContextProperty("ШиринаРазделителя", "DividerWidth")]
        public int DividerWidth
        {
            get { return Base_obj.DividerWidth; }
            set { Base_obj.DividerWidth = value; }
        }
        
    }
}
