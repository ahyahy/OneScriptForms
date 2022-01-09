using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class TreeViewEx : System.Windows.Forms.TreeView
    {
        public osf.TreeView M_Object;
    }

    public class TreeView : Control
    {
        public string AfterLabelEdit;
        public string AfterSelect;
        public string BeforeExpand;
        public string BeforeLabelEdit;
        public string BeforeSelect;
        public ClTreeView dll_obj;
        public TreeViewEx M_TreeView;

        public TreeView()
        {
            M_TreeView = new TreeViewEx();
            M_TreeView.M_Object = this;
            base.M_Control = M_TreeView;
            M_TreeView.BeforeExpand += M_TreeView_BeforeExpand;
            M_TreeView.AfterSelect += M_TreeView_AfterSelect;
            M_TreeView.AfterLabelEdit += M_TreeView_AfterLabelEdit;
            M_TreeView.BeforeSelect += M_TreeView_BeforeSelect;
            AfterLabelEdit = "";
            AfterSelect = "";
            BeforeExpand = "";
            BeforeLabelEdit = "";
            BeforeSelect = "";
        }

        public TreeView(osf.TreeView p1)
        {
            M_TreeView = p1.M_TreeView;
            M_TreeView.M_Object = this;
            base.M_Control = M_TreeView;
            M_TreeView.BeforeExpand += M_TreeView_BeforeExpand;
            M_TreeView.AfterSelect += M_TreeView_AfterSelect;
            M_TreeView.AfterLabelEdit += M_TreeView_AfterLabelEdit;
            M_TreeView.BeforeSelect += M_TreeView_BeforeSelect;
            AfterLabelEdit = "";
            AfterSelect = "";
            BeforeExpand = "";
            BeforeLabelEdit = "";
            BeforeSelect = "";
        }

        public TreeView(System.Windows.Forms.TreeView p1)
        {
            M_TreeView = (TreeViewEx)p1;
            M_TreeView.M_Object = this;
            base.M_Control = M_TreeView;
            M_TreeView.BeforeExpand += M_TreeView_BeforeExpand;
            M_TreeView.AfterSelect += M_TreeView_AfterSelect;
            M_TreeView.AfterLabelEdit += M_TreeView_AfterLabelEdit;
            M_TreeView.BeforeSelect += M_TreeView_BeforeSelect;
            AfterLabelEdit = "";
            AfterSelect = "";
            BeforeExpand = "";
            BeforeLabelEdit = "";
            BeforeSelect = "";
        }

        public int BorderStyle
        {
            get { return (int)M_TreeView.BorderStyle; }
            set { M_TreeView.BorderStyle = (System.Windows.Forms.BorderStyle)value; }
        }

        public bool CheckBoxes
        {
            get { return M_TreeView.CheckBoxes; }
            set { M_TreeView.CheckBoxes = value; }
        }

        public bool FullRowSelect
        {
            get { return M_TreeView.FullRowSelect; }
            set { M_TreeView.FullRowSelect = value; }
        }

        public bool HideSelection
        {
            get { return M_TreeView.HideSelection; }
            set { M_TreeView.HideSelection = value; }
        }

        public bool HotTracking
        {
            get { return M_TreeView.HotTracking; }
            set { M_TreeView.HotTracking = value; }
        }

        public int ImageIndex
        {
            get { return M_TreeView.ImageIndex; }
            set { M_TreeView.ImageIndex = value; }
        }

        public osf.ImageList ImageList
        {
            get { return new ImageList(M_TreeView.ImageList); }
            set { M_TreeView.ImageList = value.M_ImageList; }
        }

        public int Indent
        {
            get { return M_TreeView.Indent; }
            set { M_TreeView.Indent = value; }
        }

        public int ItemHeight
        {
            get { return M_TreeView.ItemHeight; }
            set { M_TreeView.ItemHeight = value; }
        }

        public bool LabelEdit
        {
            get { return M_TreeView.LabelEdit; }
            set { M_TreeView.LabelEdit = value; }
        }

        public osf.TreeNodeCollection Nodes
        {
            get { return new TreeNodeCollection(M_TreeView.Nodes); }
        }

        public string PathSeparator
        {
            get { return M_TreeView.PathSeparator; }
            set { M_TreeView.PathSeparator = value; }
        }

        public bool Scrollable
        {
            get { return M_TreeView.Scrollable; }
            set { M_TreeView.Scrollable = value; }
        }

        public int SelectedImageIndex
        {
            get { return M_TreeView.SelectedImageIndex; }
            set { M_TreeView.SelectedImageIndex = value; }
        }

        public osf.TreeNode SelectedNode
        {
            get
            {
                if (M_TreeView.SelectedNode != null)
                {
                    return ((TreeNodeEx)M_TreeView.SelectedNode).M_Object;
                }
                return null;
            }
            set { M_TreeView.SelectedNode = (System.Windows.Forms.TreeNode)value.M_TreeNode; }
        }

        public bool ShowLines
        {
            get { return M_TreeView.ShowLines; }
            set { M_TreeView.ShowLines = value; }
        }

        public bool ShowPlusMinus
        {
            get { return M_TreeView.ShowPlusMinus; }
            set { M_TreeView.ShowPlusMinus = value; }
        }

        public bool ShowRootLines
        {
            get { return M_TreeView.ShowRootLines; }
            set { M_TreeView.ShowRootLines = value; }
        }

        public bool Sorted
        {
            get { return M_TreeView.Sorted; }
            set { M_TreeView.Sorted = value; }
        }

        public osf.TreeNode GetNodeAt(int x, int y)
        {
            if (M_TreeView.GetNodeAt(x, y) != null)
            {
                return ((TreeNodeEx)M_TreeView.GetNodeAt(x, y)).M_Object;
            }
            return null;
        }

        public void M_TreeView_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            if (AfterLabelEdit.Length > 0)
            {
                NodeLabelEditEventArgs NodeLabelEditEventArgs1 = new NodeLabelEditEventArgs();
                NodeLabelEditEventArgs1.EventString = AfterLabelEdit;
                NodeLabelEditEventArgs1.Sender = this;
                NodeLabelEditEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.AfterLabelEdit);
                NodeLabelEditEventArgs1.CancelEdit = e.CancelEdit;
                NodeLabelEditEventArgs1.Label = e.Label;
                NodeLabelEditEventArgs1.Node = (TreeNode)((TreeNodeEx)e.Node).M_Object;
                NodeLabelEditEventArgs1.Label_old = e.Node.Text;
                ClNodeLabelEditEventArgs ClNodeLabelEditEventArgs1 = new ClNodeLabelEditEventArgs(NodeLabelEditEventArgs1);
                OneScriptForms.Event = ClNodeLabelEditEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.AfterLabelEdit);
                e.CancelEdit = NodeLabelEditEventArgs1.CancelEdit;
            }
        }

        public void M_TreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (AfterSelect.Length > 0)
            {
                TreeViewEventArgs TreeViewEventArgs1 = new TreeViewEventArgs();
                TreeViewEventArgs1.Action = (int)e.Action;
                TreeViewEventArgs1.Node = (TreeNode)((TreeNodeEx)e.Node).M_Object;
                TreeViewEventArgs1.EventString = AfterSelect;
                TreeViewEventArgs1.Sender = this;
                TreeViewEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.AfterSelect);
                ClTreeViewEventArgs ClTreeViewEventArgs1 = new ClTreeViewEventArgs(TreeViewEventArgs1);
                OneScriptForms.Event = ClTreeViewEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.AfterSelect);
            }
        }

        public void M_TreeView_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            if (BeforeExpand.Length > 0)
            {
                TreeViewCancelEventArgs TreeViewCancelEventArgs1 = new TreeViewCancelEventArgs();
                TreeViewCancelEventArgs1.Cancel = e.Cancel;
                TreeViewCancelEventArgs1.Action = (int)e.Action;
                TreeViewCancelEventArgs1.Node = (TreeNode)((TreeNodeEx)e.Node).M_Object;
                TreeViewCancelEventArgs1.EventString = BeforeExpand;
                TreeViewCancelEventArgs1.Sender = this;
                TreeViewCancelEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.BeforeExpand);
                ClTreeViewCancelEventArgs ClTreeViewCancelEventArgs1 = new ClTreeViewCancelEventArgs(TreeViewCancelEventArgs1);
                OneScriptForms.Event = ClTreeViewCancelEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.BeforeExpand);
                e.Cancel = TreeViewCancelEventArgs1.Cancel;
            }
        }

        public void M_TreeView_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            if (BeforeSelect.Length > 0)
            {
                TreeViewCancelEventArgs TreeViewCancelEventArgs1 = new TreeViewCancelEventArgs();
                TreeViewCancelEventArgs1.Cancel = e.Cancel;
                TreeViewCancelEventArgs1.Action = (int)e.Action;
                TreeViewCancelEventArgs1.Node = (TreeNode)((TreeNodeEx)e.Node).M_Object;
                TreeViewCancelEventArgs1.EventString = BeforeSelect;
                TreeViewCancelEventArgs1.Sender = this;
                TreeViewCancelEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.BeforeSelect);
                ClTreeViewCancelEventArgs ClTreeViewCancelEventArgs1 = new ClTreeViewCancelEventArgs(TreeViewCancelEventArgs1);
                OneScriptForms.Event = ClTreeViewCancelEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.BeforeSelect);
                e.Cancel = TreeViewCancelEventArgs1.Cancel;
            }
        }

        public override void BeginUpdate()
        {
            M_TreeView.BeginUpdate();
        }

        public override void EndUpdate()
        {
            M_TreeView.EndUpdate();
        }
    }

    [ContextClass ("КлДерево", "ClTreeView")]
    public class ClTreeView : AutoContext<ClTreeView>
    {
        private IValue _AfterLabelEdit;
        private IValue _AfterSelect;
        private IValue _BeforeExpand;
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
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClColor foreColor;
        private ClTreeNodeCollection nodes;
        private ClCollection tag = new ClCollection();

        public ClTreeView()
        {
            TreeView TreeView1 = new TreeView();
            TreeView1.dll_obj = this;
            Base_obj = TreeView1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            nodes = new ClTreeNodeCollection(Base_obj.Nodes);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClTreeView(TreeView p1)
        {
            TreeView TreeView1 = p1;
            TreeView1.dll_obj = this;
            Base_obj = TreeView1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            nodes = new ClTreeNodeCollection(Base_obj.Nodes);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
        
        public TreeView Base_obj;
        
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

        [ContextProperty("ВыбиратьПодэлементы", "FullRowSelect")]
        public bool FullRowSelect
        {
            get { return Base_obj.FullRowSelect; }
            set { Base_obj.FullRowSelect = value; }
        }

        [ContextProperty("ВыбранныйУзел", "SelectedNode")]
        public ClTreeNode SelectedNode
        {
            get { return (ClTreeNode)OneScriptForms.RevertObj(Base_obj.SelectedNode); }
            set { Base_obj.SelectedNode = value.Base_obj; }
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
        
        [ContextProperty("ВысотаЭлемента", "ItemHeight")]
        public int ItemHeight
        {
            get { return Base_obj.ItemHeight; }
            set { Base_obj.ItemHeight = value; }
        }

        [ContextProperty("Гиперссылка", "HotTracking")]
        public bool HotTracking
        {
            get { return Base_obj.HotTracking; }
            set { Base_obj.HotTracking = value; }
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

        [ContextProperty("ИндексВыбранногоИзображения", "SelectedImageIndex")]
        public int SelectedImageIndex
        {
            get { return Base_obj.SelectedImageIndex; }
            set { Base_obj.SelectedImageIndex = value; }
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

        [ContextProperty("Отсортирован", "Sorted")]
        public bool Sorted
        {
            get { return Base_obj.Sorted; }
            set { Base_obj.Sorted = value; }
        }

        [ContextProperty("Отступ", "Indent")]
        public int Indent
        {
            get { return Base_obj.Indent; }
            set { Base_obj.Indent = value; }
        }

        [ContextProperty("ПередРазвертыванием", "BeforeExpand")]
        public IValue BeforeExpand
        {
            get { return _BeforeExpand; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _BeforeExpand = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.BeforeExpand = "DelegateActionBeforeExpand";
                }
                else
                {
                    _BeforeExpand = value;
                    Base_obj.BeforeExpand = "osfActionBeforeExpand";
                }
            }
        }
        
        [ContextProperty("ПозицияМыши", "MousePosition")]
        public ClPoint MousePosition
        {
            get { return new ClPoint(System.Windows.Forms.Control.MousePosition); }
        }
        
        [ContextProperty("ПоказатьКорневыеЛинии", "ShowRootLines")]
        public bool ShowRootLines
        {
            get { return Base_obj.ShowRootLines; }
            set { Base_obj.ShowRootLines = value; }
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

        [ContextProperty("ПослеВыбора", "AfterSelect")]
        public IValue AfterSelect
        {
            get { return _AfterSelect; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _AfterSelect = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.AfterSelect = "DelegateActionAfterSelect";
                }
                else
                {
                    _AfterSelect = value;
                    Base_obj.AfterSelect = "osfActionAfterSelect";
                }
            }
        }
        
        [ContextProperty("ПослеРедактированияНадписи", "AfterLabelEdit")]
        public IValue AfterLabelEdit
        {
            get { return _AfterLabelEdit; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _AfterLabelEdit = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.AfterLabelEdit = "DelegateActionAfterLabelEdit";
                }
                else
                {
                    _AfterLabelEdit = value;
                    Base_obj.AfterLabelEdit = "osfActionAfterLabelEdit";
                }
            }
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
        
        [ContextProperty("Прокручиваемый", "Scrollable")]
        public bool Scrollable
        {
            get { return Base_obj.Scrollable; }
            set { Base_obj.Scrollable = value; }
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
        
        [ContextProperty("РедактированиеНадписи", "LabelEdit")]
        public bool LabelEdit
        {
            get { return Base_obj.LabelEdit; }
            set { Base_obj.LabelEdit = value; }
        }

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }
        
        [ContextProperty("СкрытьВыделение", "HideSelection")]
        public bool HideSelection
        {
            get { return Base_obj.HideSelection; }
            set { Base_obj.HideSelection = value; }
        }

        [ContextProperty("СписокИзображений", "ImageList")]
        public ClImageList ImageList
        {
            get { return (ClImageList)OneScriptForms.RevertObj(Base_obj.ImageList); }
            set { Base_obj.ImageList = value.Base_obj; }
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
        
        [ContextProperty("Узлы", "Nodes")]
        public ClTreeNodeCollection Nodes
        {
            get { return nodes; }
        }

        [ContextProperty("Флажки", "CheckBoxes")]
        public bool CheckBoxes
        {
            get { return Base_obj.CheckBoxes; }
            set { Base_obj.CheckBoxes = value; }
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

        [ContextMethod("ПолучитьУзел", "GetNodeAt")]
        public ClTreeNode GetNodeAt(int p1, int p2)
        {
            return new ClTreeNode(Base_obj.GetNodeAt(p1, p2));
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
