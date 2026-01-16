using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлРежимВыбора", "ClSelectionMode")]
    public class ClSelectionMode : AutoContext<ClSelectionMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.SelectionMode.None; // 0 Элементы не могут быть выбраны.
        private int m_one = (int)System.Windows.Forms.SelectionMode.One; // 1 Можно выбрать только один элемент.
        private int m_multiSimple = (int)System.Windows.Forms.SelectionMode.MultiSimple; // 2 Можно выбрать несколько элементов.
        private int m_multiExtended = (int)System.Windows.Forms.SelectionMode.MultiExtended; // 3 Можно выбрать несколько элементов. Пользователь может использовать для выбора клавиши SHIFT, CTRL и клавиши со стрелками.

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
            {2, "МножественныйПростой"},
            {3, "МножественныйРасширенный"},
            {1, "Одиночный"},
            {0, "Отсутствие"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {2, "MultiSimple"},
            {3, "MultiExtended"},
            {1, "One"},
            {0, "None"},
        };

        public ClSelectionMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(MultiExtended));
            _list.Add(ValueFactory.Create(MultiSimple));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(One));
        }

        [ContextProperty("МножественныйПростой", "MultiSimple")]
        public int MultiSimple
        {
            get { return m_multiSimple; }
        }

        [ContextProperty("МножественныйРасширенный", "MultiExtended")]
        public int MultiExtended
        {
            get { return m_multiExtended; }
        }

        [ContextProperty("Одиночный", "One")]
        public int One
        {
            get { return m_one; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return m_none; }
        }
    }
}
