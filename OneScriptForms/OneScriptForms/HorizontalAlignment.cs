using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлГоризонтальноеВыравнивание", "ClHorizontalAlignment")]
    public class ClHorizontalAlignment : AutoContext<ClHorizontalAlignment>
    {
        private int m_left = (int)System.Windows.Forms.HorizontalAlignment.Left; // 0 Объект или текст выравнивается по левой части элемента управления.
        private int m_right = (int)System.Windows.Forms.HorizontalAlignment.Right; // 1 Объект или текст выравнивается по правому краю элемента управления.
        private int m_center = (int)System.Windows.Forms.HorizontalAlignment.Center; // 2 Объект или текст выравнивается по центру элемента управления.

        [ContextProperty("Лево", "Left")]
        public int Left
        {
        	get { return m_left; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
        	get { return m_right; }
        }

        [ContextProperty("Центр", "Center")]
        public int Center
        {
        	get { return m_center; }
        }
    }
}
