﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace osf
{
    [ContextClass ("КлРежимСортировки", "ClDataGridViewColumnSortMode")]
    public class ClDataGridViewColumnSortMode : AutoContext<ClDataGridViewColumnSortMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_notSortable = (int)DataGridViewColumnSortMode.NotSortable; // 0 Колонка может быть отсортирована только программным способом, однако он не предназначен для сортировки, поэтому заголовок колонки не будет содержать места для глифа сортировки.
        private int m_automatic = (int)DataGridViewColumnSortMode.Automatic; // 1 Пользователь может сортировать колонку, щелкнув заголовок колонки (или нажав клавишу F3 в ячейке), если только заголовки колонок не используются для выборки. Глиф сортировки отображается автоматически.
        private int m_programmatic = (int)DataGridViewColumnSortMode.Programmatic; // 2 Колонка может быть отсортирована только программным способом, и заголовок колонки будет содержать место для глифа сортировки.

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

        public ClDataGridViewColumnSortMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Automatic));
            _list.Add(ValueFactory.Create(NotSortable));
            _list.Add(ValueFactory.Create(Programmatic));
        }

        [ContextProperty("Автоматически", "Automatic")]
        public int Automatic
        {
        	get { return m_automatic; }
        }

        [ContextProperty("НеСортируемый", "NotSortable")]
        public int NotSortable
        {
        	get { return m_notSortable; }
        }

        [ContextProperty("Программный", "Programmatic")]
        public int Programmatic
        {
        	get { return m_programmatic; }
        }
    }
}
