using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлФорматМаски", "ClMaskFormat")]
    public class ClMaskFormat : AutoContext<ClMaskFormat>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_excludePromptAndLiterals = (int)System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals; // 0 Возвращать только текст, введенный пользователем.
        private int m_includePrompt = (int)System.Windows.Forms.MaskFormat.IncludePrompt; // 1 Возвращать текст, введенный пользователем, а также экземпляры символа приглашения.
        private int m_includeLiterals = (int)System.Windows.Forms.MaskFormat.IncludeLiterals; // 2 Возвращать текст, введенный пользователем, а также символьные литералы, определенные в маске.
        private int m_includePromptAndLiterals = (int)System.Windows.Forms.MaskFormat.IncludePromptAndLiterals; // 3 Возвращать текст, введенный пользователем, а также символьные литералы, определенные в маске, и экземпляры символа приглашения.

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

        internal ClMaskFormat()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(ExcludePromptAndLiterals));
            _list.Add(ValueFactory.Create(IncludeLiterals));
            _list.Add(ValueFactory.Create(IncludePrompt));
            _list.Add(ValueFactory.Create(IncludePromptAndLiterals));
        }

        [ContextProperty("ВключитьЛитералы", "IncludeLiterals")]
        public int IncludeLiterals
        {
        	get { return m_includeLiterals; }
        }

        [ContextProperty("ВключитьПриглашение", "IncludePrompt")]
        public int IncludePrompt
        {
        	get { return m_includePrompt; }
        }

        [ContextProperty("ВключитьПриглашениеИЛитералы", "IncludePromptAndLiterals")]
        public int IncludePromptAndLiterals
        {
        	get { return m_includePromptAndLiterals; }
        }

        [ContextProperty("ИсключитьПриглашениеИЛитералы", "ExcludePromptAndLiterals")]
        public int ExcludePromptAndLiterals
        {
        	get { return m_excludePromptAndLiterals; }
        }
    }
}
