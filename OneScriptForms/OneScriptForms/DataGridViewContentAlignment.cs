using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлВыравниваниеСодержимогоЯчейки", "ClDataGridViewContentAlignment")]
    public class ClDataGridViewContentAlignment : AutoContext<ClDataGridViewContentAlignment>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_notSet = (int)System.Windows.Forms.DataGridViewContentAlignment.NotSet; // 0 Выравнивание не установлено.
        private int m_topLeft = (int)System.Windows.Forms.DataGridViewContentAlignment.TopLeft; // 1 Содержимое выравнивается по верхнему краю в вертикальном направлении и по левому краю ячейки в горизонтальном направлении.
        private int m_topCenter = (int)System.Windows.Forms.DataGridViewContentAlignment.TopCenter; // 2 Содержимое выравнивается по верхнему краю в вертикальном направлении и по центру ячейки в горизонтальном направлении.
        private int m_topRight = (int)System.Windows.Forms.DataGridViewContentAlignment.TopRight; // 4 Содержимое выравнивается по верхнему краю в вертикальном направлении и по правому краю ячейки в горизонтальном направлении.
        private int m_middleLeft = (int)System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft; // 16 Содержимое выравнивается по центру в вертикальном направлении и по левому краю ячейки в горизонтальном направлении.
        private int m_middleCenter = (int)System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; // 32 Содержимое выравнивается по центру ячейки как по вертикали, так и по горизонтали.
        private int m_middleRight = (int)System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; // 64 Содержимое выравнивается по центру в вертикальном направлении и по правому краю ячейки в горизонтальном направлении.
        private int m_bottomLeft = (int)System.Windows.Forms.DataGridViewContentAlignment.BottomLeft; // 256 Содержимое выравнивается по нижнему краю в вертикальном направлении и по левому краю ячейки в горизонтальном направлении.
        private int m_bottomCenter = (int)System.Windows.Forms.DataGridViewContentAlignment.BottomCenter; // 512 Содержимое выравнивается по нижнему краю в вертикальном направлении и по центру ячейки в горизонтальном направлении.
        private int m_bottomRight = (int)System.Windows.Forms.DataGridViewContentAlignment.BottomRight; // 1024 Содержимое выравнивается по нижнему краю в вертикальном направлении и по правому краю ячейки в горизонтальном направлении.

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
            {1, "ВерхЛево"},
            {4, "ВерхПраво"},
            {2, "ВерхЦентр"},
            {0, "НеУстановлено"},
            {256, "НизЛево"},
            {1024, "НизПраво"},
            {512, "НизЦентр"},
            {16, "СерединаЛево"},
            {64, "СерединаПраво"},
            {32, "СерединаЦентр"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "TopLeft"},
            {4, "TopRight"},
            {2, "TopCenter"},
            {0, "NotSet"},
            {256, "BottomLeft"},
            {1024, "BottomRight"},
            {512, "BottomCenter"},
            {16, "MiddleLeft"},
            {64, "MiddleRight"},
            {32, "MiddleCenter"},
        };

        public ClDataGridViewContentAlignment()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(BottomCenter));
            _list.Add(ValueFactory.Create(BottomLeft));
            _list.Add(ValueFactory.Create(BottomRight));
            _list.Add(ValueFactory.Create(MiddleCenter));
            _list.Add(ValueFactory.Create(MiddleLeft));
            _list.Add(ValueFactory.Create(MiddleRight));
            _list.Add(ValueFactory.Create(NotSet));
            _list.Add(ValueFactory.Create(TopCenter));
            _list.Add(ValueFactory.Create(TopLeft));
            _list.Add(ValueFactory.Create(TopRight));
        }

        [ContextProperty("ВерхЛево", "TopLeft")]
        public int TopLeft
        {
            get { return m_topLeft; }
        }

        [ContextProperty("ВерхПраво", "TopRight")]
        public int TopRight
        {
            get { return m_topRight; }
        }

        [ContextProperty("ВерхЦентр", "TopCenter")]
        public int TopCenter
        {
            get { return m_topCenter; }
        }

        [ContextProperty("НеУстановлено", "NotSet")]
        public int NotSet
        {
            get { return m_notSet; }
        }

        [ContextProperty("НизЛево", "BottomLeft")]
        public int BottomLeft
        {
            get { return m_bottomLeft; }
        }

        [ContextProperty("НизПраво", "BottomRight")]
        public int BottomRight
        {
            get { return m_bottomRight; }
        }

        [ContextProperty("НизЦентр", "BottomCenter")]
        public int BottomCenter
        {
            get { return m_bottomCenter; }
        }

        [ContextProperty("СерединаЛево", "MiddleLeft")]
        public int MiddleLeft
        {
            get { return m_middleLeft; }
        }

        [ContextProperty("СерединаПраво", "MiddleRight")]
        public int MiddleRight
        {
            get { return m_middleRight; }
        }

        [ContextProperty("СерединаЦентр", "MiddleCenter")]
        public int MiddleCenter
        {
            get { return m_middleCenter; }
        }
    }
}
