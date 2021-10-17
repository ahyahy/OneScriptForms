using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class NotifyIcon : Component
    {
        public string Click;
        public ClNotifyIcon dll_obj;
        public string DoubleClick;
        private System.Windows.Forms.NotifyIcon m_NotifyIcon;
        public string MouseDown;
        public string MouseMove;
        public string MouseUp;

        public NotifyIcon()
        {
            M_NotifyIcon = new System.Windows.Forms.NotifyIcon();
            Click = "";
            DoubleClick = "";
            MouseDown = "";
            MouseMove = "";
            MouseUp = "";
            OneScriptForms.AddToHashtable(M_NotifyIcon, this);
        }

        public NotifyIcon(osf.NotifyIcon p1)
        {
            M_NotifyIcon = p1.M_NotifyIcon;
            Click = "";
            DoubleClick = "";
            MouseDown = "";
            MouseMove = "";
            MouseUp = "";
            OneScriptForms.AddToHashtable(M_NotifyIcon, this);
        }

        public NotifyIcon(System.Windows.Forms.NotifyIcon p1)
        {
            M_NotifyIcon = p1;
            Click = "";
            DoubleClick = "";
            MouseDown = "";
            MouseMove = "";
            MouseUp = "";
            OneScriptForms.AddToHashtable(M_NotifyIcon, this);
        }

        //Свойства============================================================

        public osf.MenuNotifyIcon ContextMenu
        {
            get { return new MenuNotifyIcon(M_NotifyIcon.ContextMenu); }
            set { M_NotifyIcon.ContextMenu = value.M_MenuNotifyIcon; }
        }

        public osf.Icon Icon
        {
            get { return new Icon(M_NotifyIcon.Icon); }
            set
            {
                M_NotifyIcon.Icon = (System.Drawing.Icon)value.M_Icon;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public System.Windows.Forms.NotifyIcon M_NotifyIcon
        {
            get { return m_NotifyIcon; }
            set
            {
                m_NotifyIcon = value;
                base.M_Component = m_NotifyIcon;
                m_NotifyIcon.DoubleClick += M_NotifyIcon_DoubleClick;
                m_NotifyIcon.Click += M_NotifyIcon_Click;
                m_NotifyIcon.MouseMove += M_NotifyIcon_MouseMove;
                m_NotifyIcon.MouseUp += M_NotifyIcon_MouseUp;
                m_NotifyIcon.MouseDown += M_NotifyIcon_MouseDown;
            }
        }

        public string Text
        {
            get { return M_NotifyIcon.Text; }
            set
            {
                M_NotifyIcon.Text = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool Visible
        {
            get { return M_NotifyIcon.Visible; }
            set
            {
                M_NotifyIcon.Visible = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        //Методы============================================================

        public void M_NotifyIcon_Click(object sender, System.EventArgs e)
        {
            if (Click.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Click;
                EventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.Click;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    EventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    EventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    EventArgs1.Parameter = null;
                }
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        public void M_NotifyIcon_DoubleClick(object sender, System.EventArgs e)
        {
            if (DoubleClick.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = DoubleClick;
                EventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.DoubleClick;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    EventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    EventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    EventArgs1.Parameter = null;
                }
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        public void M_NotifyIcon_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseDown.Length > 0)
            {
                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
                MouseEventArgs1.EventString = MouseDown;
                MouseEventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.MouseDown;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    MouseEventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    MouseEventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    MouseEventArgs1.Parameter = null;
                }
                MouseEventArgs1.Clicks = e.Clicks;
                MouseEventArgs1.Button = (int)e.Button;
                MouseEventArgs1.X = e.X;
                MouseEventArgs1.Y = e.Y;
                OneScriptForms.EventQueue.Add(MouseEventArgs1);
                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
            }
        }

        public void M_NotifyIcon_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseMove.Length > 0)
            {
                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
                MouseEventArgs1.EventString = MouseMove;
                MouseEventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.MouseMove;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    MouseEventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    MouseEventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    MouseEventArgs1.Parameter = null;
                }
                MouseEventArgs1.Clicks = e.Clicks;
                MouseEventArgs1.Button = (int)e.Button;
                MouseEventArgs1.X = e.X;
                MouseEventArgs1.Y = e.Y;
                OneScriptForms.EventQueue.Add(MouseEventArgs1);
                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
            }
        }

        public void M_NotifyIcon_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseUp.Length > 0)
            {
                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
                MouseEventArgs1.EventString = MouseUp;
                MouseEventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.MouseUp;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    MouseEventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    MouseEventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    MouseEventArgs1.Parameter = null;
                }
                MouseEventArgs1.Clicks = e.Clicks;
                MouseEventArgs1.Button = (int)e.Button;
                MouseEventArgs1.X = e.X;
                MouseEventArgs1.Y = e.Y;
                OneScriptForms.EventQueue.Add(MouseEventArgs1);
                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
            }
        }

    }

    [ContextClass ("КлЗначокУведомления", "ClNotifyIcon")]
    public class ClNotifyIcon : AutoContext<ClNotifyIcon>
    {
        private IValue _Click;
        private IValue _DoubleClick;
        private IValue _MouseDown;
        private IValue _MouseMove;
        private IValue _MouseUp;
        private ClMenuNotifyIcon menu;
        private ClUserControl userControl1 = new ClUserControl();

        public ClNotifyIcon(ref ClMenuNotifyIcon p1)
        {
            NotifyIcon NotifyIcon1 = new NotifyIcon();
            NotifyIcon1.dll_obj = this;
            Base_obj = NotifyIcon1;
            menu = p1;
            p1.NotifyIcon = this;
            NotifyIcon1.ContextMenu = p1.Base_obj;
            userControl1.Size = new ClSize(0, 0);
            userControl1.Parent = OneScriptForms.FirstForm;
            userControl1.Value = this;
            p1.Show(userControl1, new ClPoint(5, 5));
        }

        public NotifyIcon Base_obj;

        //Свойства============================================================

        [ContextProperty("ДвойноеНажатие", "DoubleClick")]
        public IValue DoubleClick
        {
            get
            {
                if (Base_obj.DoubleClick.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _DoubleClick;
                }
                else if (Base_obj.DoubleClick.Contains("osf.ClDictionaryEntry"))
                {
                    return _DoubleClick;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.DoubleClick);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _DoubleClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.DoubleClick = "ScriptEngine.HostedScript.Library.DelegateAction" + "DoubleClick";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _DoubleClick = value;
                    Base_obj.DoubleClick = "osf.ClDictionaryEntry" + "DoubleClick";
                }
                else
                {
                    Base_obj.DoubleClick = value.AsString();
                }
            }
        }
        
        [ContextProperty("Значок", "Icon")]
        public ClIcon Icon
        {
            get { return (ClIcon)OneScriptForms.RevertObj(Base_obj.Icon); }
            set 
            {
                Base_obj.Icon = value.Base_obj; 
                Base_obj.Icon.dll_obj = value;
            }
        }

        [ContextProperty("Меню", "Menu")]
        public ClMenuNotifyIcon Menu
        {
            get { return menu; }
        }
        
        [ContextProperty("Нажатие", "Click")]
        public IValue Click
        {
            get
            {
                if (Base_obj.Click.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Click;
                }
                else if (Base_obj.Click.Contains("osf.ClDictionaryEntry"))
                {
                    return _Click;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Click);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Click = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Click = "ScriptEngine.HostedScript.Library.DelegateAction" + "Click";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Click = value;
                    Base_obj.Click = "osf.ClDictionaryEntry" + "Click";
                }
                else
                {
                    Base_obj.Click = value.AsString();
                }
            }
        }
        
        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
        }

        [ContextProperty("ПриНажатииКнопкиМыши", "MouseDown")]
        public IValue MouseDown
        {
            get
            {
                if (Base_obj.MouseDown.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseDown;
                }
                else if (Base_obj.MouseDown.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseDown;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseDown);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseDown = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseDown = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseDown";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseDown = value;
                    Base_obj.MouseDown = "osf.ClDictionaryEntry" + "MouseDown";
                }
                else
                {
                    Base_obj.MouseDown = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриОтпусканииМыши", "MouseUp")]
        public IValue MouseUp
        {
            get
            {
                if (Base_obj.MouseUp.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseUp;
                }
                else if (Base_obj.MouseUp.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseUp;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseUp);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseUp = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseUp = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseUp";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseUp = value;
                    Base_obj.MouseUp = "osf.ClDictionaryEntry" + "MouseUp";
                }
                else
                {
                    Base_obj.MouseUp = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриПеремещенииМыши", "MouseMove")]
        public IValue MouseMove
        {
            get
            {
                if (Base_obj.MouseMove.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseMove;
                }
                else if (Base_obj.MouseMove.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseMove;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseMove);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseMove = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseMove = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseMove";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseMove = value;
                    Base_obj.MouseMove = "osf.ClDictionaryEntry" + "MouseMove";
                }
                else
                {
                    Base_obj.MouseMove = value.AsString();
                }
            }
        }
        
        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }

        //Методы============================================================

        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
    }
}
