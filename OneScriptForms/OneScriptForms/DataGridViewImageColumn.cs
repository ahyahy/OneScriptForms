using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.ComponentModel;

namespace osf
{
    public sealed class DataGridViewImageColumnEx : System.Windows.Forms.DataGridViewImageColumn
    {
        public osf.DataGridViewImageColumn M_Object;
        static System.Drawing.Bitmap errorBmp;
        static System.Drawing.Icon errorIco;

        public DataGridViewImageColumnEx() : this(false)
        {
        }

        public DataGridViewImageColumnEx(bool valuesAreIcons) : base(valuesAreIcons)
        {
            this.CellTemplate = new DataGridViewImageCellEx(valuesAreIcons);
            var style = new System.Windows.Forms.DataGridViewCellStyle { Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter };
            if (valuesAreIcons)
            {
                style.NullValue = ErrorIcon;
            }
            else
            {
                style.NullValue = ErrorBitmap;
            }
            this.DefaultCellStyle = style;
        }

        static System.Drawing.Bitmap ErrorBitmap
        {
            get
            {
                string str = "Qk32AgAAAAAAADYAAAAoAAAADgAAABAAAAABABgAAAAAAMACAAB0EgAAdBIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACEgoTGw8bGw8bGw8bGw8bGw8bGw8bGw8bGw8bGw8bGw8bGw8bGw8YAAAAAAISChP///////////////////////////////////////////8bDxgAAAAAAhIKE////////////////////////////////////////////xsPGAAAAAACEgoT////////////////////////////////////////////Gw8YAAAAAAISChP///////////////////////////////////////////8bDxgAAAAAAhIKE////////////AAD/AAD/////////AAD/AAD/////////xsPGAAAAAACEgoT///////////////8AAP8AAP8AAP8AAP/////////////Gw8YAAAAAAISChP///////////////////wAA/wAA/////////////////8bDxgAAAAAAhIKE////////////////AAD/AAD/AAD/AAD/////////////xsPGAAAAAACEgoT///////////8AAP8AAP////////8AAP8AAP/////////Gw8YAAAAAAISChP///////////////////////////////////////////8bDxgAAAAAAhIKE////////////////////////////////////////////xsPGAAAAAACEgoT////////////////////////////////////////////Gw8YAAAAAAISChP///////////////////////////////////////////8bDxgAAAAAAhIKEhIKEhIKEhIKEhIKEhIKEhIKEhIKEhIKEhIKEhIKEhIKEhIKEhIKEAAA=";
                return errorBmp ?? (errorBmp = new System.Drawing.Bitmap((System.IO.Stream)new System.IO.MemoryStream(Convert.FromBase64String(str))));
            }
        }

        static System.Drawing.Icon ErrorIcon
        {
            get
            {
                string str = "AAABAAEADhAAAAEAGAAoAwAAFgAAACgAAAAOAAAAIAAAAAEAGAAAAAAAAAMAAHQSAAB0EgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAISChMbDxsbDxsbDxsbDxsbDxsbDxsbDxsbDxsbDxsbDxsbDxsbDxgAAAAAAhIKE////////////////////////////////////////////xsPGAAAAAACEgoT////////////////////////////////////////////Gw8YAAAAAAISChP///////////////////////////////////////////8bDxgAAAAAAhIKE////////////////////////////////////////////xsPGAAAAAACEgoT///////////8AAP8AAP////////8AAP8AAP/////////Gw8YAAAAAAISChP///////////////wAA/wAA/wAA/wAA/////////////8bDxgAAAAAAhIKE////////////////////AAD/AAD/////////////////xsPGAAAAAACEgoT///////////////8AAP8AAP8AAP8AAP/////////////Gw8YAAAAAAISChP///////////wAA/wAA/////////wAA/wAA/////////8bDxgAAAAAAhIKE////////////////////////////////////////////xsPGAAAAAACEgoT////////////////////////////////////////////Gw8YAAAAAAISChP///////////////////////////////////////////8bDxgAAAAAAhIKE////////////////////////////////////////////xsPGAAAAAACEgoSEgoSEgoSEgoSEgoSEgoSEgoSEgoSEgoSEgoSEgoSEgoSEgoSEgoQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=";
                return errorIco ?? (errorIco = new System.Drawing.Icon((System.IO.Stream)new System.IO.MemoryStream(Convert.FromBase64String(str))));
            }
        }

        private DataGridViewImageCellEx ImageCellTemplate
        {
            get { return (DataGridViewImageCellEx)this.CellTemplate; }
        }
    }

    public class DataGridViewImageColumn : DataGridViewColumn
    {
        public new ClDataGridViewImageColumn dll_obj;
        public dynamic M_DataGridViewImageColumn;

        public DataGridViewImageColumn()
        {
            M_DataGridViewImageColumn = new DataGridViewImageColumnEx();
            M_DataGridViewImageColumn.M_Object = this;
            base.M_DataGridViewColumn = M_DataGridViewImageColumn;
        }

        public DataGridViewImageColumn(DataGridViewImageColumnEx p1)
        {
            M_DataGridViewImageColumn = p1;
            M_DataGridViewImageColumn.M_Object = this;
            base.M_DataGridViewColumn = M_DataGridViewImageColumn;
        }

        public DataGridViewImageColumn(osf.DataGridViewImageColumn p1)
        {
            M_DataGridViewImageColumn = p1.M_DataGridViewImageColumn;
            M_DataGridViewImageColumn.M_Object = this;
            base.M_DataGridViewColumn = M_DataGridViewImageColumn;
        }

        public DataGridViewImageColumn(System.Windows.Forms.DataGridViewImageColumn p1)
        {
            M_DataGridViewImageColumn = p1;
            base.M_DataGridViewColumn = M_DataGridViewImageColumn;
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

        public osf.Bitmap Image
        {
            get { return new osf.Bitmap(M_DataGridViewImageColumn.Image); }
            set { M_DataGridViewImageColumn.Image = value.M_Image; }
        }

        public int ImageLayout
        {
            get { return (int)M_DataGridViewImageColumn.ImageLayout; }
            set { M_DataGridViewImageColumn.ImageLayout = (System.Windows.Forms.DataGridViewImageCellLayout)value; }
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
            get { return new ClBitmap(Base_obj.Image); }
            set { Base_obj.Image = value.Base_obj; }
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
