using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРежимРисования", "ClDrawMode")]
    public class ClDrawMode : AutoContext<ClDrawMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_normal = (int)System.Windows.Forms.DrawMode.Normal; // 0 Рисование всех элементов в элементе управления выполняется операционной системой, и все элементы имеют одинаковый размер.
        private int m_ownerDrawFixed = (int)System.Windows.Forms.DrawMode.OwnerDrawFixed; // 1 Рисование всех элементов в элементе управления выполняется вручную, и все элементы имеют одинаковый размер.
        private int m_ownerDrawVariable = (int)System.Windows.Forms.DrawMode.OwnerDrawVariable; // 2 Рисование всех элементов в элементе управления выполняется вручную, и размер их может быть разным.

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

        internal ClDrawMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Normal));
            _list.Add(ValueFactory.Create(OwnerDrawFixed));
            _list.Add(ValueFactory.Create(OwnerDrawVariable));
        }

        [ContextProperty("ВручнуюПеременный", "OwnerDrawVariable")]
        public int OwnerDrawVariable
        {
        	get { return m_ownerDrawVariable; }
        }

        [ContextProperty("ВручнуюФиксированный", "OwnerDrawFixed")]
        public int OwnerDrawFixed
        {
        	get { return m_ownerDrawFixed; }
        }

        [ContextProperty("Стандартный", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }
    }
}
