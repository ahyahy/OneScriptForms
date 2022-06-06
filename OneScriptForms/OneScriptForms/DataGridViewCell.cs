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
    public class DataGridViewCell : DataGridViewElement
    {
        public new ClDataGridViewCell dll_obj;
        public System.Windows.Forms.DataGridViewCell m_DataGridViewCell;

        public DataGridViewCell()
        {
        }

        public DataGridViewCell(System.Windows.Forms.DataGridViewCell p1)
        {
            M_DataGridViewCell = p1;
        }

        public int ColumnIndex
        {
            get { return M_DataGridViewCell.ColumnIndex; }
        }

        public osf.Rectangle ContentBounds
        {
            get { return new Rectangle(M_DataGridViewCell.ContentBounds); }
        }

        public bool Displayed
        {
            get { return M_DataGridViewCell.Displayed; }
        }

        public object EditedFormattedValue
        {
            get { return M_DataGridViewCell.EditedFormattedValue; }
        }

        public object FormattedValue
        {
            get { return M_DataGridViewCell.FormattedValue; }
        }

        public bool Frozen
        {
            get { return M_DataGridViewCell.Frozen; }
        }

        public bool HasStyle
        {
            get { return M_DataGridViewCell.HasStyle; }
        }

        public bool IsInEditMode
        {
            get { return M_DataGridViewCell.IsInEditMode; }
        }

        public System.Windows.Forms.DataGridViewCell M_DataGridViewCell
        {
            get { return m_DataGridViewCell; }
            set
            {
                m_DataGridViewCell = value;
                base.M_DataGridViewElement = m_DataGridViewCell;
            }
        }

        public osf.DataGridViewColumn OwningColumn
        {
            get { return new DataGridViewColumn(M_DataGridViewCell.OwningColumn); }
        }

        public osf.DataGridViewRow OwningRow
        {
            get { return new DataGridViewRow(M_DataGridViewCell.OwningRow); }
        }

        public osf.Size PreferredSize
        {
            get { return new Size(M_DataGridViewCell.PreferredSize); }
        }

        public bool ReadOnly
        {
            get { return M_DataGridViewCell.ReadOnly; }
            set { M_DataGridViewCell.ReadOnly = value; }
        }

        public bool Resizable
        {
            get { return M_DataGridViewCell.Resizable; }
        }

        public int RowIndex
        {
            get { return M_DataGridViewCell.RowIndex; }
        }

        public bool Selected
        {
            get { return M_DataGridViewCell.Selected; }
            set { M_DataGridViewCell.Selected = value; }
        }

        public osf.Size Size
        {
            get { return new Size(M_DataGridViewCell.Size); }
        }

        public osf.DataGridViewCellStyle Style
        {
            get
            {
                foreach (System.Collections.DictionaryEntry de in OneScriptForms.hashtable)
                {
                    if (de.Key.Equals(M_DataGridViewCell.Style))
                    {
                        return ((dynamic)de.Value);
                    }
                }
                return null;
            }
            set { M_DataGridViewCell.Style = value.M_DataGridViewCellStyle; }
        }

        public string ToolTipText
        {
            get { return M_DataGridViewCell.ToolTipText; }
            set { M_DataGridViewCell.ToolTipText = value; }
        }

        public object Value
        {
            get { return M_DataGridViewCell.Value; }
            set { M_DataGridViewCell.Value = value; }
        }

        public bool Visible
        {
            get { return M_DataGridViewCell.Visible; }
        }
    }

    [ContextClass ("КлЯчейкаТаблицы", "ClDataGridViewCell")]
    public class ClDataGridViewCell : AutoContext<ClDataGridViewCell>
    {
        private ClRectangle contentBounds;
        private ClCollection tag = new ClCollection();

        public ClDataGridViewCell()
        {
            DataGridViewCell DataGridViewCell1 = new DataGridViewCell();
            DataGridViewCell1.dll_obj = this;
            Base_obj = DataGridViewCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
		
        public ClDataGridViewCell(DataGridViewCell p1)
        {
            DataGridViewCell DataGridViewCell1 = p1;
            DataGridViewCell1.dll_obj = this;
            Base_obj = DataGridViewCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
        
        public DataGridViewCell Base_obj;
        
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
            set
            {
                if (value.SystemType.Name == "Строка")
                {
                    Base_obj.Value = value.AsString();
                }
                else if (value.SystemType.Name == "Число")
                {
                    Base_obj.Value = value.AsNumber();
                }
                else if (value.SystemType.Name == "Булево")
                {
                    Base_obj.Value = value.AsBoolean();
                }
                else if (value.SystemType.Name == "Дата")
                {
                    Base_obj.Value = value.AsDate();
                }
                else
                {
                    Base_obj.Value = value.AsObject();
                }
            }
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
