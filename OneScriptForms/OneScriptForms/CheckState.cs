using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСостояниеФлажка", "ClCheckState")]
    public class ClCheckState : AutoContext<ClCheckState>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_unchecked = (int)System.Windows.Forms.CheckState.Unchecked; // 0 Пометка элемента управления снята.
        private int m_checked = (int)System.Windows.Forms.CheckState.Checked; // 1 Данный элемент управления помечен.
        private int m_indeterminate = (int)System.Windows.Forms.CheckState.Indeterminate; // 2 Пометка элемента управления не определена. Такой элемент управления обычно затенен.

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

        public ClCheckState()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Checked));
            _list.Add(ValueFactory.Create(Indeterminate));
            _list.Add(ValueFactory.Create(Unchecked));
        }

        [ContextProperty("Неопределенный", "Indeterminate")]
        public int Indeterminate
        {
        	get { return m_indeterminate; }
        }

        [ContextProperty("НеПомечен", "Unchecked")]
        public int Unchecked
        {
        	get { return m_unchecked; }
        }

        [ContextProperty("Помечен", "Checked")]
        public int Checked
        {
        	get { return m_checked; }
        }
    }
}
