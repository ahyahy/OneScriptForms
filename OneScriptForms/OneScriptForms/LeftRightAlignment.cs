using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлЛевоеПравоеВыравнивание", "ClLeftRightAlignment")]
    public class ClLeftRightAlignment : AutoContext<ClLeftRightAlignment>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_left = (int)System.Windows.Forms.LeftRightAlignment.Left; // 0 Объект или текст выравнивается влево от контрольной точки.
        private int m_right = (int)System.Windows.Forms.LeftRightAlignment.Right; // 1 Объект или текст выравнивается вправо от контрольной точки.

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

        internal ClLeftRightAlignment()
        {
            _list = new List<IValue>();
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
    }
}
