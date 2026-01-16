using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСтильЗаголовкаКолонки", "ClColumnHeaderStyle")]
    public class ClColumnHeaderStyle : AutoContext<ClColumnHeaderStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.ColumnHeaderStyle.None; // 0 Заголовок колонки не отображается.
        private int m_nonclickable = (int)System.Windows.Forms.ColumnHeaderStyle.Nonclickable; // 1 Заголовки колонок не отвечают на щелчок мыши.
        private int m_clickable = (int)System.Windows.Forms.ColumnHeaderStyle.Clickable; // 2 Заголовки колонок работают подобно кнопкам и можно выполнять различные действия, например сортировку.

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
            {2, "Нажимаемая"},
            {1, "НеНажимаемая"},
            {0, "Отсутствие"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {2, "Clickable"},
            {1, "Nonclickable"},
            {0, "None"},
        };

        public ClColumnHeaderStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Clickable));
            _list.Add(ValueFactory.Create(Nonclickable));
            _list.Add(ValueFactory.Create(None));
        }

        [ContextProperty("Нажимаемая", "Clickable")]
        public int Clickable
        {
            get { return m_clickable; }
        }

        [ContextProperty("НеНажимаемая", "Nonclickable")]
        public int Nonclickable
        {
            get { return m_nonclickable; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return m_none; }
        }
    }
}
