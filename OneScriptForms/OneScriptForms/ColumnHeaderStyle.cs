using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСтильЗаголовкаКолонки", "ClColumnHeaderStyle")]
    public class ClColumnHeaderStyle : AutoContext<ClColumnHeaderStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.ColumnHeaderStyle.None; // 0 Заголовок колонки не отображается.
        private int m_nonclickable = (int)System.Windows.Forms.ColumnHeaderStyle.Nonclickable; // 1 Заголовки колонок не отвечают на щелчок мыши.
        private int m_clickable = (int)System.Windows.Forms.ColumnHeaderStyle.Clickable; // 2 Заголовки колонок работают подобно кнопкам и можно выполнять различные действия, например сортировку.

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

        internal ClColumnHeaderStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Clickable));
            _list.Add(ValueFactory.Create(Nonclickable));
            _list.Add(ValueFactory.Create(None));
        }

        [ContextProperty("Нажимаемая", "Clickable")]
        public int Clickable
        {
        	get { return m_clickable; }
        }

        [ContextProperty("НеНажимаемая", "Nonclickable")]
        public int Nonclickable
        {
        	get { return m_nonclickable; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }
    }
}
