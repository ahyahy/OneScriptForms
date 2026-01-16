using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлОформление", "ClAppearance")]
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
            {1, "Кнопка"},
            {0, "Стандартное"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Button"},
            {0, "Normal"},
        };

        public ClAppearance()
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
