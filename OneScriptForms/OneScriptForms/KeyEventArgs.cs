using ScriptEngine.Machine.Contexts;

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

        //Свойства============================================================

        //Методы============================================================

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

        //Свойства============================================================

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

        //Методы============================================================

    }
}
