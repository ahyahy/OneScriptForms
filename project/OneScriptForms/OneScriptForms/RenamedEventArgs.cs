using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class RenamedEventArgs : FileSystemEventArgs
    {
        public new ClRenamedEventArgs dll_obj;
        public string OldFullPath = "";
        public string OldName = "";

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлПереименованиеАрг", "ClRenamedEventArgs")]
    public class ClRenamedEventArgs : AutoContext<ClRenamedEventArgs>
    {

        public ClRenamedEventArgs()
        {
            RenamedEventArgs RenamedEventArgs1 = new RenamedEventArgs();
            RenamedEventArgs1.dll_obj = this;
            Base_obj = RenamedEventArgs1;
        }
		
        public ClRenamedEventArgs(RenamedEventArgs p1)
        {
            RenamedEventArgs RenamedEventArgs1 = p1;
            RenamedEventArgs1.dll_obj = this;
            Base_obj = RenamedEventArgs1;
        }
        
        public RenamedEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
        }

        [ContextProperty("ПолныйПуть", "FullPath")]
        public string FullPath
        {
            get { return Base_obj.FullPath; }
        }

        [ContextProperty("СтароеИмя", "OldName")]
        public string OldName
        {
            get { return Base_obj.OldName; }
        }

        [ContextProperty("СтарыйПолныйПуть", "OldFullPath")]
        public string OldFullPath
        {
            get { return Base_obj.OldFullPath; }
        }

        [ContextProperty("ТипИзменения", "ChangeType")]
        public int ChangeType
        {
            get { return (int)Base_obj.ChangeType; }
        }

        //Методы============================================================

    }
}
