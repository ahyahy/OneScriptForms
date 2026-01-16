using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлРегистрСимволов", "ClCharacterCasing")]
    public class ClCharacterCasing : AutoContext<ClCharacterCasing>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_normal = (int)System.Windows.Forms.CharacterCasing.Normal; // 0 Регистр символов не изменяется.
        private int m_upper = (int)System.Windows.Forms.CharacterCasing.Upper; // 1 Все символы преобразуются в верхний регистр.
        private int m_lower = (int)System.Windows.Forms.CharacterCasing.Lower; // 2 Все символы преобразуются в нижний регистр.

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
            {1, "Верхний"},
            {2, "Нижний"},
            {0, "Стандартный"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Upper"},
            {2, "Lower"},
            {0, "Normal"},
        };

        public ClCharacterCasing()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Lower));
            _list.Add(ValueFactory.Create(Normal));
            _list.Add(ValueFactory.Create(Upper));
        }

        [ContextProperty("Верхний", "Upper")]
        public int Upper
        {
            get { return m_upper; }
        }

        [ContextProperty("Нижний", "Lower")]
        public int Lower
        {
            get { return m_lower; }
        }

        [ContextProperty("Стандартный", "Normal")]
        public int Normal
        {
            get { return m_normal; }
        }
    }
}
