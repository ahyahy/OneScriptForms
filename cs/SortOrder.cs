using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлПорядокСортировки", "ClSortOrder")]
    public class ClSortOrder : AutoContext<ClSortOrder>
    {
        private int m_none = (int)System.Windows.Forms.SortOrder.None; // 0 Элементы не сортируются.
        private int m_ascending = (int)System.Windows.Forms.SortOrder.Ascending; // 1 Элементы сортируются в порядке возрастания.
        private int m_descending = (int)System.Windows.Forms.SortOrder.Descending; // 2 Элементы сортируются в порядке убывания.

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("ПоВозрастанию", "Ascending")]
        public int Ascending
        {
        	get { return m_ascending; }
        }

        [ContextProperty("ПоУбыванию", "Descending")]
        public int Descending
        {
        	get { return m_descending; }
        }

    }
}
