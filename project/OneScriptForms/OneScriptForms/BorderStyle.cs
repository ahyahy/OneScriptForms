using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСтильГраницы", "ClBorderStyle")]
    public class ClBorderStyle : AutoContext<ClBorderStyle>
    {
        private int m_none = (int)System.Windows.Forms.BorderStyle.None; // 0 Граница отсутствует.
        private int m_fixedSingle = (int)System.Windows.Forms.BorderStyle.FixedSingle; // 1 Одинарная граница.
        private int m_fixed3D = (int)System.Windows.Forms.BorderStyle.Fixed3D; // 2 Трехмерная граница.

        [ContextProperty("Одинарная", "FixedSingle")]
        public int FixedSingle
        {
        	get { return m_fixedSingle; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("Трехмерная", "Fixed3D")]
        public int Fixed3D
        {
        	get { return m_fixed3D; }
        }

    }
}
