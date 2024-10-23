﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлВыравниваниеВСпискеЭлементов", "ClListViewAlignment")]
    public class ClListViewAlignment : AutoContext<ClListViewAlignment>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_default = (int)System.Windows.Forms.ListViewAlignment.Default; // 0 Когда пользователь перемещает элемент, он остается там, куда его положили.
        private int m_left = (int)System.Windows.Forms.ListViewAlignment.Left; // 1 Выравнивание элементов по левому краю.
        private int m_top = (int)System.Windows.Forms.ListViewAlignment.Top; // 2 Выравнивание элементов по верхнему краю.
        private int m_snapToGrid = (int)System.Windows.Forms.ListViewAlignment.SnapToGrid; // 5 Элементы выравниваются по невидимой сетке в элементе управления. Когда пользователь перемещает элемент, он перемещается к ближайшей точке пересечения сетки.

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

        public ClListViewAlignment()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Default));
            _list.Add(ValueFactory.Create(Left));
            _list.Add(ValueFactory.Create(SnapToGrid));
            _list.Add(ValueFactory.Create(Top));
        }

        [ContextProperty("Верх", "Top")]
        public int Top
        {
        	get { return m_top; }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
        	get { return m_left; }
        }

        [ContextProperty("ПоСетке", "SnapToGrid")]
        public int SnapToGrid
        {
        	get { return m_snapToGrid; }
        }

        [ContextProperty("ПоУмолчанию", "Default")]
        public int Default
        {
        	get { return m_default; }
        }
    }
}
