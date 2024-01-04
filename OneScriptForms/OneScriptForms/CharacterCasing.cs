using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРегистрСимволов", "ClCharacterCasing")]
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

        internal ClCharacterCasing()
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
