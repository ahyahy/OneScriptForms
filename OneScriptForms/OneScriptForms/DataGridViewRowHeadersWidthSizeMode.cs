using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлРежимШириныЗаголовковСтрок", "ClDataGridViewRowHeadersWidthSizeMode")]
    public class ClDataGridViewRowHeadersWidthSizeMode : AutoContext<ClDataGridViewRowHeadersWidthSizeMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_enableResizing = (int)System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing; // 0 Пользователи могут изменять ширину заголовка колонки с помощью мыши.
        private int m_disableResizing = (int)System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing; // 1 Пользователи не могут изменять ширину заголовка колонки с помощью мыши.
        private int m_autoSizeToAllHeaders = (int)System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders; // 2 Ширина заголовка строки изменяется, чтобы вместить содержимое всех ячеек заголовка строки.
        private int m_autoSizeToDisplayedHeaders = (int)System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; // 3 Ширина заголовка строки изменяется, чтобы вместить содержимое всех отображенных ячеек заголовка строки.
        private int m_autoSizeToFirstHeader = (int)System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader; // 4 Ширина заголовка строки изменяется, чтобы вместить содержимое первого заголовка строки.

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

        [ContextProperty("Количество", "Count")]
        public int CountProp
        {
            get { return _list.Count; }
        }

        [ContextMethod("Получить", "Get")]
        public IValue Get(int index)
        {
            return _list[index];
        }

        [ContextMethod("Имя")]
        public string NameRu(decimal p1)
        {
            return namesRu.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        [ContextMethod("Name")]
        public string NameEn(decimal p1)
        {
            return namesEn.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        private static readonly Dictionary<decimal, string> namesRu = new Dictionary<decimal, string>
        {
            {0, "Включить"},
            {2, "ДляВсех"},
            {3, "ДляОтображаемых"},
            {4, "ДляПервого"},
            {1, "Отключить"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {0, "EnableResizing"},
            {2, "AutoSizeToAllHeaders"},
            {3, "AutoSizeToDisplayedHeaders"},
            {4, "AutoSizeToFirstHeader"},
            {1, "DisableResizing"},
        };

        public ClDataGridViewRowHeadersWidthSizeMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(AutoSizeToAllHeaders));
            _list.Add(ValueFactory.Create(AutoSizeToDisplayedHeaders));
            _list.Add(ValueFactory.Create(AutoSizeToFirstHeader));
            _list.Add(ValueFactory.Create(DisableResizing));
            _list.Add(ValueFactory.Create(EnableResizing));
        }

        [ContextProperty("Включить", "EnableResizing")]
        public int EnableResizing
        {
            get { return m_enableResizing; }
        }

        [ContextProperty("ДляВсех", "AutoSizeToAllHeaders")]
        public int AutoSizeToAllHeaders
        {
            get { return m_autoSizeToAllHeaders; }
        }

        [ContextProperty("ДляОтображаемых", "AutoSizeToDisplayedHeaders")]
        public int AutoSizeToDisplayedHeaders
        {
            get { return m_autoSizeToDisplayedHeaders; }
        }

        [ContextProperty("ДляПервого", "AutoSizeToFirstHeader")]
        public int AutoSizeToFirstHeader
        {
            get { return m_autoSizeToFirstHeader; }
        }

        [ContextProperty("Отключить", "DisableResizing")]
        public int DisableResizing
        {
            get { return m_disableResizing; }
        }
    }
}
