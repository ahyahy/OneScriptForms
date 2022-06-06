using System;
using Microsoft.VisualBasic;
using ScriptEngine.HostedScript.Library;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace osf
{
    public class DataGridViewLinkCell : DataGridViewCell
    {
        public new ClDataGridViewLinkCell dll_obj;
        private System.Windows.Forms.DataGridViewLinkCell m_DataGridViewLinkCell;

        public DataGridViewLinkCell()
        {
            M_DataGridViewLinkCell = new System.Windows.Forms.DataGridViewLinkCell();
        }

        public DataGridViewLinkCell(System.Windows.Forms.DataGridViewLinkCell p1)
        {
            M_DataGridViewLinkCell = p1;
        }

        public osf.Color ActiveLinkColor
        {
            get { return new Color(M_DataGridViewLinkCell.ActiveLinkColor); }
            set { M_DataGridViewLinkCell.ActiveLinkColor = value.M_Color; }
        }

        public int LinkBehavior
        {
            get { return (int)M_DataGridViewLinkCell.LinkBehavior; }
            set { M_DataGridViewLinkCell.LinkBehavior = (System.Windows.Forms.LinkBehavior)value; }
        }

        public osf.Color LinkColor
        {
            get { return new Color(M_DataGridViewLinkCell.LinkColor); }
            set { M_DataGridViewLinkCell.LinkColor = value.M_Color; }
        }

        public bool LinkVisited
        {
            get { return M_DataGridViewLinkCell.LinkVisited; }
            set { M_DataGridViewLinkCell.LinkVisited = value; }
        }

        public System.Windows.Forms.DataGridViewLinkCell M_DataGridViewLinkCell
        {
            get { return m_DataGridViewLinkCell; }
            set
            {
                m_DataGridViewLinkCell = value;
                base.M_DataGridViewCell = m_DataGridViewLinkCell;
            }
        }

        public bool TrackVisitedState
        {
            get { return M_DataGridViewLinkCell.TrackVisitedState; }
            set { M_DataGridViewLinkCell.TrackVisitedState = value; }
        }

        public bool UseColumnTextForLinkValue
        {
            get { return M_DataGridViewLinkCell.UseColumnTextForLinkValue; }
            set { M_DataGridViewLinkCell.UseColumnTextForLinkValue = value; }
        }

        public osf.Color VisitedLinkColor
        {
            get { return new Color(M_DataGridViewLinkCell.VisitedLinkColor); }
            set { M_DataGridViewLinkCell.VisitedLinkColor = value.M_Color; }
        }
    }

    [ContextClass ("КлСсылкаЯчейки", "ClDataGridViewLinkCell")]
    public class ClDataGridViewLinkCell : AutoContext<ClDataGridViewLinkCell>
    {
        private ClColor activeLinkColor;
        private ClRectangle contentBounds;
        private ClColor linkColor;
        private ClCollection tag = new ClCollection();
        private ClColor visitedLinkColor;

        public ClDataGridViewLinkCell()
        {
            DataGridViewLinkCell DataGridViewLinkCell1 = new DataGridViewLinkCell();
            DataGridViewLinkCell1.dll_obj = this;
            Base_obj = DataGridViewLinkCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
            activeLinkColor = new ClColor(Base_obj.ActiveLinkColor);
            visitedLinkColor = new ClColor(Base_obj.VisitedLinkColor);
            linkColor = new ClColor(Base_obj.LinkColor);
        }
		
        public ClDataGridViewLinkCell(DataGridViewLinkCell p1)
        {
            DataGridViewLinkCell DataGridViewLinkCell1 = p1;
            DataGridViewLinkCell1.dll_obj = this;
            Base_obj = DataGridViewLinkCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
            activeLinkColor = new ClColor(Base_obj.ActiveLinkColor);
            visitedLinkColor = new ClColor(Base_obj.VisitedLinkColor);
            linkColor = new ClColor(Base_obj.LinkColor);
        }
        
        public DataGridViewLinkCell Base_obj;
        
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

        [ContextProperty("ИспользоватьТекстКакСсылку", "UseColumnTextForLinkValue")]
        public bool UseColumnTextForLinkValue
        {
            get { return Base_obj.UseColumnTextForLinkValue; }
            set { Base_obj.UseColumnTextForLinkValue = value; }
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

        [ContextProperty("ПоведениеСсылки", "LinkBehavior")]
        public int LinkBehavior
        {
            get { return (int)Base_obj.LinkBehavior; }
            set { Base_obj.LinkBehavior = value; }
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

        [ContextProperty("СсылкаПосещена", "LinkVisited")]
        public bool LinkVisited
        {
            get { return Base_obj.LinkVisited; }
            set { Base_obj.LinkVisited = value; }
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
        
    }
}
