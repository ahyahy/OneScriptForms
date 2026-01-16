using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class PropertyValueChangedEventArgs : EventArgs
    {
        public osf.GridItem ChangedItem = null;
        public new ClPropertyValueChangedEventArgs dll_obj;
        public object oldValue = null;

        public object OldValue
        {
            get { return oldValue; }
            set { oldValue = value; }
        }
    }

    [ContextClass("КлЗначениеСвойстваИзмененоАрг", "ClPropertyValueChangedEventArgs")]
    public class ClPropertyValueChangedEventArgs : AutoContext<ClPropertyValueChangedEventArgs>
    {
        public ClPropertyValueChangedEventArgs()
        {
            PropertyValueChangedEventArgs PropertyValueChangedEventArgs1 = new PropertyValueChangedEventArgs();
            PropertyValueChangedEventArgs1.dll_obj = this;
            Base_obj = PropertyValueChangedEventArgs1;
        }

        public ClPropertyValueChangedEventArgs(PropertyValueChangedEventArgs p1)
        {
            PropertyValueChangedEventArgs PropertyValueChangedEventArgs1 = p1;
            PropertyValueChangedEventArgs1.dll_obj = this;
            Base_obj = PropertyValueChangedEventArgs1;
        }

        public PropertyValueChangedEventArgs Base_obj;

        [ContextProperty("ИзмененныйЭлемент", "ChangedItem")]
        public ClGridItem ChangedItem
        {
            get { return (ClGridItem)OneScriptForms.RevertObj(Base_obj.ChangedItem); }
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
        public IValue OldValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.OldValue); }
        }

    }
}
