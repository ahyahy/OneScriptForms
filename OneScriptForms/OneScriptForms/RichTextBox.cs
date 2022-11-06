using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;
using System.Runtime.InteropServices;

namespace osf
{
    public class RichTextBoxEx : System.Windows.Forms.RichTextBox
    {
        public osf.RichTextBox M_Object;
    }

    public class RichTextBox : TextBoxBase
    {
        public ClRichTextBox dll_obj;
        public string LinkClicked;
        private RichTextBoxEx m_RichTextBox;
        public string SelectionChanged;

        public RichTextBox()
        {
            M_RichTextBox = new RichTextBoxEx();
            M_RichTextBox.M_Object = this;
            base.M_TextBoxBase = M_RichTextBox;
            LinkClicked = "";
            SelectionChanged = "";
        }

        public RichTextBox(osf.RichTextBox p1)
        {
            M_RichTextBox = p1.M_RichTextBox;
            M_RichTextBox.M_Object = this;
            base.M_TextBoxBase = M_RichTextBox;
            LinkClicked = "";
            SelectionChanged = "";
        }

        public RichTextBox(System.Windows.Forms.RichTextBox p1)
        {
            M_RichTextBox = (RichTextBoxEx)p1;
            M_RichTextBox.M_Object = this;
            base.M_TextBoxBase = M_RichTextBox;
            LinkClicked = "";
            SelectionChanged = "";
        }

        public bool AutoWordSelection
        {
            get { return M_RichTextBox.AutoWordSelection; }
            set { M_RichTextBox.AutoWordSelection = value; }
        }

        public int BulletIndent
        {
            get { return M_RichTextBox.BulletIndent; }
            set { M_RichTextBox.BulletIndent = value; }
        }

        public bool CanRedo
        {
            get { return M_RichTextBox.CanRedo; }
        }

        public bool DetectUrls
        {
            get { return M_RichTextBox.DetectUrls; }
            set { M_RichTextBox.DetectUrls = value; }
        }

        public RichTextBoxEx M_RichTextBox
        {
            get { return m_RichTextBox; }
            set
            {
                m_RichTextBox = value;
                m_RichTextBox.SelectionChanged += M_RichTextBox_SelectionChanged;
                m_RichTextBox.LinkClicked += M_RichTextBox_LinkClicked;
            }
        }

        public int RightMargin
        {
            get { return M_RichTextBox.RightMargin; }
            set { M_RichTextBox.RightMargin = value; }
        }

        public string Rtf
        {
            get { return M_RichTextBox.Rtf; }
            set { M_RichTextBox.Rtf = value; }
        }

        public int ScrollBars
        {
            get { return (int)M_RichTextBox.ScrollBars; }
            set { M_RichTextBox.ScrollBars = (System.Windows.Forms.RichTextBoxScrollBars)value; }
        }

        public osf.Color SelectionBackColor
        {
            get { return new Color(M_RichTextBox.SelectionBackColor); }
            set { M_RichTextBox.SelectionBackColor = value.M_Color; }
        }

        public osf.Color SelectionColor
        {
            get { return new Color(M_RichTextBox.SelectionColor); }
            set { M_RichTextBox.SelectionColor = value.M_Color; }
        }

        public osf.Font SelectionFont
        {
            get { return new Font(M_RichTextBox.SelectionFont);            }
            set { M_RichTextBox.SelectionFont = (System.Drawing.Font)value.M_Font;            }
        }

        public int SelectionIndent
        {
            get { return M_RichTextBox.SelectionIndent; }
            set { M_RichTextBox.SelectionIndent = value; }
        }

        public int[] SelectionTabs
        {
            get { return M_RichTextBox.SelectionTabs; }
            set { M_RichTextBox.SelectionTabs = value; }
        }

        public float ZoomFactor
        {
            get { return M_RichTextBox.ZoomFactor; }
            set { M_RichTextBox.ZoomFactor = value; }
        }

        public bool CanPaste()
        {
            return M_RichTextBox.CanPaste(System.Windows.Forms.DataFormats.GetFormat(System.Windows.Forms.DataFormats.Text));
        }

        public int Find(string str, int start = 0, System.Windows.Forms.RichTextBoxFinds options = System.Windows.Forms.RichTextBoxFinds.None)
        {
            return M_RichTextBox.Find(str, start, (System.Windows.Forms.RichTextBoxFinds)options);
        }

        public int GetCharIndexFromPosition(osf.Point pt)
        {
            return M_RichTextBox.GetCharIndexFromPosition(pt.M_Point);
        }

        public int GetLineFromCharIndex(int index)
        {
            return M_RichTextBox.GetLineFromCharIndex(index);
        }

        public void LoadFile(string path, System.Windows.Forms.RichTextBoxStreamType fileType = System.Windows.Forms.RichTextBoxStreamType.RichText)
        {
            M_RichTextBox.LoadFile(path, (System.Windows.Forms.RichTextBoxStreamType)fileType);
        }

        public void M_RichTextBox_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            if (LinkClicked.Length > 0)
            {
                LinkClickedEventArgs LinkClickedEventArgs1 = new LinkClickedEventArgs();
                LinkClickedEventArgs1.EventString = LinkClicked;
                LinkClickedEventArgs1.Sender = this;
                LinkClickedEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.LinkClicked);
                LinkClickedEventArgs1.LinkText = e.LinkText;
                ClLinkClickedEventArgs ClLinkClickedEventArgs1 = new ClLinkClickedEventArgs(LinkClickedEventArgs1);
                OneScriptForms.Event = ClLinkClickedEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.LinkClicked);
            }
        }

        public void M_RichTextBox_SelectionChanged(object sender, System.EventArgs e)
        {
            if (SelectionChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = SelectionChanged;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.SelectionChanged);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.SelectionChanged);
            }
        }

        public void Redo()
        {
            M_RichTextBox.Redo();
            //System.Windows.Forms.Application.DoEvents();
        }

        public void SaveFile(string path, System.Windows.Forms.RichTextBoxStreamType fileType = System.Windows.Forms.RichTextBoxStreamType.RichText)
        {
            M_RichTextBox.SaveFile(path, (System.Windows.Forms.RichTextBoxStreamType)fileType);
        }
    }

    [ContextClass ("КлФорматированноеПолеВвода", "ClRichTextBox")]
    public class ClRichTextBox : AutoContext<ClRichTextBox>
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
        private IValue _LinkClicked;
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
        private IValue _SelectionChanged;
        private IValue _SizeChanged;
        private IValue _TextChanged;
        private ClColor backColor;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClCursor cursor;
        private ClFont font;
        private ClColor foreColor;
        private ClColor selectionColor;
        private ClFont selectionFont;
        private ClCollection tag = new ClCollection();

        public ClRichTextBox()
        {
            RichTextBox RichTextBox1 = new RichTextBox();
            RichTextBox1.dll_obj = this;
            Base_obj = RichTextBox1;
            ContextMenu = EnableContextMenu(this);
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            selectionColor = new ClColor(Base_obj.SelectionColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }

        public ClRichTextBox(RichTextBox p1)
        {
            RichTextBox RichTextBox1 = p1;
            RichTextBox1.dll_obj = this;
            Base_obj = RichTextBox1;
            ContextMenu = EnableContextMenu(this);
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            selectionColor = new ClColor(Base_obj.SelectionColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClContextMenu EnableContextMenu(ClRichTextBox rtb)
        {
            ClContextMenu cm = new ClContextMenu();
            ClMenuItem Undo = new ClMenuItem("Отменить");
            Undo.Base_obj.M_MenuItem.Click += (sender, e) => rtb.Undo();
            cm.MenuItems.Add(Undo);

            ClMenuItem Redo = new ClMenuItem("Вернуть");
            Redo.Base_obj.M_MenuItem.Click += (sender, e) => rtb.Redo();
            cm.MenuItems.Add(Redo);

            cm.MenuItems.Add(new ClMenuItem("-"));

            ClMenuItem Cut = new ClMenuItem("Вырезать");
            Cut.Base_obj.M_MenuItem.Click += (sender, e) => rtb.Cut();
            cm.MenuItems.Add(Cut);

            ClMenuItem Copy = new ClMenuItem("Копировать");
            Copy.Base_obj.M_MenuItem.Click += (sender, e) => rtb.Copy();
            cm.MenuItems.Add(Copy);

            ClMenuItem Paste = new ClMenuItem("Вставить");
            Paste.Base_obj.M_MenuItem.Click += (sender, e) => rtb.Paste();
            cm.MenuItems.Add(Paste);

            ClMenuItem Delete = new ClMenuItem("Удалить");
            Delete.Base_obj.M_MenuItem.Click += (sender, e) => rtb.SelectedText = "";
            cm.MenuItems.Add(Delete);

            cm.MenuItems.Add(new ClMenuItem("-"));

            ClMenuItem SelectAll = new ClMenuItem("Выбрать всё");
            SelectAll.Base_obj.M_MenuItem.Click += (sender, e) => rtb.SelectAll();
            cm.MenuItems.Add(SelectAll);

            cm.Base_obj.M_ContextMenu.Popup += (sender, e) =>
            {
                Undo.Enabled = !rtb.ReadOnly && rtb.CanUndo;
                Redo.Enabled = !rtb.ReadOnly && rtb.CanRedo;
                Cut.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                Copy.Enabled = rtb.SelectionLength > 0;
                Paste.Enabled = !rtb.ReadOnly && (new osf.ClClipboard()).ContainsData();
                Delete.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                SelectAll.Enabled = rtb.TextLength > 0 && rtb.SelectionLength < rtb.TextLength;
            };
            return cm;
        }

        public RichTextBox Base_obj;
        
        [ContextProperty("Rtf", "Rtf")]
        public string Rtf
        {
            get { return Base_obj.Rtf; }
            set { Base_obj.Rtf = value; }
        }

        [ContextProperty("АвтоВыборСлов", "AutoWordSelection")]
        public bool AutoWordSelection
        {
            get { return Base_obj.AutoWordSelection; }
            set { Base_obj.AutoWordSelection = value; }
        }

        [ContextProperty("АвтоРазмер", "AutoSize")]
        public bool AutoSize
        {
            get { return Base_obj.AutoSize; }
            set { Base_obj.AutoSize = value; }
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

        [ContextProperty("ВыделениеИзменено", "SelectionChanged")]
        public IValue SelectionChanged
        {
            get { return _SelectionChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _SelectionChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.SelectionChanged = "DelegateActionSelectionChanged";
                }
                else
                {
                    _SelectionChanged = value;
                    Base_obj.SelectionChanged = "osfActionSelectionChanged";
                }
            }
        }
        
        [ContextProperty("ВыделенныйТекст", "SelectedText")]
        public string SelectedText
        {
            get { return Base_obj.SelectedText; }
            set { Base_obj.SelectedText = value; }
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

        [ContextProperty("ЖирныйШрифт", "FontBold")]
        public bool FontBold
        {
            get { return Base_obj.FontBold; }
            set { Base_obj.FontBold = value; }
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

        [ContextProperty("МаксимальнаяДлина", "MaxLength")]
        public int MaxLength
        {
            get { return Base_obj.MaxLength; }
            set { Base_obj.MaxLength = value; }
        }

        [ContextProperty("Масштаб", "ZoomFactor")]
        public IValue ZoomFactor
        {
            get { return ValueFactory.Create(Convert.ToDecimal(Base_obj.ZoomFactor)); }
            set { Base_obj.ZoomFactor = Convert.ToSingle(value.AsNumber()); }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("МногострочныйРежим", "Multiline")]
        public bool Multiline
        {
            get { return Base_obj.Multiline; }
            set { Base_obj.Multiline = value; }
        }

        [ContextProperty("Модифицированность", "Modified")]
        public bool Modified
        {
            get { return Base_obj.Modified; }
            set { Base_obj.Modified = value; }
        }

        [ContextProperty("МожноВернуть", "CanRedo")]
        public bool CanRedo
        {
            get { return Base_obj.CanRedo; }
        }

        [ContextProperty("МожноОтменить", "CanUndo")]
        public bool CanUndo
        {
            get { return Base_obj.CanUndo; }
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

        [ContextProperty("ОбнаруживатьАдреса", "DetectUrls")]
        public bool DetectUrls
        {
            get { return Base_obj.DetectUrls; }
            set { Base_obj.DetectUrls = value; }
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

        [ContextProperty("ОтступВыделения", "SelectionIndent")]
        public int SelectionIndent
        {
            get { return Base_obj.SelectionIndent; }
            set { Base_obj.SelectionIndent = value; }
        }

        [ContextProperty("ОтступМаркера", "BulletIndent")]
        public int BulletIndent
        {
            get { return Base_obj.BulletIndent; }
            set { Base_obj.BulletIndent = value; }
        }

        [ContextProperty("Перенос", "WordWrap")]
        public bool WordWrap
        {
            get { return Base_obj.WordWrap; }
            set { Base_obj.WordWrap = value; }
        }

        [ContextProperty("ПозицияМыши", "MousePosition")]
        public ClPoint MousePosition
        {
            get { return new ClPoint(System.Windows.Forms.Control.MousePosition); }
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
        
        [ContextProperty("ПолосыПрокрутки", "ScrollBars")]
        public int ScrollBars
        {
            get { return (int)Base_obj.ScrollBars; }
            set { Base_obj.ScrollBars = value; }
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

        [ContextProperty("ПравоеОграничение", "RightMargin")]
        public int RightMargin
        {
            get { return Base_obj.RightMargin; }
            set { Base_obj.RightMargin = value; }
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
        
        [ContextProperty("ПринятиеТаб", "AcceptsTab")]
        public bool AcceptsTab
        {
            get { return Base_obj.AcceptsTab; }
            set { Base_obj.AcceptsTab = value; }
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
        
        [ContextProperty("РазмерШрифта", "FontSize")]
        public int FontSize
        {
            get { return Convert.ToInt32(Base_obj.FontSize); }
            set { Base_obj.FontSize = value; }
        }
        
        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }
        
        [ContextProperty("СкрытьВыделение", "HideSelection")]
        public bool HideSelection
        {
            get { return Base_obj.HideSelection; }
            set { Base_obj.HideSelection = value; }
        }

        [ContextProperty("СсылкаНажата", "LinkClicked")]
        public IValue LinkClicked
        {
            get { return _LinkClicked; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _LinkClicked = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.LinkClicked = "DelegateActionLinkClicked";
                }
                else
                {
                    _LinkClicked = value;
                    Base_obj.LinkClicked = "osfActionLinkClicked";
                }
            }
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
        
        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
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

        [ContextProperty("ФоновоеИзображение", "BackgroundImage")]
        public ClBitmap BackgroundImage
        {
            get { return new ClBitmap(Base_obj.BackgroundImage); }
            set { Base_obj.BackgroundImage = value.Base_obj; }
        }

        [ContextProperty("ЦветВыделения", "SelectionColor")]
        public ClColor SelectionColor
        {
            get { return selectionColor; }
            set 
            {
                selectionColor = value;
                Base_obj.SelectionColor = value.Base_obj;
            }
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
        
        [ContextProperty("ШрифтВыделения", "SelectionFont")]
        public ClFont SelectionFont
        {
            get
            {
                if (selectionFont != null)
                {
                    return selectionFont;
                }
                return new ClFont(Base_obj.SelectionFont);
            }
            set
            {
                selectionFont = value;
                Base_obj.SelectionFont = value.Base_obj;
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
					
        [ContextMethod("Вернуть", "Redo")]
        public void Redo()
        {
            Base_obj.Redo();
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
        
        [ContextMethod("ЗавершитьОбновление", "EndUpdate")]
        public void EndUpdate()
        {
            Base_obj.EndUpdate();
        }
					
        [ContextMethod("ЗагрузитьФайл", "LoadFile")]
        public void LoadFile(string p1, int p2)
        {
            Base_obj.LoadFile(p1, (System.Windows.Forms.RichTextBoxStreamType)p2);
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
        
        [ContextMethod("МожноВставить", "CanPaste")]
        public bool CanPaste()
        {
            return Base_obj.CanPaste();
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
					
        [ContextMethod("Отменить", "Undo")]
        public void Undo()
        {
            Base_obj.Undo();
        }
					
        [ContextMethod("Поиск", "Find")]
        public int Find(string p1, int p2, int p3)
        {
            return Base_obj.Find(p1, p2, (System.Windows.Forms.RichTextBoxFinds)p3);
        }

        [ContextMethod("Показать", "Show")]
        public void Show()
        {
            Base_obj.Show();
        }
					
        [ContextMethod("ПолучитьИндексСимвола", "GetCharIndexFromPosition")]
        public int GetCharIndexFromPosition(ClPoint p1)
        {
            return Base_obj.GetCharIndexFromPosition(p1.Base_obj);
        }

        [ContextMethod("ПолучитьНомерСтрокиПоИндексуСимвола", "GetLineFromCharIndex")]
        public int GetLineFromCharIndex(int p1)
        {
            return Base_obj.GetLineFromCharIndex(p1);
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
					
        [ContextMethod("ПрокрутитьДоКурсора", "ScrollToCaret")]
        public void ScrollToCaret()
        {
            Base_obj.ScrollToCaret();
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
					
        [ContextMethod("СохранитьФайл", "SaveFile")]
        public void SaveFile(string p1, int p2)
        {
            Base_obj.SaveFile(p1, (System.Windows.Forms.RichTextBoxStreamType)p2);
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
					
        [ContextMethod("Центр", "Center")]
        public void Center()
        {
            Base_obj.Center();
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
