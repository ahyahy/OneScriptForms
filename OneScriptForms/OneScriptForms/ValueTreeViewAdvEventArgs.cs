using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ValueTreeViewAdvEventArgs : osf.EventArgs
    {
        private object _newValue;
        private object _oldValue;
        private Aga.Controls.Tree.NodeControls.NodeControl _subject;
        public new ClValueTreeViewAdvEventArgs dll_obj;

        public ValueTreeViewAdvEventArgs(Aga.Controls.Tree.NodeControls.NodeControl subject, object oldLabel, object newLabel)
        {
            _newValue = newLabel;
            _oldValue = oldLabel;
            _subject = subject;
        }

        public object NewValue
        {
            get { return _newValue; }
        }

        public object OldValue
        {
            get { return _oldValue; }
        }

        public object Subject
        {
            get { return _subject; }
        }
    }

    [ContextClass("КлЗначениеДереваЗначенийАрг", "ClValueTreeViewAdvEventArgs")]
    public class ClValueTreeViewAdvEventArgs : AutoContext<ClValueTreeViewAdvEventArgs>
    {
        public ClValueTreeViewAdvEventArgs(osf.ValueTreeViewAdvEventArgs p1)
        {
            ValueTreeViewAdvEventArgs ValueTreeViewAdvEventArgs1 = p1;
            ValueTreeViewAdvEventArgs1.dll_obj = this;
            Base_obj = ValueTreeViewAdvEventArgs1;
        }

        public ValueTreeViewAdvEventArgs Base_obj;

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

        [ContextProperty("СтароеЗначение", "OldValue")]
        public IValue OldValue
        {
            get
            {
                if (Base_obj.OldValue.GetType() == typeof(System.Decimal) && (System.Decimal)Base_obj.OldValue == System.Decimal.Zero)
                {
                    return (IValue)null;
                }
                return (IValue)Base_obj.OldValue;
            }
        }

        [ContextProperty("Элемент", "Subject")]
        public IValue Subject
        {
            get { return ((dynamic)Base_obj.Subject).dll_obj; }
        }

    }
}
