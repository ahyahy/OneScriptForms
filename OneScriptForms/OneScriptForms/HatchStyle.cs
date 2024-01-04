using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСтильШтриховки", "ClHatchStyle")]
    public class ClHatchStyle : AutoContext<ClHatchStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_min = (int)System.Drawing.Drawing2D.HatchStyle.Min; // 0 Стиль штриховки <B>Горизонтальная&nbsp;(Horizontal)</B>.
        private int m_horizontal = (int)System.Drawing.Drawing2D.HatchStyle.Horizontal; // 0 Горизонтальные линии.
        private int m_vertical = (int)System.Drawing.Drawing2D.HatchStyle.Vertical; // 1 Штриховка в виде вертикальных линий.
        private int m_forwardDiagonal = (int)System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal; // 2 Линии по диагонали из верхнего левого угла к нижнему правому.
        private int m_backwardDiagonal = (int)System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal; // 3 Линии по диагонали от правого верхнего угла к левому нижнему углу.
        private int m_largeGrid = (int)System.Drawing.Drawing2D.HatchStyle.LargeGrid; // 4 Пересекающиеся горизонтальные и вертикальные линии.
        private int m_max = (int)System.Drawing.Drawing2D.HatchStyle.Max; // 4 Стиль штриховки <B>СплошнойАлмаз&nbsp;(SolidDiamond)</B>.
        private int m_cross = (int)System.Drawing.Drawing2D.HatchStyle.Cross; // 4 Пересекающиеся горизонтальные и вертикальные линии.
        private int m_diagonalCross = (int)System.Drawing.Drawing2D.HatchStyle.DiagonalCross; // 5 Перекрещивающиеся диагональные линии.
        private int m_percent05 = (int)System.Drawing.Drawing2D.HatchStyle.Percent05; // 6 Штриховка 5 процентов. Цвет переднего плана к цвету фона составляет 5:95.
        private int m_percent10 = (int)System.Drawing.Drawing2D.HatchStyle.Percent10; // 7 Штриховка 10 процентов. Цвет переднего плана к цвету фона составляет 10:90.
        private int m_percent20 = (int)System.Drawing.Drawing2D.HatchStyle.Percent20; // 8 20-процентная штриховка. Цвет переднего плана к цвету фона составляет 20:80.
        private int m_percent25 = (int)System.Drawing.Drawing2D.HatchStyle.Percent25; // 9 25-процентная штриховка. Цвет переднего плана к цвету фона составляет 25:75.
        private int m_percent30 = (int)System.Drawing.Drawing2D.HatchStyle.Percent30; // 10 Штриховка 30 процентов. Цвет переднего плана к цвету фона составляет 30:70.
        private int m_percent40 = (int)System.Drawing.Drawing2D.HatchStyle.Percent40; // 11 Штриховка 40 процентов. Цвет переднего плана к цвету фона составляет 40:60.
        private int m_percent50 = (int)System.Drawing.Drawing2D.HatchStyle.Percent50; // 12 Штриховка 50 процентов. Цвет переднего плана к цвету фона составляет 50:50.
        private int m_percent60 = (int)System.Drawing.Drawing2D.HatchStyle.Percent60; // 13 Штриховка 60 процентов. Цвет переднего плана к цвету фона составляет 60:40.
        private int m_percent70 = (int)System.Drawing.Drawing2D.HatchStyle.Percent70; // 14 Штриховка 70 процентов. Цвет переднего плана к цвету фона составляет 70:30.
        private int m_percent75 = (int)System.Drawing.Drawing2D.HatchStyle.Percent75; // 15 Штриховка 75 процентов. Цвет переднего плана к цвету фона составляет 75:25.
        private int m_percent80 = (int)System.Drawing.Drawing2D.HatchStyle.Percent80; // 16 Штриховка 80 процентов. Цвет переднего плана к цвету фона составляет 80:100.
        private int m_percent90 = (int)System.Drawing.Drawing2D.HatchStyle.Percent90; // 17 Штриховка 90 процентов. Цвет переднего плана к цвету фона составляет 90:10.
        private int m_lightDownwardDiagonal = (int)System.Drawing.Drawing2D.HatchStyle.LightDownwardDiagonal; // 18 Диагональные линии, которые наклонены вправо от верхних точек к нижним точкам и расположенные на 50 процентов ближе друг к другу, чем <B>ПрямаяДиагональная&nbsp;(ForwardDiagonal)</B> штриховка, но не сглаженые.
        private int m_lightUpwardDiagonal = (int)System.Drawing.Drawing2D.HatchStyle.LightUpwardDiagonal; // 19 Диагональные линии, которые наклоны влево от верхних точек к нижним точкам и расположенные на 50 процентов ближе друг к другу, чем <B>ОбратнаяДиагональная&nbsp;(BackwardDiagonal)</B> штриховка, но они не сглаженые.
        private int m_darkDownwardDiagonal = (int)System.Drawing.Drawing2D.HatchStyle.DarkDownwardDiagonal; // 20 Диагональные линии с уклоном вправо от верхних точек к нижним точкам, расположенные на 50% ближе друг к другу, и вдвое шире, чем <B>ПрямаяДиагональная&nbsp;(ForwardDiagonal)</B> штриховка. Шаблон штриховки не сглажен.
        private int m_darkUpwardDiagonal = (int)System.Drawing.Drawing2D.HatchStyle.DarkUpwardDiagonal; // 21 Диагональные линии с уклоном влево от верхних точек к нижним точкам, расположенные на 50 процентов ближе друг к другу, чем <B>ОбратнаяДиагональная&nbsp;(BackwardDiagonal)</B> штриховка, и вдвое шире, но линии не сглаженые.
        private int m_wideDownwardDiagonal = (int)System.Drawing.Drawing2D.HatchStyle.WideDownwardDiagonal; // 22 Диагональные линии с уклоном вправо от верхних точек к нижним, расположенные с такими же интервалами как в штриховке <B>ПрямаяДиагональная&nbsp;(ForwardDiagonal)</B>, и втрое шире, но не сглаженые.
        private int m_wideUpwardDiagonal = (int)System.Drawing.Drawing2D.HatchStyle.WideUpwardDiagonal; // 23 Диагональные линии с уклоном влево от верхних точек к нижним, расположенные с такими же интервалами как при штриховке <B>ОбратнаяДиагональная&nbsp;(BackwardDiagonal)</B>, и втрое шире, но не сглаженые.
        private int m_lightVertical = (int)System.Drawing.Drawing2D.HatchStyle.LightVertical; // 24 Вертикальные линии, расположенные на 50 процентов ближе друг к другу, чем <B>Вертикальная&nbsp;(Vertical)</B> штриховка.
        private int m_lightHorizontal = (int)System.Drawing.Drawing2D.HatchStyle.LightHorizontal; // 25 Горизонтальные линии, расположенные на 50 процентов ближе друг к другу, чем <B>Горизонтальная&nbsp;(Horizontal)</B> штриховка.
        private int m_narrowVertical = (int)System.Drawing.Drawing2D.HatchStyle.NarrowVertical; // 26 Вертикальные линии, расположенные на 75 процентов ближе друг к другу, чем при штриховке <B>Вертикальная&nbsp;(Vertical)</B> (или на 25 процентов ближе друг к другу, чем при штриховке <B>СветлаяВертикальная&nbsp;(LightVertical)</B>).
        private int m_narrowHorizontal = (int)System.Drawing.Drawing2D.HatchStyle.NarrowHorizontal; // 27 Горизонтальные линии, расположенные на 75 процентов ближе друг к другу, чем при штриховке <B>Горизонтальная&nbsp;(Horizontal)</B>  (или на 25 процентов ближе друг к другу, чем при штриховке <B>СветлаяГоризонтальная&nbsp;(LightHorizontal)</B>).
        private int m_darkVertical = (int)System.Drawing.Drawing2D.HatchStyle.DarkVertical; // 28 Вертикальные линии, расположенные на 50 процентов ближе друг к другу, чем <B>Вертикальная&nbsp;(Vertical)</B> штриховка, и линии вдвое шире.
        private int m_darkHorizontal = (int)System.Drawing.Drawing2D.HatchStyle.DarkHorizontal; // 29 Горизонтальные линии, расположенные на 50 процентов ближе друг к другу, и вдвое шире чем <B>Горизонтальная&nbsp;(Horizontal)</B> штриховка.
        private int m_dashedDownwardDiagonal = (int)System.Drawing.Drawing2D.HatchStyle.DashedDownwardDiagonal; // 30 Пунктирные диагональные линии с уклоном вправо от верхних точек к нижним точкам.
        private int m_dashedUpwardDiagonal = (int)System.Drawing.Drawing2D.HatchStyle.DashedUpwardDiagonal; // 31 Пунктирные диагональные линии с уклоном влево от верхних точек к нижним точкам.
        private int m_dashedHorizontal = (int)System.Drawing.Drawing2D.HatchStyle.DashedHorizontal; // 32 Пунктирные горизонтальные линии.
        private int m_dashedVertical = (int)System.Drawing.Drawing2D.HatchStyle.DashedVertical; // 33 Пунктирные вертикальные линии.
        private int m_smallConfetti = (int)System.Drawing.Drawing2D.HatchStyle.SmallConfetti; // 34 Штриховка, выглядящая как конфетти.
        private int m_largeConfetti = (int)System.Drawing.Drawing2D.HatchStyle.LargeConfetti; // 35 Штриховка, выглядящая как штриховка <B>МаленькоеКонфетти&nbsp;(SmallConfetti)</B>, но большая по размеру.
        private int m_zigZag = (int)System.Drawing.Drawing2D.HatchStyle.ZigZag; // 36 Горизонтальные линии, состоящие из зигзагов.
        private int m_wave = (int)System.Drawing.Drawing2D.HatchStyle.Wave; // 37 Горизонтальные линии, состоящие из тильд.
        private int m_diagonalBrick = (int)System.Drawing.Drawing2D.HatchStyle.DiagonalBrick; // 38 Штриховка, имеющая вид слоев кирпичей с уклоном влево от верхних точек к нижним точкам.
        private int m_horizontalBrick = (int)System.Drawing.Drawing2D.HatchStyle.HorizontalBrick; // 39 Горизонтальные слои блоков.
        private int m_weave = (int)System.Drawing.Drawing2D.HatchStyle.Weave; // 40 Штриховка, выглядящая как ткань.
        private int m_plaid = (int)System.Drawing.Drawing2D.HatchStyle.Plaid; // 41 Штриховка, выглядящая как материал шотландка.
        private int m_divot = (int)System.Drawing.Drawing2D.HatchStyle.Divot; // 42 Штриховка, выглядящая как дерн.
        private int m_dottedGrid = (int)System.Drawing.Drawing2D.HatchStyle.DottedGrid; // 43 Горизонтальные и вертикальные пересекающиеся линии, каждая из которых состоит из точек.
        private int m_dottedDiamond = (int)System.Drawing.Drawing2D.HatchStyle.DottedDiamond; // 44 Прямые и обратные пересекающиеся диагональные линии, каждая из которых состоит из точек.
        private int m_shingle = (int)System.Drawing.Drawing2D.HatchStyle.Shingle; // 45 Штриховка, которая имеет вид диагональных слоев гальки с уклоном вправо от верхних точек к нижним точкам.
        private int m_trellis = (int)System.Drawing.Drawing2D.HatchStyle.Trellis; // 46 Штриховка, имеющая вид сетки.
        private int m_sphere = (int)System.Drawing.Drawing2D.HatchStyle.Sphere; // 47 Штриховка, выглядящая как шары, расположенные рядом друг с другом.
        private int m_smallGrid = (int)System.Drawing.Drawing2D.HatchStyle.SmallGrid; // 48 Горизонтальные и вертикальные линии, которые расположенны на 50 процентов ближе друг к другу, чем при штриховке <B>ВертикальнаяСетка&nbsp;(Cross)</B>.
        private int m_smallCheckerBoard = (int)System.Drawing.Drawing2D.HatchStyle.SmallCheckerBoard; // 49 Штриховка, имеющая вид шахматной доски.
        private int m_largeCheckerBoard = (int)System.Drawing.Drawing2D.HatchStyle.LargeCheckerBoard; // 50 Шахматная доска, с квадратами, вдвое большими чем при штриховке <B>МаленькаяРешетка&nbsp;(SmallGrid)</B>.
        private int m_outlinedDiamond = (int)System.Drawing.Drawing2D.HatchStyle.OutlinedDiamond; // 51 Прямые и обратные диагональные линии, как перекрестие, но не сглаженые.
        private int m_solidDiamond = (int)System.Drawing.Drawing2D.HatchStyle.SolidDiamond; // 52 Штриховка, в виде шахматной доски по диагонали.

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

        internal ClHatchStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(BackwardDiagonal));
            _list.Add(ValueFactory.Create(Cross));
            _list.Add(ValueFactory.Create(DarkDownwardDiagonal));
            _list.Add(ValueFactory.Create(DarkHorizontal));
            _list.Add(ValueFactory.Create(DarkUpwardDiagonal));
            _list.Add(ValueFactory.Create(DarkVertical));
            _list.Add(ValueFactory.Create(DashedDownwardDiagonal));
            _list.Add(ValueFactory.Create(DashedHorizontal));
            _list.Add(ValueFactory.Create(DashedUpwardDiagonal));
            _list.Add(ValueFactory.Create(DashedVertical));
            _list.Add(ValueFactory.Create(DiagonalBrick));
            _list.Add(ValueFactory.Create(DiagonalCross));
            _list.Add(ValueFactory.Create(Divot));
            _list.Add(ValueFactory.Create(DottedDiamond));
            _list.Add(ValueFactory.Create(DottedGrid));
            _list.Add(ValueFactory.Create(ForwardDiagonal));
            _list.Add(ValueFactory.Create(Horizontal));
            _list.Add(ValueFactory.Create(HorizontalBrick));
            _list.Add(ValueFactory.Create(LargeCheckerBoard));
            _list.Add(ValueFactory.Create(LargeConfetti));
            _list.Add(ValueFactory.Create(LargeGrid));
            _list.Add(ValueFactory.Create(LightDownwardDiagonal));
            _list.Add(ValueFactory.Create(LightHorizontal));
            _list.Add(ValueFactory.Create(LightUpwardDiagonal));
            _list.Add(ValueFactory.Create(LightVertical));
            _list.Add(ValueFactory.Create(Max));
            _list.Add(ValueFactory.Create(Min));
            _list.Add(ValueFactory.Create(NarrowHorizontal));
            _list.Add(ValueFactory.Create(NarrowVertical));
            _list.Add(ValueFactory.Create(OutlinedDiamond));
            _list.Add(ValueFactory.Create(Percent05));
            _list.Add(ValueFactory.Create(Percent10));
            _list.Add(ValueFactory.Create(Percent20));
            _list.Add(ValueFactory.Create(Percent25));
            _list.Add(ValueFactory.Create(Percent30));
            _list.Add(ValueFactory.Create(Percent40));
            _list.Add(ValueFactory.Create(Percent50));
            _list.Add(ValueFactory.Create(Percent60));
            _list.Add(ValueFactory.Create(Percent70));
            _list.Add(ValueFactory.Create(Percent75));
            _list.Add(ValueFactory.Create(Percent80));
            _list.Add(ValueFactory.Create(Percent90));
            _list.Add(ValueFactory.Create(Plaid));
            _list.Add(ValueFactory.Create(Shingle));
            _list.Add(ValueFactory.Create(SmallCheckerBoard));
            _list.Add(ValueFactory.Create(SmallConfetti));
            _list.Add(ValueFactory.Create(SmallGrid));
            _list.Add(ValueFactory.Create(SolidDiamond));
            _list.Add(ValueFactory.Create(Sphere));
            _list.Add(ValueFactory.Create(Trellis));
            _list.Add(ValueFactory.Create(Vertical));
            _list.Add(ValueFactory.Create(Wave));
            _list.Add(ValueFactory.Create(Weave));
            _list.Add(ValueFactory.Create(WideDownwardDiagonal));
            _list.Add(ValueFactory.Create(WideUpwardDiagonal));
            _list.Add(ValueFactory.Create(ZigZag));
        }

        [ContextProperty("БольшаяРешетка", "LargeGrid")]
        public int LargeGrid
        {
        	get { return m_largeGrid; }
        }

        [ContextProperty("БольшаяШахматнаяДоска", "LargeCheckerBoard")]
        public int LargeCheckerBoard
        {
        	get { return m_largeCheckerBoard; }
        }

        [ContextProperty("БольшоеКонфетти", "LargeConfetti")]
        public int LargeConfetti
        {
        	get { return m_largeConfetti; }
        }

        [ContextProperty("Вертикальная", "Vertical")]
        public int Vertical
        {
        	get { return m_vertical; }
        }

        [ContextProperty("ВертикальнаяСетка", "Cross")]
        public int Cross
        {
        	get { return m_cross; }
        }

        [ContextProperty("Волна", "Wave")]
        public int Wave
        {
        	get { return m_wave; }
        }

        [ContextProperty("Горизонтальная", "Horizontal")]
        public int Horizontal
        {
        	get { return m_horizontal; }
        }

        [ContextProperty("ГоризонтальныеБлоки", "HorizontalBrick")]
        public int HorizontalBrick
        {
        	get { return m_horizontalBrick; }
        }

        [ContextProperty("Дерн", "Divot")]
        public int Divot
        {
        	get { return m_divot; }
        }

        [ContextProperty("ДиагональнаяСетка", "DiagonalCross")]
        public int DiagonalCross
        {
        	get { return m_diagonalCross; }
        }

        [ContextProperty("ДиагональныйБлок", "DiagonalBrick")]
        public int DiagonalBrick
        {
        	get { return m_diagonalBrick; }
        }

        [ContextProperty("ЗигЗаг", "ZigZag")]
        public int ZigZag
        {
        	get { return m_zigZag; }
        }

        [ContextProperty("МаленькаяРешетка", "SmallGrid")]
        public int SmallGrid
        {
        	get { return m_smallGrid; }
        }

        [ContextProperty("МаленькаяШахматнаяДоска", "SmallCheckerBoard")]
        public int SmallCheckerBoard
        {
        	get { return m_smallCheckerBoard; }
        }

        [ContextProperty("МаленькоеКонфетти", "SmallConfetti")]
        public int SmallConfetti
        {
        	get { return m_smallConfetti; }
        }

        [ContextProperty("Мешковина", "Trellis")]
        public int Trellis
        {
        	get { return m_trellis; }
        }

        [ContextProperty("ОбведенныйАлмаз", "OutlinedDiamond")]
        public int OutlinedDiamond
        {
        	get { return m_outlinedDiamond; }
        }

        [ContextProperty("ОбратнаяДиагональная", "BackwardDiagonal")]
        public int BackwardDiagonal
        {
        	get { return m_backwardDiagonal; }
        }

        [ContextProperty("Плед", "Plaid")]
        public int Plaid
        {
        	get { return m_plaid; }
        }

        [ContextProperty("Процент05", "Percent05")]
        public int Percent05
        {
        	get { return m_percent05; }
        }

        [ContextProperty("Процент10", "Percent10")]
        public int Percent10
        {
        	get { return m_percent10; }
        }

        [ContextProperty("Процент20", "Percent20")]
        public int Percent20
        {
        	get { return m_percent20; }
        }

        [ContextProperty("Процент25", "Percent25")]
        public int Percent25
        {
        	get { return m_percent25; }
        }

        [ContextProperty("Процент30", "Percent30")]
        public int Percent30
        {
        	get { return m_percent30; }
        }

        [ContextProperty("Процент40", "Percent40")]
        public int Percent40
        {
        	get { return m_percent40; }
        }

        [ContextProperty("Процент50", "Percent50")]
        public int Percent50
        {
        	get { return m_percent50; }
        }

        [ContextProperty("Процент60", "Percent60")]
        public int Percent60
        {
        	get { return m_percent60; }
        }

        [ContextProperty("Процент70", "Percent70")]
        public int Percent70
        {
        	get { return m_percent70; }
        }

        [ContextProperty("Процент75", "Percent75")]
        public int Percent75
        {
        	get { return m_percent75; }
        }

        [ContextProperty("Процент80", "Percent80")]
        public int Percent80
        {
        	get { return m_percent80; }
        }

        [ContextProperty("Процент90", "Percent90")]
        public int Percent90
        {
        	get { return m_percent90; }
        }

        [ContextProperty("ПрямаяДиагональная", "ForwardDiagonal")]
        public int ForwardDiagonal
        {
        	get { return m_forwardDiagonal; }
        }

        [ContextProperty("ПунктирнаяВертикальная", "DashedVertical")]
        public int DashedVertical
        {
        	get { return m_dashedVertical; }
        }

        [ContextProperty("ПунктирнаяВосходящаяДиагональная", "DashedUpwardDiagonal")]
        public int DashedUpwardDiagonal
        {
        	get { return m_dashedUpwardDiagonal; }
        }

        [ContextProperty("ПунктирнаяГоризонтальная", "DashedHorizontal")]
        public int DashedHorizontal
        {
        	get { return m_dashedHorizontal; }
        }

        [ContextProperty("ПунктирнаяНисходящаяДиагональная", "DashedDownwardDiagonal")]
        public int DashedDownwardDiagonal
        {
        	get { return m_dashedDownwardDiagonal; }
        }

        [ContextProperty("СветлаяВертикальная", "LightVertical")]
        public int LightVertical
        {
        	get { return m_lightVertical; }
        }

        [ContextProperty("СветлаяВосходящаяДиагональная", "LightUpwardDiagonal")]
        public int LightUpwardDiagonal
        {
        	get { return m_lightUpwardDiagonal; }
        }

        [ContextProperty("СветлаяГоризонтальная", "LightHorizontal")]
        public int LightHorizontal
        {
        	get { return m_lightHorizontal; }
        }

        [ContextProperty("СветлаяНисходящаяДиагональная", "LightDownwardDiagonal")]
        public int LightDownwardDiagonal
        {
        	get { return m_lightDownwardDiagonal; }
        }

        [ContextProperty("СплошнойАлмаз", "SolidDiamond")]
        public int SolidDiamond
        {
        	get { return m_solidDiamond; }
        }

        [ContextProperty("Сфера", "Sphere")]
        public int Sphere
        {
        	get { return m_sphere; }
        }

        [ContextProperty("ТемнаяВертикальная", "DarkVertical")]
        public int DarkVertical
        {
        	get { return m_darkVertical; }
        }

        [ContextProperty("ТемнаяВосходящаяДиагональная", "DarkUpwardDiagonal")]
        public int DarkUpwardDiagonal
        {
        	get { return m_darkUpwardDiagonal; }
        }

        [ContextProperty("ТемнаяГоризонтальная", "DarkHorizontal")]
        public int DarkHorizontal
        {
        	get { return m_darkHorizontal; }
        }

        [ContextProperty("ТемнаяНисходящаяДиагональная", "DarkDownwardDiagonal")]
        public int DarkDownwardDiagonal
        {
        	get { return m_darkDownwardDiagonal; }
        }

        [ContextProperty("Ткань", "Weave")]
        public int Weave
        {
        	get { return m_weave; }
        }

        [ContextProperty("ТочечнаяРешетка", "DottedGrid")]
        public int DottedGrid
        {
        	get { return m_dottedGrid; }
        }

        [ContextProperty("ТочечныйАлмаз", "DottedDiamond")]
        public int DottedDiamond
        {
        	get { return m_dottedDiamond; }
        }

        [ContextProperty("УзкаяВертикальная", "NarrowVertical")]
        public int NarrowVertical
        {
        	get { return m_narrowVertical; }
        }

        [ContextProperty("УзкаяГоризонтальная", "NarrowHorizontal")]
        public int NarrowHorizontal
        {
        	get { return m_narrowHorizontal; }
        }

        [ContextProperty("Черепица", "Shingle")]
        public int Shingle
        {
        	get { return m_shingle; }
        }

        [ContextProperty("ШирокаяВосходящаяДиагональная", "WideUpwardDiagonal")]
        public int WideUpwardDiagonal
        {
        	get { return m_wideUpwardDiagonal; }
        }

        [ContextProperty("ШирокаяНисходящаяДиагональная", "WideDownwardDiagonal")]
        public int WideDownwardDiagonal
        {
        	get { return m_wideDownwardDiagonal; }
        }

        [ContextProperty("ШтриховкаГоризонтальная", "Min")]
        public int Min
        {
        	get { return m_min; }
        }

        [ContextProperty("ШтриховкаСплошнойАлмаз", "Max")]
        public int Max
        {
        	get { return m_max; }
        }
    }
}
