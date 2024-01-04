using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace osf
{
    [ContextClass ("КлПлоскийСтиль", "ClFlatStyle")]
    public class ClFlatStyle : AutoContext<ClFlatStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_flat = (int)(System.Windows.Forms.FlatStyle)FlatStyle.Flat; // 0 Элемент управления выглядит плоским.
        private int m_popup = (int)(System.Windows.Forms.FlatStyle)FlatStyle.Popup; // 1 Элемент управления выглядит плоским, пока указатель мыши перемещается над ним, после чего становится объемным.
        private int m_standard = (int)(System.Windows.Forms.FlatStyle)FlatStyle.Standard; // 2 Элемент управления выглядит объемным.
        private int m_system = (int)(System.Windows.Forms.FlatStyle)FlatStyle.System; // 3 Внешний вид элемента управления определяется операционной системой пользователя.

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

        internal ClFlatStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Flat));
            _list.Add(ValueFactory.Create(Popup));
            _list.Add(ValueFactory.Create(Standard));
            _list.Add(ValueFactory.Create(System));
        }

        [ContextProperty("Всплывающий", "Popup")]
        public int Popup
        {
        	get { return m_popup; }
        }

        [ContextProperty("Плоский", "Flat")]
        public int Flat
        {
        	get { return m_flat; }
        }

        [ContextProperty("Система", "System")]
        public int System
        {
        	get { return m_system; }
        }

        [ContextProperty("Стандартный", "Standard")]
        public int Standard
        {
        	get { return m_standard; }
        }
    }
}
