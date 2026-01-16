using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлРежимАвтоРазмераСтроки", "ClDataGridViewAutoSizeRowMode")]
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
            {3, "ВсеЯчейки"},
            {2, "ВсеЯчейкиБезЗаголовков"},
            {1, "ЗаголовокСтроки"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {3, "AllCells"},
            {2, "AllCellsExceptHeader"},
            {1, "RowHeader"},
        };

        public ClDataGridViewAutoSizeRowMode()
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
