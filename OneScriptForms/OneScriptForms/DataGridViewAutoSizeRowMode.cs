using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлРежимАвтоРазмераСтроки", "ClDataGridViewAutoSizeRowMode")]
    public class ClDataGridViewAutoSizeRowMode : AutoContext<ClDataGridViewAutoSizeRowMode>
    {
        private int m_rowHeader = (int)System.Windows.Forms.DataGridViewAutoSizeRowMode.RowHeader; // 1 Высота строки изменяется в соответствии с содержимым заголовка строки.
        private int m_allCellsExceptHeader = (int)System.Windows.Forms.DataGridViewAutoSizeRowMode.AllCellsExceptHeader; // 2 Высота строки изменяется в соответствии с содержимым всех ее ячеек, исключая ячейку заголовка.
        private int m_allCells = (int)System.Windows.Forms.DataGridViewAutoSizeRowMode.AllCells; // 3 Высота строки изменяется в соответствии с содержимым всех ее ячеек, включая ячейку заголовка.

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
