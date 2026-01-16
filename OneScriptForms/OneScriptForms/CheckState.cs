using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСостояниеФлажка", "ClCheckState")]
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
            {2, "Неопределенный"},
            {0, "НеПомечен"},
            {1, "Помечен"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {2, "Indeterminate"},
            {0, "Unchecked"},
            {1, "Checked"},
        };

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
