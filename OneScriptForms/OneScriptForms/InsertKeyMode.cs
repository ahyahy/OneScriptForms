using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлРежимВставки", "ClInsertKeyMode")]
    public class ClInsertKeyMode : AutoContext<ClInsertKeyMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_default = (int)System.Windows.Forms.InsertKeyMode.Default; // 0 Учитывает текущий режим клавиши INSERT на клавиатуре.
        private int m_insert = (int)System.Windows.Forms.InsertKeyMode.Insert; // 1 Указывает, что режим вставки включен независимо от режима клавиши INSERT.
        private int m_overwrite = (int)System.Windows.Forms.InsertKeyMode.Overwrite; // 2 Указывает, что режим перезаписи включен независимо от режима клавиши INSERT.

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
            {1, "Вставить"},
            {2, "Перезаписать"},
            {0, "ПоУмолчанию"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Insert"},
            {2, "Overwrite"},
            {0, "Default"},
        };

        public ClInsertKeyMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Default));
            _list.Add(ValueFactory.Create(Insert));
            _list.Add(ValueFactory.Create(Overwrite));
        }

        [ContextProperty("Вставить", "Insert")]
        public int Insert
        {
            get { return m_insert; }
        }

        [ContextProperty("Перезаписать", "Overwrite")]
        public int Overwrite
        {
            get { return m_overwrite; }
        }

        [ContextProperty("ПоУмолчанию", "Default")]
        public int Default
        {
            get { return m_default; }
        }
    }
}
