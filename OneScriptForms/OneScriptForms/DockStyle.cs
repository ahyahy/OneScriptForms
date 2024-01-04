using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСтильСтыковки", "ClDockStyle")]
    public class ClDockStyle : AutoContext<ClDockStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.DockStyle.None; // 0 Элемент управления не закреплен к краям содержащего его элемента управления.
        private int m_top = (int)System.Windows.Forms.DockStyle.Top; // 1 Верхний край элемента управления закрепляется к верхнему краю содержащего его элемента управления.
        private int m_bottom = (int)System.Windows.Forms.DockStyle.Bottom; // 2 Нижний край элемента управления закрепляется к нижнему краю содержащего его элемента управления.
        private int m_left = (int)System.Windows.Forms.DockStyle.Left; // 3 Левый край элемента управления закрепляется к левому краю содержащего его элемента управления.
        private int m_right = (int)System.Windows.Forms.DockStyle.Right; // 4 Правый край элемента управления закрепляется к правому краю содержащего его элемента управления.
        private int m_fill = (int)System.Windows.Forms.DockStyle.Fill; // 5 Края элемента управления закрепляются ко всем краям содержащего его элемента управления, а их размеры изменяются соответствующим образом.

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

        internal ClDockStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Bottom));
            _list.Add(ValueFactory.Create(Fill));
            _list.Add(ValueFactory.Create(Left));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Right));
            _list.Add(ValueFactory.Create(Top));
        }

        [ContextProperty("Верх", "Top")]
        public int Top
        {
        	get { return m_top; }
        }

        [ContextProperty("Заполнение", "Fill")]
        public int Fill
        {
        	get { return m_fill; }
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

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
        	get { return m_right; }
        }
    }
}
