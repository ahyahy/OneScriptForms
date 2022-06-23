using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewRow : DataGridViewBand
    {
        public new ClDataGridViewRow dll_obj;
        private System.Windows.Forms.DataGridViewRow m_DataGridViewRow;

        public DataGridViewRow()
        {
            M_DataGridViewRow = new System.Windows.Forms.DataGridViewRow();
        }

        public DataGridViewRow(System.Windows.Forms.DataGridViewRow p1)
        {
            M_DataGridViewRow = p1;
        }

        public osf.DataGridViewCellCollection Cells
        {
            get { return new osf.DataGridViewCellCollection(M_DataGridViewRow.Cells); }
        }

        public osf.DataGridViewCellStyle DefaultCellStyle
        {
            get
            {
                foreach (System.Collections.DictionaryEntry de in OneScriptForms.hashtable)
                {
                    if (de.Key.Equals(M_DataGridViewRow.DefaultCellStyle))
                    {
                        return ((dynamic)de.Value);
                    }
                }
                return null;
            }
            set { M_DataGridViewRow.DefaultCellStyle = value.M_DataGridViewCellStyle; }
        }

        public int DividerHeight
        {
            get { return M_DataGridViewRow.DividerHeight; }
            set { M_DataGridViewRow.DividerHeight = value; }
        }

        public bool Frozen
        {
            get { return M_DataGridViewRow.Frozen; }
            set { M_DataGridViewRow.Frozen = value; }
        }

        public osf.DataGridViewRowHeaderCell HeaderCell
        {
            get { return new osf.DataGridViewRowHeaderCell(M_DataGridViewRow.HeaderCell); }
            set { M_DataGridViewRow.HeaderCell = value.M_DataGridViewRowHeaderCell; }
        }

        public int Height
        {
            get { return M_DataGridViewRow.Height; }
            set { M_DataGridViewRow.Height = value; }
        }

        public bool IsNewRow
        {
            get { return M_DataGridViewRow.IsNewRow; }
        }

        public System.Windows.Forms.DataGridViewRow M_DataGridViewRow
        {
            get { return m_DataGridViewRow; }
            set
            {
                m_DataGridViewRow = value;
                base.M_DataGridViewBand = m_DataGridViewRow;
            }
        }

        public int MinimumHeight
        {
            get { return M_DataGridViewRow.MinimumHeight; }
            set { M_DataGridViewRow.MinimumHeight = value; }
        }

        public bool ReadOnly
        {
            get { return M_DataGridViewRow.ReadOnly; }
            set { M_DataGridViewRow.ReadOnly = value; }
        }

        public int Resizable
        {
            get { return (int)M_DataGridViewRow.Resizable; }
            set { M_DataGridViewRow.Resizable = (System.Windows.Forms.DataGridViewTriState)value; }
        }

        public bool Visible
        {
            get { return M_DataGridViewRow.Visible; }
            set { M_DataGridViewRow.Visible = value; }
        }
    }

    [ContextClass ("КлСтрокаТаблицы", "ClDataGridViewRow")]
    public class ClDataGridViewRow : AutoContext<ClDataGridViewRow>
    {
        private ClCollection tag = new ClCollection();

        public ClDataGridViewRow()
        {
            DataGridViewRow DataGridViewRow1 = new DataGridViewRow();
            DataGridViewRow1.dll_obj = this;
            Base_obj = DataGridViewRow1;
        }
		
        public ClDataGridViewRow(DataGridViewRow p1)
        {
            DataGridViewRow DataGridViewRow1 = p1;
            DataGridViewRow1.dll_obj = this;
            Base_obj = DataGridViewRow1;
        }
        
        public DataGridViewRow Base_obj;
        
        [ContextProperty("Выбран", "Selected")]
        public bool Selected
        {
            get { return Base_obj.Selected; }
            set { Base_obj.Selected = value; }
        }

        [ContextProperty("Высота", "Height")]
        public int Height
        {
            get { return Base_obj.Height; }
            set { Base_obj.Height = value; }
        }

        [ContextProperty("ВысотаРазделителя", "DividerHeight")]
        public int DividerHeight
        {
            get { return Base_obj.DividerHeight; }
            set { Base_obj.DividerHeight = value; }
        }

        [ContextProperty("ЗаголовокСтроки", "HeaderCell")]
        public ClDataGridViewRowHeaderCell HeaderCell
        {
            get { return (ClDataGridViewRowHeaderCell)OneScriptForms.RevertObj(Base_obj.HeaderCell); }
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

        [ContextProperty("Индекс", "Index")]
        public int Index
        {
            get { return Base_obj.Index; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("МинимальнаяВысота", "MinimumHeight")]
        public int MinimumHeight
        {
            get { return Base_obj.MinimumHeight; }
            set { Base_obj.MinimumHeight = value; }
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

        [ContextProperty("ТолькоЧтение", "ReadOnly")]
        public bool ReadOnly
        {
            get { return Base_obj.ReadOnly; }
            set { Base_obj.ReadOnly = value; }
        }

        [ContextProperty("ЭтоНоваяСтрока", "IsNewRow")]
        public bool IsNewRow
        {
            get { return Base_obj.IsNewRow; }
        }

        [ContextProperty("Ячейки", "Cells")]
        public ClDataGridViewCellCollection Cells
        {
            get { return (ClDataGridViewCellCollection)OneScriptForms.RevertObj(Base_obj.Cells); }
        }
        
        [ContextMethod("Ячейки", "Cells")]
        public IValue Cells2(int p1)
        {
            dynamic Obj1 = null;
            string str1 = Base_obj.Cells[p1].GetType().ToString();
            string str2 = str1.Replace("System.Windows.Forms.", "osf.");
            System.Type Type1 = System.Type.GetType(str2, false, true);
            object[] args1 = { Base_obj.Cells[p1] };
            Obj1 = Activator.CreateInstance(Type1, args1);
            return OneScriptForms.RevertObj(Obj1);
        }
    }
}
