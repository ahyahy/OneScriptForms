using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class EventArgs
    {
        public ClEventArgs dll_obj;
        public string EventString = "";
        public dynamic Parameter;
        public dynamic Sender;

        public EventArgs()
        {
            Sender = null;
            Parameter = null;
        }
    }

    [ContextClass ("КлАргументыСобытия", "ClEventArgs")]
    public class ClEventArgs : AutoContext<ClEventArgs>
    {
        public ClEventArgs()
        {
            EventArgs EventArgs1 = new EventArgs();
            EventArgs1.dll_obj = this;
            Base_obj = EventArgs1;
        }
		
        public ClEventArgs(EventArgs p1)
        {
            EventArgs EventArgs1 = p1;
            EventArgs1.dll_obj = this;
            Base_obj = EventArgs1;
        }
        
        public EventArgs Base_obj;
        
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
        
    }
}
