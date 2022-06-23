using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewLinkColumn : DataGridViewColumn
    {
        public new ClDataGridViewLinkColumn dll_obj;
        private System.Windows.Forms.DataGridViewLinkColumn m_DataGridViewLinkColumn;

        public DataGridViewLinkColumn()
        {
            M_DataGridViewLinkColumn = new System.Windows.Forms.DataGridViewLinkColumn();
        }

        public DataGridViewLinkColumn(osf.DataGridViewLinkColumn p1)
        {
            M_DataGridViewLinkColumn = p1.M_DataGridViewLinkColumn;
        }

        public DataGridViewLinkColumn(System.Windows.Forms.DataGridViewLinkColumn p1)
        {
            M_DataGridViewLinkColumn = p1;
        }

        public osf.Color ActiveLinkColor
        {
            get { return new Color(M_DataGridViewLinkColumn.ActiveLinkColor); }
            set { M_DataGridViewLinkColumn.ActiveLinkColor = value.M_Color; }
        }

        public int LinkBehavior
        {
            get { return (int)M_DataGridViewLinkColumn.LinkBehavior; }
            set { M_DataGridViewLinkColumn.LinkBehavior = (System.Windows.Forms.LinkBehavior)value; }
        }

        public osf.Color LinkColor
        {
            get { return new Color(M_DataGridViewLinkColumn.LinkColor); }
            set { M_DataGridViewLinkColumn.LinkColor = value.M_Color; }
        }

        public System.Windows.Forms.DataGridViewLinkColumn M_DataGridViewLinkColumn
        {
            get { return m_DataGridViewLinkColumn; }
            set
            {
                m_DataGridViewLinkColumn = value;
                base.M_DataGridViewColumn = m_DataGridViewLinkColumn;
            }
        }

        public string Text
        {
            get { return M_DataGridViewLinkColumn.Text; }
            set { M_DataGridViewLinkColumn.Text = value; }
        }

        public bool TrackVisitedState
        {
            get { return M_DataGridViewLinkColumn.TrackVisitedState; }
            set { M_DataGridViewLinkColumn.TrackVisitedState = value; }
        }

        public bool UseColumnTextForLinkValue
        {
            get { return M_DataGridViewLinkColumn.UseColumnTextForLinkValue; }
            set { M_DataGridViewLinkColumn.UseColumnTextForLinkValue = value; }
        }

        public osf.Color VisitedLinkColor
        {
            get { return new Color(M_DataGridViewLinkColumn.VisitedLinkColor); }
            set { M_DataGridViewLinkColumn.VisitedLinkColor = value.M_Color; }
        }
    }

    [ContextClass ("КлКолонкаСсылка", "ClDataGridViewLinkColumn")]
    public class ClDataGridViewLinkColumn : AutoContext<ClDataGridViewLinkColumn>
    {
        private ClColor activeLinkColor;
        private ClColor linkColor;
        private ClCollection tag = new ClCollection();
        private ClColor visitedLinkColor;

        public ClDataGridViewLinkColumn()
        {
            DataGridViewLinkColumn DataGridViewLinkColumn1 = new DataGridViewLinkColumn();
            DataGridViewLinkColumn1.dll_obj = this;
            Base_obj = DataGridViewLinkColumn1;
            activeLinkColor = new ClColor(Base_obj.ActiveLinkColor);
            visitedLinkColor = new ClColor(Base_obj.VisitedLinkColor);
            linkColor = new ClColor(Base_obj.LinkColor);
        }
		
        public ClDataGridViewLinkColumn(DataGridViewLinkColumn p1)
        {
            DataGridViewLinkColumn DataGridViewLinkColumn1 = p1;
            DataGridViewLinkColumn1.dll_obj = this;
            Base_obj = DataGridViewLinkColumn1;
            activeLinkColor = new ClColor(Base_obj.ActiveLinkColor);
            visitedLinkColor = new ClColor(Base_obj.VisitedLinkColor);
            linkColor = new ClColor(Base_obj.LinkColor);
        }
        
        public DataGridViewLinkColumn Base_obj;
        
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

        [ContextProperty("ИспользоватьТекстКакСсылку", "UseColumnTextForLinkValue")]
        public bool UseColumnTextForLinkValue
        {
            get { return Base_obj.UseColumnTextForLinkValue; }
            set { Base_obj.UseColumnTextForLinkValue = value; }
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

        [ContextProperty("ПоведениеСсылки", "LinkBehavior")]
        public int LinkBehavior
        {
            get { return (int)Base_obj.LinkBehavior; }
            set { Base_obj.LinkBehavior = value; }
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

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
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

        [ContextProperty("ЦветАктивнойСсылки", "ActiveLinkColor")]
        public ClColor ActiveLinkColor
        {
            get { return activeLinkColor; }
            set 
            {
                activeLinkColor = value;
                Base_obj.ActiveLinkColor = value.Base_obj;
            }
        }

        [ContextProperty("ЦветПосещеннойИзменяется", "TrackVisitedState")]
        public bool TrackVisitedState
        {
            get { return Base_obj.TrackVisitedState; }
            set { Base_obj.TrackVisitedState = value; }
        }

        [ContextProperty("ЦветПосещеннойСсылки", "VisitedLinkColor")]
        public ClColor VisitedLinkColor
        {
            get { return visitedLinkColor; }
            set 
            {
                visitedLinkColor = value;
                Base_obj.VisitedLinkColor = value.Base_obj;
            }
        }

        [ContextProperty("ЦветСсылки", "LinkColor")]
        public ClColor LinkColor
        {
            get { return linkColor; }
            set 
            {
                linkColor = value;
                Base_obj.LinkColor = value.Base_obj;
            }
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
