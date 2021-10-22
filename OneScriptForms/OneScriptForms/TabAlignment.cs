using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлВыравниваниеВкладок", "ClTabAlignment")]
    public class ClTabAlignment : AutoContext<ClTabAlignment>
    {
        private int m_top = (int)System.Windows.Forms.TabAlignment.Top; // 0 Вкладки расположены по верхнему краю элемента управления.
        private int m_bottom = (int)System.Windows.Forms.TabAlignment.Bottom; // 1 Вкладки расположены по нижнему краю элемента управления.
        private int m_left = (int)System.Windows.Forms.TabAlignment.Left; // 2 Вкладки расположены вдоль левого края элемента управления.
        private int m_right = (int)System.Windows.Forms.TabAlignment.Right; // 3 Вкладки расположены по правому краю элемента управления.

        [ContextProperty("Верх", "Top")]
        public int Top
        {
        	get { return m_top; }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
        	get { return m_left; }
        }

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
        	get { return m_bottom; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
        	get { return m_right; }
        }
    }
}
