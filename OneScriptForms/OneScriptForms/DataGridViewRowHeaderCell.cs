using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewRowHeaderCell : DataGridViewHeaderCell
    {
        public new ClDataGridViewRowHeaderCell dll_obj;
        private System.Windows.Forms.DataGridViewRowHeaderCell m_DataGridViewRowHeaderCell;

        public DataGridViewRowHeaderCell()
        {
            M_DataGridViewRowHeaderCell = new System.Windows.Forms.DataGridViewRowHeaderCell();
        }

        public DataGridViewRowHeaderCell(System.Windows.Forms.DataGridViewRowHeaderCell p1)
        {
            M_DataGridViewRowHeaderCell = p1;
        }

        public System.Windows.Forms.DataGridViewRowHeaderCell M_DataGridViewRowHeaderCell
        {
            get { return m_DataGridViewRowHeaderCell; }
            set
            {
                m_DataGridViewRowHeaderCell = value;
                base.M_DataGridViewHeaderCell = m_DataGridViewRowHeaderCell;
            }
        }
    }

    [ContextClass("КлЗаголовокСтроки", "ClDataGridViewRowHeaderCell")]
    public class ClDataGridViewRowHeaderCell : AutoContext<ClDataGridViewRowHeaderCell>
    {
        private ClCollection tag = new ClCollection();

        public ClDataGridViewRowHeaderCell()
        {
            DataGridViewRowHeaderCell DataGridViewRowHeaderCell1 = new DataGridViewRowHeaderCell();
            DataGridViewRowHeaderCell1.dll_obj = this;
            Base_obj = DataGridViewRowHeaderCell1;
        }

        public ClDataGridViewRowHeaderCell(DataGridViewRowHeaderCell p1)
        {
            DataGridViewRowHeaderCell DataGridViewRowHeaderCell1 = p1;
            DataGridViewRowHeaderCell1.dll_obj = this;
            Base_obj = DataGridViewRowHeaderCell1;
        }

        public DataGridViewRowHeaderCell Base_obj;

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
