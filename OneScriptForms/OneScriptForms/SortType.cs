using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлТипСортировки", "ClSortType")]
    public class ClSortType : AutoContext<ClSortType>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_text = 0; // 0 Тип сортировки <B>Текст</B>.
        private int m_number = 1; // 1 Тип сортировки <B>Число</B>.
        private int m_dateTime = 2; // 2 Тип сортировки <B>Дата</B>.
        private int m_boolean = 3; // 3 Тип сортировки <B>Булево</B>.

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
            {3, "Булево"},
            {2, "ДатаВремя"},
            {0, "Текст"},
            {1, "Число"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {3, "Boolean"},
            {2, "DateTime"},
            {0, "Text"},
            {1, "Number"},
        };

        public ClSortType()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Boolean));
            _list.Add(ValueFactory.Create(DateTime));
            _list.Add(ValueFactory.Create(Number));
            _list.Add(ValueFactory.Create(Text));
        }

        [ContextProperty("Булево", "Boolean")]
        public int Boolean
        {
            get { return m_boolean; }
        }

        [ContextProperty("ДатаВремя", "DateTime")]
        public int DateTime
        {
            get { return m_dateTime; }
        }

        [ContextProperty("Текст", "Text")]
        public int Text
        {
            get { return m_text; }
        }

        [ContextProperty("Число", "Number")]
        public int Number
        {
            get { return m_number; }
        }
    }
}
