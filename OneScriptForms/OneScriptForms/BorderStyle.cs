using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСтильГраницы", "ClBorderStyle")]
    public class ClBorderStyle : AutoContext<ClBorderStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.BorderStyle.None; // 0 Граница отсутствует.
        private int m_fixedSingle = (int)System.Windows.Forms.BorderStyle.FixedSingle; // 1 Одинарная граница.
        private int m_fixed3D = (int)System.Windows.Forms.BorderStyle.Fixed3D; // 2 Трехмерная граница.

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
            {1, "Одинарная"},
            {0, "Отсутствие"},
            {2, "Трехмерная"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "FixedSingle"},
            {0, "None"},
            {2, "Fixed3D"},
        };

        public ClBorderStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Fixed3D));
            _list.Add(ValueFactory.Create(FixedSingle));
            _list.Add(ValueFactory.Create(None));
        }

        [ContextProperty("Одинарная", "FixedSingle")]
        public int FixedSingle
        {
            get { return m_fixedSingle; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return m_none; }
        }

        [ContextProperty("Трехмерная", "Fixed3D")]
        public int Fixed3D
        {
            get { return m_fixed3D; }
        }
    }
}
