using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewComboBoxColumnEx : System.Windows.Forms.DataGridViewComboBoxColumn
    {
        public osf.DataGridViewComboBoxColumn M_Object;

        public DataGridViewComboBoxColumnEx() : base()
        {
            this.CellTemplate = new DataGridViewComboBoxCellEx();
        }
    }

    public class DataGridViewComboBoxColumn : DataGridViewColumn
    {
        public new ClDataGridViewComboBoxColumn dll_obj;
        private dynamic M_DataGridViewComboBoxColumn;

        public DataGridViewComboBoxColumn()
        {
            M_DataGridViewComboBoxColumn = new DataGridViewComboBoxColumnEx();
            M_DataGridViewComboBoxColumn.M_Object = this;
            base.M_DataGridViewColumn = M_DataGridViewComboBoxColumn;
            M_DataGridViewComboBoxColumn.DisplayMember = "Text";
            M_DataGridViewComboBoxColumn.ValueMember = "Value";
        }

        public DataGridViewComboBoxColumn(DataGridViewComboBoxColumnEx p1)
        {
            M_DataGridViewComboBoxColumn = p1;
            M_DataGridViewComboBoxColumn.M_Object = this;
            base.M_DataGridViewColumn = M_DataGridViewComboBoxColumn;
        }

        public DataGridViewComboBoxColumn(osf.DataGridViewComboBoxColumn p1)
        {
            M_DataGridViewComboBoxColumn = p1.M_DataGridViewComboBoxColumn;
            M_DataGridViewComboBoxColumn.M_Object = this;
            base.M_DataGridViewColumn = M_DataGridViewComboBoxColumn;
        }

        public DataGridViewComboBoxColumn(System.Windows.Forms.DataGridViewComboBoxColumn p1)
        {
            M_DataGridViewComboBoxColumn = p1;
            base.M_DataGridViewColumn = M_DataGridViewComboBoxColumn;
        }

        public object DataSource
        {
            get
            {
                object obj;
                try
                {
                    obj = ((dynamic)M_DataGridViewComboBoxColumn.DataSource).M_Object;
                }
                catch
                {
                    obj = M_DataGridViewComboBoxColumn.DataSource;
                }
                return obj;
            }
            set
            {
                M_DataGridViewComboBoxColumn.DataSource = null;
                try
                {
                    System.Type Type1 = value.GetType();
                    string strType1 = Type1.ToString();
                    string str1 = strType1.Substring(strType1.LastIndexOf(".") + 1);
                    M_DataGridViewComboBoxColumn.DataSource = Type1.GetField("M_" + str1).GetValue(value);
                }
                catch
                {
                    M_DataGridViewComboBoxColumn.DataSource = value;
                }
            }
        }

        public string DisplayMember
        {
            get { return M_DataGridViewComboBoxColumn.DisplayMember; }
            set { M_DataGridViewComboBoxColumn.DisplayMember = value; }
        }

        public int DisplayStyle
        {
            get { return (int)M_DataGridViewComboBoxColumn.DisplayStyle; }
            set { M_DataGridViewComboBoxColumn.DisplayStyle = (System.Windows.Forms.DataGridViewComboBoxDisplayStyle)value; }
        }

        public int FlatStyle
        {
            get { return (int)M_DataGridViewComboBoxColumn.FlatStyle; }
            set { M_DataGridViewComboBoxColumn.FlatStyle = (System.Windows.Forms.FlatStyle)value; }
        }

        public osf.DataGridViewComboBoxCellObjectCollection Items
        {
            get { return new DataGridViewComboBoxCellObjectCollection(M_DataGridViewComboBoxColumn.Items); }
        }

        public int MaxDropDownItems
        {
            get { return M_DataGridViewComboBoxColumn.MaxDropDownItems; }
            set { M_DataGridViewComboBoxColumn.MaxDropDownItems = value; }
        }

        public bool Sorted
        {
            get { return M_DataGridViewComboBoxColumn.Sorted; }
            set { M_DataGridViewComboBoxColumn.Sorted = value; }
        }

        public string ValueMember
        {
            get { return M_DataGridViewComboBoxColumn.ValueMember; }
            set { M_DataGridViewComboBoxColumn.ValueMember = value; }
        }
    }

    [ContextClass ("КлКолонкаПолеВыбора", "ClDataGridViewComboBoxColumn")]
    public class ClDataGridViewComboBoxColumn : AutoContext<ClDataGridViewComboBoxColumn>
    {
        private ClCollection tag = new ClCollection();

        public ClDataGridViewComboBoxColumn()
        {
            DataGridViewComboBoxColumn DataGridViewComboBoxColumn1 = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn1.dll_obj = this;
            Base_obj = DataGridViewComboBoxColumn1;
        }
		
        public ClDataGridViewComboBoxColumn(DataGridViewComboBoxColumn p1)
        {
            DataGridViewComboBoxColumn DataGridViewComboBoxColumn1 = p1;
            DataGridViewComboBoxColumn1.dll_obj = this;
            Base_obj = DataGridViewComboBoxColumn1;
        }
        
        public DataGridViewComboBoxColumn Base_obj;
        
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

        [ContextProperty("ЗначениеЭлемента", "ValueMember")]
        public string ValueMember
        {
            get { return Base_obj.ValueMember; }
            set { Base_obj.ValueMember = value; }
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

        [ContextProperty("ИсточникДанных", "DataSource")]
        public IValue DataSource
        {
            get { return OneScriptForms.RevertObj(Base_obj.DataSource); }
            set
            {
                try
                {
                    Base_obj.DataSource = ((dynamic)value).Base_obj;
                }
                catch
                {
                    Base_obj.DataSource = null;
                }
            }
        }

        [ContextProperty("МаксимумЭлементов", "MaxDropDownItems")]
        public int MaxDropDownItems
        {
            get { return Base_obj.MaxDropDownItems; }
            set { Base_obj.MaxDropDownItems = value; }
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

        [ContextProperty("ОтображениеЭлемента", "DisplayMember")]
        public string DisplayMember
        {
            get { return Base_obj.DisplayMember; }
            set { Base_obj.DisplayMember = value; }
        }

        [ContextProperty("Отсортирован", "Sorted")]
        public bool Sorted
        {
            get { return Base_obj.Sorted; }
            set { Base_obj.Sorted = value; }
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

        [ContextProperty("СтильОтображения", "DisplayStyle")]
        public int DisplayStyle
        {
            get { return (int)Base_obj.DisplayStyle; }
            set { Base_obj.DisplayStyle = value; }
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

        [ContextProperty("Элементы", "Items")]
        public ClDataGridViewComboBoxCellObjectCollection Items
        {
            get { return (ClDataGridViewComboBoxCellObjectCollection)OneScriptForms.RevertObj(Base_obj.Items); }
        }
        
        [ContextMethod("Элементы", "Items")]
        public IValue Items2(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.Items[p1]);
        }
    }
}
