using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлЗвуки", "ClSounds")]
    public class ClSounds : AutoContext<ClSounds>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_question = 0; // 0 Звуковой файл, связанный с событием программы <B>Вопрос&nbsp;(Question)</B> в текущей звуковой схеме Windows.
        private int m_exclamation = 1; // 1 Звуковой файл, связанный с событием программы <B>Восклицание&nbsp;(Exclamation)</B> в текущей звуковой схеме Windows.
        private int m_beep = 2; // 2 Звуковой файл, связанный с событием программы <B>Гудок&nbsp;(Beep)</B> в текущей звуковой схеме Windows.
        private int m_asterisk = 3; // 3 Звуковой файл, связанный с событием программы <B>Звездочка&nbsp;(Asterisk)</B> в текущей звуковой схеме Windows.
        private int m_hand = 4; // 4 Звуковой файл, связанный с событием программы <B>Рука&nbsp;(Hand)</B> в текущей звуковой схеме Windows.

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
            {0, "Вопрос"},
            {1, "Восклицание"},
            {2, "Гудок"},
            {3, "Звездочка"},
            {4, "Рука"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {0, "Question"},
            {1, "Exclamation"},
            {2, "Beep"},
            {3, "Asterisk"},
            {4, "Hand"},
        };

        public ClSounds()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Asterisk));
            _list.Add(ValueFactory.Create(Beep));
            _list.Add(ValueFactory.Create(Exclamation));
            _list.Add(ValueFactory.Create(Hand));
            _list.Add(ValueFactory.Create(Question));
        }

        [ContextProperty("Вопрос", "Question")]
        public int Question
        {
            get { return m_question; }
        }

        [ContextProperty("Восклицание", "Exclamation")]
        public int Exclamation
        {
            get { return m_exclamation; }
        }

        [ContextProperty("Гудок", "Beep")]
        public int Beep
        {
            get { return m_beep; }
        }

        [ContextProperty("Звездочка", "Asterisk")]
        public int Asterisk
        {
            get { return m_asterisk; }
        }

        [ContextProperty("Рука", "Hand")]
        public int Hand
        {
            get { return m_hand; }
        }
    }
}
