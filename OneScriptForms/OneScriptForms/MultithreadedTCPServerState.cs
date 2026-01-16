using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСостояниеМногопоточногоTCPСервера", "ClMultithreadedTCPServerState")]
    public class ClMultithreadedTCPServerState : AutoContext<ClMultithreadedTCPServerState>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_stopped = 0; // 0 Сервер остановлен пользователем.
        private int m_starting = 1; // 1 Сервер запускается.
        private int m_running = 2; // 2 Сервер запущен.
        private int m_stopping = 3; // 3 Сервер останавливается.
        private int m_stoppedWithError = 4; // 4 Сервер остановлен из за ошибки.

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
            {1, "Запускается"},
            {2, "Запущен"},
            {3, "Останавливается"},
            {0, "Остановлен"},
            {4, "ОстановленСОшибкой"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Starting"},
            {2, "Running"},
            {3, "Stopping"},
            {0, "Stopped"},
            {4, "StoppedWithError"},
        };

        public ClMultithreadedTCPServerState()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Running));
            _list.Add(ValueFactory.Create(Starting));
            _list.Add(ValueFactory.Create(Stopped));
            _list.Add(ValueFactory.Create(StoppedWithError));
            _list.Add(ValueFactory.Create(Stopping));
        }

        [ContextProperty("Запускается", "Starting")]
        public int Starting
        {
            get { return m_starting; }
        }

        [ContextProperty("Запущен", "Running")]
        public int Running
        {
            get { return m_running; }
        }

        [ContextProperty("Останавливается", "Stopping")]
        public int Stopping
        {
            get { return m_stopping; }
        }

        [ContextProperty("Остановлен", "Stopped")]
        public int Stopped
        {
            get { return m_stopped; }
        }

        [ContextProperty("ОстановленСОшибкой", "StoppedWithError")]
        public int StoppedWithError
        {
            get { return m_stoppedWithError; }
        }
    }
}
