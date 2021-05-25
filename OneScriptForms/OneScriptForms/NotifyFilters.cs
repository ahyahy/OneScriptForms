using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлФильтрыУведомления", "ClNotifyFilters")]
    public class ClNotifyFilters : AutoContext<ClNotifyFilters>
    {
        private int m_fileName = (int)System.IO.NotifyFilters.FileName; // 1 Имя файла.
        private int m_directoryName = (int)System.IO.NotifyFilters.DirectoryName; // 2 Имя каталога.
        private int m_attributes = (int)System.IO.NotifyFilters.Attributes; // 4 Атрибуты файла или каталога.
        private int m_size = (int)System.IO.NotifyFilters.Size; // 8 Размер файла или каталога.
        private int m_lastWrite = (int)System.IO.NotifyFilters.LastWrite; // 16 Дата последней записи в файл или каталог.
        private int m_lastAccess = (int)System.IO.NotifyFilters.LastAccess; // 32 Дата последнего открытия файла или каталога.
        private int m_creationTime = (int)System.IO.NotifyFilters.CreationTime; // 64 Время создания файла или каталога.
        private int m_security = (int)System.IO.NotifyFilters.Security; // 256 Параметры безопасности файла или каталога.

        [ContextProperty("Атрибуты", "Attributes")]
        public int Attributes
        {
        	get { return m_attributes; }
        }

        [ContextProperty("Безопасность", "Security")]
        public int Security
        {
        	get { return m_security; }
        }

        [ContextProperty("ВремяСоздания", "CreationTime")]
        public int CreationTime
        {
        	get { return m_creationTime; }
        }

        [ContextProperty("ИмяКаталога", "DirectoryName")]
        public int DirectoryName
        {
        	get { return m_directoryName; }
        }

        [ContextProperty("ИмяФайла", "FileName")]
        public int FileName
        {
        	get { return m_fileName; }
        }

        [ContextProperty("ПоследнийДоступ", "LastAccess")]
        public int LastAccess
        {
        	get { return m_lastAccess; }
        }

        [ContextProperty("ПоследняяЗапись", "LastWrite")]
        public int LastWrite
        {
        	get { return m_lastWrite; }
        }

        [ContextProperty("Размер", "Size")]
        public int Size
        {
        	get { return m_size; }
        }

    }
}
