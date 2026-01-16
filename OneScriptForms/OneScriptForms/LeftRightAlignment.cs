using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлЛевоеПравоеВыравнивание", "ClLeftRightAlignment")]
    public class ClLeftRightAlignment : AutoContext<ClLeftRightAlignment>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_left = (int)System.Windows.Forms.LeftRightAlignment.Left; // 0 Объект или текст выравнивается влево от контрольной точки.
        private int m_right = (int)System.Windows.Forms.LeftRightAlignment.Right; // 1 Объект или текст выравнивается вправо от контрольной точки.

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
            {0, "Лево"},
            {1, "Право"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {0, "Left"},
            {1, "Right"},
        };

        public ClLeftRightAlignment()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Left));
            _list.Add(ValueFactory.Create(Right));
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
            get { return m_left; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
            get { return m_right; }
        }
    }
}
