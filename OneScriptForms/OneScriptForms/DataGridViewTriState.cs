using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлТриСостояния", "ClDataGridViewTriState")]
    public class ClDataGridViewTriState : AutoContext<ClDataGridViewTriState>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_notSet = (int)System.Windows.Forms.DataGridViewTriState.NotSet; // 0 Это свойство не задано и будет функционировать по другому.
        private int m_true = (int)System.Windows.Forms.DataGridViewTriState.True; // 1 Состояние свойства - <B>Истина</B>.
        private int m_false = (int)System.Windows.Forms.DataGridViewTriState.False; // 2 Состояние свойства - <B>Ложь</B>.

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

        internal ClDataGridViewTriState()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(False));
            _list.Add(ValueFactory.Create(NotSet));
            _list.Add(ValueFactory.Create(True));
        }

        [ContextProperty("Истина", "True")]
        public int True
        {
        	get { return m_true; }
        }

        [ContextProperty("Ложь", "False")]
        public int False
        {
        	get { return m_false; }
        }

        [ContextProperty("НеУстановлено", "NotSet")]
        public int NotSet
        {
        	get { return m_notSet; }
        }
    }
}
