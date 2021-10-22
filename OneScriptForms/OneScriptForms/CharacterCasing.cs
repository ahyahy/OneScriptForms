using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлРегистрСимволов", "ClCharacterCasing")]
    public class ClCharacterCasing : AutoContext<ClCharacterCasing>
    {
        private int m_normal = (int)System.Windows.Forms.CharacterCasing.Normal; // 0 Регистр символов не изменяется.
        private int m_upper = (int)System.Windows.Forms.CharacterCasing.Upper; // 1 Все символы преобразуются в верхний регистр.
        private int m_lower = (int)System.Windows.Forms.CharacterCasing.Lower; // 2 Все символы преобразуются в нижний регистр.

        [ContextProperty("Верхний", "Upper")]
        public int Upper
        {
        	get { return m_upper; }
        }

        [ContextProperty("Нижний", "Lower")]
        public int Lower
        {
        	get { return m_lower; }
        }

        [ContextProperty("Стандартный", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }
    }
}
