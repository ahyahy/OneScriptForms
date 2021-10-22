using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлВыравниваниеСодержимого", "ClContentAlignment")]
    public class ClContentAlignment : AutoContext<ClContentAlignment>
    {
        private int m_topLeft = (int)System.Drawing.ContentAlignment.TopLeft; // 1 Содержимое выравнивается вертикально сверху и горизонтально по левому краю.
        private int m_topCenter = (int)System.Drawing.ContentAlignment.TopCenter; // 2 Содержимое выравнивается вертикально сверху и горизонтально по центру.
        private int m_topRight = (int)System.Drawing.ContentAlignment.TopRight; // 4 Содержимое выравнивается вертикально сверху и горизонтально по правому краю.
        private int m_middleLeft = (int)System.Drawing.ContentAlignment.MiddleLeft; // 16 Содержимое выравнивается вертикально по середине и горизонтально по левому краю.
        private int m_middleCenter = (int)System.Drawing.ContentAlignment.MiddleCenter; // 32 Содержимое выравнивается вертикально по середине и горизонтально по центру.
        private int m_middleRight = (int)System.Drawing.ContentAlignment.MiddleRight; // 64 Содержимое выравнивается вертикально по середине и горизонтально по правому краю.
        private int m_bottomLeft = (int)System.Drawing.ContentAlignment.BottomLeft; // 256 Содержимое выравнивается вертикально снизу и горизонтально по левому краю.
        private int m_bottomCenter = (int)System.Drawing.ContentAlignment.BottomCenter; // 512 Содержимое выравнивается вертикально снизу и горизонтально по центру.
        private int m_bottomRight = (int)System.Drawing.ContentAlignment.BottomRight; // 1024 Содержимое выравнивается вертикально снизу и горизонтально по правому краю.

        [ContextProperty("ВерхЛево", "TopLeft")]
        public int TopLeft
        {
        	get { return m_topLeft; }
        }

        [ContextProperty("ВерхПраво", "TopRight")]
        public int TopRight
        {
        	get { return m_topRight; }
        }

        [ContextProperty("ВерхЦентр", "TopCenter")]
        public int TopCenter
        {
        	get { return m_topCenter; }
        }

        [ContextProperty("НизЛево", "BottomLeft")]
        public int BottomLeft
        {
        	get { return m_bottomLeft; }
        }

        [ContextProperty("НизПраво", "BottomRight")]
        public int BottomRight
        {
        	get { return m_bottomRight; }
        }

        [ContextProperty("НизЦентр", "BottomCenter")]
        public int BottomCenter
        {
        	get { return m_bottomCenter; }
        }

        [ContextProperty("СерединаЛево", "MiddleLeft")]
        public int MiddleLeft
        {
        	get { return m_middleLeft; }
        }

        [ContextProperty("СерединаПраво", "MiddleRight")]
        public int MiddleRight
        {
        	get { return m_middleRight; }
        }

        [ContextProperty("СерединаЦентр", "MiddleCenter")]
        public int MiddleCenter
        {
        	get { return m_middleCenter; }
        }
    }
}
