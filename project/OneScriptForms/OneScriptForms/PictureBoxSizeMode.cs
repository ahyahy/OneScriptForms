using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлРежимРазмераПоляКартинки", "ClPictureBoxSizeMode")]
    public class ClPictureBoxSizeMode : AutoContext<ClPictureBoxSizeMode>
    {
        private int m_normal = (int)System.Windows.Forms.PictureBoxSizeMode.Normal; // 0 Изображение размещается в левом верхнем углу <B>ПолеКартинки&nbsp;(PictureBox)</B>. Изображение обрезается, если его размер превышает <B>ПолеКартинки&nbsp;(PictureBox)</B>.
        private int m_stretchImage = (int)System.Windows.Forms.PictureBoxSizeMode.StretchImage; // 1 Изображение в <B>ПолеКартинки&nbsp;(PictureBox)</B> растягивается или сжимается в соответствии с размером <B>ПолеКартинки&nbsp;(PictureBox)</B>.
        private int m_autoSize = (int)System.Windows.Forms.PictureBoxSizeMode.AutoSize; // 2 Размер <B>ПолеКартинки&nbsp;(PictureBox)</B> изменяется под размер изображения, которое он содержит.
        private int m_centerImage = (int)System.Windows.Forms.PictureBoxSizeMode.CenterImage; // 3 Если <B>ПолеКартинки&nbsp;(PictureBox)</B> больше, чем изображение, изображение отображается в центре. Если изображение больше, чем <B>ПолеКартинки&nbsp;(PictureBox)</B>, изображение размещается в центре <B>ПолеКартинки&nbsp;(PictureBox)</B> и внешние края изображения обрезаются.

        [ContextProperty("АвтоРазмер", "AutoSize")]
        public int AutoSize
        {
        	get { return m_autoSize; }
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
