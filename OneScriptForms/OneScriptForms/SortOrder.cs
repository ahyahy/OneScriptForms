using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлПорядокСортировки", "ClSortOrder")]
    public class ClSortOrder : AutoContext<ClSortOrder>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.SortOrder.None; // 0 Элементы не сортируются.
        private int m_ascending = (int)System.Windows.Forms.SortOrder.Ascending; // 1 Элементы сортируются в порядке возрастания.
        private int m_descending = (int)System.Windows.Forms.SortOrder.Descending; // 2 Элементы сортируются в порядке убывания.

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
            {0, "Отсутствие"},
            {1, "ПоВозрастанию"},
            {2, "ПоУбыванию"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {0, "None"},
            {1, "Ascending"},
            {2, "Descending"},
        };

        public ClSortOrder()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Ascending));
            _list.Add(ValueFactory.Create(Descending));
            _list.Add(ValueFactory.Create(None));
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return m_none; }
        }

        [ContextProperty("ПоВозрастанию", "Ascending")]
        public int Ascending
        {
            get { return m_ascending; }
        }

        [ContextProperty("ПоУбыванию", "Descending")]
        public int Descending
        {
            get { return m_descending; }
        }
    }
}
