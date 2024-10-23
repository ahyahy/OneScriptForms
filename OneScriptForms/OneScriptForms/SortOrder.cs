using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлПорядокСортировки", "ClSortOrder")]
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
