using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСтильГраницыПанелиСтрокиСостояния", "ClStatusBarPanelBorderStyle")]
    public class ClStatusBarPanelBorderStyle : AutoContext<ClStatusBarPanelBorderStyle>
    {
        private int m_none = (int)System.Windows.Forms.StatusBarPanelBorderStyle.None; // 1 Граница не отображается.
        private int m_raised = (int)System.Windows.Forms.StatusBarPanelBorderStyle.Raised; // 2 Трехмерная приподнятая граница.
        private int m_sunken = (int)System.Windows.Forms.StatusBarPanelBorderStyle.Sunken; // 3 Трехмерная утопленная граница.

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("Рельефная", "Raised")]
        public int Raised
        {
        	get { return m_raised; }
        }

        [ContextProperty("Утопленная", "Sunken")]
        public int Sunken
        {
        	get { return m_sunken; }
        }

    }
}
