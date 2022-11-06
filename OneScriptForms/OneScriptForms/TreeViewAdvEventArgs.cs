using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class TreeViewAdvEventArgs : osf.EventArgs
    {
        public new ClTreeViewAdvEventArgs dll_obj;
        private Aga.Controls.Tree.TreeNodeAdv node;

        public TreeViewAdvEventArgs(Aga.Controls.Tree.TreeNodeAdv treeNodeAdv)
        {
            node = treeNodeAdv;
        }

        public TreeViewAdvEventArgs(Aga.Controls.Tree.TreeViewAdvEventArgs args)
        {
            node = args.Node;
        }

        public Aga.Controls.Tree.TreeNodeAdv Node
        {
            get { return node; }
        }
    }

    [ContextClass ("КлДеревоЗначенийАрг", "ClTreeViewAdvEventArgs")]
    public class ClTreeViewAdvEventArgs : AutoContext<ClTreeViewAdvEventArgs>
    {
        public ClTreeViewAdvEventArgs(osf.TreeViewAdvEventArgs p1)
        {
            TreeViewAdvEventArgs TreeViewAdvEventArgs1 = p1;
            TreeViewAdvEventArgs1.dll_obj = this;
            Base_obj = TreeViewAdvEventArgs1;
        }

        public TreeViewAdvEventArgs Base_obj;
        
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
        public osf.ClNode Node
        {
            get { return new ClNode((Aga.Controls.Tree.Node)Base_obj.Node.Tag); }
        }
        
    }
}
