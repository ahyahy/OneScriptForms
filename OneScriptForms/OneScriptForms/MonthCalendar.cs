using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class MonthCalendarEx : System.Windows.Forms.MonthCalendar
    {
        public osf.MonthCalendar M_Object;
    }

    public class MonthCalendar : Control
    {
        public ClMonthCalendar dll_obj;
        public string M_DateChanged;
        public string M_DateSelected;
        public MonthCalendarEx M_MonthCalendar;

        public MonthCalendar()
        {
            M_MonthCalendar = new MonthCalendarEx();
            M_MonthCalendar.M_Object = this;
            base.M_Control = M_MonthCalendar;
            M_MonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateChanged);
            M_MonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateSelected);
            M_DateChanged = "";
            M_DateSelected = "";
        }

        public MonthCalendar(osf.MonthCalendar p1)
        {
            M_MonthCalendar = p1.M_MonthCalendar;
            M_MonthCalendar.M_Object = this;
            base.M_Control = M_MonthCalendar;
            M_MonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateChanged);
            M_MonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateSelected);
            M_DateChanged = "";
            M_DateSelected = "";
        }

        public MonthCalendar(System.Windows.Forms.MonthCalendar p1)
        {
            M_MonthCalendar = (MonthCalendarEx)p1;
            M_MonthCalendar.M_Object = this;
            base.M_Control = M_MonthCalendar;
            M_MonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateChanged);
            M_MonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateSelected);
            M_DateChanged = "";
            M_DateSelected = "";
        }

        public System.DateTime[] AnnuallyBoldedDates
        {
            get { return M_MonthCalendar.AnnuallyBoldedDates; }
            set { M_MonthCalendar.AnnuallyBoldedDates = value; }
        }

        public System.DateTime[] BoldedDates
        {
            get { return M_MonthCalendar.BoldedDates; }
            set { M_MonthCalendar.BoldedDates = value; }
        }

        public string DateChanged
        {
            get { return M_DateChanged; }
            set { M_DateChanged = value; }
        }

        public string DateSelected
        {
            get { return M_DateSelected; }
            set { M_DateSelected = value; }
        }

        public int FirstDayOfWeek
        {
            get { return (int)M_MonthCalendar.FirstDayOfWeek; }
            set { M_MonthCalendar.FirstDayOfWeek = (System.Windows.Forms.Day)value; }
        }

        public System.DateTime MaxDate
        {
            get { return M_MonthCalendar.MaxDate; }
            set
            {
                M_MonthCalendar.MaxDate = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public int MaxSelectionCount
        {
            get { return M_MonthCalendar.MaxSelectionCount; }
            set { M_MonthCalendar.MaxSelectionCount = value; }
        }

        public System.DateTime MinDate
        {
            get { return M_MonthCalendar.MinDate; }
            set
            {
                M_MonthCalendar.MinDate = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public System.DateTime[] MonthlyBoldedDates
        {
            get { return M_MonthCalendar.MonthlyBoldedDates; }
            set { M_MonthCalendar.MonthlyBoldedDates = value; }
        }

        public osf.Size PreferredSize
        {
            get { return new Size(M_MonthCalendar.PreferredSize); }
        }

        public System.DateTime SelectionEnd
        {
            get { return M_MonthCalendar.SelectionEnd; }
            set
            {
                M_MonthCalendar.SelectionEnd = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.SelectionRange SelectionRange
        {
            get { return new SelectionRange(M_MonthCalendar.SelectionRange); }
            set { M_MonthCalendar.SelectionRange = value.M_SelectionRange; }
        }

        public System.DateTime SelectionStart
        {
            get { return M_MonthCalendar.SelectionStart; }
            set
            {
                M_MonthCalendar.SelectionStart = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool ShowToday
        {
            get { return M_MonthCalendar.ShowToday; }
            set { M_MonthCalendar.ShowToday = value; }
        }

        public bool ShowTodayCircle
        {
            get { return M_MonthCalendar.ShowTodayCircle; }
            set { M_MonthCalendar.ShowTodayCircle = value; }
        }

        public System.DateTime TodayDate
        {
            get { return M_MonthCalendar.TodayDate; }
            set { M_MonthCalendar.TodayDate = value; }
        }

        private void MonthCalendar_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            if (M_DateChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = M_DateChanged;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.DateChanged);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.DateChanged);
            }
        }

        private void MonthCalendar_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            if (M_DateSelected.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = M_DateSelected;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.DateSelected);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.DateSelected);
            }
        }
    }

    [ContextClass ("КлКалендарь", "ClMonthCalendar")]
    public class ClMonthCalendar : AutoContext<ClMonthCalendar>
    {
        private IValue _Click;
        private IValue _ControlAdded;
        private IValue _ControlRemoved;
        private IValue _DateChanged;
        private IValue _DateSelected;
        private IValue _DoubleClick;
        private IValue _Enter;
        private IValue _KeyDown;
        private IValue _KeyPress;
        private IValue _KeyUp;
        private IValue _Leave;
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
        private ClAnnuallyBoldedDates annuallyBoldedDates;
        private ClColor backColor;
        private ClBoldedDates boldedDates;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClCursor cursor;
        private ClFont font;
        private ClColor foreColor;
        private ClMonthlyBoldedDates monthlyBoldedDates;
        private ClCollection tag = new ClCollection();

        public ClMonthCalendar()
        {
            MonthCalendar MonthCalendar1 = new MonthCalendar();
            MonthCalendar1.dll_obj = this;
            Base_obj = MonthCalendar1;
            boldedDates = new ClBoldedDates();
            boldedDates.M_MonthCalendar = Base_obj;
            annuallyBoldedDates = new ClAnnuallyBoldedDates();
            annuallyBoldedDates.M_MonthCalendar = Base_obj;
            monthlyBoldedDates = new ClMonthlyBoldedDates();
            monthlyBoldedDates.M_MonthCalendar = Base_obj;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }

        public ClMonthCalendar(MonthCalendar p1)
        {
            MonthCalendar MonthCalendar1 = p1;
            MonthCalendar1.dll_obj = this;
            Base_obj = MonthCalendar1;
            boldedDates = new ClBoldedDates();
            boldedDates.M_MonthCalendar = Base_obj;
            annuallyBoldedDates = new ClAnnuallyBoldedDates();
            annuallyBoldedDates.M_MonthCalendar = Base_obj;
            monthlyBoldedDates = new ClMonthlyBoldedDates();
            monthlyBoldedDates.M_MonthCalendar = Base_obj;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }

        public MonthCalendar Base_obj;
        
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

        [ContextProperty("ВыделенныеДаты", "BoldedDates")]
        public ClBoldedDates BoldedDates
        {
            get { return boldedDates; }

        }
        
        [ContextProperty("ВыделенныйДиапазон", "SelectionRange")]
        public ClSelectionRange SelectionRange
        {
            get { return (ClSelectionRange)OneScriptForms.RevertObj(Base_obj.SelectionRange); }
            set { Base_obj.SelectionRange = value.Base_obj; }
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

        [ContextProperty("ДатаВыбрана", "DateSelected")]
        public IValue DateSelected
        {
            get { return _DateSelected; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _DateSelected = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.DateSelected = "DelegateActionDateSelected";
                }
                else
                {
                    _DateSelected = value;
                    Base_obj.DateSelected = "osfActionDateSelected";
                }
            }
        }
        
        [ContextProperty("ДатаИзменена", "DateChanged")]
        public IValue DateChanged
        {
            get { return _DateChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _DateChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.DateChanged = "DelegateActionDateChanged";
                }
                else
                {
                    _DateChanged = value;
                    Base_obj.DateChanged = "osfActionDateChanged";
                }
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

        [ContextProperty("ЕжегодныеДаты", "AnnuallyBoldedDates")]
        public ClAnnuallyBoldedDates AnnuallyBoldedDates
        {
            get { return annuallyBoldedDates; }
        }
        
        [ContextProperty("ЕжемесячныеДаты", "MonthlyBoldedDates")]
        public ClMonthlyBoldedDates MonthlyBoldedDates
        {
            get { return monthlyBoldedDates; }
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

        [ContextProperty("КонечнаяДата", "SelectionEnd")]
        public DateTime SelectionEnd
        {
            get { return Base_obj.SelectionEnd; }
            set { Base_obj.SelectionEnd = value; }
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

        [ContextProperty("МаксимальнаяДата", "MaxDate")]
        public DateTime MaxDate
        {
            get { return Base_obj.MaxDate; }
            set { Base_obj.MaxDate = value; }
        }

        [ContextProperty("МаксимумВыбранных", "MaxSelectionCount")]
        public int MaxSelectionCount
        {
            get { return Base_obj.MaxSelectionCount; }
            set { Base_obj.MaxSelectionCount = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("МинимальнаяДата", "MinDate")]
        public DateTime MinDate
        {
            get { return Base_obj.MinDate; }
            set { Base_obj.MinDate = value; }
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
        
        [ContextProperty("НачальнаяДата", "SelectionStart")]
        public DateTime SelectionStart
        {
            get { return Base_obj.SelectionStart; }
            set { Base_obj.SelectionStart = value; }
        }

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
            get { return Base_obj.Bottom; }
        }

        [ContextProperty("ОбвестиТекущуюДату", "ShowTodayCircle")]
        public bool ShowTodayCircle
        {
            get { return Base_obj.ShowTodayCircle; }
            set { Base_obj.ShowTodayCircle = value; }
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

        [ContextProperty("ПервыйДеньНедели", "FirstDayOfWeek")]
        public int FirstDayOfWeek
        {
            get { return (int)Base_obj.FirstDayOfWeek; }
            set { Base_obj.FirstDayOfWeek = value; }
        }

        [ContextProperty("ПозицияМыши", "MousePosition")]
        public ClPoint MousePosition
        {
            get { return new ClPoint(System.Windows.Forms.Control.MousePosition); }
        }
        
        [ContextProperty("ПоказатьТекущуюДату", "ShowToday")]
        public bool ShowToday
        {
            get { return Base_obj.ShowToday; }
            set { Base_obj.ShowToday = value; }
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

        [ContextProperty("ПредпочтительныйРазмер", "PreferredSize")]
        public ClSize PreferredSize
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.PreferredSize); }
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

        [ContextProperty("ТекущаяДата", "TodayDate")]
        public DateTime TodayDate
        {
            get { return Base_obj.TodayDate; }
            set { Base_obj.TodayDate = value; }
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
					
        [ContextMethod("ВыделенныеДаты", "BoldedDates")]
        public DateTime BoldedDates2(int p1)
        {
            return BoldedDates.Item(p1).AsDate();
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
        
        [ContextMethod("ЕжегодныеДаты", "AnnuallyBoldedDates")]
        public DateTime AnnuallyBoldedDates2(int p1)
        {
            return AnnuallyBoldedDates.Item(p1).AsDate();
        }

        [ContextMethod("ЕжемесячныеДаты", "MonthlyBoldedDates")]
        public DateTime MonthlyBoldedDates2(int p1)
        {
            return MonthlyBoldedDates.Item(p1).AsDate();
        }

        [ContextMethod("ЗавершитьОбновление", "EndUpdate")]
        public void EndUpdate()
        {
            Base_obj.EndUpdate();
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
