using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлВертикальноеВыравнивание", "ClVerticalAlign")]
    public class ClVerticalAlign : AutoContext<ClVerticalAlign>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_top = 0; // 0 Выравнивание по верхнему краю.
        private int m_bottom = 1; // 1 Выравнивание по нижнему краю.
        private int m_center = 2; // 2 Выравнивание по центру.

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

        internal ClVerticalAlign()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Bottom));
            _list.Add(ValueFactory.Create(Center));
            _list.Add(ValueFactory.Create(Top));
        }

        [ContextProperty("Верх", "Top")]
        public int Top
        {
        	get { return m_top; }
        }

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
        	get { return m_bottom; }
        }

        [ContextProperty("Центр", "Center")]
        public int Center
        {
        	get { return m_center; }
        }
    }
}
