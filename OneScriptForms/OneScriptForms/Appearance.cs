using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлОформление", "ClAppearance")]
    public class ClAppearance : AutoContext<ClAppearance>
    {
        private int m_normal = (int)System.Windows.Forms.Appearance.Normal; // 0 Внешний вид по умолчанию, определенный классом элемента управления.
        private int m_button = (int)System.Windows.Forms.Appearance.Button; // 1 Внешний вид кнопки Windows.

        [ContextProperty("Кнопка", "Button")]
        public int Button
        {
        	get { return m_button; }
        }

        [ContextProperty("Стандартное", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }
    }
}
