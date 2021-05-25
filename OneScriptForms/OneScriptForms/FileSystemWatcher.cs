using System;
using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class FileSystemWatcherEx : System.IO.FileSystemWatcher
    {
        public osf.FileSystemWatcher M_Object;
    }

    public class FileSystemWatcher : Component
    {
        public string Changed;
        public string Created;
        public string Deleted;
        public ClFileSystemWatcher dll_obj;
        private FileSystemWatcherEx m_FileSystemWatcher;
        public string Renamed;

        public FileSystemWatcher()
        {
            M_FileSystemWatcher = new FileSystemWatcherEx();
            M_FileSystemWatcher.M_Object = this;
            Changed = "";
            Created = "";
            Deleted = "";
            Renamed = "";
        }

        public FileSystemWatcher(System.IO.FileSystemWatcher FileSystemWatcher)
        {
            M_FileSystemWatcher = (FileSystemWatcherEx)FileSystemWatcher;
            M_FileSystemWatcher.M_Object = this;
            Changed = "";
            Created = "";
            Deleted = "";
            Renamed = "";
        }

        public FileSystemWatcher(osf.FileSystemWatcher p1)
        {
            M_FileSystemWatcher = p1.M_FileSystemWatcher;
            M_FileSystemWatcher.M_Object = this;
            Changed = "";
            Created = "";
            Deleted = "";
            Renamed = "";
        }

        //Свойства============================================================

        public bool EnableRaisingEvents
        {
            get { return M_FileSystemWatcher.EnableRaisingEvents; }
            set
            {
                M_FileSystemWatcher.EnableRaisingEvents = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public string Filter
        {
            get { return M_FileSystemWatcher.Filter; }
            set
            {
                M_FileSystemWatcher.Filter = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool IncludeSubDirectories
        {
            get { return M_FileSystemWatcher.EnableRaisingEvents; }
            set
            {
                M_FileSystemWatcher.EnableRaisingEvents = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int InternalBufferSize
        {
            get { return M_FileSystemWatcher.InternalBufferSize; }
            set
            {
                M_FileSystemWatcher.InternalBufferSize = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public FileSystemWatcherEx M_FileSystemWatcher
        {
            get { return m_FileSystemWatcher; }
            set
            {
                m_FileSystemWatcher = value;
                base.M_Component = m_FileSystemWatcher;
                System.Windows.Forms.Form obj1 = new System.Windows.Forms.Form();
                IntPtr num1 = obj1.Handle;
                m_FileSystemWatcher.SynchronizingObject = obj1;
                m_FileSystemWatcher.Renamed += M_FileSystemWatcher_Renamed;
                m_FileSystemWatcher.Deleted += M_FileSystemWatcher_Deleted;
                m_FileSystemWatcher.Created += M_FileSystemWatcher_Created;
                m_FileSystemWatcher.Changed += M_FileSystemWatcher_Changed;
            }
        }

        public int NotifyFilter
        {
            get { return (int)M_FileSystemWatcher.NotifyFilter; }
            set
            {
                M_FileSystemWatcher.NotifyFilter = (System.IO.NotifyFilters)value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public string Path
        {
            get { return M_FileSystemWatcher.Path; }
            set
            {
                M_FileSystemWatcher.Path = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        //Методы============================================================

        public void M_FileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            if (Changed.Length > 0)
            {
                FileSystemEventArgs FileSystemEventArgs1 = new FileSystemEventArgs();
                FileSystemEventArgs1.Sender = (object)this;
                FileSystemEventArgs1.EventString = Changed;
                FileSystemEventArgs1.ChangeType = (int)e.ChangeType;
                FileSystemEventArgs1.FullPath = e.FullPath;
                FileSystemEventArgs1.Name = e.Name;
                OneScriptForms.EventQueue.Add(FileSystemEventArgs1);
                ClFileSystemEventArgs ClFileSystemEventArgs1 = new ClFileSystemEventArgs(FileSystemEventArgs1);
            }
        }

        public void M_FileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            if (Created.Length > 0)
            {
                FileSystemEventArgs FileSystemEventArgs1 = new FileSystemEventArgs();
                FileSystemEventArgs1.Sender = (object)this;
                FileSystemEventArgs1.EventString = Created;
                FileSystemEventArgs1.ChangeType = (int)e.ChangeType;
                FileSystemEventArgs1.FullPath = e.FullPath;
                FileSystemEventArgs1.Name = e.Name;
                OneScriptForms.EventQueue.Add(FileSystemEventArgs1);
                ClFileSystemEventArgs ClFileSystemEventArgs1 = new ClFileSystemEventArgs(FileSystemEventArgs1);
            }
        }

        public void M_FileSystemWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            if (Deleted.Length > 0)
            {
                FileSystemEventArgs FileSystemEventArgs1 = new FileSystemEventArgs();
                FileSystemEventArgs1.Sender = (object)this;
                FileSystemEventArgs1.EventString = Deleted;
                FileSystemEventArgs1.ChangeType = (int)e.ChangeType;
                FileSystemEventArgs1.FullPath = e.FullPath;
                FileSystemEventArgs1.Name = e.Name;
                OneScriptForms.EventQueue.Add(FileSystemEventArgs1);
                ClFileSystemEventArgs ClFileSystemEventArgs1 = new ClFileSystemEventArgs(FileSystemEventArgs1);
            }
        }

        public void M_FileSystemWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            if (Renamed.Length > 0)
            {
                RenamedEventArgs RenamedEventArgs1 = new RenamedEventArgs();
                RenamedEventArgs1.Sender = (object)this;
                RenamedEventArgs1.EventString = Renamed;
                RenamedEventArgs1.ChangeType = (int)e.ChangeType;
                RenamedEventArgs1.FullPath = e.FullPath;
                RenamedEventArgs1.Name = e.Name;
                RenamedEventArgs1.OldFullPath = e.OldFullPath;
                RenamedEventArgs1.OldName = e.OldName;
                OneScriptForms.EventQueue.Add(RenamedEventArgs1);
                ClRenamedEventArgs ClRenamedEventArgs1 = new ClRenamedEventArgs(RenamedEventArgs1);
            }
        }

    }

    [ContextClass ("КлНаблюдательФайловойСистемы", "ClFileSystemWatcher")]
    public class ClFileSystemWatcher : AutoContext<ClFileSystemWatcher>
    {

        public ClFileSystemWatcher()
        {
            FileSystemWatcher FileSystemWatcher1 = new FileSystemWatcher();
            FileSystemWatcher1.dll_obj = this;
            Base_obj = FileSystemWatcher1;
        }
		
        public ClFileSystemWatcher(FileSystemWatcher p1)
        {
            FileSystemWatcher FileSystemWatcher1 = p1;
            FileSystemWatcher1.dll_obj = this;
            Base_obj = FileSystemWatcher1;
        }
        
        public FileSystemWatcher Base_obj;

        //Свойства============================================================

        [ContextProperty("ВключаяПодкаталоги", "IncludeSubDirectories")]
        public bool IncludeSubDirectories
        {
            get { return Base_obj.IncludeSubDirectories; }
            set { Base_obj.IncludeSubDirectories = value; }
        }

        [ContextProperty("КомпонентДоступен", "EnableRaisingEvents")]
        public bool EnableRaisingEvents
        {
            get { return Base_obj.EnableRaisingEvents; }
            set { Base_obj.EnableRaisingEvents = value; }
        }

        [ContextProperty("ПриИзменении", "Changed")]
        public string Changed
        {
            get { return Base_obj.Changed; }
            set { Base_obj.Changed = value; }
        }

        [ContextProperty("ПриПереименовании", "Renamed")]
        public string Renamed
        {
            get { return Base_obj.Renamed; }
            set { Base_obj.Renamed = value; }
        }

        [ContextProperty("ПриСоздании", "Created")]
        public string Created
        {
            get { return Base_obj.Created; }
            set { Base_obj.Created = value; }
        }

        [ContextProperty("ПриУдалении", "Deleted")]
        public string Deleted
        {
            get { return Base_obj.Deleted; }
            set { Base_obj.Deleted = value; }
        }

        [ContextProperty("Путь", "Path")]
        public string Path
        {
            get { return Base_obj.Path; }
            set { Base_obj.Path = value; }
        }

        [ContextProperty("РазмерВнутреннегоБуфера", "InternalBufferSize")]
        public int InternalBufferSize
        {
            get { return Base_obj.InternalBufferSize; }
            set { Base_obj.InternalBufferSize = value; }
        }

        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }
        
        [ContextProperty("Фильтр", "Filter")]
        public string Filter
        {
            get { return Base_obj.Filter; }
            set { Base_obj.Filter = value; }
        }

        [ContextProperty("ФильтрУведомлений", "NotifyFilter")]
        public int NotifyFilter
        {
            get { return (int)Base_obj.NotifyFilter; }
            set { Base_obj.NotifyFilter = value; }
        }

        //Методы============================================================

        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
    }
}
