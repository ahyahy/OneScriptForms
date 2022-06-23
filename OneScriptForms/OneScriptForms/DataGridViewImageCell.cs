using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewImageCell : DataGridViewCell
    {
        public new ClDataGridViewImageCell dll_obj;
        private System.Windows.Forms.DataGridViewImageCell m_DataGridViewImageCell;

        public DataGridViewImageCell()
        {
            M_DataGridViewImageCell = new System.Windows.Forms.DataGridViewImageCell();
        }

        public DataGridViewImageCell(System.Windows.Forms.DataGridViewImageCell p1)
        {
            M_DataGridViewImageCell = p1;
        }

        public string Description
        {
            get { return M_DataGridViewImageCell.Description; }
            set { M_DataGridViewImageCell.Description = value; }
        }

        public int ImageLayout
        {
            get { return (int)M_DataGridViewImageCell.ImageLayout; }
            set { M_DataGridViewImageCell.ImageLayout = (System.Windows.Forms.DataGridViewImageCellLayout)value; }
        }

        public System.Windows.Forms.DataGridViewImageCell M_DataGridViewImageCell
        {
            get { return m_DataGridViewImageCell; }
            set
            {
                m_DataGridViewImageCell = value;
                base.M_DataGridViewCell = m_DataGridViewImageCell;
            }
        }

        public bool ValueIsIcon
        {
            get { return M_DataGridViewImageCell.ValueIsIcon; }
            set { M_DataGridViewImageCell.ValueIsIcon = value; }
        }
    }

    [ContextClass ("КлКартинкаЯчейки", "ClDataGridViewImageCell")]
    public class ClDataGridViewImageCell : AutoContext<ClDataGridViewImageCell>
    {
        private ClRectangle contentBounds;
        private ClCollection tag = new ClCollection();

        public ClDataGridViewImageCell()
        {
            DataGridViewImageCell DataGridViewImageCell1 = new DataGridViewImageCell();
            DataGridViewImageCell1.dll_obj = this;
            Base_obj = DataGridViewImageCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
		
        public ClDataGridViewImageCell(DataGridViewImageCell p1)
        {
            DataGridViewImageCell DataGridViewImageCell1 = p1;
            DataGridViewImageCell1.dll_obj = this;
            Base_obj = DataGridViewImageCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
        
        public DataGridViewImageCell Base_obj;
        
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
            get { return OneScriptForms.RevertObj(new Bitmap(((System.Drawing.Bitmap)Base_obj.Value))); }
            set { Base_obj.Value = ((ClBitmap)value.AsObject()).Base_obj.M_Bitmap; }
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

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("Описание", "Description")]
        public string Description
        {
            get { return Base_obj.Description; }
            set { Base_obj.Description = value; }
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

        [ContextProperty("РазмещениеИзображения", "ImageLayout")]
        public int ImageLayout
        {
            get { return (int)Base_obj.ImageLayout; }
            set { Base_obj.ImageLayout = value; }
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
            get { return OneScriptForms.RevertObj(Base_obj.FormattedValue.ToString()); }
        }
        
        [ContextProperty("ФорматированноеЗначениеРедактируемого", "EditedFormattedValue")]
        public IValue EditedFormattedValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.EditedFormattedValue.ToString()); }
        }
        
        [ContextProperty("ЭтоИконка", "ValueIsIcon")]
        public bool ValueIsIcon
        {
            get { return Base_obj.ValueIsIcon; }
            set { Base_obj.ValueIsIcon = value; }
        }
        
    }
}
