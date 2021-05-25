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
        [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Auto, SetLastError = true)] private static extern new bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
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

        public RichTextBox(System.Windows.Forms.RichTextBox p1)
        {
            M_RichTextBox = (RichTextBoxEx)p1;
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

        //Свойства============================================================

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

        //Методы============================================================

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
                LinkClickedEventArgs1.LinkText = e.LinkText;
                OneScriptForms.EventQueue.Add(LinkClickedEventArgs1);
                ClLinkClickedEventArgs ClLinkClickedEventArgs1 = new ClLinkClickedEventArgs(LinkClickedEventArgs1);
            }
        }

        public void M_RichTextBox_SelectionChanged(object sender, System.EventArgs e)
        {
            if (SelectionChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = SelectionChanged;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        public void Redo()
        {
            M_RichTextBox.Redo();
            System.Windows.Forms.Application.DoEvents();
        }

        public void SaveFile(string path, System.Windows.Forms.RichTextBoxStreamType fileType = System.Windows.Forms.RichTextBoxStreamType.RichText)
        {
            M_RichTextBox.SaveFile(path, (System.Windows.Forms.RichTextBoxStreamType)fileType);
        }

        public override void BeginUpdate()
        {
            RichTextBox.SendMessage(M_RichTextBox.Handle, 11, 0, 0);
            System.Windows.Forms.Application.DoEvents();
        }

        public override void EndUpdate()
        {
            RichTextBox.SendMessage(M_RichTextBox.Handle, 11, -1, 0);
            M_RichTextBox.Invalidate();
            System.Windows.Forms.Application.DoEvents();
        }

    }

    [ContextClass ("КлФорматированноеПолеВвода", "ClRichTextBox")]
    public class ClRichTextBox : AutoContext<ClRichTextBox>
    {
        private ClColor backColor;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClColor foreColor;
        private ClColor selectionColor;
        private ClCollection tag = new ClCollection();

        public ClRichTextBox()
        {
            RichTextBox RichTextBox1 = new RichTextBox();
            RichTextBox1.dll_obj = this;
            Base_obj = RichTextBox1;
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
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            selectionColor = new ClColor(Base_obj.SelectionColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
        
        public RichTextBox Base_obj;

        //Свойства============================================================

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
        public string SelectionChanged
        {
            get { return Base_obj.SelectionChanged; }
            set { Base_obj.SelectionChanged = value; }
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
        public string DoubleClick
        {
            get { return Base_obj.DoubleClick; }
            set { Base_obj.DoubleClick = value; }
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
        public string KeyUp
        {
            get { return Base_obj.KeyUp; }
            set { Base_obj.KeyUp = value; }
        }

        [ContextProperty("КлавишаВниз", "KeyDown")]
        public string KeyDown
        {
            get { return Base_obj.KeyDown; }
            set { Base_obj.KeyDown = value; }
        }

        [ContextProperty("КлавишаНажата", "KeyPress")]
        public string KeyPress
        {
            get { return Base_obj.KeyPress; }
            set { Base_obj.KeyPress = value; }
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
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.Cursor); }
            set { Base_obj.Cursor = value.Base_obj; }
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
        
        [ContextProperty("МногострочныйРежим", "MultiLine")]
        public bool MultiLine
        {
            get { return Base_obj.MultiLine; }
            set { Base_obj.MultiLine = value; }
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
        public string MouseEnter
        {
            get { return Base_obj.MouseEnter; }
            set { Base_obj.MouseEnter = value; }
        }

        [ContextProperty("МышьПокинулаЭлемент", "MouseLeave")]
        public string MouseLeave
        {
            get { return Base_obj.MouseLeave; }
            set { Base_obj.MouseLeave = value; }
        }

        [ContextProperty("Нажатие", "Click")]
        public string Click
        {
            get { return Base_obj.Click; }
            set { Base_obj.Click = value; }
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
        public string LocationChanged
        {
            get { return Base_obj.LocationChanged; }
            set { Base_obj.LocationChanged = value; }
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
        public string Enter
        {
            get { return Base_obj.Enter; }
            set { Base_obj.Enter = value; }
        }

        [ContextProperty("ПриЗадержкеМыши", "MouseHover")]
        public string MouseHover
        {
            get { return Base_obj.MouseHover; }
            set { Base_obj.MouseHover = value; }
        }

        [ContextProperty("ПриНажатииКнопкиМыши", "MouseDown")]
        public string MouseDown
        {
            get { return Base_obj.MouseDown; }
            set { Base_obj.MouseDown = value; }
        }

        [ContextProperty("ПриОтпусканииМыши", "MouseUp")]
        public string MouseUp
        {
            get { return Base_obj.MouseUp; }
            set { Base_obj.MouseUp = value; }
        }

        [ContextProperty("ПриПеремещении", "Move")]
        public string Move
        {
            get { return Base_obj.Move; }
            set { Base_obj.Move = value; }
        }

        [ContextProperty("ПриПеремещенииМыши", "MouseMove")]
        public string MouseMove
        {
            get { return Base_obj.MouseMove; }
            set { Base_obj.MouseMove = value; }
        }

        [ContextProperty("ПриПерерисовке", "Paint")]
        public string Paint
        {
            get { return Base_obj.Paint; }
            set { Base_obj.Paint = value; }
        }

        [ContextProperty("ПриПотереФокуса", "LostFocus")]
        public string LostFocus
        {
            get { return Base_obj.LostFocus; }
            set { Base_obj.LostFocus = value; }
        }

        [ContextProperty("ПриУходе", "Leave")]
        public string Leave
        {
            get { return Base_obj.Leave; }
            set { Base_obj.Leave = value; }
        }

        [ContextProperty("ПринятиеТаб", "AcceptsTab")]
        public bool AcceptsTab
        {
            get { return Base_obj.AcceptsTab; }
            set { Base_obj.AcceptsTab = value; }
        }

        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
            set { Base_obj.Size = value.Base_obj; }
        }

        [ContextProperty("РазмерИзменен", "SizeChanged")]
        public string SizeChanged
        {
            get { return Base_obj.SizeChanged; }
            set { Base_obj.SizeChanged = value; }
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
        public string LinkClicked
        {
            get { return Base_obj.LinkClicked; }
            set { Base_obj.LinkClicked = value; }
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
        public string TextChanged
        {
            get { return Base_obj.TextChanged; }
            set { Base_obj.TextChanged = value; }
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
            get { return (ClFont)OneScriptForms.RevertObj(Base_obj.Font); }
            set 
            {
                Base_obj.Font = value.Base_obj; 
                Base_obj.Font.dll_obj = value;
            }
        }

        [ContextProperty("ШрифтВыделения", "SelectionFont")]
        public ClFont SelectionFont
        {
            get { return (ClFont)OneScriptForms.RevertObj(Base_obj.SelectionFont); }
            set 
            {
                Base_obj.SelectionFont = value.Base_obj; 
                Base_obj.SelectionFont.dll_obj = value;
            }
        }

        [ContextProperty("ЭлементВерхнегоУровня", "TopLevelControl")]
        public IValue TopLevelControl
        {
            get { return OneScriptForms.RevertObj(Base_obj.TopLevelControl); }
        }
        
        [ContextProperty("ЭлементДобавлен", "ControlAdded")]
        public string ControlAdded
        {
            get { return Base_obj.ControlAdded; }
            set { Base_obj.ControlAdded = value; }
        }

        [ContextProperty("ЭлементУдален", "ControlRemoved")]
        public string ControlRemoved
        {
            get { return Base_obj.ControlRemoved; }
            set { Base_obj.ControlRemoved = value; }
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

        //Методы============================================================

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
					
        [ContextMethod("НаПереднийПлан", "BringToFront")]
        public void BringToFront()
        {
            Base_obj.BringToFront();
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
