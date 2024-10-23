using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСтильСетки", "ClGridLineStyle")]
    public class ClGridLineStyle : AutoContext<ClGridLineStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = 0; // 0 Сетка не отображается.
        private int m_horizontal = 1; // 1 Отображаются горизонтальные линии.
        private int m_vertical = 2; // 2 Отображаются вертикальные линии.
        private int m_horizontalAndVertical = 3; // 3 Отображаются горизонтальные и вертикальные линии.

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

        public ClGridLineStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Horizontal));
            _list.Add(ValueFactory.Create(HorizontalAndVertical));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Vertical));
        }

        [ContextProperty("Вертикальная", "Vertical")]
        public int Vertical
        {
        	get { return m_vertical; }
        }

        [ContextProperty("Горизонтальная", "Horizontal")]
        public int Horizontal
        {
        	get { return m_horizontal; }
        }

        [ContextProperty("ГоризонтальнаяВертикальная", "HorizontalAndVertical")]
        public int HorizontalAndVertical
        {
        	get { return m_horizontalAndVertical; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }
    }
}
