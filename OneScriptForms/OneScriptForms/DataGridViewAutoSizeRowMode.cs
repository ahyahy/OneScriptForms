using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРежимАвтоРазмераСтроки", "ClDataGridViewAutoSizeRowMode")]
    public class ClDataGridViewAutoSizeRowMode : AutoContext<ClDataGridViewAutoSizeRowMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_rowHeader = (int)System.Windows.Forms.DataGridViewAutoSizeRowMode.RowHeader; // 1 Высота строки изменяется в соответствии с содержимым заголовка строки.
        private int m_allCellsExceptHeader = (int)System.Windows.Forms.DataGridViewAutoSizeRowMode.AllCellsExceptHeader; // 2 Высота строки изменяется в соответствии с содержимым всех ее ячеек, исключая ячейку заголовка.
        private int m_allCells = (int)System.Windows.Forms.DataGridViewAutoSizeRowMode.AllCells; // 3 Высота строки изменяется в соответствии с содержимым всех ее ячеек, включая ячейку заголовка.

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

        internal ClDataGridViewAutoSizeRowMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(AllCells));
            _list.Add(ValueFactory.Create(AllCellsExceptHeader));
            _list.Add(ValueFactory.Create(RowHeader));
        }

        [ContextProperty("ВсеЯчейки", "AllCells")]
        public int AllCells
        {
        	get { return m_allCells; }
        }

        [ContextProperty("ВсеЯчейкиБезЗаголовков", "AllCellsExceptHeader")]
        public int AllCellsExceptHeader
        {
        	get { return m_allCellsExceptHeader; }
        }

        [ContextProperty("ЗаголовокСтроки", "RowHeader")]
        public int RowHeader
        {
        	get { return m_rowHeader; }
        }
    }
}
