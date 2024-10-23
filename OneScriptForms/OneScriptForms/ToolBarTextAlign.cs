using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлВыравниваниеТекстаВПанелиИнструментов", "ClToolBarTextAlign")]
    public class ClToolBarTextAlign : AutoContext<ClToolBarTextAlign>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_underneath = (int)System.Windows.Forms.ToolBarTextAlign.Underneath; // 0 Текст выравнивается по нижней границе изображения кнопки панели инструментов.
        private int m_right = (int)System.Windows.Forms.ToolBarTextAlign.Right; // 1 Текст выравнивается по правому краю изображения кнопки панели инструментов.

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

        public ClToolBarTextAlign()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Right));
            _list.Add(ValueFactory.Create(Underneath));
        }

        [ContextProperty("Понизу", "Underneath")]
        public int Underneath
        {
        	get { return m_underneath; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
        	get { return m_right; }
        }
    }
}
