﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСтильПоляВыбора", "ClComboBoxStyle")]
    public class ClComboBoxStyle : AutoContext<ClComboBoxStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_simple = (int)System.Windows.Forms.ComboBoxStyle.Simple; // 0 Выпадающий список отображается всегда, а текстовая часть является редактируемой. Это означает, что пользователь может ввести новое значение, а не ограничиваться выбором из существующих значений в списке.
        private int m_dropDown = (int)System.Windows.Forms.ComboBoxStyle.DropDown; // 1 Нажав кнопку со стрелкой вниз получаем выпадающий список, текстовая часть которого является редактируемой. Это означает, что пользователь может ввести новое значение, а не ограничиваться выбором из существующих значений в списке. Это стиль по умолчанию.
        private int m_dropDownList = (int)System.Windows.Forms.ComboBoxStyle.DropDownList; // 2 Нажав кнопку со стрелкой вниз получаем выпадающий список, текстовая часть которого не является редактируемой. Это означает, что пользователь не может ввести новое значение. Можно выбрать только значение из списка.

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

        public ClComboBoxStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(DropDown));
            _list.Add(ValueFactory.Create(DropDownList));
            _list.Add(ValueFactory.Create(Simple));
        }

        [ContextProperty("НеРедактируемый", "DropDownList")]
        public int DropDownList
        {
        	get { return m_dropDownList; }
        }

        [ContextProperty("Простой", "Simple")]
        public int Simple
        {
        	get { return m_simple; }
        }

        [ContextProperty("Редактируемый", "DropDown")]
        public int DropDown
        {
        	get { return m_dropDown; }
        }
    }
}
