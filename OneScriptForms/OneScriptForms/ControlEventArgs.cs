using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class ControlEventArgs : EventArgs
    {
        public new ClControlEventArgs dll_obj;
        public dynamic Control = null;

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлЭлементУправленияАрг", "ClControlEventArgs")]
    public class ClControlEventArgs : AutoContext<ClControlEventArgs>
    {

        public ClControlEventArgs()
        {
            ControlEventArgs ControlEventArgs1 = new ControlEventArgs();
            ControlEventArgs1.dll_obj = this;
            Base_obj = ControlEventArgs1;
        }
		
        public ClControlEventArgs(ControlEventArgs p1)
        {
            ControlEventArgs ControlEventArgs1 = p1;
            ControlEventArgs1.dll_obj = this;
            Base_obj = ControlEventArgs1;
        }
        
        public ControlEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("ЭлементУправления", "Control")]
        public IValue Control
        {
            get { return (IValue)OneScriptForms.RevertObj(Base_obj.Control); }
        }

        //Методы============================================================

    }
}
