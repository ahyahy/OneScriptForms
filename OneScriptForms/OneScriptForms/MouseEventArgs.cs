using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class MouseEventArgs : EventArgs
    {
        private int button = -1;
        public int Clicks = -1;
        public new ClMouseEventArgs dll_obj;
        public int X = -1;
        public int Y = -1;

        public int Button
        {
            get { return (int)button; }
            set { button = (int)value; }
        }
    }

    [ContextClass ("КлМышьАрг", "ClMouseEventArgs")]
    public class ClMouseEventArgs : AutoContext<ClMouseEventArgs>
    {
        public ClMouseEventArgs()
        {
            MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
            MouseEventArgs1.dll_obj = this;
            Base_obj = MouseEventArgs1;
        }
		
        public ClMouseEventArgs(MouseEventArgs p1)
        {
            MouseEventArgs MouseEventArgs1 = p1;
            MouseEventArgs1.dll_obj = this;
            Base_obj = MouseEventArgs1;
        }
        
        public MouseEventArgs Base_obj;
        
        [ContextProperty("Игрек", "Y")]
        public int Y
        {
            get { return Base_obj.Y; }
        }

        [ContextProperty("Икс", "X")]
        public int X
        {
            get { return Base_obj.X; }
        }

        [ContextProperty("Кнопка", "Button")]
        public int Button
        {
            get { return (int)Base_obj.Button; }
        }

        [ContextProperty("Нажатия", "Clicks")]
        public int Clicks
        {
            get { return Base_obj.Clicks; }
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
