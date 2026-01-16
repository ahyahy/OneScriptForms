using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлФорматПикселей", "ClPixelFormat")]
    public class ClPixelFormat : AutoContext<ClPixelFormat>, ICollectionContext, IEnumerable<IValue>
    {
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
            {262144, "Альфа"},
            {397319, "Бит16АКЗС1555"},
            {135173, "Бит16КЗС555"},
            {135174, "Бит16КЗС565"},
            {1052676, "Бит16ОттенкиСерого"},
            {196865, "Бит1Индексированный"},
            {137224, "Бит24КЗС"},
            {2498570, "Бит32АКЗС"},
            {925707, "Бит32АКЗСОбратно"},
            {139273, "Бит32КЗС"},
            {1060876, "Бит48КЗС"},
            {197634, "Бит4Индексированный"},
            {3424269, "Бит64АКЗС"},
            {1851406, "Бит64АКЗСОбратно"},
            {198659, "Бит8Индексированный"},
            {65536, "Индексированный"},
            {2097152, "Канонический"},
            {15, "Максимум"},
            {0, "Неопределенный"},
            {524288, "ОбратноАльфа"},
            {1048576, "Расширенный"},
            {131072, "ЦветаGDI"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {262144, "Alpha"},
            {397319, "Format16bppArgb1555"},
            {135173, "Format16bppRgb555"},
            {135174, "Format16bppRgb565"},
            {1052676, "Format16bppGrayScale"},
            {196865, "Format1bppIndexed"},
            {137224, "Format24bppRgb"},
            {2498570, "Format32bppArgb"},
            {925707, "Format32bppPArgb"},
            {139273, "Format32bppRgb"},
            {1060876, "Format48bppRgb"},
            {197634, "Format4bppIndexed"},
            {3424269, "Format64bppArgb"},
            {1851406, "Format64bppPArgb"},
            {198659, "Format8bppIndexed"},
            {65536, "Indexed"},
            {2097152, "Canonical"},
            {15, "Max"},
            {0, "Undefined"},
            {524288, "PAlpha"},
            {1048576, "Extended"},
            {131072, "Gdi"},
        };

        public ClPixelFormat()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Alpha));
            _list.Add(ValueFactory.Create(Canonical));
            _list.Add(ValueFactory.Create(Extended));
            _list.Add(ValueFactory.Create(Format16bppArgb1555));
            _list.Add(ValueFactory.Create(Format16bppGrayScale));
            _list.Add(ValueFactory.Create(Format16bppRgb555));
            _list.Add(ValueFactory.Create(Format16bppRgb565));
            _list.Add(ValueFactory.Create(Format1bppIndexed));
            _list.Add(ValueFactory.Create(Format24bppRgb));
            _list.Add(ValueFactory.Create(Format32bppArgb));
            _list.Add(ValueFactory.Create(Format32bppPArgb));
            _list.Add(ValueFactory.Create(Format32bppRgb));
            _list.Add(ValueFactory.Create(Format48bppRgb));
            _list.Add(ValueFactory.Create(Format4bppIndexed));
            _list.Add(ValueFactory.Create(Format64bppArgb));
            _list.Add(ValueFactory.Create(Format64bppPArgb));
            _list.Add(ValueFactory.Create(Format8bppIndexed));
            _list.Add(ValueFactory.Create(Gdi));
            _list.Add(ValueFactory.Create(Indexed));
            _list.Add(ValueFactory.Create(Max));
            _list.Add(ValueFactory.Create(PAlpha));
            _list.Add(ValueFactory.Create(Undefined));
        }

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
