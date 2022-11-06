using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСокращениеСтроки", "ClStringTrimming")]
    public class ClStringTrimming : AutoContext<ClStringTrimming>
    {
        private int m_none = (int)System.Drawing.StringTrimming.None; // 0 Указывает на отсутствие обрезки.
        private int m_character = (int)System.Drawing.StringTrimming.Character; // 1 Указывает, что текст обрезается по ближайшему знаку.
        private int m_word = (int)System.Drawing.StringTrimming.Word; // 2 Указывает, что текст обрезается по ближайшему слову.
        private int m_ellipsisCharacter = (int)System.Drawing.StringTrimming.EllipsisCharacter; // 3 Указывает, что текст обрезается по ближайшему знаку и в конце обрезанной строки вставляется троеточие.
        private int m_ellipsisWord = (int)System.Drawing.StringTrimming.EllipsisWord; // 4 Указывает, что текст обрезается по ближайшему слову и в конце обрезанной строки вставляется троеточие.
        private int m_ellipsisPath = (int)System.Drawing.StringTrimming.EllipsisPath; // 5 Из обрезанных строк удаляется центральная часть и заменяется троеточием. Этот алгоритм позволяет сохранить максимально возможную часть отделенного косой чертой последнего сегмента строки.

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("ПутьМноготочие", "EllipsisPath")]
        public int EllipsisPath
        {
        	get { return m_ellipsisPath; }
        }

        [ContextProperty("Символ", "Character")]
        public int Character
        {
        	get { return m_character; }
        }

        [ContextProperty("СимволМноготочие", "EllipsisCharacter")]
        public int EllipsisCharacter
        {
        	get { return m_ellipsisCharacter; }
        }

        [ContextProperty("Слово", "Word")]
        public int Word
        {
        	get { return m_word; }
        }

        [ContextProperty("СловоМноготочие", "EllipsisWord")]
        public int EllipsisWord
        {
        	get { return m_ellipsisWord; }
        }
    }
}
