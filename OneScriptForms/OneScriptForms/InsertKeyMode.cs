using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлРежимВставки", "ClInsertKeyMode")]
    public class ClInsertKeyMode : AutoContext<ClInsertKeyMode>
    {
        private int m_default = (int)System.Windows.Forms.InsertKeyMode.Default; // 0 Учитывает текущий режим клавиши INSERT на клавиатуре.
        private int m_insert = (int)System.Windows.Forms.InsertKeyMode.Insert; // 1 Указывает, что режим вставки включен независимо от режима клавиши INSERT.
        private int m_overwrite = (int)System.Windows.Forms.InsertKeyMode.Overwrite; // 2 Указывает, что режим перезаписи включен независимо от режима клавиши INSERT.

        [ContextProperty("Вставить", "Insert")]
        public int Insert
        {
        	get { return m_insert; }
        }

        [ContextProperty("Перезаписать", "Overwrite")]
        public int Overwrite
        {
        	get { return m_overwrite; }
        }

        [ContextProperty("ПоУмолчанию", "Default")]
        public int Default
        {
        	get { return m_default; }
        }
    }
}
