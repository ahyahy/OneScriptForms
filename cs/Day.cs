using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлДень", "ClDay")]
    public class ClDay : AutoContext<ClDay>
    {
        private int m_monday = (int)System.Windows.Forms.Day.Monday; // 0 День: понедельник.
        private int m_tuesday = (int)System.Windows.Forms.Day.Tuesday; // 1 День: вторник.
        private int m_wednesday = (int)System.Windows.Forms.Day.Wednesday; // 2 День: среда.
        private int m_thursday = (int)System.Windows.Forms.Day.Thursday; // 3 День: четверг.
        private int m_friday = (int)System.Windows.Forms.Day.Friday; // 4 День: пятница.
        private int m_saturday = (int)System.Windows.Forms.Day.Saturday; // 5 День: суббота.
        private int m_sunday = (int)System.Windows.Forms.Day.Sunday; // 6 День: воскресенье.
        private int m_default = (int)System.Windows.Forms.Day.Default; // 7 День недели, используемый по умолчанию, определенный приложением.

        [ContextProperty("Воскресенье", "Sunday")]
        public int Sunday
        {
        	get { return m_sunday; }
        }

        [ContextProperty("Вторник", "Tuesday")]
        public int Tuesday
        {
        	get { return m_tuesday; }
        }

        [ContextProperty("ПоУмолчанию", "Default")]
        public int Default
        {
        	get { return m_default; }
        }

        [ContextProperty("Понедельник", "Monday")]
        public int Monday
        {
        	get { return m_monday; }
        }

        [ContextProperty("Пятница", "Friday")]
        public int Friday
        {
        	get { return m_friday; }
        }

        [ContextProperty("Среда", "Wednesday")]
        public int Wednesday
        {
        	get { return m_wednesday; }
        }

        [ContextProperty("Суббота", "Saturday")]
        public int Saturday
        {
        	get { return m_saturday; }
        }

        [ContextProperty("Четверг", "Thursday")]
        public int Thursday
        {
        	get { return m_thursday; }
        }

    }
}
