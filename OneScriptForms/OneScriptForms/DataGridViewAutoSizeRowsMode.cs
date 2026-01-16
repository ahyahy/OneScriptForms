using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлРежимАвтоРазмераСтрок", "ClDataGridViewAutoSizeRowsMode")]
    public class ClDataGridViewAutoSizeRowsMode : AutoContext<ClDataGridViewAutoSizeRowsMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.None; // 0 Значения высоты строк не изменяются автоматически.
        private int m_allHeaders = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders; // 5 Значения высоты строк изменяются в соответствии с содержимым заголовка строк.
        private int m_allCellsExceptHeaders = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders; // 6 Значения высоты строк изменяются в соответствии с содержимым всех ячеек в строках, исключая ячейки заголовка.
        private int m_allCells = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells; // 7 Значения высоты строк изменяются в соответствии с содержимым всех ячеек в строках, включая ячейки заголовка.
        private int m_displayedHeaders = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders; // 9 Значения высоты строк изменяются в соответствии с содержимым заголовков строк, отображаемых в текущий момент на экране.
        private int m_displayedCellsExceptHeaders = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders; // 10 Значения высоты строк изменяются в соответствии с содержимым всех ячеек в строках, отображаемых в текущий момент на экране, исключая ячейки заголовка.
        private int m_displayedCells = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells; // 11 Значения высоты строк изменяются в соответствии с содержимым всех ячеек в строках, отображаемых в текущий момент на экране, включая ячейки заголовка.

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
            {5, "ВсеЗаголовки"},
            {7, "ВсеЯчейки"},
            {6, "ВсеЯчейкиБезЗаголовков"},
            {9, "ОтобразритьЗаголовки"},
            {11, "ОтобразритьЯчейки"},
            {10, "ОтобразритьЯчейкиБезЗаголовков"},
            {0, "Отсутствие"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {5, "AllHeaders"},
            {7, "AllCells"},
            {6, "AllCellsExceptHeaders"},
            {9, "DisplayedHeaders"},
            {11, "DisplayedCells"},
            {10, "DisplayedCellsExceptHeaders"},
            {0, "None"},
        };

        public ClDataGridViewAutoSizeRowsMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(AllCells));
            _list.Add(ValueFactory.Create(AllCellsExceptHeaders));
            _list.Add(ValueFactory.Create(AllHeaders));
            _list.Add(ValueFactory.Create(DisplayedCells));
            _list.Add(ValueFactory.Create(DisplayedCellsExceptHeaders));
            _list.Add(ValueFactory.Create(DisplayedHeaders));
            _list.Add(ValueFactory.Create(None));
        }

        [ContextProperty("ВсеЗаголовки", "AllHeaders")]
        public int AllHeaders
        {
            get { return m_allHeaders; }
        }

        [ContextProperty("ВсеЯчейки", "AllCells")]
        public int AllCells
        {
            get { return m_allCells; }
        }

        [ContextProperty("ВсеЯчейкиБезЗаголовков", "AllCellsExceptHeaders")]
        public int AllCellsExceptHeaders
        {
            get { return m_allCellsExceptHeaders; }
        }

        [ContextProperty("ОтобразритьЗаголовки", "DisplayedHeaders")]
        public int DisplayedHeaders
        {
            get { return m_displayedHeaders; }
        }

        [ContextProperty("ОтобразритьЯчейки", "DisplayedCells")]
        public int DisplayedCells
        {
            get { return m_displayedCells; }
        }

        [ContextProperty("ОтобразритьЯчейкиБезЗаголовков", "DisplayedCellsExceptHeaders")]
        public int DisplayedCellsExceptHeaders
        {
            get { return m_displayedCellsExceptHeaders; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return m_none; }
        }
    }
}
