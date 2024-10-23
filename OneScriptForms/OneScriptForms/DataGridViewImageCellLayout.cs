using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРазмещениеИзображенияЯчейки", "ClDataGridViewImageCellLayout")]
    public class ClDataGridViewImageCellLayout : AutoContext<ClDataGridViewImageCellLayout>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_notSet = (int)System.Windows.Forms.DataGridViewImageCellLayout.NotSet; // 0 Спецификация расположения не установлена.
        private int m_normal = (int)System.Windows.Forms.DataGridViewImageCellLayout.Normal; // 1 Рисунок отображается по центру с использованием его собственного разрешения.
        private int m_stretch = (int)System.Windows.Forms.DataGridViewImageCellLayout.Stretch; // 2 Рисунок растягивается до такой ширины и высоты, чтобы заполнить содержащую его ячейку.
        private int m_zoom = (int)System.Windows.Forms.DataGridViewImageCellLayout.Zoom; // 3 Рисунок растягивается равномерно, пока он не достигнет ширины и высоты содержащей его ячейки.

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

        public ClDataGridViewImageCellLayout()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Normal));
            _list.Add(ValueFactory.Create(NotSet));
            _list.Add(ValueFactory.Create(Stretch));
            _list.Add(ValueFactory.Create(Zoom));
        }

        [ContextProperty("Масштабировать", "Zoom")]
        public int Zoom
        {
        	get { return m_zoom; }
        }

        [ContextProperty("НеУстановлено", "NotSet")]
        public int NotSet
        {
        	get { return m_notSet; }
        }

        [ContextProperty("Растянуть", "Stretch")]
        public int Stretch
        {
        	get { return m_stretch; }
        }

        [ContextProperty("Стандартное", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }
    }
}
