using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class FileSystemEventArgs : EventArgs
    {
        public int ChangeType = 0;
        public new ClFileSystemEventArgs dll_obj;
        public string FullPath = null;
        public string Name = null;

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлСобытиеФайловойСистемыАрг", "ClFileSystemEventArgs")]
    public class ClFileSystemEventArgs : AutoContext<ClFileSystemEventArgs>
    {

        public ClFileSystemEventArgs()
        {
            FileSystemEventArgs FileSystemEventArgs1 = new FileSystemEventArgs();
            FileSystemEventArgs1.dll_obj = this;
            Base_obj = FileSystemEventArgs1;
        }
		
        public ClFileSystemEventArgs(FileSystemEventArgs p1)
        {
            FileSystemEventArgs FileSystemEventArgs1 = p1;
            FileSystemEventArgs1.dll_obj = this;
            Base_obj = FileSystemEventArgs1;
        }
        
        public FileSystemEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
        }

        [ContextProperty("Отправитель", "Sender")]
        public IValue Sender
        {
            get { return OneScriptForms.RevertObj(Base_obj.Sender); }
        }
        
        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter
        {
            get { return (IValue)Base_obj.Parameter; }
        }

        [ContextProperty("ПолныйПуть", "FullPath")]
        public string FullPath
        {
            get { return Base_obj.FullPath; }
        }

        [ContextProperty("ТипИзменения", "ChangeType")]
        public int ChangeType
        {
            get { return (int)Base_obj.ChangeType; }
        }

        //Методы============================================================

    }
}
