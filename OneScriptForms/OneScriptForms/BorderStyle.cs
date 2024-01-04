using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСтильГраницы", "ClBorderStyle")]
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

        internal ClBorderStyle()
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
