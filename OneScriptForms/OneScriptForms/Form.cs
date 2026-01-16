using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;

namespace osf
{
    public class FormEx : System.Windows.Forms.Form
    {
        public osf.Form M_Object;
    }

    public class Form : ContainerControl
    {
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)] public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("User32", EntryPoint = "GetKeyState", CharSet = CharSet.Ansi, SetLastError = true)] public static extern short UserGetKeyState(int nVirtKey);
        private string activated;
        public string Closed;
        public string Closing;
        private string deactivate;
        public ClForm dll_obj;
        private string load;
        public FormEx M_Form;
        private string mdiChildActivate;
        private string resize;

        public Form()
        {
            M_Form = new FormEx();
            M_Form.M_Object = this;
            base.M_ContainerControl = M_Form;
            M_Form.FormClosed += M_Form_FormClosed;
            Closed = "";
            M_Form.Load += M_Form_Load;
            Load = "";
            M_Form.Deactivate += M_Form_Deactivate;
            Deactivate = "";
            M_Form.Activated += M_Form_Activated;
            Activated = "";
            M_Form.FormClosing += M_Form_FormClosing;
            Closing = "";
        }

        public Form(osf.Form p1)
        {
            M_Form = p1.M_Form;
            M_Form.M_Object = this;
            base.M_ContainerControl = M_Form;
            M_Form.FormClosed += M_Form_FormClosed;
            Closed = "";
            M_Form.Load += M_Form_Load;
            Load = "";
            M_Form.Deactivate += M_Form_Deactivate;
            Deactivate = "";
            M_Form.Activated += M_Form_Activated;
            Activated = "";
            M_Form.FormClosing += M_Form_FormClosing;
            Closing = "";
        }

        public Form(System.Windows.Forms.Form p1)
        {
            M_Form = (FormEx)p1;
            M_Form.M_Object = this;
            base.M_ContainerControl = M_Form;
            M_Form.FormClosed += M_Form_FormClosed;
            Closed = "";
            M_Form.Load += M_Form_Load;
            Load = "";
            M_Form.Deactivate += M_Form_Deactivate;
            Deactivate = "";
            M_Form.Activated += M_Form_Activated;
            Activated = "";
            M_Form.FormClosing += M_Form_FormClosing;
            Closing = "";
        }

        public osf.Control AcceptButton
        {
            get
            {
                if (M_Form.AcceptButton != null)
                {
                    return (osf.Control)((dynamic)M_Form.AcceptButton).M_Object;
                }
                return null;
            }
            set { M_Form.AcceptButton = (IButtonControl)value.M_Control; }
        }

        public string Activated
        {
            get { return activated; }
            set { activated = value; }
        }

        public osf.Form ActiveForm
        {
            get
            {
                if (System.Windows.Forms.Form.ActiveForm != null)
                {
                    return (osf.Form)((FormEx)System.Windows.Forms.Form.ActiveForm).M_Object;
                }
                return null;
            }
        }

        public osf.Form ActiveMdiChild
        {
            get
            {
                if (M_Form.ActiveMdiChild != null)
                {
                    return (osf.Form)((dynamic)M_Form.ActiveMdiChild).M_Object;
                }
                return null;
            }
        }

        public osf.Size AutoScaleBaseSize
        {
            get { return new Size(M_Form.AutoScaleBaseSize); }
            set
            {
                M_Form.AutoScaleBaseSize = value.M_Size;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Control CancelButton
        {
            get
            {
                if (M_Form.CancelButton != null)
                {
                    return (osf.Control)((dynamic)M_Form.CancelButton).M_Object;
                }
                return null;
            }
            set
            {
                M_Form.CancelButton = (IButtonControl)value.M_Control;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool ControlBox
        {
            get { return M_Form.ControlBox; }
            set
            {
                M_Form.ControlBox = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public string Deactivate
        {
            get { return deactivate; }
            set
            {
                deactivate = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Point DesktopLocation
        {
            get { return new Point(M_Form.DesktopLocation.X, M_Form.DesktopLocation.Y); }
            set
            {
                M_Form.DesktopLocation = value.M_Point;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public int DialogResult
        {
            get { return (int)M_Form.DialogResult; }
            set
            {
                M_Form.DialogResult = (System.Windows.Forms.DialogResult)value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public int FormBorderStyle
        {
            get { return (int)M_Form.FormBorderStyle; }
            set
            {
                M_Form.FormBorderStyle = (System.Windows.Forms.FormBorderStyle)value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public Icon Icon
        {
            get { return new Icon(M_Form.Icon); }
            set
            {
                M_Form.Icon = (System.Drawing.Icon)value.M_Icon;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public new int Top
        {
            get { return M_Form.Top; }
            set
            {
                M_Form.Top = value;
                M_Form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public new int Left
        {
            get { return M_Form.Left; }
            set
            {
                M_Form.Left = value;
                M_Form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool IsMdiChild
        {
            get { return M_Form.IsMdiChild; }
        }

        public bool IsMdiContainer
        {
            get { return M_Form.IsMdiContainer; }
            set
            {
                M_Form.IsMdiContainer = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool KeyPreview
        {
            get { return M_Form.KeyPreview; }
            set
            {
                M_Form.KeyPreview = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public string Load
        {
            get { return load; }
            set
            {
                load = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool MaximizeBox
        {
            get { return M_Form.MaximizeBox; }
            set
            {
                M_Form.MaximizeBox = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Size MaximumSize
        {
            get { return new Size(M_Form.MaximumSize); }
            set
            {
                M_Form.MaximumSize = value.M_Size;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public string MdiChildActivate
        {
            get { return mdiChildActivate; }
            set
            {
                mdiChildActivate = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.MainMenu Menu
        {
            get { return ((MainMenuEx)M_Form.Menu).M_Object; }
            set
            {
                M_Form.Menu = (System.Windows.Forms.MainMenu)value.M_MainMenu;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool MinimizeBox
        {
            get { return M_Form.MinimizeBox; }
            set
            {
                M_Form.MinimizeBox = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Size MinimumSize
        {
            get { return new Size(M_Form.MinimumSize); }
            set
            {
                M_Form.MinimumSize = value.M_Size;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public new object Parent
        {
            get
            {
                if (M_Form.Owner != null)
                {
                    return ((FormEx)M_Form.Owner).M_Object;
                }
                return null;
            }
            set
            {
                Form.SetParent(M_Form.Handle, ((Control)value).M_Control.Handle);
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Form Owner
        {
            get
            {
                if (M_Form.Owner != null)
                {
                    return (osf.Form)((FormEx)M_Form.Owner).M_Object;
                }
                return null;
            }
            set
            {
                M_Form.Owner = (System.Windows.Forms.Form)value.M_Form;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public string Resize
        {
            get { return resize; }
            set
            {
                resize = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool ShowInTaskbar
        {
            get { return M_Form.ShowInTaskbar; }
            set
            {
                M_Form.ShowInTaskbar = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public int StartPosition
        {
            get { return (int)M_Form.StartPosition; }
            set
            {
                M_Form.StartPosition = (System.Windows.Forms.FormStartPosition)value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool TopMost
        {
            get { return M_Form.TopMost; }
            set
            {
                M_Form.TopMost = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Color TransparencyKey
        {
            get { return new Color(M_Form.TransparencyKey); }
            set
            {
                M_Form.TransparencyKey = value.M_Color;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public int WindowState
        {
            get { return (int)M_Form.WindowState; }
            set
            {
                M_Form.WindowState = (System.Windows.Forms.FormWindowState)value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public void Activate()
        {
            M_Form.Activate();
            //System.Windows.Forms.Application.DoEvents();
        }

        public void Close()
        {
            M_Form.Close();
            //System.Windows.Forms.Application.DoEvents();
        }

        public int GetKeyState(Keys Key)
        {
            return (int)UserGetKeyState((int)Key);
        }

        public void LayoutMdi(MdiLayout value)
        {
            M_Form.LayoutMdi((System.Windows.Forms.MdiLayout)value);
            //System.Windows.Forms.Application.DoEvents();
        }

        public void M_Form_Activated(object sender, System.EventArgs e)
        {
            if (Activated.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Activated;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.Activated);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.Activated);
            }
        }

        public void M_Form_Deactivate(object sender, System.EventArgs e)
        {
            if (Deactivate.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Deactivate;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.Deactivate);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.Deactivate);
            }
        }

        public void M_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Closed.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Closed;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.FormClosed);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.FormClosed);
            }

            if (OneScriptForms.useMainForm && sender == OneScriptForms.FirstForm.Base_obj.M_Form)
            {
                OneScriptForms.goOn = false;
                System.Windows.Forms.Application.Exit();
            }

            OneScriptForms.formsCollection.Remove(((dynamic)sender).M_Object.dll_obj);
            if (OneScriptForms.formsCollection.CountForm == 0)
            {
                OneScriptForms.goOn = false;
                System.Windows.Forms.Application.Exit();
            }
        }

        public void M_Form_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (Closing.Length > 0)
            {
                FormClosingEventArgs FormClosingEventArgs1 = new FormClosingEventArgs(e.CloseReason, e.Cancel);
                FormClosingEventArgs1.EventString = Closing;
                FormClosingEventArgs1.Sender = this;
                FormClosingEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.FormClosing);
                FormClosingEventArgs1.Cancel = e.Cancel;
                FormClosingEventArgs1.CloseReason = (int)e.CloseReason;
                ClFormClosingEventArgs ClFormClosingEventArgs1 = new ClFormClosingEventArgs(FormClosingEventArgs1);
                OneScriptForms.Event = ClFormClosingEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.FormClosing);
                e.Cancel = FormClosingEventArgs1.Cancel;
            }
        }

        public void M_Form_Load(object sender, System.EventArgs e)
        {
            if (Load.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Load;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.Load);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.Load);
            }
        }

        public int ShowDialog()
        {
            return (int)(System.Windows.Forms.DialogResult)M_Form.ShowDialog();
        }
    }

    [ContextClass("КлФорма", "ClForm")]
    public class ClForm : AutoContext<ClForm>
    {
        private IValue _Activated;
        private IValue _Click;
        private IValue _ControlAdded;
        private IValue _ControlRemoved;
        private IValue _Deactivate;
        private IValue _DoubleClick;
        private IValue _Enter;
        private IValue _FormClosed;
        private IValue _FormClosing;
        private IValue _KeyDown;
        private IValue _KeyPress;
        private IValue _KeyUp;
        private IValue _Leave;
        private IValue _Load;
        private IValue _LocationChanged;
        private IValue _LostFocus;
        private IValue _MouseDown;
        private IValue _MouseEnter;
        private IValue _MouseHover;
        private IValue _MouseLeave;
        private IValue _MouseMove;
        private IValue _MouseUp;
        private IValue _Move;
        private IValue _Paint;
        private IValue _SizeChanged;
        private IValue _TextChanged;
        [DllImport("user32.dll", SetLastError = true)] static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        private ClColor backColor;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClCursor cursor;
        private ClDockPaddingEdges dockPadding;
        private ClFont font;
        private ClColor foreColor;
        private ClIcon icon = null;
        [DllImport("user32.dll")] static extern int SetParent(int hWndChild, int hWndNewParent);
        private ClCollection tag = new ClCollection();
        private ClColor transparencyKey;

        public System.Windows.Forms.ContainerControl M_ContainerControl;
        private IRuntimeContextInstance script = null;

        public ClForm()
        {
            Form Form1 = new Form();
            Form1.dll_obj = this;
            Base_obj = Form1;

            OneScriptForms.formsCollection.Add(this);
            if (OneScriptForms.useMainForm)
            {
                if (OneScriptForms.FirstForm == null)
                {
                    OneScriptForms.FirstForm = this;
                }
            }
            bounds = new ClRectangle(Base_obj.Bounds);
            dockPadding = new ClDockPaddingEdges(Base_obj.DockPadding);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            transparencyKey = new ClColor(Base_obj.TransparencyKey);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }

        public Form Base_obj;

        [ContextProperty("АвтоПрокрутка", "AutoScroll")]
        public bool AutoScroll
        {
            get { return Base_obj.AutoScroll; }
            set { Base_obj.AutoScroll = value; }
        }

        [ContextProperty("АктивнаяФорма", "ActiveForm")]
        public ClForm ActiveForm
        {
            get
            {
                if (System.Windows.Forms.Form.ActiveForm != null)
                {
                    return ((Form)((FormEx)System.Windows.Forms.Form.ActiveForm).M_Object).dll_obj;
                }
                return null;
            }
        }

        [ContextProperty("АктивныйЭлемент", "ActiveControl")]
        public IValue ActiveControl
        {
            get { return ((dynamic)Base_obj.ActiveControl).dll_obj; }
            set { Base_obj.ActiveControl = ((dynamic)value).Base_obj; }
        }

        [ContextProperty("ВерсияПродукта", "ProductVersion")]
        public string ProductVersion
        {
            get { return Base_obj.ProductVersion; }
        }

        [ContextProperty("Верх", "Top")]
        public int Top
        {
            get { return Base_obj.Top; }
            set { Base_obj.Top = value; }
        }

        [ContextProperty("Владелец", "Owner")]
        public ClForm Owner
        {
            get { return Base_obj.Owner.dll_obj; }
            set { Base_obj.Owner = value.Base_obj; }
        }

        [ContextProperty("Высота", "Height")]
        public int Height
        {
            get { return Base_obj.Height; }
            set { Base_obj.Height = value; }
        }

        [ContextProperty("ВысотаШрифта", "FontHeight")]
        public int FontHeight
        {
            get { return Convert.ToInt32(Base_obj.FontHeight); }
        }

        [ContextProperty("Границы", "Bounds")]
        public ClRectangle Bounds
        {
            get { return bounds; }
            set
            {
                bounds = value;
                Base_obj.Bounds = value.Base_obj;
            }
        }

        [ContextProperty("ДвойноеНажатие", "DoubleClick")]
        public IValue DoubleClick
        {
            get { return _DoubleClick; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _DoubleClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.DoubleClick = "DelegateActionDoubleClick";
                }
                else
                {
                    _DoubleClick = value;
                    Base_obj.DoubleClick = "osfActionDoubleClick";
                }
            }
        }

        [ContextProperty("Доступность", "Enabled")]
        public bool Enabled
        {
            get { return Base_obj.Enabled; }
            set { Base_obj.Enabled = value; }
        }

        [ContextProperty("ЖирныйШрифт", "FontBold")]
        public bool FontBold
        {
            get { return Base_obj.FontBold; }
            set { Base_obj.FontBold = value; }
        }

        [ContextProperty("Закрыта", "FormClosed")]
        public IValue FormClosed
        {
            get { return _FormClosed; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _FormClosed = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Closed = "DelegateActionClosed";
                }
                else
                {
                    _FormClosed = value;
                    Base_obj.Closed = "osfActionClosed";
                }
            }
        }

        [ContextProperty("ЗаполнениеГраниц", "DockPadding")]
        public ClDockPaddingEdges DockPadding
        {
            get { return dockPadding; }
        }

        [ContextProperty("Захват", "Capture")]
        public bool Capture
        {
            get { return Base_obj.Capture; }
            set { Base_obj.Capture = value; }
        }

        [ContextProperty("Значок", "Icon")]
        public ClIcon Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                Base_obj.Icon = value.Base_obj;
            }
        }

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
            set { Base_obj.Name = value; }
        }

        [ContextProperty("ИмяПродукта", "ProductName")]
        public string ProductName
        {
            get { return ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title.ToString(); }
        }

        [ContextProperty("ИмяШрифта", "FontName")]
        public string FontName
        {
            get { return Base_obj.FontName; }
            set { Base_obj.FontName = value; }
        }

        [ContextProperty("ИспользоватьКурсорОжидания", "UseWaitCursor")]
        public bool UseWaitCursor
        {
            get { return Base_obj.UseWaitCursor; }
            set { Base_obj.UseWaitCursor = value; }
        }

        [ContextProperty("КлавишаВверх", "KeyUp")]
        public IValue KeyUp
        {
            get { return _KeyUp; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _KeyUp = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyUp = "DelegateActionKeyUp";
                }
                else
                {
                    _KeyUp = value;
                    Base_obj.KeyUp = "osfActionKeyUp";
                }
            }
        }

        [ContextProperty("КлавишаВниз", "KeyDown")]
        public IValue KeyDown
        {
            get { return _KeyDown; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _KeyDown = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyDown = "DelegateActionKeyDown";
                }
                else
                {
                    _KeyDown = value;
                    Base_obj.KeyDown = "osfActionKeyDown";
                }
            }
        }

        [ContextProperty("КлавишаНажата", "KeyPress")]
        public IValue KeyPress
        {
            get { return _KeyPress; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _KeyPress = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyPress = "DelegateActionKeyPress";
                }
                else
                {
                    _KeyPress = value;
                    Base_obj.KeyPress = "osfActionKeyPress";
                }
            }
        }

        [ContextProperty("КлавишаПредпросмотр", "KeyPreview")]
        public bool KeyPreview
        {
            get { return Base_obj.KeyPreview; }
            set { Base_obj.KeyPreview = value; }
        }

        [ContextProperty("КлиентВысота", "ClientHeight")]
        public int ClientHeight
        {
            get { return Base_obj.ClientHeight; }
            set { Base_obj.ClientHeight = value; }
        }

        [ContextProperty("КлиентПрямоугольник", "ClientRectangle")]
        public ClRectangle ClientRectangle
        {
            get { return clientRectangle; }
        }

        [ContextProperty("КлиентРазмер", "ClientSize")]
        public ClSize ClientSize
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.ClientSize); }
            set { Base_obj.ClientSize = value.Base_obj; }
        }

        [ContextProperty("КлиентШирина", "ClientWidth")]
        public int ClientWidth
        {
            get { return Base_obj.ClientWidth; }
            set { Base_obj.ClientWidth = value; }
        }

        [ContextProperty("КнопкаМаксимизации", "MaximizeBox")]
        public bool MaximizeBox
        {
            get { return Base_obj.MaximizeBox; }
            set { Base_obj.MaximizeBox = value; }
        }

        [ContextProperty("КнопкаМинимизации", "MinimizeBox")]
        public bool MinimizeBox
        {
            get { return Base_obj.MinimizeBox; }
            set { Base_obj.MinimizeBox = value; }
        }

        [ContextProperty("КнопкаОтмена", "CancelButton")]
        public IValue CancelButton
        {
            get { return ((dynamic)Base_obj.CancelButton).dll_obj; }
            set { Base_obj.CancelButton = ((dynamic)value).Base_obj; }
        }

        [ContextProperty("КнопкаПринять", "AcceptButton")]
        public IValue AcceptButton
        {
            get { return ((dynamic)Base_obj.AcceptButton).dll_obj; }
            set { Base_obj.AcceptButton = ((dynamic)value).Base_obj; }
        }

        [ContextProperty("КнопкиМыши", "MouseButtons")]
        public int MouseButtons
        {
            get { return (int)Base_obj.MouseButtons; }
        }

        [ContextProperty("КонтекстноеМеню", "ContextMenu")]
        public ClContextMenu ContextMenu
        {
            get { return (ClContextMenu)OneScriptForms.RevertObj(Base_obj.ContextMenu); }
            set { Base_obj.ContextMenu = value.Base_obj; }
        }

        [ContextProperty("Курсор", "Cursor")]
        public ClCursor Cursor
        {
            get
            {
                if (cursor != null)
                {
                    return cursor;
                }
                return new ClCursor(Base_obj.Cursor);
            }
            set
            {
                cursor = value;
                Base_obj.Cursor = value.Base_obj;
            }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
            get { return Base_obj.Left; }
            set { Base_obj.Left = value; }
        }

        [ContextProperty("МаксимальныйРазмер", "MaximumSize")]
        public ClSize MaximumSize
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.MaximumSize); }
            set { Base_obj.MaximumSize = value.Base_obj; }
        }

        [ContextProperty("Меню", "Menu")]
        public ClMainMenu Menu
        {
            get { return Base_obj.Menu.dll_obj; }
            set { Base_obj.Menu = value.Base_obj; }
        }

        [ContextProperty("Местоположение", "DesktopLocation")]
        public ClPoint DesktopLocation
        {
            get { return (ClPoint)OneScriptForms.RevertObj(Base_obj.DesktopLocation); }
            set { Base_obj.DesktopLocation = value.Base_obj; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }

        [ContextProperty("МинимальныйРазмер", "MinimumSize")]
        public ClSize MinimumSize
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.MinimumSize); }
            set { Base_obj.MinimumSize = value.Base_obj; }
        }

        [ContextProperty("МышьНадЭлементом", "MouseEnter")]
        public IValue MouseEnter
        {
            get { return _MouseEnter; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseEnter = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseEnter = "DelegateActionMouseEnter";
                }
                else
                {
                    _MouseEnter = value;
                    Base_obj.MouseEnter = "osfActionMouseEnter";
                }
            }
        }

        [ContextProperty("МышьПокинулаЭлемент", "MouseLeave")]
        public IValue MouseLeave
        {
            get { return _MouseLeave; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseLeave = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseLeave = "DelegateActionMouseLeave";
                }
                else
                {
                    _MouseLeave = value;
                    Base_obj.MouseLeave = "osfActionMouseLeave";
                }
            }
        }

        [ContextProperty("Нажатие", "Click")]
        public IValue Click
        {
            get { return _Click; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Click = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Click = "DelegateActionClick";
                }
                else
                {
                    _Click = value;
                    Base_obj.Click = "osfActionClick";
                }
            }
        }

        [ContextProperty("НачальноеПоложение", "StartPosition")]
        public int StartPosition
        {
            get { return (int)Base_obj.StartPosition; }
            set { Base_obj.StartPosition = value; }
        }

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
            get { return Base_obj.Bottom; }
        }

        [ContextProperty("ОконноеМеню", "ControlBox")]
        public bool ControlBox
        {
            get { return Base_obj.ControlBox; }
            set { Base_obj.ControlBox = value; }
        }

        [ContextProperty("ОсновнойЦвет", "ForeColor")]
        public ClColor ForeColor
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                Base_obj.ForeColor = value.Base_obj;
            }
        }

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
        }

        [ContextProperty("ПоверхВсех", "TopMost")]
        public bool TopMost
        {
            get { return Base_obj.TopMost; }
            set { Base_obj.TopMost = value; }
        }

        [ContextProperty("ПозицияМыши", "MousePosition")]
        public ClPoint MousePosition
        {
            get { return new ClPoint(System.Windows.Forms.Control.MousePosition); }
        }

        [ContextProperty("ПоказатьВПанели", "ShowInTaskbar")]
        public bool ShowInTaskbar
        {
            get { return Base_obj.ShowInTaskbar; }
            set { Base_obj.ShowInTaskbar = value; }
        }

        [ContextProperty("Положение", "Location")]
        public ClPoint Location
        {
            get { return (ClPoint)OneScriptForms.RevertObj(Base_obj.Location); }
            set { Base_obj.Location = value.Base_obj; }
        }

        [ContextProperty("ПоложениеИзменено", "LocationChanged")]
        public IValue LocationChanged
        {
            get { return _LocationChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _LocationChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.LocationChanged = "DelegateActionLocationChanged";
                }
                else
                {
                    _LocationChanged = value;
                    Base_obj.LocationChanged = "osfActionLocationChanged";
                }
            }
        }

        [ContextProperty("ПорядокОбхода", "TabIndex")]
        public int TabIndex
        {
            get { return Base_obj.TabIndex; }
            set { Base_obj.TabIndex = value; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
            get { return Base_obj.Right; }
        }

        [ContextProperty("ПриАктивизации", "Activated")]
        public IValue Activated
        {
            get { return _Activated; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Activated = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Activated = "DelegateActionActivated";
                }
                else
                {
                    _Activated = value;
                    Base_obj.Activated = "osfActionActivated";
                }
            }
        }

        [ContextProperty("ПриВходе", "Enter")]
        public IValue Enter
        {
            get { return _Enter; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Enter = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Enter = "DelegateActionEnter";
                }
                else
                {
                    _Enter = value;
                    Base_obj.Enter = "osfActionEnter";
                }
            }
        }

        [ContextProperty("ПриДеактивации", "Deactivate")]
        public IValue Deactivate
        {
            get { return _Deactivate; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Deactivate = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Deactivate = "DelegateActionDeactivate";
                }
                else
                {
                    _Deactivate = value;
                    Base_obj.Deactivate = "osfActionDeactivate";
                }
            }
        }

        [ContextProperty("ПриЗагрузке", "Load")]
        public IValue Load
        {
            get { return _Load; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Load = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Load = "DelegateActionLoad";
                }
                else
                {
                    _Load = value;
                    Base_obj.Load = "osfActionLoad";
                }
            }
        }

        [ContextProperty("ПриЗадержкеМыши", "MouseHover")]
        public IValue MouseHover
        {
            get { return _MouseHover; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseHover = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseHover = "DelegateActionMouseHover";
                }
                else
                {
                    _MouseHover = value;
                    Base_obj.MouseHover = "osfActionMouseHover";
                }
            }
        }

        [ContextProperty("ПриЗакрытии", "FormClosing")]
        public IValue FormClosing
        {
            get { return _FormClosing; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _FormClosing = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Closing = "DelegateActionClosing";
                }
                else
                {
                    _FormClosing = value;
                    Base_obj.Closing = "osfActionClosing";
                }
            }
        }

        [ContextProperty("ПриНажатииКнопкиМыши", "MouseDown")]
        public IValue MouseDown
        {
            get { return _MouseDown; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseDown = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseDown = "DelegateActionMouseDown";
                }
                else
                {
                    _MouseDown = value;
                    Base_obj.MouseDown = "osfActionMouseDown";
                }
            }
        }

        [ContextProperty("ПриОтпусканииМыши", "MouseUp")]
        public IValue MouseUp
        {
            get { return _MouseUp; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseUp = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseUp = "DelegateActionMouseUp";
                }
                else
                {
                    _MouseUp = value;
                    Base_obj.MouseUp = "osfActionMouseUp";
                }
            }
        }

        [ContextProperty("ПриПеремещении", "Move")]
        public IValue Move
        {
            get { return _Move; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Move = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Move = "DelegateActionMove";
                }
                else
                {
                    _Move = value;
                    Base_obj.Move = "osfActionMove";
                }
            }
        }

        [ContextProperty("ПриПеремещенииМыши", "MouseMove")]
        public IValue MouseMove
        {
            get { return _MouseMove; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseMove = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseMove = "DelegateActionMouseMove";
                }
                else
                {
                    _MouseMove = value;
                    Base_obj.MouseMove = "osfActionMouseMove";
                }
            }
        }

        [ContextProperty("ПриПерерисовке", "Paint")]
        public IValue Paint
        {
            get { return _Paint; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Paint = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Paint = "DelegateActionPaint";
                }
                else
                {
                    _Paint = value;
                    Base_obj.Paint = "osfActionPaint";
                }
            }
        }

        [ContextProperty("ПриПотереФокуса", "LostFocus")]
        public IValue LostFocus
        {
            get { return _LostFocus; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _LostFocus = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.LostFocus = "DelegateActionLostFocus";
                }
                else
                {
                    _LostFocus = value;
                    Base_obj.LostFocus = "osfActionLostFocus";
                }
            }
        }

        [ContextProperty("ПриУходе", "Leave")]
        public IValue Leave
        {
            get { return _Leave; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Leave = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Leave = "DelegateActionLeave";
                }
                else
                {
                    _Leave = value;
                    Base_obj.Leave = "osfActionLeave";
                }
            }
        }

        [ContextProperty("ПрозрачныйЦвет", "TransparencyKey")]
        public ClColor TransparencyKey
        {
            get { return transparencyKey; }
            set
            {
                transparencyKey = value;
                Base_obj.TransparencyKey = value.Base_obj;
            }
        }

        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
            set { Base_obj.Size = value.Base_obj; }
        }

        [ContextProperty("РазмерАвтоМасштабирования", "AutoScaleBaseSize")]
        public ClSize AutoScaleBaseSize
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.AutoScaleBaseSize); }
            set { Base_obj.AutoScaleBaseSize = value.Base_obj; }
        }

        [ContextProperty("РазмерИзменен", "SizeChanged")]
        public IValue SizeChanged
        {
            get { return _SizeChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _SizeChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.SizeChanged = "DelegateActionSizeChanged";
                }
                else
                {
                    _SizeChanged = value;
                    Base_obj.SizeChanged = "osfActionSizeChanged";
                }
            }
        }

        [ContextProperty("РазмерПоляАвтоПрокрутки", "AutoScrollMargin")]
        public ClSize AutoScrollMargin
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.AutoScrollMargin); }
            set { Base_obj.AutoScrollMargin = value.Base_obj; }
        }

        [ContextProperty("РазмерШрифта", "FontSize")]
        public int FontSize
        {
            get { return Convert.ToInt32(Base_obj.FontSize); }
            set { Base_obj.FontSize = value; }
        }

        [ContextProperty("РезультатДиалога", "DialogResult")]
        public int DialogResult
        {
            get { return (int)Base_obj.DialogResult; }
            set { Base_obj.DialogResult = value; }
        }

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }

        [ContextProperty("СостояниеОкна", "WindowState")]
        public int WindowState
        {
            get { return (int)Base_obj.WindowState; }
            set { Base_obj.WindowState = value; }
        }

        [ContextProperty("СтильГраницыФормы", "FormBorderStyle")]
        public int FormBorderStyle
        {
            get { return (int)Base_obj.FormBorderStyle; }
            set { Base_obj.FormBorderStyle = value; }
        }

        [ContextProperty("Стыковка", "Dock")]
        public int Dock
        {
            get { return (int)Base_obj.Dock; }
            set { Base_obj.Dock = value; }
        }

        [ContextProperty("Сфокусирован", "Focused")]
        public bool Focused
        {
            get { return Base_obj.Focused; }
        }

        [ContextProperty("Сценарий", "Script")]
        public IRuntimeContextInstance Script
        {
            get { return script; }
            set { script = value; }
        }

        [ContextProperty("ТабФокус", "TabStop")]
        public bool TabStop
        {
            get { return Base_obj.TabStop; }
            set { Base_obj.TabStop = value; }
        }

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("ТекстИзменен", "TextChanged")]
        public IValue TextChanged
        {
            get { return _TextChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _TextChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.TextChanged = "DelegateActionTextChanged";
                }
                else
                {
                    _TextChanged = value;
                    Base_obj.TextChanged = "osfActionTextChanged";
                }
            }
        }

        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }

        [ContextProperty("Фокусируемый", "CanFocus")]
        public bool CanFocus
        {
            get { return Base_obj.CanFocus; }
        }

        [ContextProperty("ФоновоеИзображение", "BackgroundImage")]
        public ClBitmap BackgroundImage
        {
            get { return new ClBitmap(Base_obj.BackgroundImage); }
            set { Base_obj.BackgroundImage = value.Base_obj; }
        }

        [ContextProperty("ЦветФона", "BackColor")]
        public ClColor BackColor
        {
            get { return backColor; }
            set
            {
                backColor = value;
                Base_obj.BackColor = value.Base_obj;
            }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
            set { Base_obj.Width = value; }
        }

        [ContextProperty("Шрифт", "Font")]
        public ClFont Font
        {
            get
            {
                if (font != null)
                {
                    return font;
                }
                return new ClFont(Base_obj.Font);
            }
            set
            {
                font = value;
                Base_obj.Font = value.Base_obj;
            }
        }

        [ContextProperty("ЭлементВерхнегоУровня", "TopLevelControl")]
        public IValue TopLevelControl
        {
            get { return OneScriptForms.RevertObj(Base_obj.TopLevelControl); }
        }

        [ContextProperty("ЭлементДобавлен", "ControlAdded")]
        public IValue ControlAdded
        {
            get { return _ControlAdded; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _ControlAdded = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ControlAdded = "DelegateActionControlAdded";
                }
                else
                {
                    _ControlAdded = value;
                    Base_obj.ControlAdded = "osfActionControlAdded";
                }
            }
        }

        [ContextProperty("ЭлементУдален", "ControlRemoved")]
        public IValue ControlRemoved
        {
            get { return _ControlRemoved; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _ControlRemoved = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ControlRemoved = "DelegateActionControlRemoved";
                }
                else
                {
                    _ControlRemoved = value;
                    Base_obj.ControlRemoved = "osfActionControlRemoved";
                }
            }
        }

        [ContextProperty("ЭлементыУправления", "Controls")]
        public ClControlCollection Controls
        {
            get { return controls; }
        }

        [ContextProperty("Якорь", "Anchor")]
        public int Anchor
        {
            get { return (int)Base_obj.Anchor; }
            set { Base_obj.Anchor = value; }
        }

        [ContextMethod("Активизировать", "Activate")]
        public void Activate()
        {
            Base_obj.Activate();
        }

        [ContextMethod("Актуализировать", "Refresh")]
        public void Refresh()
        {
            Base_obj.Refresh();
        }

        [ContextMethod("Аннулировать", "Invalidate")]
        public void Invalidate()
        {
            Base_obj.Invalidate();
        }

        [ContextMethod("ВозобновитьРазмещение", "ResumeLayout")]
        public void ResumeLayout(bool p1 = false)
        {
            Base_obj.ResumeLayout(p1);
        }

        [ContextMethod("ВосстановитьФоновоеИзображение", "ResetBackgroundImage")]
        public void ResetBackgroundImage()
        {
            Base_obj.ResetBackgroundImage();
        }

        [ContextMethod("Выбрать", "Select")]
        public void Select()
        {
            Base_obj.Select();
        }

        [ContextMethod("ВыполнитьРазмещение", "PerformLayout")]
        public void PerformLayout()
        {
            Base_obj.PerformLayout();
        }

        [ContextMethod("ДочернийПоКоординатам", "GetChildAtPoint")]
        public IValue GetChildAtPoint(ClPoint p1)
        {
            return ((dynamic)Base_obj.GetChildAtPoint(p1.Base_obj)).dll_obj;
        }

        [ContextMethod("ЗавершитьОбновление", "EndUpdate")]
        public void EndUpdate()
        {
            Base_obj.EndUpdate();
        }

        [ContextMethod("ЗакрепитьНаРабочемСтоле", "PinToDesktop")]
        public void PinToDesktop()
        {
            IntPtr hWnd = Base_obj.M_Form.Handle;
            IntPtr hWndProgMan = FindWindow("Progman", "Program Manager");
            SetParent(hWnd.ToInt32(), hWndProgMan.ToInt32());
        }

        [ContextMethod("Закрыть", "Close")]
        public void Close()
        {
            Base_obj.Close();
        }

        [ContextMethod("НаЗаднийПлан", "SendToBack")]
        public void SendToBack()
        {
            Base_obj.SendToBack();
        }

        [ContextMethod("НайтиФорму", "FindForm")]
        public ClForm FindForm()
        {
            if (Base_obj.FindForm() != null)
            {
                return Base_obj.FindForm().dll_obj;
            }
            return null;
        }

        [ContextMethod("НайтиЭлемент", "FindControl")]
        public IValue FindControl(string p1)
        {
            return OneScriptForms.RevertObj(Base_obj.FindControl(p1));
        }

        [ContextMethod("НаПереднийПлан", "BringToFront")]
        public void BringToFront()
        {
            Base_obj.BringToFront();
        }

        [ContextMethod("НачатьОбновление", "BeginUpdate")]
        public void BeginUpdate()
        {
            Base_obj.BeginUpdate();
        }

        [ContextMethod("Обновить", "Update")]
        public void Update()
        {
            Base_obj.Update();
        }

        [ContextMethod("ОбновитьСтили", "UpdateStyles")]
        public void UpdateStyles()
        {
            Base_obj.UpdateStyles();
        }

        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }

        [ContextMethod("ОткрепитьОтРабочегоСтола", "UnpinFromDesktop")]
        public void UnpinFromDesktop()
        {
            IntPtr hWnd = Base_obj.M_Form.Handle;
            SetParent(hWnd.ToInt32(), IntPtr.Zero.ToInt32());
        }

        [ContextMethod("Показать", "Show")]
        public void Show()
        {
            Base_obj.Show();
        }

        [ContextMethod("ПоказатьДиалог", "ShowDialog")]
        public int ShowDialog()
        {
            return Base_obj.ShowDialog();
        }

        [ContextMethod("ПолучитьСтиль", "GetStyle")]
        public bool GetStyle(int p1)
        {
            return Base_obj.GetStyle((System.Windows.Forms.ControlStyles)p1);
        }

        [ContextMethod("ПриостановитьРазмещение", "SuspendLayout")]
        public void SuspendLayout()
        {
            Base_obj.SuspendLayout();
        }

        [ContextMethod("Скрыть", "Hide")]
        public void Hide()
        {
            Base_obj.Hide();
        }

        [ContextMethod("СледующийЭлемент", "GetNextControl")]
        public IValue GetNextControl(IValue p1, bool p2)
        {
            return Base_obj.GetNextControl(((dynamic)p1).Base_obj, p2).dll_obj;
        }

        [ContextMethod("СоздатьГрафику", "CreateGraphics")]
        public ClGraphics CreateGraphics()
        {
            return new ClGraphics(Base_obj.CreateGraphics());
        }

        [ContextMethod("СоздатьЭлемент", "CreateControl")]
        public void CreateControl()
        {
            Base_obj.CreateControl();
        }

        [ContextMethod("ТочкаНаКлиенте", "PointToClient")]
        public ClPoint PointToClient(ClPoint p1)
        {
            return new ClPoint(Base_obj.PointToClient(p1.Base_obj));
        }

        [ContextMethod("ТочкаНаЭкране", "PointToScreen")]
        public ClPoint PointToScreen(ClPoint p1)
        {
            return new ClPoint(Base_obj.PointToScreen(p1.Base_obj));
        }

        [ContextMethod("УстановитьГраницы", "SetBounds")]
        public void SetBounds(int p1, int p2, int p3, int p4)
        {
            Base_obj.SetBounds(p1, p2, p3, p4);
        }

        [ContextMethod("УстановитьСтиль", "SetStyle")]
        public void SetStyle(int p1, bool p2)
        {
            Base_obj.SetStyle((System.Windows.Forms.ControlStyles)p1, p2);
        }

        [ContextMethod("Фокус", "Focus")]
        public void Focus()
        {
            Base_obj.Focus();
        }

        [ContextMethod("ЭлементУправления", "Control")]
        public IValue Control(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.getControl(p1));
        }

        [ContextMethod("ЭлементыУправления", "Controls")]
        public IValue Controls2(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.Controls2(p1));
        }
    }
}
