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
    public class DataGridViewButtonColumn : DataGridViewColumn
    {
        public new ClDataGridViewButtonColumn dll_obj;
        private System.Windows.Forms.DataGridViewButtonColumn m_DataGridViewButtonColumn;

        public DataGridViewButtonColumn()
        {
            M_DataGridViewButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
        }

        public DataGridViewButtonColumn(osf.DataGridViewButtonColumn p1)
        {
            M_DataGridViewButtonColumn = p1.M_DataGridViewButtonColumn;
        }

        public DataGridViewButtonColumn(System.Windows.Forms.DataGridViewButtonColumn p1)
        {
            M_DataGridViewButtonColumn = p1;
        }

        public int FlatStyle
        {
            get { return (int)M_DataGridViewButtonColumn.FlatStyle; }
            set { M_DataGridViewButtonColumn.FlatStyle = (System.Windows.Forms.FlatStyle)value; }
        }

        public System.Windows.Forms.DataGridViewButtonColumn M_DataGridViewButtonColumn
        {
            get { return m_DataGridViewButtonColumn; }
            set
            {
                m_DataGridViewButtonColumn = value;
                base.M_DataGridViewColumn = m_DataGridViewButtonColumn;
            }
        }

        public string Text
        {
            get { return M_DataGridViewButtonColumn.Text; }
            set { M_DataGridViewButtonColumn.Text = value; }
        }

        public bool UseColumnTextForButtonValue
        {
            get { return M_DataGridViewButtonColumn.UseColumnTextForButtonValue; }
            set { M_DataGridViewButtonColumn.UseColumnTextForButtonValue = value; }
        }
    }

    [ContextClass ("КлКолонкаКнопка", "ClDataGridViewButtonColumn")]
    public class ClDataGridViewButtonColumn : AutoContext<ClDataGridViewButtonColumn>
    {
        private ClCollection tag = new ClCollection();

        public ClDataGridViewButtonColumn()
        {
            DataGridViewButtonColumn DataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn1.dll_obj = this;
            Base_obj = DataGridViewButtonColumn1;
        }
		
        public ClDataGridViewButtonColumn(DataGridViewButtonColumn p1)
        {
            DataGridViewButtonColumn DataGridViewButtonColumn1 = p1;
            DataGridViewButtonColumn1.dll_obj = this;
            Base_obj = DataGridViewButtonColumn1;
        }
        
        public DataGridViewButtonColumn Base_obj;
        
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

        [ContextProperty("ИспользоватьТекстКакЗначение", "UseColumnTextForButtonValue")]
        public bool UseColumnTextForButtonValue
        {
            get { return Base_obj.UseColumnTextForButtonValue; }
            set { Base_obj.UseColumnTextForButtonValue = value; }
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

        [ContextProperty("ПлоскийСтиль", "FlatStyle")]
        public int FlatStyle
        {
            get { return (int)Base_obj.FlatStyle; }
            set { Base_obj.FlatStyle = value; }
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
