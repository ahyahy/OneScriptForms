﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСтильГраницыФормы", "ClFormBorderStyle")]
    public class ClFormBorderStyle : AutoContext<ClFormBorderStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.FormBorderStyle.None; // 0 Граница отсутствует.
        private int m_fixedSingle = (int)System.Windows.Forms.FormBorderStyle.FixedSingle; // 1 Фиксированная однострочная граница.
        private int m_fixed3D = (int)System.Windows.Forms.FormBorderStyle.Fixed3D; // 2 Фиксированная трехмерная граница.
        private int m_fixedDialog = (int)System.Windows.Forms.FormBorderStyle.FixedDialog; // 3 Граница толстым, как в диалоговых оконах.
        private int m_sizable = (int)System.Windows.Forms.FormBorderStyle.Sizable; // 4 Изменяемая граница.
        private int m_fixedToolWindow = (int)System.Windows.Forms.FormBorderStyle.FixedToolWindow; // 5 Граница окна инструментов, размеры которого не изменяются. Окно инструментов не отображается на панели задач или в окне, которое появляется, когда пользователь нажимает сочетание клавиш ALT + TAB.
        private int m_sizableToolWindow = (int)System.Windows.Forms.FormBorderStyle.SizableToolWindow; // 6 Изменяемая граница окна инструментов. Окно инструментов не отображается на панели задач или в окне, которое появляется, когда пользователь нажимает сочетание клавиш ALT + TAB.

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

        internal ClFormBorderStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Fixed3D));
            _list.Add(ValueFactory.Create(FixedDialog));
            _list.Add(ValueFactory.Create(FixedSingle));
            _list.Add(ValueFactory.Create(FixedToolWindow));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Sizable));
            _list.Add(ValueFactory.Create(SizableToolWindow));
        }

        [ContextProperty("ГраницаОкнаИнструментов", "FixedToolWindow")]
        public int FixedToolWindow
        {
        	get { return m_fixedToolWindow; }
        }

        [ContextProperty("Диалоговая", "FixedDialog")]
        public int FixedDialog
        {
        	get { return m_fixedDialog; }
        }

        [ContextProperty("Изменяемая", "Sizable")]
        public int Sizable
        {
        	get { return m_sizable; }
        }

        [ContextProperty("ИзменяемаяОкнаИнструментов", "SizableToolWindow")]
        public int SizableToolWindow
        {
        	get { return m_sizableToolWindow; }
        }

        [ContextProperty("Одинарная", "FixedSingle")]
        public int FixedSingle
        {
        	get { return m_fixedSingle; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("Трехмерная", "Fixed3D")]
        public int Fixed3D
        {
        	get { return m_fixed3D; }
        }
    }
}
