using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлФорматПоляКалендаря", "ClFormatDateTimePicker")]
    public class ClFormatDateTimePicker : AutoContext<ClFormatDateTimePicker>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_long = (int)System.Windows.Forms.DateTimePickerFormat.Long; // 1 Элемент управления <B>ПолеКалендаря&nbsp;(DateTimePicker)</B> отображает значение даты/времени в длинном формате даты, настроенном в операционной системе пользователя.
        private int m_short = (int)System.Windows.Forms.DateTimePickerFormat.Short; // 2 Элемент управления <B>ПолеКалендаря&nbsp;(DateTimePicker)</B> отображает значение даты/времени в коротком формате даты, настроенном в операционной системе пользователя.
        private int m_time = (int)System.Windows.Forms.DateTimePickerFormat.Time; // 4 Элемент управления <B>ПолеКалендаря&nbsp;(DateTimePicker)</B> отображает значение даты/времени в формате времени, настроенном в операционной системе пользователя.
        private int m_custom = (int)System.Windows.Forms.DateTimePickerFormat.Custom; // 8 Элемент управления <B>ПолеКалендаря&nbsp;(DateTimePicker)</B> отображает значение даты/времени в пользовательском формате.

        private List<IValue> _list;

        public int Count()
        {
            return _list.Count;
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IValue>)_list).GetEnumerator();
        }

        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return (item as IValue);
            }
        }

        [ContextProperty("Количество", "Count")]
        public int CountProp
        {
            get { return _list.Count; }
        }

        [ContextMethod("Получить", "Get")]
        public IValue Get(int index)
        {
            return _list[index];
        }

        [ContextMethod("Имя")]
        public string NameRu(decimal p1)
        {
            return namesRu.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        [ContextMethod("Name")]
        public string NameEn(decimal p1)
        {
            return namesEn.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        private static readonly Dictionary<decimal, string> namesRu = new Dictionary<decimal, string>
        {
            {4, "Время"},
            {1, "Длинный"},
            {2, "Короткий"},
            {8, "Пользовательский"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {4, "Time"},
            {1, "Long"},
            {2, "Short"},
            {8, "Custom"},
        };

        public ClFormatDateTimePicker()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Custom));
            _list.Add(ValueFactory.Create(Long));
            _list.Add(ValueFactory.Create(Short));
            _list.Add(ValueFactory.Create(Time));
        }

        [ContextProperty("Время", "Time")]
        public int Time
        {
            get { return m_time; }
        }

        [ContextProperty("Длинный", "Long")]
        public int Long
        {
            get { return m_long; }
        }

        [ContextProperty("Короткий", "Short")]
        public int Short
        {
            get { return m_short; }
        }

        [ContextProperty("Пользовательский", "Custom")]
        public int Custom
        {
            get { return m_custom; }
        }
    }
}
