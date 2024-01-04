﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСтильГраницыПанелиСтрокиСостояния", "ClStatusBarPanelBorderStyle")]
    public class ClStatusBarPanelBorderStyle : AutoContext<ClStatusBarPanelBorderStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.StatusBarPanelBorderStyle.None; // 1 Граница не отображается.
        private int m_raised = (int)System.Windows.Forms.StatusBarPanelBorderStyle.Raised; // 2 Трехмерная приподнятая граница.
        private int m_sunken = (int)System.Windows.Forms.StatusBarPanelBorderStyle.Sunken; // 3 Трехмерная утопленная граница.

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

        internal ClStatusBarPanelBorderStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Raised));
            _list.Add(ValueFactory.Create(Sunken));
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("Рельефная", "Raised")]
        public int Raised
        {
        	get { return m_raised; }
        }

        [ContextProperty("Утопленная", "Sunken")]
        public int Sunken
        {
        	get { return m_sunken; }
        }
    }
}
