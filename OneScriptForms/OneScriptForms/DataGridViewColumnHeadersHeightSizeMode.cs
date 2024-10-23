using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРежимВысотыЗаголовковКолонок", "ClDataGridViewColumnHeadersHeightSizeMode")]
    public class ClDataGridViewColumnHeadersHeightSizeMode : AutoContext<ClDataGridViewColumnHeadersHeightSizeMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_enableResizing = (int)System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // 0 Пользователи могут настраивать высоту заголовка колонки с помощью мыши.
        private int m_disableResizing = (int)System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing; // 1 Пользователи не могут изменить высоту заголовка колонки с помощью мыши.
        private int m_autoSize = (int)System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize; // 2 Высота заголовка колонки настраивается так, чтобы она соответствовала содержимому всех ячеек заголовков колонок.

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

        public ClDataGridViewColumnHeadersHeightSizeMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(AutoSize));
            _list.Add(ValueFactory.Create(DisableResizing));
            _list.Add(ValueFactory.Create(EnableResizing));
        }

        [ContextProperty("АвтоРазмер", "AutoSize")]
        public int AutoSize
        {
        	get { return m_autoSize; }
        }

        [ContextProperty("Включить", "EnableResizing")]
        public int EnableResizing
        {
        	get { return m_enableResizing; }
        }

        [ContextProperty("Отключить", "DisableResizing")]
        public int DisableResizing
        {
        	get { return m_disableResizing; }
        }
    }
}
