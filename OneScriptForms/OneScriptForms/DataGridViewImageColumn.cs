using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewImageColumn : DataGridViewColumn
    {
        public new ClDataGridViewImageColumn dll_obj;
        private System.Windows.Forms.DataGridViewImageColumn m_DataGridViewImageColumn;

        public DataGridViewImageColumn()
        {
            M_DataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
        }

        public DataGridViewImageColumn(osf.DataGridViewImageColumn p1)
        {
            M_DataGridViewImageColumn = p1.M_DataGridViewImageColumn;
        }

        public DataGridViewImageColumn(System.Windows.Forms.DataGridViewImageColumn p1)
        {
            M_DataGridViewImageColumn = p1;
        }

        public osf.Bitmap Bitmap
        {
            get { return new osf.Bitmap(M_DataGridViewImageColumn.Image); }
            set { M_DataGridViewImageColumn.Image = value.M_Bitmap; }
        }

        public string Description
        {
            get { return M_DataGridViewImageColumn.Description; }
            set { M_DataGridViewImageColumn.Description = value; }
        }

        public osf.Icon Icon
        {
            get { return new osf.Icon(M_DataGridViewImageColumn.Icon); }
            set { M_DataGridViewImageColumn.Icon = (System.Drawing.Icon)value.M_Icon; }
        }

        public int ImageLayout
        {
            get { return (int)M_DataGridViewImageColumn.ImageLayout; }
            set { M_DataGridViewImageColumn.ImageLayout = (System.Windows.Forms.DataGridViewImageCellLayout)value; }
        }

        public System.Windows.Forms.DataGridViewImageColumn M_DataGridViewImageColumn
        {
            get { return m_DataGridViewImageColumn; }
            set
            {
                m_DataGridViewImageColumn = value;
                base.M_DataGridViewColumn = m_DataGridViewImageColumn;
            }
        }

        public bool ValuesAreIcons
        {
            get { return M_DataGridViewImageColumn.ValuesAreIcons; }
            set { M_DataGridViewImageColumn.ValuesAreIcons = value; }
        }
    }

    [ContextClass ("КлКолонкаКартинка", "ClDataGridViewImageColumn")]
    public class ClDataGridViewImageColumn : AutoContext<ClDataGridViewImageColumn>
    {
        private ClCollection tag = new ClCollection();

        public ClDataGridViewImageColumn()
        {
            DataGridViewImageColumn DataGridViewImageColumn1 = new DataGridViewImageColumn();
            DataGridViewImageColumn1.dll_obj = this;
            Base_obj = DataGridViewImageColumn1;
        }
		
        public ClDataGridViewImageColumn(DataGridViewImageColumn p1)
        {
            DataGridViewImageColumn DataGridViewImageColumn1 = p1;
            DataGridViewImageColumn1.dll_obj = this;
            Base_obj = DataGridViewImageColumn1;
        }
        
        public DataGridViewImageColumn Base_obj;
        
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

        [ContextProperty("Значок", "Icon")]
        public ClIcon Icon
        {
            get { return (ClIcon)OneScriptForms.RevertObj(Base_obj.Icon); }
            set 
            {
                Base_obj.Icon = value.Base_obj; 
                Base_obj.Icon.dll_obj = value;
            }
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

        [ContextProperty("Картинка", "Bitmap")]
        public ClBitmap Bitmap
        {
            get { return (ClBitmap)OneScriptForms.RevertObj(Base_obj.Bitmap); }
            set { Base_obj.Bitmap = value.Base_obj; }
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
            set { Base_obj.Visible = value; }
        }

        [ContextProperty("РазмещениеИзображения", "ImageLayout")]
        public int ImageLayout
        {
            get { return (int)Base_obj.ImageLayout; }
            set { Base_obj.ImageLayout = value; }
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

        [ContextProperty("ЭтоИконки", "ValuesAreIcons")]
        public bool ValuesAreIcons
        {
            get { return Base_obj.ValuesAreIcons; }
            set { Base_obj.ValuesAreIcons = value; }
        }
        
    }
}
