using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлФорматМаски", "ClMaskFormat")]
    public class ClMaskFormat : AutoContext<ClMaskFormat>
    {
        private int m_excludePromptAndLiterals = (int)System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals; // 0 Возвращать только текст, введенный пользователем.
        private int m_includePrompt = (int)System.Windows.Forms.MaskFormat.IncludePrompt; // 1 Возвращать текст, введенный пользователем, а также экземпляры символа приглашения.
        private int m_includeLiterals = (int)System.Windows.Forms.MaskFormat.IncludeLiterals; // 2 Возвращать текст, введенный пользователем, а также символьные литералы, определенные в маске.
        private int m_includePromptAndLiterals = (int)System.Windows.Forms.MaskFormat.IncludePromptAndLiterals; // 3 Возвращать текст, введенный пользователем, а также символьные литералы, определенные в маске, и экземпляры символа приглашения.

        [ContextProperty("ВключитьЛитералы", "IncludeLiterals")]
        public int IncludeLiterals
        {
        	get { return m_includeLiterals; }
        }

        [ContextProperty("ВключитьПриглашение", "IncludePrompt")]
        public int IncludePrompt
        {
        	get { return m_includePrompt; }
        }

        [ContextProperty("ВключитьПриглашениеИЛитералы", "IncludePromptAndLiterals")]
        public int IncludePromptAndLiterals
        {
        	get { return m_includePromptAndLiterals; }
        }

        [ContextProperty("ИсключитьПриглашениеИЛитералы", "ExcludePromptAndLiterals")]
        public int ExcludePromptAndLiterals
        {
        	get { return m_excludePromptAndLiterals; }
        }
    }
}
