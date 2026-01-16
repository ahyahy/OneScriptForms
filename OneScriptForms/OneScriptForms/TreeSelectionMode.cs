using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлРежимВыбораДереваЗначений", "ClTreeSelectionMode")]
    public class ClTreeSelectionMode : AutoContext<ClTreeSelectionMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_single = 0; // 0 Можно выбрать только один узел.
        private int m_multi = 1; // 1 Можно выбрать несколько узлов одновременно.
        private int m_multiSameParent = 2; // 2 Можно выбрать несколько узлов одновременно в пределах одного родителя.

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
            {1, "Множественный"},
            {2, "МножественныйДляРодителя"},
            {0, "Одиночный"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Multi"},
            {2, "MultiSameParent"},
            {0, "Single"},
        };

        public ClTreeSelectionMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Multi));
            _list.Add(ValueFactory.Create(MultiSameParent));
            _list.Add(ValueFactory.Create(Single));
        }

        [ContextProperty("Множественный", "Multi")]
        public int Multi
        {
            get { return m_multi; }
        }

        [ContextProperty("МножественныйДляРодителя", "MultiSameParent")]
        public int MultiSameParent
        {
            get { return m_multiSameParent; }
        }

        [ContextProperty("Одиночный", "Single")]
        public int Single
        {
            get { return m_single; }
        }
    }
}
