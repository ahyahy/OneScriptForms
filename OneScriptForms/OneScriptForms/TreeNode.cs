using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class TreeNodeEx : System.Windows.Forms.TreeNode
    {
        public osf.TreeNode M_Object;
    }

    public class TreeNode
    {
        public ClTreeNode dll_obj;
        public TreeNodeEx M_TreeNode;

        public TreeNode()
        {
            M_TreeNode = new TreeNodeEx();
            M_TreeNode.M_Object = this;
        }

        public TreeNode(osf.TreeNode p1)
        {
            M_TreeNode = p1.M_TreeNode;
            M_TreeNode.M_Object = this;
        }

        public TreeNode(string p1)
        {
            M_TreeNode = new TreeNodeEx();
            M_TreeNode.M_Object = this;
            M_TreeNode.Text = p1;
        }

        public TreeNode(System.Windows.Forms.TreeNode p1)
        {
            M_TreeNode = (TreeNodeEx)p1;
            M_TreeNode.M_Object = this;
        }

        public bool Checked
        {
            get { return M_TreeNode.Checked; }
            set { M_TreeNode.Checked = value; }
        }

        public string FullPath
        {
            get { return M_TreeNode.FullPath; }
        }

        public int ImageIndex
        {
            get { return M_TreeNode.ImageIndex; }
            set { M_TreeNode.ImageIndex = value; }
        }

        public int Index
        {
            get { return M_TreeNode.Index; }
        }

        public osf.TreeNode NextVisibleNode
        {
            get { return ((TreeNodeEx)M_TreeNode.NextVisibleNode).M_Object; }
        }

        public osf.Font NodeFont
        {
            get { return new Font(M_TreeNode.NodeFont); }
            set { M_TreeNode.NodeFont = value.M_Font; }
        }

        public osf.TreeNodeCollection Nodes
        {
            get { return new TreeNodeCollection(M_TreeNode.Nodes); }
        }

        public osf.TreeNode Parent
        {
            get { return (TreeNode)((TreeNodeEx)M_TreeNode.Parent).M_Object; }
        }

        public osf.TreeNode PrevVisibleNode
        {
            get { return ((TreeNodeEx)M_TreeNode.PrevVisibleNode).M_Object; }
        }

        public int SelectedImageIndex
        {
            get { return M_TreeNode.SelectedImageIndex; }
            set { M_TreeNode.SelectedImageIndex = value; }
        }

        public object Tag
        {
            get { return M_TreeNode.Tag; }
            set { M_TreeNode.Tag = value; }
        }

        public string Text
        {
            get { return M_TreeNode.Text; }
            set { M_TreeNode.Text = value; }
        }

        public osf.TreeView TreeView
        {
            get { return (TreeView)((TreeViewEx)M_TreeNode.TreeView).M_Object; }
        }

        public void BeginEdit()
        {
            M_TreeNode.BeginEdit();
            System.Windows.Forms.Application.DoEvents();
        }

        public void Collapse()
        {
            M_TreeNode.Collapse();
        }

        public void Expand()
        {
            M_TreeNode.Expand();
        }

        public void Remove()
        {
            M_TreeNode.Remove();
        }
    }

    [ContextClass ("КлУзелДерева", "ClTreeNode")]
    public class ClTreeNode : AutoContext<ClTreeNode>
    {
        private ClTreeNodeCollection nodes;
        private ClCollection tag = new ClCollection();

        public ClTreeNode()
        {
            TreeNode TreeNode1 = new TreeNode();
            TreeNode1.dll_obj = this;
            Base_obj = TreeNode1;
            nodes = new ClTreeNodeCollection(Base_obj.Nodes);
        }
		
        public ClTreeNode(string p1)
        {
            TreeNode TreeNode1 = new TreeNode(p1);
            TreeNode1.dll_obj = this;
            Base_obj = TreeNode1;
            nodes = new ClTreeNodeCollection(Base_obj.Nodes);
        }
		
        public ClTreeNode(TreeNode p1)
        {
            TreeNode TreeNode1 = p1;
            TreeNode1.dll_obj = this;
            Base_obj = TreeNode1;
            nodes = new ClTreeNodeCollection(Base_obj.Nodes);
        }
		
        public ClTreeNode(System.Windows.Forms.TreeNode p1)
        {
            TreeNode TreeNode1 = new TreeNode(p1);
            TreeNode1.dll_obj = this;
            Base_obj = TreeNode1;
            nodes = new ClTreeNodeCollection(Base_obj.Nodes);
        }

        public TreeNode Base_obj;
        
        [ContextProperty("Дерево", "TreeView")]
        public ClTreeView TreeView
        {
            get { return (ClTreeView)OneScriptForms.RevertObj(Base_obj.TreeView); }
        }

        [ContextProperty("Индекс", "Index")]
        public int Index
        {
            get { return Base_obj.Index; }
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

        [ContextProperty("Помечен", "Checked")]
        public bool Checked
        {
            get { return Base_obj.Checked; }
            set { Base_obj.Checked = value; }
        }

        [ContextProperty("ПредыдущийОтображаемыйУзел", "PrevVisibleNode")]
        public ClTreeNode PrevVisibleNode
        {
            get { return (ClTreeNode)OneScriptForms.RevertObj(Base_obj.PrevVisibleNode); }
        }

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
        }
        
        [ContextProperty("СледующийОтображаемыйУзел", "NextVisibleNode")]
        public ClTreeNode NextVisibleNode
        {
            get { return (ClTreeNode)OneScriptForms.RevertObj(Base_obj.NextVisibleNode); }
        }

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("Узлы", "Nodes")]
        public ClTreeNodeCollection Nodes
        {
            get { return nodes; }
        }

        [ContextProperty("ШрифтУзла", "NodeFont")]
        public ClFont NodeFont
        {
            get { return (ClFont)OneScriptForms.RevertObj(Base_obj.NodeFont); }
            set 
            {
                Base_obj.NodeFont = value.Base_obj; 
                Base_obj.NodeFont.dll_obj = value;
            }
        }
        
        [ContextMethod("НачатьРедактирование", "BeginEdit")]
        public void BeginEdit()
        {
            Base_obj.BeginEdit();
        }
					
        [ContextMethod("Развернуть", "Expand")]
        public void Expand()
        {
            Base_obj.Expand();
        }
					
        [ContextMethod("Свернуть", "Collapse")]
        public void Collapse()
        {
            Base_obj.Collapse();
        }
					
        [ContextMethod("Удалить", "Remove")]
        public void Remove()
        {
            Base_obj.Remove();
        }
					
        [ContextMethod("Узлы", "Nodes")]
        public ClTreeNode Nodes2(int p1)
        {
            return new ClTreeNode(Base_obj.Nodes[p1]);
        }
    }
}
