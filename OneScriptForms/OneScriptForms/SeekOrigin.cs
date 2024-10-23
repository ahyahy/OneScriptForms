using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлПозицияПоиска", "ClSeekOrigin")]
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
