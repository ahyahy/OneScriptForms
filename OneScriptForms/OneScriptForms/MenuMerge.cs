using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСлияниеМеню", "ClMenuMerge")]
    public class ClMenuMerge : AutoContext<ClMenuMerge>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_add = (int)System.Windows.Forms.MenuMerge.Add; // 0 Объект <B>ЭлементМеню&nbsp;(MenuItem)</B> добавляется к коллекции объектов <B>ЭлементМеню&nbsp;(MenuItem)</B> в объединенном меню.
        private int m_replace = (int)System.Windows.Forms.MenuMerge.Replace; // 1 Объект <B>ЭлементМеню&nbsp;(MenuItem)</B> заменяет существующий <B>ЭлементМеню&nbsp;(MenuItem)</B> в той же позиции в объединенном меню.
        private int m_mergeItems = (int)System.Windows.Forms.MenuMerge.MergeItems; // 2 Все элементы вложенного меню этого <B>ЭлементМеню&nbsp;(MenuItem)</B> объединяются с соответствующими элементами существующих объектов <B>ЭлементМеню&nbsp;(MenuItem)</B> в той же позиции в объединенном меню.
        private int m_remove = (int)System.Windows.Forms.MenuMerge.Remove; // 3 Объект <B>ЭлементМеню&nbsp;(MenuItem)</B> удаляется из объединенного меню.

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
            {0, "Добавить"},
            {1, "Заменить"},
            {2, "ОбъединитьМеню"},
            {3, "Удалить"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {0, "Add"},
            {1, "Replace"},
            {2, "MergeItems"},
            {3, "Remove"},
        };

        public ClMenuMerge()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Add));
            _list.Add(ValueFactory.Create(MergeItems));
            _list.Add(ValueFactory.Create(Remove));
            _list.Add(ValueFactory.Create(Replace));
        }

        [ContextProperty("Добавить", "Add")]
        public int Add
        {
            get { return m_add; }
        }

        [ContextProperty("Заменить", "Replace")]
        public int Replace
        {
            get { return m_replace; }
        }

        [ContextProperty("ОбъединитьМеню", "MergeItems")]
        public int MergeItems
        {
            get { return m_mergeItems; }
        }

        [ContextProperty("Удалить", "Remove")]
        public int Remove
        {
            get { return m_remove; }
        }
    }
}
