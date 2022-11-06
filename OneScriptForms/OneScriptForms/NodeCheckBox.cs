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
    public class NodeCheckBox : InteractiveControl
    {
        public const int ImageSize = 13;
        private Bitmap _check;
        private Bitmap _uncheck;
        private Bitmap _unknown;
        private bool _threeState;
        public event EventHandler<TreePathEventArgs> CheckStateChanged;
        public string CheckChanged;
        public osf.ClNodeCheckBox dll_obj;

        public NodeCheckBox() : this(string.Empty)
        {
        }

        public NodeCheckBox(string propertyName)
        {
            _check = new Bitmap(new MemoryStream(Convert.FromBase64String("Qk0+AgAAAAAAADYAAAAoAAAADQAAAA0AAAABABgAAAAAAAgCAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///////////////////////////////////8AAAAAAAAAAAAAAAAA////////////AAAA////////////////////AAAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAP///////////////wAAAAAAAAAAAAAAAAD///8AAAAAAAAAAAAAAAAAAAD///////////8AAAAAAAAAAAAAAAAA////AAAAAAAA////AAAAAAAAAAAA////////AAAAAAAAAAAAAAAAAP///wAAAP///////////wAAAAAAAAAAAP///wAAAAAAAAAAAAAAAAD///////////////////////8AAAAAAAD///8AAAAAAAAAAAAAAAAA////////////////////////////AAAA////AAAAAAAAAAAAAAAAAP///////////////////////////////////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==")));
            _uncheck = new Bitmap(new MemoryStream(Convert.FromBase64String("Qk0+AgAAAAAAADYAAAAoAAAADQAAAA0AAAABABgAAAAAAAgCAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///////////////////////////////////8AAAAAAAAAAAAAAAAA////////////////////////////////////AAAAAAAAAAAAAAAAAP///////////////////////////////////wAAAAAAAAAAAAAAAAD///////////////////////////////////8AAAAAAAAAAAAAAAAA////////////////////////////////////AAAAAAAAAAAAAAAAAP///////////////////////////////////wAAAAAAAAAAAAAAAAD///////////////////////////////////8AAAAAAAAAAAAAAAAA////////////////////////////////////AAAAAAAAAAAAAAAAAP///////////////////////////////////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==")));
            _unknown = new Bitmap(new MemoryStream(Convert.FromBase64String("Qk0+AgAAAAAAADYAAAAoAAAADQAAAA0AAAABABgAAAAAAAgCAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADI0NTI0NTI0NTI0NTI0NTI0NTI0NTI0NTI0NQAAAAAAAAAAAAAAAAAyNDUyNDUyNDUgICAyNDUyNDUyNDUyNDUyNDUAAAAAAAAAAAAAAAAAMjQ1MjQ1ICAgICAgICAgMjQ1MjQ1MjQ1MjQ1AAAAAAAAAAAAAAAAADI0NSAgICAgICAgICAgICAgIDI0NTI0NTI0NQAAAAAAAAAAAAAAAAAyNDUgICAgICAyNDUgICAgICAgICAyNDUyNDUAAAAAAAAAAAAAAAAAMjQ1ICAgMjQ1MjQ1MjQ1ICAgICAgICAgMjQ1AAAAAAAAAAAAAAAAADI0NTI0NTI0NTI0NTI0NTI0NSAgICAgIDI0NQAAAAAAAAAAAAAAAAAyNDUyNDUyNDUyNDUyNDUyNDUyNDUgICAyNDUAAAAAAAAAAAAAAAAAMjQ1MjQ1MjQ1MjQ1MjQ1MjQ1MjQ1MjQ1MjQ1AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==")));

            DataPropertyName = propertyName;
            LeftMargin = 0;
            this.CheckStateChanged += NodeCheckBox_CheckStateChanged;
            CheckChanged = "";
        }

        private void NodeCheckBox_CheckStateChanged(object sender, TreePathEventArgs e)
        {
            if (CheckChanged.Length > 0)
            {
                osf.TreeViewAdvEventArgs TreeViewAdvEventArgs1 = new osf.TreeViewAdvEventArgs(((Aga.Controls.Tree.Node)e.Path.LastNode).TreeNodeAdv);
                TreeViewAdvEventArgs1.EventString = CheckChanged;
                TreeViewAdvEventArgs1.Sender = ((dynamic)sender).dll_obj;
                TreeViewAdvEventArgs1.Parameter = osf.OneScriptForms.GetEventParameter(((dynamic)sender).dll_obj.CheckStateChanged);
                osf.ClTreeViewAdvEventArgs ClTreeViewAdvEventArgs1 = new osf.ClTreeViewAdvEventArgs(TreeViewAdvEventArgs1);
                osf.OneScriptForms.Event = ClTreeViewAdvEventArgs1;
                osf.OneScriptForms.ExecuteEvent(((dynamic)sender).dll_obj.CheckStateChanged);
            }
        }

        public bool ThreeState
        {
            get { return _threeState; }
            set { _threeState = value; }
        }

        public override Size MeasureSize(TreeNodeAdv node, DrawContext context)
        {
            return new Size(ImageSize, ImageSize);
        }

        public override void Draw(TreeNodeAdv node, DrawContext context)
        {
            Rectangle bounds = GetBounds(node, context);
		
            //////CheckState state = GetCheckState(node);
            CheckState state = System.Windows.Forms.CheckState.Unchecked;
            try
            {
                state = (System.Windows.Forms.CheckState)((Node)node.Tag).nodeControlValue[this];
            }
            catch { }
		
            if (Application.RenderWithVisualStyles)
            {
                VisualStyleRenderer renderer;
                if (state == CheckState.Indeterminate)
                {
                    renderer = new VisualStyleRenderer(VisualStyleElement.Button.CheckBox.MixedNormal);
                }
                else if (state == CheckState.Checked)
                {
                    renderer = new VisualStyleRenderer(VisualStyleElement.Button.CheckBox.CheckedNormal);
                }
                else
                {
                    renderer = new VisualStyleRenderer(VisualStyleElement.Button.CheckBox.UncheckedNormal);
                }
                renderer.DrawBackground(context.Graphics, new Rectangle(bounds.X, bounds.Y, ImageSize, ImageSize));
            }
            else
            {
                Image img;
                if (state == CheckState.Indeterminate)
                {
                    img = _unknown;
                }
                else if (state == CheckState.Checked)
                {
                    img = _check;
                }
                else
                {
                    img = _uncheck;
                }
                context.Graphics.DrawImage(img, bounds.Location);
            }
        }

        protected virtual CheckState GetCheckState(TreeNodeAdv node)
        {
            object obj = ((Node)node.Tag).GetControlValue(this);

            if (obj is CheckState)
            {
                return (CheckState)obj;
            }
            else if (obj is System.Int32)
            {
                return (CheckState)obj;
            }
            else if (obj is bool)
            {
                return (bool)obj ? CheckState.Checked : CheckState.Unchecked;
            }
            else
            {
                return CheckState.Unchecked;
            }
        }

        protected virtual void SetCheckState(TreeNodeAdv node, CheckState value)
        {
            if (VirtualMode)
            {
                //////SetValue(node, value);
                ((Node)node.Tag).SetControlValue(this, value);
                OnCheckStateChanged(node);
            }
            else
            {
                //////Type type = GetPropertyType(node);
                Type type = ((Node)node.Tag).GetControlValue(this).GetType();
                if (type == typeof(CheckState))
                {
                    //////SetValue(node, value);
                    ((Node)node.Tag).SetControlValue(this, value);
                    OnCheckStateChanged(node);
                }
                else if (type == typeof(bool))
                {
                    //////SetValue(node, value != CheckState.Unchecked);
                    ((Node)node.Tag).SetControlValue(this, value != CheckState.Unchecked);
                    OnCheckStateChanged(node);
                }
            }
        }

        public override void MouseDown(TreeNodeAdvMouseEventArgs args)
        {
            if (args.Button == MouseButtons.Left && IsEditEnabled(args.Node))
            {
                DrawContext context = new DrawContext();
                context.Bounds = args.ControlBounds;
                Rectangle rect = GetBounds(args.Node, context);
                if (rect.Contains(args.ViewLocation))
                {
                    CheckState state = GetCheckState(args.Node);
                    state = GetNewState(state);
                    SetCheckState(args.Node, state);
                    Parent.UpdateView();
                    args.Handled = true;
                }
            }
        }

        public override void MouseDoubleClick(TreeNodeAdvMouseEventArgs args)
        {
            args.Handled = true;
        }

        private CheckState GetNewState(CheckState state)
        {
            if (state == CheckState.Indeterminate)
            {
                return CheckState.Unchecked;
            }
            else if (state == CheckState.Unchecked)
            {
                return CheckState.Checked;
            }
            else
            {
                return ThreeState ? CheckState.Indeterminate : CheckState.Unchecked;
            }
        }

        public override void KeyDown(KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Space && EditEnabled)
            {
                Parent.BeginUpdate();
                try
                {
                    if (Parent.CurrentNode != null)
                    {
                        CheckState value = GetNewState(GetCheckState(Parent.CurrentNode));
                        foreach (TreeNodeAdv node in Parent.Selection)
                        {
                            if (IsEditEnabled(node))
                            {
                                SetCheckState(node, value);
                            }
                        }
                    }
                }
                finally
                {
                    Parent.EndUpdate();
                }
                args.Handled = true;
            }
        }

        protected void OnCheckStateChanged(TreePathEventArgs args)
        {
            if (CheckStateChanged != null)
            {
                CheckStateChanged(this, args);
            }
        }

        protected void OnCheckStateChanged(TreeNodeAdv node)
        {
            TreePath path = this.Parent.GetPath(node);
            OnCheckStateChanged(new TreePathEventArgs(path));
        }
    }
}

namespace osf
{

    [ContextClass("КлФлажокУзла", "ClNodeCheckBox")]
    public class ClNodeCheckBox : AutoContext<ClNodeCheckBox>
    {
        private IValue _CheckChanged;

        public ClNodeCheckBox()
        {
            Base_obj = new Aga.Controls.Tree.NodeControls.NodeCheckBox();
            Base_obj.dll_obj = this;
        }//end_constr
		
        public ClNodeCheckBox(Aga.Controls.Tree.NodeControls.NodeCheckBox p1)
        {
            Base_obj = p1;
            Base_obj.dll_obj = this;
        }//end_constr

        public Aga.Controls.Tree.NodeControls.NodeCheckBox Base_obj;

        //Свойства============================================================
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

        [ContextProperty("Редактируемый", "EditEnabled")]
        public bool EditEnabled
        {
            get { return Base_obj.EditEnabled; }
            set { Base_obj.EditEnabled = value; }
        }

        [ContextProperty("СостояниеФлажкаИзменено", "CheckStateChanged")]
        public IValue CheckStateChanged
        {
            get { return _CheckChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CheckChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CheckChanged = "DelegateActionTextChanged";
                }
                else
                {
                    _CheckChanged = value;
                    Base_obj.CheckChanged = "osfActionTextChanged";
                }
            }
        }
        
        [ContextProperty("ТриСостояния", "ThreeState")]
        public bool ThreeState
        {
            get { return Base_obj.ThreeState; }
            set { Base_obj.ThreeState = value; }
        }

        //endProperty
        //Методы============================================================
        [ContextMethod("ПолучитьЗначение", "GetValue")]
        public int GetValue(ClNode p1)
        {
            return (int)p1.Base_obj.GetControlValue(Base_obj);
        }

        [ContextMethod("УстановитьЗначение", "SetValue")]
        public void SetValue(ClNode p1, IValue p2)
        {
            p1.Base_obj.SetControlValue(this.Base_obj, (object)(System.Windows.Forms.CheckState)Convert.ToInt32(p2.AsNumber()));
        }

        //endMethods
    }//endClass

}//endnamespace
