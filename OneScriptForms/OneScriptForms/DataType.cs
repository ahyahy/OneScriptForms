using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлТипДанных", "ClDataType")]
    public class ClDataType : AutoContext<ClDataType>
    {
        private int m_string = 0; // 0 Тип данных <B>Строка</B>.
        private int m_number = 1; // 1 Тип данных <B>Число</B>.
        private int m_boolean = 2; // 2 Тип данных <B>Булево</B>.
        private int m_date = 3; // 3 Тип данных <B>Дата</B>.
        private int m_object = 4; // 4 Тип данных <B>Объект</B>.

        [ContextProperty("Булево", "Boolean")]
        public int Boolean
        {
        	get { return m_boolean; }
        }

        [ContextProperty("Дата", "Date")]
        public int Date
        {
        	get { return m_date; }
        }

        [ContextProperty("Объект", "Object")]
        public int Object
        {
        	get { return m_object; }
        }

        [ContextProperty("Строка", "String")]
        public int String
        {
        	get { return m_string; }
        }

        [ContextProperty("Число", "Number")]
        public int Number
        {
        	get { return m_number; }
        }

    }
}
