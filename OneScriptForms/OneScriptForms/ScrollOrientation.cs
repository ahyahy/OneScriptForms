using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлОриентацияПолосы", "ClScrollOrientation")]
    public class ClScrollOrientation : AutoContext<ClScrollOrientation>
    {
        private int m_horizontalScroll = (int)System.Windows.Forms.ScrollOrientation.HorizontalScroll; // 0 Горизонтальная полоса прокрутки.
        private int m_verticalScroll = (int)System.Windows.Forms.ScrollOrientation.VerticalScroll; // 1 Вертикальная полоса прокрутки.

        [ContextProperty("ВертикальнаяПрокрутка", "VerticalScroll")]
        public int VerticalScroll
        {
        	get { return m_verticalScroll; }
        }

        [ContextProperty("ГоризонтальнаяПрокрутка", "HorizontalScroll")]
        public int HorizontalScroll
        {
        	get { return m_horizontalScroll; }
        }
    }
}
