using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace Subro.Controls
{
    // Этот элемент управления используется для обеспечения пользовательского интерфейса для DataGridViewGrouper.
    // Код создан на основе разработки автора Robert.Verpalen https://www.codeproject.com/Tips/995958/DataGridViewGrouper под лицензией 
    // The Code Project Open License (CPOL) 1.02 https://www.codeproject.com/info/cpol10.aspx

    public partial class DataGridViewGrouperControl : UserControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbFields;
        private System.Windows.Forms.CheckBox chk;
        public ClDataGridViewGrouperControl dll_obj;

        public DataGridViewGrouperControl()
        {
            cmbFields = new System.Windows.Forms.ComboBox();
            chk = new System.Windows.Forms.CheckBox();
            SuspendLayout();

            cmbFields.DisplayMember = "Name";
            cmbFields.Dock = System.Windows.Forms.DockStyle.Fill;
            cmbFields.DropDownWidth = 120;
            cmbFields.FormattingEnabled = true;
            cmbFields.Location = new System.Drawing.Point(90, 0);
            cmbFields.Margin = new System.Windows.Forms.Padding(4);
            cmbFields.Name = "cmbFields";
            cmbFields.Size = new System.Drawing.Size(176, 24);
            cmbFields.Sorted = true;
            cmbFields.TabIndex = 0;
            cmbFields.SelectedIndexChanged += new System.EventHandler(this.cmbFields_SelectedIndexChanged);

            chk.AutoSize = true;
            chk.Dock = System.Windows.Forms.DockStyle.Left;
            chk.Location = new System.Drawing.Point(0, 0);
            chk.Margin = new System.Windows.Forms.Padding(4);
            chk.Name = "chk";
            chk.Size = new System.Drawing.Size(90, 25);
            chk.TabIndex = 1;
            chk.Text = "";
            chk.UseVisualStyleBackColor = true;
            chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);

            //AllowDrop = true; // иначе ошибка Регистрация DragDrop невозможна. Или можно поставить false, чтобы не возникла ошибка.
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(this.cmbFields);
            Controls.Add(this.chk);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "DataGridViewGrouperControl";
            Padding = new System.Windows.Forms.Padding(0, 0, 13, 0);
            Size = new System.Drawing.Size(279, 25);
            ResumeLayout(false);
            PerformLayout();
        }

        public System.Windows.Forms.ComboBox CmbFields
        {
            get { return cmbFields; }
        }

        public System.Windows.Forms.CheckBox Chk
        {
            get { return chk; }
        }

        private DataGridViewGrouper grouper;

        // Компонент grouper, используемый для выполнения фактической группировки. Если ни один из них не задан или не может быть 
        // получен, DataGridViewGrouper создается, когда задано свойство DataGridView.
        [DefaultValue(null)]
        public DataGridViewGrouper Grouper
        {
            get { return grouper; }
            set
            {
                if (grouper == value)
                {
                    return;
                }
                if (!DesignMode)
                {
                    cmbFields.Enabled = value != null;
                }

                if (grouper != null)
                {
                    grouper.PropertiesChanged -= new EventHandler(GroupingSource_DataSourceChanged);
                    grouper.GroupingChanged -= new EventHandler(grouper_GroupingChanged);
                    if (grouperowned)
                    {
                        if (grouper is IDisposable)
                        {
                            (grouper as IDisposable).Dispose();
                        }
                        grouperowned = false;
                    }
                }
                grouper = value;
                if (grouper != null)
                {
                    grouper.PropertiesChanged += new EventHandler(GroupingSource_DataSourceChanged);
                    grouper.GroupingChanged += new EventHandler(grouper_GroupingChanged);
                }

                setprops();

                if (cm != null)
                {
                    cm.Grouper = value;
                }
            }
        }

        bool settingvalues;

        bool ShouldSerializeGrouper()
        {
            return grouper != null && !grouperowned;
        }

        bool grouperowned;

        // Очистите все используемые ресурсы.
        protected override void Dispose(bool disposing)
        {
            Grouper = null;
            if (cm != null)
            {
                cm.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public override string Text
        {
            get { return chk.Text; }
            set { chk.Text = value; }
        }

        [DefaultValue(null)]
        public DataGridView DataGridView
        {
            get
            {
                if (grouper != null)
                {
                    return grouper.DataGridView;
                }
                return null;
            }
            set
            {
                if (DataGridView == value)
                {
                    return;
                }
                if (DataGridView != null)
                {
                    DataGridView.DataSourceChanged -= value_DataSourceChanged;
                }
                if (grouperowned || value == null)
                {
                    Grouper = null;
                }
                if (value != null)
                {
                    if (grouper != null)
                    {
                        grouper.DataGridView = value;
                    }
                    else if (value is IDataGridViewGrouperOwner)
                    {
                        Grouper = (value as IDataGridViewGrouperOwner).Grouper;
                        grouper.DataGridView = value;
                    }
                    else
                    {
                        Grouper = new DataGridViewGrouper(value);
                        grouperowned = true;
                    }
                }
            }
        }

        void value_DataSourceChanged(object sender, EventArgs e)
        {
            setprops();
        }

        public GroupingSource GroupingSource
        {
            get
            {
                if (grouper == null)
                {
                    return null;
                }
                return grouper.GroupingSource;
            }
        }

        void setprops()
        {
            if (settingvalues)
            {
                return;
            }
            settingvalues = true;
            cmbFields.BeginUpdate();
            cmbFields.Items.Clear();

            try
            {
                if (grouper != null)
                {
                    IEnumerable<PropertyDescriptor> props = grouper.GetProperties();
                    if (props != null)
                    {
                        GroupingInfo cur = grouper.GroupOn;
                        foreach (PropertyDescriptor p in props)
                        {
                            cmbFields.Items.Add(p);
                            if (cur != null && cur.IsProperty(p.Name))
                            {
                                cmbFields.SelectedItem = p;
                            }
                        }
                    }
                }
                chk.Checked = grouper != null && grouper.GroupOn != null;
            }
            catch (Exception ex)
            {
                ShowEx(ex);
            }
            settingvalues = false;
            cmbFields.EndUpdate();
        }

        void ShowEx(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        void grouper_GroupingChanged(object sender, EventArgs e)
        {
            if (settingvalues)
            {
                return;
            }
            settingvalues = true;
            try
            {
                GroupingInfo gr = grouper.GroupOn;
                chk.Checked = gr != null;
                if (chk.Checked)
                {
                    var prop = FindProperty(gr);
                    cmbFields.SelectedItem = prop;
                    if (prop == null)
                    {
                        cmbFields.Text = gr.ToString();
                    }
                }
                /*if (cm != null)cm.Grouper = dgvGrouper;*/
            }
            finally
            {
                settingvalues = false;
            }
        }

        public PropertyDescriptor FindProperty(GroupingInfo gr)
        {
            foreach (PropertyDescriptor pd in cmbFields.Items)
            {
                if (gr.IsProperty(pd.Name))
                {
                    return pd;
                }
            }
            return null;
        }

        public bool IsGrouped
        {
            get { return grouper != null && grouper.GroupOn != null; }
        }

        void GroupingSource_DataSourceChanged(object sender, EventArgs e)
        {
            setprops();
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            setgroup();
        }

        private void cmbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chk.Checked)
            {
                return;
            }
            setgroup();
        }

        void setgroup()
        {
            if (settingvalues || grouper == null)
            {
                return;
            }
            settingvalues = true;
            if (!chk.Checked || cmbFields.SelectedItem == null)
            {
                grouper.RemoveGrouping();
            }
            else
            {
                PropertyDescriptor p = SelectedProperty;
                try
                {
                    grouper.SetGroupOn(p);
                    /*if (cm != null)cm.Grouper = dgvGrouper;*/
                }
                catch (Exception ex)
                {
                    ShowEx(new Exception("Error while grouping on " + p.Name + ": " + ex.Message, ex));
                }
            }
            settingvalues = false;
        }

        public PropertyDescriptor SelectedProperty
        {
            get { return (PropertyDescriptor)cmbFields.SelectedItem; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                Rectangle r = e.ClipRectangle;
                if (r.IsEmpty)
                {
                    return;
                }
                ControlPaint.DrawButton(e.Graphics, r, down ? ButtonState.Pushed : ButtonState.Normal);

                if (down)
                {
                    r.Offset(1, 1);
                }
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Point p = new Point(r.X + 2, r.Y + r.Height / 2 - 2);
                for (int i = 0; i < 2; i++)
                {
                    int w = r.Right - p.X - 4;
                    Point[] ps = { p, new Point(p.X + w / 2, p.Y + 2), new Point(p.X + w, p.Y) };
                    e.Graphics.DrawLines(Pens.Black, ps);
                    p.Y += 3;
                }
            }
            catch { }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!down)
            {
                down = true;
                ContextMenuStrip.Show(this, new Point(Width, Height), ToolStripDropDownDirection.BelowLeft);
                Invalidate();
            }
        }

        DataGridViewGrouperContextMenuStrip cm;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewGrouperContextMenuStrip ContextMenuStrip
        {
            get
            {
                if (cm == null)
                {
                    cm = new DataGridViewGrouperContextMenuStrip(grouper);
                    cm.Closed += new ToolStripDropDownClosedEventHandler(cm_Closed);
                }
                return cm;
            }
        }

        void cm_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            down = false;
            Invalidate();
        }

        bool down;
    }

    // Инкапсулирует DataGridViewGrouperControl в ToolStripItem.
    public class DataGridViewGrouperControlItem : ToolStripControlHost
    {
        public DataGridViewGrouperControlItem() : base(new DataGridViewGrouperControl())
        {
            DataGridViewGrouperControl.MinimumSize = new Size(150, 20);
        }

        public DataGridViewGrouperControl DataGridViewGrouperControl
        {
            get { return (DataGridViewGrouperControl)Control; }
        }

        [DefaultValue(null)]
        public DataGridView DataGridView
        {
            get { return DataGridViewGrouperControl.DataGridView; }
            set { DataGridViewGrouperControl.DataGridView = value; }
        }
    }

    [ContextClass("КлГруппировщикТаблицы", "ClDataGridViewGrouperControl")]
    public class ClDataGridViewGrouperControl : AutoContext<ClDataGridViewGrouperControl>
    {

        public ClDataGridViewGrouperControl()
        {
            DataGridViewGrouperControl DataGridViewGrouperControl1 = new DataGridViewGrouperControl();
            DataGridViewGrouperControl1.dll_obj = this;
            Base_obj = DataGridViewGrouperControl1;
        }

        public ClDataGridViewGrouperControl(Subro.Controls.DataGridViewGrouper p1)
        {
            DataGridViewGrouperControl DataGridViewGrouperControl1 = new DataGridViewGrouperControl();
            DataGridViewGrouperControl1.dll_obj = this;
            Base_obj = DataGridViewGrouperControl1;

            DataGridViewGrouperControl1.Grouper = p1;
            var prop = DataGridViewGrouperControl1.FindProperty(p1.GroupOn);
            DataGridViewGrouperControl1.CmbFields.SelectedItem = prop;
            if (prop == null)
            {
                // Значит колонка группировки не задана. Нужно установить группировку по первой колонке и снять флажок Группировать
                DataGridViewGrouperControl1.Grouper.SetGroupOn(DataGridViewGrouperControl1.Grouper.DataGridView.Columns[0]);
                DataGridViewGrouperControl1.Chk.CheckState = CheckState.Unchecked;
            }
        }

        public ClDataGridViewGrouperControl(DataGridViewGrouperControl p1)
        {
            DataGridViewGrouperControl DataGridViewGrouperControl1 = p1;
            DataGridViewGrouperControl1.dll_obj = this;
            Base_obj = DataGridViewGrouperControl1;
        }

        public DataGridViewGrouperControl Base_obj;

        [ContextProperty("Верх", "Top")]
        public int Top
        {
            get { return Base_obj.Top; }
            set { Base_obj.Top = value; }
        }

        [ContextProperty("ГруппировкаТаблицы", "Grouper")]
        public ClDataGridViewGrouper Grouper
        {
            get { return (ClDataGridViewGrouper)osf.OneScriptForms.RevertObj(Base_obj.Grouper); }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
            get { return Base_obj.Left; }
            set { Base_obj.Left = value; }
        }

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return osf.OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj.M_Control; }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
            set { Base_obj.Width = value; }
        }

        [ContextMethod("Выше", "PlaceTop")]
        public void PlaceTop(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left, p3.Top - Base_obj.Height - p2);
        }

        [ContextMethod("Левее", "PlaceLeft")]
        public void PlaceLeft(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left - Base_obj.Width - p2, p3.Top);
        }

        [ContextMethod("Ниже", "PlaceBottom")]
        public void PlaceBottom(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left, p3.Top + p3.Height + p2);
        }

        [ContextMethod("Правее", "PlaceRight")]
        public void PlaceRight(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Right + p2, p3.Top);
        }
    }
}
