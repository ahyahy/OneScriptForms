using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class SelectedGridItemChangedEventArgs : EventArgs
    {
        public new ClSelectedGridItemChangedEventArgs dll_obj;
        public string NewLabel;
        public object NewValue;
        public string OldLabel;
        public object OldValue;

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлВыбранныйЭлементСеткиИзмененАрг", "ClSelectedGridItemChangedEventArgs")]
    public class ClSelectedGridItemChangedEventArgs : AutoContext<ClSelectedGridItemChangedEventArgs>
    {

        public ClSelectedGridItemChangedEventArgs()
        {
            SelectedGridItemChangedEventArgs SelectedGridItemChangedEventArgs1 = new SelectedGridItemChangedEventArgs();
            SelectedGridItemChangedEventArgs1.dll_obj = this;
            Base_obj = SelectedGridItemChangedEventArgs1;
        }
		
        public ClSelectedGridItemChangedEventArgs(SelectedGridItemChangedEventArgs p1)
        {
            SelectedGridItemChangedEventArgs SelectedGridItemChangedEventArgs1 = p1;
            SelectedGridItemChangedEventArgs1.dll_obj = this;
            Base_obj = SelectedGridItemChangedEventArgs1;
        }
        
        public SelectedGridItemChangedEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("НоваяНадпись", "NewLabel")]
        public string NewLabel
        {
            get { return Base_obj.NewLabel; }
        }

        [ContextProperty("НовоеЗначение", "NewValue")]
        public IValue NewValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.NewValue); }
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

        [ContextProperty("СтараяНадпись", "OldLabel")]
        public string OldLabel
        {
            get { return Base_obj.OldLabel; }
        }

        [ContextProperty("СтароеЗначение", "OldValue")]
        public IValue OldValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.OldValue); }
        }

        //Методы============================================================

    }
}
