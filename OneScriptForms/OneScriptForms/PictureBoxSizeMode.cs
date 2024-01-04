using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРежимРазмераПоляКартинки", "ClPictureBoxSizeMode")]
    public class ClPictureBoxSizeMode : AutoContext<ClPictureBoxSizeMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_normal = (int)System.Windows.Forms.PictureBoxSizeMode.Normal; // 0 Изображение размещается в левом верхнем углу <B>ПолеКартинки&nbsp;(PictureBox)</B>. Изображение обрезается, если его размер превышает <B>ПолеКартинки&nbsp;(PictureBox)</B>.
        private int m_stretchImage = (int)System.Windows.Forms.PictureBoxSizeMode.StretchImage; // 1 Изображение в <B>ПолеКартинки&nbsp;(PictureBox)</B> растягивается или сжимается в соответствии с размером <B>ПолеКартинки&nbsp;(PictureBox)</B>.
        private int m_autoSize = (int)System.Windows.Forms.PictureBoxSizeMode.AutoSize; // 2 Размер <B>ПолеКартинки&nbsp;(PictureBox)</B> изменяется под размер изображения, которое он содержит.
        private int m_centerImage = (int)System.Windows.Forms.PictureBoxSizeMode.CenterImage; // 3 Если <B>ПолеКартинки&nbsp;(PictureBox)</B> больше, чем изображение, изображение отображается в центре. Если изображение больше, чем <B>ПолеКартинки&nbsp;(PictureBox)</B>, изображение размещается в центре <B>ПолеКартинки&nbsp;(PictureBox)</B> и внешние края изображения обрезаются.
        private int m_zoom = (int)System.Windows.Forms.PictureBoxSizeMode.Zoom; // 4 Размер изображения увеличивается или уменьшается, сохраняя пропорции.

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

        internal ClPictureBoxSizeMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(AutoSize));
            _list.Add(ValueFactory.Create(CenterImage));
            _list.Add(ValueFactory.Create(Normal));
            _list.Add(ValueFactory.Create(StretchImage));
            _list.Add(ValueFactory.Create(Zoom));
        }

        [ContextProperty("АвтоРазмер", "AutoSize")]
        public int AutoSize
        {
        	get { return m_autoSize; }
        }

        [ContextProperty("Пропорционально", "Zoom")]
        public int Zoom
        {
        	get { return m_zoom; }
        }

        [ContextProperty("РастянутьИзображение", "StretchImage")]
        public int StretchImage
        {
        	get { return m_stretchImage; }
        }

        [ContextProperty("Стандартный", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }

        [ContextProperty("ЦентрИзображения", "CenterImage")]
        public int CenterImage
        {
        	get { return m_centerImage; }
        }
    }
}
