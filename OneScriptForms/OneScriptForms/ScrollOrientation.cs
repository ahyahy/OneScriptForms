using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлОриентацияПолосы", "ClScrollOrientation")]
    public class ClScrollOrientation : AutoContext<ClScrollOrientation>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_horizontalScroll = (int)System.Windows.Forms.ScrollOrientation.HorizontalScroll; // 0 Горизонтальная полоса прокрутки.
        private int m_verticalScroll = (int)System.Windows.Forms.ScrollOrientation.VerticalScroll; // 1 Вертикальная полоса прокрутки.

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

        public ClScrollOrientation()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(HorizontalScroll));
            _list.Add(ValueFactory.Create(VerticalScroll));
        }

        [ContextProperty("ВертикальнаяПрокрутка", "VerticalScroll")]
        public int VerticalScroll
        {
        	get { return m_verticalScroll; }
        }

        [ContextProperty("ГоризонтальнаяПрокрутка", "HorizontalScroll")]
        public int HorizontalScroll
        {
        	get { return m_horizontalScroll; }
        }
    }
}
