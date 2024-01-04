using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРежимВыбора", "ClSelectionMode")]
    public class ClSelectionMode : AutoContext<ClSelectionMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.SelectionMode.None; // 0 Элементы не могут быть выбраны.
        private int m_one = (int)System.Windows.Forms.SelectionMode.One; // 1 Можно выбрать только один элемент.
        private int m_multiSimple = (int)System.Windows.Forms.SelectionMode.MultiSimple; // 2 Можно выбрать несколько элементов.
        private int m_multiExtended = (int)System.Windows.Forms.SelectionMode.MultiExtended; // 3 Можно выбрать несколько элементов. Пользователь может использовать для выбора клавиши SHIFT, CTRL и клавиши со стрелками.

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

        internal ClSelectionMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(MultiExtended));
            _list.Add(ValueFactory.Create(MultiSimple));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(One));
        }

        [ContextProperty("МножественныйПростой", "MultiSimple")]
        public int MultiSimple
        {
        	get { return m_multiSimple; }
        }

        [ContextProperty("МножественныйРасширенный", "MultiExtended")]
        public int MultiExtended
        {
        	get { return m_multiExtended; }
        }

        [ContextProperty("Одиночный", "One")]
        public int One
        {
        	get { return m_one; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }
    }
}
