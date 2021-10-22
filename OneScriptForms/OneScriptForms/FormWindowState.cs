using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСостояниеОкнаФормы", "ClFormWindowState")]
    public class ClFormWindowState : AutoContext<ClFormWindowState>
    {
        private int m_normal = (int)System.Windows.Forms.FormWindowState.Normal; // 0 Окно с размерами по умолчанию.
        private int m_minimized = (int)System.Windows.Forms.FormWindowState.Minimized; // 1 Свернутое окно.
        private int m_maximized = (int)System.Windows.Forms.FormWindowState.Maximized; // 2 Развернутое окно.

        [ContextProperty("Развернутое", "Maximized")]
        public int Maximized
        {
        	get { return m_maximized; }
        }

        [ContextProperty("Свернутое", "Minimized")]
        public int Minimized
        {
        	get { return m_minimized; }
        }

        [ContextProperty("Стандартное", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }
    }
}
