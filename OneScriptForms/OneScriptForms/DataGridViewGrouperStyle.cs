using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСтильГруппировкиТаблицы", "ClDataGridViewGrouperStyle")]
    public class ClDataGridViewGrouperStyle : AutoContext<ClDataGridViewGrouperStyle>
    {
        private int m_firstLetter = 0; // 0 Группировка осуществляется на основе первого символа.
        private int m_firstWord = 1; // 1 Группировка осуществляется на основе первого слова.
        private int m_lastWord = 2; // 2 Группировка осуществляется на основе последнего слова.

        [ContextProperty("ПервоеСлово", "FirstWord")]
        public int FirstWord
        {
        	get { return m_firstWord; }
        }

        [ContextProperty("ПервыйСимвол", "FirstLetter")]
        public int FirstLetter
        {
        	get { return m_firstLetter; }
        }

        [ContextProperty("ПоследнееСлово", "LastWord")]
        public int LastWord
        {
        	get { return m_lastWord; }
        }
    }
}
