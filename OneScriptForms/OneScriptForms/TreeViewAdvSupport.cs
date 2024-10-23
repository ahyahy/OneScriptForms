using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Threading;
using System.Text;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Aga.Controls.Tree.NodeControls;
using Aga.Controls.Threading;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

    #region Aga.Controls.Threading

namespace Aga.Controls.Threading
{
    public class AbortableThreadPool
    {
        private LinkedList<WorkItem> _callbacks = new LinkedList<WorkItem>();
        private Dictionary<WorkItem, Thread> _threads = new Dictionary<WorkItem, Thread>();

        public WorkItem QueueUserWorkItem(WaitCallback callback)
        {
            return QueueUserWorkItem(callback, null);
        }

        public WorkItem QueueUserWorkItem(WaitCallback callback, object state)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            WorkItem item = new WorkItem(callback, state, ExecutionContext.Capture());
            lock (_callbacks)
            {
                _callbacks.AddLast(item);
            }
            ThreadPool.QueueUserWorkItem(new WaitCallback(HandleItem));
            return item;
        }

        private void HandleItem(object ignored)
        {
            WorkItem item = null;
            try
            {
                lock (_callbacks)
                {
                    if (_callbacks.Count > 0)
                    {
                        item = _callbacks.First.Value;
                        _callbacks.RemoveFirst();
                    }
                    if (item == null)
                    {
                        return;
                    }
                    _threads.Add(item, Thread.CurrentThread);
                }
                ExecutionContext.Run(item.Context, delegate { item.Callback(item.State); }, null);
            }
            finally
            {
                lock (_callbacks)
                {
                    if (item != null)
                    {
                        _threads.Remove(item);
                    }
                }
            }
        }

        public bool IsMyThread(Thread thread)
        {
            lock (_callbacks)
            {
                foreach (Thread t in _threads.Values)
                {
                    if (t == thread)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public WorkItemStatus Cancel(WorkItem item, bool allowAbort)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            lock (_callbacks)
            {
                LinkedListNode<WorkItem> node = _callbacks.Find(item);
                if (node != null)
                {
                    _callbacks.Remove(node);
                    return WorkItemStatus.Queued;
                }
                else if (_threads.ContainsKey(item))
                {
                    if (allowAbort)
                    {
                        _threads[item].Abort();
                        _threads.Remove(item);
                        return WorkItemStatus.Aborted;
                    }
                    else
                    {
                        return WorkItemStatus.Executing;
                    }
                }
                else
                {
                    return WorkItemStatus.Completed;
                }
            }
        }

        public void CancelAll(bool allowAbort)
        {
            lock (_callbacks)
            {
                _callbacks.Clear();
                if (allowAbort)
                {
                    foreach (Thread t in _threads.Values)
                    {
                        t.Abort();
                    }
                }
            }
        }
    }

    public sealed class WorkItem
    {
        internal WorkItem(WaitCallback wc, object state, ExecutionContext ctx)
        {
            _callback = wc;
            _state = state;
            _ctx = ctx;
        }

        private WaitCallback _callback;
        internal WaitCallback Callback
        {
            get { return _callback; }
        }

        private object _state;
        internal object State
        {
            get { return _state; }
        }

        private ExecutionContext _ctx;
        internal ExecutionContext Context
        {
            get { return _ctx; }
        }
    }

    public enum WorkItemStatus
    {
        Completed,
        Queued,
        Executing,
        Aborted
    }
}

    #endregion Aga.Controls.Threading

    #region Aga.Controls

namespace Aga.Controls
{
    public static class BitmapHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct PixelData
        {
            public byte B;
            public byte G;
            public byte R;
            public byte A;
        }

        public static void SetAlphaChanelValue(Bitmap image, byte value)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (image.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new ArgumentException("Wrong PixelFormat");
            }

            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                PixelData* pPixel = (PixelData*)bitmapData.Scan0;
                for (int i = 0; i < bitmapData.Height; i++)
                {
                    for (int j = 0; j < bitmapData.Width; j++)
                    {
                        pPixel->A = value;
                        pPixel++;
                    }
                    pPixel += bitmapData.Stride - (bitmapData.Width * 4);
                }
            }
            image.UnlockBits(bitmapData);
        }
    }

    //#region Java Info
    ///**
    // * Класс GifDecoder - Декодирует GIF-файл в один или несколько кадров.
    // * <br><pre>
    // * Example:
    // *    GifDecoder d = new GifDecoder();
    // *    d.read("sample.gif");
    // *    int n = d.getFrameCount();
    // *    for (int i = 0; i < n; i++) {
    // *       BufferedImage frame = d.getFrame(i);  // frame i
    // *       int t = d.getDelay(i);  // display duration of frame in milliseconds
    // *       // do something with frame
    // *    }
    // * </pre>
    // * No copyright asserted on the source code of this class.  May be used for
    // * any purpose, however, refer to the Unisys LZW patent for any additional
    // * restrictions.  Please forward any corrections to kweiner@fmsware.com.
    // *
    // * @author Kevin Weiner, FM Software; LZW decoder adapted from John Cristy's ImageMagick.
    // * @version 1.03 November 2003
    // *
    // */
    //#endregion
    public class GifFrame
    {
        private Image _image;
        public Image Image
        {
            get { return _image; }
        }

        private int _delay;
        public int Delay
        {
            get { return _delay; }
        }

        public GifFrame(Image im, int del)
        {
            _image = im;
            _delay = del;
        }
    }

    public class GifDecoder
    {
        public const int StatusOK = 0; // Статус чтения файла: Ошибок нет.
        public const int StatusFormatError = 1; // Статус чтения файла: Ошибка декодирования файла (может быть частично декодирован).
        public const int StatusOpenError = 2; // Невозможно открыть исходный код.

        private Stream inStream;
        private int status;

        private int width; // Полная ширина изображения.
        private int height; // Полная высота изображения.
        private bool gctFlag; // Используемая глобальная таблица цветов.
        private int gctSize; // Размер глобальной таблицы цветов.
        private int loopCount = 1; // Итерации; 0 = повторять вечно.

        private int[] gct; // Глобальная таблица цветов.
        private int[] lct; // Локальная таблица  цветов.
        private int[] act; // Активная таблица цветов.

        private int bgIndex; // Индекс цвета фона.
        private int bgColor; // Цвет фона.
        private int lastBgColor; // Предыдущий цвет bg.
        private int pixelAspect; // Соотношение сторон в пикселях.

        private bool lctFlag; // Флаг локальной таблицы цветов.
        private bool interlace; // Флаг чересстрочной развертки.
        private int lctSize; // Размер локальной таблицы цветов.

        private int ix, iy, iw, ih; // Прямоугольник текущего изображения.
        private Rectangle lastRect; // Последний прямоугольник изображения.
        private Image image; // Текущий кадр.
        private Bitmap bitmap;
        private Image lastImage; // Предыдущий кадр.

        private byte[] block = new byte[256]; // Текущий блок данных.
        private int blockSize = 0; // Размер блока.

        // Последняя информация о расширении графического элемента управления.
        private int dispose = 0;
        // 0=no action; 1=leave in place; 2=restore to bg; 3=restore to prev
        private int lastDispose = 0;
        private bool transparency = false; // Используйте прозрачный цвет.
        private int delay = 0; // Задержка в миллисекундах.
        private int transIndex; // Индекс прозрачного цвета.

        private const int MaxStackSize = 4096;
        // Максимальный размер стека пикселей декодера.

        // LZW рабочий массив декодера.
        private short[] prefix;
        private byte[] suffix;
        private byte[] pixelStack;
        private byte[] pixels;

        private ArrayList frames; // Кадры, считанные из текущего файла.
        private int frameCount;
        private bool _makeTransparent;

        /**
		 * Gets the number of frames read from file.
		 * @return frame count
		 */
        public int FrameCount
        {
            get { return frameCount; }
        }

        /**
		 * Gets the first (or only) image read.
		 *
		 * @return BufferedImage containing first frame, or null if none.
		 */
        public Image Image
        {
            get { return GetFrame(0).Image; }
        }

        /**
		 * Получает количество итераций "Netscape", если таковые имеются.
		 * Значение 0 означает повторение до бесконечности.
		 *
		 * @return количество итераций, если была указана одна, в противном случае 1.
		 */
        public int LoopCount
        {
            get { return loopCount; }
        }

        public GifDecoder(Stream stream, bool makeTransparent)
        {
            _makeTransparent = makeTransparent;
            if (Read(stream) != 0)
            {
                throw new InvalidOperationException();
            }
        }

        /**
		 * Создает новое изображение кадра из текущих данных (и предыдущих кадров, как указано в их кодах расположения).
		 */
        private int[] GetPixels(Bitmap bitmap)
        {
            int[] pixels = new int[3 * image.Width * image.Height];
            int count = 0;
            for (int th = 0; th < image.Height; th++)
            {
                for (int tw = 0; tw < image.Width; tw++)
                {
                    Color color = bitmap.GetPixel(tw, th);
                    pixels[count] = color.R;
                    count++;
                    pixels[count] = color.G;
                    count++;
                    pixels[count] = color.B;
                    count++;
                }
            }
            return pixels;
        }

        private void SetPixels(int[] pixels)
        {
            int count = 0;
            for (int th = 0; th < image.Height; th++)
            {
                for (int tw = 0; tw < image.Width; tw++)
                {
                    Color color = Color.FromArgb(pixels[count++]);
                    bitmap.SetPixel(tw, th, color);
                }
            }
            if (_makeTransparent)
            {
                bitmap.MakeTransparent(bitmap.GetPixel(0, 0));
            }
        }

        private void SetPixels()
        {
            // Выставлять пиксели целевого изображения в виде массива int.
            //		int[] dest =
            //			(( int ) image.getRaster().getDataBuffer()).getData();
            int[] dest = GetPixels(bitmap);

            // Заполните начальное содержимое изображения на основе кода удаления последнего изображения.
            if (lastDispose > 0)
            {
                if (lastDispose == 3)
                {
                    // Используйте изображение перед последним.
                    int n = frameCount - 2;
                    if (n > 0)
                    {
                        lastImage = GetFrame(n - 1).Image;
                    }
                    else
                    {
                        lastImage = null;
                    }
                }

                if (lastImage != null)
                {
                    //				int[] prev =
                    //					((DataBufferInt) lastImage.getRaster().getDataBuffer()).getData();
                    int[] prev = GetPixels(new Bitmap(lastImage));
                    Array.Copy(prev, 0, dest, 0, width * height);
                    // Копирование пикселей.

                    if (lastDispose == 2)
                    {
                        // Заполните прямоугольную область последнего изображения фоновым цветом/
                        Graphics g = Graphics.FromImage(image);
                        Color c = Color.Empty;
                        if (transparency)
                        {
                            c = Color.FromArgb(0, 0, 0, 0); // Предположим, что фон прозрачный.
                        }
                        else
                        {
                            c = Color.FromArgb(lastBgColor);
                            // c = new Color(lastBgColor); // use given background color
                        }
                        Brush brush = new SolidBrush(c);
                        g.FillRectangle(brush, lastRect);
                        brush.Dispose();
                        g.Dispose();
                    }
                }
            }

            // Скопируйте каждую исходную строку в соответствующее место в пункте назначения.
            int pass = 1;
            int inc = 8;
            int iline = 0;
            for (int i = 0; i < ih; i++)
            {
                int line = i;
                if (interlace)
                {
                    if (iline >= ih)
                    {
                        pass++;
                        switch (pass)
                        {
                            case 2:
                                iline = 4;
                                break;
                            case 3:
                                iline = 2;
                                inc = 4;
                                break;
                            case 4:
                                iline = 1;
                                inc = 2;
                                break;
                        }
                    }
                    line = iline;
                    iline += inc;
                }
                line += iy;
                if (line < height)
                {
                    int k = line * width;
                    int dx = k + ix; // Начало строки в dest.
                    int dlim = dx + iw; // Конец строки dest.
                    if ((k + width) < dlim)
                    {
                        dlim = k + width; // Последний в dest.
                    }
                    int sx = i * iw; // Начало строки в источнике.
                    while (dx < dlim)
                    {
                        // Цвет карты и вставка в пункт назначения.
                        int index = ((int)pixels[sx++]) & 0xff;
                        int c = act[index];
                        if (c != 0)
                        {
                            dest[dx] = c;
                        }
                        dx++;
                    }
                }
            }
            SetPixels(dest);
        }

        /**
		 * Возвращает содержимое изображения кадра n.
		 *
		 * @return Буферизованное представление кадра.
		 */
        public GifFrame GetFrame(int n)
        {
            if ((n >= 0) && (n < frameCount))
            {
                return (GifFrame)frames[n];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /**
		 * Получает размер изображения.
		 *
		 * @return Размеры GIF-изображения.
		 */
        public Size FrameSize
        {
            get { return new Size(width, height); }
        }

        /**
		 * Reads GIF image from stream
		 *
		 * @param BufferedInputStream containing GIF file.
		 * @return read status code (0 = no errors)
		 */
        private int Read(Stream inStream)
        {
            Init();
            if (inStream != null)
            {
                this.inStream = inStream;
                ReadHeader();
                if (!Error())
                {
                    ReadContents();
                    if (frameCount < 0)
                    {
                        status = StatusFormatError;
                    }
                }
                inStream.Close();
            }
            else
            {
                status = StatusOpenError;
            }
            return status;
        }

        /**
		 * Decodes LZW image data into pixel array.
		 * Adapted from John Cristy's ImageMagick.
		 */
        private void DecodeImageData()
        {
            int NullCode = -1;
            int npix = iw * ih;
            int available,
                clear,
                code_mask,
                code_size,
                end_of_information,
                in_code,
                old_code,
                bits,
                code,
                count,
                i,
                datum,
                data_size,
                first,
                top,
                bi,
                pi;

            if ((pixels == null) || (pixels.Length < npix))
            {
                pixels = new byte[npix]; // allocate new pixel array
            }
            if (prefix == null)
            {
                prefix = new short[MaxStackSize];
            }
            if (suffix == null)
            {
                suffix = new byte[MaxStackSize];
            }
            if (pixelStack == null)
            {
                pixelStack = new byte[MaxStackSize + 1];
            }

            // Инициализируйте декодер потока данных GIF.

            data_size = Read();
            clear = 1 << data_size;
            end_of_information = clear + 1;
            available = clear + 2;
            old_code = NullCode;
            code_size = data_size + 1;
            code_mask = (1 << code_size) - 1;
            for (code = 0; code < clear; code++)
            {
                prefix[code] = 0;
                suffix[code] = (byte)code;
            }

            // Декодируйте поток пикселей GIF.

            datum = bits = count = first = top = pi = bi = 0;

            for (i = 0; i < npix;)
            {
                if (top == 0)
                {
                    if (bits < code_size)
                    {
                        // Загружайте байты до тех пор, пока не наберется достаточно битов для кода.
                        if (count == 0)
                        {
                            // Считайте новый блок данных.
                            count = ReadBlock();
                            if (count <= 0)
                            {
                                break;
                            }
                            bi = 0;
                        }
                        datum += (((int)block[bi]) & 0xff) << bits;
                        bits += 8;
                        bi++;
                        count--;
                        continue;
                    }

                    // Получите следующий код.

                    code = datum & code_mask;
                    datum >>= code_size;
                    bits -= code_size;

                    // Интерпретируйте код.

                    if ((code > available) || (code == end_of_information))
                    {
                        break;
                    }
                    if (code == clear)
                    {
                        // Сброс декодера.
                        code_size = data_size + 1;
                        code_mask = (1 << code_size) - 1;
                        available = clear + 2;
                        old_code = NullCode;
                        continue;
                    }
                    if (old_code == NullCode)
                    {
                        pixelStack[top++] = suffix[code];
                        old_code = code;
                        first = code;
                        continue;
                    }
                    in_code = code;
                    if (code == available)
                    {
                        pixelStack[top++] = (byte)first;
                        code = old_code;
                    }
                    while (code > clear)
                    {
                        pixelStack[top++] = suffix[code];
                        code = prefix[code];
                    }
                    first = ((int)suffix[code]) & 0xff;

                    // Добавьте новую строку в таблицу строк,

                    if (available >= MaxStackSize)
                    {
                        break;
                    }
                    pixelStack[top++] = (byte)first;
                    prefix[available] = (short)old_code;
                    suffix[available] = (byte)first;
                    available++;
                    if (((available & code_mask) == 0) && (available < MaxStackSize))
                    {
                        code_size++;
                        code_mask += available;
                    }
                    old_code = in_code;
                }

                // Извлеките пиксель из стека пикселей.

                top--;
                pixels[pi++] = pixelStack[top];
                i++;
            }

            for (i = pi; i < npix; i++)
            {
                pixels[i] = 0; // Очистите недостающие пиксели.
            }
        }

        /**
		 * Возвращает значение true, если во время чтения/декодирования была обнаружена ошибка.
		 */
        private bool Error()
        {
            return status != StatusOK;
        }

        /**
		 * Инициализирует или повторно инициализирует считыватель.
		 */
        private void Init()
        {
            status = StatusOK;
            frameCount = 0;
            frames = new ArrayList();
            gct = null;
            lct = null;
        }

        /**
		 * Считывает один байт из входного потока.
		 */
        private int Read()
        {
            int curByte = 0;
            try
            {
                curByte = inStream.ReadByte();
            }
            catch (IOException)
            {
                status = StatusFormatError;
            }
            return curByte;
        }

        /**
		 * Считывает следующий блок переменной длины из входных данных.
		 *
		 * @return number of bytes stored in "buffer"
		 */
        private int ReadBlock()
        {
            blockSize = Read();
            int n = 0;
            if (blockSize > 0)
            {
                try
                {
                    int count = 0;
                    while (n < blockSize)
                    {
                        count = inStream.Read(block, n, blockSize - n);
                        if (count == -1)
                        {
                            break;
                        }
                        n += count;
                    }
                }
                catch (IOException)
                {
                }

                if (n < blockSize)
                {
                    status = StatusFormatError;
                }
            }
            return n;
        }

        /**
		 * Считывает таблицу цветов в виде 256 целых значений RGB.
		 *
		 * @param ncolors int number of colors to read
		 * @return int array containing 256 colors (packed ARGB with full alpha)
		 */
#pragma warning disable 675 // Bitwise-or operator used on a sign-extended operand
        private int[] ReadColorTable(int ncolors)
        {
            int nbytes = 3 * ncolors;
            int[] tab = null;
            byte[] c = new byte[nbytes];
            int n = 0;
            try
            {
                n = inStream.Read(c, 0, c.Length);
            }
            catch (IOException)
            {
            }
            if (n < nbytes)
            {
                status = StatusFormatError;
            }
            else
            {
                tab = new int[256]; // Максимальный размер, чтобы избежать проверки границ.
                int i = 0;
                int j = 0;
                while (i < ncolors)
                {
                    int r = ((int)c[j++]) & 0xff;
                    int g = ((int)c[j++]) & 0xff;
                    int b = ((int)c[j++]) & 0xff;
                    tab[i++] = (int)(0xff000000 | (r << 16) | (g << 8) | b);
                }
            }
            return tab;
        }

        /**
		 * Основной анализатор файлов.  Считывает блоки содержимого GIF.
		 */
        private void ReadContents()
        {
            // Чтение блоков содержимого GIF-файла.
            bool done = false;
            while (!(done || Error()))
            {
                int code = Read();
                switch (code)
                {

                    case 0x2C: // Разделитель изображений.
                        ReadImage();
                        break;

                    case 0x21: // Расширение.
                        code = Read();
                        switch (code)
                        {
                            case 0xf9: // Расширение для управления графикой.
                                ReadGraphicControlExt();
                                break;

                            case 0xff: // Расширение приложения.
                                ReadBlock();
                                String app = "";
                                for (int i = 0; i < 11; i++)
                                {
                                    app += (char)block[i];
                                }
                                if (app.Equals("NETSCAPE2.0"))
                                {
                                    ReadNetscapeExt();
                                }
                                else
                                    Skip(); // Мне все равно.
                                break;

                            default: // Неинтересное расширение.
                                Skip();
                                break;
                        }
                        break;

                    case 0x3b: // Признак конца.
                        done = true;
                        break;

                    case 0x00: // Плохой байт, но продолжайте идти и посмотрите, что произойдет.
                        break;

                    default:
                        status = StatusFormatError;
                        break;
                }
            }
        }

        /**
		 * Reads Graphics Control Extension values
		 */
        private void ReadGraphicControlExt()
        {
            Read(); // Размер блока.
            int packed = Read(); // Упакованные поля.
            dispose = (packed & 0x1c) >> 2; // Способ утилизации.
            if (dispose == 0)
            {
                dispose = 1; // Выберите сохранить старое изображение, если это необходимо по усмотрению.
            }
            transparency = (packed & 1) != 0;
            delay = ReadShort() * 10; // Задержка в миллисекундах.
            transIndex = Read(); // Индекс прозрачного цвета.
            Read(); // Блок-терминатор.
        }

        /**
		 * Считывает информацию о заголовке GIF-файла.
		 */
        private void ReadHeader()
        {
            String id = "";
            for (int i = 0; i < 6; i++)
            {
                id += (char)Read();
            }
            if (!id.StartsWith("GIF"))
            {
                status = StatusFormatError;
                return;
            }

            ReadLSD();
            if (gctFlag && !Error())
            {
                gct = ReadColorTable(gctSize);
                bgColor = gct[bgIndex];
            }
        }

        /**
		 * Reads next frame image
		 */
        private void ReadImage()
        {
            ix = ReadShort(); // (sub)image position & size
            iy = ReadShort();
            iw = ReadShort();
            ih = ReadShort();

            int packed = Read();
            lctFlag = (packed & 0x80) != 0; // 1 - local color table flag
            interlace = (packed & 0x40) != 0; // 2 - interlace flag
                                              // 3 - sort flag
                                              // 4-5 - reserved
            lctSize = 2 << (packed & 7); // 6-8 - local color table size

            if (lctFlag)
            {
                lct = ReadColorTable(lctSize); // read table
                act = lct; // make local table active
            }
            else
            {
                act = gct; // make global table active
                if (bgIndex == transIndex)
                {
                    bgColor = 0;
                }
            }
            int save = 0;
            if (transparency)
            {
                save = act[transIndex];
                act[transIndex] = 0; // set transparent color if specified
            }

            if (act == null)
            {
                status = StatusFormatError; // no color table defined
            }

            if (Error())
            {
                return;
            }

            DecodeImageData(); // decode pixel data
            Skip();

            if (Error())
            {
                return;
            }

            frameCount++;

            // create new image to receive frame data
            //		image =
            //			new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB_PRE);

            bitmap = new Bitmap(width, height);
            image = bitmap;
            SetPixels(); // transfer pixel data to image

            frames.Add(new GifFrame(bitmap, delay)); // add image to frame list

            if (transparency)
            {
                act[transIndex] = save;
            }
            ResetFrame();

        }

        /**
		 * Reads Logical Screen Descriptor
		 */
        private void ReadLSD()
        {

            // logical screen size
            width = ReadShort();
            height = ReadShort();

            // packed fields
            int packed = Read();
            gctFlag = (packed & 0x80) != 0; // 1   : global color table flag
                                            // 2-4 : color resolution
                                            // 5   : gct sort flag
            gctSize = 2 << (packed & 7); // 6-8 : gct size

            bgIndex = Read(); // background color index
            pixelAspect = Read(); // pixel aspect ratio
        }

        /**
		 * Reads Netscape extenstion to obtain iteration count
		 */
        private void ReadNetscapeExt()
        {
            do
            {
                ReadBlock();
                if (block[0] == 1)
                {
                    // loop count sub-block
                    int b1 = ((int)block[1]) & 0xff;
                    int b2 = ((int)block[2]) & 0xff;
                    loopCount = (b2 << 8) | b1;
                }
            }
            while ((blockSize > 0) && !Error());
        }

        /**
		 * Reads next 16-bit value, LSB first
		 */
        private int ReadShort()
        {
            // read 16-bit value, LSB first
            return Read() | (Read() << 8);
        }

        /**
		 * Resets frame state for reading next image.
		 */
        private void ResetFrame()
        {
            lastDispose = dispose;
            lastRect = new Rectangle(ix, iy, iw, ih);
            lastImage = image;
            lastBgColor = bgColor;
            //		int dispose = 0;
            lct = null;
        }

        /**
		 * Skips variable length blocks up to and including
		 * next zero length block.
		 */
        private void Skip()
        {
            do
            {
                ReadBlock();
            }
            while ((blockSize > 0) && !Error());
        }
    }

    public class NumericTextBox : TextBox
    {
        // Ограничивает ввод символов цифрами, знаком минус, десятичной точкой и нажатиями клавиш редактирования (пробел).
        // Он не обрабатывает ключ AltGr, поэтому любые ключи, которые могут быть созданы в любой комбинации с AltGr, не фильтруются.

        private const int WM_PASTE = 0x302;
        private NumberStyles numberStyle = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;

        // Ограничивает ввод символов цифрами, знаком минус, десятичной точкой и нажатиями клавиш редактирования (пробел).
        // Он не обрабатывает клавишу AltGr.
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            e.Handled = invalidNumeric(e.KeyChar);
        }

        // Основной метод проверки разрешенных нажатий клавиш.
        // Это не улавливает операции вырезания, вставки, копирования ....
        private bool invalidNumeric(char key)
        {
            bool handled = false;
            NumberFormatInfo numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;
            string keyString = key.ToString();

            if (Char.IsDigit(key))
            {
                // Digits are OK
            }
            else if (AllowDecimalSeparator && keyString.Equals(decimalSeparator))
            {
                if (Text.IndexOf(decimalSeparator) >= 0)
                {
                    handled = true;
                }
            }
            else if (AllowNegativeSign && keyString.Equals(negativeSign))
            {
                if (Text.IndexOf(negativeSign) >= 0)
                {
                    handled = true;
                }
            }
            else if (key == '\b')
            {
                // Backspace key is OK
            }
            else if ((ModifierKeys & (Keys.Control)) != 0)
            {
                // Let the edit control handle control and alt key combinations
            }
            else
            {
                // Swallow this invalid key and beep
                handled = true;
            }
            return handled;
        }

        // Метод, вызываемый, когда Windows отправляет сообщение.
        // Это переопределено, так что пользователь не может использовать операции вырезания или вставки для обхода события TextChanging.
        // Это ловит контекстное меню Paste, Shift+Insert, Ctrl+V,
        // Хотя обычно не одобряется переопределение WndProc, не было видно другого простого механизма для одновременного и прозрачного перехвата такого количества различных операций.
        protected override void WndProc(ref Message m)
        {
            // Switch to handle message...
            switch (m.Msg)
            {
                case WM_PASTE:
                    {
                        // Get clipboard object to paste
                        IDataObject clipboardData = Clipboard.GetDataObject();

                        // Get text from clipboard data
                        string pasteText = (string)clipboardData.GetData(DataFormats.UnicodeText);

                        // Get the number of characters to replace
                        int selectionLength = SelectionLength;

                        // If no replacement or insertion, we are done
                        if (pasteText.Length == 0)
                        {
                            break;
                        }
                        else if (selectionLength != 0)
                        {
                            base.Text = base.Text.Remove(SelectionStart, selectionLength);
                        }

                        bool containsInvalidChars = false;
                        foreach (char c in pasteText)
                        {
                            if (containsInvalidChars)
                            {
                                break;
                            }
                            else if (invalidNumeric(c))
                            {
                                containsInvalidChars = true;
                            }
                        }

                        if (!containsInvalidChars)
                        {
                            base.Text = base.Text.Insert(SelectionStart, pasteText);
                        }
                        return;
                    }
            }
            base.WndProc(ref m);
        }

        public int IntValue
        {
            get
            {
                int intValue;
                Int32.TryParse(this.Text, numberStyle, CultureInfo.CurrentCulture.NumberFormat, out intValue);
                return intValue;
            }
        }

        public decimal DecimalValue
        {
            get
            {
                decimal decimalValue;
                Decimal.TryParse(this.Text, numberStyle, CultureInfo.CurrentCulture.NumberFormat, out decimalValue);
                return decimalValue;
            }
            set { this.Text = value.ToString(CultureInfo.CurrentCulture.NumberFormat); }
        }

        private bool allowNegativeSign;
        public bool AllowNegativeSign
        {
            get { return allowNegativeSign; }
            set { allowNegativeSign = value; }
        }

        private bool allowDecimalSeparator;
        public bool AllowDecimalSeparator
        {
            get { return allowDecimalSeparator; }
            set { allowDecimalSeparator = value; }
        }
    }

    public static class TextHelper
    {
        public static StringAlignment TranslateAligment(HorizontalAlignment alignment)
        {
            if (alignment == HorizontalAlignment.Left)
            {
                return StringAlignment.Near;
            }
            else if (alignment == HorizontalAlignment.Right)
            {
                return StringAlignment.Far;
            }
            else
            {
                return StringAlignment.Center;
            }
        }

        public static TextFormatFlags TranslateAligmentToFlag(HorizontalAlignment alignment)
        {
            if (alignment == HorizontalAlignment.Left)
            {
                return TextFormatFlags.Left;
            }
            else if (alignment == HorizontalAlignment.Right)
            {
                return TextFormatFlags.Right;
            }
            else
            {
                return TextFormatFlags.HorizontalCenter;
            }
        }

        public static TextFormatFlags TranslateTrimmingToFlag(StringTrimming trimming)
        {
            if (trimming == StringTrimming.EllipsisCharacter)
            {
                return TextFormatFlags.EndEllipsis;
            }
            else if (trimming == StringTrimming.EllipsisPath)
            {
                return TextFormatFlags.PathEllipsis;
            }

            if (trimming == StringTrimming.EllipsisWord)
            {
                return TextFormatFlags.WordEllipsis;
            }
            if (trimming == StringTrimming.Word)
            {
                return TextFormatFlags.WordBreak;
            }
            else
            {
                return TextFormatFlags.Default;
            }
        }
    }
}

    #endregion Aga.Controls

    #region Aga.Controls.Tree.NodeControls

namespace Aga.Controls.Tree.NodeControls
{
    public abstract class BaseTextControl : EditableControl
    {
        private TextFormatFlags _baseFormatFlags;
        private TextFormatFlags _formatFlags;
        private Pen _focusPen;
        private StringFormat _format;

        protected BaseTextControl()
        {
            IncrementalSearchEnabled = true;
            _focusPen = new Pen(Color.Black);
            _focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            _format = new StringFormat(StringFormatFlags.LineLimit | StringFormatFlags.NoClip | StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces);
            _baseFormatFlags = TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.PreserveGraphicsTranslateTransform;
            SetFormatFlags();
            LeftMargin = 3;
        }

        private Font _font = null;
        public Font Font
        {
            get
            {
                if (_font == null)
                {
                    return Control.DefaultFont;
                }
                else
                {
                    return _font;
                }
            }
            set
            {
                if (value == Control.DefaultFont)
                {
                    _font = null;
                }
                else
                {
                    _font = value;
                }
            }
        }

        protected bool ShouldSerializeFont()
        {
            return (_font != null);
        }

        private HorizontalAlignment _textAlign = HorizontalAlignment.Left;
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;
                SetFormatFlags();
            }
        }

        private StringTrimming _trimming = StringTrimming.None;
        [DefaultValue(StringTrimming.None)]
        public StringTrimming Trimming
        {
            get { return _trimming; }
            set
            {
                _trimming = value;
                SetFormatFlags();
            }
        }

        private bool _displayHiddenContentInToolTip = true;
        [DefaultValue(true)]
        public bool DisplayHiddenContentInToolTip
        {
            get { return _displayHiddenContentInToolTip; }
            set { _displayHiddenContentInToolTip = value; }
        }

        private bool _useCompatibleTextRendering = false;
        [DefaultValue(false)]
        public bool UseCompatibleTextRendering
        {
            get { return _useCompatibleTextRendering; }
            set { _useCompatibleTextRendering = value; }
        }

        [DefaultValue(false)]
        public bool TrimMultiLine { get; set; }

        private void SetFormatFlags()
        {
            _format.Alignment = TextHelper.TranslateAligment(TextAlign);
            _format.Trimming = Trimming;

            _formatFlags = _baseFormatFlags | TextHelper.TranslateAligmentToFlag(TextAlign) | TextHelper.TranslateTrimmingToFlag(Trimming);
        }

        public override Size MeasureSize(TreeNodeAdv node, DrawContext context)
        {
            return GetLabelSize(node, context);
        }

        protected Size GetLabelSize(TreeNodeAdv node, DrawContext context)
        {
            return GetLabelSize(node, context, GetLabel(node));
        }

        protected Size GetLabelSize(TreeNodeAdv node, DrawContext context, string label)
        {
            CheckThread();
            Font font = GetDrawingFont(node, context, label);
            Size s = Size.Empty;
            if (UseCompatibleTextRendering)
            {
                s = TextRenderer.MeasureText(label, font);
            }
            else
            {
                SizeF sf = context.Graphics.MeasureString(label, font);
                s = new Size((int)Math.Ceiling(sf.Width), (int)Math.Ceiling(sf.Height));
            }

            if (!s.IsEmpty)
            {
                return s;
            }
            else
            {
                return new Size(10, Font.Height);
            }
        }

        protected Font GetDrawingFont(TreeNodeAdv node, DrawContext context, string label)
        {
            Font font = context.Font;
            if (DrawTextMustBeFired(node))
            {
                DrawEventArgs args = new DrawEventArgs(node, this, context, label);
                args.Font = context.Font;
                OnDrawText(args);
                font = args.Font;
            }
            return font;
        }

        protected void SetEditControlProperties(Control control, TreeNodeAdv node)
        {
            string label = GetLabel(node);
            DrawContext context = new DrawContext();
            context.Font = control.Font;
            control.Font = GetDrawingFont(node, context, label);
        }

        public override void Draw(TreeNodeAdv node, DrawContext context)
        {
            if (context.CurrentEditorOwner == this && node == Parent.CurrentNode)
            {
                return;
            }

            //string label = GetLabel(node);
            string label = String.Empty;
            try
            {
                if (this.GetType() == typeof(NodeDecimalTextBox))
                {
                    string f = ((NodeDecimalTextBox)this).CustomFormat;
                    ScriptEngine.Machine.Values.NumberValue numberValue = ((ScriptEngine.Machine.Values.NumberValue)((Node)node.Tag).nodeControlValue[this]);
                    if (f.Contains("D") || f.Contains("X"))
                    {
                        int i = Convert.ToInt32(numberValue.AsNumber());
                        label = i.ToString(f);
                    }
                    else
                    {
                        decimal d = ((ScriptEngine.Machine.Values.NumberValue)((Node)node.Tag).nodeControlValue[this]).AsNumber();
                        label = d.ToString(f);
                    }
                }
                else
                {
                    label = ((Node)node.Tag).nodeControlValue[this].ToString();
                }
            }
            catch { }
		
            Rectangle bounds = GetBounds(node, context);
            if (this.VerticalAlign == VerticalAlignment.Center)
            {
                bounds.Y = (int)(context.Bounds.Y + (context.Bounds.Height / 2) - (Font.Height / 2));
            }
            Rectangle focusRect = new Rectangle(bounds.X, context.Bounds.Y, bounds.Width, context.Bounds.Height);

            Brush backgroundBrush;
            Color textColor;
            Font font;
            CreateBrushes(node, context, label, out backgroundBrush, out textColor, out font, ref label);

            var nodeControl = (Aga.Controls.Tree.NodeControls.BaseTextControl)this;
            osf.TreeViewAdv treeViewAdv = ((osf.TreeViewAdvEx)nodeControl.Parent).M_Object;
            if (treeViewAdv.SelectedNodes.Count == 1)
            {
                if (treeViewAdv.SelectedNodes[0] == node)
                {
                    if (this.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeComboBox) ||
                        this.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeDecimalTextBox) ||
                        this.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeNumericUpDown) ||
                        this.GetType() == typeof(Aga.Controls.Tree.NodeControls.NodeTextBox))
                    {
                        if (node == nodeControl.Parent.CurrentNode)
                        {
                            System.Collections.DictionaryEntry currentControl = treeViewAdv.CurrentControl;
                            if (currentControl.Value == this)
                            {
                                backgroundBrush = new SolidBrush(System.Drawing.Color.DodgerBlue);
                            }
                        }
                    }
                }
            }

            if (backgroundBrush != null)
            {
                context.Graphics.FillRectangle(backgroundBrush, focusRect);
            }
            if (context.DrawFocus)
            {
                focusRect.Width--;
                focusRect.Height--;
                if (context.DrawSelection == DrawSelectionMode.None)
                {
                    _focusPen.Color = SystemColors.ControlText;
                }
                else
                {
                    _focusPen.Color = SystemColors.InactiveCaption;
                }
                context.Graphics.DrawRectangle(_focusPen, focusRect);
            }

            if (UseCompatibleTextRendering)
            {
                TextRenderer.DrawText(context.Graphics, label, Font, bounds, textColor, _formatFlags);
            }
            else
            {
                context.Graphics.DrawString(label, Font, GetFrush(textColor), bounds, _format);
            }
        }

        private static Dictionary<Color, Brush> _brushes = new Dictionary<Color, Brush>();
        private static Brush GetFrush(Color color)
        {
            Brush br;
            if (_brushes.ContainsKey(color))
            {
                br = _brushes[color];
            }
            else
            {
                br = new SolidBrush(color);
                _brushes.Add(color, br);
            }
            return br;
        }

        // здесь можно задать цвет фона для всего узла
        private void CreateBrushes(TreeNodeAdv node, DrawContext context, string text, out Brush backgroundBrush, out Color textColor, out Font font, ref string label)
        {
            textColor = SystemColors.ControlText;
            backgroundBrush = null;
            font = context.Font;
            if (context.DrawSelection == DrawSelectionMode.Active)
            {
                textColor = SystemColors.HighlightText;
                backgroundBrush = SystemBrushes.Highlight;
                //backgroundBrush = System.Drawing.Brushes.Red;
            }
            else if (context.DrawSelection == DrawSelectionMode.Inactive)
            {
                textColor = SystemColors.ControlText;
                backgroundBrush = SystemBrushes.InactiveBorder;
            }
            else if (context.DrawSelection == DrawSelectionMode.FullRowSelect)
            {
                textColor = SystemColors.HighlightText;
            }

            if (!context.Enabled)
            {
                textColor = SystemColors.GrayText;
            }

            if (DrawTextMustBeFired(node))
            {
                DrawEventArgs args = new DrawEventArgs(node, this, context, text);
                args.Text = label;
                args.TextColor = textColor;
                args.BackgroundBrush = backgroundBrush;
                args.Font = font;

                OnDrawText(args);

                textColor = args.TextColor;
                backgroundBrush = args.BackgroundBrush;
                font = args.Font;
                label = args.Text;
            }
        }

        public string GetLabel(TreeNodeAdv node)
        {
            if (node != null && node.Tag != null)
            {
                object obj = GetValue(node);
                if (obj != null)
                {
                    return FormatLabel(obj);
                }
            }
            return string.Empty;
        }

        protected virtual string FormatLabel(object obj)
        {
            var res = obj.ToString();
            if (TrimMultiLine && res != null)
            {
                string[] parts = res.Split('\n');
                if (parts.Length > 1)
                {
                    return parts[0] + "...";
                }
            }
            return res;
        }

        public void SetLabel(TreeNodeAdv node, string value)
        {
            SetValue(node, value);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _focusPen.Dispose();
                _format.Dispose();
            }
        }

        // Срабатывает, когда элемент управления собирается нарисовать текст. Может использоваться для изменения текста или цвета задней панели.
        public event EventHandler<DrawEventArgs> DrawText;
        protected virtual void OnDrawText(DrawEventArgs args)
        {
            TreeViewAdv tree = args.Node.Tree;
            if (tree != null)
            {
                tree.FireDrawControl(args);
            }
            if (DrawText != null)
            {
                DrawText(this, args);
            }
        }

        protected virtual bool DrawTextMustBeFired(TreeNodeAdv node)
        {
            return DrawText != null || (node.Tree != null && node.Tree.DrawControlMustBeFired());
        }
    }

    public abstract class BindableControl : NodeControl
    {
        private struct MemberAdapter
        {
            private object _obj;
            private PropertyInfo _pi;
            private FieldInfo _fi;
            public static readonly MemberAdapter Empty = new MemberAdapter();

            public MemberAdapter(object obj, PropertyInfo pi)
            {
                _obj = obj;
                _pi = pi;
                _fi = null;
            }

            public MemberAdapter(object obj, FieldInfo fi)
            {
                _obj = obj;
                _fi = fi;
                _pi = null;
            }

            public MemberAdapter(object obj, dynamic value)
            {
                _obj = obj;
                _fi = null;
                _pi = null;

                this.Value = value;
            }




            public Type MemberType
            {
                get
                {
                    if (_pi != null)
                    {
                        return _pi.PropertyType;
                    }
                    else if (_fi != null)
                    {
                        return _fi.FieldType;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            public object Value
            {
                get
                {
                    if (_pi != null && _pi.CanRead)
                    {
                        return _pi.GetValue(_obj, null);
                    }
                    else if (_fi != null)
                    {
                        return _fi.GetValue(_obj);
                    }
                    else
                    {
                        return null;
                    }
                }
                set
                {
                    if (_pi != null && _pi.CanWrite)
                    {
                        _pi.SetValue(_obj, value, null);
                    }
                    else if (_fi != null)
                    {
                        _fi.SetValue(_obj, value);
                    }


                    //_obj.
                }
            }
        }

        private bool _virtualMode = false;
        [DefaultValue(false)]
        public bool VirtualMode
        {
            get { return _virtualMode; }
            set { _virtualMode = value; }
        }

        private string _propertyName = "";
        [DefaultValue("")]
        public string DataPropertyName
        {
            get { return _propertyName; }
            set
            {
                if (_propertyName == null)
                {
                    _propertyName = string.Empty;
                }
                _propertyName = value;
            }
        }

        private bool _incrementalSearchEnabled = false;
        [DefaultValue(false)]
        public bool IncrementalSearchEnabled
        {
            get { return _incrementalSearchEnabled; }
            set { _incrementalSearchEnabled = value; }
        }

        public virtual object GetValue(TreeNodeAdv node)
        {
            if (VirtualMode)
            {
                NodeControlValueEventArgs args = new NodeControlValueEventArgs(node);
                OnValueNeeded(args);
                return args.Value;
            }
            else
            {
                try
                {
                    return GetMemberAdapter(node).Value;
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException != null)
                    {
                        throw new ArgumentException(ex.InnerException.Message, ex.InnerException);
                    }
                    else
                    {
                        throw new ArgumentException(ex.Message);
                    }
                }
            }
        }

        public virtual void SetValue(TreeNodeAdv node, object value)
        {

            if (VirtualMode)
            {
                NodeControlValueEventArgs args = new NodeControlValueEventArgs(node);
                args.Value = value;
                OnValuePushed(args);
            }
            else
            {
                try
                {
                    MemberAdapter ma = GetMemberAdapter(node);
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException != null)
                    {
                        throw new ArgumentException(ex.InnerException.Message, ex.InnerException);
                    }
                    else
                    {
                        throw new ArgumentException(ex.Message);
                    }
                }
            }
        }

        public Type GetPropertyType(TreeNodeAdv node)
        {
            return GetMemberAdapter(node).MemberType;
        }

        private MemberAdapter GetMemberAdapter(TreeNodeAdv node)
        {
            if (node.Tag != null && !string.IsNullOrEmpty(DataPropertyName))
            {
                Type type = node.Tag.GetType();
                PropertyInfo pi = type.GetProperty(DataPropertyName);
                if (pi != null)
                {
                    return new MemberAdapter(node.Tag, pi);
                }
                else
                {
                    FieldInfo fi = type.GetField(DataPropertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    if (fi != null)
                    {
                        return new MemberAdapter(node.Tag, fi);
                    }
                }
            }
            return MemberAdapter.Empty;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(DataPropertyName))
            {
                return GetType().Name;
            }
            else
            {
                return string.Format("{0} ({1})", GetType().Name, DataPropertyName);
            }
        }

        public event EventHandler<NodeControlValueEventArgs> ValueNeeded;
        private void OnValueNeeded(NodeControlValueEventArgs args)
        {
            if (ValueNeeded != null)
            {
                ValueNeeded(this, args);
            }
        }

        public event EventHandler<NodeControlValueEventArgs> ValuePushed;
        private void OnValuePushed(NodeControlValueEventArgs args)
        {
            if (ValuePushed != null)
            {
                ValuePushed(this, args);
            }
        }
    }

    public class DrawEventArgs : NodeEventArgs
    {
        private DrawContext _context;
        public DrawContext Context
        {
            get { return _context; }
        }

        private Brush _textBrush;
        [Obsolete("Use TextColor")]
        public Brush TextBrush
        {
            get { return _textBrush; }
            set { _textBrush = value; }
        }

        private Brush _backgroundBrush;
        public Brush BackgroundBrush
        {
            get { return _backgroundBrush; }
            set { _backgroundBrush = value; }
        }

        private Font _font;
        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        private Color _textColor;
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private EditableControl _control;
        public EditableControl Control
        {
            get { return _control; }
        }

        public DrawEventArgs(TreeNodeAdv node, EditableControl control, DrawContext context, string text) : base(node)
        {
            _control = control;
            _context = context;
            _text = text;
        }
    }

    public abstract class EditableControl : InteractiveControl
    {
        private System.Windows.Forms.Timer _timer;
        private bool _editFlag;

        protected EditableControl()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += new EventHandler(TimerTick);
        }

        private bool _editOnClick = false;
        [DefaultValue(false)]
        public bool EditOnClick
        {
            get { return _editOnClick; }
            set { _editOnClick = value; }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _timer.Stop();
            if (_editFlag)
            {
                BeginEdit();
            }
            _editFlag = false;
        }

        public void SetEditorBounds(EditorContext context)
        {
            Size size = CalculateEditorSize(context);
            context.Editor.Bounds = new Rectangle(context.Bounds.X, context.Bounds.Y, Math.Min(size.Width, context.Bounds.Width), Math.Min(size.Height, Parent.ClientSize.Height - context.Bounds.Y));
        }

        protected abstract Size CalculateEditorSize(EditorContext context);

        protected virtual bool CanEdit(TreeNodeAdv node)
        {
            return (node.Tag != null) && IsEditEnabled(node);
        }

        public void BeginEdit()
        {
            if (Parent != null && Parent.CurrentNode != null && CanEdit(Parent.CurrentNode))
            {
                CancelEventArgs args = new CancelEventArgs();
                OnEditorShowing(args);
                if (!args.Cancel)
                {
                    var editor = CreateEditor(Parent.CurrentNode);
                    Parent.DisplayEditor(editor, this);
                }
            }
        }

        public void EndEdit(bool applyChanges)
        {
            if (Parent != null)
            {
                if (Parent.HideEditor(applyChanges))
                {
                    OnEditorHided();
                }
            }
        }

        public virtual void UpdateEditor(Control control)
        {
        }

        internal void ApplyChanges(TreeNodeAdv node, Control editor)
        {
            DoApplyChanges(node, editor);
            OnChangesApplied();
        }

        internal void DoDisposeEditor(Control editor)
        {
            DisposeEditor(editor);
        }

        protected abstract void DoApplyChanges(TreeNodeAdv node, Control editor);
        protected abstract Control CreateEditor(TreeNodeAdv node);
        protected abstract void DisposeEditor(Control editor);

        public virtual void Cut(Control control)
        {
        }

        public virtual void Copy(Control control)
        {
        }

        public virtual void Paste(Control control)
        {
        }

        public virtual void Delete(Control control)
        {
        }

        public override void MouseDown(TreeNodeAdvMouseEventArgs args)
        {
            _editFlag = (!EditOnClick && args.Button == MouseButtons.Left && args.ModifierKeys == Keys.None && args.Node.IsSelected);
        }

        public override void MouseUp(TreeNodeAdvMouseEventArgs args)
        {
            if (args.Node.IsSelected)
            {
                if (EditOnClick && args.Button == MouseButtons.Left && args.ModifierKeys == Keys.None)
                {
                    Parent.ItemDragMode = false;
                    BeginEdit();
                    args.Handled = true;
                }
                else if (_editFlag) // && args.Node.IsSelected)
                {
                    _timer.Start();
                }
            }
        }

        public override void MouseDoubleClick(TreeNodeAdvMouseEventArgs args)
        {
            _editFlag = false;
            _timer.Stop();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _timer.Dispose();
            }
        }

        public event CancelEventHandler EditorShowing;
        protected void OnEditorShowing(CancelEventArgs args)
        {
            if (EditorShowing != null)
            {
                EditorShowing(this, args);
            }
        }

        public event EventHandler EditorHided;
        protected void OnEditorHided()
        {
            if (EditorHided != null)
            {
                EditorHided(this, EventArgs.Empty);
            }
        }

        public event EventHandler ChangesApplied;
        protected void OnChangesApplied()
        {
            if (ChangesApplied != null)
            {
                ChangesApplied(this, EventArgs.Empty);
            }
        }
    }

    public class EditEventArgs : NodeEventArgs
    {
        private Control _control;
        public Control Control
        {
            get { return _control; }
        }

        public EditEventArgs(TreeNodeAdv node, Control control) : base(node)
        {
            _control = control;
        }
    }

    public class ExpandingIcon : NodeControl
    {
        // Отображает анимированный значок для тех узлов, которые находятся в развернутом состоянии. 
        // Родительский TreeView должен иметь свойство AsyncExpanding, равное true.

        private static GifDecoder _gif = Aga.Controls.Tree.TreeViewAdv.LoadingIcon;
        private static int _index = 0;
        private static volatile Thread _animatingThread;
        private static object _lock = new object();

        public override Size MeasureSize(TreeNodeAdv node, DrawContext context)
        {
            return Aga.Controls.Tree.TreeViewAdv.LoadingIcon.FrameSize;
        }

        protected override void OnIsVisibleValueNeeded(NodeControlValueEventArgs args)
        {
            args.Value = args.Node.IsExpandingNow;
            base.OnIsVisibleValueNeeded(args);
        }

        public override void Draw(TreeNodeAdv node, DrawContext context)
        {
            Rectangle rect = GetBounds(node, context);
            Image img = _gif.GetFrame(_index).Image;
            context.Graphics.DrawImage(img, rect.Location);
        }

        public static void Start()
        {
            lock (_lock)
            {
                if (_animatingThread == null)
                {
                    _index = 0;
                    _animatingThread = new Thread(new ThreadStart(IterateIcons));
                    _animatingThread.IsBackground = true;
                    _animatingThread.Priority = ThreadPriority.Lowest;
                    _animatingThread.Start();
                }
            }
        }

        public static void Stop()
        {
            lock (_lock)
            {
                _index = 0;
                _animatingThread = null;
            }
        }

        private static void IterateIcons()
        {
            while (_animatingThread != null)
            {
                if (_index < _gif.FrameCount - 1)
                {
                    _index++;
                }
                else
                {
                    _index = 0;
                }

                if (IconChanged != null)
                {
                    IconChanged(null, EventArgs.Empty);
                }

                int delay = _gif.GetFrame(_index).Delay;
                Thread.Sleep(delay);
            }
            System.Diagnostics.Debug.WriteLine("IterateIcons Stopped");
        }

        public static event EventHandler IconChanged;
    }

    public abstract class InteractiveControl : BindableControl
    {
        private bool _editEnabled = false;
        [DefaultValue(false)]
        public bool EditEnabled
        {
            get { return _editEnabled; }
            set { _editEnabled = value; }
        }

        protected bool IsEditEnabled(TreeNodeAdv node)
        {
            if (EditEnabled)
            {
                NodeControlValueEventArgs args = new NodeControlValueEventArgs(node);
                args.Value = true;
                OnIsEditEnabledValueNeeded(args);
                return Convert.ToBoolean(args.Value);
            }
            else
            {
                return false;
            }
        }

        public event EventHandler<NodeControlValueEventArgs> IsEditEnabledValueNeeded;

        private void OnIsEditEnabledValueNeeded(NodeControlValueEventArgs args)
        {
            if (IsEditEnabledValueNeeded != null)
            {
                IsEditEnabledValueNeeded(this, args);
            }
        }
    }

    public class LabelEventArgs : EventArgs
    {
        private object _subject;
        private object _oldLabel;
        private object _newLabel;

        public LabelEventArgs(object subject, object oldLabel, object newLabel)
        {
            _subject = subject;
            _oldLabel = oldLabel;
            _newLabel = newLabel;
        }

        public object Subject
        {
            get { return _subject; }
        }

        public object OldLabel
        {
            get { return _oldLabel; }
        }

        public object NewLabel
        {
            get { return _newLabel; }
        }
    }

    public abstract class NodeControl : Component
    {
        public Dictionary<osf.ClToolTip, object> ObjTooltip = new Dictionary<osf.ClToolTip, object>();
		
        private object _tooltipText = "";
        public object TooltipText
        {
            get { return _tooltipText; }
            set { _tooltipText = value; }
        }

        private TreeViewAdv _parent;
        public TreeViewAdv Parent
        {
            get { return _parent; }
            set
            {
                if (value != _parent)
                {
                    if (_parent != null)
                    {
                        _parent.NodeControls.Remove(this);
                    }
                    if (value != null)
                    {
                        value.NodeControls.Add(this);
                        _parent = value;
                    }
                }
            }
        }

        private IToolTipProvider _toolTipProvider;
        public IToolTipProvider ToolTipProvider
        {
            get { return _toolTipProvider; }
            set { _toolTipProvider = value; }
        }

        private TreeColumn _parentColumn;
        public TreeColumn ParentColumn
        {
            get { return _parentColumn; }
            set
            {
                _parentColumn = value;
                if (_parent != null)
                {
                    _parent.FullUpdate();
                }
            }
        }

        private VerticalAlignment _verticalAlign = VerticalAlignment.Center;
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment VerticalAlign
        {
            get { return _verticalAlign; }
            set
            {
                _verticalAlign = value;
                if (_parent != null)
                {
                    _parent.FullUpdate();
                }
            }
        }

        private int _leftMargin = 0;
        public int LeftMargin
        {
            get { return _leftMargin; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _leftMargin = value;
                if (_parent != null)
                {
                    _parent.FullUpdate();
                }
            }
        }

        internal virtual void AssignParent(TreeViewAdv parent)
        {
            _parent = parent;
        }

        protected virtual Rectangle GetBounds(TreeNodeAdv node, DrawContext context)
        {
            Rectangle r = context.Bounds;
            Size s = GetActualSize(node, context);
            Size bs = new Size(r.Width - LeftMargin, Math.Min(r.Height, s.Height));
            switch (VerticalAlign)
            {
                case VerticalAlignment.Top:
                    return new Rectangle(new Point(r.X + LeftMargin, r.Y), bs);
                case VerticalAlignment.Bottom:
                    return new Rectangle(new Point(r.X + LeftMargin, r.Bottom - s.Height), bs);
                default:
                    return new Rectangle(new Point(r.X + LeftMargin, r.Y + (r.Height - s.Height) / 2), bs);
            }
        }

        protected void CheckThread()
        {
            if (Parent != null && Control.CheckForIllegalCrossThreadCalls)
            {
                if (Parent.InvokeRequired)
                {
                    throw new InvalidOperationException("Cross-thread calls are not allowed");
                }
            }
        }

        public bool IsVisible(TreeNodeAdv node)
        {
            NodeControlValueEventArgs args = new NodeControlValueEventArgs(node);
            args.Value = true;
            OnIsVisibleValueNeeded(args);
            return Convert.ToBoolean(args.Value);
        }

        internal Size GetActualSize(TreeNodeAdv node, DrawContext context)
        {
            if (IsVisible(node))
            {
                Size s = MeasureSize(node, context);
                return new Size(s.Width + LeftMargin, s.Height);
            }
            else
            {
                return Size.Empty;
            }
        }

        public abstract Size MeasureSize(TreeNodeAdv node, DrawContext context);
        public abstract void Draw(TreeNodeAdv node, DrawContext context);

        public virtual string GetToolTip(TreeNodeAdv node)
        {
            if (ToolTipProvider != null)
            {
                return ToolTipProvider.GetToolTip(node, this);
            }
            else
            {
                return string.Empty;
            }
        }

        public virtual void MouseDown(TreeNodeAdvMouseEventArgs args)
        {
        }

        public virtual void MouseUp(TreeNodeAdvMouseEventArgs args)
        {
        }

        public virtual void MouseDoubleClick(TreeNodeAdvMouseEventArgs args)
        {
        }

        public virtual void KeyDown(KeyEventArgs args)
        {
        }

        public virtual void KeyUp(KeyEventArgs args)
        {
        }

        public event EventHandler<NodeControlValueEventArgs> IsVisibleValueNeeded;
        protected virtual void OnIsVisibleValueNeeded(NodeControlValueEventArgs args)
        {
            if (IsVisibleValueNeeded != null)
            {
                IsVisibleValueNeeded(this, args);
            }
        }
    }

    public class NodeControlValueEventArgs : NodeEventArgs
    {
        private object _value;
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public NodeControlValueEventArgs(TreeNodeAdv node) : base(node)
        {
        }
    }

    public class NodeEventArgs : EventArgs
    {
        private TreeNodeAdv _node;
        public TreeNodeAdv Node
        {
            get { return _node; }
        }

        public NodeEventArgs(TreeNodeAdv node)
        {
            _node = node;
        }
    }

    public class NodeIcon : BindableControl
    {
        public NodeIcon()
        {
            LeftMargin = 1;
        }

        public override Size MeasureSize(TreeNodeAdv node, DrawContext context)
        {
            Image image = GetIcon(node);
            if (image != null)
            {
                return image.Size;
            }
            else
            {
                return Size.Empty;
            }
        }

        public override void Draw(TreeNodeAdv node, DrawContext context)
        {
            Image image = GetIcon(node);
            if (image != null)
            {
                Rectangle r = GetBounds(node, context);
                if (image.Width > 0 && image.Height > 0)
                {
                    float f = (float)(image.Height - node.Tree.RowHeight) / 2;
                    switch (_scaleMode)
                    {
                        case ImageScaleMode.Fit:
                            {
                                r.Y = r.Y + Convert.ToInt32(f);
                                r.Height = node.Tree.RowHeight;
                                context.Graphics.DrawImage(image, r);
                            }
                            break;
                        case ImageScaleMode.AlwaysScale:
                            {
                                float fh = (float)node.Tree.RowHeight / (float)image.Height;
                                if (node.Tree.RowHeight > image.Height) // высота строки больше высоты рисунка - увеличиваем рисунок
                                {
                                    context.Graphics.DrawImage(image, r.X, r.Y + f, image.Width * fh, image.Height * fh);
                                }
                                else if (node.Tree.RowHeight < image.Height) // высота строки меньше высоты рисунка - уменьшаем рисунок
                                {
                                    context.Graphics.DrawImage(image, r.X, r.Y + f, image.Width * fh, image.Height * fh);
                                }
                                else // не масштабируем
                                {
                                    context.Graphics.DrawImage(image, r.X, r.Y, image.Width, image.Height);
                                }
                            }
                            break;
                        case ImageScaleMode.Clip:
                        default:
                            context.Graphics.DrawImage(image, r.X, r.Y, image.Width, image.Height);
                            break;
                    }
                }
            }
        }

        protected virtual Image GetIcon(TreeNodeAdv node)
        {
            return GetValue(node) as Image;
        }

        private ImageScaleMode _scaleMode = ImageScaleMode.AlwaysScale;
        public ImageScaleMode ScaleMode
        {
            get { return _scaleMode; }
            set { _scaleMode = value; }
        }
    }

    public class NodeIntegerTextBox : NodeTextBox
    {
        private bool _allowNegativeSign = true;
        [DefaultValue(true)]
        public bool AllowNegativeSign
        {
            get { return _allowNegativeSign; }
            set { _allowNegativeSign = value; }
        }

        public NodeIntegerTextBox()
        {
        }

        protected override TextBox CreateTextBox()
        {
            NumericTextBox textBox = new NumericTextBox();
            textBox.AllowDecimalSeparator = false;
            textBox.AllowNegativeSign = AllowNegativeSign;
            return textBox;
        }

        protected override void DoApplyChanges(TreeNodeAdv node, Control editor)
        {
            SetValue(node, (editor as NumericTextBox).IntValue);
        }
    }

    internal class NodePlusMinus : NodeControl
    {
        public const int ImageSize = 9;
        public const int Width = 16;
        private Bitmap _plus;
        private Bitmap _minus;

        private VisualStyleRenderer _openedRenderer;
        private VisualStyleRenderer OpenedRenderer
        {
            get
            {
                if (_openedRenderer == null)
                {
                    _openedRenderer = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened);
                }
                return _openedRenderer;
            }
        }

        private VisualStyleRenderer _closedRenderer;
        private VisualStyleRenderer ClosedRenderer
        {
            get
            {
                if (_closedRenderer == null)
                {
                    _closedRenderer = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Closed);
                }
                return _closedRenderer;
            }
        }

        public NodePlusMinus()
        {
            _plus = new Bitmap(new MemoryStream(Convert.FromBase64String("Qk0yAQAAAAAAADYAAAAoAAAACQAAAAkAAAABABgAAAAAAPwAAAAAAAAAAAAAAAAAAAAAAAAAfWVPfWVPfWVPfWVPfWVPfWVPfWVPfWVPfWVPAH1lT////////////////////////////31lTwB9ZU////////////8AAAD///////////99ZU8AfWVP////////////AAAA////////////fWVPAH1lT////wAAAAAAAAAAAAAAAAAAAP///31lTwB9ZU////////////8AAAD///////////99ZU8AfWVP////////////AAAA////////////fWVPAH1lT////////////////////////////31lTwB9ZU99ZU99ZU99ZU99ZU99ZU99ZU99ZU99ZU8A")));
            _minus = new Bitmap(new MemoryStream(Convert.FromBase64String("Qk0yAQAAAAAAADYAAAAoAAAACQAAAAkAAAABABgAAAAAAPwAAAAAAAAAAAAAAAAAAAAAAAAAfWVPfWVPfWVPfWVPfWVPfWVPfWVPfWVPfWVPAH1lT////////////////////////////31lTwB9ZU////////////////////////////99ZU8AfWVP////////////////////////////fWVPAH1lT////wAAAAAAAAAAAAAAAAAAAP///31lTwB9ZU////////////////////////////99ZU8AfWVP////////////////////////////fWVPAH1lT////////////////////////////31lTwB9ZU99ZU99ZU99ZU99ZU99ZU99ZU99ZU99ZU8A")));
        }

        public override Size MeasureSize(TreeNodeAdv node, DrawContext context)
        {
            return new Size(Width, Width);
        }

        public override void Draw(TreeNodeAdv node, DrawContext context)
        {
            if (node.CanExpand)
            {
                Rectangle r = context.Bounds;
                int dy = (int)Math.Round((float)(r.Height - ImageSize) / 2);
                if (Application.RenderWithVisualStyles)
                {
                    VisualStyleRenderer renderer;
                    if (node.IsExpanded)
                    {
                        renderer = OpenedRenderer;
                    }
                    else
                    {
                        renderer = ClosedRenderer;
                    }
                    renderer.DrawBackground(context.Graphics, new Rectangle(r.X, r.Y + dy, ImageSize, ImageSize));
                }
                else
                {
                    Image img;
                    if (node.IsExpanded)
                    {
                        img = _minus;
                    }
                    else
                    {
                        img = _plus;
                    }
                    context.Graphics.DrawImageUnscaled(img, new Point(r.X, r.Y + dy));
                }
            }
        }

        public override void MouseDown(TreeNodeAdvMouseEventArgs args)
        {
            if (args.Button == MouseButtons.Left)
            {
                args.Handled = true;
                if (args.Node.CanExpand)
                {
                    args.Node.IsExpanded = !args.Node.IsExpanded;
                }
            }
        }

        public override void MouseDoubleClick(TreeNodeAdvMouseEventArgs args)
        {
            args.Handled = true; // Подавление разворачивания/сворачивания при двойном щелчке на плюс/минус
        }
    }
}

    #endregion Aga.Controls.Tree.NodeControls

    #region Aga.Controls.Tree

namespace Aga.Controls.Tree
{
    internal interface IHeaderLayout
    {
        int PreferredHeaderHeight { get; set; }
        void ClearCache();
    }

    internal class FixedHeaderHeightLayout : IHeaderLayout
    {
        private TreeViewAdv _treeView;
        private int _headerHeight;

        public FixedHeaderHeightLayout(TreeViewAdv treeView, int headerHeight)
        {
            _treeView = treeView;
            PreferredHeaderHeight = headerHeight;
        }

        public int PreferredHeaderHeight
        {
            get { return _headerHeight; }
            set { _headerHeight = value; }
        }

        public void ClearCache()
        {
        }
    }

    public class AutoHeaderHeightLayout : IHeaderLayout
    {
        private DrawContext _measureContext;
        private TreeViewAdv _treeView;
        private int? _headerHeight;
        private bool _computed;

        public AutoHeaderHeightLayout(TreeViewAdv treeView, int headerHeight)
        {
            _treeView = treeView;
            PreferredHeaderHeight = headerHeight;
            _measureContext = new DrawContext();
            _measureContext.Graphics = Graphics.FromImage((Image)new Bitmap(1, 1));
        }

        public int PreferredHeaderHeight
        {
            get { return GetHeaderHeight(); }
            set
            {
                _headerHeight = new int?(value);
                _computed = false;
            }
        }

        public void ClearCache()
        {
            _computed = false;
        }

        private int GetHeaderHeight()
        {
            if (!_computed)
            {
                int num = 0;
                _measureContext.Font = _treeView.Font;
                foreach (TreeColumn column in _treeView.Columns)
                {
                    int height = column.GetActualSize(_measureContext).Height;
                    if (height > num)
                    {
                        num = height;
                    }
                }
                _headerHeight = new int?(num);
                _computed = true;
            }
            return _headerHeight.Value;
        }
    }
		
    public class TreeViewAdvCancelEventArgs : TreeViewAdvEventArgs
    {
        private bool _cancel;

        public TreeViewAdvCancelEventArgs(TreeNodeAdv node) : base(node)
        {
        }

        public bool Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }
    }

    public class TreeViewAdvEventArgs : EventArgs
    {
        private TreeNodeAdv _node;

        public TreeNodeAdv Node
        {
            get { return _node; }
        }

        public TreeViewAdvEventArgs(TreeNodeAdv node)
        {
            _node = node;
        }
    }

    public class TreeViewRowDrawEventArgs : PaintEventArgs
    {
        TreeNodeAdv _node;
        DrawContext _context;
        int _row;
        Rectangle _rowRect;

        public TreeViewRowDrawEventArgs(Graphics graphics, Rectangle clipRectangle, TreeNodeAdv node, DrawContext context, int row, Rectangle rowRect) : base(graphics, clipRectangle)
        {
            _node = node;
            _context = context;
            _row = row;
            _rowRect = rowRect;
        }

        public TreeNodeAdv Node
        {
            get { return _node; }
        }

        public DrawContext Context
        {
            get { return _context; }
        }

        public int Row
        {
            get { return _row; }
        }

        public Rectangle RowRect
        {
            get { return _rowRect; }
        }
    }

    internal class ClickColumnState : ColumnState
    {
        private Point _location;

        public ClickColumnState(TreeViewAdv tree, TreeColumn column, Point location) : base(tree, column)
        {
            _location = location;
        }

        public override void KeyDown(KeyEventArgs args)
        {
        }

        public override void MouseDown(TreeNodeAdvMouseEventArgs args)
        {
        }

        public override bool MouseMove(MouseEventArgs args)
        {
            if (TreeViewAdv.Dist(_location, args.Location) > TreeViewAdv.ItemDragSensivity && Tree.AllowColumnReorder)
            {
                Tree.Input = new ReorderColumnState(Tree, Column, args.Location);
                Tree.UpdateView();
            }
            return true;
        }

        public override void MouseUp(TreeNodeAdvMouseEventArgs args)
        {
            Tree.ChangeInput();
            Tree.UpdateView();
            Tree.OnColumnClicked(Column);
        }
    }

    internal abstract class ColumnState : InputState
    {
        private TreeColumn _column;
        public TreeColumn Column
        {
            get { return _column; }
        }

        public ColumnState(TreeViewAdv tree, TreeColumn column) : base(tree)
        {
            _column = column;
        }
    }

    internal abstract class InputState
    {
        private TreeViewAdv _tree;

        public TreeViewAdv Tree
        {
            get { return _tree; }
        }

        public InputState(TreeViewAdv tree)
        {
            _tree = tree;
        }

        public abstract void KeyDown(System.Windows.Forms.KeyEventArgs args);
        public abstract void MouseDown(TreeNodeAdvMouseEventArgs args);
        public abstract void MouseUp(TreeNodeAdvMouseEventArgs args);

        // Обработайте событие OnMouseMove.
        // true, если событие было обработано и должно быть отправлено.
        public virtual bool MouseMove(MouseEventArgs args)
        {
            return false;
        }

        public virtual void MouseDoubleClick(TreeNodeAdvMouseEventArgs args)
        {
        }
    }

    internal class InputWithControl : NormalInputState
    {
        public InputWithControl(TreeViewAdv tree) : base(tree)
        {
        }

        protected override void DoMouseOperation(TreeNodeAdvMouseEventArgs args)
        {
            if (Tree.SelectionMode == TreeSelectionMode.Single)
            {
                base.DoMouseOperation(args);
            }
            else if (CanSelect(args.Node))
            {
                args.Node.IsSelected = !args.Node.IsSelected;
                Tree.SelectionStart = args.Node;
            }
        }

        protected override void MouseDownAtEmptySpace(TreeNodeAdvMouseEventArgs args)
        {
        }
    }

    internal class InputWithShift : NormalInputState
    {
        public InputWithShift(TreeViewAdv tree) : base(tree)
        {
        }

        protected override void FocusRow(TreeNodeAdv node)
        {
            Tree.SuspendSelectionEvent = true;
            try
            {
                if (Tree.SelectionMode == TreeSelectionMode.Single || Tree.SelectionStart == null)
                {
                    base.FocusRow(node);
                }
                else if (CanSelect(node))
                {
                    SelectAllFromStart(node);
                    Tree.CurrentNode = node;
                    Tree.ScrollTo(node);
                }
            }
            finally
            {
                Tree.SuspendSelectionEvent = false;
            }
        }

        protected override void DoMouseOperation(TreeNodeAdvMouseEventArgs args)
        {
            if (Tree.SelectionMode == TreeSelectionMode.Single || Tree.SelectionStart == null)
            {
                base.DoMouseOperation(args);
            }
            else if (CanSelect(args.Node))
            {
                Tree.SuspendSelectionEvent = true;
                try
                {
                    SelectAllFromStart(args.Node);
                }
                finally
                {
                    Tree.SuspendSelectionEvent = false;
                }
            }
        }

        protected override void MouseDownAtEmptySpace(TreeNodeAdvMouseEventArgs args)
        {
        }

        private void SelectAllFromStart(TreeNodeAdv node)
        {
            Tree.ClearSelectionInternal();
            int a = node.Row;
            int b = Tree.SelectionStart.Row;
            for (int i = Math.Min(a, b); i <= Math.Max(a, b); i++)
            {
                if (Tree.SelectionMode == TreeSelectionMode.Multi || Tree.RowMap[i].Parent == node.Parent)
                {
                    Tree.RowMap[i].IsSelected = true;
                }
            }
        }
    }

    internal class NormalInputState : InputState
    {
        private bool _mouseDownFlag = false;

        public NormalInputState(TreeViewAdv tree) : base(tree)
        {
        }

        public override void KeyDown(KeyEventArgs args)
        {
            if (Tree.CurrentNode == null && Tree.Root.Nodes.Count > 0)
            {
                Tree.CurrentNode = Tree.Root.Nodes[0];
            }

            if (Tree.CurrentNode != null)
            {
                switch (args.KeyCode)
                {
                    case Keys.Right:
                        if (!Tree.CurrentNode.IsExpanded)
                        {
                            Tree.CurrentNode.IsExpanded = true;
                        }
                        else if (Tree.CurrentNode.Nodes.Count > 0)
                        {
                            Tree.SelectedNode = Tree.CurrentNode.Nodes[0];
                        }
                        args.Handled = true;
                        break;
                    case Keys.Left:
                        if (Tree.CurrentNode.IsExpanded)
                        {
                            Tree.CurrentNode.IsExpanded = false;
                        }
                        else if (Tree.CurrentNode.Parent != Tree.Root)
                        {
                            Tree.SelectedNode = Tree.CurrentNode.Parent;
                        }
                        args.Handled = true;
                        break;
                    case Keys.Down:
                        NavigateForward(1);
                        args.Handled = true;
                        break;
                    case Keys.Up:
                        NavigateBackward(1);
                        args.Handled = true;
                        break;
                    case Keys.PageDown:
                        NavigateForward(Math.Max(1, Tree.CurrentPageSize - 1));
                        args.Handled = true;
                        break;
                    case Keys.PageUp:
                        NavigateBackward(Math.Max(1, Tree.CurrentPageSize - 1));
                        args.Handled = true;
                        break;
                    case Keys.Home:
                        if (Tree.RowMap.Count > 0)
                        {
                            FocusRow(Tree.RowMap[0]);
                        }
                        args.Handled = true;
                        break;
                    case Keys.End:
                        if (Tree.RowMap.Count > 0)
                        {
                            FocusRow(Tree.RowMap[Tree.RowMap.Count - 1]);
                        }
                        args.Handled = true;
                        break;
                    case Keys.Subtract:
                        Tree.CurrentNode.Collapse();
                        args.Handled = true;
                        args.SuppressKeyPress = true;
                        break;
                    case Keys.Add:
                        Tree.CurrentNode.Expand();
                        args.Handled = true;
                        args.SuppressKeyPress = true;
                        break;
                    case Keys.Multiply:
                        Tree.CurrentNode.ExpandAll();
                        args.Handled = true;
                        args.SuppressKeyPress = true;
                        break;
                    case Keys.A:
                        if (args.Modifiers == Keys.Control)
                        {
                            Tree.SelectAllNodes();
                        }
                        break;
                }
            }
        }

        public override void MouseDown(TreeNodeAdvMouseEventArgs args)
        {
            if (args.Node != null)
            {
                Tree.ItemDragMode = true;
                Tree.ItemDragStart = args.Location;

                if (args.Button == MouseButtons.Left || args.Button == MouseButtons.Right)
                {
                    Tree.BeginUpdate();
                    try
                    {
                        Tree.CurrentNode = args.Node;
                        if (args.Node.IsSelected)
                        {
                            _mouseDownFlag = true;
                        }
                        else
                        {
                            _mouseDownFlag = false;
                            DoMouseOperation(args);
                        }
                    }
                    finally
                    {
                        Tree.EndUpdate();
                    }
                }
            }
            else
            {
                Tree.ItemDragMode = false;
                MouseDownAtEmptySpace(args);
            }
        }

        public override void MouseUp(TreeNodeAdvMouseEventArgs args)
        {
            Tree.ItemDragMode = false;
            if (_mouseDownFlag && args.Node != null)
            {
                if (args.Button == MouseButtons.Left)
                {
                    DoMouseOperation(args);
                }
                else if (args.Button == MouseButtons.Right)
                {
                    Tree.CurrentNode = args.Node;
                }
            }
            _mouseDownFlag = false;
        }

        private void NavigateBackward(int n)
        {
            int row = Math.Max(Tree.CurrentNode.Row - n, 0);
            if (row != Tree.CurrentNode.Row)
            {
                FocusRow(Tree.RowMap[row]);
            }
        }

        private void NavigateForward(int n)
        {
            int row = Math.Min(Tree.CurrentNode.Row + n, Tree.RowCount - 1);
            if (row != Tree.CurrentNode.Row)
            {
                FocusRow(Tree.RowMap[row]);
            }
        }

        protected virtual void MouseDownAtEmptySpace(TreeNodeAdvMouseEventArgs args)
        {
            Tree.ClearSelection();
        }

        protected virtual void FocusRow(TreeNodeAdv node)
        {
            Tree.SuspendSelectionEvent = true;
            try
            {
                Tree.ClearSelectionInternal();
                Tree.CurrentNode = node;
                Tree.SelectionStart = node;
                node.IsSelected = true;
                Tree.ScrollTo(node);
            }
            finally
            {
                Tree.SuspendSelectionEvent = false;
            }
        }

        protected bool CanSelect(TreeNodeAdv node)
        {
            if (Tree.SelectionMode == TreeSelectionMode.MultiSameParent)
            {
                return (Tree.SelectionStart == null || node.Parent == Tree.SelectionStart.Parent);
            }
            else
            {
                return true;
            }
        }

        protected virtual void DoMouseOperation(TreeNodeAdvMouseEventArgs args)
        {
            if (Tree.SelectedNodes.Count == 1 && args.Node != null && args.Node.IsSelected)
            {
                return;
            }

            Tree.SuspendSelectionEvent = true;
            try
            {
                Tree.ClearSelectionInternal();
                if (args.Node != null)
                {
                    args.Node.IsSelected = true;
                }
                Tree.SelectionStart = args.Node;
            }
            finally
            {
                Tree.SuspendSelectionEvent = false;
            }
        }
    }

    internal class ReorderColumnState : ColumnState
    {
        private Point _location;
        public Point Location
        {
            get { return _location; }
        }

        private Bitmap _ghostImage;
        public Bitmap GhostImage
        {
            get { return _ghostImage; }
        }

        private TreeColumn _dropColumn;
        public TreeColumn DropColumn
        {
            get { return _dropColumn; }
        }

        private int _dragOffset;
        public int DragOffset
        {
            get { return _dragOffset; }
        }

        public ReorderColumnState(TreeViewAdv tree, TreeColumn column, Point initialMouseLocation) : base(tree, column)
        {
            _location = new Point(initialMouseLocation.X + Tree.OffsetX, 0);
            _dragOffset = tree.GetColumnX(column) - initialMouseLocation.X;
            _ghostImage = column.CreateGhostImage(new Rectangle(0, 0, column.Width, tree.ColumnHeaderHeight), tree.Font);
        }

        public override void KeyDown(KeyEventArgs args)
        {
            args.Handled = true;
            if (args.KeyCode == Keys.Escape)
            {
                FinishResize();
            }
        }

        public override void MouseDown(TreeNodeAdvMouseEventArgs args)
        {
        }

        public override void MouseUp(TreeNodeAdvMouseEventArgs args)
        {
            FinishResize();
        }

        public override bool MouseMove(MouseEventArgs args)
        {
            _dropColumn = null;
            _location = new Point(args.X + Tree.OffsetX, 0);
            int x = 0;
            foreach (TreeColumn c in Tree.Columns)
            {
                if (c.IsVisible)
                {
                    if (_location.X < x + c.Width / 2)
                    {
                        _dropColumn = c;
                        break;
                    }
                    x += c.Width;
                }
            }
            Tree.UpdateHeaders();
            return true;
        }

        private void FinishResize()
        {
            Tree.ChangeInput();
            if (Column == DropColumn)
            {
                Tree.UpdateView();
            }
            else
            {
                Tree.Columns.Remove(Column);
                if (DropColumn == null)
                {
                    Tree.Columns.Add(Column);
                }
                else
                {
                    Tree.Columns.Insert(Tree.Columns.IndexOf(DropColumn), Column);
                }
                Tree.OnColumnReordered(Column);
            }
        }
    }

    internal class ResizeColumnState : ColumnState
    {
        private Point _initLocation;
        private int _initWidth;

        public ResizeColumnState(TreeViewAdv tree, TreeColumn column, Point p) : base(tree, column)
        {
            _initLocation = p;
            _initWidth = column.Width;
        }

        public override void KeyDown(KeyEventArgs args)
        {
            args.Handled = true;
            if (args.KeyCode == Keys.Escape)
            {
                FinishResize();
            }
        }

        public override void MouseDown(TreeNodeAdvMouseEventArgs args)
        {
        }

        public override void MouseUp(TreeNodeAdvMouseEventArgs args)
        {
            FinishResize();
        }

        private void FinishResize()
        {
            Tree.ChangeInput();
            Tree.FullUpdate();
            Tree.OnColumnWidthChanged(Column);
        }

        public override bool MouseMove(MouseEventArgs args)
        {
            Column.Width = _initWidth + args.Location.X - _initLocation.X;
            Tree.UpdateView();
            return true;
        }

        public override void MouseDoubleClick(TreeNodeAdvMouseEventArgs args)
        {
            Tree.AutoSizeColumn(Column);
        }
    }

    public class AutoRowHeightLayout : IRowLayout
    {
        private DrawContext _measureContext;
        private TreeViewAdv _treeView;
        private List<Rectangle> _rowCache;
        private int _rowHeight;

        public AutoRowHeightLayout(TreeViewAdv treeView, int rowHeight)
        {
            _rowCache = new List<Rectangle>();
            _treeView = treeView;
            PreferredRowHeight = rowHeight;
            _measureContext = new DrawContext();
            _measureContext.Graphics = Graphics.FromImage(new Bitmap(1, 1));
        }

        public int PreferredRowHeight
        {
            get { return _rowHeight; }
            set { _rowHeight = value; }
        }

        public int PageRowCount
        {
            get
            {
                if (_treeView.RowCount == 0)
                {
                    return 0;
                }
                else
                {
                    int pageHeight = _treeView.DisplayRectangle.Height - _treeView.ColumnHeaderHeight;
                    int y = 0;
                    for (int i = _treeView.RowCount - 1; i >= 0; i--)
                    {
                        y += GetRowHeight(i);
                        if (y > pageHeight)
                        {
                            return Math.Max(0, _treeView.RowCount - 1 - i);
                        }
                    }
                    return _treeView.RowCount;
                }
            }
        }

        public int CurrentPageSize
        {
            get
            {
                if (_treeView.RowCount == 0)
                {
                    return 0;
                }
                else
                {
                    int pageHeight = _treeView.DisplayRectangle.Height - _treeView.ColumnHeaderHeight;
                    int y = 0;
                    for (int i = _treeView.FirstVisibleRow; i < _treeView.RowCount; i++)
                    {
                        y += GetRowHeight(i);
                        if (y > pageHeight)
                        {
                            return Math.Max(0, i - _treeView.FirstVisibleRow);
                        }
                    }
                    return Math.Max(0, _treeView.RowCount - _treeView.FirstVisibleRow);
                }
            }
        }

        public Rectangle GetRowBounds(int rowNo)
        {
            if (rowNo >= _rowCache.Count)
            {
                int count = _rowCache.Count;
                int y = count > 0 ? _rowCache[count - 1].Bottom : 0;
                for (int i = count; i <= rowNo; i++)
                {
                    int height = GetRowHeight(i);
                    _rowCache.Add(new Rectangle(0, y, 0, height));
                    y += height;
                }
                if (rowNo < _rowCache.Count - 1)
                {
                    return Rectangle.Empty;
                }
            }
            if (rowNo >= 0 && rowNo < _rowCache.Count)
            {
                return _rowCache[rowNo];
            }
            else
            {
                return Rectangle.Empty;
            }
        }

        private int GetRowHeight(int rowNo)
        {
            if (rowNo < _treeView.RowMap.Count)
            {
                TreeNodeAdv node = _treeView.RowMap[rowNo];
                if (node.Height == null)
                {
                    int res = 0;
                    _measureContext.Font = _treeView.Font;
                    foreach (NodeControl nc in _treeView.NodeControls)
                    {
                        int h = nc.GetActualSize(node, _measureContext).Height;
                        if (h > res)
                        {
                            res = h;
                        }
                    }
                    node.Height = res;
                }
                return node.Height.Value;
            }
            else
            {
                return 0;
            }
        }

        public int GetRowAt(Point point)
        {
            int py = point.Y - _treeView.ColumnHeaderHeight;
            int y = 0;
            for (int i = _treeView.FirstVisibleRow; i < _treeView.RowCount; i++)
            {
                int h = GetRowHeight(i);
                if (py >= y && py < y + h)
                {
                    return i;
                }
                else
                {
                    y += h;
                }
            }
            return -1;
        }

        public int GetFirstRow(int lastPageRow)
        {
            int pageHeight = _treeView.DisplayRectangle.Height - _treeView.ColumnHeaderHeight;
            int y = 0;
            for (int i = lastPageRow; i >= 0; i--)
            {
                y += GetRowHeight(i);
                if (y > pageHeight)
                {
                    return Math.Max(0, i + 1);
                }
            }
            return 0;
        }

        public void ClearCache()
        {
            _rowCache.Clear();
        }
    }

    public struct DrawContext
    {
        private Graphics _graphics;
        private Rectangle _bounds;
        private Font _font;
        private DrawSelectionMode _drawSelection;
        private bool _drawFocus;
        private NodeControl _currentEditorOwner;
        private bool _enabled;

        public Graphics Graphics
        {
            get { return _graphics; }
            set { _graphics = value; }
        }

        public Rectangle Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        public DrawSelectionMode DrawSelection
        {
            get { return _drawSelection; }
            set { _drawSelection = value; }
        }

        public bool DrawFocus
        {
            get { return _drawFocus; }
            set { _drawFocus = value; }
        }

        public NodeControl CurrentEditorOwner
        {
            get { return _currentEditorOwner; }
            set { _currentEditorOwner = value; }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
    }

    public class DropNodeValidatingEventArgs : EventArgs
    {
        Point _point;
        TreeNodeAdv _node;

        public DropNodeValidatingEventArgs(Point point, TreeNodeAdv node)
        {
            _point = point;
            _node = node;
        }

        public Point Point
        {
            get { return _point; }
        }

        public TreeNodeAdv Node
        {
            get { return _node; }
            set { _node = value; }
        }
    }

    public struct DropPosition
    {
        private TreeNodeAdv _node;
        private NodePosition _position;

        public TreeNodeAdv Node
        {
            get { return _node; }
            set { _node = value; }
        }

        public NodePosition Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }

    public struct EditorContext
    {
        private TreeNodeAdv _currentNode;
        private Control _editor;
        private NodeControl _owner;
        private Rectangle _bounds;
        private DrawContext _drawContext;

        public TreeNodeAdv CurrentNode
        {
            get { return _currentNode; }
            set { _currentNode = value; }
        }

        public Control Editor
        {
            get { return _editor; }
            set { _editor = value; }
        }

        public NodeControl Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public Rectangle Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        public DrawContext DrawContext
        {
            get { return _drawContext; }
            set { _drawContext = value; }
        }
    }

    public enum DrawSelectionMode
    {
        None, Active, Inactive, FullRowSelect
    }

    public enum TreeSelectionMode
    {
        Single, Multi, MultiSameParent
    }

    public enum NodePosition
    {
        Inside, Before, After
    }

    public enum VerticalAlignment
    {
        Top, Bottom, Center
    }

    public enum IncrementalSearchMode
    {
        None, Standard, Continuous
    }

    [Flags]
    public enum GridLineStyle
    {
        None = 0,
        Horizontal = 1,
        Vertical = 2,
        HorizontalAndVertical = 3
    }

    public enum ImageScaleMode
    {
        Clip, // Не масштабировать.
        Fit, // Масштабирует изображение так, чтобы оно соответствовало прямоугольнику дисплея, соотношение сторон не фиксировано.
        AlwaysScale // Масштабирование изображения в соответствии с отображаемым прямоугольником с учетом соотношения сторон.
    }

    internal class FixedRowHeightLayout : IRowLayout
    {
        private TreeViewAdv _treeView;
        private int _rowHeight;

        public FixedRowHeightLayout(TreeViewAdv treeView, int rowHeight)
        {
            _treeView = treeView;
            PreferredRowHeight = rowHeight;
        }

        public int PreferredRowHeight
        {
            get { return _rowHeight; }
            set { _rowHeight = value; }
        }

        public Rectangle GetRowBounds(int rowNo)
        {
            return new Rectangle(0, rowNo * _rowHeight, 0, _rowHeight);
        }

        public int PageRowCount
        {
            get { return Math.Max((_treeView.DisplayRectangle.Height - _treeView.ColumnHeaderHeight) / _rowHeight, 0); }
        }

        public int CurrentPageSize
        {
            get { return PageRowCount; }
        }

        public int GetRowAt(Point point)
        {
            point = new Point(point.X, point.Y + (_treeView.FirstVisibleRow * _rowHeight) - _treeView.ColumnHeaderHeight);
            return point.Y / _rowHeight;
        }

        public int GetFirstRow(int lastPageRow)
        {
            return Math.Max(0, lastPageRow - PageRowCount + 1);
        }

        public void ClearCache()
        {
        }
    }

    internal class IncrementalSearch
    {
        private const int SearchTimeout = 300; // Окончание инкрементного времени поиска в мсек.
        private TreeViewAdv _tree;
        private TreeNodeAdv _currentNode;
        private string _searchString = "";
        private DateTime _lastKeyPressed = DateTime.Now;

        public IncrementalSearch(TreeViewAdv tree)
        {
            _tree = tree;
        }

        public void Search(Char value)
        {
            if (!Char.IsControl(value))
            {
                Char ch = Char.ToLowerInvariant(value);
                DateTime dt = DateTime.Now;
                TimeSpan ts = dt - _lastKeyPressed;
                _lastKeyPressed = dt;
                if (ts.TotalMilliseconds < SearchTimeout)
                {
                    if (_searchString == value.ToString())
                    {
                        FirstCharSearch(ch);
                    }
                    else
                    {
                        ContinuousSearch(ch);
                    }
                }
                else
                {
                    FirstCharSearch(ch);
                }
            }
        }

        private void ContinuousSearch(Char value)
        {
            if (value == ' ' && String.IsNullOrEmpty(_searchString))
            {
                return; // Игнорировать ведущие пробелы.
            }

            _searchString += value;
            DoContinuousSearch();
        }

        private void FirstCharSearch(Char value)
        {
            if (value == ' ')
            {
                return;
            }

            _searchString = value.ToString();
            TreeNodeAdv node = null;
            if (_tree.SelectedNode != null)
            {
                node = _tree.SelectedNode.NextVisibleNode;
            }
            if (node == null)
            {
                node = _tree.Root.NextVisibleNode;
            }

            if (node != null)
            {
                foreach (string label in IterateNodeLabels(node))
                {
                    if (label.StartsWith(_searchString))
                    {
                        _tree.SelectedNode = _currentNode;
                        return;
                    }
                }
            }
        }

        public virtual void EndSearch()
        {
            _currentNode = null;
            _searchString = "";
        }

        protected IEnumerable<string> IterateNodeLabels(TreeNodeAdv start)
        {
            _currentNode = start;
            while (_currentNode != null)
            {
                foreach (string label in GetNodeLabels(_currentNode))
                {
                    yield return label;
                }

                _currentNode = _currentNode.NextVisibleNode;
                if (_currentNode == null)
                {
                    _currentNode = _tree.Root;
                }

                if (start == _currentNode)
                {
                    break;
                }
            }
        }

        private IEnumerable<string> GetNodeLabels(TreeNodeAdv node)
        {
            foreach (NodeControl nc in _tree.NodeControls)
            {
                BindableControl bc = nc as BindableControl;
                if (bc != null && bc.IncrementalSearchEnabled)
                {
                    object obj = bc.GetValue(node);
                    if (obj != null)
                    {
                        yield return obj.ToString().ToLowerInvariant();
                    }
                }
            }
        }

        private bool DoContinuousSearch()
        {
            bool found = false;
            if (!String.IsNullOrEmpty(_searchString))
            {
                TreeNodeAdv node = null;
                if (_tree.SelectedNode != null)
                {
                    node = _tree.SelectedNode;
                }
                if (node == null)
                {
                    node = _tree.Root.NextVisibleNode;
                }

                if (!String.IsNullOrEmpty(_searchString))
                {
                    foreach (string label in IterateNodeLabels(node))
                    {
                        if (label.StartsWith(_searchString))
                        {
                            found = true;
                            _tree.SelectedNode = _currentNode;
                            break;
                        }
                    }
                }
            }
            return found;
        }
    }

    internal interface IRowLayout
    {
        int PreferredRowHeight { get; set; }
        int PageRowCount { get; }
        int CurrentPageSize { get; }
        Rectangle GetRowBounds(int rowNo);
        int GetRowAt(Point point);
        int GetFirstRow(int lastPageRow);
        void ClearCache();
    }

    public interface IToolTipProvider
    {
        string GetToolTip(TreeNodeAdv node, NodeControl nodeControl);
    }

    public interface ITreeModel
    {
        IEnumerable GetChildren(TreePath treePath);
        bool IsLeaf(TreePath treePath);

        event EventHandler<TreeModelEventArgs> NodesChanged;
        event EventHandler<TreeModelEventArgs> NodesInserted;
        event EventHandler<TreeModelEventArgs> NodesRemoved;
        event EventHandler<TreePathEventArgs> StructureChanged;
    }

    public class ListModel : TreeModelBase
    {
        private IList _list;

        public int Count
        {
            get { return _list.Count; }
        }

        public ListModel()
        {
            _list = new List<object>();
        }

        public ListModel(IList list)
        {
            _list = list;
        }

        public override IEnumerable GetChildren(TreePath treePath)
        {
            return _list;
        }

        public override bool IsLeaf(TreePath treePath)
        {
            return true;
        }

        public void AddRange(IEnumerable items)
        {
            foreach (object obj in items)
            {
                _list.Add(obj);
            }
            OnStructureChanged(new TreePathEventArgs(TreePath.Empty));
        }

        public void Add(object item)
        {
            _list.Add(item);
            OnNodesInserted(new TreeModelEventArgs(TreePath.Empty, new int[] { _list.Count - 1 }, new object[] { item }));
        }

        public void Clear()
        {
            _list.Clear();
            OnStructureChanged(new TreePathEventArgs(TreePath.Empty));
        }
    }

    public struct NodeControlInfo
    {
        public static readonly NodeControlInfo Empty = new NodeControlInfo(null, Rectangle.Empty, null);
        private NodeControl _control;
        private Rectangle _bounds;
        private TreeNodeAdv _node;

        public NodeControl Control
        {
            get { return _control; }
        }

        public Rectangle Bounds
        {
            get { return _bounds; }
        }

        public TreeNodeAdv Node
        {
            get { return _node; }
        }

        public NodeControlInfo(NodeControl control, Rectangle bounds, TreeNodeAdv node)
        {
            _control = control;
            _bounds = bounds;
            _node = node;
        }
    }

    public class SortedTreeModel : TreeModelBase
    {
        private ITreeModel _innerModel;
        private IComparer _comparer;

        public ITreeModel InnerModel
        {
            get { return _innerModel; }
        }

        public IComparer Comparer
        {
            get { return _comparer; }
            set
            {
                _comparer = value;
                OnStructureChanged(new TreePathEventArgs(TreePath.Empty));
            }
        }

        public SortedTreeModel(ITreeModel innerModel)
        {
            _innerModel = innerModel;
            _innerModel.NodesChanged += new EventHandler<TreeModelEventArgs>(_innerModel_NodesChanged);
            _innerModel.NodesInserted += new EventHandler<TreeModelEventArgs>(_innerModel_NodesInserted);
            _innerModel.NodesRemoved += new EventHandler<TreeModelEventArgs>(_innerModel_NodesRemoved);
            _innerModel.StructureChanged += new EventHandler<TreePathEventArgs>(_innerModel_StructureChanged);
        }

        void _innerModel_StructureChanged(object sender, TreePathEventArgs e)
        {
            OnStructureChanged(e);
        }

        void _innerModel_NodesRemoved(object sender, TreeModelEventArgs e)
        {
            OnStructureChanged(new TreePathEventArgs(e.Path));
        }

        void _innerModel_NodesInserted(object sender, TreeModelEventArgs e)
        {
            OnStructureChanged(new TreePathEventArgs(e.Path));
        }

        void _innerModel_NodesChanged(object sender, TreeModelEventArgs e)
        {
            OnStructureChanged(new TreePathEventArgs(e.Path));
        }

        public override IEnumerable GetChildren(TreePath treePath)
        {
            if (Comparer != null)
            {
                ArrayList list = new ArrayList();
                IEnumerable res = InnerModel.GetChildren(treePath);
                if (res != null)
                {
                    foreach (object obj in res)
                    {
                        list.Add(obj);
                    }
                    list.Sort(Comparer);
                    return list;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return InnerModel.GetChildren(treePath);
            }
        }

        public override bool IsLeaf(TreePath treePath)
        {
            return InnerModel.IsLeaf(treePath);
        }
    }

    public class TreeColumnEventArgs : EventArgs
    {
        private TreeColumn _column;

        public TreeColumn Column
        {
            get { return _column; }
        }

        public TreeColumnEventArgs(TreeColumn column)
        {
            _column = column;
        }
    }

    public class TreeListAdapter : ITreeModel
    {
        // Преобразует интерфейс IEnumerable в ITreeModel.
        // Позволяет отображать простой список в TreeView.

        private System.Collections.IEnumerable _list;
        public event EventHandler<TreeModelEventArgs> NodesChanged;
        public event EventHandler<TreePathEventArgs> StructureChanged;
        public event EventHandler<TreeModelEventArgs> NodesInserted;
        public event EventHandler<TreeModelEventArgs> NodesRemoved;

        public TreeListAdapter(System.Collections.IEnumerable list)
        {
            _list = list;
        }

        public System.Collections.IEnumerable GetChildren(TreePath treePath)
        {
            if (treePath.IsEmpty())
            {
                return _list;
            }
            else
            {
                return null;
            }
        }

        public bool IsLeaf(TreePath treePath)
        {
            return true;
        }

        public void OnNodesChanged(TreeModelEventArgs args)
        {
            if (NodesChanged != null)
            {
                NodesChanged(this, args);
            }
        }

        public void OnStructureChanged(TreePathEventArgs args)
        {
            if (StructureChanged != null)
            {
                StructureChanged(this, args);
            }
        }

        public void OnNodeInserted(TreeModelEventArgs args)
        {
            if (NodesInserted != null)
            {
                NodesInserted(this, args);
            }
        }

        public void OnNodeRemoved(TreeModelEventArgs args)
        {
            if (NodesRemoved != null)
            {
                NodesRemoved(this, args);
            }
        }
    }

    public abstract class TreeModelBase : ITreeModel
    {
        public abstract System.Collections.IEnumerable GetChildren(TreePath treePath);
        public abstract bool IsLeaf(TreePath treePath);
        public event EventHandler<TreeModelEventArgs> NodesChanged;
        public event EventHandler<TreePathEventArgs> StructureChanged;
        public event EventHandler<TreeModelEventArgs> NodesInserted;
        public event EventHandler<TreeModelEventArgs> NodesRemoved;

        protected void OnNodesChanged(TreeModelEventArgs args)
        {
            if (NodesChanged != null)
            {
                NodesChanged(this, args);
            }
        }

        protected void OnStructureChanged(TreePathEventArgs args)
        {
            if (StructureChanged != null)
            {
                StructureChanged(this, args);
            }
        }

        protected void OnNodesInserted(TreeModelEventArgs args)
        {
            if (NodesInserted != null)
            {
                NodesInserted(this, args);
            }
        }

        protected void OnNodesRemoved(TreeModelEventArgs args)
        {
            if (NodesRemoved != null)
            {
                NodesRemoved(this, args);
            }
        }

        public virtual void Refresh()
        {
            OnStructureChanged(new TreePathEventArgs(TreePath.Empty));
        }
    }

    public class TreeModelEventArgs : TreePathEventArgs
    {
        private object[] _children;
        private int[] _indices;

        public object[] Children
        {
            get { return _children; }
        }

        public int[] Indices
        {
            get { return _indices; }
        }

        public TreeModelEventArgs(TreePath parent, object[] children) : this(parent, null, children)
        {
        }

        public TreeModelEventArgs(TreePath parent, int[] indices, object[] children) : base(parent)
        {
            if (children == null)
            {
                throw new ArgumentNullException();
            }

            if (indices != null && indices.Length != children.Length)
            {
                throw new ArgumentException("Индексы и дочерние массивы должны иметь одинаковую длину.");
            }
            _indices = indices;
            _children = children;
        }
    }

    public class TreeNodeAdvMouseEventArgs : MouseEventArgs
    {
        private TreeNodeAdv _node;
        private NodeControl _control;
        private Point _viewLocation;
        private Keys _modifierKeys;
        private bool _handled;
        private Rectangle _controlBounds;

        public TreeNodeAdv Node
        {
            get { return _node; }
            set { _node = value; }
        }

        public NodeControl Control
        {
            get { return _control; }
            set { _control = value; }
        }

        public Point ViewLocation
        {
            get { return _viewLocation; }
            set { _viewLocation = value; }
        }

        public Keys ModifierKeys
        {
            get { return _modifierKeys; }
            set { _modifierKeys = value; }
        }

        public bool Handled
        {
            get { return _handled; }
            set { _handled = value; }
        }

        public Rectangle ControlBounds
        {
            get { return _controlBounds; }
            set { _controlBounds = value; }
        }

        public TreeNodeAdvMouseEventArgs(MouseEventArgs args) : base(args.Button, args.Clicks, args.X, args.Y, args.Delta)
        {
        }
    }

    public class TreePath
    {
        public static readonly TreePath Empty = new TreePath();
        private object[] _path;

        public TreePath()
        {
            _path = new object[0];
        }

        public TreePath(object node)
        {
            _path = new object[] { node };
        }

        public TreePath(object[] path)
        {
            _path = path;
        }

        public TreePath(TreePath parent, object node)
        {
            _path = new object[parent.FullPath.Length + 1];
            for (int i = 0; i < _path.Length - 1; i++)
            {
                _path[i] = parent.FullPath[i];
            }
            _path[_path.Length - 1] = node;
        }

        public object[] FullPath
        {
            get { return _path; }
        }

        public object LastNode
        {
            get
            {
                if (_path.Length > 0)
                {
                    return _path[_path.Length - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        public object FirstNode
        {
            get
            {
                if (_path.Length > 0)
                {
                    return _path[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public bool IsEmpty()
        {
            return (_path.Length == 0);
        }
    }

    public class TreePathEventArgs : EventArgs
    {
        private TreePath _path;

        public TreePath Path
        {
            get { return _path; }
        }

        public TreePathEventArgs()
        {
            _path = new TreePath();
        }

        public TreePathEventArgs(TreePath path)
        {
            if (path == null)
            {
                throw new ArgumentNullException();
            }
            _path = path;
        }
    }

    public class TreeModel : ITreeModel
    {
        // Предоставляет простую готовую к использованию реализацию ITreeModel.
        // Предупреждение: этот класс не оптимизирован для работы с большим объемом данных.
        // В этом случае создайте свою собственную реализацию ITreeModel и обратите внимание на методы getChildren и isLeaf.

        private Node _root;
        public event EventHandler<TreeModelEventArgs> NodesChanged;
        public event EventHandler<TreePathEventArgs> StructureChanged;
        public event EventHandler<TreeModelEventArgs> NodesInserted;
        public event EventHandler<TreeModelEventArgs> NodesRemoved;

        public TreeModel()
        {
            _root = new Node();
            _root.Model = this;
        }

        public Node Root
        {
            get { return _root; }
        }

        public Aga.Controls.Tree.Node.NodeCollection Nodes
        {
            get { return _root.Nodes; }
        }

        public TreePath GetPath(Node node)
        {
            if (node == _root)
            {
                return TreePath.Empty;
            }
            else
            {
                Stack<object> stack = new Stack<object>();
                while (node != _root)
                {
                    stack.Push(node);
                    node = node.Parent;
                }
                return new TreePath(stack.ToArray());
            }
        }

        public Node FindNode(TreePath path)
        {
            if (path.IsEmpty())
            {
                return _root;
            }
            else
            {
                return FindNode(_root, path, 0);
            }
        }

        private Node FindNode(Node root, TreePath path, int level)
        {
            foreach (Node node in root.Nodes)
            {
                if (node == path.FullPath[level])
                {
                    if (level == path.FullPath.Length - 1)
                    {
                        return node;
                    }
                    else
                    {
                        return FindNode(node, path, level + 1);
                    }
                }
            }
            return null;
        }

        public System.Collections.IEnumerable GetChildren(TreePath treePath)
        {
            Node node = FindNode(treePath);
            if (node != null)
            {
                foreach (Node n in node.Nodes)
                {
                    yield return n;
                }
            }
            else
            {
                yield break;
            }
        }

        public bool IsLeaf(TreePath treePath)
        {
            Node node = FindNode(treePath);
            if (node != null)
            {
                return node.IsLeaf;
            }
            else
            {
                throw new ArgumentException("treePath");
            }
        }

        internal void OnNodesChanged(TreeModelEventArgs args)
        {
            if (NodesChanged != null)
            {
                NodesChanged(this, args);
            }
        }

        public void OnStructureChanged(TreePathEventArgs args)
        {
            if (StructureChanged != null)
            {
                StructureChanged(this, args);
            }
        }

        internal void OnNodeInserted(Node parent, int index, Node node)
        {
            if (NodesInserted != null)
            {
                TreeModelEventArgs args = new TreeModelEventArgs(GetPath(parent), new int[] { index }, new object[] { node });
                NodesInserted(this, args);
            }
        }

        internal void OnNodeRemoved(Node parent, int index, Node node)
        {
            if (NodesRemoved != null)
            {
                TreeModelEventArgs args = new TreeModelEventArgs(GetPath(parent), new int[] { index }, new object[] { node });
                NodesRemoved(this, args);
            }
        }
    }
}

#endregion Aga.Controls.Tree
