using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлРежимАвтоРазмераСтрок", "ClDataGridViewAutoSizeRowsMode")]
    public class ClDataGridViewAutoSizeRowsMode : AutoContext<ClDataGridViewAutoSizeRowsMode>
    {
        private int m_none = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.None; // 0 Значения высоты строк не изменяются автоматически.
        private int m_allHeaders = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders; // 5 Значения высоты строк изменяются в соответствии с содержимым заголовка строк.
        private int m_allCellsExceptHeaders = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders; // 6 Значения высоты строк изменяются в соответствии с содержимым всех ячеек в строках, исключая ячейки заголовка.
        private int m_allCells = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells; // 7 Значения высоты строк изменяются в соответствии с содержимым всех ячеек в строках, включая ячейки заголовка.
        private int m_displayedHeaders = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders; // 9 Значения высоты строк изменяются в соответствии с содержимым заголовков строк, отображаемых в текущий момент на экране.
        private int m_displayedCellsExceptHeaders = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders; // 10 Значения высоты строк изменяются в соответствии с содержимым всех ячеек в строках, отображаемых в текущий момент на экране, исключая ячейки заголовка.
        private int m_displayedCells = (int)System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells; // 11 Значения высоты строк изменяются в соответствии с содержимым всех ячеек в строках, отображаемых в текущий момент на экране, включая ячейки заголовка.

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
