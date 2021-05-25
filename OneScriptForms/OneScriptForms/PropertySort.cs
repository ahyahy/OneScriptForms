using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСортировкаСвойств", "ClPropertySort")]
    public class ClPropertySort : AutoContext<ClPropertySort>
    {
        private int m_noSort = (int)System.Windows.Forms.PropertySort.NoSort; // 0 Свойства не сортируются.
        private int m_alphabetical = (int)System.Windows.Forms.PropertySort.Alphabetical; // 1 Свойства сортируются в алфавитном порядке.
        private int m_categorized = (int)System.Windows.Forms.PropertySort.Categorized; // 2 Свойства сортируются в соответствии с их категорией в группе. Категории определяются непосредственно из свойств.
        private int m_categorizedAlphabetical = (int)System.Windows.Forms.PropertySort.CategorizedAlphabetical; // 3 Свойства сортируются в соответствии с их категорией в группе. Дополнительные свойства сортируются в алфавитном порядке в пределах группы. Категории определяются непосредственно из свойств.

        [ContextProperty("БезСортировки", "NoSort")]
        public int NoSort
        {
        	get { return m_noSort; }
        }

        [ContextProperty("ПоАлфавиту", "Alphabetical")]
        public int Alphabetical
        {
        	get { return m_alphabetical; }
        }

        [ContextProperty("ПоКатегориям", "Categorized")]
        public int Categorized
        {
        	get { return m_categorized; }
        }

        [ContextProperty("ПоКатегориямПоАлфавиту", "CategorizedAlphabetical")]
        public int CategorizedAlphabetical
        {
        	get { return m_categorizedAlphabetical; }
        }

    }
}
