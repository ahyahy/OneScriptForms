using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлРежимАвтоРазмераКолонки", "ClDataGridViewAutoSizeColumnMode")]
    public class ClDataGridViewAutoSizeColumnMode : AutoContext<ClDataGridViewAutoSizeColumnMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_notSet = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet; // 0 Режим изменения размеров колонки наследуется из свойства AutoSizeColumnsMode.
        private int m_none = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.None; // 1 Значения ширины колонок не изменяются автоматически.
        private int m_columnHeader = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader; // 2 Ширина колонки изменяется так, чтобы вместить содержимое ячейки заголовка для колонки.
        private int m_allCellsExceptHeader = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // 4 Ширина колонки изменяется так, чтобы вместить содержимое всех ячеек колонки, за исключением ячейки заголовка.
        private int m_allCells = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells; // 6 Ширина колонки изменяется так, чтобы вместить содержимое всех ячеек колонки, включая ячейку заголовка.
        private int m_displayedCellsExceptHeader = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader; // 8 Ширина колонки изменяется так, чтобы вместить содержимое всех ячеек колонки, которые находятся в строках, отображающихся на экране в настоящий момент, за исключением строки заголовка.
        private int m_displayedCells = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells; // 10 Ширина колонки изменяется так, чтобы вместить содержимое всех ячеек колонки, которые находятся в строках, отображающихся на экране в настоящий момент, включая строку заголовка.
        private int m_fill = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill; // 16 Ширина колонки подбирается таким образом, чтобы суммарная ширина всех колонок в точности заполняла отображаемую область элемента управления, а прокрутка по горизонтали требовалась только для колонок, ширина которых превышает значение свойства <A href="OneScriptForms.DataGridViewColumn.MinimumWidth.html">КолонкаТаблицы.МинимальнаяШирина&nbsp;(DataGridViewColumn.MinimumWidth)</A>.

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
            {6, "ВсеЯчейки"},
            {4, "ВсеЯчейкиБезЗаголовков"},
            {2, "ЗаголовокКолонки"},
            {16, "Заполнение"},
            {0, "НеУстановлено"},
            {10, "ОтобразритьЯчейки"},
            {8, "ОтобразритьЯчейкиБезЗаголовков"},
            {1, "Отсутствие"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {6, "AllCells"},
            {4, "AllCellsExceptHeader"},
            {2, "ColumnHeader"},
            {16, "Fill"},
            {0, "NotSet"},
            {10, "DisplayedCells"},
            {8, "DisplayedCellsExceptHeader"},
            {1, "None"},
        };

        public ClDataGridViewAutoSizeColumnMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(AllCells));
            _list.Add(ValueFactory.Create(AllCellsExceptHeader));
            _list.Add(ValueFactory.Create(ColumnHeader));
            _list.Add(ValueFactory.Create(DisplayedCells));
            _list.Add(ValueFactory.Create(DisplayedCellsExceptHeader));
            _list.Add(ValueFactory.Create(Fill));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(NotSet));
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

        [ContextProperty("ЗаголовокКолонки", "ColumnHeader")]
        public int ColumnHeader
        {
            get { return m_columnHeader; }
        }

        [ContextProperty("Заполнение", "Fill")]
        public int Fill
        {
            get { return m_fill; }
        }

        [ContextProperty("НеУстановлено", "NotSet")]
        public int NotSet
        {
            get { return m_notSet; }
        }

        [ContextProperty("ОтобразритьЯчейки", "DisplayedCells")]
        public int DisplayedCells
        {
            get { return m_displayedCells; }
        }

        [ContextProperty("ОтобразритьЯчейкиБезЗаголовков", "DisplayedCellsExceptHeader")]
        public int DisplayedCellsExceptHeader
        {
            get { return m_displayedCellsExceptHeader; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return m_none; }
        }
    }
}
