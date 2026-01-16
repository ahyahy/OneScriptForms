using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлОриентацияПолосы", "ClScrollOrientation")]
    public class ClScrollOrientation : AutoContext<ClScrollOrientation>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_horizontalScroll = (int)System.Windows.Forms.ScrollOrientation.HorizontalScroll; // 0 Горизонтальная полоса прокрутки.
        private int m_verticalScroll = (int)System.Windows.Forms.ScrollOrientation.VerticalScroll; // 1 Вертикальная полоса прокрутки.

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
            {1, "ВертикальнаяПрокрутка"},
            {0, "ГоризонтальнаяПрокрутка"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "VerticalScroll"},
            {0, "HorizontalScroll"},
        };

        public ClScrollOrientation()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(HorizontalScroll));
            _list.Add(ValueFactory.Create(VerticalScroll));
        }

        [ContextProperty("ВертикальнаяПрокрутка", "VerticalScroll")]
        public int VerticalScroll
        {
            get { return m_verticalScroll; }
        }

        [ContextProperty("ГоризонтальнаяПрокрутка", "HorizontalScroll")]
        public int HorizontalScroll
        {
            get { return m_horizontalScroll; }
        }
    }
}
