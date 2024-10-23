using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСортировкаСвойств", "ClPropertySort")]
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
