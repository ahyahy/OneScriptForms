using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлЛевоеПравоеВыравнивание", "ClLeftRightAlignment")]
    public class ClLeftRightAlignment : AutoContext<ClLeftRightAlignment>
    {
        private int m_left = (int)System.Windows.Forms.LeftRightAlignment.Left; // 0 Объект или текст выравнивается влево от контрольной точки.
        private int m_right = (int)System.Windows.Forms.LeftRightAlignment.Right; // 1 Объект или текст выравнивается вправо от контрольной точки.

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

    }
}
