using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлВертикальноеВыравнивание", "ClVerticalAlign")]
    public class ClVerticalAlign : AutoContext<ClVerticalAlign>
    {
        private int m_top = 0; // 0 Выравнивание по верхнему краю.
        private int m_bottom = 1; // 1 Выравнивание по нижнему краю.
        private int m_center = 2; // 2 Выравнивание по центру.

        [ContextProperty("Верх", "Top")]
        public int Top
        {
        	get { return m_top; }
        }

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
        	get { return m_bottom; }
        }

        [ContextProperty("Центр", "Center")]
        public int Center
        {
        	get { return m_center; }
        }
    }
}
