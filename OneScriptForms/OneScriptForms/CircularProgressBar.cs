using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Reflection;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class CircularProgressBarEx : System.Windows.Forms.Control
    {
        // Код создан на основе разработки автора Jhollman (Analyst Senior at Cutcsa) https://stackoverflow.com/users/2000656/jhollman?tab=profile
        // Подсказка здесь https://stackoverflow.com/questions/4871263/how-to-create-a-circular-style-progressbar/44419033#44419033

        public osf.CircularProgressBar M_Object;

        private long _Value;
        private long _Maximum = 100;
        private System.Drawing.Color _InitialColor = System.Drawing.Color.FromArgb(92, 92, 92);
        private System.Drawing.Color _FinalColor = System.Drawing.Color.FromArgb(92, 92, 92);
        private System.Drawing.Color _CircleColor = System.Drawing.Color.FromArgb(92, 92, 92);
        private int ProgressShapeVal;
        private bool clockwise;

        private int _LineWitdh = 1;
        private float _BarWidth = 14f;
        private System.Drawing.Color _LineColor = System.Drawing.Color.Silver;
        private int _GradientMode = (int)LinearGradientMode.ForwardDiagonal;
        private int ProgressTextMode;

        public long Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum;
                }
                _Value = value;
                Invalidate();
            }
        }

        public long Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                _Maximum = value;
                Invalidate();
            }
        }

        public System.Drawing.Color InitialColor
        {
            get { return _InitialColor; }
            set
            {
                _InitialColor = value;
                Invalidate();
            }
        }

        public System.Drawing.Color FinalColor
        {
            get { return _FinalColor; }
            set
            {
                _FinalColor = value;
                Invalidate();
            }
        }

        public int ProgressShape
        {
            get { return ProgressShapeVal; }
            set
            {
                ProgressShapeVal = value;
                Invalidate();
            }
        }

        public void Increment(int Val)
        {
            this._Value += Convert.ToInt64(Val);
            Invalidate();
            System.Windows.Forms.Application.DoEvents();
        }

        public void Decrement(int Val)
        {
            this._Value -= Convert.ToInt64(Val);
            Invalidate();
            System.Windows.Forms.Application.DoEvents();
        }

        public bool Clockwise
        {
            get { return clockwise; }
            set { clockwise = value; }
        }

        public float BarWidth
        {
            get { return _BarWidth; }
            set
            {
                _BarWidth = value;
                Invalidate();
            }
        }

        public int GradientMode
        {
            get { return _GradientMode; }
            set
            {
                _GradientMode = value;
                Invalidate();
            }
        }

        public System.Drawing.Color LineColor
        {
            get { return _LineColor; }
            set
            {
                _LineColor = value;
                Invalidate();
            }
        }
		
        public System.Drawing.Color CircleColor
        {
            get { return _CircleColor; }
            set
            {
                _CircleColor = value;
                Invalidate();
            }
        }

        public int LineWidth
        {
            get { return _LineWitdh; }
            set
            {
                _LineWitdh = value;
                Invalidate();
            }
        }

        public int TextMode
        {
            get { return ProgressTextMode; }
            set
            {
                ProgressTextMode = value;
                Invalidate();
            }
        }

        public new string Text { get; set; }

        private static void PaintTransparentBackground(System.Windows.Forms.Control c, System.Windows.Forms.PaintEventArgs e)
        {
            if (c.Parent == null || !System.Windows.Forms.Application.RenderWithVisualStyles)
            {
                return;
            }

            ButtonRenderer.DrawParentBackground(e.Graphics, c.ClientRectangle, c);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            SetStandardSize();
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs p)
        {
            base.OnPaintBackground(p);
        }

        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new System.Drawing.Size(_Size, _Size);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(this.Width, this.Height))
            {
                using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
                {
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    //graphics.Clear(Color.Transparent); //<-- this.BackColor, SystemColors.Control, Color.Transparent

                    PaintTransparentBackground(this, e);

                    // Нарисуйте внутренний белый круг:
                    using (System.Drawing.Brush mBackColor = new System.Drawing.SolidBrush(_CircleColor))
                    {
                        graphics.FillEllipse(mBackColor,
                                BarWidth / 2,
                                BarWidth / 2,
                                this.Width - BarWidth,
                                this.Height - BarWidth
                                );
                    }
                    // Проведите тонкую серую линию посередине:
                    using (System.Drawing.Pen pen2 = new System.Drawing.Pen(LineColor, this.LineWidth))
                    {
                        graphics.DrawEllipse(pen2,
                                BarWidth / 2,
                                BarWidth / 2,
                                this.Width - BarWidth,
                                this.Height - BarWidth
                                );
                    }

                    // Нарисуйте индикатор.
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                        this._FinalColor, this._InitialColor, this.GradientMode))
                    {
                        using (System.Drawing.Pen pen = new System.Drawing.Pen(brush, this.BarWidth))
                        {
                            switch (this.ProgressShapeVal)
                            {
                                case 0: // _ProgressShape.Round
                                    pen.StartCap = LineCap.Round;
                                    pen.EndCap = LineCap.Round;
                                    break;

                                case 1: // _ProgressShape.Flat
                                    pen.StartCap = LineCap.Flat;
                                    pen.EndCap = LineCap.Flat;
                                    break;
                            }

                            // Покажем индикатор.
                            if (!Clockwise)
                            {
                                graphics.DrawArc(pen,
                                    BarWidth / 2,
                                    BarWidth / 2,
                                    this.Width - BarWidth,
                                    this.Width - BarWidth, 
                                    -90,
                                    -(int)Math.Round((double)((360.0 / ((double)this._Maximum)) * this._Value)));
                            }
                            else
                            {
                                graphics.DrawArc(pen,
                                    BarWidth / 2,
                                    BarWidth / 2,
                                    this.Width - BarWidth,
                                    this.Width - BarWidth,
                                    -90,
                                    (int)Math.Round((double)((360.0 / ((double)this._Maximum)) * this._Value)));
                            }
                        }
                    }

                    switch (this.TextMode)
                    {
                        case 0: // _TextMode.None:
                            this.Text = string.Empty;
                            break;

                        case 1: // _TextMode.Value:
                            this.Text = _Value.ToString();
                            break;

                        case 2: // _TextMode.Percentage:
                            this.Text = Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)) + "%";
                            break;

                        default:
                            break;
                    }

                    if (this.Text != string.Empty)
                    {
                        using (System.Drawing.Brush FontColor = new System.Drawing.SolidBrush(this.ForeColor))
                        {
                            int ShadowOffset = 2;
                            System.Drawing.SizeF MS = graphics.MeasureString(this.Text, this.Font);
                            System.Drawing.SolidBrush shadowBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(100, this.ForeColor));

                            // Тень от текста:
                            graphics.DrawString(this.Text, this.Font, shadowBrush,
                                Convert.ToInt32(Width / 2 - MS.Width / 2) + ShadowOffset,
                                Convert.ToInt32(Height / 2 - MS.Height / 2) + ShadowOffset
                            );

                            // Текст элемента управления:
                            graphics.DrawString(this.Text, this.Font, FontColor,
                                Convert.ToInt32(Width / 2 - MS.Width / 2),
                                Convert.ToInt32(Height / 2 - MS.Height / 2));
                        }
                    }
                    // Рисуем элемент управления:
                    e.Graphics.DrawImage(bitmap, 0, 0);
                    graphics.Dispose();
                    bitmap.Dispose();
                }
            }
        }

        // <summary>Нарисуйте круг с цветной заливкой и идеальными краями.
        // <param name="g">Холст объекта, который нужно нарисовать
        // <param name="brush">Цвет и стиль заливки
        // <param name="centerX">Центр окружности на оси X
        // <param name="centerY">Центр окружности на оси Y
        // <param name="radius">Радиус окружности
        private void FillCircle(System.Drawing.Graphics g, System.Drawing.Brush brush, float centerX, float centerY, float radius)
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
            }
        }
    }

    public class CircularProgressBar : Control
    {
        public ClCircularProgressBar dll_obj;
        public CircularProgressBarEx M_CircularProgressBar;

        public CircularProgressBar()
        {
            M_CircularProgressBar = new CircularProgressBarEx();
            M_CircularProgressBar.M_Object = this;
            base.M_Control = M_CircularProgressBar;
            M_CircularProgressBar.MinimumSize = new System.Drawing.Size(33, 33);
            M_CircularProgressBar.CircleColor = M_CircularProgressBar.BackColor;
            DoubleBuffered = true;
            M_CircularProgressBar.Width = 33;
            M_CircularProgressBar.Height = 33;
        }

        public int BarWidth
        {
            get { return Convert.ToInt32(M_CircularProgressBar.BarWidth); }
            set { M_CircularProgressBar.BarWidth = Convert.ToInt64(value); }
        }

        public osf.Color CircleColor
        {
            get { return new Color(M_CircularProgressBar.CircleColor); }
            set { M_CircularProgressBar.CircleColor = value.M_Color; }
        }

        public bool Clockwise
        {
            get { return M_CircularProgressBar.Clockwise; }
            set { M_CircularProgressBar.Clockwise = value; }
        }

        public osf.Color FinalColor
        {
            get { return new Color(M_CircularProgressBar.FinalColor); }
            set { M_CircularProgressBar.FinalColor = value.M_Color; }
        }

        public osf.Color InitialColor
        {
            get { return new Color(M_CircularProgressBar.InitialColor); }
            set { M_CircularProgressBar.InitialColor = value.M_Color; }
        }

        public osf.Color LineColor
        {
            get { return new Color(M_CircularProgressBar.LineColor); }
            set { M_CircularProgressBar.LineColor = value.M_Color; }
        }

        public int LineWidth
        {
            get { return M_CircularProgressBar.LineWidth; }
            set { M_CircularProgressBar.LineWidth = value; }
        }

        public int Maximum
        {
            get { return Convert.ToInt32(M_CircularProgressBar.Maximum); }
            set { M_CircularProgressBar.Maximum = Convert.ToInt64(value); }
        }

        public int ProgressShape
        {
            get { return (int)M_CircularProgressBar.ProgressShape; }
            set { M_CircularProgressBar.ProgressShape = value; }
        }

        public new string Text
        {
            get { return M_CircularProgressBar.Text; }
            set { M_CircularProgressBar.Text = value; }
        }

        public int TextMode
        {
            get { return (int)M_CircularProgressBar.TextMode; }
            set { M_CircularProgressBar.TextMode = value; }
        }

        public int Value
        {
            get { return Convert.ToInt32(M_CircularProgressBar.Value); }
            set { M_CircularProgressBar.Value = Convert.ToInt64(value); }
        }

        public void Decrement(int val)
        {
            M_CircularProgressBar.Decrement(val);
        }

        public void Increment(int val)
        {
            M_CircularProgressBar.Increment(val);
        }
    }

    [ContextClass ("КлКольцевойИндикатор", "ClCircularProgressBar")]
    public class ClCircularProgressBar : AutoContext<ClCircularProgressBar>
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
        private ClColor circleColor;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClCursor cursor;
        private ClColor finalColor;
        private ClFont font;
        private ClColor foreColor;
        private ClColor initialColor;
        private ClColor lineColor;
        private ClCollection tag = new ClCollection();

        public ClCircularProgressBar()
        {
            CircularProgressBar CircularProgressBar1 = new CircularProgressBar();
            CircularProgressBar1.dll_obj = this;
            Base_obj = CircularProgressBar1;
            Clockwise = true;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            finalColor = new ClColor(Base_obj.FinalColor);
            initialColor = new ClColor(Base_obj.InitialColor);
            foreColor = new ClColor(Base_obj.ForeColor);
            circleColor = new ClColor(Base_obj.CircleColor);
            lineColor = new ClColor(Base_obj.LineColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }

        public CircularProgressBar Base_obj;
        
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

        [ContextProperty("Значение", "Value")]
        public int Value
        {
            get { return Base_obj.Value; }
            set { Base_obj.Value = value; }
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

        [ContextProperty("КонечныйЦвет", "FinalColor")]
        public ClColor FinalColor
        {
            get { return finalColor; }
            set 
            {
                finalColor = value;
                Base_obj.FinalColor = value.Base_obj;
            }
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

        [ContextProperty("Максимум", "Maximum")]
        public int Maximum
        {
            get { return Base_obj.Maximum; }
            set { Base_obj.Maximum = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
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
        
        [ContextProperty("НачальныйЦвет", "InitialColor")]
        public ClColor InitialColor
        {
            get { return initialColor; }
            set 
            {
                initialColor = value;
                Base_obj.InitialColor = value.Base_obj;
            }
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

        [ContextProperty("ПоЧасовой", "Clockwise")]
        public bool Clockwise
        {
            get { return Base_obj.Clockwise; }
            set { Base_obj.Clockwise = value; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
            get { return Base_obj.Right; }
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
        
        [ContextProperty("РежимТекста", "TextMode")]
        public int TextMode
        {
            get { return (int)Base_obj.TextMode; }
            set { Base_obj.TextMode = value; }
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

        [ContextProperty("ФормаИндикатора", "ProgressShape")]
        public int ProgressShape
        {
            get { return (int)Base_obj.ProgressShape; }
            set { Base_obj.ProgressShape = value; }
        }

        [ContextProperty("ЦветКруга", "CircleColor")]
        public ClColor CircleColor
        {
            get { return circleColor; }
            set 
            {
                circleColor = value;
                Base_obj.CircleColor = value.Base_obj;
            }
        }

        [ContextProperty("ЦветЛинии", "LineColor")]
        public ClColor LineColor
        {
            get { return lineColor; }
            set 
            {
                lineColor = value;
                Base_obj.LineColor = value.Base_obj;
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

        [ContextProperty("ШиринаЛинии", "LineWidth")]
        public int LineWidth
        {
            get { return Base_obj.LineWidth; }
            set { Base_obj.LineWidth = value; }
        }

        [ContextProperty("ШиринаПолосы", "BarWidth")]
        public int BarWidth
        {
            get { return Base_obj.BarWidth; }
            set { Base_obj.BarWidth = value; }
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

        [ContextMethod("Увеличение", "Increment")]
        public void Increment(int p1)
        {
            Base_obj.Increment(p1);
        }

        [ContextMethod("Уменьшение", "Decrement")]
        public void Decrement(int p1)
        {
            Base_obj.Decrement(p1);
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
