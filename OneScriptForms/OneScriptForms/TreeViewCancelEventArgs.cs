using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class TreeViewCancelEventArgs : CancelEventArgs
    {
        public int Action = (int)System.Windows.Forms.TreeViewAction.Unknown;
        public new ClTreeViewCancelEventArgs dll_obj;
        public osf.TreeNode Node = null;

        //Свойства============================================================

        //Методы============================================================

        public override bool PostEvent()
        {
            if (Cancel)
            {
                return true;
            }
            TreeView TreeView1 = (TreeView)Sender;
            TreeView1.M_TreeView.BeforeExpand -= TreeView1.M_TreeView_BeforeExpand;
            Node.Expand();
            TreeView1.M_TreeView.BeforeExpand += TreeView1.M_TreeView_BeforeExpand;
            return true;
        }

    }

    [ContextClass ("КлДеревоОтменаАрг", "ClTreeViewCancelEventArgs")]
    public class ClTreeViewCancelEventArgs : AutoContext<ClTreeViewCancelEventArgs>
    {

        public ClTreeViewCancelEventArgs()
        {
            TreeViewCancelEventArgs TreeViewCancelEventArgs1 = new TreeViewCancelEventArgs();
            TreeViewCancelEventArgs1.dll_obj = this;
            Base_obj = TreeViewCancelEventArgs1;
        }
		
        public ClTreeViewCancelEventArgs(TreeViewCancelEventArgs p1)
        {
            TreeViewCancelEventArgs TreeViewCancelEventArgs1 = p1;
            TreeViewCancelEventArgs1.dll_obj = this;
            Base_obj = TreeViewCancelEventArgs1;
        }
        
        public TreeViewCancelEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Действие", "Action")]
        public int Action
        {
            get { return (int)Base_obj.Action; }
        }

        [ContextProperty("Отмена", "Cancel")]
        public bool Cancel
        {
            get { return Base_obj.Cancel; }
            set { Base_obj.Cancel = value; }
        }

        [ContextProperty("Узел", "Node")]
        public ClTreeNode Node
        {
            get { return (ClTreeNode)OneScriptForms.RevertObj(Base_obj.Node); }
        }

        //Методы============================================================

    }
}
