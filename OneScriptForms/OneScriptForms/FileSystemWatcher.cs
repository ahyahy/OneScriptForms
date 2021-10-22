using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

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

        public FileSystemWatcher(osf.FileSystemWatcher p1)
        {
            M_FileSystemWatcher = p1.M_FileSystemWatcher;
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

        public void M_FileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            if (Changed.Length > 0)
            {
                FileSystemEventArgs FileSystemEventArgs1 = new FileSystemEventArgs();
                FileSystemEventArgs1.EventString = Changed;
                FileSystemEventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.Changed;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    FileSystemEventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    FileSystemEventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    FileSystemEventArgs1.Parameter = null;
                }
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
                FileSystemEventArgs1.EventString = Created;
                FileSystemEventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.Created;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    FileSystemEventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    FileSystemEventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    FileSystemEventArgs1.Parameter = null;
                }
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
                FileSystemEventArgs1.EventString = Deleted;
                FileSystemEventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.Deleted;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    FileSystemEventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    FileSystemEventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    FileSystemEventArgs1.Parameter = null;
                }
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
                RenamedEventArgs1.EventString = Renamed;
                RenamedEventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.Renamed;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    RenamedEventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    RenamedEventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    RenamedEventArgs1.Parameter = null;
                }
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
        private IValue _Changed;
        private IValue _Created;
        private IValue _Deleted;
        private IValue _Renamed;

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
        public IValue Changed
        {
            get
            {
                if (Base_obj.Changed.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Changed;
                }
                else if (Base_obj.Changed.Contains("osf.ClDictionaryEntry"))
                {
                    return _Changed;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Changed);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Changed = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Changed = "ScriptEngine.HostedScript.Library.DelegateAction" + "Changed";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Changed = value;
                    Base_obj.Changed = "osf.ClDictionaryEntry" + "Changed";
                }
                else
                {
                    Base_obj.Changed = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриПереименовании", "Renamed")]
        public IValue Renamed
        {
            get
            {
                if (Base_obj.Renamed.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Renamed;
                }
                else if (Base_obj.Renamed.Contains("osf.ClDictionaryEntry"))
                {
                    return _Renamed;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Renamed);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Renamed = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Renamed = "ScriptEngine.HostedScript.Library.DelegateAction" + "Renamed";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Renamed = value;
                    Base_obj.Renamed = "osf.ClDictionaryEntry" + "Renamed";
                }
                else
                {
                    Base_obj.Renamed = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриСоздании", "Created")]
        public IValue Created
        {
            get
            {
                if (Base_obj.Created.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Created;
                }
                else if (Base_obj.Created.Contains("osf.ClDictionaryEntry"))
                {
                    return _Created;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Created);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Created = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Created = "ScriptEngine.HostedScript.Library.DelegateAction" + "Created";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Created = value;
                    Base_obj.Created = "osf.ClDictionaryEntry" + "Created";
                }
                else
                {
                    Base_obj.Created = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриУдалении", "Deleted")]
        public IValue Deleted
        {
            get
            {
                if (Base_obj.Deleted.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Deleted;
                }
                else if (Base_obj.Deleted.Contains("osf.ClDictionaryEntry"))
                {
                    return _Deleted;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Deleted);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Deleted = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Deleted = "ScriptEngine.HostedScript.Library.DelegateAction" + "Deleted";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Deleted = value;
                    Base_obj.Deleted = "osf.ClDictionaryEntry" + "Deleted";
                }
                else
                {
                    Base_obj.Deleted = value.AsString();
                }
            }
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
        
        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
    }
}
