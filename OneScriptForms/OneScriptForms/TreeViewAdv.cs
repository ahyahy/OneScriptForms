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

    #region Aga.Controls.Tree

namespace Aga.Controls.Tree
{
    // Код создан на основе разработки автора Andrey Gliznetsov https://www.codeproject.com/Articles/14741/Advanced-TreeView-for-NET под лицензией 
    // == license.txt ===========================================
    // The BSD License

    //Copyright(c) 2009, Andrey Gliznetsov(a.gliznetsov @gmail.com)

    //All rights reserved.

    //Redistribution and use in source and binary forms, with or without modification, are permitted provided
    //that the following conditions are met

    //- Redistributions of source code must retain the above copyright notice, this list of conditions
    //and the following disclaimer.
    //- Redistributions in binary form must reproduce the above copyright notice, this list of conditions
    //and the following disclaimer in the documentation andor other materials provided with the distribution.

    //THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
    //AS IS AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
    //LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
    //A PARTICULAR PURPOSE ARE DISCLAIMED.IN NO EVENT SHALL THE COPYRIGHT OWNER OR
    //CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
    //EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
    //PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
    //PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
    //LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
    //NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
    //SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
    // =============================================

    // Расширенный TreeView, реализованный на 100% в управляемом коде C#.
    // Особенности: 
    //    Архитектура - модель/представление. 
    //    Несколько колонок на узел. 
    //    Возможность выбора нескольких узлов дерева.
    //    Различные типы элементов управления для каждого столбца узла: CheckBox, Icon, Label... 
    //    Подсветка, выделение при перетаскивании. 
    //    Загрузка узлов по требованию. 
    //    Инкрементный поиск узлов.

    public class TreeViewAdv : Control
    {
        static string str_dVSplitCursor = "AAACAAEAICACAAgACQAwAQAAFgAAACgAAAAgAAAAQAAAAAEAAQAAAAAAAAEAAAAAAAAAAAAAAgAAAAAAAAAAAAAA////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADwAAAA8AAAAPAAAADwAAAA8AAAAPAAAADwAAAA8AAAAPAAAADwAAAA8AAAAPAAAADwAAAA8AAAAPAAAADwAAAAAAAA/////////////////////////////////////////////////////////////////////////////////gf///4H///+B////gf///4H///uB3//zgc//4AAH/+AAB//zgc//+4Hf//+B////gf///4H///+B////gf///////8=";
        public static Cursor DVSplitCursor = GetCursor(str_dVSplitCursor);
        static string str_loadingIcon = "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";
        public static GifDecoder LoadingIcon = GetGifDecoder(str_loadingIcon);
        private const int LeftMargin = 7;
        internal const int ItemDragSensivity = 4;
        private int _columnHeaderHeight;
        private const int DividerWidth = 9;
        private const int DividerCorrectionGap = -2;
        private Pen _linePen;
        private Pen _markPen;
        private bool _suspendUpdate;
        private bool _needFullUpdate;
        private bool _fireSelectionEvent;
        private NodePlusMinus _plusMinus;
        private ToolTip _toolTip;
        private DrawContext _measureContext;
        private TreeColumn _hotColumn;
        private IncrementalSearch _search;
        private List<TreeNodeAdv> _expandingNodes = new List<TreeNodeAdv>();
        private AbortableThreadPool _threadPool = new AbortableThreadPool();
        private IContainer components = null;
        private VScrollBar _vScrollBar;
        private HScrollBar _hScrollBar;
        private ErrorProvider _errorProvider;
        public event EventHandler<TreeNodeAdvMouseEventArgs> NodeMouseDoubleClick;
        public event EventHandler<TreeColumnEventArgs> ColumnWidthChanged;
        public event EventHandler<TreeColumnEventArgs> ColumnReordered;
        public event EventHandler<TreeColumnEventArgs> ColumnClicked;
        public event EventHandler SelectionChanged;
        public event EventHandler<TreeViewAdvEventArgs> Collapsing;
        public event EventHandler<TreeViewAdvEventArgs> Collapsed;
        public event EventHandler<TreeViewAdvEventArgs> Expanding;
        public event EventHandler<TreeViewAdvEventArgs> Expanded;
        public event EventHandler GridLineStyleChanged;
        public event ScrollEventHandler Scroll;
        public event EventHandler<TreeViewRowDrawEventArgs> RowDraw;
        public event EventHandler<DrawEventArgs> DrawControl;
        public event ItemDragEventHandler ItemDrag;
        public event EventHandler<TreeNodeAdvMouseEventArgs> NodeMouseClick;
        public event EventHandler<DropNodeValidatingEventArgs> DropNodeValidating;
        private delegate void UpdateContentWidthDelegate(TreeModelEventArgs e, TreeNodeAdv parent);
        public osf.ClTreeViewAdv dll_obj;
        private TreeNodeAdv _editingNode;
        public EditableControl CurrentEditorOwner { get; private set; }
        public Control CurrentEditor { get; private set; }
        TreeColumn _tooltipColumn;
        TreeNodeAdv _tooltipTreeNodeAdv;
        NodeControl _tooltipNodeControl;
        TreeNodeAdv _hotNode;
        NodeControl _hotControl;
        private bool _dragAutoScrollFlag = false;
        private Bitmap _dragBitmap = null;
        private System.Threading.Timer _dragTimer;
        private Cursor _innerCursor = null;
        private IRowLayout _rowLayout;
        private bool _dragMode;
        private bool _suspendSelectionEvent;
        private List<TreeNodeAdv> _rowMap;
        private TreeNodeAdv _selectionStart;
        private InputState _input;
        private int _contentWidth = 0;
        private bool _itemDragMode;
        private Point _itemDragStart;
        private int _firstVisibleRow;
        private int _offsetX;
        private List<TreeNodeAdv> _selection;
        private bool _shiftFirstNode;
        private bool _displayDraggingNodes;
        private bool _fullRowSelect;
        private bool _useColumns;
        private bool _allowColumnReorder;
        private bool _showLines = true;
        private bool _showPlusMinus = true;
        private bool _showNodeToolTips = true;
        private ITreeModel _model;
        private static Font _font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)), false); // Шрифт Tahoma используется по умолчанию.
        private BorderStyle _borderStyle = BorderStyle.Fixed3D;
        private bool _autoRowHeight = false;
        private GridLineStyle _gridLineStyle = GridLineStyle.None;
        private int _rowHeight = 16;
        private TreeSelectionMode _selectionMode = TreeSelectionMode.Single;
        private bool _hideSelection;
        private float _topEdgeSensivity = 0.3f;
        private float _bottomEdgeSensivity = 0.3f;
        private bool _loadOnDemand;
        private bool _unloadCollapsedOnReload = false;
        private int _indent = 19;
        private Color _lineColor = SystemColors.ControlDark;
        private Color _dragDropMarkColor = Color.Black;
        private float _dragDropMarkWidth = 3.0f;
        private bool _highlightDropPosition = true;
        private TreeColumnCollection _columns;
        private NodeControlsCollection _controls;
        private bool _asyncExpanding;
        private IToolTipProvider _defaultToolTipProvider = null;
        private DropPosition _dropPosition;
        private TreeNodeAdv _root;
        private ReadOnlyCollection<TreeNodeAdv> _readonlySelection;
        private TreeNodeAdv _currentNode;
        private IHeaderLayout _headerLayout;
        private bool _autoHeaderHeight;
        private string pathSeparator = @"\";
        private Image image;
        private Image selectedImage;

        public TreeViewAdv()
        {
            components = new System.ComponentModel.Container();
            _vScrollBar = new System.Windows.Forms.VScrollBar();
            _hScrollBar = new System.Windows.Forms.HScrollBar();
            _errorProvider = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)(_errorProvider)).BeginInit();
            SuspendLayout();

            _vScrollBar.LargeChange = 1;
            _vScrollBar.Location = new System.Drawing.Point(0, 0);
            _vScrollBar.Maximum = 0;
            _vScrollBar.Name = "_vScrollBar";
            _vScrollBar.Size = new System.Drawing.Size(13, 80);
            _vScrollBar.TabIndex = 1;
            _vScrollBar.ValueChanged += new System.EventHandler(_vScrollBar_ValueChanged);
            _vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(_vScrollBar_Scroll);

            _hScrollBar.LargeChange = 1;
            _hScrollBar.Location = new System.Drawing.Point(0, 0);
            _hScrollBar.Maximum = 0;
            _hScrollBar.Name = "_hScrollBar";
            _hScrollBar.Size = new System.Drawing.Size(80, 13);
            _hScrollBar.TabIndex = 2;
            _hScrollBar.ValueChanged += new System.EventHandler(_hScrollBar_ValueChanged);
            _hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(_hScrollBar_Scroll);

            BackColor = System.Drawing.SystemColors.Window;
            Controls.Add(_vScrollBar);
            Controls.Add(_hScrollBar);
            ((System.ComponentModel.ISupportInitialize)(_errorProvider)).EndInit();
            ResumeLayout(false);

            SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.Selectable
                , true);

            if (Application.RenderWithVisualStyles)
            {
                _columnHeaderHeight = 20;
            }
            else
            {
                _columnHeaderHeight = 17;
            }

            //BorderStyle = BorderStyle.Fixed3D;
            _hScrollBar.Height = SystemInformation.HorizontalScrollBarHeight;
            _vScrollBar.Width = SystemInformation.VerticalScrollBarWidth;
            _rowLayout = new FixedRowHeightLayout(this, RowHeight);
            _rowMap = new List<TreeNodeAdv>();
            _selection = new List<TreeNodeAdv>();
            _readonlySelection = new ReadOnlyCollection<TreeNodeAdv>(_selection);
            _columns = new TreeColumnCollection(this);
            _toolTip = new ToolTip();

            _measureContext = new DrawContext();
            _measureContext.Font = Font;
            _measureContext.Graphics = Graphics.FromImage(new Bitmap(1, 1));

            Input = new NormalInputState(this);
            _search = new IncrementalSearch(this);
            CreateNodes();
            CreatePens();

            ArrangeControls();

            _plusMinus = new NodePlusMinus();
            _controls = new NodeControlsCollection(this);

            Font = _font;
            Size = new System.Drawing.Size(121, 97);
            ExpandingIcon.IconChanged += ExpandingIconChanged;
        }
		
        public string PathSeparator
        {
            get { return pathSeparator; }
            set { pathSeparator = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                if (_dragBitmap != null)
                {
                    _dragBitmap.Dispose();
                }
                if (_dragTimer != null)
                {
                    _dragTimer.Dispose();
                }
                if (_linePen != null)
                {
                    _linePen.Dispose();
                }
                if (_markPen != null)
                {
                    _markPen.Dispose();
                }
            }
            base.Dispose(disposing);
        }

		private void OnItemDrag(MouseButtons buttons, object item)
		{
			if (ItemDrag != null)
            {
                ItemDrag(this, new ItemDragEventArgs(buttons, item));
            }
        }

		private void OnNodeMouseClick(TreeNodeAdvMouseEventArgs args)
		{
			if (NodeMouseClick != null)
            {
                NodeMouseClick(this, args);
            }
        }

		private void OnNodeMouseDoubleClick(TreeNodeAdvMouseEventArgs args)
		{
			if (NodeMouseDoubleClick != null)
            {
                NodeMouseDoubleClick(this, args);
            }
        }

		internal void OnColumnWidthChanged(TreeColumn column)
		{
			if (ColumnWidthChanged != null)
            {
                ColumnWidthChanged(this, new TreeColumnEventArgs(column));
            }
        }

		internal void OnColumnReordered(TreeColumn column)
		{
			if (ColumnReordered != null)
            {
                ColumnReordered(this, new TreeColumnEventArgs(column));
            }
        }

		internal void OnColumnClicked(TreeColumn column)
		{
			if (ColumnClicked != null)
            {
                ColumnClicked(this, new TreeColumnEventArgs(column));
            }
        }

		internal void OnSelectionChanged()
		{
			if (SuspendSelectionEvent)
            {
                _fireSelectionEvent = true;
            }
            else
			{
				_fireSelectionEvent = false;
				if (SelectionChanged != null)
                {
                    SelectionChanged(this, EventArgs.Empty);
                }
            }
		}

		private void OnCollapsing(TreeNodeAdv node)
		{
			if (Collapsing != null)
            {
                Collapsing(this, new TreeViewAdvEventArgs(node));
            }
        }

		private void OnCollapsed(TreeNodeAdv node)
		{
			if (Collapsed != null)
            {
                Collapsed(this, new TreeViewAdvEventArgs(node));
            }
        }

		private void OnExpanding(TreeNodeAdv node)
		{
			if (Expanding != null)
            {
                Expanding(this, new TreeViewAdvEventArgs(node));
            }
        }

		private void OnExpanded(TreeNodeAdv node)
		{
			if (Expanded != null)
            {
                Expanded(this, new TreeViewAdvEventArgs(node));
            }
        }

		private void OnGridLineStyleChanged()
		{
			if (GridLineStyleChanged != null)
            {
                GridLineStyleChanged(this, EventArgs.Empty);
            }
        }

		protected virtual void OnScroll(ScrollEventArgs e)
		{
			if (Scroll != null)
            {
                Scroll(this, e);
            }
        }

		protected virtual void OnRowDraw(PaintEventArgs e, TreeNodeAdv node, DrawContext context, int row, Rectangle rowRect)
		{
			if (RowDraw != null)
			{
				TreeViewRowDrawEventArgs args = new TreeViewRowDrawEventArgs(e.Graphics, e.ClipRectangle, node, context, row, rowRect);
				RowDraw(this, args);
			}
		}

        // Срабатывает, когда управление переходит в режим прорисовки. Может использоваться для изменения текста или цвета задней панели.
		internal bool DrawControlMustBeFired()
		{
			return DrawControl != null;
		}

		internal void FireDrawControl(DrawEventArgs args)
		{
			OnDrawControl(args);
		}

		protected virtual void OnDrawControl(DrawEventArgs args)
		{
			if (DrawControl != null)
            {
                DrawControl(this, args);
            }
        }

		protected virtual void OnDropNodeValidating(Point point, ref TreeNodeAdv node)
		{
			if (DropNodeValidating != null)
			{
				DropNodeValidatingEventArgs args = new DropNodeValidatingEventArgs(point, node);
				DropNodeValidating(this, args);
				node = args.Node;
			}
		}

        private static Cursor GetCursor(string str)
        {
            byte[] bytes_dVSplitCursor = Convert.FromBase64String(str);
            MemoryStream ms = new MemoryStream(bytes_dVSplitCursor);
            return new Cursor(ms);
        }

        private static GifDecoder GetGifDecoder(string str)
        {
            byte[] bytes_loadingIcon = Convert.FromBase64String(str);
            MemoryStream ms = new MemoryStream(bytes_loadingIcon);
            return new GifDecoder(ms, true);
        }

        void ExpandingIconChanged(object sender, EventArgs e)
		{
			if (IsHandleCreated && !IsDisposed)
            {
                BeginInvoke(new MethodInvoker(DrawIcons));
            }
        }

		private void DrawIcons()
		{
			using (Graphics gr = Graphics.FromHwnd(this.Handle))
			{
                // Примените ту же логику преобразования графики, что и в OnPaint.
                int y = 0;
				if (UseColumns)
				{
					y += ColumnHeaderHeight;
					if (Columns.Count == 0)
                    {
                        return;
                    }
                }
				int firstRowY = _rowLayout.GetRowBounds(FirstVisibleRow).Y;
				y -= firstRowY;
				gr.ResetTransform();
				gr.TranslateTransform(-OffsetX, y);

				DrawContext context = new DrawContext();
				context.Graphics = gr;
				for (int i = 0; i < _expandingNodes.Count; i++)
				{
					foreach (NodeControlInfo item in GetNodeControls(_expandingNodes[i]))
					{
						if (item.Control is ExpandingIcon)
						{
							Rectangle bounds = item.Bounds;
							if (item.Node.Parent == null && UseColumns)
                            {
                                bounds.Location = Point.Empty; // Отображение значка расширения корня на уровне 0,0
                            }

                            context.Bounds = bounds;
							item.Control.Draw(item.Node, context);
						}
					}
				}
			}
		}

		public TreePath GetPath(TreeNodeAdv node)
		{
			if (node == _root)
            {
                return TreePath.Empty;
            }
            else
			{
				Stack<object> stack = new Stack<object>();
				while (node != _root && node != null)
				{
					stack.Push(node.Tag);
					node = node.Parent;
				}
				return new TreePath(stack.ToArray());
			}
		}
		
        public string GetFullPath(TreeNodeAdv node)
        {
            Node _node = (Node)node.Tag;
            string fullPath = _node.NodeName;
            while (_node.Parent != null)
            {
                _node = _node.Parent;
                fullPath = _node.NodeName + this.PathSeparator + fullPath;
            }
            return fullPath.TrimStart(this.PathSeparator.ToCharArray());
        }

		public TreeNodeAdv GetNodeAt(Point point)
		{
			NodeControlInfo info = GetNodeControlInfoAt(point);
			return info.Node;
		}

		public NodeControlInfo GetNodeControlInfoAt(Point point)
		{
			if (point.X < 0 || point.Y < 0)
            {
                return NodeControlInfo.Empty;
            }

            int row = _rowLayout.GetRowAt(point);
			if (row < RowCount && row >= 0)
            {
                return GetNodeControlInfoAt(RowMap[row], point);
            }
            else
            {
                return NodeControlInfo.Empty;
            }
        }
		
        public NodeControlInfo GetNodeControlInfoAt2(TreeNodeAdv node, Point point)
        {
            return GetNodeControlInfoAt(node, point);
        }

		private NodeControlInfo GetNodeControlInfoAt(TreeNodeAdv node, Point point)
		{
			Rectangle rect = _rowLayout.GetRowBounds(FirstVisibleRow);
			point.Y += (rect.Y - ColumnHeaderHeight);
			point.X += OffsetX;
			foreach (NodeControlInfo info in GetNodeControls(node))
				if (info.Bounds.Contains(point))
                {
                    return info;
                }

            if (FullRowSelect)
            {
                return new NodeControlInfo(null, Rectangle.Empty, node);
            }
            else
            {
                return NodeControlInfo.Empty;
            }
        }

		public void BeginUpdate()
		{
			_suspendUpdate = true;
			SuspendSelectionEvent = true;
		}

		public void EndUpdate()
		{
			_suspendUpdate = false;
			if (_needFullUpdate)
            {
                FullUpdate();
            }
            else
            {
                UpdateView();
            }
            SuspendSelectionEvent = false;
		}

		public void ExpandAll()
		{
			_root.ExpandAll();
		}

		public void CollapseAll()
		{
			_root.CollapseAll();
		}

        // Разверните все родительские узлы, а затем прокрутите до указанного узла.
        public void EnsureVisible(TreeNodeAdv node)
		{
			if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (!IsMyNode(node))
            {
                throw new ArgumentException();
            }

            TreeNodeAdv parent = node.Parent;
			while (parent != _root)
			{
				parent.IsExpanded = true;
				parent = parent.Parent;
			}
			ScrollTo(node);
		}

        // Сделайте узел видимым, при необходимости прокрутите его. Все родительские узлы указанного узла должны быть развернуты.
        public void ScrollTo(TreeNodeAdv node)
		{
			if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            if (!IsMyNode(node))
            {
                throw new ArgumentException();
            }
            if (node.Row < 0)
            {
                CreateRowMap();
            }

            int row = -1;

			if (node.Row < FirstVisibleRow)
            {
                row = node.Row;
            }
            else
			{
				int pageStart = _rowLayout.GetRowBounds(FirstVisibleRow).Top;
				int rowBottom = _rowLayout.GetRowBounds(node.Row).Bottom;
				if (rowBottom > pageStart + DisplayRectangle.Height - ColumnHeaderHeight)
                {
                    row = _rowLayout.GetFirstRow(node.Row);
                }
            }

			if (row >= _vScrollBar.Minimum && row <= _vScrollBar.Maximum)
            {
                _vScrollBar.Value = row;
            }
        }

		public void ClearSelection()
		{
			BeginUpdate();
			try
			{
				ClearSelectionInternal();
			}
			finally
			{
				EndUpdate();
			}
		}

		internal void ClearSelectionInternal()
		{
			while (Selection.Count > 0)
			{
				var t = Selection[0];
				t.IsSelected = false;
				Selection.Remove(t); // Трюк.
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			ArrangeControls();
			SafeUpdateScrollBars();
			base.OnSizeChanged(e);
		}

		private void ArrangeControls()
		{
			int hBarSize = _hScrollBar.Height;
			int vBarSize = _vScrollBar.Width;
			Rectangle clientRect = ClientRectangle;

			_hScrollBar.SetBounds(clientRect.X, clientRect.Bottom - hBarSize, clientRect.Width - vBarSize, hBarSize);
			_vScrollBar.SetBounds(clientRect.Right - vBarSize, clientRect.Y, vBarSize, clientRect.Height - hBarSize);
		}

		private void SafeUpdateScrollBars()
		{
			if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(UpdateScrollBars));
            }
            else
            {
                UpdateScrollBars();
            }
        }

		private void UpdateScrollBars()
		{
			UpdateVScrollBar();
			UpdateHScrollBar();
			UpdateVScrollBar();
			UpdateHScrollBar();
			_hScrollBar.Width = DisplayRectangle.Width;
			_vScrollBar.Height = DisplayRectangle.Height;
		}

		private void UpdateHScrollBar()
		{
			_hScrollBar.Maximum = ContentWidth;
			_hScrollBar.LargeChange = Math.Max(DisplayRectangle.Width, 0);
			_hScrollBar.SmallChange = 5;
			_hScrollBar.Visible = _hScrollBar.LargeChange < _hScrollBar.Maximum;
			_hScrollBar.Value = Math.Min(_hScrollBar.Value, _hScrollBar.Maximum - _hScrollBar.LargeChange + 1);
		}

		private void UpdateVScrollBar()
		{
			_vScrollBar.Maximum = Math.Max(RowCount - 1, 0);
			_vScrollBar.LargeChange = _rowLayout.PageRowCount;
			_vScrollBar.Visible = (RowCount > 0) && (_vScrollBar.LargeChange <= _vScrollBar.Maximum);
			_vScrollBar.Value = Math.Min(_vScrollBar.Value, _vScrollBar.Maximum - _vScrollBar.LargeChange + 1);
		}

		protected override CreateParams CreateParams
		{
			[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
			get
			{
				CreateParams res = base.CreateParams;
				switch (BorderStyle)
				{
					case BorderStyle.FixedSingle:
						res.Style |= 0x800000;
						break;
					case BorderStyle.Fixed3D:
						res.ExStyle |= 0x200;
						break;
				}
				return res;
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			UpdateView();
			ChangeInput();
			base.OnGotFocus(e);
		}

		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			_measureContext.Font = Font;
			FullUpdate();
		}

		internal IEnumerable<NodeControlInfo> GetNodeControls(TreeNodeAdv node)
		{
			if (node == null)
            {
                yield break;
            }
            Rectangle rowRect = _rowLayout.GetRowBounds(node.Row);
			foreach (NodeControlInfo n in GetNodeControls(node, rowRect))
            {
                yield return n;
            }
        }

		internal IEnumerable<NodeControlInfo> GetNodeControls(TreeNodeAdv node, Rectangle rowRect)
		{
			if (node == null)
            {
                yield break;
            }

            int y = rowRect.Y;
			int x = (node.Level - 1) * _indent + LeftMargin;
			int width = 0;
			if (node.Row == 0 && ShiftFirstNode)
            {
                x -= _indent;
            }
            Rectangle rect = Rectangle.Empty;

			if (ShowPlusMinus)
			{
				width = _plusMinus.GetActualSize(node, _measureContext).Width;
				rect = new Rectangle(x, y, width, rowRect.Height);
				if (UseColumns && Columns.Count > 0 && Columns[0].Width < rect.Right)
                {
                    rect.Width = Columns[0].Width - x;
                }

                yield return new NodeControlInfo(_plusMinus, rect, node);
				x += width;
			}

			if (!UseColumns)
			{
				foreach (NodeControl c in NodeControls)
				{
					Size s = c.GetActualSize(node, _measureContext);
					if (!s.IsEmpty)
					{
						width = s.Width;
						rect = new Rectangle(x, y, width, rowRect.Height);
						x += rect.Width;
						yield return new NodeControlInfo(c, rect, node);
					}
				}
			}
			else
			{
				int right = 0;
				foreach (TreeColumn col in Columns)
				{
					if (col.IsVisible && col.Width > 0)
					{
						right += col.Width;
						for (int i = 0; i < NodeControls.Count; i++)
						{
							NodeControl nc = NodeControls[i];
							if (nc.ParentColumn == col)
							{
								Size s = nc.GetActualSize(node, _measureContext);
								if (!s.IsEmpty)
								{
									bool isLastControl = true;
									for (int k = i + 1; k < NodeControls.Count; k++)
										if (NodeControls[k].ParentColumn == col)
										{
											isLastControl = false;
											break;
										}

									width = right - x;
									if (!isLastControl)
                                    {
                                        width = s.Width;
                                    }
                                    int maxWidth = Math.Max(0, right - x);
									rect = new Rectangle(x, y, Math.Min(maxWidth, width), rowRect.Height);
									x += width;
									yield return new NodeControlInfo(nc, rect, node);
								}
							}
						}
						x = right;
					}
				}
			}
		}

		internal static double Dist(Point p1, Point p2)
		{
			return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
		}

		public void FullUpdate()
		{
			HideEditor();
			if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(UnsafeFullUpdate));
            }
            else
            {
                UnsafeFullUpdate();
            }
        }

		private void UnsafeFullUpdate()
		{
			_rowLayout.ClearCache();
			CreateRowMap();
			SafeUpdateScrollBars();
			UpdateView();
			_needFullUpdate = false;
		}

		internal void UpdateView()
		{
			if (!_suspendUpdate)
            {
                Invalidate(false);
            }
        }

		internal void UpdateHeaders()
		{
			Invalidate(new Rectangle(0, 0, Width, ColumnHeaderHeight));
		}

		internal void UpdateColumns()
		{
			FullUpdate();
		}

		private void CreateNodes()
		{
			Selection.Clear();
			SelectionStart = null;
			_root = new TreeNodeAdv(this, null);
			_root.IsExpanded = true;
			if (_root.Nodes.Count > 0)
            {
                CurrentNode = _root.Nodes[0];
            }
            else
            {
                CurrentNode = null;
            }
        }

		internal void ReadChilds(TreeNodeAdv parentNode)
		{
			ReadChilds(parentNode, false);
		}

		internal void ReadChilds(TreeNodeAdv parentNode, bool performFullUpdate)
		{
			if (!parentNode.IsLeaf)
			{
				parentNode.IsExpandedOnce = true;
				parentNode.Nodes.Clear();

				if (Model != null)
				{
					IEnumerable items = Model.GetChildren(GetPath(parentNode));
					if (items != null)
                    {
                        foreach (object obj in items)
                        {
                            AddNewNode(parentNode, obj, -1);
                            if (performFullUpdate)
                            {
                                FullUpdate();
                            }
                        }
                    }
                }

				if (parentNode.AutoExpandOnStructureChanged)
                {
                    parentNode.ExpandAll();
                }
            }
		}

		private void AddNewNode(TreeNodeAdv parent, object tag, int index)
		{
			TreeNodeAdv node = new TreeNodeAdv(this, tag);
			AddNode(parent, index, node);
		}

		private void AddNode(TreeNodeAdv parent, int index, TreeNodeAdv node)
		{
			if (index >= 0 && index < parent.Nodes.Count)
            {
                parent.Nodes.Insert(index, node);
            }
            else
            {
                parent.Nodes.Add(node);
            }

            node.IsLeaf = Model.IsLeaf(GetPath(node));
			if (node.IsLeaf)
            {
                node.Nodes.Clear();
            }
            if (!LoadOnDemand || node.IsExpandedOnce)
            {
                ReadChilds(node);
            }
        }

		private struct ExpandArgs
		{
			public TreeNodeAdv Node;
			public bool Value;
			public bool IgnoreChildren;
		}

		public void AbortBackgroundExpandingThreads()
		{
			_threadPool.CancelAll(true);
			for (int i = 0; i < _expandingNodes.Count; i++)
            {
                _expandingNodes[i].IsExpandingNow = false;
            }
            _expandingNodes.Clear();
			Invalidate();
		}

		internal void SetIsExpanded(TreeNodeAdv node, bool value, bool ignoreChildren)
		{
			ExpandArgs eargs = new ExpandArgs();
			eargs.Node = node;
			eargs.Value = value;
			eargs.IgnoreChildren = ignoreChildren;

			if (AsyncExpanding && LoadOnDemand && !_threadPool.IsMyThread(Thread.CurrentThread))
			{
				WaitCallback wc = delegate(object argument) { SetIsExpanded((ExpandArgs)argument); };
				_threadPool.QueueUserWorkItem(wc, eargs);
			}
            else
            {
                SetIsExpanded(eargs);
            }
        }

		private void SetIsExpanded(ExpandArgs eargs)
		{
			bool update = !eargs.IgnoreChildren && !AsyncExpanding;
			if (update)
            {
                BeginUpdate();
            }
            try
			{
				if (IsMyNode(eargs.Node) && eargs.Node.IsExpanded != eargs.Value)
                {
                    SetIsExpanded(eargs.Node, eargs.Value);
                }
                if (!eargs.IgnoreChildren)
                {
                    SetIsExpandedRecursive(eargs.Node, eargs.Value);
                }
            }
			finally
			{
				if (update)
                {
                    EndUpdate();
                }
            }
		}

		internal void SetIsExpanded(TreeNodeAdv node, bool value)
		{
			if (Root == node && !value)
            {
                return; // Не удается свернуть корневой узел.
            }

            if (value)
			{
				OnExpanding(node);
				node.OnExpanding();
			}
			else
			{
				OnCollapsing(node);
				node.OnCollapsing();
			}

			if (value && !node.IsExpandedOnce)
			{
				if (AsyncExpanding && LoadOnDemand)
				{
					AddExpandingNode(node);
					node.AssignIsExpanded(true);
					Invalidate();
				}
				ReadChilds(node, AsyncExpanding);
				RemoveExpandingNode(node);
			}
			node.AssignIsExpanded(value);
			SmartFullUpdate();

			if (value)
			{
				OnExpanded(node);
				node.OnExpanded();
			}
			else
			{
				OnCollapsed(node);
				node.OnCollapsed();
			}
		}

		private void RemoveExpandingNode(TreeNodeAdv node)
		{
			node.IsExpandingNow = false;
			_expandingNodes.Remove(node);
			if (_expandingNodes.Count <= 0)
            {
                ExpandingIcon.Stop();
            }
        }

		private void AddExpandingNode(TreeNodeAdv node)
		{
			node.IsExpandingNow = true;
			_expandingNodes.Add(node);
			ExpandingIcon.Start();
		}

		internal void SetIsExpandedRecursive(TreeNodeAdv root, bool value)
		{
			for (int i = 0; i < root.Nodes.Count; i++)
			{
				TreeNodeAdv node = root.Nodes[i];
				node.IsExpanded = value;
				SetIsExpandedRecursive(node, value);
			}
		}

		private void CreateRowMap()
		{
			RowMap.Clear();
			int row = 0;
			_contentWidth = 0;
			foreach (TreeNodeAdv node in VisibleNodes)
			{
				node.Row = row;
				RowMap.Add(node);
				if (!UseColumns)
				{
					_contentWidth = Math.Max(_contentWidth, GetNodeWidth(node));
				}
				row++;
			}
			if (UseColumns)
			{
				_contentWidth = 0;
				foreach (TreeColumn col in _columns)
                {
                    if (col.IsVisible)
                    {
                        _contentWidth += col.Width;
                    }
                }
            }
		}

		private int GetNodeWidth(TreeNodeAdv node)
		{
			if (node.RightBounds == null)
			{
				Rectangle res = GetNodeBounds(GetNodeControls(node, Rectangle.Empty));
				node.RightBounds = res.Right;
			}
			return node.RightBounds.Value;
		}

		internal Rectangle GetNodeBounds(TreeNodeAdv node)
		{
			return GetNodeBounds(GetNodeControls(node));
		}

		private Rectangle GetNodeBounds(IEnumerable<NodeControlInfo> nodeControls)
		{
			Rectangle res = Rectangle.Empty;
			foreach (NodeControlInfo info in nodeControls)
			{
				if (res == Rectangle.Empty)
                {
                    res = info.Bounds;
                }
                else
                {
                    res = Rectangle.Union(res, info.Bounds);
                }
            }
			return res;
		}

		private void _vScrollBar_ValueChanged(object sender, EventArgs e)
		{
			FirstVisibleRow = _vScrollBar.Value;
		}

		private void _hScrollBar_ValueChanged(object sender, EventArgs e)
		{
			OffsetX = _hScrollBar.Value;
		}

		private void _vScrollBar_Scroll(object sender, ScrollEventArgs e)
		{
			OnScroll(e);
		}

		private void _hScrollBar_Scroll(object sender, ScrollEventArgs e)
		{
			OnScroll(e);
		}

		internal void SmartFullUpdate()
		{
			if (_suspendUpdate)
            {
                _needFullUpdate = true;
            }
            else
            {
                FullUpdate();
            }
        }

		internal bool IsMyNode(TreeNodeAdv node)
		{
			if (node == null)
            {
                return false;
            }

            if (node.Tree != this)
            {
                return false;
            }

            while (node.Parent != null)
            {
                node = node.Parent;
            }

            return node == _root;
		}

		internal void UpdateSelection()
		{
			bool flag = false;

			if (!IsMyNode(CurrentNode))
            {
                CurrentNode = null;
            }
            if (!IsMyNode(_selectionStart))
            {
                _selectionStart = null;
            }

            for (int i = Selection.Count - 1; i >= 0; i--)
            {
                if (!IsMyNode(Selection[i]))
                {
                    flag = true;
                    Selection.RemoveAt(i);
                }
            }

            if (flag)
            {
                OnSelectionChanged();
            }
        }

		internal void ChangeColumnWidth(TreeColumn column)
		{
			if (!(_input is ResizeColumnState))
			{
				FullUpdate();
				OnColumnWidthChanged(column);
			}
		}

		public TreeNodeAdv FindNode(TreePath path)
		{
			return FindNode(path, false);
		}

		public TreeNodeAdv FindNode(TreePath path, bool readChilds)
		{
			if (path.IsEmpty())
            {
                return _root;
            }
            else
            {
                return FindNode(_root, path, 0, readChilds);
            }
        }

		private TreeNodeAdv FindNode(TreeNodeAdv root, TreePath path, int level, bool readChilds)
		{
			if (!root.IsExpandedOnce && readChilds)
            {
                ReadChilds(root);
            }

            for (int i = 0; i < root.Nodes.Count; i++)
			{
				TreeNodeAdv node = root.Nodes[i];
				if (node.Tag == path.FullPath[level])
				{
					if (level == path.FullPath.Length - 1)
                    {
                        return node;
                    }
                    else
                    {
                        return FindNode(node, path, level + 1, readChilds);
                    }
                }
			}
			return null;
		}

		public TreeNodeAdv FindNodeByTag(object tag)
		{
			return FindNodeByTag(_root, tag);
		}

		private TreeNodeAdv FindNodeByTag(TreeNodeAdv root, object tag)
		{
			foreach (TreeNodeAdv node in root.Nodes)
			{
				if (node.Tag == tag)
                {
                    return node;
                }
                TreeNodeAdv res = FindNodeByTag(node, tag);
				if (res != null)
                {
                    return res;
                }
            }
			return null;
		}

		public void SelectAllNodes()
		{
			SuspendSelectionEvent = true;
			try
			{
				if (SelectionMode == TreeSelectionMode.MultiSameParent)
				{
					if (CurrentNode != null)
					{
						foreach (TreeNodeAdv n in CurrentNode.Parent.Nodes)
                        {
                            n.IsSelected = true;
                        }
                    }
				}
				else if (SelectionMode == TreeSelectionMode.Multi)
				{
					SelectNodes(Root.Nodes);
				}
			}
			finally
			{
				SuspendSelectionEvent = false;
			}
		}

		private void SelectNodes(Collection<TreeNodeAdv> nodes)
		{
			foreach (TreeNodeAdv n in nodes)
			{
				n.IsSelected = true;
				if (n.IsExpanded)
                {
                    SelectNodes(n.Nodes);
                }
            }
		}

		private void BindModelEvents()
		{
			_model.NodesChanged += new EventHandler<TreeModelEventArgs>(_model_NodesChanged);
			_model.NodesInserted += new EventHandler<TreeModelEventArgs>(_model_NodesInserted);
			_model.NodesRemoved += new EventHandler<TreeModelEventArgs>(_model_NodesRemoved);
			_model.StructureChanged += new EventHandler<TreePathEventArgs>(_model_StructureChanged);
		}

		private void UnbindModelEvents()
		{
			_model.NodesChanged -= new EventHandler<TreeModelEventArgs>(_model_NodesChanged);
			_model.NodesInserted -= new EventHandler<TreeModelEventArgs>(_model_NodesInserted);
			_model.NodesRemoved -= new EventHandler<TreeModelEventArgs>(_model_NodesRemoved);
			_model.StructureChanged -= new EventHandler<TreePathEventArgs>(_model_StructureChanged);
		}

		private void _model_StructureChanged(object sender, TreePathEventArgs e)
		{
			if (e.Path == null)
            {
                throw new ArgumentNullException();
            }

            TreeNodeAdv node = FindNode(e.Path);
			if (node != null)
			{
				if (node != Root)
                {
                    node.IsLeaf = Model.IsLeaf(GetPath(node));
                }

                var list = new Dictionary<object, object>();
				SaveExpandedNodes(node, list);
				ReadChilds(node);
				RestoreExpandedNodes(node, list);

				UpdateSelection();
				SmartFullUpdate();
			}
			//else 
			//	throw new ArgumentException("Path not found");
		}

		private void RestoreExpandedNodes(TreeNodeAdv node, Dictionary<object, object> list)
		{
			if (node.Tag != null && list.ContainsKey(node.Tag))
			{
				node.IsExpanded = true;
				foreach (var child in node.Children)
                {
                    RestoreExpandedNodes(child, list);
                }
            }
		}

		private void SaveExpandedNodes(TreeNodeAdv node, Dictionary<object, object> list)
		{
			if (node.IsExpanded && node.Tag != null)
			{
				list.Add(node.Tag, null);
				foreach (var child in node.Children)
                {
                    SaveExpandedNodes(child, list);
                }
            }
		}

		private void _model_NodesRemoved(object sender, TreeModelEventArgs e)
		{
			TreeNodeAdv parent = FindNode(e.Path);
			if (parent != null)
			{
				if (e.Indices != null)
				{
					List<int> list = new List<int>(e.Indices);
					list.Sort();
					for (int n = list.Count - 1; n >= 0; n--)
					{
						int index = list[n];
						if (index >= 0 && index <= parent.Nodes.Count)
                        {
                            parent.Nodes.RemoveAt(index);
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("Index out of range");
                        }
                    }
				}
				else
				{
					for (int i = parent.Nodes.Count - 1; i >= 0; i--)
					{
						for (int n = 0; n < e.Children.Length; n++)
                        {
                            if (parent.Nodes[i].Tag == e.Children[n])
                            {
                                parent.Nodes.RemoveAt(i);
                                break;
                            }
                        }
                    }
				}
			}
			UpdateSelection();
			SmartFullUpdate();
		}

		private void _model_NodesInserted(object sender, TreeModelEventArgs e)
		{
			if (e.Indices == null)
            {
                throw new ArgumentNullException("Indices");
            }

            TreeNodeAdv parent = FindNode(e.Path);
			if (parent != null)
			{
				for (int i = 0; i < e.Children.Length; i++)
                {
                    AddNewNode(parent, e.Children[i], e.Indices[i]);
                }
            }
			SmartFullUpdate();
		}

		private void _model_NodesChanged(object sender, TreeModelEventArgs e)
		{
			TreeNodeAdv parent = FindNode(e.Path);
			if (parent != null && parent.IsVisible && parent.IsExpanded)
			{
				if (InvokeRequired)
                {
                    BeginInvoke(new UpdateContentWidthDelegate(ClearNodesSize), e, parent);
                }
                else
                {
                    ClearNodesSize(e, parent);
                }
                SmartFullUpdate();
			}
		}

		private void ClearNodesSize(TreeModelEventArgs e, TreeNodeAdv parent)
		{
			if (e.Indices != null)
			{
				foreach (int index in e.Indices)
				{
					if (index >= 0 && index < parent.Nodes.Count)
					{
						TreeNodeAdv node = parent.Nodes[index];
						node.Height = node.RightBounds = null;
					}
                    else
                    {
                        throw new ArgumentOutOfRangeException("Index out of range");
                    }
                }
			}
			else
			{
				foreach (TreeNodeAdv node in parent.Nodes)
				{
					foreach (object obj in e.Children)
                    {
                        if (node.Tag == obj)
                        {
                            node.Height = node.RightBounds = null;
                        }
                    }
                }
			}
		}

        public void HideEditor()
        {
            if (CurrentEditorOwner != null)
            {
                CurrentEditorOwner.EndEdit(false);
            }
        }

        internal void DisplayEditor(Control editor, EditableControl owner)
        {
            if (editor == null || owner == null || CurrentNode == null)
            {
                throw new ArgumentNullException();
            }

            HideEditor(false);

            CurrentEditor = editor;
            CurrentEditorOwner = owner;
            _editingNode = CurrentNode;

            editor.Validating += EditorValidating;
            UpdateEditorBounds();
            UpdateView();
            editor.Parent = this;
            editor.Focus();
            owner.UpdateEditor(editor);
        }

        internal bool HideEditor(bool applyChanges)
        {
            if (CurrentEditor != null)
            {
                if (applyChanges)
                {
                    if (!ApplyChanges())
                    {
                        return false;
                    }
                }

                // Проверьте еще раз, был ли редактор закрыт в ApplyChanges.
                if (CurrentEditor != null)
                {
                    CurrentEditor.Validating -= EditorValidating;
                    CurrentEditorOwner.DoDisposeEditor(CurrentEditor);

                    CurrentEditor.Parent = null;
                    CurrentEditor.Dispose();

                    CurrentEditor = null;
                    CurrentEditorOwner = null;
                    _editingNode = null;
                }
            }
            return true;
        }

        private bool ApplyChanges()
        {
            try
            {
                CurrentEditorOwner.ApplyChanges(_editingNode, CurrentEditor);
                _errorProvider.Clear();
                return true;
            }
            catch (ArgumentException ex)
            {
                _errorProvider.SetError(CurrentEditor, ex.Message);
                /*CurrentEditor.Validating -= EditorValidating;
				MessageBox.Show(this, ex.Message, "Value is not valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				CurrentEditor.Focus();
				CurrentEditor.Validating += EditorValidating;*/
                return false;
            }
        }

        void EditorValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !ApplyChanges();
        }

        public void UpdateEditorBounds()
        {
            if (CurrentEditor != null)
            {
                EditorContext context = new EditorContext();
                context.Owner = CurrentEditorOwner;
                context.CurrentNode = CurrentNode;
                context.Editor = CurrentEditor;
                context.DrawContext = _measureContext;
                SetEditorBounds(context);
            }
        }

        private void SetEditorBounds(EditorContext context)
        {
            foreach (NodeControlInfo info in GetNodeControls(context.CurrentNode))
            {
                if (context.Owner == info.Control && info.Control is EditableControl)
                {
                    Point p = info.Bounds.Location;
                    p.X += info.Control.LeftMargin;
                    p.X -= OffsetX;
                    p.Y -= (_rowLayout.GetRowBounds(FirstVisibleRow).Y - ColumnHeaderHeight);
                    int width = DisplayRectangle.Width - p.X;
                    if (UseColumns && info.Control.ParentColumn != null && Columns.Contains(info.Control.ParentColumn))
                    {
                        Rectangle rect = GetColumnBounds(info.Control.ParentColumn.Index);
                        width = rect.Right - OffsetX - p.X;
                    }
                    context.Bounds = new Rectangle(p.X, p.Y, width, info.Bounds.Height);
                    ((EditableControl)info.Control).SetEditorBounds(context);
                    return;
                }
            }
        }

        private Rectangle GetColumnBounds(int column)
        {
            int x = 0;
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].IsVisible)
                {
                    if (i < column)
                    {
                        x += Columns[i].Width;
                    }
                    else
                    {
                        return new Rectangle(x, 0, Columns[i].Width, 0);
                    }
                }
            }
            return Rectangle.Empty;
        }

        protected override bool IsInputChar(char charCode)
        {
            return true;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (((keyData & Keys.Up) == Keys.Up) ||
                ((keyData & Keys.Down) == Keys.Down) ||
                ((keyData & Keys.Left) == Keys.Left) ||
                ((keyData & Keys.Right) == Keys.Right))
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }

        internal void ChangeInput()
        {
            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                if (!(Input is InputWithShift))
                {
                    Input = new InputWithShift(this);
                }
            }
            else if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (!(Input is InputWithControl))
                {
                    Input = new InputWithControl(this);
                }
            }
            else
            {
                if (!(Input.GetType() == typeof(NormalInputState)))
                {
                    Input = new NormalInputState(this);
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!e.Handled)
            {
                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey)
                {
                    ChangeInput();
                }
                Input.KeyDown(e);
                if (!e.Handled)
                {
                    foreach (NodeControlInfo item in GetNodeControls(CurrentNode))
                    {
                        item.Control.KeyDown(e);
                        if (e.Handled)
                        {
                            break;
                        }
                    }
                }
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (!e.Handled)
            {
                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey)
                {
                    ChangeInput();
                }
                if (!e.Handled)
                {
                    foreach (NodeControlInfo item in GetNodeControls(CurrentNode))
                    {
                        item.Control.KeyUp(e);
                        if (e.Handled)
                        {
                            return;
                        }
                    }
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (!e.Handled)
            {
                _search.Search(e.KeyChar);
            }
        }

        private TreeNodeAdvMouseEventArgs CreateMouseArgs(MouseEventArgs e)
        {
            TreeNodeAdvMouseEventArgs args = new TreeNodeAdvMouseEventArgs(e);
            args.ViewLocation = new Point(e.X + OffsetX, e.Y + _rowLayout.GetRowBounds(FirstVisibleRow).Y - ColumnHeaderHeight);
            args.ModifierKeys = ModifierKeys;
            args.Node = GetNodeAt(e.Location);
            NodeControlInfo info = GetNodeControlInfoAt(args.Node, e.Location);
            args.ControlBounds = info.Bounds;
            args.Control = info.Control;
            return args;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            _search.EndSearch();
            if (SystemInformation.MouseWheelScrollLines > 0)
            {
                int lines = e.Delta / 120 * SystemInformation.MouseWheelScrollLines;
                int newValue = _vScrollBar.Value - lines;
                newValue = Math.Min(_vScrollBar.Maximum - _vScrollBar.LargeChange + 1, newValue);
                newValue = Math.Min(_vScrollBar.Maximum, newValue);
                _vScrollBar.Value = Math.Max(_vScrollBar.Minimum, newValue);
            }
            base.OnMouseWheel(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (CurrentEditorOwner != null)
            {
                CurrentEditorOwner.EndEdit(true);
                return;
            }

            if (!Focused)
            {
                Focus();
            }

            _search.EndSearch();
            if (e.Button == MouseButtons.Left)
            {
                TreeColumn c;
                c = GetColumnDividerAt(e.Location);
                if (c != null)
                {
                    Input = new ResizeColumnState(this, c, e.Location);
                    return;
                }
                c = GetColumnAt(e.Location);
                if (c != null)
                {
                    Input = new ClickColumnState(this, c, e.Location);
                    UpdateView();
                    return;
                }
            }

            ChangeInput();
            TreeNodeAdvMouseEventArgs args = CreateMouseArgs(e);

            if (args.Node != null && args.Control != null)
            {
                args.Control.MouseDown(args);
            }

            if (!args.Handled)
            {
                Input.MouseDown(args);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            // ЗАДАЧА: Отключить при нажатии на значок plusminus.
            TreeNodeAdvMouseEventArgs args = CreateMouseArgs(e);
            if (args.Node != null)
            {
                OnNodeMouseClick(args);
            }
            base.OnMouseClick(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            TreeNodeAdvMouseEventArgs args = CreateMouseArgs(e);

            if (args.Node != null && args.Control != null)
            {
                args.Control.MouseDoubleClick(args);
            }

            if (!args.Handled)
            {
                if (args.Node != null)
                {
                    OnNodeMouseDoubleClick(args);
                }
                else
                {
                    Input.MouseDoubleClick(args);
                }

                if (!args.Handled)
                {
                    if (args.Node != null && args.Button == MouseButtons.Left)
                    {
                        args.Node.IsExpanded = !args.Node.IsExpanded;
                    }
                }
            }
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            TreeNodeAdvMouseEventArgs args = CreateMouseArgs(e);
            if (Input is ResizeColumnState)
            {
                Input.MouseUp(args);
            }
            else
            {
                if (args.Node != null && args.Control != null)
                {
                    args.Control.MouseUp(args);
                }
                if (!args.Handled)
                {
                    Input.MouseUp(args);
                }
                base.OnMouseUp(e);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Input.MouseMove(e))
            {
                return;
            }

            base.OnMouseMove(e);
            SetCursor(e);
            UpdateToolTip(e);
            if (ItemDragMode && Dist(e.Location, ItemDragStart) > ItemDragSensivity && CurrentNode != null && CurrentNode.IsSelected)
            {
                ItemDragMode = false;
                _toolTip.Active = false;
                OnItemDrag(e.Button, Selection.ToArray());
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hotColumn = null;
            UpdateHeaders();
            base.OnMouseLeave(e);
        }

        private void SetCursor(MouseEventArgs e)
        {
            TreeColumn col;
            col = GetColumnDividerAt(e.Location);
            if (col == null)
            {
                _innerCursor = null;
            }
            else
            {
                if (col.Width == 0)
                {
                    _innerCursor = Aga.Controls.Tree.TreeViewAdv.DVSplitCursor;
                }
                else
                {
                    _innerCursor = Cursors.VSplit;
                }
            }

            col = GetColumnAt(e.Location);
            if (col != _hotColumn)
            {
                _hotColumn = col;
                UpdateHeaders();
            }
        }

        internal TreeColumn GetColumnAt(Point p)
        {
            if (p.Y > ColumnHeaderHeight)
            {
                return null;
            }

            int x = -OffsetX;
            foreach (TreeColumn col in Columns)
            {
                if (col.IsVisible)
                {
                    Rectangle rect = new Rectangle(x, 0, col.Width, ColumnHeaderHeight);
                    x += col.Width;
                    if (rect.Contains(p))
                    {
                        return col;
                    }
                }
            }
            return null;
        }

        internal int GetColumnX(TreeColumn column)
        {
            int x = -OffsetX;
            foreach (TreeColumn col in Columns)
            {
                if (col.IsVisible)
                {
                    if (column == col)
                    {
                        return x;
                    }
                    else
                    {
                        x += col.Width;
                    }
                }
            }
            return x;
        }

        internal TreeColumn GetColumnDividerAt(Point p)
        {
            if (p.Y > ColumnHeaderHeight)
            {
                return null;
            }

            int x = -OffsetX;
            TreeColumn prevCol = null;
            Rectangle left, right;
            foreach (TreeColumn col in Columns)
            {
                if (col.IsVisible)
                {
                    if (col.Width > 0)
                    {
                        left = new Rectangle(x, 0, DividerWidth / 2, ColumnHeaderHeight);
                        right = new Rectangle(x + col.Width - (DividerWidth / 2), 0, DividerWidth / 2, ColumnHeaderHeight);
                        if (left.Contains(p) && prevCol != null)
                        {
                            return prevCol;
                        }
                        else if (right.Contains(p))
                        {
                            return col;
                        }
                    }
                    prevCol = col;
                    x += col.Width;
                }
            }

            left = new Rectangle(x, 0, DividerWidth / 2, ColumnHeaderHeight);
            if (left.Contains(p) && prevCol != null)
            {
                return prevCol;
            }
            return null;
        }

        private void UpdateToolTip(MouseEventArgs e)
        {
            if (!ShowNodeToolTips)
            {
                return;
            }

            NodeControlInfo nodeControlInfo = GetNodeControlInfoAt(e.Location);
            NodeControl nodeControl = nodeControlInfo.Control;
            TreeNodeAdv treeNodeAdv = nodeControlInfo.Node;
            TreeColumn col = GetColumnAt(e.Location);

            if (col != null)
            {
                // курсор находится на заголовке колонки
                if (col != _tooltipColumn)
                {
                    dynamic colTooltipText = col.TooltipText;
                    if (colTooltipText != null)
                    {
                        if (colTooltipText.GetType() == typeof(osf.ClAction))
                        {
                            osf.ClAction ClAction1 = (osf.ClAction)colTooltipText;
                            IRuntimeContextInstance script = ClAction1.Script;
                            string method = ClAction1.MethodName;
                            ScriptEngine.HostedScript.Library.ArrayImpl ArrayImpl1 = new ScriptEngine.HostedScript.Library.ArrayImpl();
                            ArrayImpl1.Add(ClAction1.Parameter);
                            ScriptEngine.HostedScript.Library.ReflectorContext reflector = new ScriptEngine.HostedScript.Library.ReflectorContext();

                            foreach (KeyValuePair<osf.ClToolTip, object> keyValue in col.ObjTooltip)
                            {
                                if (keyValue.Value.Equals(colTooltipText))
                                {
                                    osf.ClToolTip ClToolTip1 = keyValue.Key;
                                    if (ClToolTip1.Active)
                                    {
                                        _toolTip = ClToolTip1.Base_obj.M_ToolTip;
                                        SetTooltip(reflector.CallMethod(script, method, ArrayImpl1).AsString());
                                    }
                                }
                            }
                        }
                        else if (colTooltipText.GetType() == typeof(string))
                        {
                            foreach (KeyValuePair<osf.ClToolTip, object> keyValue in col.ObjTooltip)
                            {
                                if (keyValue.Value.Equals(colTooltipText))
                                {
                                    osf.ClToolTip ClToolTip1 = keyValue.Key;
                                    if (ClToolTip1.Active)
                                    {
                                        _toolTip = ClToolTip1.Base_obj.M_ToolTip;
                                        SetTooltip((string)colTooltipText);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (treeNodeAdv != null && nodeControl != null)
            {
                // курсор находится в табличной части на элементе и одновременно на узле
                Node node = (Node)treeNodeAdv.Tag;
                dynamic tooltipText = null;
                dynamic obj = null;

                if (treeNodeAdv != _tooltipTreeNodeAdv || nodeControl != _tooltipNodeControl)
                {
                    if (node.TooltipText != null)
                    {
                        tooltipText = node.TooltipText;
                        obj = node;
                    }
                    if (nodeControl.TooltipText != null)
                    {
                        tooltipText = nodeControl.TooltipText;
                        obj = nodeControl;
                    }
                }

                if (tooltipText != null)
                {
                    if (tooltipText.GetType() == typeof(osf.ClAction))
                    {
                        osf.ClAction ClAction1 = (osf.ClAction)tooltipText;
                        IRuntimeContextInstance script = ClAction1.Script;
                        string method = ClAction1.MethodName;
                        ScriptEngine.HostedScript.Library.ArrayImpl ArrayImpl1 = new ScriptEngine.HostedScript.Library.ArrayImpl();
                        ArrayImpl1.Add(ClAction1.Parameter);
                        ScriptEngine.HostedScript.Library.ReflectorContext reflector = new ScriptEngine.HostedScript.Library.ReflectorContext();

                        foreach (KeyValuePair<osf.ClToolTip, object> keyValue in obj.ObjTooltip)
                        {
                            if (keyValue.Value.Equals(tooltipText))
                            {
                                osf.ClToolTip ClToolTip1 = keyValue.Key;
                                if (ClToolTip1.Active)
                                {
                                    _toolTip = ClToolTip1.Base_obj.M_ToolTip;
                                    SetTooltip(reflector.CallMethod(script, method, ArrayImpl1).AsString());
                                }
                            }
                        }
                    }
                    else if (tooltipText.GetType() == typeof(string))
                    {
                        if (tooltipText == "")
                        {
                            SetTooltip((string)tooltipText);
                        }
                        foreach (KeyValuePair<osf.ClToolTip, object> keyValue in obj.ObjTooltip)
                        {
                            if (keyValue.Value.Equals(tooltipText))
                            {
                                osf.ClToolTip ClToolTip1 = keyValue.Key;
                                if (ClToolTip1.Active)
                                {
                                    _toolTip = ClToolTip1.Base_obj.M_ToolTip;
                                    SetTooltip((string)tooltipText);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // курсор находится вне табличной части или заголовка колонки
                DisplayNodesTooltip(e);
            }
            _tooltipColumn = col;
            _tooltipNodeControl = nodeControl;
            _tooltipTreeNodeAdv = treeNodeAdv;
        }

        private void DisplayNodesTooltip(MouseEventArgs e)
        {
            if (ShowNodeToolTips)
            {
                TreeNodeAdvMouseEventArgs args = CreateMouseArgs(e);
                if (args.Node != null && args.Control != null)
                {
                    if (args.Node != _hotNode || args.Control != _hotControl)
                    {
                        SetTooltip(GetNodeToolTip(args));
                    }
                }
                else
                {
                    _toolTip.SetToolTip(this, null);
                }
                _hotControl = args.Control;
                _hotNode = args.Node;
            }
            else
            {
                _toolTip.SetToolTip(this, null);
            }
        }

        private void SetTooltip(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                _toolTip.Active = false;
                _toolTip.SetToolTip(this, text);
                _toolTip.Active = true;
            }
            else
            {
                _toolTip.SetToolTip(this, null);
            }
        }

        private string GetNodeToolTip(TreeNodeAdvMouseEventArgs args)
        {
            string msg = args.Control.GetToolTip(args.Node);

            BaseTextControl btc = args.Control as BaseTextControl;
            if (btc != null && btc.DisplayHiddenContentInToolTip && String.IsNullOrEmpty(msg))
            {
                Size ms = btc.GetActualSize(args.Node, _measureContext);
                if (ms.Width > args.ControlBounds.Size.Width || ms.Height > args.ControlBounds.Size.Height || args.ControlBounds.Right - OffsetX > DisplayRectangle.Width)
                {
                    msg = btc.GetLabel(args.Node);
                }
            }

            if (String.IsNullOrEmpty(msg) && DefaultToolTipProvider != null)
            {
                msg = DefaultToolTipProvider.GetToolTip(args.Node, args.Control);
            }
            return msg;
        }

        private void StartDragTimer()
        {
            if (_dragTimer == null)
            {
                _dragTimer = new System.Threading.Timer(new TimerCallback(DragTimerTick), null, 0, 100);
            }
        }

        private void StopDragTimer()
        {
            if (_dragTimer != null)
            {
                _dragTimer.Dispose();
                _dragTimer = null;
            }
        }

        private void SetDropPosition(Point pt)
        {
            TreeNodeAdv node = GetNodeAt(pt);
            OnDropNodeValidating(pt, ref node);
            _dropPosition.Node = node;
            if (node != null)
            {
                Rectangle first = _rowLayout.GetRowBounds(FirstVisibleRow);
                Rectangle bounds = _rowLayout.GetRowBounds(node.Row);
                float pos = (pt.Y + first.Y - ColumnHeaderHeight - bounds.Y) / (float)bounds.Height;
                if (pos < TopEdgeSensivity)
                {
                    _dropPosition.Position = NodePosition.Before;
                }
                else if (pos > (1 - BottomEdgeSensivity))
                {
                    _dropPosition.Position = NodePosition.After;
                }
                else
                {
                    _dropPosition.Position = NodePosition.Inside;
                }
            }
        }

        private void DragTimerTick(object state)
        {
            _dragAutoScrollFlag = true;
        }

        private void DragAutoScroll()
        {
            _dragAutoScrollFlag = false;
            Point pt = PointToClient(MousePosition);
            if (pt.Y < 20 && _vScrollBar.Value > 0)
            {
                _vScrollBar.Value--;
            }
            else if (pt.Y > Height - 20 && _vScrollBar.Value <= _vScrollBar.Maximum - _vScrollBar.LargeChange)
            {
                _vScrollBar.Value++;
            }
        }

        public void DoDragDropSelectedNodes(DragDropEffects allowedEffects)
        {
            if (SelectedNodes.Count > 0)
            {
                TreeNodeAdv[] nodes = new TreeNodeAdv[SelectedNodes.Count];
                SelectedNodes.CopyTo(nodes, 0);
                DoDragDrop(nodes, allowedEffects);
            }
        }

        private void CreateDragBitmap(IDataObject data)
        {
            if (UseColumns || !DisplayDraggingNodes)
            {
                return;
            }

            TreeNodeAdv[] nodes = data.GetData(typeof(TreeNodeAdv[])) as TreeNodeAdv[];
            if (nodes != null && nodes.Length > 0)
            {
                Rectangle rect = DisplayRectangle;
                Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
                using (Graphics gr = Graphics.FromImage(bitmap))
                {
                    gr.Clear(BackColor);
                    DrawContext context = new DrawContext();
                    context.Graphics = gr;
                    context.Font = Font;
                    context.Enabled = true;
                    int y = 0;
                    int maxWidth = 0;
                    foreach (TreeNodeAdv node in nodes)
                    {
                        if (node.Tree == this)
                        {
                            int x = 0;
                            int height = _rowLayout.GetRowBounds(node.Row).Height;
                            foreach (NodeControl c in NodeControls)
                            {
                                Size s = c.GetActualSize(node, context);
                                if (!s.IsEmpty)
                                {
                                    int width = s.Width;
                                    rect = new Rectangle(x, y, width, height);
                                    x += (width + 1);
                                    context.Bounds = rect;
                                    c.Draw(node, context);
                                }
                            }
                            y += height;
                            maxWidth = Math.Max(maxWidth, x);
                        }
                    }

                    if (maxWidth > 0 && y > 0)
                    {
                        _dragBitmap = new Bitmap(maxWidth, y, PixelFormat.Format32bppArgb);
                        using (Graphics tgr = Graphics.FromImage(_dragBitmap))
                        {
                            tgr.DrawImage(bitmap, Point.Empty);
                        }
                        BitmapHelper.SetAlphaChanelValue(_dragBitmap, 150);
                    }
                    else
                    {
                        _dragBitmap = null;
                    }
                }
            }
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            ItemDragMode = false;
            Point pt = PointToClient(new Point(drgevent.X, drgevent.Y));
            if (_dragAutoScrollFlag)
            {
                DragAutoScroll();
            }
            SetDropPosition(pt);
            UpdateView();
            base.OnDragOver(drgevent);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            _search.EndSearch();
            DragMode = true;
            CreateDragBitmap(drgevent.Data);
            base.OnDragEnter(drgevent);
        }

        protected override void OnDragLeave(EventArgs e)
        {
            DragMode = false;
            UpdateView();
            base.OnDragLeave(e);
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            DragMode = false;
            UpdateView();
            base.OnDragDrop(drgevent);
        }

        public override Cursor Cursor
        {
            get
            {
                if (_innerCursor != null)
                {
                    return _innerCursor;
                }
                else
                {
                    return base.Cursor;
                }
            }
            set { base.Cursor = value; }
        }

        private bool DragMode
        {
            get { return _dragMode; }
            set
            {
                _dragMode = value;
                if (!value)
                {
                    StopDragTimer();
                    if (_dragBitmap != null)
                    {
                        _dragBitmap.Dispose();
                    }
                    _dragBitmap = null;
                }
                else
                {
                    StartDragTimer();
                }
            }
        }

        internal int ColumnHeaderHeight
        {
            get
            {
                if (UseColumns)
                {
                    return _columnHeaderHeight;
                }
                else
                {
                    return 0;
                }
            }
        }
		
        public int ColumnHeadersHeight
        {
            get { return _columnHeaderHeight; }
            set
            {
                _columnHeaderHeight = value;
                FullUpdate();
            }
        }

        //public int ColumnHeadersHeight
        //{
        //    get
        //    {
        //        if (UseColumns)
        //        {
        //            return _headerLayout.PreferredHeaderHeight;
        //        }
        //        return 0;
        //    }
        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentOutOfRangeException(nameof(value));
        //        }
        //        _headerLayout.PreferredHeaderHeight = value;
        //        FullUpdate();
        //    }
        //}

        // Возвращает все узлы, родительский элемент которых развернут.
        private IEnumerable<TreeNodeAdv> VisibleNodes
        {
            get
            {
                TreeNodeAdv node = Root;
                while (node != null)
                {
                    node = node.NextVisibleNode;
                    if (node != null)
                    {
                        yield return node;
                    }
                }
            }
        }

        internal bool SuspendSelectionEvent
        {
            get { return _suspendSelectionEvent; }
            set
            {
                if (value != _suspendSelectionEvent)
                {
                    _suspendSelectionEvent = value;
                    if (!_suspendSelectionEvent && _fireSelectionEvent)
                    {
                        OnSelectionChanged();
                    }
                }
            }
        }

        internal List<TreeNodeAdv> RowMap
        {
            get { return _rowMap; }
        }

        internal TreeNodeAdv SelectionStart
        {
            get { return _selectionStart; }
            set { _selectionStart = value; }
        }

        internal InputState Input
        {
            get { return _input; }
            set { _input = value; }
        }

        internal bool ItemDragMode
        {
            get { return _itemDragMode; }
            set { _itemDragMode = value; }
        }

        internal Point ItemDragStart
        {
            get { return _itemDragStart; }
            set { _itemDragStart = value; }
        }


        // Количество строк, подходящих для текущей страницы.
        internal int CurrentPageSize
        {
            get { return _rowLayout.CurrentPageSize; }
        }

        // Количество всех видимых узлов (какой родительский узел развернут).
        internal int RowCount
        {
            get { return RowMap.Count; }
        }

        private int ContentWidth
        {
            get { return _contentWidth; }
        }

        internal int FirstVisibleRow
        {
            get { return _firstVisibleRow; }
            set
            {
                HideEditor();
                _firstVisibleRow = value;
                UpdateView();
            }
        }

        public int OffsetX
        {
            get { return _offsetX; }
            private set
            {
                HideEditor();
                _offsetX = value;
                UpdateView();
            }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle r = ClientRectangle;
                //r.Y += ColumnHeaderHeight;
                //r.Height -= ColumnHeaderHeight;
                int w = _vScrollBar.Visible ? _vScrollBar.Width : 0;
                int h = _hScrollBar.Visible ? _hScrollBar.Height : 0;
                return new Rectangle(r.X, r.Y, r.Width - w, r.Height - h);
            }
        }

        internal List<TreeNodeAdv> Selection
        {
            get { return _selection; }
        }

        public bool ShiftFirstNode
        {
            get { return _shiftFirstNode; }
            set { _shiftFirstNode = value; }
        }

        public bool DisplayDraggingNodes
        {
            get { return _displayDraggingNodes; }
            set { _displayDraggingNodes = value; }
        }

        public bool FullRowSelect
        {
            get { return _fullRowSelect; }
            set
            {
                _fullRowSelect = value;
                UpdateView();
            }
        }

        public bool UseColumns
        {
            get { return _useColumns; }
            set
            {
                _useColumns = value;
                FullUpdate();
            }
        }

        public bool AllowColumnReorder
        {
            get { return _allowColumnReorder; }
            set { _allowColumnReorder = value; }
        }

        public bool ShowLines
        {
            get { return _showLines; }
            set
            {
                _showLines = value;
                UpdateView();
            }
        }

        public bool ShowPlusMinus
        {
            get { return _showPlusMinus; }
            set
            {
                _showPlusMinus = value;
                FullUpdate();
            }
        }

        public bool ShowNodeToolTips
        {
            get { return _showNodeToolTips; }
            set { _showNodeToolTips = value; }
        }

        public bool KeepNodesExpanded
        {
            get { return true; }
            set { }
        }

        // Модель, связанная с этим TreeViewAdv.
        public ITreeModel Model
        {
            get { return _model; }
            set
            {
                if (_model != value)
                {
                    AbortBackgroundExpandingThreads();
                    if (_model != null)
                    {
                        UnbindModelEvents();
                    }
                    _model = value;
                    CreateNodes();
                    FullUpdate();
                    if (_model != null)
                    {
                        BindModelEvents();
                    }
                }
            }
        }

        // Шрифт для отображения содержимого TreeViewAdv.
        public override Font Font
        {
            get { return (base.Font); }
            set
            {
                if (value == null)
                {
                    base.Font = _font;
                }
                else
                {
                    if (value == DefaultFont)
                    {
                        base.Font = _font;
                    }
                    else
                    {
                        base.Font = value;
                    }
                }
            }
        }

        public override void ResetFont()
        {
            Font = null;
        }

        private bool ShouldSerializeFont()
        {
            return (!Font.Equals(_font));
        }

        public BorderStyle BorderStyle
        {
            get { return this._borderStyle; }
            set
            {
                if (_borderStyle != value)
                {
                    _borderStyle = value;
                    base.UpdateStyles();
                }
            }
        }

        // Установите значение true, чтобы увеличить высоту каждой строки, чтобы она соответствовала тексту самого большого столбца.
        public bool AutoRowHeight
        {
            get { return _autoRowHeight; }
            set
            {
                _autoRowHeight = value;
                if (value)
                {
                    _rowLayout = new AutoRowHeightLayout(this, RowHeight);
                }
                else
                {
                    _rowLayout = new FixedRowHeightLayout(this, RowHeight);
                }
                FullUpdate();
            }
        }
		
        public bool AutoHeaderHeight
        {
            get { return _autoHeaderHeight; }
            set
            {
                _autoHeaderHeight = value;
                _headerLayout = !value ? (IHeaderLayout)new FixedHeaderHeightLayout(this, ColumnHeaderHeight) : (IHeaderLayout)new AutoHeaderHeightLayout(this, ColumnHeaderHeight);
                FullUpdate();
            }
        }

        public GridLineStyle GridLineStyle
        {
            get { return _gridLineStyle; }
            set
            {
                if (value != _gridLineStyle)
                {
                    _gridLineStyle = value;
                    UpdateView();
                    OnGridLineStyleChanged();
                }
            }
        }

        public int RowHeight
        {
            get { return _rowHeight; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _rowHeight = value;
                _rowLayout.PreferredRowHeight = value;
                FullUpdate();
            }
        }

        public TreeSelectionMode SelectionMode
        {
            get { return _selectionMode; }
            set { _selectionMode = value; }
        }

        public bool HideSelection
        {
            get { return _hideSelection; }
            set
            {
                _hideSelection = value;
                UpdateView();
            }
        }

        public float TopEdgeSensivity
        {
            get { return _topEdgeSensivity; }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _topEdgeSensivity = value;
            }
        }

        public float BottomEdgeSensivity
        {
            get { return _bottomEdgeSensivity; }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("value should be from 0 to 1");
                }
                _bottomEdgeSensivity = value;
            }
        }

        public bool LoadOnDemand
        {
            get { return _loadOnDemand; }
            set { _loadOnDemand = value; }
        }

        public bool UnloadCollapsedOnReload
        {
            get { return _unloadCollapsedOnReload; }
            set { _unloadCollapsedOnReload = value; }
        }

        public int Indent
        {
            get { return _indent; }
            set
            {
                _indent = value;
                UpdateView();
            }
        }

        public Color LineColor
        {
            get { return _lineColor; }
            set
            {
                _lineColor = value;
                CreateLinePen();
                UpdateView();
            }
        }

        public Color DragDropMarkColor
        {
            get { return _dragDropMarkColor; }
            set
            {
                _dragDropMarkColor = value;
                CreateMarkPen();
            }
        }

        public float DragDropMarkWidth
        {
            get { return _dragDropMarkWidth; }
            set
            {
                _dragDropMarkWidth = value;
                CreateMarkPen();
            }
        }

        public bool HighlightDropPosition
        {
            get { return _highlightDropPosition; }
            set { _highlightDropPosition = value; }
        }

        public TreeColumnCollection Columns
        {
            get { return _columns; }
        }

        public Aga.Controls.Tree.NodeControls.NodeControlsCollection NodeControls
        {
            get { return _controls; }
        }

        // Если установлено значение true, содержимое узла будет считываться в фоновом потоке.
        public bool AsyncExpanding
        {
            get { return _asyncExpanding; }
            set { _asyncExpanding = value; }
        }

        public IToolTipProvider DefaultToolTipProvider
        {
            get { return _defaultToolTipProvider; }
            set { _defaultToolTipProvider = value; }
        }
		
        public Aga.Controls.Tree.TreeNodeAdv.NodeCollection Nodes
        {
            get { return _root.Nodes; }
        }

        public IEnumerable<TreeNodeAdv> AllNodes
        {
            get
            {
                if (_root.Nodes.Count > 0)
                {
                    TreeNodeAdv node = _root.Nodes[0];
                    while (node != null)
                    {
                        yield return node;
                        if (node.Nodes.Count > 0)
                        {
                            node = node.Nodes[0];
                        }
                        else if (node.NextNode != null)
                        {
                            node = node.NextNode;
                        }
                        else
                        {
                            node = node.BottomNode;
                        }
                    }
                }
            }
        }

        public DropPosition DropPosition
        {
            get { return _dropPosition; }
            set { _dropPosition = value; }
        }

        public TreeNodeAdv Root
        {
            get { return _root; }
        }

        public ReadOnlyCollection<TreeNodeAdv> SelectedNodes
        {
            get { return _readonlySelection; }
        }

        public TreeNodeAdv SelectedNode
        {
            get
            {
                if (Selection.Count > 0)
                {
                    if (CurrentNode != null && CurrentNode.IsSelected)
                    {
                        return CurrentNode;
                    }
                    else
                    {
                        return Selection[0];
                    }
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (SelectedNode == value)
                {
                    return;
                }

                BeginUpdate();
                try
                {
                    if (value == null)
                    {
                        ClearSelectionInternal();
                    }
                    else
                    {
                        if (!IsMyNode(value))
                        {
                            throw new ArgumentException();
                        }

                        ClearSelectionInternal();
                        value.IsSelected = true;
                        CurrentNode = value;
                        EnsureVisible(value);
                    }
                }
                finally
                {
                    EndUpdate();
                }
            }
        }

        public TreeNodeAdv CurrentNode
        {
            get { return _currentNode; }
            internal set { _currentNode = value; }
        }

        public int ItemCount
        {
            get { return RowMap.Count; }
        }

        // Указывает расстояние, на котором содержимое прокручивается влево.
        public int HorizontalScrollPosition
        {
            get
            {
                if (_hScrollBar.Visible)
                {
                    return _hScrollBar.Value;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void AutoSizeColumn(TreeColumn column = null)
        {
            if (column != null)
            {
                if (!Columns.Contains(column))
                {
                    throw new ArgumentException("column");
                }

                DrawContext context = new DrawContext();
                context.Graphics = Graphics.FromImage(new Bitmap(1, 1));
                context.Font = this.Font;
                int res = 0;
                IEnumerable allNodes = this.AllNodes;
                foreach (TreeNodeAdv node in allNodes)
                {
                    int w = 0;
                    foreach (NodeControl nc in NodeControls)
                    {
                        if (nc.ParentColumn == column)
                        {
                            w += nc.GetActualSize(node, _measureContext).Width;
                        }
                    }
                    if (column.Index == 0)
                    {
                        w += node.Level * _indent + LeftMargin;
                    }
                    res = Math.Max(res, w);
                }
                if (res > 0)
                {
                    column.Width = res;
                }
            }
            else
            {
                foreach (TreeColumn col in this.Columns)
                {
                    DrawContext context = new DrawContext();
                    context.Graphics = Graphics.FromImage(new Bitmap(1, 1));
                    context.Font = this.Font;
                    int res = 0;
                    IEnumerable allNodes = this.AllNodes;
                    foreach (TreeNodeAdv node in allNodes)
                    {
                        int w = 0;
                        foreach (NodeControl nc in NodeControls)
                        {
                            if (nc.ParentColumn == col)
                            {
                                w += nc.GetActualSize(node, _measureContext).Width;
                            }
                        }
                        if (col.Index == 0)
                        {
                            w += node.Level * _indent + LeftMargin;
                        }
                        res = Math.Max(res, w);
                    }
                    if (res > 0)
                    {
                        col.Width = res;
                    }
                }
            }
        }

        private void CreatePens()
        {
            CreateLinePen();
            CreateMarkPen();
        }

        private void CreateMarkPen()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLines(new Point[] { new Point(0, 0), new Point(1, 1), new Point(-1, 1), new Point(0, 0) });
            CustomLineCap cap = new CustomLineCap(null, path);
            cap.WidthScale = 1.0f;

            _markPen = new Pen(_dragDropMarkColor, _dragDropMarkWidth);
            _markPen.CustomStartCap = cap;
            _markPen.CustomEndCap = cap;
        }

        private void CreateLinePen()
        {
            _linePen = new Pen(_lineColor);
            _linePen.DashStyle = DashStyle.Dot;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            DrawContext context = new DrawContext();
            context.Graphics = e.Graphics;
            context.Font = this.Font;
            context.Enabled = Enabled;

            int y = 0;
            int gridHeight = 0;

            if (UseColumns)
            {
                DrawColumnHeaders(e.Graphics);
                y += ColumnHeaderHeight;
                if (Columns.Count == 0 || e.ClipRectangle.Height <= y)
                {
                    return;
                }
            }

            int firstRowY = _rowLayout.GetRowBounds(FirstVisibleRow).Y;
            y -= firstRowY;

            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(-OffsetX, y);
            Rectangle displayRect = DisplayRectangle;
            for (int row = FirstVisibleRow; row < RowCount; row++)
            {
                Rectangle rowRect = _rowLayout.GetRowBounds(row);
                gridHeight += rowRect.Height;
                if (rowRect.Y + y > displayRect.Bottom)
                {
                    break;
                }
                else
                {
                    DrawRow(e, ref context, row, rowRect);
                }
            }

            if ((GridLineStyle & GridLineStyle.Vertical) == GridLineStyle.Vertical && UseColumns)
            {
                DrawVerticalGridLines(e.Graphics, firstRowY);
            }

            if (_dropPosition.Node != null && DragMode && HighlightDropPosition)
            {
                DrawDropMark(e.Graphics);
            }

            e.Graphics.ResetTransform();
            DrawScrollBarsBox(e.Graphics);

            if (DragMode && _dragBitmap != null)
            {
                e.Graphics.DrawImage(_dragBitmap, PointToClient(MousePosition));
            }
        }

        private void DrawRow(PaintEventArgs e, ref DrawContext context, int row, Rectangle rowRect)
        {
            TreeNodeAdv node = RowMap[row];
            context.DrawSelection = DrawSelectionMode.None;
            context.CurrentEditorOwner = CurrentEditorOwner;
            if (DragMode)
            {
                if ((_dropPosition.Node == node) && _dropPosition.Position == NodePosition.Inside && HighlightDropPosition)
                {
                    context.DrawSelection = DrawSelectionMode.Active;
                }
            }
            else
            {
                if (node.IsSelected && Focused)
                {
                    context.DrawSelection = DrawSelectionMode.Active;
                }
                else if (node.IsSelected && !Focused && !HideSelection)
                {
                    context.DrawSelection = DrawSelectionMode.Inactive;
                }
            }
            context.DrawFocus = Focused && CurrentNode == node;

            OnRowDraw(e, node, context, row, rowRect);

            if (FullRowSelect)
            {
                context.DrawFocus = false;
                if (context.DrawSelection == DrawSelectionMode.Active || context.DrawSelection == DrawSelectionMode.Inactive)
                {
                    Rectangle focusRect = new Rectangle(OffsetX, rowRect.Y, ClientRectangle.Width, rowRect.Height);
                    if (context.DrawSelection == DrawSelectionMode.Active)
                    {
                        e.Graphics.FillRectangle(SystemBrushes.Highlight, focusRect);
                        context.DrawSelection = DrawSelectionMode.FullRowSelect;
                    }
                    else
                    {
                        e.Graphics.FillRectangle(SystemBrushes.InactiveBorder, focusRect);
                        context.DrawSelection = DrawSelectionMode.None;
                    }
                }
            }

            if ((GridLineStyle & GridLineStyle.Horizontal) == GridLineStyle.Horizontal)
            {
                e.Graphics.DrawLine(SystemPens.InactiveBorder, 0, rowRect.Bottom, e.Graphics.ClipBounds.Right, rowRect.Bottom);
            }

            if (ShowLines)
            {
                DrawLines(e.Graphics, node, rowRect);
            }
            DrawNode(node, context);
        }

        private void DrawVerticalGridLines(Graphics gr, int y)
        {
            int x = 0;
            foreach (TreeColumn c in Columns)
            {
                if (c.IsVisible)
                {
                    x += c.Width;
                    gr.DrawLine(SystemPens.InactiveBorder, x - 1, y, x - 1, gr.ClipBounds.Bottom);
                }
            }
        }

        private void DrawColumnHeaders(Graphics gr)
        {
            ReorderColumnState reorder = Input as ReorderColumnState;
            int x = 0;
            TreeColumn.DrawBackground(gr, new Rectangle(0, 0, ClientRectangle.Width + 2, ColumnHeaderHeight - 1), false, false);
            gr.TranslateTransform(-OffsetX, 0);
            foreach (TreeColumn c in Columns)
            {
                if (c.IsVisible)
                {
                    if (x >= OffsetX && x - OffsetX < this.Bounds.Width)// skip invisible columns
                    {
                        Rectangle rect = new Rectangle(x, 0, c.Width, ColumnHeaderHeight - 1);
                        gr.SetClip(rect);
                        bool pressed = ((Input is ClickColumnState || reorder != null) && ((Input as ColumnState).Column == c));
                        c.Draw(gr, rect, Font, pressed, _hotColumn == c);
                        gr.ResetClip();

                        if (reorder != null && reorder.DropColumn == c)
                        {
                            TreeColumn.DrawDropMark(gr, rect);
                        }
                    }
                    x += c.Width;
                }
            }

            if (reorder != null)
            {
                if (reorder.DropColumn == null)
                {
                    TreeColumn.DrawDropMark(gr, new Rectangle(x, 0, 0, ColumnHeaderHeight));
                }
                gr.DrawImage(reorder.GhostImage, new Point(reorder.Location.X + +reorder.DragOffset, reorder.Location.Y));
            }
        }

        public void DrawNode(TreeNodeAdv node, DrawContext context)
        {
            foreach (NodeControlInfo item in GetNodeControls(node))
            {
                if (item.Bounds.Right >= OffsetX && item.Bounds.X - OffsetX < this.Bounds.Width) // Пропустить невидимые узлы.
                {
                    context.Bounds = item.Bounds;
                    context.Graphics.SetClip(context.Bounds);
                    item.Control.Draw(node, context);
                    context.Graphics.ResetClip();
                }
            }
        }

        private void DrawScrollBarsBox(Graphics gr)
        {
            Rectangle r1 = DisplayRectangle;
            Rectangle r2 = ClientRectangle;
            gr.FillRectangle(SystemBrushes.Control, new Rectangle(r1.Right, r1.Bottom, r2.Width - r1.Width, r2.Height - r1.Height));
        }

        private void DrawDropMark(Graphics gr)
        {
            if (_dropPosition.Position == NodePosition.Inside)
            {
                return;
            }

            Rectangle rect = GetNodeBounds(_dropPosition.Node);
            int right = DisplayRectangle.Right - LeftMargin + OffsetX;
            int y = rect.Y;
            if (_dropPosition.Position == NodePosition.After)
            {
                y = rect.Bottom;
            }
            gr.DrawLine(_markPen, rect.X, y, right, y);
        }

        private void DrawLines(Graphics gr, TreeNodeAdv node, Rectangle rowRect)
        {
            if (UseColumns && Columns.Count > 0)
            {
                gr.SetClip(new Rectangle(0, rowRect.Y, Columns[0].Width, rowRect.Bottom));
            }

            TreeNodeAdv curNode = node;
            while (curNode != _root && curNode != null)
            {
                int level = curNode.Level;
                int x = (level - 1) * _indent + NodePlusMinus.ImageSize / 2 + LeftMargin;
                int width = NodePlusMinus.Width - NodePlusMinus.ImageSize / 2;
                int y = rowRect.Y;
                int y2 = y + rowRect.Height;

                if (curNode == node)
                {
                    int midy = y + rowRect.Height / 2;
                    gr.DrawLine(_linePen, x, midy, x + width, midy);
                    if (curNode.NextNode == null)
                    {
                        y2 = y + rowRect.Height / 2;
                    }
                }

                if (node.Row == 0)
                {
                    y = rowRect.Height / 2;
                }
                if (curNode.NextNode != null || curNode == node)
                {
                    gr.DrawLine(_linePen, x, y, x, y2);
                }
                curNode = curNode.Parent;
            }
            gr.ResetClip();
        }
		
        public System.Drawing.Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public System.Drawing.Image SelectedImage
        {
            get { return selectedImage; }
            set { selectedImage = value; }
        }
    }
}

    #endregion Aga.Controls.Tree

		
namespace osf
{
    public class TreeViewAdvEx : Aga.Controls.Tree.TreeViewAdv
    {
        public osf.TreeViewAdv M_Object;

        public TreeViewAdvEx() : base()
        {
        }
    }

    public class TreeViewAdv : Control
    {
        public ClTreeViewAdv dll_obj;
        public TreeViewAdvEx M_TreeViewAdv;
        public string SelectionChanged;
        public string ColumnReordered;
        public string ColumnClicked;
        public string NodeMouseClick;
        public string ItemDrag;
        public string Scroll;
        public string Expanding;
        public string Collapsing;
        public string Expanded;
        public string Collapsed;
        public bool selectNodeControl = false;
        public System.Collections.DictionaryEntry CurrentControl = new System.Collections.DictionaryEntry(null, null);

        public TreeViewAdv()
        {
            M_TreeViewAdv = new TreeViewAdvEx();
            M_TreeViewAdv.M_Object = this;
            base.M_Control = M_TreeViewAdv;
		
            M_TreeViewAdv.SelectionChanged += M_TreeViewAdv_SelectionChanged;
            SelectionChanged = "";
            M_TreeViewAdv.ColumnReordered += M_TreeViewAdv_ColumnReordered;
            ColumnReordered = "";
            M_TreeViewAdv.ColumnClicked += M_TreeViewAdv_ColumnClicked;
            ColumnClicked = "";
            M_TreeViewAdv.NodeMouseClick += M_TreeViewAdv_NodeMouseClick;
            NodeMouseClick = "";
            M_TreeViewAdv.ItemDrag += M_TreeViewAdv_ItemDrag;
            ItemDrag = "";
            M_TreeViewAdv.Scroll += M_TreeViewAdv_Scroll;
            Scroll = "";
            M_TreeViewAdv.Expanding += M_TreeViewAdv_Expanding;
            Expanding = "";
            M_TreeViewAdv.Collapsing += M_TreeViewAdv_Collapsing;
            Collapsing = "";
            M_TreeViewAdv.Expanded += M_TreeViewAdv_Expanded;
            Expanded = "";
            M_TreeViewAdv.Collapsed += M_TreeViewAdv_Collapsed;
            Collapsed = "";
        }

        public TreeViewAdv(osf.TreeViewAdv p1)
        {
            M_TreeViewAdv = p1.M_TreeViewAdv;
            M_TreeViewAdv.M_Object = this;
            base.M_Control = M_TreeViewAdv;
		
            M_TreeViewAdv.SelectionChanged += M_TreeViewAdv_SelectionChanged;
            SelectionChanged = "";
            M_TreeViewAdv.ColumnReordered += M_TreeViewAdv_ColumnReordered;
            ColumnReordered = "";
            M_TreeViewAdv.ColumnClicked += M_TreeViewAdv_ColumnClicked;
            ColumnClicked = "";
            M_TreeViewAdv.NodeMouseClick += M_TreeViewAdv_NodeMouseClick;
            NodeMouseClick = "";
            M_TreeViewAdv.ItemDrag += M_TreeViewAdv_ItemDrag;
            ItemDrag = "";
            M_TreeViewAdv.Scroll += M_TreeViewAdv_Scroll;
            Scroll = "";
            M_TreeViewAdv.Expanding += M_TreeViewAdv_Expanding;
            Expanding = "";
            M_TreeViewAdv.Collapsing += M_TreeViewAdv_Collapsing;
            Collapsing = "";
            M_TreeViewAdv.Expanded += M_TreeViewAdv_Expanded;
            Expanded = "";
            M_TreeViewAdv.Collapsed += M_TreeViewAdv_Collapsed;
            Collapsed = "";
        }

        public TreeViewAdv(Aga.Controls.Tree.TreeViewAdv p1)
        {
            M_TreeViewAdv = (TreeViewAdvEx)p1;
            M_TreeViewAdv.M_Object = this;
            base.M_Control = M_TreeViewAdv;
		
            M_TreeViewAdv.SelectionChanged += M_TreeViewAdv_SelectionChanged;
            SelectionChanged = "";
            M_TreeViewAdv.ColumnReordered += M_TreeViewAdv_ColumnReordered;
            ColumnReordered = "";
            M_TreeViewAdv.ColumnClicked += M_TreeViewAdv_ColumnClicked;
            ColumnClicked = "";
            M_TreeViewAdv.NodeMouseClick += M_TreeViewAdv_NodeMouseClick;
            NodeMouseClick = "";
            M_TreeViewAdv.ItemDrag += M_TreeViewAdv_ItemDrag;
            ItemDrag = "";
            M_TreeViewAdv.Scroll += M_TreeViewAdv_Scroll;
            Scroll = "";
            M_TreeViewAdv.Expanding += M_TreeViewAdv_Expanding;
            Expanding = "";
            M_TreeViewAdv.Collapsing += M_TreeViewAdv_Collapsing;
            Collapsing = "";
            M_TreeViewAdv.Expanded += M_TreeViewAdv_Expanded;
            Expanded = "";
            M_TreeViewAdv.Collapsed += M_TreeViewAdv_Collapsed;
            Collapsed = "";
        }
		
        public void M_TreeViewAdv_Collapsed(object sender, Aga.Controls.Tree.TreeViewAdvEventArgs e)
        {
            if (Collapsed.Length > 0)
            {
                TreeViewAdvEventArgs TreeViewAdvEventArgs1 = new TreeViewAdvEventArgs(e);
                TreeViewAdvEventArgs1.EventString = Collapsed;
                TreeViewAdvEventArgs1.Sender = this;
                TreeViewAdvEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.Collapsed);
                ClTreeViewAdvEventArgs ClTreeViewAdvEventArgs1 = new ClTreeViewAdvEventArgs(TreeViewAdvEventArgs1);
                OneScriptForms.Event = ClTreeViewAdvEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.Collapsed);
            }
        }

        public void M_TreeViewAdv_Expanded(object sender, Aga.Controls.Tree.TreeViewAdvEventArgs e)
        {
            if (Expanded.Length > 0)
            {
                TreeViewAdvEventArgs TreeViewAdvEventArgs1 = new TreeViewAdvEventArgs(e);
                TreeViewAdvEventArgs1.EventString = Expanded;
                TreeViewAdvEventArgs1.Sender = this;
                TreeViewAdvEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.Expanded);
                ClTreeViewAdvEventArgs ClTreeViewAdvEventArgs1 = new ClTreeViewAdvEventArgs(TreeViewAdvEventArgs1);
                OneScriptForms.Event = ClTreeViewAdvEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.Expanded);
            }
        }

        public void M_TreeViewAdv_Collapsing(object sender, Aga.Controls.Tree.TreeViewAdvEventArgs e)
        {
            if (Collapsing.Length > 0)
            {
                TreeViewAdvEventArgs TreeViewAdvEventArgs1 = new TreeViewAdvEventArgs(e);
                TreeViewAdvEventArgs1.EventString = Collapsing;
                TreeViewAdvEventArgs1.Sender = this;
                TreeViewAdvEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.Collapsing);
                ClTreeViewAdvEventArgs ClTreeViewAdvEventArgs1 = new ClTreeViewAdvEventArgs(TreeViewAdvEventArgs1);
                OneScriptForms.Event = ClTreeViewAdvEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.Collapsing);
            }
        }

        public void M_TreeViewAdv_Expanding(object sender, Aga.Controls.Tree.TreeViewAdvEventArgs e)
        {
            if (Expanding.Length > 0)
            {
                TreeViewAdvEventArgs TreeViewAdvEventArgs1 = new TreeViewAdvEventArgs(e);
                TreeViewAdvEventArgs1.EventString = Expanding;
                TreeViewAdvEventArgs1.Sender = this;
                TreeViewAdvEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.Expanding);
                ClTreeViewAdvEventArgs ClTreeViewAdvEventArgs1 = new ClTreeViewAdvEventArgs(TreeViewAdvEventArgs1);
                OneScriptForms.Event = ClTreeViewAdvEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.Expanding);
            }
        }

        public void M_TreeViewAdv_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            if (Scroll.Length > 0)
            {
                ScrollEventArgs ScrollEventArgs1 = new ScrollEventArgs();
                ScrollEventArgs1.EventString = Scroll;
                ScrollEventArgs1.Sender = this;
                ScrollEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.Scroll);
                ScrollEventArgs1.OldValue = e.OldValue;
                ScrollEventArgs1.NewValue = e.NewValue;
                ScrollEventArgs1.ScrollOrientation = (int)e.ScrollOrientation;
                ScrollEventArgs1.EventType = (int)e.Type;
                ClScrollEventArgs ClScrollEventArgs1 = new ClScrollEventArgs(ScrollEventArgs1);
                OneScriptForms.Event = ClScrollEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.Scroll);
            }
        }

        private void M_TreeViewAdv_ItemDrag(object sender, ItemDragEventArgs e)
        {
            
        }

        public void M_TreeViewAdv_NodeMouseClick(object sender, Aga.Controls.Tree.TreeNodeAdvMouseEventArgs e)
        {
            if (SelectNodeControl)
            {
                if (e.Control.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeComboBox) ||
                    e.Control.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeDecimalTextBox) ||
                    e.Control.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeNumericUpDown) ||
                    e.Control.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeTextBox))
                {
                    var nodeControl = (Aga.Controls.Tree.NodeControls.BaseTextControl)e.Control;
                    if (e.Node == nodeControl.Parent.CurrentNode)
                    {
                        CurrentControl.Key = e.Node;
                        CurrentControl.Value = nodeControl;
                        this.Refresh();
                    }
                }
            }
            if (NodeMouseClick.Length > 0)
            {
                TreeNodeAdvMouseEventArgs TreeNodeAdvMouseEventArgs1 = new TreeNodeAdvMouseEventArgs(e);
                TreeNodeAdvMouseEventArgs1.EventString = NodeMouseClick;
                TreeNodeAdvMouseEventArgs1.Sender = this;
                TreeNodeAdvMouseEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.NodeMouseClick);
                ClTreeNodeAdvMouseEventArgs ClTreeNodeAdvMouseEventArgs1 = new ClTreeNodeAdvMouseEventArgs(TreeNodeAdvMouseEventArgs1);
                OneScriptForms.Event = ClTreeNodeAdvMouseEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.NodeMouseClick);
            }
        }

        public void M_TreeViewAdv_ColumnClicked(object sender, Aga.Controls.Tree.TreeColumnEventArgs e)
        {
            if (ColumnClicked.Length > 0)
            {
                TreeColumnEventArgs TreeColumnEventArgs1 = new TreeColumnEventArgs(e.Column);
                TreeColumnEventArgs1.EventString = ColumnClicked;
                TreeColumnEventArgs1.Sender = this;
                TreeColumnEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.ColumnClicked);
                ClTreeColumnEventArgs ClTreeColumnEventArgs1 = new ClTreeColumnEventArgs(TreeColumnEventArgs1);
                OneScriptForms.Event = ClTreeColumnEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.ColumnClicked);
            }
        }

        public void M_TreeViewAdv_ColumnReordered(object sender, Aga.Controls.Tree.TreeColumnEventArgs e)
        {
            if (ColumnReordered.Length > 0)
            {
                TreeColumnEventArgs TreeColumnEventArgs1 = new TreeColumnEventArgs(e.Column);
                TreeColumnEventArgs1.EventString = ColumnReordered;
                TreeColumnEventArgs1.Sender = this;
                TreeColumnEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.ColumnReordered);
                ClTreeColumnEventArgs ClTreeColumnEventArgs1 = new ClTreeColumnEventArgs(TreeColumnEventArgs1);
                OneScriptForms.Event = ClTreeColumnEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.ColumnReordered);
            }
        }

        public void M_TreeViewAdv_SelectionChanged(object sender, System.EventArgs e)
        {
            if (this.SelectedNodes.Count > 1)
            {
                CurrentControl.Key = null;
                CurrentControl.Value = null;
            }
		
            if (SelectionChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = SelectionChanged;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.SelectionChanged);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.SelectionChanged);
            }
        }
		
        public bool UseColumns
        {
            get { return M_TreeViewAdv.UseColumns; }
            set
            {
                M_TreeViewAdv.UseColumns = value;
                M_TreeViewAdv.FullUpdate();
            }
        }

        public void CollapseAll()
        {
            M_TreeViewAdv.CollapseAll();
        }

        public Aga.Controls.Tree.ITreeModel TreeModel
        {
            get { return M_TreeViewAdv.Model; }
            set { M_TreeViewAdv.Model = (Aga.Controls.Tree.ITreeModel)value; }
        }

        public Aga.Controls.Tree.NodeControls.NodeControlsCollection NodeControls
        {
            get { return M_TreeViewAdv.NodeControls; }
        }

        public Aga.Controls.Tree.TreeColumnCollection Columns
        {
            get { return M_TreeViewAdv.Columns; }
        }
		
        public void FullUpdate()
        {
            M_TreeViewAdv.FullUpdate();
        }
		
        public Aga.Controls.Tree.TreeNodeAdv.NodeCollection Nodes
        {
            get { return M_TreeViewAdv.Nodes; }
        }
		
        public osf.Rectangle DisplayRectangle
        {
            get { return new Rectangle(M_TreeViewAdv.DisplayRectangle); }
        }

        public osf.Color LineColor
        {
            get { return new Color(M_TreeViewAdv.LineColor); }
            set { M_TreeViewAdv.LineColor = value.M_Color; }
        }

        public bool AutoRowHeight
        {
            get { return M_TreeViewAdv.AutoRowHeight; }
            set { M_TreeViewAdv.AutoRowHeight = value; }
        }

        public bool AsyncExpanding
        {
            get { return M_TreeViewAdv.AsyncExpanding; }
            set { M_TreeViewAdv.AsyncExpanding = value; }
        }

        public bool FullRowSelect
        {
            get { return M_TreeViewAdv.FullRowSelect; }
            set { M_TreeViewAdv.FullRowSelect = value; }
        }

        public Aga.Controls.Tree.TreeNodeAdv SelectedNode
        {
            get { return M_TreeViewAdv.SelectedNode; }
            set { M_TreeViewAdv.SelectedNode = value; }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Aga.Controls.Tree.TreeNodeAdv> SelectedNodes
        {
            get { return M_TreeViewAdv.SelectedNodes; }
        }

        public bool HighlightDropPosition
        {
            get { return M_TreeViewAdv.HighlightDropPosition; }
            set { M_TreeViewAdv.HighlightDropPosition = value; }
        }

        public int ColumnHeadersHeight
        {
            get { return M_TreeViewAdv.ColumnHeadersHeight; }
            set { M_TreeViewAdv.ColumnHeadersHeight = value; }
        }

        public int RowHeight
        {
            get { return M_TreeViewAdv.RowHeight; }
            set { M_TreeViewAdv.RowHeight = value; }
        }

        public bool LoadOnDemand
        {
            get { return M_TreeViewAdv.LoadOnDemand; }
            set { M_TreeViewAdv.LoadOnDemand = value; }
        }

        public int ItemCount
        {
            get { return M_TreeViewAdv.ItemCount; }
        }
        
        public Aga.Controls.Tree.TreeNodeAdv Root
        {
            get { return M_TreeViewAdv.Root; }
        }

        public bool DisplayDraggingNodes
        {
            get { return M_TreeViewAdv.DisplayDraggingNodes; }
            set { M_TreeViewAdv.DisplayDraggingNodes = value; }
        }

        public int Indent
        {
            get { return M_TreeViewAdv.Indent; }
            set { M_TreeViewAdv.Indent = value; }
        }

        public int HorizontalScrollPosition
        {
            get { return M_TreeViewAdv.HorizontalScrollPosition; }
        }

        public bool ShowLines
        {
            get { return M_TreeViewAdv.ShowLines; }
            set { M_TreeViewAdv.ShowLines = value; }
        }

        public bool ShowPlusMinus
        {
            get { return M_TreeViewAdv.ShowPlusMinus; }
            set { M_TreeViewAdv.ShowPlusMinus = value; }
        }

        public bool ShowNodeToolTips
        {
            get { return M_TreeViewAdv.ShowNodeToolTips; }
            set { M_TreeViewAdv.ShowNodeToolTips = value; }
        }

        public bool UnloadCollapsedOnReload
        {
            get { return M_TreeViewAdv.UnloadCollapsedOnReload; }
            set { M_TreeViewAdv.UnloadCollapsedOnReload = value; }
        }

        public bool AllowColumnReorder
        {
            get { return M_TreeViewAdv.AllowColumnReorder; }
            set { M_TreeViewAdv.AllowColumnReorder = value; }
        }

        public Aga.Controls.Tree.TreeSelectionMode SelectionMode
        {
            get { return M_TreeViewAdv.SelectionMode; }
            set { M_TreeViewAdv.SelectionMode = value; }
        }

        public bool HideSelection
        {
            get { return M_TreeViewAdv.HideSelection; }
            set { M_TreeViewAdv.HideSelection = value; }
        }

        public int BorderStyle
        {
            get { return (int)M_TreeViewAdv.BorderStyle; }
            set
            {
                M_TreeViewAdv.BorderStyle = (System.Windows.Forms.BorderStyle)value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public Aga.Controls.Tree.GridLineStyle GridLineStyle
        {
            get { return M_TreeViewAdv.GridLineStyle; }
            set { M_TreeViewAdv.GridLineStyle = value; }
        }

        public Aga.Controls.Tree.TreeNodeAdv CurrentNode
        {
            get { return M_TreeViewAdv.CurrentNode; }
        }

        public osf.Color DragDropMarkColor
        {
            get { return new Color(M_TreeViewAdv.DragDropMarkColor); }
            set { M_TreeViewAdv.DragDropMarkColor = value.M_Color; }
        }

        public float TopEdgeSensivity
        {
            get { return M_TreeViewAdv.TopEdgeSensivity; }
            set { M_TreeViewAdv.TopEdgeSensivity = value; }
        }

        public float BottomEdgeSensivity
        {
            get { return M_TreeViewAdv.BottomEdgeSensivity; }
            set { M_TreeViewAdv.BottomEdgeSensivity = value; }
        }
        
        public float DragDropMarkWidth
        {
            get { return M_TreeViewAdv.DragDropMarkWidth; }
            set { M_TreeViewAdv.DragDropMarkWidth = value; }
        }
		
        public void AutoSizeColumn(TreeColumn p1 = null)
        {
            if (p1 != null)
            {
                M_TreeViewAdv.AutoSizeColumn(p1.M_TreeColumn);
            }
            else
            {
                M_TreeViewAdv.AutoSizeColumn();
            }
        }

        public void SelectAllNodes()
        {
            M_TreeViewAdv.SelectAllNodes();
        }

        public void EnsureVisible(Aga.Controls.Tree.TreeNodeAdv p1)
        {
            M_TreeViewAdv.EnsureVisible(p1);
        }

        public void ClearSelection()
        {
            M_TreeViewAdv.ClearSelection();
        }

        public string GetFullPath(Aga.Controls.Tree.TreeNodeAdv p1)
        {
            return M_TreeViewAdv.GetFullPath(p1);
        }

        public void ScrollTo(Aga.Controls.Tree.TreeNodeAdv p1)
        {
            M_TreeViewAdv.ScrollTo(p1);
        }

        public void ExpandAll()
        {
            M_TreeViewAdv.ExpandAll();
        }
		
        public string PathSeparator
        {
            get { return M_TreeViewAdv.PathSeparator; }
            set { M_TreeViewAdv.PathSeparator = value; }
        }
		
        public System.Drawing.Image Image
        {
            get { return M_TreeViewAdv.Image; }
            set { M_TreeViewAdv.Image = value; }
        }

        public System.Drawing.Image SelectedImage
        {
            get { return M_TreeViewAdv.SelectedImage; }
            set { M_TreeViewAdv.SelectedImage = value; }
        }
		
        public bool SelectNodeControl
        {
            get { return selectNodeControl; }
            set { selectNodeControl = value; }
        }
    }

    [ContextClass("КлДеревоЗначений", "ClTreeViewAdv")]
    public class ClTreeViewAdv : AutoContext<ClTreeViewAdv>
    {
        private IValue _Click;
        private IValue _Collapsed;
        private IValue _Collapsing;
        private IValue _ColumnClicked;
        private IValue _ColumnReordered;
        private IValue _ControlAdded;
        private IValue _ControlRemoved;
        private IValue _DoubleClick;
        private IValue _Enter;
        private IValue _Expanded;
        private IValue _Expanding;
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
        private IValue _NodeMouseClick;
        private IValue _Paint;
        private IValue _Scroll;
        private IValue _SelectionChanged;
        private IValue _SizeChanged;
        private IValue _TextChanged;
        private ClColor backColor;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClTreeColumnCollection columns;
        private ClControlCollection controls;
        private ClCursor cursor;
        private ClFont font;
        private ClColor foreColor;
        private ClColor lineColor;
        private ClNodeControlsCollection nodeControls;
        private ClSelectedTreeNodeAdvCollection selectedNodes;
        private ClCollection tag = new ClCollection();
        private Aga.Controls.Tree.TreeModel TreeModel1;

        public ClTreeViewAdv()
        {
            TreeViewAdv TreeViewAdv1 = new TreeViewAdv();
            TreeViewAdv1.dll_obj = this;
            Base_obj = TreeViewAdv1;
            columns = new ClTreeColumnCollection(this.Base_obj.Columns);
            nodeControls = new ClNodeControlsCollection(this.Base_obj.NodeControls);
            nodeControls.TreeViewAdv = this;
            selectedNodes = new ClSelectedTreeNodeAdvCollection(this.Base_obj.SelectedNodes);
            TreeModel1 = new Aga.Controls.Tree.TreeModel();
            Base_obj.TreeModel = TreeModel1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            lineColor = new ClColor(Base_obj.LineColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }//end_constr

        public TreeViewAdv Base_obj;

        //Свойства============================================================
        [ContextProperty("АвтоВысотаСтрок", "AutoRowHeight")]
        public bool AutoRowHeight
        {
            get { return Base_obj.AutoRowHeight; }
            set { Base_obj.AutoRowHeight = value; }
        }

        [ContextProperty("АсинхронноеРазвертывание", "AsyncExpanding")]
        public bool AsyncExpanding
        {
            get { return Base_obj.AsyncExpanding; }
            set { Base_obj.AsyncExpanding = value; }
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

        [ContextProperty("ВыбранныеУзлы", "SelectedNodes")]
        public ClSelectedTreeNodeAdvCollection SelectedNodes
        {
            get { return selectedNodes; }
        }
        
        [ContextProperty("ВыбранныйУзел", "SelectedNode")]
        public ClNode SelectedNode
        {
            get { return (ClNode)OneScriptForms.RevertObj(Base_obj.SelectedNode.Tag); }
            set { Base_obj.SelectedNode = value.Base_obj.TreeNodeAdv; }
        }
        
        [ContextProperty("ВыделениеИзменено", "SelectionChanged")]
        public IValue SelectionChanged
        {
            get { return _SelectionChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _SelectionChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.SelectionChanged = "DelegateActionSelectionChanged";
                }
                else
                {
                    _SelectionChanged = value;
                    Base_obj.SelectionChanged = "osfActionSelectionChanged";
                }
            }
        }
        
        [ContextProperty("ВыделятьЭлементУзла", "SelectNodeControl")]
        public bool SelectNodeControl
        {
            get { return Base_obj.SelectNodeControl; }
            set { Base_obj.SelectNodeControl = value; }
        }

        [ContextProperty("Высота", "Height")]
        public int Height
        {
            get { return Base_obj.Height; }
            set { Base_obj.Height = value; }
        }

        [ContextProperty("ВысотаЗаголовковКолонок", "ColumnHeadersHeight")]
        public int ColumnHeadersHeight
        {
            get { return Base_obj.ColumnHeadersHeight; }
            set { Base_obj.ColumnHeadersHeight = value; }
        }

        [ContextProperty("ВысотаСтроки", "RowHeight")]
        public int RowHeight
        {
            get { return Base_obj.RowHeight; }
            set { Base_obj.RowHeight = value; }
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

        [ContextProperty("ЗагрузкаПоТребованию", "LoadOnDemand")]
        public bool LoadOnDemand
        {
            get { return Base_obj.LoadOnDemand; }
            set { Base_obj.LoadOnDemand = value; }
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

        [ContextProperty("ИспользоватьКолонки", "UseColumns")]
        public bool UseColumns
        {
            get { return Base_obj.UseColumns; }
            set { Base_obj.UseColumns = value; }
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

        [ContextProperty("КолонкаНажата", "ColumnClicked")]
        public IValue ColumnClicked
        {
            get { return _ColumnClicked; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _ColumnClicked = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ColumnClicked = "DelegateActionColumnClicked";
                }
                else
                {
                    _ColumnClicked = value;
                    Base_obj.ColumnClicked = "osfActionColumnClicked";
                }
            }
        }
        
        [ContextProperty("КолонкаПерестроена", "ColumnReordered")]
        public IValue ColumnReordered
        {
            get { return _ColumnReordered; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _ColumnReordered = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ColumnReordered = "DelegateActionColumnReordered";
                }
                else
                {
                    _ColumnReordered = value;
                    Base_obj.ColumnReordered = "osfActionColumnReordered";
                }
            }
        }
        
        [ContextProperty("Колонки", "Columns")]
        public ClTreeColumnCollection Columns
        {
            get { return columns; }
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

        [ContextProperty("Отступ", "Indent")]
        public int Indent
        {
            get { return Base_obj.Indent; }
            set { Base_obj.Indent = value; }
        }

        [ContextProperty("ПозицияМыши", "MousePosition")]
        public ClPoint MousePosition
        {
            get { return new ClPoint(System.Windows.Forms.Control.MousePosition); }
        }
        
        [ContextProperty("ПоказатьЛинии", "ShowLines")]
        public bool ShowLines
        {
            get { return Base_obj.ShowLines; }
            set { Base_obj.ShowLines = value; }
        }

        [ContextProperty("ПоказатьПлюсМинус", "ShowPlusMinus")]
        public bool ShowPlusMinus
        {
            get { return Base_obj.ShowPlusMinus; }
            set { Base_obj.ShowPlusMinus = value; }
        }

        [ContextProperty("ВыбиратьПодэлементы", "FullRowSelect")]
        public bool FullRowSelect
        {
            // Устаревшее свойство, оставить для совместимости.
            get { return Base_obj.FullRowSelect; }
            set { Base_obj.FullRowSelect = value; }
        }

        [ContextProperty("ПолныйВыборСтроки", "FullRowSelect4")]
        public bool FullRowSelect4
        {
            get { return FullRowSelect; }
            set { FullRowSelect = value; }
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
        
        [ContextProperty("ПриНажатииУзла", "NodeMouseClick")]
        public IValue NodeMouseClick
        {
            get { return _NodeMouseClick; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _NodeMouseClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.NodeMouseClick = "DelegateActionNodeMouseClick";
                }
                else
                {
                    _NodeMouseClick = value;
                    Base_obj.NodeMouseClick = "osfActionNodeMouseClick";
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
        
        [ContextProperty("ПриПрокручивании", "Scroll")]
        public IValue Scroll
        {
            get { return _Scroll; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Scroll = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Scroll = "DelegateActionScroll";
                }
                else
                {
                    _Scroll = value;
                    Base_obj.Scroll = "osfActionScroll";
                }
            }
        }
        
        [ContextProperty("ПриРазворачивании", "Expanding")]
        public IValue Expanding
        {
            get { return _Expanding; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Expanding = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Expanding = "DelegateActionExpanding";
                }
                else
                {
                    _Expanding = value;
                    Base_obj.Expanding = "osfActionExpanding";
                }
            }
        }
        
        [ContextProperty("ПриСвертывании", "Collapsing")]
        public IValue Collapsing
        {
            get { return _Collapsing; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Collapsing = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Collapsing = "DelegateActionCollapsing";
                }
                else
                {
                    _Collapsing = value;
                    Base_obj.Collapsing = "osfActionCollapsing";
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
        
        [ContextProperty("Развернут", "Expanded")]
        public IValue Expanded
        {
            get { return _Expanded; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Expanded = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Expanded = "DelegateActionExpanded";
                }
                else
                {
                    _Expanded = value;
                    Base_obj.Expanded = "osfActionExpanded";
                }
            }
        }
        
        [ContextProperty("РазделительПути", "PathSeparator")]
        public string PathSeparator
        {
            get { return Base_obj.PathSeparator; }
            set { Base_obj.PathSeparator = value; }
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
        
        [ContextProperty("РазрешитьПерестраиватьКолонки", "AllowColumnReorder")]
        public bool AllowColumnReorder
        {
            get { return Base_obj.AllowColumnReorder; }
            set { Base_obj.AllowColumnReorder = value; }
        }

        [ContextProperty("РежимВыбора", "SelectionMode")]
        public int SelectionMode
        {
            get { return (int)Base_obj.SelectionMode; }
            set { Base_obj.SelectionMode = (Aga.Controls.Tree.TreeSelectionMode)value; }
        }
        
        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }
        
        [ContextProperty("Свернут", "Collapsed")]
        public IValue Collapsed
        {
            get { return _Collapsed; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Collapsed = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Collapsed = "DelegateActionCollapsed";
                }
                else
                {
                    _Collapsed = value;
                    Base_obj.Collapsed = "osfActionCollapsed";
                }
            }
        }
        
        [ContextProperty("СкрытьВыделение", "HideSelection")]
        public bool HideSelection
        {
            get { return Base_obj.HideSelection; }
            set { Base_obj.HideSelection = value; }
        }

        [ContextProperty("СтильГраницы", "BorderStyle")]
        public int BorderStyle
        {
            get { return (int)Base_obj.BorderStyle; }
            set { Base_obj.BorderStyle = value; }
        }

        [ContextProperty("СтильСетки", "GridLineStyle")]
        public int GridLineStyle
        {
            get { return (int)Base_obj.GridLineStyle; }
            set { Base_obj.GridLineStyle = (Aga.Controls.Tree.GridLineStyle)value; }
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
        
        [ContextProperty("ТекущийУзел", "CurrentNode")]
        public ClNode CurrentNode
        {
            get
            {
                Aga.Controls.Tree.Node Node1 = null;
                try
                {
                    Node1 = (Aga.Controls.Tree.Node)Base_obj.CurrentNode.Tag;
                }
                catch { }
                if (Node1 == null)
                {
                    return null;
                }
                return new ClNode((Aga.Controls.Tree.Node)Base_obj.CurrentNode.Tag);
            }
        }
        
        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }
        
        [ContextProperty("Узлы", "Nodes")]
        public ClNodeCollection Nodes
        {
            get { return new ClNodeCollection(TreeModel1.Nodes); }
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
        
        [ContextProperty("ЭлементыУзла", "NodeControls")]
        public ClNodeControlsCollection NodeControls
        {
            get { return nodeControls; }
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

        //endProperty
        //Методы============================================================
        [ContextMethod("АвтоРазмерКолонки", "AutoSizeColumn")]
        public void AutoSizeColumn(ClTreeColumn p1 = null)
        {
            if (p1 != null)
            {
                Base_obj.AutoSizeColumn(p1.Base_obj);
            }
            else
            {
                Base_obj.AutoSizeColumn();
            }
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

        [ContextMethod("Выбрать", "Select")]
        public void Select()
        {
            Base_obj.Select();
        }
					
        [ContextMethod("ВыбратьВсеУзлы", "SelectAllNodes")]
        public void SelectAllNodes()
        {
            Base_obj.SelectAllNodes();
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
        
        [ContextMethod("ОбеспечитьОтображение", "EnsureVisible")]
        public void EnsureVisible(ClNode p1)
        {
            Base_obj.EnsureVisible(p1.Base_obj.TreeNodeAdv);
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
					
        [ContextMethod("ОчиститьВыделение", "ClearSelection")]
        public void ClearSelection()
        {
            Base_obj.ClearSelection();
        }
					
        [ContextMethod("Показать", "Show")]
        public void Show()
        {
            Base_obj.Show();
        }
					
        [ContextMethod("ПолучитьПолныйПуть", "GetFullPath")]
        public string GetFullPath(ClNode p1)
        {
            return Base_obj.GetFullPath(p1.Base_obj.TreeNodeAdv);
        }
        
        [ContextMethod("ПолучитьСтиль", "GetStyle")]
        public bool GetStyle(int p1)
        {
            return Base_obj.GetStyle((System.Windows.Forms.ControlStyles)p1);
        }

        [ContextMethod("ПолучитьУзел", "GetNodeAt")]
        public ClNode GetNodeAt(ClPoint p1)
        {
            return new ClNode((Aga.Controls.Tree.Node)Base_obj.M_TreeViewAdv.GetNodeAt(p1.Base_obj.M_Point).Tag);
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
					
        [ContextMethod("ПрокрутитьДоУзла", "ScrollTo")]
        public void ScrollTo(ClNode p1)
        {
            Base_obj.ScrollTo(p1.Base_obj.TreeNodeAdv);
        }
        
        [ContextMethod("РазвернутьВсе", "ExpandAll")]
        public void ExpandAll()
        {
            Base_obj.ExpandAll();
        }
					
        [ContextMethod("СвернутьВсе", "CollapseAll")]
        public void CollapseAll()
        {
            Base_obj.CollapseAll();
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

        [ContextMethod("Узлы", "Nodes")]
        public ClNode Nodes2(int p1)
        {
            return new ClNode(TreeModel1.Nodes[p1]);
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
        
        [ContextMethod("ЭлементыУзла", "NodeControls")]
        public IValue NodeControls2(int p1)
        {
            dynamic Obj1 = null;
            string str1 = Base_obj.NodeControls[p1].GetType().ToString();
            string str2 = str1.Replace("Aga.Controls.Tree.NodeControls.", "osf.Cl");
            System.Type Type1 = System.Type.GetType(str2, false, true);
            object[] args1 = { Base_obj.NodeControls[p1] };
            Obj1 = Activator.CreateInstance(Type1, args1);
            return OneScriptForms.RevertObj(Obj1);
        }
        
        [ContextMethod("ЭлементыУправления", "Controls")]
        public IValue Controls2(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.Controls2(p1));
        }

        //endMethods
    }//endClass

}//endnamespace

