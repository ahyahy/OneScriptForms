using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewComboBoxCell : DataGridViewCell
    {
        public new ClDataGridViewComboBoxCell dll_obj;
        private System.Windows.Forms.DataGridViewComboBoxCell m_DataGridViewComboBoxCell;

        public DataGridViewComboBoxCell()
        {
            M_DataGridViewComboBoxCell = new System.Windows.Forms.DataGridViewComboBoxCell();
            M_DataGridViewComboBoxCell.DisplayMember = "Text";
            M_DataGridViewComboBoxCell.ValueMember = "Value";
        }

        public DataGridViewComboBoxCell(System.Windows.Forms.DataGridViewComboBoxCell p1)
        {
            M_DataGridViewComboBoxCell = p1;
        }

        public object DataSource
        {
            get
            {
                object obj;
                try
                {
                    obj = ((dynamic)M_DataGridViewComboBoxCell.DataSource).M_Object;
                }
                catch
                {
                    obj = M_DataGridViewComboBoxCell.DataSource;
                }
                return obj;
            }
            set
            {
                M_DataGridViewComboBoxCell.DataSource = null;
                try
                {
                    System.Type Type1 = value.GetType();
                    string strType1 = Type1.ToString();
                    string str1 = strType1.Substring(strType1.LastIndexOf(".") + 1);
                    M_DataGridViewComboBoxCell.DataSource = Type1.GetField("M_" + str1).GetValue(value);
                }
                catch
                {
                    M_DataGridViewComboBoxCell.DataSource = value;
                }
            }
        }

        public string DisplayMember
        {
            get { return M_DataGridViewComboBoxCell.DisplayMember; }
            set { M_DataGridViewComboBoxCell.DisplayMember = value; }
        }

        public int DisplayStyle
        {
            get { return (int)M_DataGridViewComboBoxCell.DisplayStyle; }
            set { M_DataGridViewComboBoxCell.DisplayStyle = (System.Windows.Forms.DataGridViewComboBoxDisplayStyle)value; }
        }

        public int FlatStyle
        {
            get { return (int)M_DataGridViewComboBoxCell.FlatStyle; }
            set { M_DataGridViewComboBoxCell.FlatStyle = (System.Windows.Forms.FlatStyle)value; }
        }

        public osf.DataGridViewComboBoxCellObjectCollection Items
        {
            get { return new DataGridViewComboBoxCellObjectCollection(M_DataGridViewComboBoxCell.Items); }
        }

        public System.Windows.Forms.DataGridViewComboBoxCell M_DataGridViewComboBoxCell
        {
            get { return m_DataGridViewComboBoxCell; }
            set
            {
                m_DataGridViewComboBoxCell = value;
                base.M_DataGridViewCell = m_DataGridViewComboBoxCell;
            }
        }

        public int MaxDropDownItems
        {
            get { return M_DataGridViewComboBoxCell.MaxDropDownItems; }
            set { M_DataGridViewComboBoxCell.MaxDropDownItems = value; }
        }

        public bool Sorted
        {
            get { return M_DataGridViewComboBoxCell.Sorted; }
            set { M_DataGridViewComboBoxCell.Sorted = value; }
        }

        public string ValueMember
        {
            get { return M_DataGridViewComboBoxCell.ValueMember; }
            set { M_DataGridViewComboBoxCell.ValueMember = value; }
        }
    }

    [ContextClass ("КлПолеВыбораЯчейки", "ClDataGridViewComboBoxCell")]
    public class ClDataGridViewComboBoxCell : AutoContext<ClDataGridViewComboBoxCell>
    {
        private ClRectangle contentBounds;
        private ClCollection tag = new ClCollection();

        public ClDataGridViewComboBoxCell()
        {
            DataGridViewComboBoxCell DataGridViewComboBoxCell1 = new DataGridViewComboBoxCell();
            DataGridViewComboBoxCell1.dll_obj = this;
            Base_obj = DataGridViewComboBoxCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
		
        public ClDataGridViewComboBoxCell(DataGridViewComboBoxCell p1)
        {
            DataGridViewComboBoxCell DataGridViewComboBoxCell1 = p1;
            DataGridViewComboBoxCell1.dll_obj = this;
            Base_obj = DataGridViewComboBoxCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
        
        public DataGridViewComboBoxCell Base_obj;
        
        [ContextProperty("Выбран", "Selected")]
        public bool Selected
        {
            get { return Base_obj.Selected; }
            set { Base_obj.Selected = value; }
        }

        [ContextProperty("ГраницыСодержимого", "ContentBounds")]
        public ClRectangle ContentBounds
        {
            get { return contentBounds; }
        }

        [ContextProperty("Закреплено", "Frozen")]
        public bool Frozen
        {
            get { return Base_obj.Frozen; }
        }

        [ContextProperty("Значение", "Value")]
        public IValue Value
        {
            get { return OneScriptForms.RevertObj(Base_obj.Value); }
            set { Base_obj.Value = value; }
        }
        
        [ContextProperty("ЗначениеЭлемента", "ValueMember")]
        public string ValueMember
        {
            get { return Base_obj.ValueMember; }
            set { Base_obj.ValueMember = value; }
        }

        [ContextProperty("ИзменяемыйРазмер", "Resizable")]
        public bool Resizable
        {
            get { return Base_obj.Resizable; }
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

        [ContextProperty("КолонкаВладелец", "OwningColumn")]
        public ClDataGridViewColumn OwningColumn
        {
            get { return (ClDataGridViewColumn)OneScriptForms.RevertObj(Base_obj.OwningColumn); }
        }

        [ContextProperty("МаксимумЭлементов", "MaxDropDownItems")]
        public int MaxDropDownItems
        {
            get { return Base_obj.MaxDropDownItems; }
            set
            {
                if (OneScriptForms.systemVersionIsMicrosoft)
                {
                    Base_obj.MaxDropDownItems = value;
                }
            }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
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
            set
            {
                if (OneScriptForms.systemVersionIsMicrosoft)
                {
                    Base_obj.Sorted = value;
                }
            }
        }

        [ContextProperty("ПлоскийСтиль", "FlatStyle")]
        public int FlatStyle
        {
            get { return (int)Base_obj.FlatStyle; }
            set { Base_obj.FlatStyle = value; }
        }

        [ContextProperty("ПредпочтительныйРазмер", "PreferredSize")]
        public ClSize PreferredSize
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.PreferredSize); }
        }

        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
        }

        [ContextProperty("Стиль", "Style")]
        public ClDataGridViewCellStyle Style
        {
            get { return (ClDataGridViewCellStyle)OneScriptForms.RevertObj(Base_obj.Style); }
            set { Base_obj.Style = value.Base_obj; }
        }

        [ContextProperty("СтильОтображения", "DisplayStyle")]
        public int DisplayStyle
        {
            get { return (int)Base_obj.DisplayStyle; }
            set { Base_obj.DisplayStyle = value; }
        }

        [ContextProperty("СтильУстановлен", "HasStyle")]
        public bool HasStyle
        {
            get { return Base_obj.HasStyle; }
        }

        [ContextProperty("СтрокаВладелец", "OwningRow")]
        public ClDataGridViewRow OwningRow
        {
            get { return (ClDataGridViewRow)OneScriptForms.RevertObj(Base_obj.OwningRow); }
        }

        [ContextProperty("Таблица", "DataGridView")]
        public ClDataGridView DataGridView
        {
            get { return (ClDataGridView)OneScriptForms.RevertObj(Base_obj.DataGridView); }
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

        [ContextProperty("ФорматированноеЗначение", "FormattedValue")]
        public IValue FormattedValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.FormattedValue); }
        }
        
        [ContextProperty("ФорматированноеЗначениеРедактируемого", "EditedFormattedValue")]
        public IValue EditedFormattedValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.EditedFormattedValue); }
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
