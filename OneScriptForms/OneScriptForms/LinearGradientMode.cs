using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРежимГрадиента", "ClLinearGradientMode")]
    public class ClLinearGradientMode : AutoContext<ClLinearGradientMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_horizontal = (int)System.Drawing.Drawing2D.LinearGradientMode.Horizontal; // 0 Задает градиент слева направо.
        private int m_vertical = (int)System.Drawing.Drawing2D.LinearGradientMode.Vertical; // 1 Задает градиент сверху вниз.
        private int m_forwardDiagonal = (int)System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal; // 2 Задает градиент от левого верхнего угла до правого нижнего угла.
        private int m_backwardDiagonal = (int)System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal; // 3 Задает градиент от правого верхнего угла до левого нижнего угла.

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

        internal ClLinearGradientMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(BackwardDiagonal));
            _list.Add(ValueFactory.Create(ForwardDiagonal));
            _list.Add(ValueFactory.Create(Horizontal));
            _list.Add(ValueFactory.Create(Vertical));
        }

        [ContextProperty("Вертикаль", "Vertical")]
        public int Vertical
        {
        	get { return m_vertical; }
        }

        [ContextProperty("Горизонталь", "Horizontal")]
        public int Horizontal
        {
        	get { return m_horizontal; }
        }

        [ContextProperty("ОбратнаяДиагональ", "BackwardDiagonal")]
        public int BackwardDiagonal
        {
        	get { return m_backwardDiagonal; }
        }

        [ContextProperty("ПрямаяДиагональ", "ForwardDiagonal")]
        public int ForwardDiagonal
        {
        	get { return m_forwardDiagonal; }
        }
    }
}
