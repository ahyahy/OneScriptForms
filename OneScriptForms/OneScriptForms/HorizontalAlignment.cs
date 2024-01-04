using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлГоризонтальноеВыравнивание", "ClHorizontalAlignment")]
    public class ClHorizontalAlignment : AutoContext<ClHorizontalAlignment>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_left = (int)System.Windows.Forms.HorizontalAlignment.Left; // 0 Объект или текст выравнивается по левой части элемента управления.
        private int m_right = (int)System.Windows.Forms.HorizontalAlignment.Right; // 1 Объект или текст выравнивается по правому краю элемента управления.
        private int m_center = (int)System.Windows.Forms.HorizontalAlignment.Center; // 2 Объект или текст выравнивается по центру элемента управления.

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

        internal ClHorizontalAlignment()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Center));
            _list.Add(ValueFactory.Create(Left));
            _list.Add(ValueFactory.Create(Right));
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
        	get { return m_left; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
        	get { return m_right; }
        }

        [ContextProperty("Центр", "Center")]
        public int Center
        {
        	get { return m_center; }
        }
    }
}
