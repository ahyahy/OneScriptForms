using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлОформление", "ClAppearance")]
    public class ClAppearance : AutoContext<ClAppearance>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_normal = (int)System.Windows.Forms.Appearance.Normal; // 0 Внешний вид по умолчанию, определенный классом элемента управления.
        private int m_button = (int)System.Windows.Forms.Appearance.Button; // 1 Внешний вид кнопки Windows.

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

        internal ClAppearance()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Button));
            _list.Add(ValueFactory.Create(Normal));
        }

        [ContextProperty("Кнопка", "Button")]
        public int Button
        {
        	get { return m_button; }
        }

        [ContextProperty("Стандартное", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }
    }
}
