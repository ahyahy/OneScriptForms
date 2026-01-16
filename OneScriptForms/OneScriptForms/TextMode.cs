using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлРежимТекста", "ClTextMode")]
    public class ClTextMode : AutoContext<ClTextMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = 0; // 0 Текст отсутствует.
        private int m_value = 1; // 1 Текст в виде значения.
        private int m_percentage = 2; // 2 Текст в виде процентов.
        private int m_custom = 3; // 3 Текст заданный пользователем.

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
            {1, "Значение"},
            {0, "Отсутствие"},
            {3, "Пользовательский"},
            {2, "Проценты"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Value"},
            {0, "None"},
            {3, "Custom"},
            {2, "Percentage"},
        };

        public ClTextMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Custom));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Percentage));
            _list.Add(ValueFactory.Create(Value));
        }

        [ContextProperty("Значение", "Value")]
        public int Value
        {
            get { return m_value; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return m_none; }
        }

        [ContextProperty("Пользовательский", "Custom")]
        public int Custom
        {
            get { return m_custom; }
        }

        [ContextProperty("Проценты", "Percentage")]
        public int Percentage
        {
            get { return m_percentage; }
        }
    }
}
