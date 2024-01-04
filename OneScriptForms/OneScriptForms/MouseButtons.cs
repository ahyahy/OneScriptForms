using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлКнопкиМыши", "ClMouseButtons")]
    public class ClMouseButtons : AutoContext<ClMouseButtons>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_left = (int)System.Windows.Forms.MouseButtons.Left; // 1048576 Была нажата левая кнопка мыши.
        private int m_right = (int)System.Windows.Forms.MouseButtons.Right; // 2097152 Была нажата правая кнопка мыши.
        private int m_middle = (int)System.Windows.Forms.MouseButtons.Middle; // 4194304 Была нажата средняя кнопка мыши.

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

        internal ClMouseButtons()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Left));
            _list.Add(ValueFactory.Create(Middle));
            _list.Add(ValueFactory.Create(Right));
        }

        [ContextProperty("Левая", "Left")]
        public int Left
        {
        	get { return m_left; }
        }

        [ContextProperty("Правая", "Right")]
        public int Right
        {
        	get { return m_right; }
        }

        [ContextProperty("Средняя", "Middle")]
        public int Middle
        {
        	get { return m_middle; }
        }
    }
}
