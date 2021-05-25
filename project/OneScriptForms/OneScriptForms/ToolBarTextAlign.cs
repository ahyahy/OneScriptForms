using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлВыравниваниеТекстаВПанелиИнструментов", "ClToolBarTextAlign")]
    public class ClToolBarTextAlign : AutoContext<ClToolBarTextAlign>
    {
        private int m_underneath = (int)System.Windows.Forms.ToolBarTextAlign.Underneath; // 0 Текст выравнивается по нижней границе изображения кнопки панели инструментов.
        private int m_right = (int)System.Windows.Forms.ToolBarTextAlign.Right; // 1 Текст выравнивается по правому краю изображения кнопки панели инструментов.

        [ContextProperty("Понизу", "Underneath")]
        public int Underneath
        {
        	get { return m_underneath; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
        	get { return m_right; }
        }

    }
}
