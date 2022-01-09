using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class TreeViewCancelEventArgs : CancelEventArgs
    {
        public int Action = (int)System.Windows.Forms.TreeViewAction.Unknown;
        public new ClTreeViewCancelEventArgs dll_obj;
        public osf.TreeNode Node = null;

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

        [ContextProperty("Отправитель", "Sender")]
        public IValue Sender
        {
            get { return OneScriptForms.RevertObj(Base_obj.Sender); }
        }
        
        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter
        {
            get { return (IValue)Base_obj.Parameter; }
        }

        [ContextProperty("Узел", "Node")]
        public ClTreeNode Node
        {
            get { return (ClTreeNode)OneScriptForms.RevertObj(Base_obj.Node); }
        }
        
    }
}
