using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРежимВставки", "ClInsertKeyMode")]
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

        internal ClInsertKeyMode()
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
