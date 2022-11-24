using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Threading;
using System.Text;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Aga.Controls.Tree.NodeControls;
using Aga.Controls.Threading;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace Aga.Controls.Tree.NodeControls
{
    public class NodeNumericUpDown : BaseTextControl
    {
        private int _editorWidth = 100;
        private int _decimalPlaces = 0;
        private decimal _increment = 1;
        private decimal _minimum = 0;
        private decimal _maximum = 100;
        public osf.ClNodeNumericUpDown dll_obj;
        public string ValueChanged;
        public event EventHandler<LabelEventArgs> LabelChanged;

        public NodeNumericUpDown()
        {
            this.LabelChanged += NodeNumericUpDown_LabelChanged;
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
		
        public void NodeNumericUpDown_LabelChanged(object sender, LabelEventArgs e)
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

        public int DecimalPlaces
        {
            get { return this._decimalPlaces; }
            set { this._decimalPlaces = value; }
        }

        public decimal Increment
        {
            get { return this._increment; }
            set { this._increment = value; }
        }

        public decimal Minimum
        {
            get { return _minimum; }
            set { _minimum = value; }
        }

        public decimal Maximum
        {
            get { return this._maximum; }
            set { this._maximum = value; }
        }

        protected override Size CalculateEditorSize(EditorContext context)
        {
            if (Parent.UseColumns)
            {
                return context.Bounds.Size;
            }
            else
            {
                return new Size(EditorWidth, context.Bounds.Height);
            }
        }

        protected override Control CreateEditor(TreeNodeAdv node)
        {
            NumericUpDown num = new NumericUpDown();
            num.Increment = Increment;
            num.DecimalPlaces = DecimalPlaces;
            num.Minimum = Minimum;
            num.Maximum = Maximum;
            num.KeyDown += EditorKeyDown;
            try
            {
                ScriptEngine.Machine.Values.NumberValue NumberValue1 = (ScriptEngine.Machine.Values.NumberValue)((Node)node.Tag).GetControlValue(this);
                num.Value = (decimal)NumberValue1.AsNumber();
            }
            catch
            {
                num.Value = num.Minimum;
            }
            SetEditControlProperties(num, node);
            return num;
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
                EndEdit(false);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                EndEdit(true);
            }
        }

        protected override void DoApplyChanges(TreeNodeAdv node, Control editor)
        {
            //SetValue(node, (editor as NumericUpDown).Value);
            object label = (editor as NumericUpDown).Value;
            object oldLabel = ((Node)node.Tag).GetControlValue(this);
            ((Node)node.Tag).dll_obj.SetControlValue(this.dll_obj, (dynamic)label);
            OnLabelChanged(this, oldLabel, label);
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

    [ContextClass("КлРегуляторВверхВнизУзла", "ClNodeNumericUpDown")]
    public class ClNodeNumericUpDown : AutoContext<ClNodeNumericUpDown>
    {
        private IValue _ValueChanged;

        public ClNodeNumericUpDown()
        {
            Base_obj = new Aga.Controls.Tree.NodeControls.NodeNumericUpDown();
            Base_obj.dll_obj = this;
        }//end_constr
		
        public ClNodeNumericUpDown(Aga.Controls.Tree.NodeControls.NodeNumericUpDown p1)
        {
            Base_obj = p1;
            Base_obj.dll_obj = this;
        }//end_constr

        public Aga.Controls.Tree.NodeControls.NodeNumericUpDown Base_obj;

        //Свойства============================================================
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

        [ContextProperty("Максимум", "Maximum")]
        public IValue Maximum
        {
            get { return OneScriptForms.RevertObj(Base_obj.Maximum); }
            set { Base_obj.Maximum = value.AsNumber(); }
        }

        [ContextProperty("Минимум", "Minimum")]
       public IValue Minimum
        {
            get { return OneScriptForms.RevertObj(Base_obj.Minimum); }
            set { Base_obj.Minimum = value.AsNumber(); }
        }

        [ContextProperty("Обрезка", "Trimming")]
        public int Trimming
        {
            get { return (int)Base_obj.Trimming; }
            set { Base_obj.Trimming = (System.Drawing.StringTrimming)value; }
        }

        [ContextProperty("Разрядность", "DecimalPlaces")]
        public int DecimalPlaces
        {
            get { return Base_obj.DecimalPlaces; }
            set { Base_obj.DecimalPlaces = value; }
        }

        [ContextProperty("Редактируемый", "EditEnabled")]
        public bool EditEnabled
        {
            get { return Base_obj.EditEnabled; }
            set { Base_obj.EditEnabled = value; }
        }

        [ContextProperty("Увеличение", "Increment")]
        public IValue Increment
        {
            get { return OneScriptForms.RevertObj(Base_obj.Increment); }
            set { Base_obj.Increment = value.AsNumber(); }
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

        //endProperty
        //Методы============================================================
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

        //endMethods
    }//endClass

}//endnamespace
