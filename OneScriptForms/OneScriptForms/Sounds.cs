using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлЗвуки", "ClSounds")]
    public class ClSounds : AutoContext<ClSounds>
    {
        private int m_question = 0; // 0 Звуковой файл, связанный с событием программы <B>Вопрос&nbsp;(Question)</B> в текущей звуковой схеме Windows.
        private int m_exclamation = 1; // 1 Звуковой файл, связанный с событием программы <B>Восклицание&nbsp;(Exclamation)</B> в текущей звуковой схеме Windows.
        private int m_beep = 2; // 2 Звуковой файл, связанный с событием программы <B>Гудок&nbsp;(Beep)</B> в текущей звуковой схеме Windows.
        private int m_asterisk = 3; // 3 Звуковой файл, связанный с событием программы <B>Звездочка&nbsp;(Asterisk)</B> в текущей звуковой схеме Windows.
        private int m_hand = 4; // 4 Звуковой файл, связанный с событием программы <B>Рука&nbsp;(Hand)</B> в текущей звуковой схеме Windows.

        [ContextProperty("Вопрос", "Question")]
        public int Question
        {
        	get { return m_question; }
        }

        [ContextProperty("Восклицание", "Exclamation")]
        public int Exclamation
        {
        	get { return m_exclamation; }
        }

        [ContextProperty("Гудок", "Beep")]
        public int Beep
        {
        	get { return m_beep; }
        }

        [ContextProperty("Звездочка", "Asterisk")]
        public int Asterisk
        {
        	get { return m_asterisk; }
        }

        [ContextProperty("Рука", "Hand")]
        public int Hand
        {
        	get { return m_hand; }
        }

    }
}
