using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлФорматПикселей", "ClPixelFormat")]
    public class ClPixelFormat : AutoContext<ClPixelFormat>
    {
        private int m_dontCare = (int)System.Drawing.Imaging.PixelFormat.DontCare; // 0 Формат пикселей не указан.
        private int m_undefined = (int)System.Drawing.Imaging.PixelFormat.Undefined; // 0 Формат пикселей не определен.
        private int m_max = (int)System.Drawing.Imaging.PixelFormat.Max; // 15 Максимальное значение данного перечисления.
        private int m_indexed = (int)System.Drawing.Imaging.PixelFormat.Indexed; // 65536 Данные о пикселях содержат значения индексированных цветов, то есть значение является индексом цвета в системной таблице цветов, в отличие от отдельных значений цветов.
        private int m_gdi = (int)System.Drawing.Imaging.PixelFormat.Gdi; // 131072 Данные о пикселях содержат цвета GDI.
        private int m_format16bppRgb555 = (int)System.Drawing.Imaging.PixelFormat.Format16bppRgb555; // 135173 Указывает, что форматом отводится 16 бит на пиксель: по 5 бит на красный, зеленый и синий каналы. Оставшийся бит не используется.
        private int m_format16bppRgb565 = (int)System.Drawing.Imaging.PixelFormat.Format16bppRgb565; // 135174 Указывает, что форматом отводится 16 бит на пиксель: по 5 бит на красный и синий канал, 6 бит на зеленый канал.
        private int m_format24bppRgb = (int)System.Drawing.Imaging.PixelFormat.Format24bppRgb; // 137224 Указывает, что форматом отводится 24 бита на пиксель: по 8 бит на красный, зеленый и синий каналы.
        private int m_format32bppRgb = (int)System.Drawing.Imaging.PixelFormat.Format32bppRgb; // 139273 Указывает, что форматом отводится 32 бита на пиксель: по 8 бит на красный, зеленый и синий каналы. Оставшиеся 8 бит не используются.
        private int m_format1bppIndexed = (int)System.Drawing.Imaging.PixelFormat.Format1bppIndexed; // 196865 Указывает, что форматом отводится 1 бит на пиксель и используется индексированный цвет. Следовательно, таблица цветов содержит два цвета.
        private int m_format4bppIndexed = (int)System.Drawing.Imaging.PixelFormat.Format4bppIndexed; // 197634 Указывает, что форматом отводится 4 бита на пиксель и цвета индексированы.
        private int m_format8bppIndexed = (int)System.Drawing.Imaging.PixelFormat.Format8bppIndexed; // 198659 Указывает, что форматом отводится 8 бит на пиксель и цвета индексированы. Следовательно, таблица цветов содержит 256 цветов.
        private int m_alpha = (int)System.Drawing.Imaging.PixelFormat.Alpha; // 262144 Данные о пикселях содержат значения альфа, которые не умножаются в обратном порядке (начиная со старшего разряда).
        private int m_format16bppArgb1555 = (int)System.Drawing.Imaging.PixelFormat.Format16bppArgb1555; // 397319 Формат пикселей – 16 бит на точку. Информация о цвете определяет 32 768 оттенков цвета, где 5 бит отведены на красный канал, 5 бит на зеленый, 5 бит на синий и 1 бит на альфа-канал.
        private int m_pAlpha = (int)System.Drawing.Imaging.PixelFormat.PAlpha; // 524288 Формат пикселей содержит значения альфа, умноженные в обратном порядке.
        private int m_format32bppPArgb = (int)System.Drawing.Imaging.PixelFormat.Format32bppPArgb; // 925707 Указывает, что форматом отводится 32 бита на пиксель: по 8 бит на красный, зеленый и синий каналы, а также альфа-канал. Красный, зеленый и синий каналы умножаются в обратном порядке с учетом альфа-канала.
        private int m_extended = (int)System.Drawing.Imaging.PixelFormat.Extended; // 1048576 Зарезервировано.
        private int m_format16bppGrayScale = (int)System.Drawing.Imaging.PixelFormat.Format16bppGrayScale; // 1052676 Формат пикселей – 16 бит на точку. Данные цвета предусматривают 65 536 оттенков серого.
        private int m_format48bppRgb = (int)System.Drawing.Imaging.PixelFormat.Format48bppRgb; // 1060876 Указывает, что форматом отводится 48 бит на пиксель: по 16 бит на красный, зеленый и синий каналы.
        private int m_format64bppPArgb = (int)System.Drawing.Imaging.PixelFormat.Format64bppPArgb; // 1851406 Указывает, что форматом отводится 64 бита на пиксель: по 16 бит на красный, зеленый и синий каналы, а также альфа-канал. Красный, зеленый и синий каналы умножаются в обратном порядке с учетом альфа-канала.
        private int m_canonical = (int)System.Drawing.Imaging.PixelFormat.Canonical; // 2097152 В формате пикселей по умолчанию на точку приходится 32 бита. Этот формат задает 24-битовую глубину цвета и 8-битовый альфа-канал.
        private int m_format32bppArgb = (int)System.Drawing.Imaging.PixelFormat.Format32bppArgb; // 2498570 Указывает, что форматом отводится 32 бита на пиксель: по 8 бит на красный, зеленый и синий каналы, а также альфа-канал.
        private int m_format64bppArgb = (int)System.Drawing.Imaging.PixelFormat.Format64bppArgb; // 3424269 Указывает, что форматом отводится 64 бита на пиксель: по 16 бит на красный, зеленый и синий каналы, а также альфа-канал.

        [ContextProperty("Альфа", "Alpha")]
        public int Alpha
        {
        	get { return m_alpha; }
        }

        [ContextProperty("Бит16АКЗС1555", "Format16bppArgb1555")]
        public int Format16bppArgb1555
        {
        	get { return m_format16bppArgb1555; }
        }

        [ContextProperty("Бит16КЗС555", "Format16bppRgb555")]
        public int Format16bppRgb555
        {
        	get { return m_format16bppRgb555; }
        }

        [ContextProperty("Бит16КЗС565", "Format16bppRgb565")]
        public int Format16bppRgb565
        {
        	get { return m_format16bppRgb565; }
        }

        [ContextProperty("Бит16ОттенкиСерого", "Format16bppGrayScale")]
        public int Format16bppGrayScale
        {
        	get { return m_format16bppGrayScale; }
        }

        [ContextProperty("Бит1Индексированный", "Format1bppIndexed")]
        public int Format1bppIndexed
        {
        	get { return m_format1bppIndexed; }
        }

        [ContextProperty("Бит24КЗС", "Format24bppRgb")]
        public int Format24bppRgb
        {
        	get { return m_format24bppRgb; }
        }

        [ContextProperty("Бит32АКЗС", "Format32bppArgb")]
        public int Format32bppArgb
        {
        	get { return m_format32bppArgb; }
        }

        [ContextProperty("Бит32АКЗСОбратно", "Format32bppPArgb")]
        public int Format32bppPArgb
        {
        	get { return m_format32bppPArgb; }
        }

        [ContextProperty("Бит32КЗС", "Format32bppRgb")]
        public int Format32bppRgb
        {
        	get { return m_format32bppRgb; }
        }

        [ContextProperty("Бит48КЗС", "Format48bppRgb")]
        public int Format48bppRgb
        {
        	get { return m_format48bppRgb; }
        }

        [ContextProperty("Бит4Индексированный", "Format4bppIndexed")]
        public int Format4bppIndexed
        {
        	get { return m_format4bppIndexed; }
        }

        [ContextProperty("Бит64АКЗС", "Format64bppArgb")]
        public int Format64bppArgb
        {
        	get { return m_format64bppArgb; }
        }

        [ContextProperty("Бит64АКЗСОбратно", "Format64bppPArgb")]
        public int Format64bppPArgb
        {
        	get { return m_format64bppPArgb; }
        }

        [ContextProperty("Бит8Индексированный", "Format8bppIndexed")]
        public int Format8bppIndexed
        {
        	get { return m_format8bppIndexed; }
        }

        [ContextProperty("Индексированный", "Indexed")]
        public int Indexed
        {
        	get { return m_indexed; }
        }

        [ContextProperty("Канонический", "Canonical")]
        public int Canonical
        {
        	get { return m_canonical; }
        }

        [ContextProperty("Максимум", "Max")]
        public int Max
        {
        	get { return m_max; }
        }

        [ContextProperty("Неопределенный", "Undefined")]
        public int Undefined
        {
        	get { return m_undefined; }
        }

        [ContextProperty("НеУказан", "DontCare")]
        public int DontCare
        {
        	get { return m_dontCare; }
        }

        [ContextProperty("ОбратноАльфа", "PAlpha")]
        public int PAlpha
        {
        	get { return m_pAlpha; }
        }

        [ContextProperty("Расширенный", "Extended")]
        public int Extended
        {
        	get { return m_extended; }
        }

        [ContextProperty("ЦветаGDI", "Gdi")]
        public int Gdi
        {
        	get { return m_gdi; }
        }

    }
}
