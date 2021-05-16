using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлГлубинаЦвета", "ClColorDepth")]
    public class ClColorDepth : AutoContext<ClColorDepth>
    {
        private int m_depth4Bit = (int)System.Windows.Forms.ColorDepth.Depth4Bit; // 4 4-битовая глубина цвета.
        private int m_depth8Bit = (int)System.Windows.Forms.ColorDepth.Depth8Bit; // 8 8-битовая глубина цвета.
        private int m_depth16Bit = (int)System.Windows.Forms.ColorDepth.Depth16Bit; // 16 16-битовая глубина цвета.
        private int m_depth24Bit = (int)System.Windows.Forms.ColorDepth.Depth24Bit; // 24 24-битовая глубина цвета.
        private int m_depth32Bit = (int)System.Windows.Forms.ColorDepth.Depth32Bit; // 32 32-битовая глубина цвета.

        [ContextProperty("Глубина16", "Depth16Bit")]
        public int Depth16Bit
        {
        	get { return m_depth16Bit; }
        }

        [ContextProperty("Глубина24", "Depth24Bit")]
        public int Depth24Bit
        {
        	get { return m_depth24Bit; }
        }

        [ContextProperty("Глубина32", "Depth32Bit")]
        public int Depth32Bit
        {
        	get { return m_depth32Bit; }
        }

        [ContextProperty("Глубина4", "Depth4Bit")]
        public int Depth4Bit
        {
        	get { return m_depth4Bit; }
        }

        [ContextProperty("Глубина8", "Depth8Bit")]
        public int Depth8Bit
        {
        	get { return m_depth8Bit; }
        }

    }
}
