using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРезультатДиалога", "ClDialogResult")]
    public class ClDialogResult : AutoContext<ClDialogResult>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.DialogResult.None; // 0 Диалоговое окно возвращает значение <B>Ничего</B>. Это означает, что модальное диалоговое окно не закрывается.
        private int m_oK = (int)System.Windows.Forms.DialogResult.OK; // 1 Диалоговое окно возвращает значение <B>ОК</B>.
        private int m_cancel = (int)System.Windows.Forms.DialogResult.Cancel; // 2 Диалоговое окно возвращает значение <B>Отмена</B>.
        private int m_abort = (int)System.Windows.Forms.DialogResult.Abort; // 3 Диалоговое окно возвращает значение <B>Прервать</B>.
        private int m_retry = (int)System.Windows.Forms.DialogResult.Retry; // 4 Диалоговое окно возвращает значение <B>Повторить</B>.
        private int m_ignore = (int)System.Windows.Forms.DialogResult.Ignore; // 5 Диалоговое окно возвращает значение <B>Пропустить</B>.
        private int m_yes = (int)System.Windows.Forms.DialogResult.Yes; // 6 Диалоговое окно возвращает значение <B>Да</B>.
        private int m_no = (int)System.Windows.Forms.DialogResult.No; // 7 Диалоговое окно возвращает значение <B>Нет</B>.

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

        internal ClDialogResult()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Abort));
            _list.Add(ValueFactory.Create(Cancel));
            _list.Add(ValueFactory.Create(Ignore));
            _list.Add(ValueFactory.Create(No));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(OK));
            _list.Add(ValueFactory.Create(Retry));
            _list.Add(ValueFactory.Create(Yes));
        }

        [ContextProperty("Да", "Yes")]
        public int Yes
        {
        	get { return m_yes; }
        }

        [ContextProperty("Нет", "No")]
        public int No
        {
        	get { return m_no; }
        }

        [ContextProperty("ОК", "OK")]
        public int OK
        {
        	get { return m_oK; }
        }

        [ContextProperty("Отмена", "Cancel")]
        public int Cancel
        {
        	get { return m_cancel; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("Повторить", "Retry")]
        public int Retry
        {
        	get { return m_retry; }
        }

        [ContextProperty("Прервать", "Abort")]
        public int Abort
        {
        	get { return m_abort; }
        }

        [ContextProperty("Пропустить", "Ignore")]
        public int Ignore
        {
        	get { return m_ignore; }
        }
    }
}
