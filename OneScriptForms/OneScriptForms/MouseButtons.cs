using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлКнопкиМыши", "ClMouseButtons")]
    public class ClMouseButtons : AutoContext<ClMouseButtons>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_left = (int)System.Windows.Forms.MouseButtons.Left; // 1048576 Была нажата левая кнопка мыши.
        private int m_right = (int)System.Windows.Forms.MouseButtons.Right; // 2097152 Была нажата правая кнопка мыши.
        private int m_middle = (int)System.Windows.Forms.MouseButtons.Middle; // 4194304 Была нажата средняя кнопка мыши.

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
            {1048576, "Левая"},
            {2097152, "Правая"},
            {4194304, "Средняя"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1048576, "Left"},
            {2097152, "Right"},
            {4194304, "Middle"},
        };

        public ClMouseButtons()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Left));
            _list.Add(ValueFactory.Create(Middle));
            _list.Add(ValueFactory.Create(Right));
        }

        [ContextProperty("Левая", "Left")]
        public int Left
        {
            get { return m_left; }
        }

        [ContextProperty("Правая", "Right")]
        public int Right
        {
            get { return m_right; }
        }

        [ContextProperty("Средняя", "Middle")]
        public int Middle
        {
            get { return m_middle; }
        }
    }
}
