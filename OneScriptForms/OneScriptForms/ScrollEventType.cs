using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлТипСобытияПрокрутки", "ClScrollEventType")]
    public class ClScrollEventType : AutoContext<ClScrollEventType>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_smallDecrement = (int)System.Windows.Forms.ScrollEventType.SmallDecrement; // 0 Ползунок полосы прокрутки переместился на малое расстояние. Пользователь щелкнул левую (на горизонтальной полосе) или верхнюю (на вертикальной) кнопку со стрелкой для прокрутки, либо нажал клавишу СТРЕЛКА ВВЕРХ.
        private int m_smallIncrement = (int)System.Windows.Forms.ScrollEventType.SmallIncrement; // 1 Ползунок полосы прокрутки переместился на малое расстояние. Пользователь щелкнул правую (на горизонтальной полосе) или нижнюю (на вертикальной) кнопку прокрутки, либо нажал клавишу СТРЕЛКА ВНИЗ.
        private int m_largeDecrement = (int)System.Windows.Forms.ScrollEventType.LargeDecrement; // 2 Ползунок полосы прокрутки переместился на большое расстояние. Пользователь щелкнул полосу прокрутки левее (на горизонтальной полосе) или выше (на вертикальной) от ползунка полосы прокрутки, либо нажал клавишу PAGE UP.
        private int m_largeIncrement = (int)System.Windows.Forms.ScrollEventType.LargeIncrement; // 3 Ползунок полосы прокрутки переместился на большое расстояние. Пользователь щелкнул полосу прокрутки правее (на горизонтальной полосе) или ниже (на вертикальной) от ползунка полосы прокрутки, либо нажал клавишу PAGE DOWN.
        private int m_thumbPosition = (int)System.Windows.Forms.ScrollEventType.ThumbPosition; // 4 Ползунок полосы прокрутки переместился.
        private int m_thumbTrack = (int)System.Windows.Forms.ScrollEventType.ThumbTrack; // 5 Ползунок полосы прокрутки перемещается в данный момент.
        private int m_first = (int)System.Windows.Forms.ScrollEventType.First; // 6 Ползунок полосы прокрутки переместился в позицию минимума.
        private int m_last = (int)System.Windows.Forms.ScrollEventType.Last; // 7 Ползунок полосы прокрутки переместился в позицию максимума.
        private int m_endScroll = (int)System.Windows.Forms.ScrollEventType.EndScroll; // 8 Ползунок полосы прокрутки остановился.

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

        public ClScrollEventType()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(EndScroll));
            _list.Add(ValueFactory.Create(First));
            _list.Add(ValueFactory.Create(LargeDecrement));
            _list.Add(ValueFactory.Create(LargeIncrement));
            _list.Add(ValueFactory.Create(Last));
            _list.Add(ValueFactory.Create(SmallDecrement));
            _list.Add(ValueFactory.Create(SmallIncrement));
            _list.Add(ValueFactory.Create(ThumbPosition));
            _list.Add(ValueFactory.Create(ThumbTrack));
        }

        [ContextProperty("БольшоеУвеличение", "LargeIncrement")]
        public int LargeIncrement
        {
        	get { return m_largeIncrement; }
        }

        [ContextProperty("БольшоеУменьшение", "LargeDecrement")]
        public int LargeDecrement
        {
        	get { return m_largeDecrement; }
        }

        [ContextProperty("Максимум", "Last")]
        public int Last
        {
        	get { return m_last; }
        }

        [ContextProperty("МалоеУвеличение", "SmallIncrement")]
        public int SmallIncrement
        {
        	get { return m_smallIncrement; }
        }

        [ContextProperty("МалоеУменьшение", "SmallDecrement")]
        public int SmallDecrement
        {
        	get { return m_smallDecrement; }
        }

        [ContextProperty("Минимум", "First")]
        public int First
        {
        	get { return m_first; }
        }

        [ContextProperty("Переместился", "ThumbPosition")]
        public int ThumbPosition
        {
        	get { return m_thumbPosition; }
        }

        [ContextProperty("Перемещается", "ThumbTrack")]
        public int ThumbTrack
        {
        	get { return m_thumbTrack; }
        }

        [ContextProperty("ПолзунокОстановился", "EndScroll")]
        public int EndScroll
        {
        	get { return m_endScroll; }
        }
    }
}
