using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСтилиПривязки", "ClAnchorStyles")]
    public class ClAnchorStyles : AutoContext<ClAnchorStyles>
    {
        private int m_none = (int)System.Windows.Forms.AnchorStyles.None; // 0 Элемент управления не привязан к краям контейнера.
        private int m_top = (int)System.Windows.Forms.AnchorStyles.Top; // 1 Элемент управления привязан к верхнему краю своего контейнера.
        private int m_bottom = (int)System.Windows.Forms.AnchorStyles.Bottom; // 2 Элемент управления привязан к нижнему краю своего контейнера.
        private int m_left = (int)System.Windows.Forms.AnchorStyles.Left; // 4 Элемент управления привязан к левому краю своего контейнера.
        private int m_right = (int)System.Windows.Forms.AnchorStyles.Right; // 8 Элемент управления привязан к правому краю своего контейнера.

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

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
        	get { return m_right; }
        }

    }
}
