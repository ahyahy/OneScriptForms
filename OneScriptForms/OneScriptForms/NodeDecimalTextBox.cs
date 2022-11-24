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
    public class NodeDecimalTextBox : NodeTextBox
    {
        private bool _allowDecimalSeparator = true;
        private bool _allowNegativeSign = true;
        private string _customFormat = "G";
        public new osf.ClNodeDecimalTextBox dll_obj;
        public new string ValueChanged;
        public new event EventHandler<LabelEventArgs> LabelChanged;

        public NodeDecimalTextBox()
        {
            this.LabelChanged += NodeDecimalTextBox_LabelChanged;
            ValueChanged = "";
        }
		
        public void NodeDecimalTextBox_LabelChanged(object sender, LabelEventArgs e)
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

        public bool AllowDecimalSeparator
        {
            get { return _allowDecimalSeparator; }
            set { _allowDecimalSeparator = value; }
        }

        public bool AllowNegativeSign
        {
            get { return _allowNegativeSign; }
            set { _allowNegativeSign = value; }
        }

        protected new NumericTextBox CreateTextBox()
        {
            NumericTextBox textBox = new NumericTextBox();
            textBox.AllowDecimalSeparator = AllowDecimalSeparator;
            textBox.AllowNegativeSign = AllowNegativeSign;
            return textBox;
        }
		
        protected override Control CreateEditor(TreeNodeAdv node)
        {
            NumericTextBox textBox = CreateTextBox();
            textBox.TextAlign = TextAlign;
            textBox.Text = GetLabel(node);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.TextChanged += EditorTextChanged;
            textBox.KeyDown += EditorKeyDown;
            try
            {
                ScriptEngine.Machine.Values.NumberValue NumberValue1 = (ScriptEngine.Machine.Values.NumberValue)((Node)node.Tag).GetControlValue(this);
                textBox.DecimalValue = (decimal)NumberValue1.AsNumber();
            }
            catch
            {
                textBox.DecimalValue = (decimal)((Node)node.Tag).GetControlValue(this);
            }
            SetEditControlProperties(textBox, node);
            return textBox;
        }
		
        protected override void DisposeEditor(Control editor)
        {
            var textBox = editor as NumericTextBox;
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
            Parent.UpdateEditorBounds();
        }

        protected override void DoApplyChanges(TreeNodeAdv node, Control editor)
        {
            //SetValue(node, (editor as NumericTextBox).DecimalValue);
            object label = (editor as NumericTextBox).DecimalValue;
            object oldLabel = ((Node)node.Tag).GetControlValue(this);
            ((Node)node.Tag).dll_obj.SetControlValue(this.dll_obj, (dynamic)label);
            OnLabelChanged(this, oldLabel, label);
        }
		
        public string CustomFormat
        {
            get { return _customFormat; }
            set { _customFormat = value; }
        }
		
        protected new void OnLabelChanged(object subject, object oldLabel, object newLabel)
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

    [ContextClass("КлЧисловоеПолеУзла", "ClNodeDecimalTextBox")]
    public class ClNodeDecimalTextBox : AutoContext<ClNodeDecimalTextBox>
    {
        private IValue _ValueChanged;

        public ClNodeDecimalTextBox()
        {
            Base_obj = new Aga.Controls.Tree.NodeControls.NodeDecimalTextBox();
            Base_obj.dll_obj = this;
        }//end_constr
		
        public ClNodeDecimalTextBox(Aga.Controls.Tree.NodeControls.NodeDecimalTextBox p1)
        {
            Base_obj = p1;
            Base_obj.dll_obj = this;
        }//end_constr

        public Aga.Controls.Tree.NodeControls.NodeDecimalTextBox Base_obj;

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

        [ContextProperty("Обрезка", "Trimming")]
        public int Trimming
        {
            get { return (int)Base_obj.Trimming; }
            set { Base_obj.Trimming = (System.Drawing.StringTrimming)value; }
        }

        [ContextProperty("ПользовательскийФормат", "CustomFormat")]
        public string CustomFormat
        {
            get { return Base_obj.CustomFormat; }
            set { Base_obj.CustomFormat = value; }
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
