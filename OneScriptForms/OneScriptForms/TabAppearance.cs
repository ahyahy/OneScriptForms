using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлОформлениеВкладок", "ClTabAppearance")]
    public class ClTabAppearance : AutoContext<ClTabAppearance>
    {
        private int m_normal = (int)System.Windows.Forms.TabAppearance.Normal; // 0 Вкладки имеют стандартный внешний вид вкладок.
        private int m_buttons = (int)System.Windows.Forms.TabAppearance.Buttons; // 1 Вкладки имеют вид объемных кнопок.
        private int m_flatButtons = (int)System.Windows.Forms.TabAppearance.FlatButtons; // 2 Вкладки имеют вид плоских кнопок.

        [ContextProperty("Кнопки", "Buttons")]
        public int Buttons
        {
        	get { return m_buttons; }
        }

        [ContextProperty("ПлоскиеКнопки", "FlatButtons")]
        public int FlatButtons
        {
        	get { return m_flatButtons; }
        }

        [ContextProperty("Стандартный", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }
    }
}
