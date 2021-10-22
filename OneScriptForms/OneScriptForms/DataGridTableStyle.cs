using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridTableStyleEx : System.Windows.Forms.DataGridTableStyle
    {
        public osf.DataGridTableStyle M_Object;
    }

    public class DataGridTableStyle : Component
    {
        public ClDataGridTableStyle dll_obj;
        public DataGridTableStyleEx M_DataGridTableStyle;

        public DataGridTableStyle()
        {
            M_DataGridTableStyle = new DataGridTableStyleEx();
            M_DataGridTableStyle.M_Object = this;
            base.M_Component = M_DataGridTableStyle;
        }

        public DataGridTableStyle(osf.DataGridTableStyle p1)
        {
            M_DataGridTableStyle = p1.M_DataGridTableStyle;
            M_DataGridTableStyle.M_Object = this;
            base.M_Component = M_DataGridTableStyle;
        }

        public DataGridTableStyle(System.Windows.Forms.DataGridTableStyle p1)
        {
            M_DataGridTableStyle = (DataGridTableStyleEx)p1;
            M_DataGridTableStyle.M_Object = this;
            base.M_Component = M_DataGridTableStyle;
        }

        public bool AllowSorting
        {
            get { return M_DataGridTableStyle.AllowSorting; }
            set { M_DataGridTableStyle.AllowSorting = value; }
        }

        public osf.Color AlternatingBackColor
        {
            get { return new Color(M_DataGridTableStyle.AlternatingBackColor); }
            set { M_DataGridTableStyle.AlternatingBackColor = value.M_Color; }
        }

        public osf.Color BackColor
        {
            get { return new Color(M_DataGridTableStyle.BackColor); }
            set { M_DataGridTableStyle.BackColor = value.M_Color; }
        }

        public bool ColumnHeadersVisible
        {
            get { return M_DataGridTableStyle.ColumnHeadersVisible; }
            set { M_DataGridTableStyle.ColumnHeadersVisible = value; }
        }

        public osf.DataGrid DataGrid
        {
            get { return ((DataGridEx)(M_DataGridTableStyle.DataGrid)).M_Object; }
            set { M_DataGridTableStyle.DataGrid = value.M_DataGrid; }
        }

        public osf.Color ForeColor
        {
            get { return new Color(M_DataGridTableStyle.ForeColor); }
            set { M_DataGridTableStyle.ForeColor = value.M_Color; }
        }

        public osf.GridColumnStylesCollection GridColumnStyles
        {
            get { return new GridColumnStylesCollection(M_DataGridTableStyle.GridColumnStyles); }
        }

        public osf.Color GridLineColor
        {
            get { return new Color(M_DataGridTableStyle.GridLineColor); }
            set { M_DataGridTableStyle.GridLineColor = value.M_Color; }
        }

        public osf.Color HeaderBackColor
        {
            get { return new Color(M_DataGridTableStyle.HeaderBackColor); }
            set { M_DataGridTableStyle.HeaderBackColor = value.M_Color; }
        }

        public osf.Font HeaderFont
        {
            get { return new Font(M_DataGridTableStyle.HeaderFont); }
            set { M_DataGridTableStyle.HeaderFont = value.M_Font; }
        }

        public osf.Color HeaderForeColor
        {
            get { return new Color(M_DataGridTableStyle.HeaderForeColor); }
            set { M_DataGridTableStyle.HeaderForeColor = value.M_Color; }
        }

        public string MappingName
        {
            get { return M_DataGridTableStyle.MappingName; }
            set { M_DataGridTableStyle.MappingName = value; }
        }

        public int PreferredColumnWidth
        {
            get { return M_DataGridTableStyle.PreferredColumnWidth; }
            set { M_DataGridTableStyle.PreferredColumnWidth = value; }
        }

        public int PreferredRowHeight
        {
            get { return M_DataGridTableStyle.PreferredRowHeight; }
            set { M_DataGridTableStyle.PreferredRowHeight = value; }
        }

        public bool ReadOnly
        {
            get { return M_DataGridTableStyle.ReadOnly; }
            set { M_DataGridTableStyle.ReadOnly = value; }
        }

        public bool RowHeadersVisible
        {
            get { return M_DataGridTableStyle.RowHeadersVisible; }
            set { M_DataGridTableStyle.RowHeadersVisible = value; }
        }

        public int RowHeaderWidth
        {
            get { return M_DataGridTableStyle.RowHeaderWidth; }
            set { M_DataGridTableStyle.RowHeaderWidth = value; }
        }
    }

    [ContextClass ("КлСтильТаблицыСеткиДанных", "ClDataGridTableStyle")]
    public class ClDataGridTableStyle : AutoContext<ClDataGridTableStyle>
    {
        private ClColor alternatingBackColor;
        private ClColor backColor;
        private ClColor foreColor;
        private ClGridColumnStylesCollection gridColumnStyles;
        private ClColor gridLineColor;
        private ClColor headerBackColor;
        private ClColor headerForeColor;

        public ClDataGridTableStyle()
        {
            DataGridTableStyle DataGridTableStyle1 = new DataGridTableStyle();
            DataGridTableStyle1.dll_obj = this;
            Base_obj = DataGridTableStyle1;
            foreColor = new ClColor(Base_obj.ForeColor);
            headerForeColor = new ClColor(Base_obj.HeaderForeColor);
            gridColumnStyles = new ClGridColumnStylesCollection(Base_obj.GridColumnStyles);
            gridLineColor = new ClColor(Base_obj.GridLineColor);
            backColor = new ClColor(Base_obj.BackColor);
            headerBackColor = new ClColor(Base_obj.HeaderBackColor);
            alternatingBackColor = new ClColor(Base_obj.AlternatingBackColor);
        }
		
        public ClDataGridTableStyle(DataGridTableStyle p1)
        {
            DataGridTableStyle DataGridTableStyle1 = p1;
            DataGridTableStyle1.dll_obj = this;
            Base_obj = DataGridTableStyle1;
            foreColor = new ClColor(Base_obj.ForeColor);
            headerForeColor = new ClColor(Base_obj.HeaderForeColor);
            gridColumnStyles = new ClGridColumnStylesCollection(Base_obj.GridColumnStyles);
            gridLineColor = new ClColor(Base_obj.GridLineColor);
            backColor = new ClColor(Base_obj.BackColor);
            headerBackColor = new ClColor(Base_obj.HeaderBackColor);
            alternatingBackColor = new ClColor(Base_obj.AlternatingBackColor);
        }
        
        public DataGridTableStyle Base_obj;
        
        [ContextProperty("ИмяОтображаемого", "MappingName")]
        public string MappingName
        {
            get { return Base_obj.MappingName; }
            set { Base_obj.MappingName = value; }
        }

        [ContextProperty("ОсновнойЦвет", "ForeColor")]
        public ClColor ForeColor
        {
            get { return foreColor; }
            set 
            {
                foreColor = value;
                Base_obj.ForeColor = value.Base_obj;
            }
        }

        [ContextProperty("ОсновнойЦветЗаголовков", "HeaderForeColor")]
        public ClColor HeaderForeColor
        {
            get { return headerForeColor; }
            set 
            {
                headerForeColor = value;
                Base_obj.HeaderForeColor = value.Base_obj;
            }
        }

        [ContextProperty("ОтображатьЗаголовкиСтолбцов", "ColumnHeadersVisible")]
        public bool ColumnHeadersVisible
        {
            get { return Base_obj.ColumnHeadersVisible; }
            set { Base_obj.ColumnHeadersVisible = value; }
        }

        [ContextProperty("ОтображатьЗаголовкиСтрок", "RowHeadersVisible")]
        public bool RowHeadersVisible
        {
            get { return Base_obj.RowHeadersVisible; }
            set { Base_obj.RowHeadersVisible = value; }
        }

        [ContextProperty("ПредпочтительнаяВысотаСтрок", "PreferredRowHeight")]
        public int PreferredRowHeight
        {
            get { return Base_obj.PreferredRowHeight; }
            set { Base_obj.PreferredRowHeight = value; }
        }

        [ContextProperty("ПредпочтительнаяШиринаСтолбцов", "PreferredColumnWidth")]
        public int PreferredColumnWidth
        {
            get { return Base_obj.PreferredColumnWidth; }
            set { Base_obj.PreferredColumnWidth = value; }
        }

        [ContextProperty("РазрешитьСортировку", "AllowSorting")]
        public bool AllowSorting
        {
            get { return Base_obj.AllowSorting; }
            set { Base_obj.AllowSorting = value; }
        }

        [ContextProperty("СеткаДанных", "DataGrid")]
        public ClDataGrid DataGrid
        {
            get { return (ClDataGrid)OneScriptForms.RevertObj(Base_obj.DataGrid); }
            set { Base_obj.DataGrid = value.Base_obj; }
        }

        [ContextProperty("СтилиКолонкиСеткиДанных", "GridColumnStyles")]
        public ClGridColumnStylesCollection GridColumnStyles
        {
            get { return gridColumnStyles; }
        }

        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }
        
        [ContextProperty("ТолькоЧтение", "ReadOnly")]
        public bool ReadOnly
        {
            get { return Base_obj.ReadOnly; }
            set { Base_obj.ReadOnly = value; }
        }

        [ContextProperty("ЦветСетки", "GridLineColor")]
        public ClColor GridLineColor
        {
            get { return gridLineColor; }
            set 
            {
                gridLineColor = value;
                Base_obj.GridLineColor = value.Base_obj;
            }
        }

        [ContextProperty("ЦветФона", "BackColor")]
        public ClColor BackColor
        {
            get { return backColor; }
            set 
            {
                backColor = value;
                Base_obj.BackColor = value.Base_obj;
            }
        }

        [ContextProperty("ЦветФонаЗаголовков", "HeaderBackColor")]
        public ClColor HeaderBackColor
        {
            get { return headerBackColor; }
            set 
            {
                headerBackColor = value;
                Base_obj.HeaderBackColor = value.Base_obj;
            }
        }

        [ContextProperty("ЦветФонаНечетныхСтрок", "AlternatingBackColor")]
        public ClColor AlternatingBackColor
        {
            get { return alternatingBackColor; }
            set 
            {
                alternatingBackColor = value;
                Base_obj.AlternatingBackColor = value.Base_obj;
            }
        }

        [ContextProperty("ШиринаЗаголовковСтрок", "RowHeaderWidth")]
        public int RowHeaderWidth
        {
            get { return Base_obj.RowHeaderWidth; }
            set { Base_obj.RowHeaderWidth = value; }
        }

        [ContextProperty("ШрифтЗаголовков", "HeaderFont")]
        public ClFont HeaderFont
        {
            get { return (ClFont)OneScriptForms.RevertObj(Base_obj.HeaderFont); }
            set 
            {
                Base_obj.HeaderFont = value.Base_obj; 
                Base_obj.HeaderFont.dll_obj = value;
            }
        }
        
        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
					
        [ContextMethod("СтилиКолонкиСеткиДанных", "GridColumnStyles")]
        public IValue GridColumnStyles2(int p1)
        {
            try
            {
                return ((dynamic)Base_obj.GridColumnStyles.M_GridColumnStylesCollection[p1]).M_Object.dll_obj;
            }
            catch
            {
                return new ClDataGridComboBoxColumnStyle((dynamic)Base_obj.GridColumnStyles.M_GridColumnStylesCollection[p1]);
            }
        }
    }
}
