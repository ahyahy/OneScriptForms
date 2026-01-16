using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class MaskedTextBoxEx : System.Windows.Forms.MaskedTextBox
    {
        public osf.MaskedTextBox M_Object;
    }

    public class MaskedTextBox : TextBoxBase
    {
        public ClMaskedTextBox dll_obj;
        public MaskedTextBoxEx M_MaskedTextBox;
        public string MaskInputRejected;
        public new string TextChanged;

        public MaskedTextBox()
        {
            M_MaskedTextBox = new MaskedTextBoxEx();
            M_MaskedTextBox.M_Object = this;
            base.M_TextBoxBase = M_MaskedTextBox;
            M_MaskedTextBox.MaskInputRejected += M_MaskedTextBox_MaskInputRejected;
            MaskInputRejected = "";
            M_MaskedTextBox.TextChanged += M_MaskedTextBox_TextChanged;
            TextChanged = "";
        }

        public MaskedTextBox(osf.MaskedTextBox p1)
        {
            M_MaskedTextBox = p1.M_MaskedTextBox;
            M_MaskedTextBox.M_Object = this;
            base.M_TextBoxBase = M_MaskedTextBox;
            M_MaskedTextBox.MaskInputRejected += M_MaskedTextBox_MaskInputRejected;
            MaskInputRejected = "";
            M_MaskedTextBox.TextChanged += M_MaskedTextBox_TextChanged;
            TextChanged = "";
        }

        public MaskedTextBox(System.Windows.Forms.MaskedTextBox p1)
        {
            M_MaskedTextBox = (MaskedTextBoxEx)p1;
            M_MaskedTextBox.M_Object = this;
            base.M_TextBoxBase = M_MaskedTextBox;
            M_MaskedTextBox.MaskInputRejected += M_MaskedTextBox_MaskInputRejected;
            MaskInputRejected = "";
            M_MaskedTextBox.TextChanged += M_MaskedTextBox_TextChanged;
            TextChanged = "";
        }

        public bool AllowPromptAsInput
        {
            get { return M_MaskedTextBox.AllowPromptAsInput; }
            set { M_MaskedTextBox.AllowPromptAsInput = value; }
        }

        public bool AsciiOnly
        {
            get { return M_MaskedTextBox.AsciiOnly; }
            set { M_MaskedTextBox.AsciiOnly = value; }
        }

        public bool BeepOnError
        {
            get { return M_MaskedTextBox.BeepOnError; }
            set { M_MaskedTextBox.BeepOnError = value; }
        }

        public int CutCopyMaskFormat
        {
            get { return (int)M_MaskedTextBox.CutCopyMaskFormat; }
            set { M_MaskedTextBox.CutCopyMaskFormat = (System.Windows.Forms.MaskFormat)value; }
        }

        public bool HidePromptOnLeave
        {
            get { return M_MaskedTextBox.HidePromptOnLeave; }
            set { M_MaskedTextBox.HidePromptOnLeave = value; }
        }

        public int InsertKeyMode
        {
            get { return (int)M_MaskedTextBox.InsertKeyMode; }
            set { M_MaskedTextBox.InsertKeyMode = (System.Windows.Forms.InsertKeyMode)value; }
        }

        public bool IsOverwriteMode
        {
            get { return M_MaskedTextBox.IsOverwriteMode; }
        }

        public string Mask
        {
            get { return M_MaskedTextBox.Mask; }
            set { M_MaskedTextBox.Mask = value; }
        }

        public bool MaskCompleted
        {
            get { return M_MaskedTextBox.MaskCompleted; }
        }

        public bool MaskFull
        {
            get { return M_MaskedTextBox.MaskFull; }
        }

        public string PasswordChar
        {
            get { return Convert.ToString(M_MaskedTextBox.PasswordChar); }
            set { M_MaskedTextBox.PasswordChar = Convert.ToChar(value); }
        }

        public string PromptChar
        {
            get { return Convert.ToString(M_MaskedTextBox.PromptChar); }
            set { M_MaskedTextBox.PromptChar = Convert.ToChar(value); }
        }

        public bool ResetOnPrompt
        {
            get { return M_MaskedTextBox.ResetOnPrompt; }
            set { M_MaskedTextBox.ResetOnPrompt = value; }
        }

        public bool ResetOnSpace
        {
            get { return M_MaskedTextBox.ResetOnSpace; }
            set { M_MaskedTextBox.ResetOnSpace = value; }
        }

        public bool SkipLiterals
        {
            get { return M_MaskedTextBox.SkipLiterals; }
            set { M_MaskedTextBox.SkipLiterals = value; }
        }

        public new string SelectedText
        {
            get { return M_MaskedTextBox.SelectedText; }
            set { M_MaskedTextBox.SelectedText = value; }
        }

        public int TextAlign
        {
            get { return (int)M_MaskedTextBox.TextAlign; }
            set { M_MaskedTextBox.TextAlign = (System.Windows.Forms.HorizontalAlignment)value; }
        }

        public int TextMaskFormat
        {
            get { return (int)M_MaskedTextBox.TextMaskFormat; }
            set { M_MaskedTextBox.TextMaskFormat = (System.Windows.Forms.MaskFormat)value; }
        }

        public bool UseSystemPasswordChar
        {
            get { return M_MaskedTextBox.UseSystemPasswordChar; }
            set { M_MaskedTextBox.UseSystemPasswordChar = value; }
        }

        private void M_MaskedTextBox_MaskInputRejected(object sender, System.Windows.Forms.MaskInputRejectedEventArgs e)
        {
            if (MaskInputRejected.Length > 0)
            {
                MaskInputRejectedEventArgs MaskInputRejectedEventArgs1 = new MaskInputRejectedEventArgs();
                MaskInputRejectedEventArgs1.EventString = MaskInputRejected;
                MaskInputRejectedEventArgs1.Sender = this;
                MaskInputRejectedEventArgs1.Position = e.Position;
                MaskInputRejectedEventArgs1.RejectionHint = (int)e.RejectionHint;
                MaskInputRejectedEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.MaskInputRejected);
                ClMaskInputRejectedEventArgs ClMaskInputRejectedEventArgs1 = new ClMaskInputRejectedEventArgs(MaskInputRejectedEventArgs1);
                OneScriptForms.Event = ClMaskInputRejectedEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.MaskInputRejected);
            }
        }

        private void M_MaskedTextBox_TextChanged(object sender, System.EventArgs e)
        {
            if (TextChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = TextChanged;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.TextChanged);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.TextChanged);
            }
        }
    }

    [ContextClass("КлМаскаПоляВвода", "ClMaskedTextBox")]
    public class ClMaskedTextBox : AutoContext<ClMaskedTextBox>
    {
        private IValue _Click;
        private IValue _ControlAdded;
        private IValue _ControlRemoved;
        private IValue _DoubleClick;
        private IValue _Enter;
        private IValue _KeyDown;
        private IValue _KeyPress;
        private IValue _KeyUp;
        private IValue _Leave;
        private IValue _LocationChanged;
        private IValue _LostFocus;
        private IValue _MaskInputRejected;
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
        private ClColor backColor;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClCursor cursor;
        private ClFont font;
        private ClColor foreColor;
        private ClCollection tag = new ClCollection();

        public ClMaskedTextBox(string p1 = null)
        {
            MaskedTextBox MaskedTextBox1 = new MaskedTextBox();
            MaskedTextBox1.dll_obj = this;
            Base_obj = MaskedTextBox1;
            MaskedTextBox1.Mask = p1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }

        public ClMaskedTextBox(osf.MaskedTextBox p1)
        {
            MaskedTextBox MaskedTextBox1 = p1;
            MaskedTextBox1.dll_obj = this;
            Base_obj = MaskedTextBox1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }

        public MaskedTextBox Base_obj;

        [ContextProperty("АвтоРазмер", "AutoSize")]
        public bool AutoSize
        {
            get { return Base_obj.AutoSize; }
            set { Base_obj.AutoSize = value; }
        }

        [ContextProperty("ВводОтклонен", "MaskInputRejected")]
        public IValue MaskInputRejected
        {
            get { return _MaskInputRejected; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MaskInputRejected = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MaskInputRejected = "DelegateActionMaskInputRejected";
                }
                else
                {
                    _MaskInputRejected = value;
                    Base_obj.MaskInputRejected = "osfActionMaskInputRejected";
                }
            }
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

        [ContextProperty("ВыделенныйТекст", "SelectedText")]
        public string SelectedText
        {
            get { return Base_obj.SelectedText; }
            set { Base_obj.SelectedText = value; }
        }

        [ContextProperty("ВыравниваниеТекста", "TextAlign")]
        public int TextAlign
        {
            get { return (int)Base_obj.TextAlign; }
            set { Base_obj.TextAlign = value; }
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

        [ContextProperty("ДлинаВыделения", "SelectionLength")]
        public int SelectionLength
        {
            get { return Base_obj.SelectionLength; }
            set { Base_obj.SelectionLength = value; }
        }

        [ContextProperty("ДлинаТекста", "TextLength")]
        public int TextLength
        {
            get { return Base_obj.TextLength; }
        }

        [ContextProperty("Доступность", "Enabled")]
        public bool Enabled
        {
            get { return Base_obj.Enabled; }
            set { Base_obj.Enabled = value; }
        }

        [ContextProperty("Завершена", "MaskCompleted")]
        public bool MaskCompleted
        {
            get { return Base_obj.MaskCompleted; }
        }

        [ContextProperty("Заполнена", "MaskFull")]
        public bool MaskFull
        {
            get { return Base_obj.MaskFull; }
        }

        [ContextProperty("Захват", "Capture")]
        public bool Capture
        {
            get { return Base_obj.Capture; }
            set { Base_obj.Capture = value; }
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

        [ContextProperty("ИспользоватьКурсорОжидания", "UseWaitCursor")]
        public bool UseWaitCursor
        {
            get { return Base_obj.UseWaitCursor; }
            set { Base_obj.UseWaitCursor = value; }
        }

        [ContextProperty("ИспользоватьСимволПриглашения", "AllowPromptAsInput")]
        public bool AllowPromptAsInput
        {
            get { return Base_obj.AllowPromptAsInput; }
            set { Base_obj.AllowPromptAsInput = value; }
        }

        [ContextProperty("ИспользоватьСистемныйСимволПароля", "UseSystemPasswordChar")]
        public bool UseSystemPasswordChar
        {
            get { return Base_obj.UseSystemPasswordChar; }
            set { Base_obj.UseSystemPasswordChar = value; }
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

        [ContextProperty("КонтекстноеМеню", "ContextMenu")]
        public ClContextMenu ContextMenu
        {
            get { return (ClContextMenu)OneScriptForms.RevertObj(Base_obj.ContextMenu); }
            set { Base_obj.ContextMenu = value.Base_obj; }
        }

        [ContextProperty("КопироватьМаску", "CutCopyMaskFormat")]
        public int CutCopyMaskFormat
        {
            get { return (int)Base_obj.CutCopyMaskFormat; }
            set { Base_obj.CutCopyMaskFormat = value; }
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

        [ContextProperty("Маска", "Mask")]
        public string Mask
        {
            get { return Base_obj.Mask; }
            set { Base_obj.Mask = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }

        [ContextProperty("Модифицированность", "Modified")]
        public bool Modified
        {
            get { return Base_obj.Modified; }
            set { Base_obj.Modified = value; }
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

        [ContextProperty("НачалоВыделения", "SelectionStart")]
        public int SelectionStart
        {
            get { return Base_obj.SelectionStart; }
            set { Base_obj.SelectionStart = value; }
        }

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
            get { return Base_obj.Bottom; }
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

        [ContextProperty("ПредпочтительнаяВысота", "PreferredHeight")]
        public int PreferredHeight
        {
            get { return Base_obj.PreferredHeight; }
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

        [ContextProperty("ПропускЛитералов", "SkipLiterals")]
        public bool SkipLiterals
        {
            get { return Base_obj.SkipLiterals; }
            set { Base_obj.SkipLiterals = value; }
        }

        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
            set { Base_obj.Size = value.Base_obj; }
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

        [ContextProperty("РежимВставки", "InsertKeyMode")]
        public int InsertKeyMode
        {
            get { return (int)Base_obj.InsertKeyMode; }
            set { Base_obj.InsertKeyMode = value; }
        }

        [ContextProperty("РежимПерезаписи", "IsOverwriteMode")]
        public bool IsOverwriteMode
        {
            get { return Base_obj.IsOverwriteMode; }
        }

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }

        [ContextProperty("СбросНаПробел", "ResetOnSpace")]
        public bool ResetOnSpace
        {
            get { return Base_obj.ResetOnSpace; }
            set { Base_obj.ResetOnSpace = value; }
        }

        [ContextProperty("СбросНаСимволПриглашения", "ResetOnPrompt")]
        public bool ResetOnPrompt
        {
            get { return Base_obj.ResetOnPrompt; }
            set { Base_obj.ResetOnPrompt = value; }
        }

        [ContextProperty("СигналОтклоненного", "BeepOnError")]
        public bool BeepOnError
        {
            get { return Base_obj.BeepOnError; }
            set { Base_obj.BeepOnError = value; }
        }

        [ContextProperty("СимволПароля", "PasswordChar")]
        public string PasswordChar
        {
            get { return Base_obj.PasswordChar; }
            set { Base_obj.PasswordChar = value; }
        }

        [ContextProperty("СимволПриглашения", "PromptChar")]
        public string PromptChar
        {
            get { return Base_obj.PromptChar; }
            set { Base_obj.PromptChar = value; }
        }

        [ContextProperty("СкрыватьМаскуПриУходе", "HidePromptOnLeave")]
        public bool HidePromptOnLeave
        {
            get { return Base_obj.HidePromptOnLeave; }
            set { Base_obj.HidePromptOnLeave = value; }
        }

        [ContextProperty("СкрытьВыделение", "HideSelection")]
        public bool HideSelection
        {
            get { return Base_obj.HideSelection; }
            set { Base_obj.HideSelection = value; }
        }

        [ContextProperty("СтильГраницы", "BorderStyle")]
        public int BorderStyle
        {
            get { return (int)Base_obj.BorderStyle; }
            set { Base_obj.BorderStyle = value; }
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

        [ContextProperty("ТолькоASCII", "AsciiOnly")]
        public bool AsciiOnly
        {
            get { return Base_obj.AsciiOnly; }
            set { Base_obj.AsciiOnly = value; }
        }

        [ContextProperty("ТолькоЧтение", "ReadOnly")]
        public bool ReadOnly
        {
            get { return Base_obj.ReadOnly; }
            set { Base_obj.ReadOnly = value; }
        }

        [ContextProperty("Фокусируемый", "CanFocus")]
        public bool CanFocus
        {
            get { return Base_obj.CanFocus; }
        }

        [ContextProperty("ФорматМаски", "TextMaskFormat")]
        public int TextMaskFormat
        {
            get { return (int)Base_obj.TextMaskFormat; }
            set { Base_obj.TextMaskFormat = value; }
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

        [ContextMethod("Вставить", "Paste")]
        public void Paste()
        {
            Base_obj.Paste();
        }

        [ContextMethod("Выбрать", "Select")]
        public void Select()
        {
            Base_obj.Select();
        }

        [ContextMethod("ВыбратьВсе", "SelectAll")]
        public void SelectAll()
        {
            Base_obj.SelectAll();
        }

        [ContextMethod("ВыполнитьРазмещение", "PerformLayout")]
        public void PerformLayout()
        {
            Base_obj.PerformLayout();
        }

        [ContextMethod("Вырезать", "Cut")]
        public void Cut()
        {
            Base_obj.Cut();
        }

        [ContextMethod("Выше", "PlaceTop")]
        public void PlaceTop(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left, p3.Top - Base_obj.Height - p2);
        }

        [ContextMethod("ДобавитьТекст", "AppendText")]
        public void AppendText(string p1)
        {
            Base_obj.AppendText(p1);
        }

        [ContextMethod("ДочернийПоКоординатам", "GetChildAtPoint")]
        public IValue GetChildAtPoint(ClPoint p1)
        {
            return ((dynamic)Base_obj.GetChildAtPoint(p1.Base_obj)).dll_obj;
        }

        [ContextMethod("Копировать", "Copy")]
        public void Copy()
        {
            Base_obj.Copy();
        }

        [ContextMethod("Левее", "PlaceLeft")]
        public void PlaceLeft(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left - Base_obj.Width - p2, p3.Top);
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

        [ContextMethod("НаПереднийПлан", "BringToFront")]
        public void BringToFront()
        {
            Base_obj.BringToFront();
        }

        [ContextMethod("Ниже", "PlaceBottom")]
        public void PlaceBottom(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left, p3.Top + p3.Height + p2);
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

        [ContextMethod("Показать", "Show")]
        public void Show()
        {
            Base_obj.Show();
        }

        [ContextMethod("ПолучитьСтиль", "GetStyle")]
        public bool GetStyle(int p1)
        {
            return Base_obj.GetStyle((System.Windows.Forms.ControlStyles)p1);
        }

        [ContextMethod("Правее", "PlaceRight")]
        public void PlaceRight(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Right + p2, p3.Top);
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
