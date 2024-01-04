using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлТипСортировки", "ClSortType")]
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

        internal ClSortType()
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
