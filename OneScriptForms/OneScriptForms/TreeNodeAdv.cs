using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Aga.Controls.Tree.NodeControls;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace Aga.Controls.Tree
{
    public class Node
    {
        private TreeModel _model;
        private NodeCollection _nodes;
        private Node _parent;
        private int _index = -1;
        private string _text;
        private CheckState _checkState;
        private Image _image;
        private object _tag;
        public Dictionary<osf.ClToolTip, object> ObjTooltip = new Dictionary<osf.ClToolTip, object>();
        public Dictionary<NodeControl, object> nodeControlValue = new Dictionary<NodeControl, object>();
        public osf.ClNode dll_obj;

        public Node() : this(string.Empty)
        {
        }

        public Node(string text)
        {
            _text = text;
            _nodes = new NodeCollection(this);
            NodeName = text;
        }

        public TreeNodeAdv TreeNodeAdv { get; set; }

        public string NodeName { get; set; }

        internal TreeModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public NodeCollection Nodes
        {
            get { return _nodes; }
        }

        public object TooltipText { get; set; }

        public Node Parent
        {
            get { return _parent; }
            set
            {
                if (value != _parent)
                {
                    if (_parent != null)
                    {
                        _parent._nodes.Remove(this);
                    }

                    if (value != null)
                    {
                        value._nodes.Add(this);
                    }
                }
            }
        }

        public int Index
        {
            get { return _index; }
        }

        public Node PreviousNode
        {
            get
            {
                int index = Index;
                if (index > 0)
                {
                    return _parent._nodes[index - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        public Node NextNode
        {
            get
            {
                int index = Index;
                if (index >= 0 && index < _parent._nodes.Count - 1)
                {
                    return _parent._nodes[index + 1];
                }
                else
                {
                    return null;
                }
            }
        }

        public virtual string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    NotifyModel();
                }
            }
        }

        public virtual CheckState CheckState
        {
            get { return _checkState; }
            set
            {
                if (_checkState != value)
                {
                    _checkState = value;
                    NotifyModel();
                }
            }
        }

        public Image Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    NotifyModel();
                }
            }
        }

        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        public bool IsChecked
        {
            get { return CheckState != CheckState.Unchecked; }
            set
            {
                if (value)
                {
                    CheckState = CheckState.Checked;
                }
                else
                {
                    CheckState = CheckState.Unchecked;
                }
            }
        }

        public bool Checked
        {
            get { return IsChecked; }
            set { IsChecked = value; }
        }

        public virtual bool IsLeaf
        {
            get { return false; }
        }

        public override string ToString()
        {
            return Text;
        }

        private TreeModel FindModel()
        {
            Node node = this;
            while (node != null)
            {
                if (node.Model != null)
                {
                    return node.Model;
                }
                node = node.Parent;
            }
            return null;
        }

        protected void NotifyModel()
        {
            TreeModel model = FindModel();
            if (model != null && Parent != null)
            {
                TreePath path = model.GetPath(Parent);
                if (path != null)
                {
                    TreeModelEventArgs args = new TreeModelEventArgs(path, new int[] { Index }, new object[] { this });
                    model.OnNodesChanged(args);
                }
            }
        }

        public string FullPath
        {
            get { return GetFullPath(); }
        }

        public string GetFullPath()
        {
            string fullPath = this.NodeName;
            Node node = this;
            while (node.Parent != null)
            {
                node = node.Parent;
                fullPath = node.NodeName + this.TreeNodeAdv.Tree.PathSeparator + fullPath;
            }
            return fullPath.TrimStart(this.TreeNodeAdv.Tree.PathSeparator.ToCharArray());
        }

        public void SetControlValue(NodeControl p1, object p2)
        {
            if (p2 == null)
            {
                return;
            }
            if (!nodeControlValue.ContainsKey(p1))
            {
                nodeControlValue.Add(p1, p2);
            }
            else
            {
                if (!((object)nodeControlValue[p1]).Equals(p2))
                {
                    nodeControlValue[p1] = p2;
                }
            }
        }

        public object GetControlValue(NodeControl p1)
        {
            object obj;
            if (p1.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeCheckBox))
            {
                try
                {
                    obj = nodeControlValue[p1];
                }
                catch
                {
                    nodeControlValue[p1] = System.Windows.Forms.CheckState.Unchecked;
                }
            }
            if (p1.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeNumericUpDown))
            {
                try
                {
                    obj = nodeControlValue[p1];
                }
                catch
                {
                    nodeControlValue[p1] = Decimal.Zero;
                }
            }
            if (p1.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeTextBox))
            {
                try
                {
                    obj = nodeControlValue[p1];
                }
                catch
                {
                    nodeControlValue[p1] = String.Empty;
                }
            }
            if (p1.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeDecimalTextBox))
            {
                try
                {
                    obj = nodeControlValue[p1];
                }
                catch
                {
                    nodeControlValue[p1] = Decimal.Zero;
                }
            }
            if (p1.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeStateIcon))
            {
                Aga.Controls.Tree.NodeControls.NodeStateIcon nodeStateIcon = (Aga.Controls.Tree.NodeControls.NodeStateIcon)p1;
                try
                {
                    obj = nodeControlValue[p1];
                }
                catch
                {
                    try
                    {
                        // Сначала проверим установлено ли ИзображениеВыбранного.
                        nodeControlValue[p1] = nodeStateIcon.StateIconImage[this];
                    }
                    catch
                    {
                        // Иначе получим Изображение.
                        nodeControlValue[p1] = (osf.ClBitmap)osf.OneScriptForms.RevertEqualsObj(nodeStateIcon.Image);
                    }
                }
            }
            obj = nodeControlValue[p1];
            return obj;
        }

        public class NodeCollection : Collection<Node>
        {
            private Node _owner;

            public NodeCollection(Node owner)
            {
                _owner = owner;
            }

            protected override void ClearItems()
            {
                while (this.Count != 0)
                {
                    this.RemoveAt(this.Count - 1);
                }
            }

            public new void Clear()
            {
                ClearItems();
            }

            protected override void InsertItem(int index, Node item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }

                if (item.Parent != _owner)
                {
                    if (item.Parent != null)
                    {
                        item.Parent._nodes.Remove(item);
                    }
                    item._parent = _owner;
                    item._index = index;
                    for (int i = index; i < Count; i++)
                    {
                        this[i]._index++;
                    }
                    base.InsertItem(index, item);

                    TreeModel model = _owner.FindModel();
                    if (model != null)
                    {
                        model.OnNodeInserted(_owner, index, item);
                    }
                }
            }

            protected override void RemoveItem(int index)
            {
                Node item = this[index];
                item._parent = null;
                item._index = -1;
                for (int i = index + 1; i < Count; i++)
                {
                    this[i]._index--;
                }
                base.RemoveItem(index);

                TreeModel model = _owner.FindModel();
                if (model != null)
                {
                    model.OnNodeRemoved(_owner, index, item);
                }
            }

            protected override void SetItem(int index, Node item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                RemoveAt(index);
                InsertItem(index, item);
            }

            public void SetNode(int p1, Node p2)
            {
                SetItem(p1, p2);
            }
        }
    }

    public sealed class TreeNodeAdv
    {
        public event EventHandler<TreeViewAdvEventArgs> Collapsing;
        public event EventHandler<TreeViewAdvEventArgs> Collapsed;
        public event EventHandler<TreeViewAdvEventArgs> Expanding;
        public event EventHandler<TreeViewAdvEventArgs> Expanded;
        private TreeViewAdv _tree;
        private int _row;
        private int _index = -1;
        private bool _isSelected;
        private bool _isLeaf;
        private bool _isExpandedOnce;
        private bool _isExpanded;
        private TreeNodeAdv _parent;
        private object _tag;
        private NodeCollection _nodes;
        private ReadOnlyCollection<TreeNodeAdv> _children;
        private int? _rightBounds;
        private int? _height;
        private bool _isExpandingNow;
        private bool _autoExpandOnStructureChanged = false;
        private System.Drawing.Font nodeFont;

        public TreeNodeAdv(object tag) : this(null, tag)
        {
        }

        internal TreeNodeAdv(TreeViewAdv tree, object tag)
        {
            _row = -1;
            _tree = tree;
            _nodes = new NodeCollection(this);
            _children = new ReadOnlyCollection<TreeNodeAdv>(_nodes);
            _tag = tag;
            if (tag != null)
            {
                ((Aga.Controls.Tree.Node)tag).TreeNodeAdv = this;
            }
        }

        internal void OnCollapsing()
        {
            if (Collapsing != null)
            {
                Collapsing(this, new TreeViewAdvEventArgs(this));
            }
        }

        internal void OnCollapsed()
        {
            if (Collapsed != null)
            {
                Collapsed(this, new TreeViewAdvEventArgs(this));
            }
        }

        internal void OnExpanding()
        {
            if (Expanding != null)
            {
                Expanding(this, new TreeViewAdvEventArgs(this));
            }
        }

        internal void OnExpanded()
        {
            if (Expanded != null)
            {
                Expanded(this, new TreeViewAdvEventArgs(this));
            }
        }

        public TreeViewAdv Tree
        {
            get { return _tree; }
        }

        public int Row
        {
            get { return _row; }
            internal set { _row = value; }
        }

        public int Index
        {
            get { return _index; }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    if (Tree.IsMyNode(this))
                    {
                        //_tree.OnSelectionChanging
                        if (value)
                        {
                            if (!_tree.Selection.Contains(this))
                            {
                                _tree.Selection.Add(this);
                            }

                            if (_tree.Selection.Count == 1)
                            {
                                _tree.CurrentNode = this;
                            }
                        }
                        else
                        {
                            _tree.Selection.Remove(this);
                        }
                        _tree.UpdateView();
                        _tree.OnSelectionChanged();
                    }
                    _isSelected = value;
                }
            }
        }

        // Возвращает значение true, если все родительские узлы этого узла развернуты.
        internal bool IsVisible
        {
            get
            {
                TreeNodeAdv node = _parent;
                while (node != null)
                {
                    if (!node.IsExpanded)
                    {
                        return false;
                    }
                    node = node.Parent;
                }
                return true;
            }
        }

        public bool IsLeaf
        {
            get { return _isLeaf; }
            internal set { _isLeaf = value; }
        }

        public bool IsExpandedOnce
        {
            get { return _isExpandedOnce; }
            internal set { _isExpandedOnce = value; }
        }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value)
                {
                    Expand();
                }
                else
                {
                    Collapse();
                }
            }
        }

        internal void AssignIsExpanded(bool value)
        {
            _isExpanded = value;
        }

        public TreeNodeAdv Parent
        {
            get { return _parent; }
        }

        public int Level
        {
            get
            {
                if (_parent == null)
                {
                    return 0;
                }
                else
                {
                    return _parent.Level + 1;
                }
            }
        }

        public TreeNodeAdv PreviousNode
        {
            get
            {
                if (_parent != null)
                {
                    int index = Index;
                    if (index > 0)
                    {
                        return _parent.Nodes[index - 1];
                    }
                }
                return null;
            }
        }

        public TreeNodeAdv NextNode
        {
            get
            {
                if (_parent != null)
                {
                    int index = Index;
                    if (index < _parent.Nodes.Count - 1)
                    {
                        return _parent.Nodes[index + 1];
                    }
                }
                return null;
            }
        }

        internal TreeNodeAdv BottomNode
        {
            get
            {
                TreeNodeAdv parent = this.Parent;
                if (parent != null)
                {
                    if (parent.NextNode != null)
                    {
                        return parent.NextNode;
                    }
                    else
                    {
                        return parent.BottomNode;
                    }
                }
                return null;
            }
        }

        internal TreeNodeAdv NextVisibleNode
        {
            get
            {
                if (IsExpanded && Nodes.Count > 0)
                {
                    return Nodes[0];
                }
                else
                {
                    TreeNodeAdv nn = NextNode;
                    if (nn != null)
                    {
                        return nn;
                    }
                    else
                    {
                        return BottomNode;
                    }
                }
            }
        }

        public bool CanExpand
        {
            get { return (Nodes.Count > 0 || (!IsExpandedOnce && !IsLeaf)); }
        }

        public object Tag
        {
            get { return _tag; }
        }

        public NodeCollection Nodes
        {
            get { return _nodes; }
        }

        public ReadOnlyCollection<TreeNodeAdv> Children
        {
            get { return _children; }
        }

        internal int? RightBounds
        {
            get { return _rightBounds; }
            set { _rightBounds = value; }
        }

        internal int? Height
        {
            get { return _height; }
            set { _height = value; }
        }

        internal bool IsExpandingNow
        {
            get { return _isExpandingNow; }
            set { _isExpandingNow = value; }
        }

        public bool AutoExpandOnStructureChanged
        {
            get { return _autoExpandOnStructureChanged; }
            set { _autoExpandOnStructureChanged = value; }
        }

        public override string ToString()
        {
            if (Tag != null)
            {
                return Tag.ToString();
            }
            else
            {
                return base.ToString();
            }
        }

        public void Collapse()
        {
            if (_isExpanded)
            {
                Collapse(true);
            }
        }

        public void CollapseAll()
        {
            Collapse(false);
        }

        public void Collapse(bool ignoreChildren)
        {
            SetIsExpanded(false, ignoreChildren);
        }

        public void Expand()
        {
            if (!_isExpanded)
            {
                Expand(true);
            }
        }

        public void ExpandAll()
        {
            Expand(false);
        }

        public void Expand(bool ignoreChildren)
        {
            SetIsExpanded(true, ignoreChildren);
        }

        private void SetIsExpanded(bool value, bool ignoreChildren)
        {
            if (Tree == null)
            {
                _isExpanded = value;
            }
            else
            {
                Tree.SetIsExpanded(this, value, ignoreChildren);
            }
        }

        public System.Drawing.Image Image
        {
            get { return ((Node)Tag).Image; }
            set { ((Node)Tag).Image = value; }
        }

        public bool Checked
        {
            get { return ((Node)Tag).Checked; }
            set { ((Node)Tag).Checked = value; }
        }

        public CheckState CheckState
        {
            get { return ((Node)Tag).CheckState; }
            set { ((Node)Tag).CheckState = value; }
        }

        public string Text
        {
            get { return ((Node)Tag).Text; }
            set { ((Node)Tag).Text = value; }
        }

        public System.Drawing.Font NodeFont
        {
            get { return nodeFont; }
            set { nodeFont = value; }
        }

        public void Remove()
        {
            ((Node)Tag).Parent.Nodes.Remove(((Node)Tag));
        }

        public class NodeCollection : Collection<TreeNodeAdv>
        {
            private TreeNodeAdv _owner;

            public NodeCollection(TreeNodeAdv owner)
            {
                _owner = owner;
            }

            protected override void ClearItems()
            {
                while (this.Count != 0)
                {
                    this.RemoveAt(this.Count - 1);
                }
            }

            protected override void InsertItem(int index, TreeNodeAdv item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }

                if (item.Parent != _owner)
                {
                    if (item.Parent != null)
                    {
                        item.Parent.Nodes.Remove(item);
                    }
                    item._parent = _owner;
                    item._index = index;
                    for (int i = index; i < Count; i++)
                    {
                        this[i]._index++;
                    }
                    base.InsertItem(index, item);
                }

                if (_owner.Tree != null && _owner.Tree.Model == null)
                {
                    _owner.Tree.SmartFullUpdate();
                }
            }

            protected override void RemoveItem(int index)
            {
                TreeNodeAdv item = this[index];
                item._parent = null;
                item._index = -1;
                for (int i = index + 1; i < Count; i++)
                {
                    this[i]._index--;
                }
                base.RemoveItem(index);

                if (_owner.Tree != null && _owner.Tree.Model == null)
                {
                    _owner.Tree.UpdateSelection();
                    _owner.Tree.SmartFullUpdate();
                }
            }

            protected override void SetItem(int index, TreeNodeAdv item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                RemoveAt(index);
                InsertItem(index, item);
            }

            public void SetNode(int p1, TreeNodeAdv p2)
            {
                SetItem(p1, p2);
            }
        }
    }
}

namespace osf
{

    [ContextClass("КлУзелДереваЗначений", "ClTreeNodeAdv")]
    public class ClNode : AutoContext<ClNode>
    {
        public ClNodeCollection nodes;
        private ClCollection tag = new ClCollection();

        public ClNode(string p1)
        {
            Base_obj = new Aga.Controls.Tree.Node(p1);
            Base_obj.dll_obj = this;
            nodes = new ClNodeCollection(Base_obj.Nodes);
            NodeName = p1;
        }

        public ClNode(Aga.Controls.Tree.Node p1)
        {
            Base_obj = p1;
            Base_obj.dll_obj = this;
            nodes = new ClNodeCollection(Base_obj.Nodes);
        }

        public Aga.Controls.Tree.Node Base_obj;

        [ContextProperty("Выбран", "IsSelected")]
        public bool IsSelected
        {
            get { return Base_obj.TreeNodeAdv.IsSelected; }
            set { Base_obj.TreeNodeAdv.IsSelected = value; }
        }

        [ContextProperty("ДеревоЗначений", "Tree")]
        public ClTreeViewAdv Tree
        {
            get { return (ClTreeViewAdv)OneScriptForms.RevertObj(Base_obj.TreeNodeAdv.Tree); }
        }

        [ContextProperty("ИмяУзла", "NodeName")]
        public string NodeName
        {
            get { return Base_obj.NodeName; }
            set { Base_obj.NodeName = value; }
        }

        [ContextProperty("Индекс", "Index")]
        public int Index
        {
            get { return Base_obj.Index; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }

        [ContextProperty("ПолныйПуть", "FullPath")]
        public string FullPath
        {
            get { return Base_obj.FullPath; }
        }

        [ContextProperty("ПредыдущийУзел", "PreviousNode")]
        public ClNode PreviousNode
        {
            get { return new ClNode(Base_obj.PreviousNode); }
        }

        [ContextProperty("Развернут", "IsExpanded")]
        public bool IsExpanded
        {
            get { return Base_obj.TreeNodeAdv.IsExpanded; }
            set { Base_obj.TreeNodeAdv.IsExpanded = value; }
        }

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }

        [ContextProperty("СледующийУзел", "NextNode")]
        public ClNode NextNode
        {
            get { return new ClNode(Base_obj.NextNode); }
        }

        [ContextProperty("Строка", "Row")]
        public int Row
        {
            get { return Base_obj.TreeNodeAdv.Row; }
        }

        [ContextProperty("Узлы", "Nodes")]
        public ClNodeCollection Nodes
        {
            get { return nodes; }
        }

        [ContextProperty("Уровень", "Level")]
        public int Level
        {
            get { return Base_obj.TreeNodeAdv.Level; }
        }

        [ContextMethod("ПолучитьЗначение", "GetControlValue")]
        public IValue GetControlValue(IValue p1)
        {
            if (p1.GetType() == typeof(ClNodeCheckBox))
            {
                return ValueFactory.Create((int)Base_obj.GetControlValue(((dynamic)p1).Base_obj));
            }
            else
            {
                return Base_obj.GetControlValue(((dynamic)p1).Base_obj);
            }
        }

        [ContextMethod("Развернуть", "Expand")]
        public void Expand()
        {
            Base_obj.TreeNodeAdv.Expand();
        }

        [ContextMethod("Свернуть", "Collapse")]
        public void Collapse()
        {
            Base_obj.TreeNodeAdv.Collapse();
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove()
        {
            Base_obj.TreeNodeAdv.Remove();
        }

        [ContextMethod("Узлы", "Nodes")]
        public ClNode Nodes2(int p1)
        {
            return new ClNode(Base_obj.Nodes[p1]);
        }

        [ContextMethod("УстановитьЗначение", "SetControlValue")]
        public void SetControlValue(IValue p1, IValue p2)
        {
            if (p1.GetType() == typeof(ClNodeCheckBox))
            {
                Base_obj.SetControlValue(((dynamic)p1).Base_obj, (object)(System.Windows.Forms.CheckState)Convert.ToInt32(p2.AsNumber()));
            }
            else
            {
                Base_obj.SetControlValue(((dynamic)p1).Base_obj, (object)p2);
            }
        }

    }
}
