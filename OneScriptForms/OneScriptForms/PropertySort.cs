using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСортировкаСвойств", "ClPropertySort")]
    public class ClPropertySort : AutoContext<ClPropertySort>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_noSort = (int)System.Windows.Forms.PropertySort.NoSort; // 0 Свойства не сортируются.
        private int m_alphabetical = (int)System.Windows.Forms.PropertySort.Alphabetical; // 1 Свойства сортируются в алфавитном порядке.
        private int m_categorized = (int)System.Windows.Forms.PropertySort.Categorized; // 2 Свойства сортируются в соответствии с их категорией в группе. Категории определяются непосредственно из свойств.
        private int m_categorizedAlphabetical = (int)System.Windows.Forms.PropertySort.CategorizedAlphabetical; // 3 Свойства сортируются в соответствии с их категорией в группе. Дополнительные свойства сортируются в алфавитном порядке в пределах группы. Категории определяются непосредственно из свойств.

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
            {0, "БезСортировки"},
            {1, "ПоАлфавиту"},
            {2, "ПоКатегориям"},
            {3, "ПоКатегориямПоАлфавиту"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {0, "NoSort"},
            {1, "Alphabetical"},
            {2, "Categorized"},
            {3, "CategorizedAlphabetical"},
        };

        public ClPropertySort()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Alphabetical));
            _list.Add(ValueFactory.Create(Categorized));
            _list.Add(ValueFactory.Create(CategorizedAlphabetical));
            _list.Add(ValueFactory.Create(NoSort));
        }

        [ContextProperty("БезСортировки", "NoSort")]
        public int NoSort
        {
            get { return m_noSort; }
        }

        [ContextProperty("ПоАлфавиту", "Alphabetical")]
        public int Alphabetical
        {
            get { return m_alphabetical; }
        }

        [ContextProperty("ПоКатегориям", "Categorized")]
        public int Categorized
        {
            get { return m_categorized; }
        }

        [ContextProperty("ПоКатегориямПоАлфавиту", "CategorizedAlphabetical")]
        public int CategorizedAlphabetical
        {
            get { return m_categorizedAlphabetical; }
        }
    }
}
