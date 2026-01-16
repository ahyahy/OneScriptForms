using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлТипЭлементаСетки", "ClGridItemType")]
    public class ClGridItemType : AutoContext<ClGridItemType>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_property = (int)System.Windows.Forms.GridItemType.Property; // 0 Компонент сетки, соответствующий свойству.
        private int m_category = (int)System.Windows.Forms.GridItemType.Category; // 1 Компонент сетки, являющийся именем категории. Категория представляет собой описательную классификацию групп строк <A href="OneScriptForms.GridItem.html">ЭлементСетки&nbsp;(GridItem)</A>. К типовым категориям относятся <B>Поведение</B>, <B>Макет</B>, <B>Данные</B> и <B>Внешний вид</B>.
        private int m_arrayValue = (int)System.Windows.Forms.GridItemType.ArrayValue; // 2 Компонент сетки, соответствующий элементу массива.
        private int m_root = (int)System.Windows.Forms.GridItemType.Root; // 3 Корневой элемент в иерархии сетки.

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
            {1, "Категория"},
            {3, "Корневой"},
            {0, "Свойство"},
            {2, "ЭлементМассива"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Category"},
            {3, "Root"},
            {0, "Property"},
            {2, "ArrayValue"},
        };

        public ClGridItemType()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(ArrayValue));
            _list.Add(ValueFactory.Create(Category));
            _list.Add(ValueFactory.Create(Property));
            _list.Add(ValueFactory.Create(Root));
        }

        [ContextProperty("Категория", "Category")]
        public int Category
        {
            get { return m_category; }
        }

        [ContextProperty("Корневой", "Root")]
        public int Root
        {
            get { return m_root; }
        }

        [ContextProperty("Свойство", "Property")]
        public int Property
        {
            get { return m_property; }
        }

        [ContextProperty("ЭлементМассива", "ArrayValue")]
        public int ArrayValue
        {
            get { return m_arrayValue; }
        }
    }
}
