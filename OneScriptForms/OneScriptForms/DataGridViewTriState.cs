using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлТриСостояния", "ClDataGridViewTriState")]
    public class ClDataGridViewTriState : AutoContext<ClDataGridViewTriState>
    {
        private int m_notSet = (int)System.Windows.Forms.DataGridViewTriState.NotSet; // 0 Это свойство не задано и будет функционировать по другому.
        private int m_true = (int)System.Windows.Forms.DataGridViewTriState.True; // 1 Состояние свойства - <B>Истина</B>.
        private int m_false = (int)System.Windows.Forms.DataGridViewTriState.False; // 2 Состояние свойства - <B>Ложь</B>.

        [ContextProperty("Истина", "True")]
        public int True
        {
        	get { return m_true; }
        }

        [ContextProperty("Ложь", "False")]
        public int False
        {
        	get { return m_false; }
        }

        [ContextProperty("НеУстановлено", "NotSet")]
        public int NotSet
        {
        	get { return m_notSet; }
        }
    }
}
