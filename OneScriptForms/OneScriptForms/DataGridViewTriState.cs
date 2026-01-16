using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлТриСостояния", "ClDataGridViewTriState")]
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

        [ContextProperty("Количество", "Count")]
        public int CountProp
        {
            get { return _list.Count; }
        }

        [ContextMethod("Получить", "Get")]
        public IValue Get(int index)
        {
            return _list[index];
        }

        [ContextMethod("Имя")]
        public string NameRu(decimal p1)
        {
            return namesRu.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        [ContextMethod("Name")]
        public string NameEn(decimal p1)
        {
            return namesEn.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        private static readonly Dictionary<decimal, string> namesRu = new Dictionary<decimal, string>
        {
            {1, "Истина"},
            {2, "Ложь"},
            {0, "НеУстановлено"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "True"},
            {2, "False"},
            {0, "NotSet"},
        };

        public ClDataGridViewTriState()
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
