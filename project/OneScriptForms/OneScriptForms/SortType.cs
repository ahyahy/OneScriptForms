using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлТипСортировки", "ClSortType")]
    public class ClSortType : AutoContext<ClSortType>
    {
        private int m_text = 0; // 0 Тип сортировки <B>Текст</B>.
        private int m_number = 1; // 1 Тип сортировки <B>Число</B>.
        private int m_dateTime = 2; // 2 Тип сортировки <B>Дата</B>.
        private int m_boolean = 3; // 3 Тип сортировки <B>Булево</B>.

        [ContextProperty("Булево", "Boolean")]
        public int Boolean
        {
        	get { return m_boolean; }
        }

        [ContextProperty("ДатаВремя", "DateTime")]
        public int DateTime
        {
        	get { return m_dateTime; }
        }

        [ContextProperty("Текст", "Text")]
        public int Text
        {
        	get { return m_text; }
        }

        [ContextProperty("Число", "Number")]
        public int Number
        {
        	get { return m_number; }
        }

    }
}
