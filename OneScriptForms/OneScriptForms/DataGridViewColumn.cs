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
    public class DataGridViewColumn : DataGridViewBand
    {
        public new ClDataGridViewColumn dll_obj;
        private System.Windows.Forms.DataGridViewColumn m_DataGridViewColumn;

        public DataGridViewColumn()
        {
            M_DataGridViewColumn = new System.Windows.Forms.DataGridViewColumn();
        }

        public DataGridViewColumn(osf.DataGridViewColumn p1)
        {
            M_DataGridViewColumn = p1.M_DataGridViewColumn;
        }

        public DataGridViewColumn(System.Windows.Forms.DataGridViewColumn p1)
        {
            M_DataGridViewColumn = p1;
        }

        public int AutoSizeMode
        {
            get { return (int)M_DataGridViewColumn.AutoSizeMode; }
            set { M_DataGridViewColumn.AutoSizeMode = (System.Windows.Forms.DataGridViewAutoSizeColumnMode)value; }
        }

        public string DataPropertyName
        {
            get { return M_DataGridViewColumn.DataPropertyName; }
            set { M_DataGridViewColumn.DataPropertyName = value; }
        }

        public osf.DataGridViewCellStyle DefaultCellStyle
        {
            get
            {
                foreach (System.Collections.DictionaryEntry de in OneScriptForms.hashtable)
                {
                    if (de.Key.Equals(M_DataGridViewColumn.DefaultCellStyle))
                    {
                        return ((dynamic)de.Value);
                    }
                }
                return null;
            }
            set { M_DataGridViewColumn.DefaultCellStyle = value.M_DataGridViewCellStyle; }
        }

        public int DisplayIndex
        {
            get { return M_DataGridViewColumn.DisplayIndex; }
            set { M_DataGridViewColumn.DisplayIndex = value; }
        }

        public int DividerWidth
        {
            get { return M_DataGridViewColumn.DividerWidth; }
            set { M_DataGridViewColumn.DividerWidth = value; }
        }

        public float FillWeight
        {
            get { return M_DataGridViewColumn.FillWeight; }
            set { M_DataGridViewColumn.FillWeight = value; }
        }

        public bool Frozen
        {
            get { return M_DataGridViewColumn.Frozen; }
            set { M_DataGridViewColumn.Frozen = value; }
        }

        public osf.DataGridViewColumnHeaderCell HeaderCell
        {
            get { return new DataGridViewColumnHeaderCell(M_DataGridViewColumn.HeaderCell); }
            set { M_DataGridViewColumn.HeaderCell = value.M_DataGridViewColumnHeaderCell; }
        }

        public string HeaderText
        {
            get { return M_DataGridViewColumn.HeaderText; }
            set { M_DataGridViewColumn.HeaderText = value; }
        }

        public System.Windows.Forms.DataGridViewColumn M_DataGridViewColumn
        {
            get { return m_DataGridViewColumn; }
            set
            {
                m_DataGridViewColumn = value;
                base.M_DataGridViewBand = m_DataGridViewColumn;
            }
        }

        public int MinimumWidth
        {
            get { return M_DataGridViewColumn.MinimumWidth; }
            set { M_DataGridViewColumn.MinimumWidth = value; }
        }

        public string Name
        {
            get { return M_DataGridViewColumn.Name; }
            set { M_DataGridViewColumn.Name = value; }
        }

        public bool ReadOnly
        {
            get { return M_DataGridViewColumn.ReadOnly; }
            set { M_DataGridViewColumn.ReadOnly = value; }
        }

        public int Resizable
        {
            get { return (int)M_DataGridViewColumn.Resizable; }
            set { M_DataGridViewColumn.Resizable = (System.Windows.Forms.DataGridViewTriState)value; }
        }

        public int SortMode
        {
            get { return (int)M_DataGridViewColumn.SortMode; }
            set { M_DataGridViewColumn.SortMode = (System.Windows.Forms.DataGridViewColumnSortMode)value; }
        }

        public string ToolTipText
        {
            get { return M_DataGridViewColumn.ToolTipText; }
            set { M_DataGridViewColumn.ToolTipText = value; }
        }

        public bool Visible
        {
            get { return M_DataGridViewColumn.Visible; }
            set { M_DataGridViewColumn.Visible = value; }
        }

        public int Width
        {
            get { return (int)M_DataGridViewColumn.Width; }
            set { M_DataGridViewColumn.Width = value; }
        }
    }

    [ContextClass ("КлКолонкаТаблицы", "ClDataGridViewColumn")]
    public class ClDataGridViewColumn : AutoContext<ClDataGridViewColumn>
    {
        private ClCollection tag = new ClCollection();

        public ClDataGridViewColumn()
        {
            DataGridViewColumn DataGridViewColumn1 = new DataGridViewColumn();
            DataGridViewColumn1.dll_obj = this;
            Base_obj = DataGridViewColumn1;
        }
		
        public ClDataGridViewColumn(DataGridViewColumn p1)
        {
            DataGridViewColumn DataGridViewColumn1 = p1;
            DataGridViewColumn1.dll_obj = this;
            Base_obj = DataGridViewColumn1;
        }
        
        public DataGridViewColumn Base_obj;
        
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

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
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
        
    }
}
