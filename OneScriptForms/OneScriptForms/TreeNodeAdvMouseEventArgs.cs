using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class TreeNodeAdvMouseEventArgs : osf.EventArgs
    {
        public new ClTreeNodeAdvMouseEventArgs dll_obj;
        private Aga.Controls.Tree.NodeControls.NodeControl control;
        private osf.Rectangle controlBounds;
        private bool handled;
        private System.Windows.Forms.Keys modifierKeys;
        private Aga.Controls.Tree.TreeNodeAdv node;
        private osf.Point viewLocation;

        public TreeNodeAdvMouseEventArgs(Aga.Controls.Tree.TreeNodeAdvMouseEventArgs args)
        {
            node = args.Node;
            control = args.Control;
            viewLocation = new Point(args.ViewLocation);
            modifierKeys = args.ModifierKeys;
            handled = args.Handled;
            controlBounds = new Rectangle(args.ControlBounds);
        }

        public Aga.Controls.Tree.NodeControls.NodeControl Control
        {
            get { return control; }
        }

        public Rectangle ControlBounds
        {
            get { return controlBounds; }
        }

        public bool Handled
        {
            get { return handled; }
            set { handled = value; }
        }

        public System.Windows.Forms.Keys ModifierKeys
        {
            get { return modifierKeys; }
        }

        public Aga.Controls.Tree.TreeNodeAdv Node
        {
            get { return node; }
        }

        public Point ViewLocation
        {
            get { return viewLocation; }
        }
    }

    [ContextClass ("КлУзелДереваЗначенийАрг", "ClTreeNodeAdvMouseEventArgs")]
    public class ClTreeNodeAdvMouseEventArgs : AutoContext<ClTreeNodeAdvMouseEventArgs>
    {
        public ClTreeNodeAdvMouseEventArgs(osf.TreeNodeAdvMouseEventArgs p1)
        {
            TreeNodeAdvMouseEventArgs TreeNodeAdvMouseEventArgs1 = p1;
            TreeNodeAdvMouseEventArgs1.dll_obj = this;
            Base_obj = TreeNodeAdvMouseEventArgs1;
        }

        public TreeNodeAdvMouseEventArgs Base_obj;
        
        [ContextProperty("ГраницыЭлементаУзла", "ControlBounds")]
        public ClRectangle ControlBounds
        {
            get { return (ClRectangle)OneScriptForms.RevertObj(Base_obj.ControlBounds); }
        }

        [ContextProperty("Модификаторы", "ModifierKeys")]
        public int ModifierKeys
        {
            get { return (int)Base_obj.ModifierKeys; }
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

        [ContextProperty("Положение", "ViewLocation")]
        public ClPoint ViewLocation
        {
            get { return (ClPoint)OneScriptForms.RevertObj(Base_obj.ViewLocation); }
        }

        [ContextProperty("Узел", "Node")]
        public osf.ClNode Node
        {
            get { return new ClNode((Aga.Controls.Tree.Node)Base_obj.Node.Tag); }
        }
        
        [ContextProperty("ЭлементУзла", "Control")]
        public IValue Control
        {
            get
            {
                dynamic Obj1 = null;
                string str1 = Base_obj.Control.GetType().ToString();
                string str2 = str1.Replace("Aga.Controls.Tree.NodeControls.", "osf.Cl");
                System.Type Type1 = System.Type.GetType(str2, false, true);
                object[] args1 = { Base_obj.Control };
                Obj1 = System.Activator.CreateInstance(Type1, args1);
                return OneScriptForms.RevertObj(Obj1);
            }
        }
        
    }
}
