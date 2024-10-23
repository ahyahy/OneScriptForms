﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлВыравниваниеВкладок", "ClTabAlignment")]
    public class ClTabAlignment : AutoContext<ClTabAlignment>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_top = (int)System.Windows.Forms.TabAlignment.Top; // 0 Вкладки расположены по верхнему краю элемента управления.
        private int m_bottom = (int)System.Windows.Forms.TabAlignment.Bottom; // 1 Вкладки расположены по нижнему краю элемента управления.
        private int m_left = (int)System.Windows.Forms.TabAlignment.Left; // 2 Вкладки расположены вдоль левого края элемента управления.
        private int m_right = (int)System.Windows.Forms.TabAlignment.Right; // 3 Вкладки расположены по правому краю элемента управления.

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

        public ClTabAlignment()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Bottom));
            _list.Add(ValueFactory.Create(Left));
            _list.Add(ValueFactory.Create(Right));
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

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
        	get { return m_bottom; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
        	get { return m_right; }
        }
    }
}
