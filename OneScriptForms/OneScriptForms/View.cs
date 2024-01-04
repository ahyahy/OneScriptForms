using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace osf
{
    [ContextClass ("КлРежимОтображения", "ClView")]
    public class ClView : AutoContext<ClView>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_largeIcon = (int)View.LargeIcon; // 0 Каждый элемент отображается в виде полноразмерного значка с меткой под ним.
        private int m_details = (int)View.Details; // 1 Каждый элемент отображается в отдельной строке. Дополнительные сведения о каждом элементе распределены по колонкам.  Крайняя левая колонка содержит небольшой значок и метку, а последующие колонки содержат вложенные элементы.  В колонке отображается заголовок. Пользователь может изменить размер каждой колонки.
        private int m_smallIcon = (int)View.SmallIcon; // 2 Каждый элемент отображается в виде небольшого значка с меткой справа.
        private int m_list = (int)View.List; // 3 Каждый элемент отображается в виде небольшого значка с меткой справа. Элементы располагаются в колонках без заголовков колонок.

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

        internal ClView()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Details));
            _list.Add(ValueFactory.Create(LargeIcon));
            _list.Add(ValueFactory.Create(List));
            _list.Add(ValueFactory.Create(SmallIcon));
        }

        [ContextProperty("БольшойЗначок", "LargeIcon")]
        public int LargeIcon
        {
        	get { return m_largeIcon; }
        }

        [ContextProperty("МаленькийЗначок", "SmallIcon")]
        public int SmallIcon
        {
        	get { return m_smallIcon; }
        }

        [ContextProperty("Подробно", "Details")]
        public int Details
        {
        	get { return m_details; }
        }

        [ContextProperty("Список", "List")]
        public int List
        {
        	get { return m_list; }
        }
    }
}
