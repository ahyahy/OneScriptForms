using System.Drawing;
using System.Drawing.Drawing2D;

namespace JonasKohl.Graphics
{
    // Код создан на основе разработки автора Jonas Kohl https://github.com/jonaskohl/RoundRect
    // Простой вспомогательный класс для рисования идеальных по пикселям симметричных прямоугольников со скругленными углами.
    // Адаптировано из https://www.codeproject.com/Articles/27228/A-class-for-creating-round-rectangles-in-GDI-with
    // и перенесенный с C++ на C#.NET by Jonas Kohl http://jonaskohl.de/

    static class RoundRect
    {
        // Создает контур закругленного прямоугольника (Графическая дорожка, напоминающая закругленный прямоугольник).
        public static GraphicsPath GetRoundRectPath(Rectangle r, int dia)
        {
            // r - Прямоугольник для использования
            // dia - Диаметр
            GraphicsPath pPath = new GraphicsPath();

            // Диаметр не может превышать ширину или высоту.
            if (dia > r.Width) dia = r.Width;
            if (dia > r.Height) dia = r.Height;

            // Определите угол.
            Rectangle Corner = new Rectangle(r.X, r.Y, dia, dia);

            // Начальный путь.
            pPath.Reset();

            // Вверху слева.
            pPath.AddArc(Corner, 180, 90);

            // Настройка необходима для радиуса 10 (диаметр 20).
            if (dia == 20)
            {
                Corner.Width += 1;
                Corner.Height += 1;
                r.Width -= 1; r.Height -= 1;
            }

            // Вверху справа.
            Corner.X += (r.Width - dia - 1);
            pPath.AddArc(Corner, 270, 90);

            // Внизу справа.
            Corner.Y += (r.Height - dia - 1);
            pPath.AddArc(Corner, 0, 90);

            // Внизу слева.
            Corner.X -= (r.Width - dia - 1);
            pPath.AddArc(Corner, 90, 90);

            // Конечный путь.
            pPath.CloseFigure();

            return pPath;
        }

        // Рисует (очерчивает) закругленный прямоугольник в графическом контексте.
        public static void DrawRoundRect(System.Drawing.Graphics pGraphics, Rectangle r, Color color, int radius, int width)
        {
            // pGraphics - Графический контекст
            // r - Ограничивающий прямоугольник
            // color - Цвет контура
            // radius - Радиус угла
            // width - Ширина контура
            int dia = 2 * radius;

            // Сохранить старый блок страниц.
            GraphicsUnit oldPageUnit = pGraphics.PageUnit;

            // Установить в пиксельный режим.
            pGraphics.PageUnit = GraphicsUnit.Pixel;

            // Определите перо.
            Pen pen = new Pen(color, 1);

            // Установите выравнивание пера.
            pen.Alignment = PenAlignment.Center;

            // Получить угловой путь.
            GraphicsPath path = GetRoundRectPath(r, dia);

            // Нарисуйте круглую прямую линию.
            pGraphics.DrawPath(pen, path);

            // Если ширина > 1.
            for (int i = 1; i < width; i++)
            {
                // Левый ход.
                r.Inflate(-1, 0);

                // Получить путь.
                path = GetRoundRectPath(r, dia);

                // Нарисуйте круглую прямую линию.
                pGraphics.DrawPath(pen, path);

                // Ход вверх.
                r.Inflate(0, -1);

                // Получить путь.
                path = GetRoundRectPath(r, dia);

                // Нарисуйте круглую прямую линию.
                pGraphics.DrawPath(pen, path);
            }

            // Восстановить блок страниц.
            pGraphics.PageUnit = oldPageUnit;
        }

        // Заполняет закругленный прямоугольник в графическом контексте.
        public static void FillRoundRect(System.Drawing.Graphics pGraphics, Brush pBrush, Rectangle r, Color border, int radius)
        {
            // pGraphics - Графический контекст
            // pBrush - Кисть для заполнения прямоугольника
            // r - Ограничивающий прямоугольник
            // border - Цвет контура (границы)
            // radius - Радиус угла
            int dia = 2 * radius;

            // Сохранить старый блок страниц.
            GraphicsUnit oldPageUnit = pGraphics.PageUnit;

            // Установить в пиксельный режим.
            pGraphics.PageUnit = GraphicsUnit.Pixel;

            // Определите перо.
            Pen pen = new Pen(border, 1);

            // Установите выравнивание пера.
            pen.Alignment = PenAlignment.Center;

            // Получить угловой путь.
            GraphicsPath path = GetRoundRectPath(r, dia);

            // Заполнить.
            pGraphics.FillPath(pBrush, path);

            // Нарисуйте границу в последнюю очередь, чтобы она была сверху, если цвет отличается.
            pGraphics.DrawPath(pen, path);

            // Восстановить блок страниц.
            pGraphics.PageUnit = oldPageUnit;
        }

        public static void SetRoundedShape(System.Windows.Forms.Panel control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddLine(radius, 0, control.Width - radius, 0);
            path.AddArc(control.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddLine(control.Width, radius, control.Width, control.Height - radius);
            path.AddArc(control.Width - radius - 1, control.Height - radius, radius, radius, 0, 90);
            path.AddLine(control.Width - radius, control.Height, radius, control.Height);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, control.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            control.Region = new Region(path);
        }
    }
}
