using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class TreeViewEventArgs : EventArgs
    {
        public int Action = (int)System.Windows.Forms.TreeViewAction.Unknown;
        public new ClTreeViewEventArgs dll_obj;
        public osf.TreeNode Node = null;

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлДеревоАрг", "ClTreeViewEventArgs")]
    public class ClTreeViewEventArgs : AutoContext<ClTreeViewEventArgs>
    {

        public ClTreeViewEventArgs()
        {
            TreeViewEventArgs TreeViewEventArgs1 = new TreeViewEventArgs();
            TreeViewEventArgs1.dll_obj = this;
            Base_obj = TreeViewEventArgs1;
        }
		
        public ClTreeViewEventArgs(TreeViewEventArgs p1)
        {
            TreeViewEventArgs TreeViewEventArgs1 = p1;
            TreeViewEventArgs1.dll_obj = this;
            Base_obj = TreeViewEventArgs1;
        }
        
        public TreeViewEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Действие", "Action")]
        public int Action
        {
            get { return (int)Base_obj.Action; }
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

        //Методы============================================================

    }
}
