using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСтильЭлементаУправления", "ClControlStyles")]
    public class ClControlStyles : AutoContext<ClControlStyles>
    {
        private int m_containerControl = (int)System.Windows.Forms.ControlStyles.ContainerControl; // 1 Если присвоено значение <B>Истина</B>, элемент управления является контейнером.
        private int m_userPaint = (int)System.Windows.Forms.ControlStyles.UserPaint; // 2 Если присвоено значение <B>Истина</B>, отображение элемента управления выполняет сам элемент, а не операционная система. Если присвоено значение <B>Ложь</B>, событие Paint не возникает. Этот стиль применяется только к классам, производным от Control.
        private int m_opaque = (int)System.Windows.Forms.ControlStyles.Opaque; // 4 Если присвоено значение <B>Истина</B>, элемент управления отображается непрозрачным, а фон не закрашивается.
        private int m_resizeRedraw = (int)System.Windows.Forms.ControlStyles.ResizeRedraw; // 16 Если присвоено значение <B>Истина</B>, элемент управления перерисовывается при изменении его размера.
        private int m_fixedWidth = (int)System.Windows.Forms.ControlStyles.FixedWidth; // 32 Если присвоено значение <B>Истина</B>, элемент управления имеет фиксированную ширину при автоматическом масштабировании. Например, если операция макета пытается изменить размер элемента управления в соответствии с обновлением шрифта, ширина элемента управления не изменяется.
        private int m_fixedHeight = (int)System.Windows.Forms.ControlStyles.FixedHeight; // 64 Если присвоено значение <B>Истина</B>, элемент управления имеет фиксированную высоту при автоматическом масштабировании. Например, если операция макета пытается изменить размер элемента управления в соответствии с обновлением шрифта, высота элемента управления не изменяется.
        private int m_standardClick = (int)System.Windows.Forms.ControlStyles.StandardClick; // 256 Если присвоено значение <B>Истина</B>, элемент управления реализует стандартное поведение при нажатии.
        private int m_selectable = (int)System.Windows.Forms.ControlStyles.Selectable; // 512 Если присвоено значение <B>Истина</B>, элемент управления может получать фокус.
        private int m_userMouse = (int)System.Windows.Forms.ControlStyles.UserMouse; // 1024 Если присвоено значение <B>Истина</B>, элемент управления самостоятельно выполняет обработку событий мыши, и эти события не обрабатываются операционной системой.
        private int m_supportsTransparentBackColor = (int)System.Windows.Forms.ControlStyles.SupportsTransparentBackColor; // 2048 Если присвоено значение <B>Истина</B>, элемент управления принимает параметр BackColor c альфа-составляющей, при значении которой менее 255 имитируется прозрачность. Прозрачность имитируется, только если биту UserPaint присвоено значение <B>Истина</B>, а родительский элемент управления наследуется от класса Control.
        private int m_standardDoubleClick = (int)System.Windows.Forms.ControlStyles.StandardDoubleClick; // 4096 Если присвоено значение <B>Истина</B>, элемент управления реализует стандартное поведение при двойном нажатии. Этот стиль игнорируется, если бит <B>СтандартноеНажатие&nbsp;(StandardClick)</B> имеет значение, отличное от <B>Истина</B>.
        private int m_allPaintingInWmPaint = (int)System.Windows.Forms.ControlStyles.AllPaintingInWmPaint; // 8192 Если присвоено значение <B>Истина</B>, элемент управления не обрабатывает сообщение окна WM_ERASEBKGND, чтобы снизить мерцание. Этот стиль следует применять, только если бит <B>ПользовательскаяОтрисовка&nbsp;(UserPaint)</B> имеет значение <B>Истина</B>.
        private int m_cacheText = (int)System.Windows.Forms.ControlStyles.CacheText; // 16384 Если присвоено значение <B>Истина</B>, элемент управления хранит копию текста у себя, а не обращается к дескриптору каждый раз, когда нужен текст. По умолчанию этот стиль имеет значение <B>Ложь</B>. Этот режим повышает производительность, но затрудняет синхронизацию текста.
        private int m_enableNotifyMessage = (int)System.Windows.Forms.ControlStyles.EnableNotifyMessage; // 32768 Если присвоено значение <B>Истина</B>, обрабатывается каждое сообщение этого элемента управления. По умолчанию этот стиль имеет значение <B>Ложь</B>.
        private int m_doubleBuffer = (int)System.Windows.Forms.ControlStyles.DoubleBuffer; // 65536 Если присвоено значение <B>Истина</B>, рисование выполняется в буфере, а после завершения результат выводится на экран. Двойная буферизация предотвращает мерцание, вызываемое обновлением элемента управления. Если для этого стиля задано значение <B>Истина</B>, следует также установить <B>Истина</B> для стилей <B>ПользовательскаяОтрисовка&nbsp;(UserPaint)</B> и <B>НеСтиратьФон&nbsp;(AllPaintingInWmPaint)</B>.
        private int m_optimizedDoubleBuffer = (int)System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer; // 131072 Если присвоено значение <B>Истина</B>, элемент управления сначала прорисовывается в буфер, а не сразу на экран, что позволяет снизить мерцание. Если для этого стиля задано значение <B>Истина</B>, следует также установить <B>Истина</B> для стиля <B>НеСтиратьФон&nbsp;(AllPaintingInWmPaint)</B>.

        [ContextProperty("Выбираемый", "Selectable")]
        public int Selectable
        {
        	get { return m_selectable; }
        }

        [ContextProperty("ДвойнаяБуферизация", "DoubleBuffer")]
        public int DoubleBuffer
        {
        	get { return m_doubleBuffer; }
        }

        [ContextProperty("Контейнер", "ContainerControl")]
        public int ContainerControl
        {
        	get { return m_containerControl; }
        }

        [ContextProperty("КэшироватьТекст", "CacheText")]
        public int CacheText
        {
        	get { return m_cacheText; }
        }

        [ContextProperty("Непрозрачный", "Opaque")]
        public int Opaque
        {
        	get { return m_opaque; }
        }

        [ContextProperty("НеСтиратьФон", "AllPaintingInWmPaint")]
        public int AllPaintingInWmPaint
        {
        	get { return m_allPaintingInWmPaint; }
        }

        [ContextProperty("ОптимизированнаяДвойнаяБуферизация", "OptimizedDoubleBuffer")]
        public int OptimizedDoubleBuffer
        {
        	get { return m_optimizedDoubleBuffer; }
        }

        [ContextProperty("ПерерисоватьПриМасштабировании", "ResizeRedraw")]
        public int ResizeRedraw
        {
        	get { return m_resizeRedraw; }
        }

        [ContextProperty("ПоддержкаПрозрачногоЦвета", "SupportsTransparentBackColor")]
        public int SupportsTransparentBackColor
        {
        	get { return m_supportsTransparentBackColor; }
        }

        [ContextProperty("ПользовательскаяМышь", "UserMouse")]
        public int UserMouse
        {
        	get { return m_userMouse; }
        }

        [ContextProperty("ПользовательскаяОтрисовка", "UserPaint")]
        public int UserPaint
        {
        	get { return m_userPaint; }
        }

        [ContextProperty("СтандартноеДвойноеНажатие", "StandardDoubleClick")]
        public int StandardDoubleClick
        {
        	get { return m_standardDoubleClick; }
        }

        [ContextProperty("СтандартноеНажатие", "StandardClick")]
        public int StandardClick
        {
        	get { return m_standardClick; }
        }

        [ContextProperty("Уведомления", "EnableNotifyMessage")]
        public int EnableNotifyMessage
        {
        	get { return m_enableNotifyMessage; }
        }

        [ContextProperty("ФиксированнаяВысота", "FixedHeight")]
        public int FixedHeight
        {
        	get { return m_fixedHeight; }
        }

        [ContextProperty("ФиксированнаяШирина", "FixedWidth")]
        public int FixedWidth
        {
        	get { return m_fixedWidth; }
        }
    }
}
