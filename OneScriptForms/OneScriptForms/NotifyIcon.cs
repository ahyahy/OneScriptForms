using ScriptEngine.Machine.Contexts;

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
                EventArgs1.Sender = (object)this;
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
                EventArgs1.Sender = (object)this;
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
                MouseEventArgs1.Sender = (object)this;
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
                MouseEventArgs1.Sender = (object)this;
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
                MouseEventArgs1.Sender = (object)this;
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
        public string DoubleClick
        {
            get { return Base_obj.DoubleClick; }
            set { Base_obj.DoubleClick = value; }
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
        public string Click
        {
            get { return Base_obj.Click; }
            set { Base_obj.Click = value; }
        }

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
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

        [ContextProperty("ПриПеремещенииМыши", "MouseMove")]
        public string MouseMove
        {
            get { return Base_obj.MouseMove; }
            set { Base_obj.MouseMove = value; }
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
