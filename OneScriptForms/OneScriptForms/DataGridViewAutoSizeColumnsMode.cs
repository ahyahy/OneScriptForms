using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРежимАвтоРазмераКолонок", "ClDataGridViewAutoSizeColumnsMode")]
    public class ClDataGridViewAutoSizeColumnsMode : AutoContext<ClDataGridViewAutoSizeColumnsMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None; // 1 Значения ширины колонок не изменяются автоматически.
        private int m_columnHeader = (int)System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader; // 2 Ширина колонок изменяется так, чтобы вместить содержимое ячеек заголовков колонок.
        private int m_allCellsExceptHeader = (int)System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader; // 4 Ширина колонок изменяется так, чтобы вместить содержимое всех ячеек колонок, исключая ячейки заголовков.
        private int m_allCells = (int)System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells; // 6 Ширина колонок изменяется так, чтобы вместить содержимое всех ячеек колонок, включая ячейки заголовков.
        private int m_displayedCellsExceptHeader = (int)System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader; // 8 Ширина колонок изменяется так, чтобы вместить содержимое всех ячеек колонок, которые находятся в строках, отображающихся на экране в настоящий момент, исключая ячейки заголовков.
        private int m_displayedCells = (int)System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells; // 10 Ширина колонок изменяется так, чтобы вместить содержимое всех ячеек колонок, которые находятся в строках, отображающихся на экране в настоящий момент, включая ячейки заголовков.
        private int m_fill = (int)System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // 16 Ширина колонок подбирается таким образом, чтобы суммарная ширина всех колонок в точности заполняла отображаемую область элемента управления, а прокрутка по горизонтали требовалась только для того, чтобы не допускать уменьшения ширины колонок ниже значений свойства <A href="OneScriptForms.DataGridViewColumn.MinimumWidth.html">КолонкаТаблицы.МинимальнаяШирина&nbsp;(DataGridViewColumn.MinimumWidth)</A>.

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

        internal ClDataGridViewAutoSizeColumnsMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(AllCells));
            _list.Add(ValueFactory.Create(AllCellsExceptHeader));
            _list.Add(ValueFactory.Create(ColumnHeader));
            _list.Add(ValueFactory.Create(DisplayedCells));
            _list.Add(ValueFactory.Create(DisplayedCellsExceptHeader));
            _list.Add(ValueFactory.Create(Fill));
            _list.Add(ValueFactory.Create(None));
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
