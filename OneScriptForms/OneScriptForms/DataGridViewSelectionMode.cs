using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлРежимВыбораТаблицы", "ClDataGridViewSelectionMode")]
    public class ClDataGridViewSelectionMode : AutoContext<ClDataGridViewSelectionMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_cellSelect = (int)System.Windows.Forms.DataGridViewSelectionMode.CellSelect; // 0 Можно выбрать одну или несколько отдельных ячеек.
        private int m_fullRowSelect = (int)System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; // 1 Вся строка может быть выбрана путем щелчка заголовка строки или ячейки, содержащейся в этой строке.
        private int m_fullColumnSelect = (int)System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect; // 2 Вся колонка может быть выбрана путем щелчка заголовка колонки или ячейки, содержащейся в этой колонке.
        private int m_rowHeaderSelect = (int)System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect; // 3 Строка может быть выбрана путем щелчка заголовка строки. Отдельную ячейку можно выбрать, щелкнув ее.
        private int m_columnHeaderSelect = (int)System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect; // 4 Колонка будет выбрана путем щелчка ячейки заголовка колонки. Отдельную ячейку можно выбрать, щелкнув ее.

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
            {4, "ЗаголовокКолонки"},
            {3, "ЗаголовокСтроки"},
            {2, "Колонка"},
            {1, "Строка"},
            {0, "Ячейка"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {4, "ColumnHeaderSelect"},
            {3, "RowHeaderSelect"},
            {2, "FullColumnSelect"},
            {1, "FullRowSelect"},
            {0, "CellSelect"},
        };

        public ClDataGridViewSelectionMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(CellSelect));
            _list.Add(ValueFactory.Create(ColumnHeaderSelect));
            _list.Add(ValueFactory.Create(FullColumnSelect));
            _list.Add(ValueFactory.Create(FullRowSelect));
            _list.Add(ValueFactory.Create(RowHeaderSelect));
        }

        [ContextProperty("ЗаголовокКолонки", "ColumnHeaderSelect")]
        public int ColumnHeaderSelect
        {
            get { return m_columnHeaderSelect; }
        }

        [ContextProperty("ЗаголовокСтроки", "RowHeaderSelect")]
        public int RowHeaderSelect
        {
            get { return m_rowHeaderSelect; }
        }

        [ContextProperty("Колонка", "FullColumnSelect")]
        public int FullColumnSelect
        {
            get { return m_fullColumnSelect; }
        }

        [ContextProperty("Строка", "FullRowSelect")]
        public int FullRowSelect
        {
            get { return m_fullRowSelect; }
        }

        [ContextProperty("Ячейка", "CellSelect")]
        public int CellSelect
        {
            get { return m_cellSelect; }
        }
    }
}
