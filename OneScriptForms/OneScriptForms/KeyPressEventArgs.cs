using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class KeyPressEventArgs : EventArgs
    {
        public new ClKeyPressEventArgs dll_obj;
        public string KeyChar;

        public KeyPressEventArgs()
        {
            KeyChar = Convert.ToString(char.MinValue);
        }

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлКлавишаНажатаАрг", "ClKeyPressEventArgs")]
    public class ClKeyPressEventArgs : AutoContext<ClKeyPressEventArgs>
    {

        public ClKeyPressEventArgs()
        {
            KeyPressEventArgs KeyPressEventArgs1 = new KeyPressEventArgs();
            KeyPressEventArgs1.dll_obj = this;
            Base_obj = KeyPressEventArgs1;
        }
		
        public ClKeyPressEventArgs(KeyPressEventArgs p1)
        {
            KeyPressEventArgs KeyPressEventArgs1 = p1;
            KeyPressEventArgs1.dll_obj = this;
            Base_obj = KeyPressEventArgs1;
        }
        
        public KeyPressEventArgs Base_obj;

        //Свойства============================================================

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

        [ContextProperty("СимволКлавиши", "KeyChar")]
        public string KeyChar
        {
            get { return Base_obj.KeyChar; }
        }

        //Методы============================================================

    }
}
