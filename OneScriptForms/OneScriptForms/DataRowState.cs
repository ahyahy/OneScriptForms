using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСостояниеСтрокиДанных", "ClDataRowState")]
    public class ClDataRowState : AutoContext<ClDataRowState>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_detached = (int)System.Data.DataRowState.Detached; // 1 Строка была создана, но не является частью какой-либо коллекции данных. Поток данных находится в этом состоянии сразу после его создания и до его добавления в коллекцию или после его удаления из коллекции.
        private int m_unchanged = (int)System.Data.DataRowState.Unchanged; // 2 Строка не изменилась с момента последнего вызова функции <A href="OneScriptForms.DataRow.AcceptChanges.html">СтрокаДанных.ПринятьИзменения&nbsp;(DataRow.AcceptChanges)</A>.
        private int m_added = (int)System.Data.DataRowState.Added; // 4 Строка была добавлена в коллекцию <A href="OneScriptForms.DataRowCollection.html">СтрокиДанных&nbsp;(DataRowCollection)</A>, а функция <A href="OneScriptForms.DataRow.AcceptChanges.html">СтрокаДанных.ПринятьИзменения&nbsp;(DataRow.AcceptChanges)</A> не была вызвана.
        private int m_deleted = (int)System.Data.DataRowState.Deleted; // 8 Строка была удалена с помощью метода <A href="OneScriptForms.DataRow.Delete.html">СтрокаДанных.Удалить&nbsp;(DataRow.Delete)</A>.
        private int m_modified = (int)System.Data.DataRowState.Modified; // 16 Строка была изменена, и функция <A href="OneScriptForms.DataRow.AcceptChanges.html">СтрокаДанных.ПринятьИзменения&nbsp;(DataRow.AcceptChanges)</A> не была вызвана.

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
            {4, "Добавлена"},
            {16, "Изменена"},
            {2, "Неизменна"},
            {1, "Отсоединена"},
            {8, "Удалена"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {4, "Added"},
            {16, "Modified"},
            {2, "Unchanged"},
            {1, "Detached"},
            {8, "Deleted"},
        };

        public ClDataRowState()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Added));
            _list.Add(ValueFactory.Create(Deleted));
            _list.Add(ValueFactory.Create(Detached));
            _list.Add(ValueFactory.Create(Modified));
            _list.Add(ValueFactory.Create(Unchanged));
        }

        [ContextProperty("Добавлена", "Added")]
        public int Added
        {
            get { return m_added; }
        }

        [ContextProperty("Изменена", "Modified")]
        public int Modified
        {
            get { return m_modified; }
        }

        [ContextProperty("Неизменна", "Unchanged")]
        public int Unchanged
        {
            get { return m_unchanged; }
        }

        [ContextProperty("Отсоединена", "Detached")]
        public int Detached
        {
            get { return m_detached; }
        }

        [ContextProperty("Удалена", "Deleted")]
        public int Deleted
        {
            get { return m_deleted; }
        }
    }
}
