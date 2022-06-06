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
    public class DataGridViewCheckBoxCell : DataGridViewCell
    {
        public new ClDataGridViewCheckBoxCell dll_obj;
        private System.Windows.Forms.DataGridViewCheckBoxCell m_DataGridViewCheckBoxCell;

        public DataGridViewCheckBoxCell()
        {
            M_DataGridViewCheckBoxCell = new System.Windows.Forms.DataGridViewCheckBoxCell();
        }

        public DataGridViewCheckBoxCell(System.Windows.Forms.DataGridViewCheckBoxCell p1)
        {
            M_DataGridViewCheckBoxCell = p1;
        }

        public object FalseValue
        {
            get { return M_DataGridViewCheckBoxCell.FalseValue; }
            set { M_DataGridViewCheckBoxCell.FalseValue = value; }
        }

        public int FlatStyle
        {
            get { return (int)M_DataGridViewCheckBoxCell.FlatStyle; }
            set { M_DataGridViewCheckBoxCell.FlatStyle = (System.Windows.Forms.FlatStyle)value; }
        }

        public object IndeterminateValue
        {
            get { return M_DataGridViewCheckBoxCell.IndeterminateValue; }
            set { M_DataGridViewCheckBoxCell.IndeterminateValue = value; }
        }

        public System.Windows.Forms.DataGridViewCheckBoxCell M_DataGridViewCheckBoxCell
        {
            get { return m_DataGridViewCheckBoxCell; }
            set
            {
                m_DataGridViewCheckBoxCell = value;
                base.M_DataGridViewCell = m_DataGridViewCheckBoxCell;
            }
        }

        public bool ThreeState
        {
            get { return M_DataGridViewCheckBoxCell.ThreeState; }
            set { M_DataGridViewCheckBoxCell.ThreeState = value; }
        }

        public object TrueValue
        {
            get { return M_DataGridViewCheckBoxCell.TrueValue; }
            set { M_DataGridViewCheckBoxCell.TrueValue = value; }
        }
    }

    [ContextClass ("КлФлажокЯчейки", "ClDataGridViewCheckBoxCell")]
    public class ClDataGridViewCheckBoxCell : AutoContext<ClDataGridViewCheckBoxCell>
    {
        private ClRectangle contentBounds;
        private ClCollection tag = new ClCollection();

        public ClDataGridViewCheckBoxCell()
        {
            DataGridViewCheckBoxCell DataGridViewCheckBoxCell1 = new DataGridViewCheckBoxCell();
            DataGridViewCheckBoxCell1.dll_obj = this;
            Base_obj = DataGridViewCheckBoxCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
		
        public ClDataGridViewCheckBoxCell(DataGridViewCheckBoxCell p1)
        {
            DataGridViewCheckBoxCell DataGridViewCheckBoxCell1 = p1;
            DataGridViewCheckBoxCell1.dll_obj = this;
            Base_obj = DataGridViewCheckBoxCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
        
        public DataGridViewCheckBoxCell Base_obj;
        
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

        [ContextProperty("СоответствиеДляНеопределено", "IndeterminateValue")]
        public IValue IndeterminateValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.IndeterminateValue); }
            set { Base_obj.IndeterminateValue = value; }
        }

        [ContextProperty("СоответствиеДляНеПомечен", "FalseValue")]
        public IValue FalseValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.FalseValue); }
            set { Base_obj.FalseValue = value; }
        }

        [ContextProperty("СоответствиеДляПомечен", "TrueValue")]
        public IValue TrueValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.TrueValue); }
            set { Base_obj.TrueValue = value; }
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

        [ContextProperty("ТриСостояния", "ThreeState")]
        public bool ThreeState
        {
            get { return Base_obj.ThreeState; }
            set { Base_obj.ThreeState = value; }
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
