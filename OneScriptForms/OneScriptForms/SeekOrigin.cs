using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлПозицияПоиска", "ClSeekOrigin")]
    public class ClSeekOrigin : AutoContext<ClSeekOrigin>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_begin = (int)System.IO.SeekOrigin.Begin; // 0 Начало потока.
        private int m_current = (int)System.IO.SeekOrigin.Current; // 1 Текущая позиция в потоке.
        private int m_end = (int)System.IO.SeekOrigin.End; // 2 Конец потока.

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
            {2, "Конец"},
            {0, "Начало"},
            {1, "Текущая"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {2, "End"},
            {0, "Begin"},
            {1, "Current"},
        };

        public ClSeekOrigin()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Begin));
            _list.Add(ValueFactory.Create(Current));
            _list.Add(ValueFactory.Create(End));
        }

        [ContextProperty("Конец", "End")]
        public int End
        {
            get { return m_end; }
        }

        [ContextProperty("Начало", "Begin")]
        public int Begin
        {
            get { return m_begin; }
        }

        [ContextProperty("Текущая", "Current")]
        public int Current
        {
            get { return m_current; }
        }
    }
}
