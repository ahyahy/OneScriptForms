using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлДеревоДействие", "ClTreeViewAction")]
    public class ClTreeViewAction : AutoContext<ClTreeViewAction>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_unknown = (int)System.Windows.Forms.TreeViewAction.Unknown; // 0 Действие, вызвавшее событие неизвестно.
        private int m_byKeyboard = (int)System.Windows.Forms.TreeViewAction.ByKeyboard; // 1 Событие вызвано нажатием клавиши.
        private int m_byMouse = (int)System.Windows.Forms.TreeViewAction.ByMouse; // 2 Событие вызвано операцией с мышью.
        private int m_collapse = (int)System.Windows.Forms.TreeViewAction.Collapse; // 3 Вызвано событие свертывания узла дерева.
        private int m_expand = (int)System.Windows.Forms.TreeViewAction.Expand; // 4 Вызвано событие развертывания узла дерева.

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

        public ClTreeViewAction()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(ByKeyboard));
            _list.Add(ValueFactory.Create(ByMouse));
            _list.Add(ValueFactory.Create(Collapse));
            _list.Add(ValueFactory.Create(Expand));
            _list.Add(ValueFactory.Create(Unknown));
        }

        [ContextProperty("Неизвестно", "Unknown")]
        public int Unknown
        {
        	get { return m_unknown; }
        }

        [ContextProperty("ОтКлавиатуры", "ByKeyboard")]
        public int ByKeyboard
        {
        	get { return m_byKeyboard; }
        }

        [ContextProperty("ОтМыши", "ByMouse")]
        public int ByMouse
        {
        	get { return m_byMouse; }
        }

        [ContextProperty("Развертывание", "Expand")]
        public int Expand
        {
        	get { return m_expand; }
        }

        [ContextProperty("Свертывание", "Collapse")]
        public int Collapse
        {
        	get { return m_collapse; }
        }
    }
}
