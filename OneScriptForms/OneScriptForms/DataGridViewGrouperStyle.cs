using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСтильГруппировкиТаблицы", "ClDataGridViewGrouperStyle")]
    public class ClDataGridViewGrouperStyle : AutoContext<ClDataGridViewGrouperStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_firstLetter = 0; // 0 Группировка осуществляется на основе первого символа.
        private int m_firstWord = 1; // 1 Группировка осуществляется на основе первого слова.
        private int m_lastWord = 2; // 2 Группировка осуществляется на основе последнего слова.

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

        public ClDataGridViewGrouperStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(FirstLetter));
            _list.Add(ValueFactory.Create(FirstWord));
            _list.Add(ValueFactory.Create(LastWord));
        }

        [ContextProperty("ПервоеСлово", "FirstWord")]
        public int FirstWord
        {
        	get { return m_firstWord; }
        }

        [ContextProperty("ПервыйСимвол", "FirstLetter")]
        public int FirstLetter
        {
        	get { return m_firstLetter; }
        }

        [ContextProperty("ПоследнееСлово", "LastWord")]
        public int LastWord
        {
        	get { return m_lastWord; }
        }
    }
}
