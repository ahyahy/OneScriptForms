using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСтилиПривязки", "ClAnchorStyles")]
    public class ClAnchorStyles : AutoContext<ClAnchorStyles>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.AnchorStyles.None; // 0 Элемент управления не привязан к краям контейнера.
        private int m_top = (int)System.Windows.Forms.AnchorStyles.Top; // 1 Элемент управления привязан к верхнему краю своего контейнера.
        private int m_bottom = (int)System.Windows.Forms.AnchorStyles.Bottom; // 2 Элемент управления привязан к нижнему краю своего контейнера.
        private int m_left = (int)System.Windows.Forms.AnchorStyles.Left; // 4 Элемент управления привязан к левому краю своего контейнера.
        private int m_right = (int)System.Windows.Forms.AnchorStyles.Right; // 8 Элемент управления привязан к правому краю своего контейнера.

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
            {1, "Верх"},
            {4, "Лево"},
            {2, "Низ"},
            {0, "Отсутствие"},
            {8, "Право"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Top"},
            {4, "Left"},
            {2, "Bottom"},
            {0, "None"},
            {8, "Right"},
        };

        public ClAnchorStyles()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Bottom));
            _list.Add(ValueFactory.Create(Left));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Right));
            _list.Add(ValueFactory.Create(Top));
        }

        [ContextProperty("Верх", "Top")]
        public int Top
        {
            get { return m_top; }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
            get { return m_left; }
        }

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
            get { return m_bottom; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return m_none; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
            get { return m_right; }
        }
    }
}
