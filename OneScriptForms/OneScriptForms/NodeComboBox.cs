using System;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace Aga.Controls.Tree.NodeControls
{
    public class NodeComboBox : BaseTextControl
    {
        private int _editorWidth = 100;
        private int _editorHeight = 100;
        private NodeComboBoxObjectCollection _dropDownItems;
        public event EventHandler<EditEventArgs> CreatingEditor;
        public string ValueChanged;
        public event EventHandler<LabelEventArgs> LabelChanged;
        public osf.ClNodeComboBox dll_obj;
        DictionaryEntry currentValue;

        public NodeComboBox()
        {
            _dropDownItems = new NodeComboBoxObjectCollection();
            this.LabelChanged += NodeComboBox_LabelChanged;
            ValueChanged = "";
        }

        // Здесь по клавише F2, нажатию ENTER вызывается редактирование элемента узла.
        public override void KeyDown(KeyEventArgs args)
        {
            osf.TreeViewAdv treeViewAdv = ((osf.TreeViewAdvEx)this.Parent).M_Object;
            var currentControl = treeViewAdv.CurrentControl;
            var currentControlValue = currentControl.Value;
            if ((args.KeyCode == Keys.F2 || args.KeyCode == Keys.Enter) && Parent.CurrentNode != null && EditEnabled && currentControlValue == this)
            {
                args.Handled = true;
                BeginEdit();
            }
        }

        public void NodeComboBox_LabelChanged(object sender, LabelEventArgs e)
        {
            if (ValueChanged.Length > 0)
            {
                osf.ValueTreeViewAdvEventArgs ValueTreeViewAdvEventArgs1 = new osf.ValueTreeViewAdvEventArgs(this, e.OldLabel, e.NewLabel);
                ValueTreeViewAdvEventArgs1.EventString = ValueChanged;
                ValueTreeViewAdvEventArgs1.Sender = ((dynamic)sender).dll_obj;
                ValueTreeViewAdvEventArgs1.Parameter = osf.OneScriptForms.GetEventParameter(((dynamic)sender).dll_obj.ValueChanged);
                osf.ClValueTreeViewAdvEventArgs ClValueTreeViewAdvEventArgs1 = new osf.ClValueTreeViewAdvEventArgs(ValueTreeViewAdvEventArgs1);
                osf.OneScriptForms.Event = ClValueTreeViewAdvEventArgs1;
                osf.OneScriptForms.ExecuteEvent(((dynamic)sender).dll_obj.ValueChanged);
            }
        }

        public int EditorWidth
        {
            get { return _editorWidth; }
            set { _editorWidth = value; }
        }

        public int EditorHeight
        {
            get { return _editorHeight; }
            set { _editorHeight = value; }
        }

        public NodeComboBoxObjectCollection DropDownItems
        {
            get { return _dropDownItems; }
        }

        protected override Size CalculateEditorSize(EditorContext context)
        {
            if (Parent.UseColumns)
            {
                if (context.Editor is CheckedListBox)
                {
                    return new Size(context.Bounds.Size.Width, EditorHeight);
                }
                else
                {
                    return context.Bounds.Size;
                }
            }
            else
            {
                if (context.Editor is CheckedListBox)
                {
                    return new Size(EditorWidth, EditorHeight);
                }
                else
                {
                    return new Size(EditorWidth, context.Bounds.Height);
                }
            }
        }

        protected override Control CreateEditor(TreeNodeAdv node)
        {
            Control c;
            object value = GetValue(node);
            if (IsCheckedListBoxRequired(node))
            {
                c = CreateCheckedListBox(node);
            }
            else
            {
                c = CreateCombo(node);
            }
            c.KeyDown += EditorKeyDown;
            currentValue.Key = (Node)node.Tag;
            currentValue.Value = ((Node)node.Tag).GetControlValue(this);
            ComboBox comboBox = (ComboBox)c;
            int index = comboBox.Items.IndexOf(currentValue.Value);
            comboBox.SelectedIndex = index;
            OnCreatingEditor(new EditEventArgs(node, c));
            return c;
        }

        protected override void DisposeEditor(Control editor)
        {
            var c = editor as Control;
            c.KeyDown -= EditorKeyDown;
        }

        private void EditorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ((Node)currentValue.Key).SetControlValue(this, currentValue.Value);
                currentValue.Value = null;
                currentValue.Key = null;
            }
            else if (e.KeyCode == Keys.Enter)
            {
            }
        }

        protected virtual void OnCreatingEditor(EditEventArgs args)
        {
            if (CreatingEditor != null)
            {
                CreatingEditor(this, args);
            }
        }

        protected virtual bool IsCheckedListBoxRequired(TreeNodeAdv node)
        {
            object value = GetValue(node);
            if (value != null)
            {
                Type t = value.GetType();
                object[] arr = t.GetCustomAttributes(typeof(FlagsAttribute), false);
                return (t.IsEnum && arr.Length == 1);
            }
            return false;
        }

        private Control CreateCombo(TreeNodeAdv node)
        {
            ComboBox comboBox = new ComboBox();
            if (DropDownItems != null)
            {
                comboBox.Items.AddRange(DropDownItems.ToArray());
            }
            comboBox.SelectedItem = GetValue(node);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DropDownClosed += new EventHandler(EditorDropDownClosed);
            SetEditControlProperties(comboBox, node);
            return comboBox;
        }

        private Control CreateCheckedListBox(TreeNodeAdv node)
        {
            CheckedListBox listBox = new CheckedListBox();
            listBox.CheckOnClick = true;

            object value = GetValue(node);
            Type enumType = GetEnumType(node);
            foreach (object obj in Enum.GetValues(enumType))
            {
                object[] attributes = enumType.GetField(obj.ToString()).GetCustomAttributes(typeof(BrowsableAttribute), false);
                if (attributes.Length == 0 || ((BrowsableAttribute)attributes[0]).Browsable)
                {
                    listBox.Items.Add(obj, IsContain(value, obj));
                }
            }

            SetEditControlProperties(listBox, node);
            if (CreatingEditor != null)
            {
                CreatingEditor(this, new EditEventArgs(node, listBox));
            }
            return listBox;
        }

        protected virtual Type GetEnumType(TreeNodeAdv node)
        {
            object value = GetValue(node);
            return value.GetType();
        }

        private bool IsContain(object value, object enumElement)
        {
            if (value == null || enumElement == null)
            {
                return false;
            }
            if (value.GetType().IsEnum)
            {
                int i1 = (int)value;
                int i2 = (int)enumElement;
                return (i1 & i2) == i2;
            }
            else
            {
                var arr = value as object[];
                foreach (object obj in arr)
                {
                    if ((int)obj == (int)enumElement)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        protected override string FormatLabel(object obj)
        {
            var arr = obj as object[];
            if (arr != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (object t in arr)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(", ");
                    }
                    sb.Append(t);
                }
                return sb.ToString();
            }
            else
            {
                return base.FormatLabel(obj);
            }
        }

        void EditorDropDownClosed(object sender, EventArgs e)
        {
            EndEdit(true);
        }

        public override void UpdateEditor(Control control)
        {
            if (control is ComboBox)
            {
                (control as ComboBox).DroppedDown = true;
            }
        }

        protected override void DoApplyChanges(TreeNodeAdv node, Control editor)
        {
            if (currentValue.Key == null)
            {
                return;
            }
            var combo = editor as ComboBox;
            if (combo != null)
            {
                if (combo.DropDownStyle == ComboBoxStyle.DropDown)
                {
                    //SetValue(node, combo.Text);
                    object label = (object)combo.Text;
                    object oldLabel = ((Node)node.Tag).GetControlValue(this);
                    ((Node)node.Tag).SetControlValue(this, (object)combo.Text);
                    OnLabelChanged(this, oldLabel, label);
                }
                else
                {
                    //SetValue(node, combo.SelectedItem);
                    object label = (object)combo.SelectedItem;
                    object oldLabel = ((Node)node.Tag).GetControlValue(this);
                    ((Node)node.Tag).SetControlValue(this, (object)combo.SelectedItem);
                    OnLabelChanged(this, oldLabel, label);
                }
            }
            else
            {
                var listBox = editor as CheckedListBox;
                Type type = GetEnumType(node);
                if (IsFlags(type))
                {
                    int res = 0;
                    foreach (object obj in listBox.CheckedItems)
                    {
                        res |= (int)obj;
                    }
                    object val = Enum.ToObject(type, res);
                    SetValue(node, val);
                }
                else
                {
                    List<object> list = new List<object>();
                    foreach (object obj in listBox.CheckedItems)
                    {
                        list.Add(obj);
                    }
                    SetValue(node, list.ToArray());
                }
            }
        }

        private bool IsFlags(Type type)
        {
            object[] atr = type.GetCustomAttributes(typeof(FlagsAttribute), false);
            return atr.Length == 1;
        }

        public override void MouseUp(TreeNodeAdvMouseEventArgs args)
        {
            if (args.Node != null && args.Node.IsSelected)
            {
                // Обходной путь для определенного поведения элемента управления ComboBox.
                base.MouseUp(args);
            }
        }

        protected void OnLabelChanged(object subject, object oldLabel, object newLabel)
        {
            if (LabelChanged != null)
            {
                LabelChanged(this, new LabelEventArgs(subject, oldLabel, newLabel));
            }
        }
    }
}

namespace osf
{

    [ContextClass("КлПолеВыбораУзла", "ClNodeComboBox")]
    public class ClNodeComboBox : AutoContext<ClNodeComboBox>
    {
        private IValue _ValueChanged;

        public ClNodeComboBox()
        {
            Base_obj = new Aga.Controls.Tree.NodeControls.NodeComboBox();
            Base_obj.dll_obj = this;
        }

        public ClNodeComboBox(Aga.Controls.Tree.NodeControls.NodeComboBox p1)
        {
            Base_obj = p1;
            Base_obj.dll_obj = this;
        }

        public Aga.Controls.Tree.NodeControls.NodeComboBox Base_obj;

        [ContextProperty("ВертикальноеВыравнивание", "VerticalAlign")]
        public int VerticalAlign
        {
            get { return (int)Base_obj.VerticalAlign; }
            set { Base_obj.VerticalAlign = (Aga.Controls.Tree.VerticalAlignment)value; }
        }

        [ContextProperty("ВыравниваниеТекста", "TextAlign")]
        public int TextAlign
        {
            get { return (int)Base_obj.TextAlign; }
            set { Base_obj.TextAlign = (System.Windows.Forms.HorizontalAlignment)value; }
        }

        [ContextProperty("ЗначениеИзменено", "ValueChanged")]
        public IValue ValueChanged
        {
            get { return _ValueChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _ValueChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ValueChanged = "DelegateActionValueChanged";
                }
                else
                {
                    _ValueChanged = value;
                    Base_obj.ValueChanged = "osfActionValueChanged";
                }
            }
        }

        [ContextProperty("ИспользоватьСовместимуюОтрисовку", "UseCompatibleTextRendering")]
        public bool UseCompatibleTextRendering
        {
            get { return Base_obj.UseCompatibleTextRendering; }
            set { Base_obj.UseCompatibleTextRendering = value; }
        }

        [ContextProperty("Колонка", "ParentColumn")]
        public ClTreeColumn ParentColumn
        {
            get { return (ClTreeColumn)OneScriptForms.RevertEqualsObj(Base_obj.ParentColumn); }
            set
            {
                Base_obj.ParentColumn = value.Base_obj.M_TreeColumn;
                OneScriptForms.AddToHashtable(Base_obj.ParentColumn, value);
            }
        }

        [ContextProperty("ЛевыйОтступ", "LeftMargin")]
        public int LeftMargin
        {
            get { return Base_obj.LeftMargin; }
            set { Base_obj.LeftMargin = value; }
        }

        [ContextProperty("Обрезка", "Trimming")]
        public int Trimming
        {
            get { return (int)Base_obj.Trimming; }
            set { Base_obj.Trimming = (System.Drawing.StringTrimming)value; }
        }

        [ContextProperty("Редактируемый", "EditEnabled")]
        public bool EditEnabled
        {
            get { return Base_obj.EditEnabled; }
            set { Base_obj.EditEnabled = value; }
        }

        [ContextProperty("Шрифт", "Font")]
        public ClFont Font
        {
            get { return (ClFont)OneScriptForms.RevertEqualsObj(this); }
            set
            {
                Base_obj.Font = value.Base_obj.M_Font;
                OneScriptForms.AddToHashtable(this, value);
            }
        }

        [ContextProperty("ЭлементыСписка", "DropDownItems")]
        public ClNodeComboBoxObjectCollection DropDownItems
        {
            get { return (ClNodeComboBoxObjectCollection)OneScriptForms.RevertObj(Base_obj.DropDownItems); }
        }

        [ContextMethod("ПолучитьЗначение", "GetValue")]
        public IValue GetValue(ClNode p1)
        {
            return (IValue)p1.Base_obj.GetControlValue(Base_obj);
        }

        [ContextMethod("УстановитьЗначение", "SetValue")]
        public void SetValue(ClNode p1, IValue p2)
        {
            p1.Base_obj.SetControlValue(Base_obj, (object)p2);
        }

    }
}
