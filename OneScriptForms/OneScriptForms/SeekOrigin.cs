using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлПозицияПоиска", "ClSeekOrigin")]
    public class ClSeekOrigin : AutoContext<ClSeekOrigin>
    {
        private int m_begin = (int)System.IO.SeekOrigin.Begin; // 0 Начало потока.
        private int m_current = (int)System.IO.SeekOrigin.Current; // 1 Текущая позиция в потоке.
        private int m_end = (int)System.IO.SeekOrigin.End; // 2 Конец потока.

        [ContextProperty("Конец", "End")]
        public int End
        {
        	get { return m_end; }
        }

        [ContextProperty("Начало", "Begin")]
        public int Begin
        {
        	get { return m_begin; }
        }

        [ContextProperty("Текущая", "Current")]
        public int Current
        {
        	get { return m_current; }
        }
    }
}
