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
    public class DataGridViewButtonCell : DataGridViewCell
    {
        public new ClDataGridViewButtonCell dll_obj;
        private System.Windows.Forms.DataGridViewButtonCell m_DataGridViewButtonCell;

        public DataGridViewButtonCell()
        {
            M_DataGridViewButtonCell = new System.Windows.Forms.DataGridViewButtonCell();
        }

        public DataGridViewButtonCell(System.Windows.Forms.DataGridViewButtonCell p1)
        {
            M_DataGridViewButtonCell = p1;
        }

        public int FlatStyle
        {
            get { return (int)M_DataGridViewButtonCell.FlatStyle; }
            set { M_DataGridViewButtonCell.FlatStyle = (System.Windows.Forms.FlatStyle)value; }
        }

        public System.Windows.Forms.DataGridViewButtonCell M_DataGridViewButtonCell
        {
            get { return m_DataGridViewButtonCell; }
            set
            {
                m_DataGridViewButtonCell = value;
                base.M_DataGridViewCell = m_DataGridViewButtonCell;
            }
        }

        public bool UseColumnTextForButtonValue
        {
            get { return M_DataGridViewButtonCell.UseColumnTextForButtonValue; }
            set { M_DataGridViewButtonCell.UseColumnTextForButtonValue = value; }
        }
    }

    [ContextClass ("КлКнопкаЯчейки", "ClDataGridViewButtonCell")]
    public class ClDataGridViewButtonCell : AutoContext<ClDataGridViewButtonCell>
    {
        private ClRectangle contentBounds;
        private ClCollection tag = new ClCollection();

        public ClDataGridViewButtonCell()
        {
            DataGridViewButtonCell DataGridViewButtonCell1 = new DataGridViewButtonCell();
            DataGridViewButtonCell1.dll_obj = this;
            Base_obj = DataGridViewButtonCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
		
        public ClDataGridViewButtonCell(DataGridViewButtonCell p1)
        {
            DataGridViewButtonCell DataGridViewButtonCell1 = p1;
            DataGridViewButtonCell1.dll_obj = this;
            Base_obj = DataGridViewButtonCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
        
        public DataGridViewButtonCell Base_obj;
        
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

        [ContextProperty("ИспользоватьТекстКакЗначение", "UseColumnTextForButtonValue")]
        public bool UseColumnTextForButtonValue
        {
            get { return Base_obj.UseColumnTextForButtonValue; }
            set { Base_obj.UseColumnTextForButtonValue = value; }
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

        [ContextProperty("ПлоскийСтиль", "FlatStyle")]
        public int FlatStyle
        {
            get { return (int)Base_obj.FlatStyle; }
            set { Base_obj.FlatStyle = value; }
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
