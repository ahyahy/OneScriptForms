using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСтильШрифта", "ClFontStyle")]
    public class ClFontStyle : AutoContext<ClFontStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_regular = (int)System.Drawing.FontStyle.Regular; // 0 Обычный шрифт.
        private int m_bold = (int)System.Drawing.FontStyle.Bold; // 1 Полужирный шрифт.
        private int m_italic = (int)System.Drawing.FontStyle.Italic; // 2 Шрифт курсив.
        private int m_underline = (int)System.Drawing.FontStyle.Underline; // 4 Подчеркнутый шрифт.
        private int m_strikeout = (int)System.Drawing.FontStyle.Strikeout; // 8 Зачеркнутый шрифт.

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
            {1, "Жирный"},
            {8, "Зачеркнутый"},
            {2, "Курсив"},
            {4, "Подчеркнутый"},
            {0, "Стандартный"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Bold"},
            {8, "Strikeout"},
            {2, "Italic"},
            {4, "Underline"},
            {0, "Regular"},
        };

        public ClFontStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Bold));
            _list.Add(ValueFactory.Create(Italic));
            _list.Add(ValueFactory.Create(Regular));
            _list.Add(ValueFactory.Create(Strikeout));
            _list.Add(ValueFactory.Create(Underline));
        }

        [ContextProperty("Жирный", "Bold")]
        public int Bold
        {
            get { return m_bold; }
        }

        [ContextProperty("Зачеркнутый", "Strikeout")]
        public int Strikeout
        {
            get { return m_strikeout; }
        }

        [ContextProperty("Курсив", "Italic")]
        public int Italic
        {
            get { return m_italic; }
        }

        [ContextProperty("Подчеркнутый", "Underline")]
        public int Underline
        {
            get { return m_underline; }
        }

        [ContextProperty("Стандартный", "Regular")]
        public int Regular
        {
            get { return m_regular; }
        }
    }
}
