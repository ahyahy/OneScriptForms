﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class KeyEventArgs : EventArgs
    {
        public bool Alt = false;
        public new ClKeyEventArgs dll_obj;
        public bool Control = false;
        public int KeyCode = (int)System.Windows.Forms.Keys.None;
        public int Modifiers = (int)System.Windows.Forms.Keys.None;
        public bool Shift = false;

    }

    [ContextClass ("КлКлавишаАрг", "ClKeyEventArgs")]
    public class ClKeyEventArgs : AutoContext<ClKeyEventArgs>
    {
        public ClKeyEventArgs()
        {
            KeyEventArgs KeyEventArgs1 = new KeyEventArgs();
            KeyEventArgs1.dll_obj = this;
            Base_obj = KeyEventArgs1;
        }
		
        public ClKeyEventArgs(KeyEventArgs p1)
        {
            KeyEventArgs KeyEventArgs1 = p1;
            KeyEventArgs1.dll_obj = this;
            Base_obj = KeyEventArgs1;
        }
        
        public KeyEventArgs Base_obj;
        
        [ContextProperty("Alt", "Alt")]
        public bool Alt
        {
            get { return Base_obj.Alt; }
        }

        [ContextProperty("Ctrl", "Control")]
        public bool Control
        {
            get { return Base_obj.Control; }
        }

        [ContextProperty("Shift", "Shift")]
        public bool Shift
        {
            get { return Base_obj.Shift; }
        }

        [ContextProperty("КодКлавиши", "KeyCode")]
        public int KeyCode
        {
            get { return (int)Base_obj.KeyCode; }
        }

        [ContextProperty("Модификаторы", "Modifiers")]
        public int Modifiers
        {
            get { return (int)Base_obj.Modifiers; }
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
