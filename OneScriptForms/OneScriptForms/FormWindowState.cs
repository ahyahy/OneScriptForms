using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСостояниеОкнаФормы", "ClFormWindowState")]
    public class ClFormWindowState : AutoContext<ClFormWindowState>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_normal = (int)System.Windows.Forms.FormWindowState.Normal; // 0 Окно с размерами по умолчанию.
        private int m_minimized = (int)System.Windows.Forms.FormWindowState.Minimized; // 1 Свернутое окно.
        private int m_maximized = (int)System.Windows.Forms.FormWindowState.Maximized; // 2 Развернутое окно.

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
            {2, "Развернутое"},
            {1, "Свернутое"},
            {0, "Стандартное"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {2, "Maximized"},
            {1, "Minimized"},
            {0, "Normal"},
        };

        public ClFormWindowState()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Maximized));
            _list.Add(ValueFactory.Create(Minimized));
            _list.Add(ValueFactory.Create(Normal));
        }

        [ContextProperty("Развернутое", "Maximized")]
        public int Maximized
        {
            get { return m_maximized; }
        }

        [ContextProperty("Свернутое", "Minimized")]
        public int Minimized
        {
            get { return m_minimized; }
        }

        [ContextProperty("Стандартное", "Normal")]
        public int Normal
        {
            get { return m_normal; }
        }
    }
}
