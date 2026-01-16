using System;
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

        public int BalloonTipIcon
        {
            get { return (int)M_NotifyIcon.BalloonTipIcon; }
            set { M_NotifyIcon.BalloonTipIcon = (System.Windows.Forms.ToolTipIcon)value; }
        }

        public string BalloonTipText
        {
            get { return M_NotifyIcon.BalloonTipText; }
            set { M_NotifyIcon.BalloonTipText = value; }
        }

        public string BalloonTipTitle
        {
            get { return M_NotifyIcon.BalloonTipTitle; }
            set { M_NotifyIcon.BalloonTipTitle = value; }
        }

        public osf.ContextMenu ContextMenu
        {
            get { return new ContextMenu(M_NotifyIcon.ContextMenu); }
            set { M_NotifyIcon.ContextMenu = value.M_ContextMenu; }
        }

        public osf.Icon Icon
        {
            get { return new Icon(M_NotifyIcon.Icon); }
            set
            {
                M_NotifyIcon.Icon = (System.Drawing.Icon)value.M_Icon;
                //System.Windows.Forms.Application.DoEvents();
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
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool Visible
        {
            get { return M_NotifyIcon.Visible; }
            set
            {
                M_NotifyIcon.Visible = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public void M_NotifyIcon_Click(object sender, System.EventArgs e)
        {
            if (Click.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Click;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(dll_obj.Click);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(dll_obj.Click);
            }
        }

        public void M_NotifyIcon_DoubleClick(object sender, System.EventArgs e)
        {
            if (DoubleClick.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = DoubleClick;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(dll_obj.DoubleClick);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(dll_obj.DoubleClick);
            }
        }

        public void M_NotifyIcon_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseDown.Length > 0)
            {
                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
                MouseEventArgs1.EventString = MouseDown;
                MouseEventArgs1.Sender = this;
                MouseEventArgs1.Parameter = OneScriptForms.GetEventParameter(dll_obj.MouseDown);
                MouseEventArgs1.Clicks = e.Clicks;
                MouseEventArgs1.Button = (int)e.Button;
                MouseEventArgs1.X = e.X;
                MouseEventArgs1.Y = e.Y;
                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
                OneScriptForms.Event = ClMouseEventArgs1;
                OneScriptForms.ExecuteEvent(dll_obj.MouseDown);
            }
        }

        public void M_NotifyIcon_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseMove.Length > 0)
            {
                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
                MouseEventArgs1.EventString = MouseMove;
                MouseEventArgs1.Sender = this;
                MouseEventArgs1.Parameter = OneScriptForms.GetEventParameter(dll_obj.MouseMove);
                MouseEventArgs1.Clicks = e.Clicks;
                MouseEventArgs1.Button = (int)e.Button;
                MouseEventArgs1.X = e.X;
                MouseEventArgs1.Y = e.Y;
                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
                OneScriptForms.Event = ClMouseEventArgs1;
                OneScriptForms.ExecuteEvent(dll_obj.MouseMove);
            }
        }

        public void M_NotifyIcon_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseUp.Length > 0)
            {
                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
                MouseEventArgs1.EventString = MouseUp;
                MouseEventArgs1.Sender = this;
                MouseEventArgs1.Parameter = OneScriptForms.GetEventParameter(dll_obj.MouseUp);
                MouseEventArgs1.Clicks = e.Clicks;
                MouseEventArgs1.Button = (int)e.Button;
                MouseEventArgs1.X = e.X;
                MouseEventArgs1.Y = e.Y;
                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
                OneScriptForms.Event = ClMouseEventArgs1;
                OneScriptForms.ExecuteEvent(dll_obj.MouseUp);
            }
        }

        public void ShowBalloonTip(int p1, string p2, string p3, int p4)
        {
            M_NotifyIcon.ShowBalloonTip(p1, p2, p3, (System.Windows.Forms.ToolTipIcon)p4);
        }

        public void ShowBalloonTip(int p1)
        {
            M_NotifyIcon.ShowBalloonTip(p1);
        }
    }

    [ContextClass("КлЗначокУведомления", "ClNotifyIcon")]
    public class ClNotifyIcon : AutoContext<ClNotifyIcon>
    {
        private IValue _Click;
        private IValue _DoubleClick;
        private IValue _MouseDown;
        private IValue _MouseMove;
        private IValue _MouseUp;

        public ClNotifyIcon()
        {
            NotifyIcon NotifyIcon1 = new NotifyIcon();
            NotifyIcon1.dll_obj = this;
            Base_obj = NotifyIcon1;
        }

        public NotifyIcon Base_obj;

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

        [ContextProperty("ЗаголовокВсплывающейПодсказки", "BalloonTipTitle")]
        public string BalloonTipTitle
        {
            get { return Base_obj.BalloonTipTitle; }
            set { Base_obj.BalloonTipTitle = value; }
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

        [ContextProperty("ЗначокВсплывающейПодсказки", "BalloonTipIcon")]
        public int BalloonTipIcon
        {
            get { return (int)Base_obj.BalloonTipIcon; }
            set { Base_obj.BalloonTipIcon = value; }
        }

        [ContextProperty("КонтекстноеМеню", "ContextMenu")]
        public ClContextMenu ContextMenu
        {
            get { return (ClContextMenu)OneScriptForms.RevertObj(Base_obj.ContextMenu); }
            set { Base_obj.ContextMenu = value.Base_obj; }
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

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
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

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("ТекстВсплывающейПодсказки", "BalloonTipText")]
        public string BalloonTipText
        {
            get { return Base_obj.BalloonTipText; }
            set { Base_obj.BalloonTipText = value; }
        }

        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }

        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }

        [ContextMethod("ПоказатьВсплывающуюПодсказку", "ShowBalloonTip")]
        public void ShowBalloonTip(int p1, IValue p2 = null, IValue p3 = null, IValue p4 = null)
        {
            if (p2 != null && p3 != null && p4 != null)
            {
                Base_obj.ShowBalloonTip(p1, p2.AsString(), p3.AsString(), Convert.ToInt32(p4.AsNumber()));
            }
            else
            {
                Base_obj.ShowBalloonTip(p1);
            }
        }
    }
}
