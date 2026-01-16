using System;
using System.Windows.Forms;
using System.Drawing;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace Aga.Controls.Tree.NodeControls
{
    public class NodeTextBox : BaseTextControl
    {
        private const int MinTextBoxWidth = 30;
        private string _label;
        public event EventHandler<LabelEventArgs> LabelChanged;
        public osf.ClNodeTextBox dll_obj;
        public string ValueChanged;

        public NodeTextBox()
        {
            this.LabelChanged += NodeTextBox_LabelChanged;
            ValueChanged = "";
        }

        public void NodeTextBox_LabelChanged(object sender, LabelEventArgs e)
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

        protected override Size CalculateEditorSize(EditorContext context)
        {
            if (Parent.UseColumns)
            {
                return context.Bounds.Size;
            }
            else
            {
                Size size = GetLabelSize(context.CurrentNode, context.DrawContext, _label);
                int width = Math.Max(size.Width + Font.Height, MinTextBoxWidth); // Зарезервируйте место для нового введенного символа.
                return new Size(width, size.Height);
            }
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

        protected override Control CreateEditor(TreeNodeAdv node)
        {
            TextBox textBox = CreateTextBox();
            textBox.TextAlign = TextAlign;
            textBox.Text = GetLabel(node);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.TextChanged += EditorTextChanged;
            textBox.KeyDown += EditorKeyDown;
            _label = textBox.Text;
            try
            {
                ScriptEngine.Machine.Values.StringValue StringValue1 = (ScriptEngine.Machine.Values.StringValue)((Node)node.Tag).GetControlValue(this);
                textBox.Text = (string)StringValue1.AsString();
            }
            catch
            {
                textBox.Text = (string)((Node)node.Tag).GetControlValue(this);
            }
            SetEditControlProperties(textBox, node);
            return textBox;
        }

        protected virtual TextBox CreateTextBox()
        {
            return new TextBox();
        }

        protected override void DisposeEditor(Control editor)
        {
            var textBox = editor as TextBox;
            textBox.TextChanged -= EditorTextChanged;
            textBox.KeyDown -= EditorKeyDown;
        }

        private void EditorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                EndEdit(false);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                EndEdit(true);
            }
        }

        private void EditorTextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            _label = textBox.Text;
            Parent.UpdateEditorBounds();
        }

        protected override void DoApplyChanges(TreeNodeAdv node, Control editor)
        {
            object label = (editor as TextBox).Text;
            object oldLabel = ((Node)node.Tag).GetControlValue(this);
            if (oldLabel != label)
            {
                //SetLabel(node, label);
                ((Node)node.Tag).dll_obj.SetControlValue(this.dll_obj, (dynamic)label);
                OnLabelChanged(this, oldLabel, label);
            }
        }

        public override void Cut(Control control)
        {
            (control as TextBox).Cut();
        }

        public override void Copy(Control control)
        {
            (control as TextBox).Copy();
        }

        public override void Paste(Control control)
        {
            (control as TextBox).Paste();
        }

        public override void Delete(Control control)
        {
            var textBox = control as TextBox;
            int len = Math.Max(textBox.SelectionLength, 1);
            if (textBox.SelectionStart < textBox.Text.Length)
            {
                int start = textBox.SelectionStart;
                textBox.Text = textBox.Text.Remove(textBox.SelectionStart, len);
                textBox.SelectionStart = start;
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

    [ContextClass("КлПолеВводаУзла", "ClNodeTextBox")]
    public class ClNodeTextBox : AutoContext<ClNodeTextBox>
    {
        private IValue _ValueChanged;

        public ClNodeTextBox()
        {
            Base_obj = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            Base_obj.dll_obj = this;
        }

        public ClNodeTextBox(Aga.Controls.Tree.NodeControls.NodeTextBox p1)
        {
            Base_obj = p1;
            Base_obj.dll_obj = this;
        }

        public Aga.Controls.Tree.NodeControls.NodeTextBox Base_obj;

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
