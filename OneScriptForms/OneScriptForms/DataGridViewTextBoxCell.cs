using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewTextBoxCell : DataGridViewCell
    {
        public new ClDataGridViewTextBoxCell dll_obj;
        private System.Windows.Forms.DataGridViewTextBoxCell m_DataGridViewTextBoxCell;

        public DataGridViewTextBoxCell()
        {
            M_DataGridViewTextBoxCell = new System.Windows.Forms.DataGridViewTextBoxCell();
        }

        public DataGridViewTextBoxCell(System.Windows.Forms.DataGridViewTextBoxCell p1)
        {
            M_DataGridViewTextBoxCell = p1;
        }

        public System.Windows.Forms.DataGridViewTextBoxCell M_DataGridViewTextBoxCell
        {
            get { return m_DataGridViewTextBoxCell; }
            set
            {
                m_DataGridViewTextBoxCell = value;
                base.M_DataGridViewCell = m_DataGridViewTextBoxCell;
            }
        }

        public int MaxInputLength
        {
            get { return M_DataGridViewTextBoxCell.MaxInputLength; }
            set { M_DataGridViewTextBoxCell.MaxInputLength = value; }
        }
    }

    [ContextClass ("КлПолеВводаЯчейки", "ClDataGridViewTextBoxCell")]
    public class ClDataGridViewTextBoxCell : AutoContext<ClDataGridViewTextBoxCell>
    {
        private ClRectangle contentBounds;
        private ClCollection tag = new ClCollection();

        public ClDataGridViewTextBoxCell()
        {
            DataGridViewTextBoxCell DataGridViewTextBoxCell1 = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell1.dll_obj = this;
            Base_obj = DataGridViewTextBoxCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
		
        public ClDataGridViewTextBoxCell(DataGridViewTextBoxCell p1)
        {
            DataGridViewTextBoxCell DataGridViewTextBoxCell1 = p1;
            DataGridViewTextBoxCell1.dll_obj = this;
            Base_obj = DataGridViewTextBoxCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
        
        public DataGridViewTextBoxCell Base_obj;
        
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
            set { Base_obj.Value = value.AsString(); }
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

        [ContextProperty("КолонкаВладелец", "OwningColumn")]
        public ClDataGridViewColumn OwningColumn
        {
            get { return (ClDataGridViewColumn)OneScriptForms.RevertObj(Base_obj.OwningColumn); }
        }

        [ContextProperty("МаксимальнаяДлина", "MaxInputLength")]
        public int MaxInputLength
        {
            get { return Base_obj.MaxInputLength; }
            set { Base_obj.MaxInputLength = value; }
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
        
    }
}
