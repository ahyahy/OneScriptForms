using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлФормаИндикатора", "ClProgressShape")]
    public class ClProgressShape : AutoContext<ClProgressShape>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_round = 0; // 0 Форма индикатора круглая.
        private int m_flat = 1; // 1 Форма индикатора плоская.

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

        public ClProgressShape()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Flat));
            _list.Add(ValueFactory.Create(Round));
        }

        [ContextProperty("Круглый", "Round")]
        public int Round
        {
        	get { return m_round; }
        }

        [ContextProperty("Плоский", "Flat")]
        public int Flat
        {
        	get { return m_flat; }
        }
    }
}
