using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлЗначокВсплывающейПодсказки", "ClToolTipIcon")]
    public class ClToolTipIcon : AutoContext<ClToolTipIcon>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.ToolTipIcon.None; // 0 Нестандартный значок.
        private int m_info = (int)System.Windows.Forms.ToolTipIcon.Info; // 1 Значок сведений.
        private int m_warning = (int)System.Windows.Forms.ToolTipIcon.Warning; // 2 Значок предупреждения.
        private int m_error = (int)System.Windows.Forms.ToolTipIcon.Error; // 3 Значок ошибки.

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
            {1, "Информация"},
            {0, "Отсутствие"},
            {3, "Ошибка"},
            {2, "Предупреждение"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "Info"},
            {0, "None"},
            {3, "Error"},
            {2, "Warning"},
        };

        public ClToolTipIcon()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Error));
            _list.Add(ValueFactory.Create(Info));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Warning));
        }

        [ContextProperty("Информация", "Info")]
        public int Info
        {
            get { return m_info; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return m_none; }
        }

        [ContextProperty("Ошибка", "Error")]
        public int Error
        {
            get { return m_error; }
        }

        [ContextProperty("Предупреждение", "Warning")]
        public int Warning
        {
            get { return m_warning; }
        }
    }
}
