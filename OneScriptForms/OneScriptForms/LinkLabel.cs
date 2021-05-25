using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class LinkLabelEx : System.Windows.Forms.LinkLabel
    {
        public osf.LinkLabel M_Object;
    }

    public class LinkLabel : Label
    {
        public new ClLinkLabel dll_obj;
        private osf.Bitmap image;
        public string LinkClicked;
        public LinkLabelEx M_LinkLabel;

        public LinkLabel()
        {
            M_LinkLabel = new LinkLabelEx();
            M_LinkLabel.M_Object = this;
            base.M_Control = M_LinkLabel;
            M_LinkLabel.LinkClicked += M_LinkLabel_LinkClicked;
            LinkClicked = "";
        }

        public LinkLabel(System.Windows.Forms.LinkLabel p1)
        {
            M_LinkLabel = (LinkLabelEx)p1;
            M_LinkLabel.M_Object = this;
            base.M_Control = M_LinkLabel;
            M_LinkLabel.LinkClicked += M_LinkLabel_LinkClicked;
            LinkClicked = "";
        }

        public LinkLabel(osf.LinkLabel p1)
        {
            M_LinkLabel = p1.M_LinkLabel;
            M_LinkLabel.M_Object = this;
            base.M_Control = M_LinkLabel;
            M_LinkLabel.LinkClicked += M_LinkLabel_LinkClicked;
            LinkClicked = "";
        }

        //Свойства============================================================

        public osf.Color ActiveLinkColor
        {
            get { return new Color(M_LinkLabel.ActiveLinkColor); }
            set { M_LinkLabel.ActiveLinkColor = value.M_Color; }
        }

        public new bool AutoSize
        {
            get { return M_LinkLabel.AutoSize; }
            set
            {
                M_LinkLabel.AutoSize = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public new int ImageAlign
        {
            get { return (int)M_LinkLabel.ImageAlign; }
            set
            {
                M_LinkLabel.ImageAlign = (System.Drawing.ContentAlignment)value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public new int TextAlign
        {
            get { return (int)M_LinkLabel.TextAlign; }
            set
            {
                M_LinkLabel.TextAlign = (System.Drawing.ContentAlignment)value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public new int ImageIndex
        {
            get { return M_LinkLabel.ImageIndex; }
            set
            {
                M_LinkLabel.ImageIndex = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public new int PreferredHeight
        {
            get { return M_LinkLabel.PreferredHeight; }
        }

        public new int PreferredWidth
        {
            get { return M_LinkLabel.PreferredWidth; }
        }

        public new int BorderStyle
        {
            get { return (int)M_LinkLabel.BorderStyle; }
            set
            {
                M_LinkLabel.BorderStyle = (System.Windows.Forms.BorderStyle)value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.LinkArea LinkArea
        {
            get { return new LinkArea(M_LinkLabel.LinkArea); }
            set { M_LinkLabel.LinkArea = value.M_LinkArea; }
        }

        public int LinkBehavior
        {
            get { return (int)M_LinkLabel.LinkBehavior; }
            set { M_LinkLabel.LinkBehavior = (System.Windows.Forms.LinkBehavior)value; }
        }

        public osf.Color LinkColor
        {
            get { return new Color(M_LinkLabel.LinkColor); }
            set { M_LinkLabel.LinkColor = value.M_Color; }
        }

        public osf.LinkCollection Links
        {
            get { return new LinkCollection(M_LinkLabel.Links); }
        }

        public bool LinkVisited
        {
            get { return M_LinkLabel.LinkVisited; }
            set { M_LinkLabel.LinkVisited = value; }
        }

        public new osf.Bitmap Image
        {
            get { return image; }
            set
            {
                image = value;
                M_LinkLabel.Image = value.M_Image;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public new osf.ImageList ImageList
        {
            get { return new ImageList(M_LinkLabel.ImageList); }
            set
            {
                M_LinkLabel.ImageList = value.M_ImageList;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Color VisitedLinkColor
        {
            get { return new Color(M_LinkLabel.VisitedLinkColor); }
            set { M_LinkLabel.VisitedLinkColor = value.M_Color; }
        }

        //Методы============================================================

        private void M_LinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            if (LinkClicked.Length > 0)
            {
                LinkLabelLinkClickedEventArgs LinkLabelLinkClickedEventArgs1 = new LinkLabelLinkClickedEventArgs();
                LinkLabelLinkClickedEventArgs1.EventString = LinkClicked;
                LinkLabelLinkClickedEventArgs1.Sender = (object)this;
                LinkLabelLinkClickedEventArgs1.Button = (int)e.Button;
                LinkLabelLinkClickedEventArgs1.Link = ((LinkEx)e.Link).M_Object;
                OneScriptForms.EventQueue.Add(LinkLabelLinkClickedEventArgs1);
                ClLinkLabelLinkClickedEventArgs ClLinkLabelLinkClickedEventArgs1 = new ClLinkLabelLinkClickedEventArgs(LinkLabelLinkClickedEventArgs1);
            }
        }

    }

    [ContextClass ("КлНадписьСсылка", "ClLinkLabel")]
    public class ClLinkLabel : AutoContext<ClLinkLabel>
    {
        private ClColor activeLinkColor;
        private ClColor backColor;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClColor foreColor;
        private ClColor linkColor;
        private ClLinkCollection links;
        private ClCollection tag = new ClCollection();
        private ClColor visitedLinkColor;

        public ClLinkLabel()
        {
            LinkLabel LinkLabel1 = new LinkLabel();
            LinkLabel1.dll_obj = this;
            Base_obj = LinkLabel1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            links = new ClLinkCollection(Base_obj.Links);
            activeLinkColor = new ClColor(Base_obj.ActiveLinkColor);
            visitedLinkColor = new ClColor(Base_obj.VisitedLinkColor);
            linkColor = new ClColor(Base_obj.LinkColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClLinkLabel(LinkLabel p1)
        {
            LinkLabel LinkLabel1 = p1;
            LinkLabel1.dll_obj = this;
            Base_obj = LinkLabel1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            links = new ClLinkCollection(Base_obj.Links);
            activeLinkColor = new ClColor(Base_obj.ActiveLinkColor);
            visitedLinkColor = new ClColor(Base_obj.VisitedLinkColor);
            linkColor = new ClColor(Base_obj.LinkColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
        
        public LinkLabel Base_obj;

        //Свойства============================================================

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

        [ContextProperty("ВыравниваниеИзображения", "ImageAlign")]
        public int ImageAlign
        {
            get { return (int)Base_obj.ImageAlign; }
            set { Base_obj.ImageAlign = value; }
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
        public string DoubleClick
        {
            get { return Base_obj.DoubleClick; }
            set { Base_obj.DoubleClick = value; }
        }

        [ContextProperty("Доступность", "Enabled")]
        public bool Enabled
        {
            get { return Base_obj.Enabled; }
            set { Base_obj.Enabled = value; }
        }

        [ContextProperty("Захват", "Capture")]
        public bool Capture
        {
            get { return Base_obj.Capture; }
            set { Base_obj.Capture = value; }
        }

        [ContextProperty("Изображение", "Image")]
        public ClBitmap Image
        {
            get { return (ClBitmap)OneScriptForms.RevertObj(Base_obj.Image); }
            set
            {
                Base_obj.Image = value.Base_obj;
                Base_obj.Image.dll_obj = value;
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
        
        [ContextProperty("ИндексИзображения", "ImageIndex")]
        public int ImageIndex
        {
            get { return Base_obj.ImageIndex; }
            set { Base_obj.ImageIndex = value; }
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

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
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

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
            get { return Base_obj.Bottom; }
        }

        [ContextProperty("ОбластьСсылки", "LinkArea")]
        public ClLinkArea LinkArea
        {
            get { return (ClLinkArea)OneScriptForms.RevertObj(Base_obj.LinkArea); }
            set { Base_obj.LinkArea = value.Base_obj; }
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

        [ContextProperty("ПоведениеСсылки", "LinkBehavior")]
        public int LinkBehavior
        {
            get { return (int)Base_obj.LinkBehavior; }
            set { Base_obj.LinkBehavior = value; }
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

        [ContextProperty("ПредпочтительнаяШирина", "PreferredWidth")]
        public int PreferredWidth
        {
            get { return Base_obj.PreferredWidth; }
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

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }
        
        [ContextProperty("СписокИзображений", "ImageList")]
        public ClImageList ImageList
        {
            get { return (ClImageList)OneScriptForms.RevertObj(Base_obj.ImageList); }
            set { Base_obj.ImageList = value.Base_obj; }
        }

        [ContextProperty("СсылкаНажата", "LinkClicked")]
        public string LinkClicked
        {
            get { return Base_obj.LinkClicked; }
            set { Base_obj.LinkClicked = value; }
        }

        [ContextProperty("СсылкаПосещена", "LinkVisited")]
        public bool LinkVisited
        {
            get { return Base_obj.LinkVisited; }
            set { Base_obj.LinkVisited = value; }
        }

        [ContextProperty("Ссылки", "Links")]
        public ClLinkCollection Links
        {
            get { return links; }
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

        [ContextProperty("ЦветАктивнойСсылки", "ActiveLinkColor")]
        public ClColor ActiveLinkColor
        {
            get { return activeLinkColor; }
            set 
            {
                activeLinkColor = value;
                Base_obj.ActiveLinkColor = value.Base_obj;
            }
        }

        [ContextProperty("ЦветПосещеннойСсылки", "VisitedLinkColor")]
        public ClColor VisitedLinkColor
        {
            get { return visitedLinkColor; }
            set 
            {
                visitedLinkColor = value;
                Base_obj.VisitedLinkColor = value.Base_obj;
            }
        }

        [ContextProperty("ЦветСсылки", "LinkColor")]
        public ClColor LinkColor
        {
            get { return linkColor; }
            set 
            {
                linkColor = value;
                Base_obj.LinkColor = value.Base_obj;
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
					
        [ContextMethod("ВозобновитьРазмещение", "ResumeLayout")]
        public void ResumeLayout(bool p1 = false)
        {
            Base_obj.ResumeLayout(p1);
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
					
        [ContextMethod("Выше", "PlaceTop")]
        public void PlaceTop(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left, p3.Top - Base_obj.Height - p2);
        }
        
        [ContextMethod("ДочернийПоКоординатам", "GetChildAtPoint")]
        public IValue GetChildAtPoint(ClPoint p1)
        {
            return ((dynamic)Base_obj.GetChildAtPoint(p1.Base_obj)).dll_obj;
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
					
        [ContextMethod("Показать", "Show")]
        public void Show()
        {
            Base_obj.Show();
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
					
        [ContextMethod("Ссылки", "Links")]
        public ClLink Links2(int p1)
        {
            return (ClLink)OneScriptForms.RevertObj(Base_obj.Links[p1]);
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
					
        [ContextMethod("ЭлементыУправления", "Controls")]
        public IValue Controls2(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.Controls2(p1));
        }
    }
}
