using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлОформлениеВкладок", "ClTabAppearance")]
    public class ClTabAppearance : AutoContext<ClTabAppearance>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_normal = (int)System.Windows.Forms.TabAppearance.Normal; // 0 Вкладки имеют стандартный внешний вид вкладок.
        private int m_buttons = (int)System.Windows.Forms.TabAppearance.Buttons; // 1 Вкладки имеют вид объемных кнопок.
        private int m_flatButtons = (int)System.Windows.Forms.TabAppearance.FlatButtons; // 2 Вкладки имеют вид плоских кнопок.

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

        public ClTabAppearance()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Buttons));
            _list.Add(ValueFactory.Create(FlatButtons));
            _list.Add(ValueFactory.Create(Normal));
        }

        [ContextProperty("Кнопки", "Buttons")]
        public int Buttons
        {
        	get { return m_buttons; }
        }

        [ContextProperty("ПлоскиеКнопки", "FlatButtons")]
        public int FlatButtons
        {
        	get { return m_flatButtons; }
        }

        [ContextProperty("Стандартный", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }
    }
}
