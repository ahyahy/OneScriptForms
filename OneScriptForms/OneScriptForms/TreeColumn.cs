using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Threading;
using System.Text;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Aga.Controls.Tree.NodeControls;
using Aga.Controls.Threading;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace Aga.Controls.Tree
{
    public class TreeColumn : System.ComponentModel.Component
    {
        private const int HeaderLeftMargin = 5;
        private const int HeaderRightMargin = 5;
        private const int SortOrderMarkMargin = 8;
        private TextFormatFlags _headerFlags;
        private TextFormatFlags _baseHeaderFlags = TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsTranslateTransform;
        private TreeColumnCollection _owner;
        private string _header;
        private int _width;
        private int _minColumnWidth;
        private int _maxColumnWidth;
        private bool _visible = true;
        private HorizontalAlignment _textAlign = HorizontalAlignment.Left;
        private bool _sortable = false;
        private SortOrder _sort_order = SortOrder.None;
        private static VisualStyleRenderer _normalRenderer;
        private static VisualStyleRenderer _pressedRenderer;
        private static VisualStyleRenderer _hotRenderer;
        public event EventHandler HeaderChanged;
        public event EventHandler SortOrderChanged;
        public event EventHandler IsVisibleChanged;
        public event EventHandler WidthChanged;
        public Dictionary<osf.ClToolTip, object> ObjTooltip = new Dictionary<osf.ClToolTip, object>();

        public TreeColumn() : this(string.Empty, 50)
        {
        }

        public TreeColumn(string header, int width)
        {
            _header = header;
            _width = width;
            _headerFlags = _baseHeaderFlags | TextFormatFlags.Left;
        }

        internal TreeColumnCollection Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public int Index
        {
            get
            {
                if (Owner != null)
                {
                    return Owner.IndexOf(this);
                }
                else
                {
                    return -1;
                }
            }
        }

        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                OnHeaderChanged();
            }
        }

        public object TooltipText { get; set; }

        public int Width
        {
            get { return _width; }
            set
            {
                if (_width != value)
                {
                    _width = Math.Max(MinColumnWidth, value);
                    if (_maxColumnWidth > 0)
                    {
                        _width = Math.Min(_width, MaxColumnWidth);
                    }
                    OnWidthChanged();
                }
            }
        }

        public int MinColumnWidth
        {
            get { return _minColumnWidth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                _minColumnWidth = value;
                Width = Math.Max(value, Width);
            }
        }

        public int MaxColumnWidth
        {
            get { return _maxColumnWidth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                _maxColumnWidth = value;
                if (value > 0)
                {
                    Width = Math.Min(value, _width);
                }
            }
        }

        public bool IsVisible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                OnIsVisibleChanged();
            }
        }
		
        public bool Visible
        {
            get { return IsVisible; }
            set { IsVisible = value; }
        }

        public HorizontalAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                if (value != _textAlign)
                {
                    _textAlign = value;
                    _headerFlags = _baseHeaderFlags | TextHelper.TranslateAligmentToFlag(value);
                    OnHeaderChanged();
                }
            }
        }

        public bool Sortable
        {
            get { return _sortable; }
            set { _sortable = value; }
        }

        public SortOrder SortOrder
        {
            get { return _sort_order; }
            set
            {
                if (value == _sort_order)
                {
                    return;
                }
                _sort_order = value;
                OnSortOrderChanged();
            }
        }

        public Size SortMarkSize
        {
            get
            {
                if (Application.RenderWithVisualStyles)
                {
                    return new Size(9, 5);
                }
                else
                {
                    return new Size(7, 4);
                }
            }
        }
		
        public TextFormatFlags HeaderFlags
        {
            get { return _headerFlags; }
            set { _headerFlags = value; }
        }

        public TextFormatFlags BaseHeaderFlags
        {
            get { return _baseHeaderFlags; }
            set { _baseHeaderFlags = value; }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Header))
            {
                return GetType().Name;
            }
            else
            {
                return Header;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private static void CreateRenderers()
        {
            if (Application.RenderWithVisualStyles && _normalRenderer == null)
            {
                _normalRenderer = new VisualStyleRenderer(VisualStyleElement.Header.Item.Normal);
                _pressedRenderer = new VisualStyleRenderer(VisualStyleElement.Header.Item.Pressed);
                _hotRenderer = new VisualStyleRenderer(VisualStyleElement.Header.Item.Hot);
            }
        }

        internal Bitmap CreateGhostImage(Rectangle bounds, Font font)
        {
            Bitmap b = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            Graphics gr = Graphics.FromImage(b);
            gr.FillRectangle(SystemBrushes.ControlDark, bounds);
            DrawContent(gr, bounds, font);
            BitmapHelper.SetAlphaChanelValue(b, 150);
            return b;
        }

        internal void Draw(Graphics gr, Rectangle bounds, Font font, bool pressed, bool hot)
        {
            DrawBackground(gr, bounds, pressed, hot);
            DrawContent(gr, bounds, font);
        }

        private void DrawContent(Graphics gr, Rectangle bounds, Font font)
        {
            Rectangle innerBounds = new Rectangle(bounds.X + HeaderLeftMargin, bounds.Y, bounds.Width - HeaderLeftMargin - HeaderRightMargin, bounds.Height);

            if (SortOrder != SortOrder.None)
            {
                innerBounds.Width -= (SortMarkSize.Width + SortOrderMarkMargin);
            }

            Size maxTextSize = TextRenderer.MeasureText(gr, Header, font, innerBounds.Size, TextFormatFlags.NoPadding);
            Size textSize = TextRenderer.MeasureText(gr, Header, font, innerBounds.Size, _baseHeaderFlags);

            if (SortOrder != SortOrder.None)
            {
                int tw = Math.Min(textSize.Width, innerBounds.Size.Width);

                int x = 0;
                if (TextAlign == HorizontalAlignment.Left)
                {
                    x = innerBounds.X + tw + SortOrderMarkMargin;
                }
                else if (TextAlign == HorizontalAlignment.Right)
                {
                    x = innerBounds.Right + SortOrderMarkMargin;
                }
                else
                {
                    x = innerBounds.X + tw + (innerBounds.Width - tw) / 2 + SortOrderMarkMargin;
                }
                DrawSortMark(gr, bounds, x);
            }

            if (textSize.Width < maxTextSize.Width)
            {
                TextRenderer.DrawText(gr, Header, font, innerBounds, SystemColors.ControlText, _baseHeaderFlags | TextFormatFlags.Left);
            }
            else
            {
                TextRenderer.DrawText(gr, Header, font, innerBounds, SystemColors.ControlText, _headerFlags);
            }
        }

        private void DrawSortMark(Graphics gr, Rectangle bounds, int x)
        {
            int y = bounds.Y + bounds.Height / 2 - 2;
            x = Math.Max(x, bounds.X + SortOrderMarkMargin);

            int w2 = SortMarkSize.Width / 2;
            if (SortOrder == SortOrder.Ascending)
            {
                Point[] points = new Point[] { new Point(x, y), new Point(x + SortMarkSize.Width, y), new Point(x + w2, y + SortMarkSize.Height) };
                gr.FillPolygon(SystemBrushes.ControlDark, points);
            }
            else if (SortOrder == SortOrder.Descending)
            {
                Point[] points = new Point[] { new Point(x - 1, y + SortMarkSize.Height), new Point(x + SortMarkSize.Width, y + SortMarkSize.Height), new Point(x + w2, y - 1) };
                gr.FillPolygon(SystemBrushes.ControlDark, points);
            }
        }

        internal static void DrawDropMark(Graphics gr, Rectangle rect)
        {
            gr.FillRectangle(SystemBrushes.HotTrack, rect.X - 1, rect.Y, 2, rect.Height);
        }

        internal static void DrawBackground(Graphics gr, Rectangle bounds, bool pressed, bool hot)
        {
            if (Application.RenderWithVisualStyles)
            {
                CreateRenderers();
                if (pressed)
                {
                    _pressedRenderer.DrawBackground(gr, bounds);
                }
                else if (hot)
                {
                    _hotRenderer.DrawBackground(gr, bounds);
                }
                else
                {
                    _normalRenderer.DrawBackground(gr, bounds);
                }
            }
            else
            {
                gr.FillRectangle(SystemBrushes.Control, bounds);
                Pen p1 = SystemPens.ControlLightLight;
                Pen p2 = SystemPens.ControlDark;
                Pen p3 = SystemPens.ControlDarkDark;
                if (pressed)
                {
                    gr.DrawRectangle(p2, bounds.X, bounds.Y, bounds.Width, bounds.Height);
                }
                else
                {
                    gr.DrawLine(p1, bounds.X, bounds.Y, bounds.Right, bounds.Y);
                    gr.DrawLine(p3, bounds.X, bounds.Bottom, bounds.Right, bounds.Bottom);
                    gr.DrawLine(p3, bounds.Right - 1, bounds.Y, bounds.Right - 1, bounds.Bottom - 1);
                    gr.DrawLine(p1, bounds.Left, bounds.Y + 1, bounds.Left, bounds.Bottom - 2);
                    gr.DrawLine(p2, bounds.Right - 2, bounds.Y + 1, bounds.Right - 2, bounds.Bottom - 2);
                    gr.DrawLine(p2, bounds.X, bounds.Bottom - 1, bounds.Right - 2, bounds.Bottom - 1);
                }
            }
        }

        private void OnHeaderChanged()
        {
            if (HeaderChanged != null)
            {
                HeaderChanged(this, EventArgs.Empty);
            }
        }

        private void OnSortOrderChanged()
        {
            if (SortOrderChanged != null)
            {
                SortOrderChanged(this, EventArgs.Empty);
            }
        }

        private void OnIsVisibleChanged()
        {
            if (IsVisibleChanged != null)
            {
                IsVisibleChanged(this, EventArgs.Empty);
            }
        }

        private void OnWidthChanged()
        {
            if (WidthChanged != null)
            {
                WidthChanged(this, EventArgs.Empty);
            }
        }
		
        internal Size GetActualSize(DrawContext context)
        {
            if (!IsVisible)
            {
                return Size.Empty;
            }
            Size size = MeasureSize(context);
            return new Size(size.Width + 5, 3 + size.Height + 3);
        }

        public Size MeasureSize(DrawContext context)
        {
            return GetLabelSize(context);
        }

        protected Size GetLabelSize(DrawContext context)
        {
            return GetLabelSize(context, Header);
        }

        protected Size GetLabelSize(DrawContext context, string label)
        {
            Font drawingFont = GetDrawingFont(context, label);
            Size size = Size.Empty;
            if (UseCompatibleTextRendering)
            {
                size = TextRenderer.MeasureText(label, drawingFont);
            }
            else
            {
                SizeF sizeF = context.Graphics.MeasureString(label, drawingFont);
                size = new Size((int)Math.Ceiling((double)sizeF.Width), (int)Math.Ceiling((double)sizeF.Height));
            }
            if (!size.IsEmpty)
            {
                return size;
            }
            return new Size(10, drawingFont.Height);
        }

        protected Font GetDrawingFont(DrawContext context, string label)
        {
            return context.Font;
        }

        private bool _useCompatibleTextRendering;
        public bool UseCompatibleTextRendering
        {
            get { return _useCompatibleTextRendering; }
            set { _useCompatibleTextRendering = value; }
        }
    }
}

namespace osf
{
    public class TreeColumnEx : Aga.Controls.Tree.TreeColumn
    {
        public osf.TreeColumn M_Object;

        public TreeColumnEx() : base(string.Empty, 50)
        {
        }

        public TreeColumnEx(string header, int width) : base(header, width)
        {
        }
    }

    public class TreeColumn : osf.Component
    {
        public ClTreeColumn dll_obj;
        public TreeColumnEx M_TreeColumn;
        public string HeaderChanged;
        public string SortOrderChanged;
        public string IsVisibleChanged;
        public string WidthChanged;

        public TreeColumn()
        {
            M_TreeColumn = new TreeColumnEx();
            M_TreeColumn.M_Object = this;
            base.M_Component = M_TreeColumn;

            HeaderChanged = "";
            SortOrderChanged = "";
            IsVisibleChanged = "";
            WidthChanged = "";
        }

        public TreeColumn(string header, int width)
        {
            M_TreeColumn = new TreeColumnEx(header, width);
            M_TreeColumn.M_Object = this;
            base.M_Component = M_TreeColumn;

            HeaderChanged = "";
            SortOrderChanged = "";
            IsVisibleChanged = "";
            WidthChanged = "";
        }

        public TreeColumn(Aga.Controls.Tree.TreeColumn p1)
        {
            M_TreeColumn = (TreeColumnEx)p1;
            M_TreeColumn.M_Object = this;
            base.M_Component = M_TreeColumn;

            HeaderChanged = "";
            SortOrderChanged = "";
            IsVisibleChanged = "";
            WidthChanged = "";
        }

        public int Index
        {
            get { return M_TreeColumn.Index; }
        }
		
        public int TextAlign
        {
            get { return (int)M_TreeColumn.TextAlign; }
            set { M_TreeColumn.TextAlign = (System.Windows.Forms.HorizontalAlignment)value; }
        }

        public string Header
        {
            get { return M_TreeColumn.Header; }
            set { M_TreeColumn.Header = value; }
        }

        public int MaxColumnWidth
        {
            get { return M_TreeColumn.MaxColumnWidth; }
            set { M_TreeColumn.MaxColumnWidth = value; }
        }

        public int MinColumnWidth
        {
            get { return M_TreeColumn.MinColumnWidth; }
            set { M_TreeColumn.MinColumnWidth = value; }
        }

        public bool Visible
        {
            get { return M_TreeColumn.Visible; }
            set { M_TreeColumn.Visible = value; }
        }

        public int SortOrder
        {
            get { return (int)M_TreeColumn.SortOrder; }
            set { M_TreeColumn.SortOrder = (System.Windows.Forms.SortOrder)value; }
        }

        public bool Sortable
        {
            get { return M_TreeColumn.Sortable; }
            set { M_TreeColumn.Sortable = value; }
        }

        public Dictionary<osf.ClToolTip, object> ObjTooltip
        {
            get { return M_TreeColumn.ObjTooltip; }
        }

        public object TooltipText
        {
            get { return M_TreeColumn.TooltipText; }
            set { M_TreeColumn.TooltipText = value; }
        }

        public int Width
        {
            get { return M_TreeColumn.Width; }
            set { M_TreeColumn.Width = value; }
        }
    }

    [ContextClass("КлКолонкаДереваЗначений", "ClTreeColumn")]
    public class ClTreeColumn : AutoContext<ClTreeColumn>
    {

        public ClTreeColumn(string p1 = null, int p2 = 50)
        {
            TreeColumn TreeColumn1 = new TreeColumn(p1, p2);
            TreeColumn1.dll_obj = this;
            Base_obj = TreeColumn1;
        }//end_constr
		
        public ClTreeColumn(TreeColumn p1)
        {
            TreeColumn TreeColumn1 = p1;
            TreeColumn1.dll_obj = this;
            Base_obj = TreeColumn1;
        }//end_constr

        public TreeColumn Base_obj;

        //Свойства============================================================
        [ContextProperty("ВыравниваниеТекста", "TextAlign")]
        public int TextAlign
        {
            get { return (int)Base_obj.TextAlign; }
            set { Base_obj.TextAlign = value; }
        }

        [ContextProperty("Заголовок", "Header")]
        public string Header
        {
            get { return Base_obj.Header; }
            set { Base_obj.Header = value; }
        }

        [ContextProperty("Индекс", "Index")]
        public int Index
        {
            get { return Base_obj.Index; }
        }

        [ContextProperty("МаксимальнаяШиринаКолонки", "MaxColumnWidth")]
        public int MaxColumnWidth
        {
            get { return Base_obj.MaxColumnWidth; }
            set { Base_obj.MaxColumnWidth = value; }
        }

        [ContextProperty("МинимальнаяШиринаКолонки", "MinColumnWidth")]
        public int MinColumnWidth
        {
            get { return Base_obj.MinColumnWidth; }
            set { Base_obj.MinColumnWidth = value; }
        }

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
            set { Base_obj.Width = value; }
        }

        //endProperty
        //Методы============================================================
        //endMethods
    }//endClass

}//endnamespace
