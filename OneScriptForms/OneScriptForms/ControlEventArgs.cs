﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ControlEventArgs : EventArgs
    {
        public new ClControlEventArgs dll_obj;
        public dynamic Control = null;

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

        [ContextProperty("ЭлементУправления", "Control")]
        public IValue Control
        {
            get { return (IValue)OneScriptForms.RevertObj(Base_obj.Control); }
        }
        
    }
}
