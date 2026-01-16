using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osf
{
    public class Environment
    {
        public ClEnvironment dll_obj;

        public string CommandLine
        {
            get { return System.Environment.CommandLine; }
        }

        public string NewLine
        {
            get { return System.Environment.NewLine; }
        }

        public osf.Version Version
        {
            get { return new Version(Assembly.GetExecutingAssembly().GetName().Version); }
        }

        public string GetFolderPath(int p1)
        {
            return System.Environment.GetFolderPath((System.Environment.SpecialFolder)p1);
        }
    }

    [ContextClass("КлОкружение", "ClEnvironment")]
    public class ClEnvironment : AutoContext<ClEnvironment>
    {
        public ClEnvironment()
        {
            Environment Environment1 = new Environment();
            Environment1.dll_obj = this;
            Base_obj = Environment1;
        }

        public ClEnvironment(Environment p1)
        {
            Environment Environment1 = p1;
            Environment1.dll_obj = this;
            Base_obj = Environment1;
        }

        public Environment Base_obj;

        [ContextProperty("Версия", "Version")]
        public ClVersion Version
        {
            get { return (ClVersion)OneScriptForms.RevertObj(Base_obj.Version); }
        }

        [ContextProperty("КоманднаяСтрока", "CommandLine")]
        public string CommandLine
        {
            get { return Base_obj.CommandLine; }
        }

        [ContextProperty("НоваяСтрока", "NewLine")]
        public string NewLine
        {
            get { return Base_obj.NewLine; }
        }

        [ContextMethod("ПолучитьПутьКаталога", "GetFolderPath")]
        public string GetFolderPath(int p1)
        {
            return Base_obj.GetFolderPath(p1);
        }
    }
}
