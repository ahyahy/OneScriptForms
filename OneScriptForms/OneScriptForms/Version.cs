using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class Version
    {
        public ClVersion dll_obj;
        public System.Version M_Version;

        public Version(System.Version p1)
        {
            M_Version = p1;
        }

        public int Build
        {
            get { return M_Version.Build; }
        }

        public int Major
        {
            get { return M_Version.Major; }
        }

        public int Minor
        {
            get { return M_Version.Minor; }
        }

        public int Revision
        {
            get { return M_Version.Revision; }
        }

        public new string ToString()
        {
            return M_Version.ToString();
        }
    }

    [ContextClass ("КлВерсия", "ClVersion")]
    public class ClVersion : AutoContext<ClVersion>
    {
        public ClVersion(Version p1)
        {
            Version Version1 = p1;
            Version1.dll_obj = this;
            Base_obj = Version1;
        }

        public ClVersion(System.Version p1)
        {
            Version Version1 = new Version(p1);
            Version1.dll_obj = this;
            Base_obj = Version1;
        }

        public Version Base_obj;
        
        [ContextProperty("ДополнительныйНомер", "Minor")]
        public int Minor
        {
            get { return Base_obj.Minor; }
        }

        [ContextProperty("ОсновнойНомер", "Major")]
        public int Major
        {
            get { return Base_obj.Major; }
        }

        [ContextProperty("Редакция", "Revision")]
        public int Revision
        {
            get { return Base_obj.Revision; }
        }

        [ContextProperty("Сборка", "Build")]
        public int Build
        {
            get { return Base_obj.Build; }
        }
        
    }
}
