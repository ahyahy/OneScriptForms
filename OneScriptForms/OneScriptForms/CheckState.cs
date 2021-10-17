using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСостояниеФлажка", "ClCheckState")]
    public class ClCheckState : AutoContext<ClCheckState>
    {
        private int m_unchecked = (int)System.Windows.Forms.CheckState.Unchecked; // 0 Пометка элемента управления снята.
        private int m_checked = (int)System.Windows.Forms.CheckState.Checked; // 1 Данный элемент управления помечен.
        private int m_indeterminate = (int)System.Windows.Forms.CheckState.Indeterminate; // 2 Пометка элемента управления не определена. Такой элемент управления обычно затенен.

        [ContextProperty("Неопределенный", "Indeterminate")]
        public int Indeterminate
        {
        	get { return m_indeterminate; }
        }

        [ContextProperty("НеПомечен", "Unchecked")]
        public int Unchecked
        {
        	get { return m_unchecked; }
        }

        [ContextProperty("Помечен", "Checked")]
        public int Checked
        {
        	get { return m_checked; }
        }

    }
}
