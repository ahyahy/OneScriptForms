using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлОсобаяПапка", "ClSpecialFolder")]
    public class ClSpecialFolder : AutoContext<ClSpecialFolder>
    {
        private int m_desktop = (int)System.Environment.SpecialFolder.Desktop; // 0 Логический рабочий стол, а не физическое местоположение файлов системы.
        private int m_programs = (int)System.Environment.SpecialFolder.Programs; // 2 Каталог, содержащий группы программ пользователя.
        private int m_personal = (int)System.Environment.SpecialFolder.Personal; // 5 Каталог для документов.
        private int m_favorites = (int)System.Environment.SpecialFolder.Favorites; // 6 Каталог избранных элементов пользователя.
        private int m_startup = (int)System.Environment.SpecialFolder.Startup; // 7 Каталог, соответствующий группе программ пользователя «Автозагрузка».
        private int m_recent = (int)System.Environment.SpecialFolder.Recent; // 8 Каталог, содержащий недавно использовавшиеся документы.
        private int m_sendTo = (int)System.Environment.SpecialFolder.SendTo; // 9 Каталог, содержащий пункты меню «Отправить».
        private int m_startMenu = (int)System.Environment.SpecialFolder.StartMenu; // 11 Каталог, содержащий пункты меню «Пуск».
        private int m_myMusic = (int)System.Environment.SpecialFolder.MyMusic; // 13 Каталог Моя музыка.
        private int m_desktopDirectory = (int)System.Environment.SpecialFolder.DesktopDirectory; // 16 Каталог, используемый для физического хранения файловых объектов рабочего стола.
        private int m_myComputer = (int)System.Environment.SpecialFolder.MyComputer; // 17 Каталог Мой компьютер.
        private int m_templates = (int)System.Environment.SpecialFolder.Templates; // 21 Каталог шаблонов документов.
        private int m_applicationData = (int)System.Environment.SpecialFolder.ApplicationData; // 26 Каталог, выполняющий функции общего репозитория для данных приложения текущего перемещающегося пользователя.
        private int m_localApplicationData = (int)System.Environment.SpecialFolder.LocalApplicationData; // 28 Каталог данных приложений, используемых текущим пользователем, который не перемещается.
        private int m_internetCache = (int)System.Environment.SpecialFolder.InternetCache; // 32 Каталог временных файлов Интернета.
        private int m_cookies = (int)System.Environment.SpecialFolder.Cookies; // 33 Каталог файлов cookie Интернета.
        private int m_history = (int)System.Environment.SpecialFolder.History; // 34 Каталог элементов журнала Интернета.
        private int m_commonApplicationData = (int)System.Environment.SpecialFolder.CommonApplicationData; // 35 Каталог, выполняющий функции общего репозитория для данных приложения, используемого всеми пользователями.
        private int m_systemDirectory = (int)System.Environment.SpecialFolder.System; // 37 Каталог System.
        private int m_programFiles = (int)System.Environment.SpecialFolder.ProgramFiles; // 38 Каталог файлов программ.
        private int m_myPictures = (int)System.Environment.SpecialFolder.MyPictures; // 39 Каталог Мои рисунки.
        private int m_commonProgramFiles = (int)System.Environment.SpecialFolder.CommonProgramFiles; // 43 Каталог общих для приложений компонентов.

        [ContextProperty("ВременныеФайлыИнтернета", "InternetCache")]
        public int InternetCache
        {
        	get { return m_internetCache; }
        }

        [ContextProperty("ДанныеПриложений", "ApplicationData")]
        public int ApplicationData
        {
        	get { return m_applicationData; }
        }

        [ContextProperty("ДанныеПриложенийПользователя", "LocalApplicationData")]
        public int LocalApplicationData
        {
        	get { return m_localApplicationData; }
        }

        [ContextProperty("Избранное", "Favorites")]
        public int Favorites
        {
        	get { return m_favorites; }
        }

        [ContextProperty("История", "History")]
        public int History
        {
        	get { return m_history; }
        }

        [ContextProperty("КаталогЗапуска", "Startup")]
        public int Startup
        {
        	get { return m_startup; }
        }

        [ContextProperty("КаталогОтправить", "SendTo")]
        public int SendTo
        {
        	get { return m_sendTo; }
        }

        [ContextProperty("КаталогПуск", "StartMenu")]
        public int StartMenu
        {
        	get { return m_startMenu; }
        }

        [ContextProperty("КаталогСистема", "SystemDirectory")]
        public int SystemDirectory
        {
        	get { return m_systemDirectory; }
        }

        [ContextProperty("Куки", "Cookies")]
        public int Cookies
        {
        	get { return m_cookies; }
        }

        [ContextProperty("Личное", "Personal")]
        public int Personal
        {
        	get { return m_personal; }
        }

        [ContextProperty("МоиРисунки", "MyPictures")]
        public int MyPictures
        {
        	get { return m_myPictures; }
        }

        [ContextProperty("МойКомпьютер", "MyComputer")]
        public int MyComputer
        {
        	get { return m_myComputer; }
        }

        [ContextProperty("МояМузыка", "MyMusic")]
        public int MyMusic
        {
        	get { return m_myMusic; }
        }

        [ContextProperty("НедавниеДокументы", "Recent")]
        public int Recent
        {
        	get { return m_recent; }
        }

        [ContextProperty("ОбщиеДанныеПриложений", "CommonApplicationData")]
        public int CommonApplicationData
        {
        	get { return m_commonApplicationData; }
        }

        [ContextProperty("ОбщиеПрограммныеФайлы", "CommonProgramFiles")]
        public int CommonProgramFiles
        {
        	get { return m_commonProgramFiles; }
        }

        [ContextProperty("ПрограммныеФайлы", "ProgramFiles")]
        public int ProgramFiles
        {
        	get { return m_programFiles; }
        }

        [ContextProperty("Программы", "Programs")]
        public int Programs
        {
        	get { return m_programs; }
        }

        [ContextProperty("РабочийСтол", "Desktop")]
        public int Desktop
        {
        	get { return m_desktop; }
        }

        [ContextProperty("ФайлыРабочегоСтола", "DesktopDirectory")]
        public int DesktopDirectory
        {
        	get { return m_desktopDirectory; }
        }

        [ContextProperty("Шаблоны", "Templates")]
        public int Templates
        {
        	get { return m_templates; }
        }

    }
}
