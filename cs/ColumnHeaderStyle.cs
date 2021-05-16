using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСтильЗаголовкаКолонки", "ClColumnHeaderStyle")]
    public class ClColumnHeaderStyle : AutoContext<ClColumnHeaderStyle>
    {
        private int m_none = (int)System.Windows.Forms.ColumnHeaderStyle.None; // 0 Заголовок колонки не отображается.
        private int m_nonclickable = (int)System.Windows.Forms.ColumnHeaderStyle.Nonclickable; // 1 Заголовки колонок не отвечают на щелчок мыши.
        private int m_clickable = (int)System.Windows.Forms.ColumnHeaderStyle.Clickable; // 2 Заголовки колонок работают подобно кнопкам и можно выполнять различные действия, например сортировку.

        [ContextProperty("Нажимаемая", "Clickable")]
        public int Clickable
        {
        	get { return m_clickable; }
        }

        [ContextProperty("НеНажимаемая", "Nonclickable")]
        public int Nonclickable
        {
        	get { return m_nonclickable; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

    }
}
