using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСтильГруппировкиТаблицы", "ClDataGridViewGrouperStyle")]
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
            {1, "ПервоеСлово"},
            {0, "ПервыйСимвол"},
            {2, "ПоследнееСлово"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "FirstWord"},
            {0, "FirstLetter"},
            {2, "LastWord"},
        };

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
