using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлОформлениеПанелиИнструментов", "ClToolBarAppearance")]
    public class ClToolBarAppearance : AutoContext<ClToolBarAppearance>
    {
        private int m_normal = (int)System.Windows.Forms.ToolBarAppearance.Normal; // 0 Панель инструментов и кнопки отображаются как обычные трехмерные элементы управления.
        private int m_flat = (int)System.Windows.Forms.ToolBarAppearance.Flat; // 1 Панель инструментов и кнопки отображаются плоскими, однако кнопки становятся объемными когда указатель мыши перемещается над ними.

        [ContextProperty("Плоский", "Flat")]
        public int Flat
        {
        	get { return m_flat; }
        }

        [ContextProperty("Стандартный", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }

    }
}
