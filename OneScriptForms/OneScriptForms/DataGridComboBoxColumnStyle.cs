using System;
using ScriptEngine.Machine.Contexts;
using System.Windows.Forms;

namespace osf
{
    public class DataGridComboBoxColumn : System.Windows.Forms.DataGridTextBoxColumn
    {
        private bool _isEditing;
        private bool _readOnly;
        private int _rowNum;
        private System.Windows.Forms.CurrencyManager _source;
        public System.Windows.Forms.ComboBox ColumnComboBox;
        public ClComboBox comboBox;
        public ClDataGridComboBoxColumnStyle dll_obj;
        public static int _RowCount;

        public DataGridComboBoxColumn() : base()
        {
            _source = null;
            _isEditing = false;
            _RowCount = -1;
            osf.NoKeyUpComboBoxEx NoKeyUpComboEx1 = new osf.NoKeyUpComboBoxEx();
            comboBox = new ClComboBox(NoKeyUpComboEx1);
            ColumnComboBox = (System.Windows.Forms.ComboBox)NoKeyUpComboEx1;
            ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ColumnComboBox.Leave += ColumnComboBox_Leave;
            ColumnComboBox.SelectionChangeCommitted += ColumnComboBox_SelectionChangeCommitted;
            _readOnly = false;
        }

        public override bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        public ClComboBox ComboBox
        {
            get { return comboBox; }
        }

        protected override void Edit(
            CurrencyManager source,
            int rowNum,
            System.Drawing.Rectangle bounds,
            bool readOnly,
            string instantText,
            bool cellIsVisible)
        {
            if (!_readOnly)
            {
                base.Edit(source, rowNum, bounds, readOnly, instantText, cellIsVisible);
                _rowNum = rowNum;
                _source = source;
                ColumnComboBox.Parent = this.TextBox.Parent;
                ColumnComboBox.Location = new System.Drawing.Point(this.TextBox.Location.X - 2, this.TextBox.Location.Y - 2);
                ColumnComboBox.Size = new System.Drawing.Size(this.TextBox.Size.Width, ColumnComboBox.Size.Height);
                ColumnComboBox.SelectedIndex = ColumnComboBox.FindStringExact(this.TextBox.Text);
                ColumnComboBox.Text = this.TextBox.Text;
                this.TextBox.Visible = false;
                ColumnComboBox.Visible = true;
                this.DataGridTableStyle.DataGrid.Scroll += DataGrid_Scroll;

                ColumnComboBox.BringToFront();
                ColumnComboBox.Focus();
            }
        }

        protected override bool Commit(CurrencyManager dataSource, int rowNum)
        {
            if (_isEditing)
            {
                _isEditing = false;
                SetColumnValueAtRow(dataSource, rowNum, ColumnComboBox.Text);
            }
            return true;
        }

        protected override void ConcedeFocus()
        {
            base.ConcedeFocus();
        }

        protected override object GetColumnValueAtRow(CurrencyManager source, int rowNum)
        {
            object s = base.GetColumnValueAtRow(source, rowNum);
            System.Data.DataView dv = (System.Data.DataView)((System.Data.DataTable)this.ColumnComboBox.DataSource).DefaultView;
            int rowCount = dv.Count;
            int i = 0;
            while (i < rowCount)
            {
                if (s.Equals(dv[i][this.ComboBox.Base_obj.ValueMember]))
                {
                    break;
                }
                ++i;
            }

            if (i < rowCount)
            {
                return dv[i][this.ComboBox.Base_obj.DisplayMember];
            }
            return DBNull.Value;
        }

        protected override void SetColumnValueAtRow(CurrencyManager source, int rowNum, object value)
        {
            object s = value;
            System.Data.DataView dv = (System.Data.DataView)((System.Data.DataTable)this.ColumnComboBox.DataSource).DefaultView;
            int rowCount = dv.Count;
            int i = 0;
            while (i < rowCount)
            {
                if (s.Equals(dv[i][this.ComboBox.Base_obj.DisplayMember]))
                {
                    break;
                }
                ++i;
            }
            if (i < rowCount)
            {
                s = dv[i][this.ComboBox.Base_obj.ValueMember];
            }
            else
                s = DBNull.Value;
            try
            {
                base.SetColumnValueAtRow(source, rowNum, s);
            }
            catch { }
        }

        private void ColumnComboBox_Leave(object sender, System.EventArgs e)
        {
            if (_isEditing)
            {
                try
                {
                    SetColumnValueAtRow(_source, _rowNum, ColumnComboBox.Text);
                    _isEditing = false;
                    Invalidate();
                }
                catch { }
            }
            ColumnComboBox.Hide();
            this.DataGridTableStyle.DataGrid.Scroll -= DataGrid_Scroll;
        }

        private void ColumnComboBox_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            _isEditing = true;
            base.ColumnStartedEditing((System.Windows.Forms.Control)sender);
        }

        private void DataGrid_Scroll(object sender, System.EventArgs e)
        {
            if (ColumnComboBox.Visible)
            {
                ColumnComboBox.Hide();
            }
        }
    }

    [ContextClass ("КлСтильКолонкиПолеВыбора", "ClDataGridComboBoxColumnStyle")]
    public class ClDataGridComboBoxColumnStyle : AutoContext<ClDataGridComboBoxColumnStyle>
    {
        public ClDataGridComboBoxColumnStyle()
        {
            DataGridComboBoxColumn DataGridComboBoxColumnStyle1 = new DataGridComboBoxColumn();
            DataGridComboBoxColumnStyle1.dll_obj = this;
            Base_obj = DataGridComboBoxColumnStyle1;
        }

        public ClDataGridComboBoxColumnStyle(DataGridComboBoxColumn p1)
        {
            DataGridComboBoxColumn DataGridComboBoxColumnStyle1 = p1;
            DataGridComboBoxColumnStyle1.dll_obj = this;
            Base_obj = DataGridComboBoxColumnStyle1;
        }

        public DataGridComboBoxColumn Base_obj;
        
        [ContextProperty("Выравнивание", "Alignment")]
        public int Alignment
        {
            get { return (int)Base_obj.Alignment; }
            set { Base_obj.Alignment = (System.Windows.Forms.HorizontalAlignment)value; }
        }

        [ContextProperty("ИмяОтображаемого", "MappingName")]
        public string MappingName
        {
            get { return Base_obj.MappingName; }
            set { Base_obj.MappingName = value; }
        }

        [ContextProperty("ПолеВыбора", "ComboBox")]
        public ClComboBox ComboBox
        {
            get { return (ClComboBox)OneScriptForms.RevertObj(Base_obj.ComboBox); }
        }

        [ContextProperty("ТекстЗаголовка", "HeaderText")]
        public string HeaderText
        {
            get { return Base_obj.HeaderText; }
            set { Base_obj.HeaderText = value; }
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
        
        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
    }
}
