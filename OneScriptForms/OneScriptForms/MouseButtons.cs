using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлКнопкиМыши", "ClMouseButtons")]
    public class ClMouseButtons : AutoContext<ClMouseButtons>
    {
        private int m_left = (int)System.Windows.Forms.MouseButtons.Left; // 1048576 Была нажата левая кнопка мыши.
        private int m_right = (int)System.Windows.Forms.MouseButtons.Right; // 2097152 Была нажата правая кнопка мыши.
        private int m_middle = (int)System.Windows.Forms.MouseButtons.Middle; // 4194304 Была нажата средняя кнопка мыши.

        [ContextProperty("Левая", "Left")]
        public int Left
        {
        	get { return m_left; }
        }

        [ContextProperty("Правая", "Right")]
        public int Right
        {
        	get { return m_right; }
        }

        [ContextProperty("Средняя", "Middle")]
        public int Middle
        {
        	get { return m_middle; }
        }
    }
}
