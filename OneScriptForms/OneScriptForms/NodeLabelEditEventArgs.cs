using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class NodeLabelEditEventArgs : EventArgs
    {
        public bool CancelEdit;
        public new ClNodeLabelEditEventArgs dll_obj;
        public string Label;
        public string Label_old;
        public osf.TreeNode Node;

        //Свойства============================================================

        //Методы============================================================

        public override bool PostEvent()
        {
            if (CancelEdit)
            {
                Node.Text = Label_old;
                Node.BeginEdit();
                return true;
            }
            Node.M_TreeNode.EndEdit(false);
            return true;
        }

    }

    [ContextClass ("КлРедактированиеНадписиУзлаАрг", "ClNodeLabelEditEventArgs")]
    public class ClNodeLabelEditEventArgs : AutoContext<ClNodeLabelEditEventArgs>
    {

        public ClNodeLabelEditEventArgs()
        {
            NodeLabelEditEventArgs NodeLabelEditEventArgs1 = new NodeLabelEditEventArgs();
            NodeLabelEditEventArgs1.dll_obj = this;
            Base_obj = NodeLabelEditEventArgs1;
        }
		
        public ClNodeLabelEditEventArgs(NodeLabelEditEventArgs p1)
        {
            NodeLabelEditEventArgs NodeLabelEditEventArgs1 = p1;
            NodeLabelEditEventArgs1.dll_obj = this;
            Base_obj = NodeLabelEditEventArgs1;
        }
        
        public NodeLabelEditEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Надпись", "Label")]
        public string Label
        {
            get { return Base_obj.Label; }
        }

        [ContextProperty("ОтменаРедактирования", "CancelEdit")]
        public bool CancelEdit
        {
            get { return Base_obj.CancelEdit; }
            set { Base_obj.CancelEdit = value; }
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
