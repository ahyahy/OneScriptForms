using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ScrollEventArgs : EventArgs
    {
        public new ClScrollEventArgs dll_obj;
        public int EventType;
        public int NewValue;
        public int OldValue;
        public int ScrollOrientation;

    }

    [ContextClass ("КлПриПрокручиванииАрг", "ClScrollEventArgs")]
    public class ClScrollEventArgs : AutoContext<ClScrollEventArgs>
    {
        public ClScrollEventArgs()
        {
            ScrollEventArgs ScrollEventArgs1 = new ScrollEventArgs();
            ScrollEventArgs1.dll_obj = this;
            Base_obj = ScrollEventArgs1;
        }
		
        public ClScrollEventArgs(ScrollEventArgs p1)
        {
            ScrollEventArgs ScrollEventArgs1 = p1;
            ScrollEventArgs1.dll_obj = this;
            Base_obj = ScrollEventArgs1;
        }
        
        public ScrollEventArgs Base_obj;
        
        [ContextProperty("НовоеЗначение", "NewValue")]
        public int NewValue
        {
            get { return Base_obj.NewValue; }
            set { Base_obj.NewValue = value; }
        }

        [ContextProperty("Ориентация", "ScrollOrientation")]
        public int ScrollOrientation
        {
            get { return (int)Base_obj.ScrollOrientation; }
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

        [ContextProperty("СтароеЗначение", "OldValue")]
        public int OldValue
        {
            get { return Base_obj.OldValue; }
        }

        [ContextProperty("ТипСобытия", "EventType")]
        public int EventType
        {
            get { return (int)Base_obj.EventType; }
        }
        
    }
}
