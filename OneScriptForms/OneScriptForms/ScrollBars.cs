using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлПолосыПрокрутки", "ClScrollBars")]
    public class ClScrollBars : AutoContext<ClScrollBars>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.ScrollBars.None; // 0 Полосы прокрутки не отображаются.
        private int m_horizontal = (int)System.Windows.Forms.ScrollBars.Horizontal; // 1 Отображаются только горизонтальные полосы прокрутки.
        private int m_vertical = (int)System.Windows.Forms.ScrollBars.Vertical; // 2 Отображаются только вертикальные полосы прокрутки.
        private int m_both = (int)System.Windows.Forms.ScrollBars.Both; // 3 Отображаются горизонтальная и вертикальная полосы прокрутки.

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

        public ClScrollBars()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Both));
            _list.Add(ValueFactory.Create(Horizontal));
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

        [ContextProperty("Обе", "Both")]
        public int Both
        {
        	get { return m_both; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }
    }
}
