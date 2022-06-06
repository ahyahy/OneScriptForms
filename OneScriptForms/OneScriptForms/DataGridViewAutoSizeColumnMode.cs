using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлРежимАвтоРазмераКолонки", "ClDataGridViewAutoSizeColumnMode")]
    public class ClDataGridViewAutoSizeColumnMode : AutoContext<ClDataGridViewAutoSizeColumnMode>
    {
        private int m_notSet = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet; // 0 Режим изменения размеров колонки наследуется из свойства AutoSizeColumnsMode.
        private int m_none = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.None; // 1 Значения ширины колонок не изменяются автоматически.
        private int m_columnHeader = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader; // 2 Ширина колонки изменяется так, чтобы вместить содержимое ячейки заголовка для колонки.
        private int m_allCellsExceptHeader = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // 4 Ширина колонки изменяется так, чтобы вместить содержимое всех ячеек колонки, за исключением ячейки заголовка.
        private int m_allCells = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells; // 6 Ширина колонки изменяется так, чтобы вместить содержимое всех ячеек колонки, включая ячейку заголовка.
        private int m_displayedCellsExceptHeader = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader; // 8 Ширина колонки изменяется так, чтобы вместить содержимое всех ячеек колонки, которые находятся в строках, отображающихся на экране в настоящий момент, за исключением строки заголовка.
        private int m_displayedCells = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells; // 10 Ширина колонки изменяется так, чтобы вместить содержимое всех ячеек колонки, которые находятся в строках, отображающихся на экране в настоящий момент, включая строку заголовка.
        private int m_fill = (int)System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill; // 16 Ширина колонки подбирается таким образом, чтобы суммарная ширина всех колонок в точности заполняла отображаемую область элемента управления, а прокрутка по горизонтали требовалась только для колонок, ширина которых превышает значение свойства <A href="OneScriptForms.DataGridViewColumn.MinimumWidth.html">КолонкаТаблицы.МинимальнаяШирина&nbsp;(DataGridViewColumn.MinimumWidth)</A>.

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
