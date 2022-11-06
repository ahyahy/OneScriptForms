using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСтильСетки", "ClGridLineStyle")]
    public class ClGridLineStyle : AutoContext<ClGridLineStyle>
    {
        private int m_none = 0; // 0 Сетка не отображается.
        private int m_horizontal = 1; // 1 Отображаются горизонтальные линии.
        private int m_vertical = 2; // 2 Отображаются вертикальные линии.
        private int m_horizontalAndVertical = 3; // 3 Отображаются горизонтальные и вертикальные линии.

        [ContextProperty("Вертикальная", "Vertical")]
        public int Vertical
        {
        	get { return m_vertical; }
        }

        [ContextProperty("Горизонтальная", "Horizontal")]
        public int Horizontal
        {
        	get { return m_horizontal; }
        }

        [ContextProperty("ГоризонтальнаяВертикальная", "HorizontalAndVertical")]
        public int HorizontalAndVertical
        {
        	get { return m_horizontalAndVertical; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }
    }
}
