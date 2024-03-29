﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ColumnClickEventArgs : EventArgs
    {
        public new ClColumnClickEventArgs dll_obj;
        public int Column = -1;

    }

    [ContextClass ("КлКолонкаНажатиеАрг", "ClColumnClickEventArgs")]
    public class ClColumnClickEventArgs : AutoContext<ClColumnClickEventArgs>
    {
        public ClColumnClickEventArgs()
        {
            ColumnClickEventArgs ColumnClickEventArgs1 = new ColumnClickEventArgs();
            ColumnClickEventArgs1.dll_obj = this;
            Base_obj = ColumnClickEventArgs1;
        }
		
        public ClColumnClickEventArgs(ColumnClickEventArgs p1)
        {
            ColumnClickEventArgs ColumnClickEventArgs1 = p1;
            ColumnClickEventArgs1.dll_obj = this;
            Base_obj = ColumnClickEventArgs1;
        }
        
        public ColumnClickEventArgs Base_obj;
        
        [ContextProperty("Колонка", "Column")]
        public int Column
        {
            get { return Base_obj.Column; }
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
        
    }
}
