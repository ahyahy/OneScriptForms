using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлСокращениеСтроки", "ClStringTrimming")]
    public class ClStringTrimming : AutoContext<ClStringTrimming>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Drawing.StringTrimming.None; // 0 Указывает на отсутствие обрезки.
        private int m_character = (int)System.Drawing.StringTrimming.Character; // 1 Указывает, что текст обрезается по ближайшему знаку.
        private int m_word = (int)System.Drawing.StringTrimming.Word; // 2 Указывает, что текст обрезается по ближайшему слову.
        private int m_ellipsisCharacter = (int)System.Drawing.StringTrimming.EllipsisCharacter; // 3 Указывает, что текст обрезается по ближайшему знаку и в конце обрезанной строки вставляется троеточие.
        private int m_ellipsisWord = (int)System.Drawing.StringTrimming.EllipsisWord; // 4 Указывает, что текст обрезается по ближайшему слову и в конце обрезанной строки вставляется троеточие.
        private int m_ellipsisPath = (int)System.Drawing.StringTrimming.EllipsisPath; // 5 Из обрезанных строк удаляется центральная часть и заменяется троеточием. Этот алгоритм позволяет сохранить максимально возможную часть отделенного косой чертой последнего сегмента строки.

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
            {0, "Отсутствие"},
            {5, "ПутьМноготочие"},
            {1, "Символ"},
            {3, "СимволМноготочие"},
            {2, "Слово"},
            {4, "СловоМноготочие"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {0, "None"},
            {5, "EllipsisPath"},
            {1, "Character"},
            {3, "EllipsisCharacter"},
            {2, "Word"},
            {4, "EllipsisWord"},
        };

        public ClStringTrimming()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Character));
            _list.Add(ValueFactory.Create(EllipsisCharacter));
            _list.Add(ValueFactory.Create(EllipsisPath));
            _list.Add(ValueFactory.Create(EllipsisWord));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Word));
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return m_none; }
        }

        [ContextProperty("ПутьМноготочие", "EllipsisPath")]
        public int EllipsisPath
        {
            get { return m_ellipsisPath; }
        }

        [ContextProperty("Символ", "Character")]
        public int Character
        {
            get { return m_character; }
        }

        [ContextProperty("СимволМноготочие", "EllipsisCharacter")]
        public int EllipsisCharacter
        {
            get { return m_ellipsisCharacter; }
        }

        [ContextProperty("Слово", "Word")]
        public int Word
        {
            get { return m_word; }
        }

        [ContextProperty("СловоМноготочие", "EllipsisWord")]
        public int EllipsisWord
        {
            get { return m_ellipsisWord; }
        }
    }
}
