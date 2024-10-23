using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлАктивацияЭлемента", "ClItemActivation")]
    public class ClItemActivation : AutoContext<ClItemActivation>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_standard = (int)System.Windows.Forms.ItemActivation.Standard; // 0 Активация двойным щелчком. Без обратной связи при перемещении пользователем указателя мыши над элементом.
        private int m_oneClick = (int)System.Windows.Forms.ItemActivation.OneClick; // 1 Активация одним щелчком. Курсор изменяется на указатель курсора в виде руки и изменяется цвет текста элемента при перемещении пользователем указателя мыши над элементом.
        private int m_twoClick = (int)System.Windows.Forms.ItemActivation.TwoClick; // 2 Пользователь должен щелкнуть элемент дважды, чтобы активировать его. Это отличается от стандартного двойного щелчка, поскольку между щелчками может пройти некоторое время. Изменяется цвет текста элемента при перемещении пользователем указателя мыши над элементом.

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

        public ClItemActivation()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(OneClick));
            _list.Add(ValueFactory.Create(Standard));
            _list.Add(ValueFactory.Create(TwoClick));
        }

        [ContextProperty("ДваНажатия", "TwoClick")]
        public int TwoClick
        {
        	get { return m_twoClick; }
        }

        [ContextProperty("ОдноНажатие", "OneClick")]
        public int OneClick
        {
        	get { return m_oneClick; }
        }

        [ContextProperty("Стандартная", "Standard")]
        public int Standard
        {
        	get { return m_standard; }
        }
    }
}
