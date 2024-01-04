using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлГлубинаЦвета", "ClColorDepth")]
    public class ClColorDepth : AutoContext<ClColorDepth>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_depth4Bit = (int)System.Windows.Forms.ColorDepth.Depth4Bit; // 4 4-битовая глубина цвета.
        private int m_depth8Bit = (int)System.Windows.Forms.ColorDepth.Depth8Bit; // 8 8-битовая глубина цвета.
        private int m_depth16Bit = (int)System.Windows.Forms.ColorDepth.Depth16Bit; // 16 16-битовая глубина цвета.
        private int m_depth24Bit = (int)System.Windows.Forms.ColorDepth.Depth24Bit; // 24 24-битовая глубина цвета.
        private int m_depth32Bit = (int)System.Windows.Forms.ColorDepth.Depth32Bit; // 32 32-битовая глубина цвета.

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

        internal ClColorDepth()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Depth16Bit));
            _list.Add(ValueFactory.Create(Depth24Bit));
            _list.Add(ValueFactory.Create(Depth32Bit));
            _list.Add(ValueFactory.Create(Depth4Bit));
            _list.Add(ValueFactory.Create(Depth8Bit));
        }

        [ContextProperty("Глубина16", "Depth16Bit")]
        public int Depth16Bit
        {
        	get { return m_depth16Bit; }
        }

        [ContextProperty("Глубина24", "Depth24Bit")]
        public int Depth24Bit
        {
        	get { return m_depth24Bit; }
        }

        [ContextProperty("Глубина32", "Depth32Bit")]
        public int Depth32Bit
        {
        	get { return m_depth32Bit; }
        }

        [ContextProperty("Глубина4", "Depth4Bit")]
        public int Depth4Bit
        {
        	get { return m_depth4Bit; }
        }

        [ContextProperty("Глубина8", "Depth8Bit")]
        public int Depth8Bit
        {
        	get { return m_depth8Bit; }
        }
    }
}
