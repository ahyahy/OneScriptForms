using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace osf
{

    public class Control : Component
    {
        [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Auto, SetLastError = true)] public static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public string Click;
        public string ControlAdded;
        public string ControlRemoved;
        public string DoubleClick;
        public string Enter;
        public string KeyDown;
        public string KeyPress;
        public string KeyUp;
        public string Leave;
        public string LocationChanged;
        public string LostFocus;
        private System.Windows.Forms.Control m_Control;
        public string MouseDown;
        public string MouseEnter;
        public string MouseHover;
        public string MouseLeave;
        public string MouseMove;
        public string MouseUp;
        public string Move;
        public string Paint;
        public string SizeChanged;
        public string TextChanged;

        public Control(System.Windows.Forms.Control control = null)
        {
        }

        //Свойства============================================================

        public int Anchor
        {
            get { return (int)M_Control.Anchor; }
            set { M_Control.Anchor = (System.Windows.Forms.AnchorStyles)value; }
        }

        //Методы============================================================

        public osf.Color BackColor
        {
            get { return new Color(M_Control.BackColor); }
            set { M_Control.BackColor = value.M_Color; }
        }

        public osf.Bitmap BackgroundImage
        {
            get
            {
                if (M_Control.BackgroundImage != null)
                {
                    return new Bitmap(M_Control.BackgroundImage);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                M_Control.BackgroundImage = value.M_Image;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int Bottom
        {
            get { return M_Control.Bottom; }
        }

        public osf.Rectangle Bounds
        {
            get { return new Rectangle(M_Control.Bounds); }
            set { M_Control.Bounds = value.M_Rectangle; }
        }

        public bool CanFocus
        {
            get { return M_Control.CanFocus; }
        }

        public bool Capture
        {
            get { return M_Control.Capture; }
            set { M_Control.Capture = value; }
        }

        public int ClientHeight
        {
            get { return M_Control.ClientSize.Height; }
            set { M_Control.ClientSize = new System.Drawing.Size(M_Control.ClientSize.Width, value); }
        }

        public osf.Rectangle ClientRectangle
        {
            get { return new Rectangle(M_Control.ClientRectangle); }
        }

        public osf.Size ClientSize
        {
            get { return new Size(M_Control.ClientSize); }
            set { M_Control.ClientSize = value.M_Size; }
        }

        public int ClientWidth
        {
            get { return M_Control.ClientSize.Width; }
            set { M_Control.ClientSize = new System.Drawing.Size(value, M_Control.ClientSize.Height); }
        }

        public osf.ContextMenu ContextMenu
        {
            get
            {
                if (M_Control.ContextMenu != null)
                {
                    return (ContextMenu)((ContextMenuEx)M_Control.ContextMenu).M_Object;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                M_Control.ContextMenu = value.M_ContextMenu;
                ((ContextMenuEx)M_Control.ContextMenu).M_Object = value;
            }
        }

        public osf.ControlCollection Controls
        {
            get { return new ControlCollection(M_Control.Controls); }
        }

        public osf.Cursor Cursor
        {
            get { return new Cursor(M_Control.Cursor); }
            set { M_Control.Cursor = value.M_Cursor; }
        }

        public int Dock
        {
            get { return (int)M_Control.Dock; }
            set { M_Control.Dock = (System.Windows.Forms.DockStyle)value; }
        }

        public bool Enabled
        {
            get { return M_Control.Enabled; }
            set { M_Control.Enabled = value; }
        }

        public bool Focused
        {
            get { return M_Control.Focused; }
        }

        public osf.Font Font
        {
            get { return new Font(M_Control.Font); }
            set { M_Control.Font = value.M_Font; }
        }

        public bool FontBold
        {
            get
            {
                if (M_Control.Font.Bold)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                System.Drawing.Font Font1 = M_Control.Font;
                if (!value)
                {
                    M_Control.Font = new System.Drawing.Font(Font1.Name, Font1.Size, Font1.Style & System.Drawing.FontStyle.Bold);
                }
                else
                {
                    M_Control.Font = new System.Drawing.Font(Font1.Name, Font1.Size, Font1.Style | System.Drawing.FontStyle.Bold);
                }
            }
        }

        public int FontHeight
        {
            get { return Convert.ToInt32(M_Control.Font.Height); }
        }

        public string FontName
        {
            get { return M_Control.Font.Name; }
            set
            {
                System.Drawing.Font Font1 = M_Control.Font;
                M_Control.Font = new System.Drawing.Font(value, Font1.Size, Font1.Style);
            }
        }

        public int FontSize
        {
            get { return Convert.ToInt32(M_Control.Font.Size); }
            set
            {
                System.Drawing.Font Font1 = M_Control.Font;
                M_Control.Font = new System.Drawing.Font(Font1.Name, Convert.ToSingle(value), Font1.Style);
            }
        }

        public osf.Color ForeColor
        {
            get { return new Color(M_Control.ForeColor); }
            set { M_Control.ForeColor = value.M_Color; }
        }

        public osf.Control getControl(object p1)
        {
            System.Windows.Forms.Control.ControlCollection ControlCollection1 = M_Control.Controls;
            object[] array1 = new object[ControlCollection1.Count];
            ControlCollection1.CopyTo(array1, 0);
            try
            {
                return (osf.Control)((dynamic)ControlCollection1[(int)p1]).M_Object;
            }
            catch
            {
                return (osf.Control)((dynamic)array1.ElementAt((int)p1)).M_Object;
            }
        }

        public int Height
        {
            get { return M_Control.Height; }
            set { M_Control.Height = value; }
        }

        public int Left
        {
            get { return M_Control.Left; }
            set { M_Control.Left = value; }
        }

        public osf.Point Location
        {
            get { return new Point(M_Control.Location); }
            set { M_Control.Location = value.M_Point; }
        }

        public System.Windows.Forms.Control M_Control
        {
            get { return m_Control; }
            set
            {
                m_Control = value;
                base.M_Component = m_Control;
                m_Control.DoubleClick += m_Control_DoubleClick;
                DoubleClick = "";
                m_Control.KeyUp += m_Control_KeyUp;
                KeyUp = "";
                m_Control.KeyDown += m_Control_KeyDown;
                KeyDown = "";
                m_Control.KeyPress += m_Control_KeyPress;
                KeyPress = "";
                m_Control.MouseEnter += m_Control_MouseEnter;
                MouseEnter = "";
                m_Control.MouseLeave += m_Control_MouseLeave;
                MouseLeave = "";
                m_Control.Click += m_Control_Click;
                Click = "";
                m_Control.LocationChanged += m_Control_LocationChanged;
                LocationChanged = "";
                m_Control.Enter += m_Control_Enter;
                Enter = "";
                m_Control.MouseHover += m_Control_MouseHover;
                MouseHover = "";
                m_Control.MouseDown += m_Control_MouseDown;
                MouseDown = "";
                m_Control.MouseUp += m_Control_MouseUp;
                MouseUp = "";
                m_Control.Move += m_Control_Move;
                Move = "";
                m_Control.MouseMove += m_Control_MouseMove;
                MouseMove = "";
                m_Control.Paint += m_Control_Paint;
                Paint = "";
                m_Control.LostFocus += m_Control_LostFocus;
                LostFocus = "";
                m_Control.Leave += m_Control_Leave;
                Leave = "";
                m_Control.SizeChanged += m_Control_SizeChanged;
                SizeChanged = "";
                m_Control.TextChanged += m_Control_TextChanged;
                TextChanged = "";
                m_Control.ControlAdded += m_Control_ControlAdded;
                ControlAdded = "";
                m_Control.ControlRemoved += m_Control_ControlRemoved;
                ControlRemoved = "";
            }
        }

        public int MouseButtons
        {
            get
            {
                try
                {
                    return (int)((dynamic)OneScriptForms.Event).Button;
                }
                catch
                {
                    return (int)System.Windows.Forms.Control.MouseButtons;
                }
            }
        }

        public osf.Point MousePosition
        {
            get { return new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y); }
        }

        public string Name
        {
            get { return M_Control.Name; }
            set { M_Control.Name = value; }
        }

        public object Parent
        {
            get { return ((dynamic)M_Control.Parent).M_Object; }
            set { M_Control.Parent = ((dynamic)value).M_Control; }
        }

        public string ProductName
        {
            get { return ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title.ToString(); }
        }

        public string ProductVersion
        {
            get { return M_Control.ProductVersion; }
        }

        public void ResetBackgroundImage()
        {
            M_Control.BackgroundImage = null;
            System.Windows.Forms.Application.DoEvents();
        }

        public int Right
        {
            get { return M_Control.Right; }
        }

        public osf.Size Size
        {
            get { return new Size(M_Control.Size); }
            set { M_Control.Size = value.M_Size; }
        }

        public int TabIndex
        {
            get { return M_Control.TabIndex; }
            set { M_Control.TabIndex = value; }
        }

        public bool TabStop
        {
            get { return M_Control.TabStop; }
            set { M_Control.TabStop = value; }
        }

        public object Tag
        {
            get { return M_Control.Tag; }
            set { M_Control.Tag = value; }
        }

        public string Text
        {
            get { return Convert.ToString(M_Control.Text); }
            set { M_Control.Text = value; }
        }

        public int Top
        {
            get { return M_Control.Top; }
            set { M_Control.Top = value; }
        }

        public osf.Control TopLevelControl
        {
            get
            {
                if (M_Control.TopLevelControl != null)
                {
                    return ((osf.Control)((dynamic)M_Control.TopLevelControl).M_Object);
                }
                return null;
            }
        }

        public bool UseWaitCursor
        {
            get { return M_Control.UseWaitCursor; }
            set { M_Control.UseWaitCursor = value; }
        }

        public bool Visible
        {
            get { return M_Control.Visible; }
            set { M_Control.Visible = value; }
        }

        public int Width
        {
            get { return M_Control.Width; }
            set { M_Control.Width = value; }
        }

        //Методы============================================================

        public void BringToFront()
        {
            M_Control.BringToFront();
        }

        public osf.Control Controls2(int p1)
        {
            return Controls[p1];
        }

        public void CreateControl()
        {
            M_Control.CreateControl();
        }

        public osf.Graphics CreateGraphics()
        {
            return new Graphics(M_Control.CreateGraphics());
        }

        public dynamic FindControl(string p1)
        {
            foreach (dynamic item in M_Control.Controls)
            {
                if (item.Name == p1)
                {
                    return item;
                }
            }
            return null;
        }

        public osf.Form FindForm()
        {
            if ((FormEx)M_Control.FindForm() != null)
            {
                return (osf.Form)((FormEx)M_Control.FindForm()).M_Object;
            }
            return null;
        }

        public void Focus()
        {
            M_Control.Focus();
        }

        public osf.Control GetChildAtPoint(Point p1)
        {
            if (M_Control.GetChildAtPoint(p1.M_Point) != null)
            {
                return ((osf.Control)((dynamic)M_Control.GetChildAtPoint(p1.M_Point)).M_Object);
            }
            return null;
        }

        public osf.Control GetNextControl(Control p1, bool p2)
        {
            return (osf.Control)((dynamic)M_Control.GetNextControl(p1.M_Control, p2)).M_Object;
        }

        public void Hide()
        {
            M_Control.Hide();
        }

        public void Invalidate()
        {
            M_Control.Invalidate();
        }

        private void m_Control_Click(object sender, System.EventArgs e)
        {
            if (Click.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Click;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void m_Control_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            if (ControlAdded.Length > 0)
            {
                ControlEventArgs ControlEventArgs1 = new ControlEventArgs();
                ControlEventArgs1.EventString = ControlAdded;
                ControlEventArgs1.Sender = this;
                ControlEventArgs1.Control = e.Control;
                OneScriptForms.EventQueue.Add(ControlEventArgs1);
                ClControlEventArgs ClControlEventArgs1 = new ClControlEventArgs(ControlEventArgs1);
            }
        }

        private void m_Control_ControlRemoved(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            if (ControlRemoved.Length > 0)
            {
                ControlEventArgs ControlEventArgs1 = new ControlEventArgs();
                ControlEventArgs1.EventString = ControlRemoved;
                ControlEventArgs1.Sender = this;
                ControlEventArgs1.Control = e.Control;
                OneScriptForms.EventQueue.Add(ControlEventArgs1);
                ClControlEventArgs ClControlEventArgs1 = new ClControlEventArgs(ControlEventArgs1);
            }
        }

        //Свойства============================================================

        private void m_Control_DoubleClick(object sender, System.EventArgs e)
        {
            if (DoubleClick.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = DoubleClick;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void m_Control_Enter(object sender, System.EventArgs e)
        {
            if (Enter.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Enter;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void m_Control_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (KeyDown.Length > 0)
            {
                KeyEventArgs KeyEventArgs1 = new KeyEventArgs();
                KeyEventArgs1.EventString = KeyDown;
                KeyEventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(KeyEventArgs1);
                ClKeyEventArgs ClKeyEventArgs1 = new ClKeyEventArgs(KeyEventArgs1);
            }
        }

        private void m_Control_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (KeyPress.Length > 0)
            {
                KeyPressEventArgs KeyPressEventArgs1 = new KeyPressEventArgs();
                KeyPressEventArgs1.EventString = KeyPress;
                KeyPressEventArgs1.Sender = this;
                KeyPressEventArgs1.KeyChar = Convert.ToString(e.KeyChar);
                OneScriptForms.EventQueue.Add(KeyPressEventArgs1);
                ClKeyPressEventArgs ClKeyPressEventArgs1 = new ClKeyPressEventArgs(KeyPressEventArgs1);
            }
        }

        private void m_Control_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (KeyUp.Length > 0)
            {
                KeyEventArgs KeyEventArgs1 = new KeyEventArgs();
                KeyEventArgs1.EventString = KeyUp;
                KeyEventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(KeyEventArgs1);
                ClKeyEventArgs ClKeyEventArgs1 = new ClKeyEventArgs(KeyEventArgs1);
            }
        }

        private void m_Control_Leave(object sender, System.EventArgs e)
        {
            if (Leave.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Leave;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void m_Control_LocationChanged(object sender, System.EventArgs e)
        {
            if (LocationChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = LocationChanged;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void m_Control_LostFocus(object sender, System.EventArgs e)
        {
            if (LostFocus.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = LostFocus;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void m_Control_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseDown.Length > 0)
            {
                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
                MouseEventArgs1.EventString = MouseDown;
                MouseEventArgs1.Sender = this;
                MouseEventArgs1.Clicks = e.Clicks;
                MouseEventArgs1.Button = (int)e.Button;
                MouseEventArgs1.X = e.X;
                MouseEventArgs1.Y = e.Y;
                OneScriptForms.EventQueue.Add(MouseEventArgs1);
                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
            }
        }

        private void m_Control_MouseEnter(object sender, System.EventArgs e)
        {
            if (MouseEnter.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = MouseEnter;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void m_Control_MouseHover(object sender, System.EventArgs e)
        {
            if (MouseHover.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = MouseHover;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void m_Control_MouseLeave(object sender, System.EventArgs e)
        {
            if (MouseLeave.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = MouseLeave;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void m_Control_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseMove.Length > 0)
            {
                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
                MouseEventArgs1.EventString = MouseMove;
                MouseEventArgs1.Sender = this;
                MouseEventArgs1.Clicks = e.Clicks;
                MouseEventArgs1.Button = (int)e.Button;
                MouseEventArgs1.X = e.X;
                MouseEventArgs1.Y = e.Y;
                OneScriptForms.EventQueue.Add(MouseEventArgs1);
                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
            }
        }

        private void m_Control_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseUp.Length > 0)
            {
                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
                MouseEventArgs1.EventString = MouseUp;
                MouseEventArgs1.Sender = this;
                MouseEventArgs1.Clicks = e.Clicks;
                MouseEventArgs1.Button = (int)e.Button;
                MouseEventArgs1.X = e.X;
                MouseEventArgs1.Y = e.Y;
                OneScriptForms.EventQueue.Add(MouseEventArgs1);
                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
            }
        }

        private void m_Control_Move(object sender, System.EventArgs e)
        {
            if (Move.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Move;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void m_Control_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (Paint.Length > 0)
            {
                PaintEventArgs PaintEventArgs1 = new PaintEventArgs();
                PaintEventArgs1.EventString = Paint;
                PaintEventArgs1.Sender = this;
                PaintEventArgs1.Graphics = new Graphics(M_Control.CreateGraphics());
                PaintEventArgs1.ClipRectangle = new Rectangle(e.ClipRectangle);
                OneScriptForms.EventQueue.Add(PaintEventArgs1);
                ClPaintEventArgs ClPaintEventArgs1 = new ClPaintEventArgs(PaintEventArgs1);
            }
        }

        private void m_Control_SizeChanged(object sender, System.EventArgs e)
        {
            if (SizeChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = SizeChanged;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void m_Control_TextChanged(object sender, System.EventArgs e)
        {
            if (TextChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = TextChanged;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        public void PerformLayout()
        {
            M_Control.PerformLayout();
        }

        public void PlaceBottom(Control p1, int p2)
        {
            p1.M_Control.Location = new System.Drawing.Point(p1.M_Control.Left, p1.M_Control.Top + p1.M_Control.Height + p2);
        }

        public void PlaceLeft(Control p1, int p2)
        {
            p1.M_Control.Location = new System.Drawing.Point(p1.M_Control.Left - Width - p2, p1.M_Control.Top);
        }

        public void PlaceRight(Control p1, int p2)
        {
            p1.M_Control.Location = new System.Drawing.Point(p1.M_Control.Right + p2, p1.M_Control.Top);
        }

        public void PlaceTop(Control p1, int p2)
        {
            p1.M_Control.Location = new System.Drawing.Point(p1.M_Control.Left, p1.M_Control.Top - Height - p2);
        }

        public osf.Point PointToClient(Point p1)
        {
            return new Point(M_Control.PointToClient(p1.M_Point));
        }

        public osf.Point PointToScreen(Point p1)
        {
            return new Point(M_Control.PointToScreen(p1.M_Point));
        }

        public void Refresh()
        {
            M_Control.Refresh();
        }

        public void ResumeLayout(bool p1 = false)
        {
            M_Control.ResumeLayout(p1);
        }

        public void Select()
        {
            M_Control.Select();
        }

        public void SendToBack()
        {
            M_Control.SendToBack();
        }

        public void SetBounds(int p1, int p2, int p3, int p4)
        {
            M_Control.SetBounds(p1, p2, p3, p4);
        }

        public void Show()
        {
            M_Control.Show();
        }

        public void SuspendLayout()
        {
            M_Control.SuspendLayout();
        }

        public void Update()
        {
            M_Control.Update();
        }

        public virtual void BeginUpdate()
        {
            SendMessage(M_Control.Handle, 11, 0, 0);
            System.Windows.Forms.Application.DoEvents();
        }

        public virtual void EndUpdate()
        {
            SendMessage(M_Control.Handle, 11, -1, 0);
            M_Control.Invalidate();
            System.Windows.Forms.Application.DoEvents();
        }

        public virtual void Center()
        {
            System.Windows.Forms.Control parent = M_Control.Parent;
            M_Control.Location = new System.Drawing.Point((int)System.Math.Round((parent.ClientSize.Width - M_Control.Width) / 2.0), (int)System.Math.Round((parent.ClientSize.Height - M_Control.Height) / 2.0));
        }

    }

}
