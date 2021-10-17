using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class ToolBarButtonClickEventArgs : EventArgs
    {
        public osf.ToolBarButton Button = null;
        public new ClToolBarButtonClickEventArgs dll_obj;

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлКнопкаПанелиИнструментовАрг", "ClToolBarButtonClickEventArgs")]
    public class ClToolBarButtonClickEventArgs : AutoContext<ClToolBarButtonClickEventArgs>
    {

        public ClToolBarButtonClickEventArgs()
        {
            ToolBarButtonClickEventArgs ToolBarButtonClickEventArgs1 = new ToolBarButtonClickEventArgs();
            ToolBarButtonClickEventArgs1.dll_obj = this;
            Base_obj = ToolBarButtonClickEventArgs1;
        }
		
        public ClToolBarButtonClickEventArgs(ToolBarButtonClickEventArgs p1)
        {
            ToolBarButtonClickEventArgs ToolBarButtonClickEventArgs1 = p1;
            ToolBarButtonClickEventArgs1.dll_obj = this;
            Base_obj = ToolBarButtonClickEventArgs1;
        }
        
        public ToolBarButtonClickEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Кнопка", "Button")]
        public ClToolBarButton Button
        {
            get { return (ClToolBarButton)OneScriptForms.RevertObj(Base_obj.Button); }
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

        //Методы============================================================

    }
}
