﻿using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class SplitterEx : System.Windows.Forms.Splitter
    {
        public osf.Splitter M_Object;
    }

    public class Splitter : Control
    {
        public ClSplitter dll_obj;
        public SplitterEx M_Splitter;

        public Splitter()
        {
            M_Splitter = new SplitterEx();
            M_Splitter.M_Object = this;
            base.M_Control = M_Splitter;
        }

        public Splitter(System.Windows.Forms.Splitter p1)
        {
            M_Splitter = (SplitterEx)p1;
            M_Splitter.M_Object = this;
            base.M_Control = M_Splitter;
        }

        public Splitter(osf.Splitter p1)
        {
            M_Splitter = p1.M_Splitter;
            M_Splitter.M_Object = this;
            base.M_Control = M_Splitter;
        }

        //Свойства============================================================

        public int MinExtra
        {
            get { return M_Splitter.MinExtra; }
            set { M_Splitter.MinExtra = value; }
        }

        public int MinSize
        {
            get { return M_Splitter.MinSize; }
            set { M_Splitter.MinSize = value; }
        }

        public int SplitPosition
        {
            get { return M_Splitter.SplitPosition; }
            set { M_Splitter.SplitPosition = value; }
        }

        //Методы============================================================

    }

    [ContextClass ("КлРазделитель", "ClSplitter")]
    public class ClSplitter : AutoContext<ClSplitter>
    {
        private ClColor backColor;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClColor foreColor;
        private ClCollection tag = new ClCollection();

        public ClSplitter()
        {
            Splitter Splitter1 = new Splitter();
            Splitter1.dll_obj = this;
            Base_obj = Splitter1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClSplitter(Splitter p1)
        {
            Splitter Splitter1 = p1;
            Splitter1.dll_obj = this;
            Base_obj = Splitter1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
        
        public Splitter Base_obj;

        //Свойства============================================================

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

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("МинимальноеРасстояние", "MinExtra")]
        public int MinExtra
        {
            get { return Base_obj.MinExtra; }
            set { Base_obj.MinExtra = value; }
        }

        [ContextProperty("МинимальныйРазмер", "MinSize")]
        public int MinSize
        {
            get { return Base_obj.MinSize; }
            set { Base_obj.MinSize = value; }
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

        [ContextProperty("ПозицияМыши", "MousePosition")]
        public ClPoint MousePosition
        {
            get { return new ClPoint(System.Windows.Forms.Control.MousePosition); }
        }
        
        [ContextProperty("ПозицияРазделителя", "SplitPosition")]
        public int SplitPosition
        {
            get { return Base_obj.SplitPosition; }
            set { Base_obj.SplitPosition = value; }
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
