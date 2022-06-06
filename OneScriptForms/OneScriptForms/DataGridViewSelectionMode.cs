using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлРежимВыбораТаблицы", "ClDataGridViewSelectionMode")]
    public class ClDataGridViewSelectionMode : AutoContext<ClDataGridViewSelectionMode>
    {
        private int m_cellSelect = (int)System.Windows.Forms.DataGridViewSelectionMode.CellSelect; // 0 Можно выбрать одну или несколько отдельных ячеек.
        private int m_fullRowSelect = (int)System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; // 1 Вся строка может быть выбрана путем щелчка заголовка строки или ячейки, содержащейся в этой строке.
        private int m_fullColumnSelect = (int)System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect; // 2 Вся колонка может быть выбрана путем щелчка заголовка колонки или ячейки, содержащейся в этой колонке.
        private int m_rowHeaderSelect = (int)System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect; // 3 Строка может быть выбрана путем щелчка заголовка строки. Отдельную ячейку можно выбрать, щелкнув ее.
        private int m_columnHeaderSelect = (int)System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect; // 4 Колонка будет выбрана путем щелчка ячейки заголовка колонки. Отдельную ячейку можно выбрать, щелкнув ее.

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
