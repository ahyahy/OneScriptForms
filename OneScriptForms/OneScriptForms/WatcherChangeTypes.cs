using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлНаблюдательИзмененияВида", "ClWatcherChangeTypes")]
    public class ClWatcherChangeTypes : AutoContext<ClWatcherChangeTypes>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_created = (int)System.IO.WatcherChangeTypes.Created; // 1 Создание файла или каталога.
        private int m_deleted = (int)System.IO.WatcherChangeTypes.Deleted; // 2 Удаление файла или каталога.
        private int m_changed = (int)System.IO.WatcherChangeTypes.Changed; // 4 Изменение файла или каталога. Типы изменений включают: изменения размера, атрибутов, параметров безопасности, последней записи и времени последнего доступа.
        private int m_renamed = (int)System.IO.WatcherChangeTypes.Renamed; // 8 Переименование файла или каталога.
        private int m_all = (int)System.IO.WatcherChangeTypes.All; // 15 Создание, удаление, изменение или переименование файла или каталога.

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
            {15, "Все"},
            {4, "Изменение"},
            {8, "Переименование"},
            {1, "Создание"},
            {2, "Удаление"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {15, "All"},
            {4, "Changed"},
            {8, "Renamed"},
            {1, "Created"},
            {2, "Deleted"},
        };

        public ClWatcherChangeTypes()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(All));
            _list.Add(ValueFactory.Create(Changed));
            _list.Add(ValueFactory.Create(Created));
            _list.Add(ValueFactory.Create(Deleted));
            _list.Add(ValueFactory.Create(Renamed));
        }

        [ContextProperty("Все", "All")]
        public int All
        {
            get { return m_all; }
        }

        [ContextProperty("Изменение", "Changed")]
        public int Changed
        {
            get { return m_changed; }
        }

        [ContextProperty("Переименование", "Renamed")]
        public int Renamed
        {
            get { return m_renamed; }
        }

        [ContextProperty("Создание", "Created")]
        public int Created
        {
            get { return m_created; }
        }

        [ContextProperty("Удаление", "Deleted")]
        public int Deleted
        {
            get { return m_deleted; }
        }
    }
}
