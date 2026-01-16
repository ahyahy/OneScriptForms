using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлОформлениеПанелиИнструментов", "ClToolBarAppearance")]
    public class ClToolBarAppearance : AutoContext<ClToolBarAppearance>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_normal = (int)System.Windows.Forms.ToolBarAppearance.Normal; // 0 Панель инструментов и кнопки отображаются как обычные трехмерные элементы управления.
        private int m_flat = (int)System.Windows.Forms.ToolBarAppearance.Flat; // 1 Панель инструментов и кнопки отображаются плоскими, однако кнопки становятся объемными когда указатель мыши перемещается над ними.

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
            {1, "Плоский"},
            {0, "Стандартный"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Flat"},
            {0, "Normal"},
        };

        public ClToolBarAppearance()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Flat));
            _list.Add(ValueFactory.Create(Normal));
        }

        [ContextProperty("Плоский", "Flat")]
        public int Flat
        {
            get { return m_flat; }
        }

        [ContextProperty("Стандартный", "Normal")]
        public int Normal
        {
            get { return m_normal; }
        }
    }
}
