using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osf
{
    public class Application
    {
        private static bool m_IsRunning = false;
        public ClApplication dll_obj;

        public bool IsRunning
        {
            get { return Application.m_IsRunning; }
        }

        public string ProductName
        {
            get { return ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title.ToString(); }
        }

        public string ProductVersion
        {
            get { return new osf.Version((dynamic)Assembly.GetExecutingAssembly().GetName().Version).ToString(); }
        }

        public string UserAppDataPath
        {
            get { return System.Windows.Forms.Application.UserAppDataPath; }
        }

        public Version Version
        {
            get { return new osf.Version((dynamic)Assembly.GetExecutingAssembly().GetName().Version); }
        }

        public void EnableVisualStyles()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            //System.Windows.Forms.Application.DoEvents();
        }

        public void Exit()
        {
            System.Windows.Forms.Application.Exit();
            Application.m_IsRunning = false;
        }

        public void Run(Form form = null)
        {
            Application.m_IsRunning = true;
            if (form.GetType() != typeof(Form))
                return;
            form.Show();
        }
    }

    [ContextClass ("КлПриложение", "ClApplication")]
    public class ClApplication : AutoContext<ClApplication>
    {
        public ClApplication()
        {
            Application Application1 = new Application();
            Application1.dll_obj = this;
            Base_obj = Application1;
        }
		
        public ClApplication(Application p1)
        {
            Application Application1 = p1;
            Application1.dll_obj = this;
            Base_obj = Application1;
        }
        
        public Application Base_obj;
        
        [ContextProperty("Версия", "Version")]
        public ClVersion Version
        {
            get { return (ClVersion)OneScriptForms.RevertObj(Base_obj.Version); }
        }

        [ContextProperty("ВерсияПродукта", "ProductVersion")]
        public string ProductVersion
        {
            get { return Base_obj.ProductVersion; }
        }

        [ContextProperty("ИмяПродукта", "ProductName")]
        public string ProductName
        {
            get { return ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title.ToString(); }
        }
        
        [ContextProperty("ПутьДанныхПриложенияПользователя", "UserAppDataPath")]
        public string UserAppDataPath
        {
            get { return Base_obj.UserAppDataPath; }
        }
        
        [ContextMethod("ВключитьВизуальныеСтили", "EnableVisualStyles")]
        public void EnableVisualStyles()
        {
            Base_obj.EnableVisualStyles();
        }
    }
}
