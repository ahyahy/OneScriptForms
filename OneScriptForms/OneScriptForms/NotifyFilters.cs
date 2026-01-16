using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлФильтрыУведомления", "ClNotifyFilters")]
    public class ClNotifyFilters : AutoContext<ClNotifyFilters>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_fileName = (int)System.IO.NotifyFilters.FileName; // 1 Имя файла.
        private int m_directoryName = (int)System.IO.NotifyFilters.DirectoryName; // 2 Имя каталога.
        private int m_attributes = (int)System.IO.NotifyFilters.Attributes; // 4 Атрибуты файла или каталога.
        private int m_size = (int)System.IO.NotifyFilters.Size; // 8 Размер файла или каталога.
        private int m_lastWrite = (int)System.IO.NotifyFilters.LastWrite; // 16 Дата последней записи в файл или каталог.
        private int m_lastAccess = (int)System.IO.NotifyFilters.LastAccess; // 32 Дата последнего открытия файла или каталога.
        private int m_creationTime = (int)System.IO.NotifyFilters.CreationTime; // 64 Время создания файла или каталога.
        private int m_security = (int)System.IO.NotifyFilters.Security; // 256 Параметры безопасности файла или каталога.

        private List<IValue> _list;

        public int Count()
        {
            return _list.Count;
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IValue>)_list).GetEnumerator();
        }

        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return (item as IValue);
            }
        }

        [ContextProperty("Количество", "Count")]
        public int CountProp
        {
            get { return _list.Count; }
        }

        [ContextMethod("Получить", "Get")]
        public IValue Get(int index)
        {
            return _list[index];
        }

        [ContextMethod("Имя")]
        public string NameRu(decimal p1)
        {
            return namesRu.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        [ContextMethod("Name")]
        public string NameEn(decimal p1)
        {
            return namesEn.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        private static readonly Dictionary<decimal, string> namesRu = new Dictionary<decimal, string>
        {
            {4, "Атрибуты"},
            {256, "Безопасность"},
            {64, "ВремяСоздания"},
            {2, "ИмяКаталога"},
            {1, "ИмяФайла"},
            {32, "ПоследнийДоступ"},
            {16, "ПоследняяЗапись"},
            {8, "Размер"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {4, "Attributes"},
            {256, "Security"},
            {64, "CreationTime"},
            {2, "DirectoryName"},
            {1, "FileName"},
            {32, "LastAccess"},
            {16, "LastWrite"},
            {8, "Size"},
        };

        public ClNotifyFilters()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Attributes));
            _list.Add(ValueFactory.Create(CreationTime));
            _list.Add(ValueFactory.Create(DirectoryName));
            _list.Add(ValueFactory.Create(FileName));
            _list.Add(ValueFactory.Create(LastAccess));
            _list.Add(ValueFactory.Create(LastWrite));
            _list.Add(ValueFactory.Create(Security));
            _list.Add(ValueFactory.Create(Size));
        }

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
