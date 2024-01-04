using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСтильКнопокПанелиИнструментов", "ClToolBarButtonStyle")]
    public class ClToolBarButtonStyle : AutoContext<ClToolBarButtonStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_pushButton = (int)System.Windows.Forms.ToolBarButtonStyle.PushButton; // 1 Стандартная трехмерная кнопка.
        private int m_toggleButton = (int)System.Windows.Forms.ToolBarButtonStyle.ToggleButton; // 2 Выключатель, который отображается углубленным при щелчке и остается таковым до следующего нажатия на него.
        private int m_separator = (int)System.Windows.Forms.ToolBarButtonStyle.Separator; // 3 Промежуток или линия между кнопками панели инструментов. Внешний вид зависит от значения свойства <B>Оформление&nbsp;(Appearance)</B>.
        private int m_dropDownButton = (int)System.Windows.Forms.ToolBarButtonStyle.DropDownButton; // 4 Раскрывающийся элемент управления отображает меню или окно при нажатии.

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

        internal ClToolBarButtonStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(DropDownButton));
            _list.Add(ValueFactory.Create(PushButton));
            _list.Add(ValueFactory.Create(Separator));
            _list.Add(ValueFactory.Create(ToggleButton));
        }

        [ContextProperty("КнопкаВыпадающегоСписка", "DropDownButton")]
        public int DropDownButton
        {
        	get { return m_dropDownButton; }
        }

        [ContextProperty("Разделитель", "Separator")]
        public int Separator
        {
        	get { return m_separator; }
        }

        [ContextProperty("СтандартнаяТрехмерная", "PushButton")]
        public int PushButton
        {
        	get { return m_pushButton; }
        }

        [ContextProperty("Тумблер", "ToggleButton")]
        public int ToggleButton
        {
        	get { return m_toggleButton; }
        }
    }
}
