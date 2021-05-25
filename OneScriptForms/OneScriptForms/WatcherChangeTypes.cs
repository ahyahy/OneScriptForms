using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлНаблюдательИзмененияВида", "ClWatcherChangeTypes")]
    public class ClWatcherChangeTypes : AutoContext<ClWatcherChangeTypes>
    {
        private int m_created = (int)System.IO.WatcherChangeTypes.Created; // 1 Создание файла или каталога.
        private int m_deleted = (int)System.IO.WatcherChangeTypes.Deleted; // 2 Удаление файла или каталога.
        private int m_changed = (int)System.IO.WatcherChangeTypes.Changed; // 4 Изменение файла или каталога. Типы изменений включают: изменения размера, атрибутов, параметров безопасности, последней записи и времени последнего доступа.
        private int m_renamed = (int)System.IO.WatcherChangeTypes.Renamed; // 8 Переименование файла или каталога.
        private int m_all = (int)System.IO.WatcherChangeTypes.All; // 15 Создание, удаление, изменение или переименование файла или каталога.

        [ContextProperty("Все", "All")]
        public int All
        {
        	get { return m_all; }
        }

        [ContextProperty("Изменение", "Changed")]
        public int Changed
        {
        	get { return m_changed; }
        }

        [ContextProperty("Переименование", "Renamed")]
        public int Renamed
        {
        	get { return m_renamed; }
        }

        [ContextProperty("Создание", "Created")]
        public int Created
        {
        	get { return m_created; }
        }

        [ContextProperty("Удаление", "Deleted")]
        public int Deleted
        {
        	get { return m_deleted; }
        }

    }
}
