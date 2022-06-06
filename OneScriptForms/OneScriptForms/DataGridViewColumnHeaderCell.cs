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
    public class DataGridViewColumnHeaderCell : DataGridViewHeaderCell
    {
        public new ClDataGridViewColumnHeaderCell dll_obj;
        private System.Windows.Forms.DataGridViewColumnHeaderCell m_DataGridViewColumnHeaderCell;

        public DataGridViewColumnHeaderCell()
        {
            M_DataGridViewColumnHeaderCell = new System.Windows.Forms.DataGridViewColumnHeaderCell();
        }

        public DataGridViewColumnHeaderCell(System.Windows.Forms.DataGridViewColumnHeaderCell p1)
        {
            M_DataGridViewColumnHeaderCell = p1;
        }

        public System.Windows.Forms.DataGridViewColumnHeaderCell M_DataGridViewColumnHeaderCell
        {
            get { return m_DataGridViewColumnHeaderCell; }
            set
            {
                m_DataGridViewColumnHeaderCell = value;
                base.M_DataGridViewHeaderCell = m_DataGridViewColumnHeaderCell;
            }
        }
    }

    [ContextClass ("КлЗаголовокКолонки", "ClDataGridViewColumnHeaderCell")]
    public class ClDataGridViewColumnHeaderCell : AutoContext<ClDataGridViewColumnHeaderCell>
    {
        private ClCollection tag = new ClCollection();

        public ClDataGridViewColumnHeaderCell()
        {
            DataGridViewColumnHeaderCell DataGridViewColumnHeaderCell1 = new DataGridViewColumnHeaderCell();
            DataGridViewColumnHeaderCell1.dll_obj = this;
            Base_obj = DataGridViewColumnHeaderCell1;
        }
		
        public ClDataGridViewColumnHeaderCell(DataGridViewColumnHeaderCell p1)
        {
            DataGridViewColumnHeaderCell DataGridViewColumnHeaderCell1 = p1;
            DataGridViewColumnHeaderCell1.dll_obj = this;
            Base_obj = DataGridViewColumnHeaderCell1;
        }
        
        public DataGridViewColumnHeaderCell Base_obj;
        
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
