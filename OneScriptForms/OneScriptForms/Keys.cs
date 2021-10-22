using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлКлавиши", "ClKeys")]
    public class ClKeys : AutoContext<ClKeys>
    {
        private int m_modifiers = (int)System.Windows.Forms.Keys.Modifiers; // -65536 Бит-маска для извлечения модификаторов из значения ключа.
        private int m_none = (int)System.Windows.Forms.Keys.None; // 0 Нет нажатой клавиши.
        private int m_lButton = (int)System.Windows.Forms.Keys.LButton; // 1 Левая кнопка мыши.
        private int m_rButton = (int)System.Windows.Forms.Keys.RButton; // 2 Правая кнопка мыши.
        private int m_cancel = (int)System.Windows.Forms.Keys.Cancel; // 3 Клавиша CANCEL
        private int m_mButton = (int)System.Windows.Forms.Keys.MButton; // 4 Средняя кнопка мыши (трехкнопочная мышь).
        private int m_xButton1 = (int)System.Windows.Forms.Keys.XButton1; // 5 Первая кнопка мыши (пятикнопочная мышь).
        private int m_xButton2 = (int)System.Windows.Forms.Keys.XButton2; // 6 Вторая кнопка мыши (пятикнопочная мышь).
        private int m_back = (int)System.Windows.Forms.Keys.Back; // 8 Клавиша BACKSPACE
        private int m_tab = (int)System.Windows.Forms.Keys.Tab; // 9 Клавиша TAB
        private int m_lineFeed = (int)System.Windows.Forms.Keys.LineFeed; // 10 Клавиша LINEFEED
        private int m_clear = (int)System.Windows.Forms.Keys.Clear; // 12 Клавиша CLEAR
        private int m_return = (int)System.Windows.Forms.Keys.Return; // 13 Клавиша RETURN
        private int m_enter = (int)System.Windows.Forms.Keys.Enter; // 13 Клавиша ENTER
        private int m_shiftKey = (int)System.Windows.Forms.Keys.ShiftKey; // 16 Клавиша SHIFT
        private int m_controlKey = (int)System.Windows.Forms.Keys.ControlKey; // 17 Клавиша CTRL
        private int m_menu = (int)System.Windows.Forms.Keys.Menu; // 18 Клавиша ALT
        private int m_pause = (int)System.Windows.Forms.Keys.Pause; // 19 Клавиша PAUSE
        private int m_capital = (int)System.Windows.Forms.Keys.Capital; // 20 Клавиша CAPS LOCK.
        private int m_capsLock = (int)System.Windows.Forms.Keys.CapsLock; // 20 Клавиша CAPS LOCK.
        private int m_hanguelMode = (int)System.Windows.Forms.Keys.HanguelMode; // 21 Клавиша режима IME Hanguel. (поддерживается для обеспечения совместимости; HangulMode)
        private int m_kanaMode = (int)System.Windows.Forms.Keys.KanaMode; // 21 Клавиша режима IME Kana.
        private int m_hangulMode = (int)System.Windows.Forms.Keys.HangulMode; // 21 Клавиша режима IMG Hangul.
        private int m_junjaMode = (int)System.Windows.Forms.Keys.JunjaMode; // 23 Клавиша режима IME Junja.
        private int m_finalMode = (int)System.Windows.Forms.Keys.FinalMode; // 24 Клавиша окончательного режима IME.
        private int m_hanjaMode = (int)System.Windows.Forms.Keys.HanjaMode; // 25 Клавиша режима IME Hanja.
        private int m_kanjiMode = (int)System.Windows.Forms.Keys.KanjiMode; // 25 Клавиша режима IME Kanji.
        private int m_escape = (int)System.Windows.Forms.Keys.Escape; // 27 Клавиша ESC
        private int m_iMEConvert = (int)System.Windows.Forms.Keys.IMEConvert; // 28 Клавиша конвертации IME.
        private int m_iMENonconvert = (int)System.Windows.Forms.Keys.IMENonconvert; // 29 Неконвертируемый IME-ключ.
        private int m_iMEAceept = (int)System.Windows.Forms.Keys.IMEAceept; // 30 Клавиша подтверждения IME.
        private int m_iMEModeChange = (int)System.Windows.Forms.Keys.IMEModeChange; // 31 Клавиша изменения режима IME.
        private int m_space = (int)System.Windows.Forms.Keys.Space; // 32 Клавиша SPACEBAR
        private int m_pageUp = (int)System.Windows.Forms.Keys.PageUp; // 33 Клавиша PAGE UP.
        private int m_prior = (int)System.Windows.Forms.Keys.Prior; // 33 Клавиша PAGE UP.
        private int m_next = (int)System.Windows.Forms.Keys.Next; // 34 Клавиша PAGE DOWN.
        private int m_pageDown = (int)System.Windows.Forms.Keys.PageDown; // 34 Клавиша PAGE DOWN.
        private int m_end = (int)System.Windows.Forms.Keys.End; // 35 Клавиша END
        private int m_home = (int)System.Windows.Forms.Keys.Home; // 36 Клавиша HOME
        private int m_left = (int)System.Windows.Forms.Keys.Left; // 37 Клавиша СТРЕЛКА ВЛЕВО.
        private int m_up = (int)System.Windows.Forms.Keys.Up; // 38 Клавиша СТРЕЛКА ВВЕРХ.
        private int m_right = (int)System.Windows.Forms.Keys.Right; // 39 Клавиша RIGHT ARROW.
        private int m_down = (int)System.Windows.Forms.Keys.Down; // 40 Клавиша СТРЕЛКА ВНИЗ.
        private int m_select = (int)System.Windows.Forms.Keys.Select; // 41 Клавиша SELECT
        private int m_print = (int)System.Windows.Forms.Keys.Print; // 42 Клавиша PRINT
        private int m_execute = (int)System.Windows.Forms.Keys.Execute; // 43 Клавиша EXECUTE
        private int m_printScreen = (int)System.Windows.Forms.Keys.PrintScreen; // 44 Клавиша PRINT SCREEN.
        private int m_snapshot = (int)System.Windows.Forms.Keys.Snapshot; // 44 Клавиша PRINT SCREEN.
        private int m_insert = (int)System.Windows.Forms.Keys.Insert; // 45 Клавиша INS
        private int m_delete = (int)System.Windows.Forms.Keys.Delete; // 46 Клавиша DEL
        private int m_help = (int)System.Windows.Forms.Keys.Help; // 47 Клавиша HELP
        private int m_d0 = (int)System.Windows.Forms.Keys.D0; // 48 Клавиша 0 (Цифровые клавиши на основной части клавиатуры)
        private int m_d1 = (int)System.Windows.Forms.Keys.D1; // 49 Клавиша 1 (Цифровые клавиши на основной части клавиатуры)
        private int m_d2 = (int)System.Windows.Forms.Keys.D2; // 50 Клавиша 2 (Цифровые клавиши на основной части клавиатуры)
        private int m_d3 = (int)System.Windows.Forms.Keys.D3; // 51 Клавиша 3 (Цифровые клавиши на основной части клавиатуры)
        private int m_d4 = (int)System.Windows.Forms.Keys.D4; // 52 Клавиша 4 (Цифровые клавиши на основной части клавиатуры)
        private int m_d5 = (int)System.Windows.Forms.Keys.D5; // 53 Клавиша 5 (Цифровые клавиши на основной части клавиатуры)
        private int m_d6 = (int)System.Windows.Forms.Keys.D6; // 54 Клавиша 6 (Цифровые клавиши на основной части клавиатуры)
        private int m_d7 = (int)System.Windows.Forms.Keys.D7; // 55 Клавиша 7 (Цифровые клавиши на основной части клавиатуры)
        private int m_d8 = (int)System.Windows.Forms.Keys.D8; // 56 Клавиша 8 (Цифровые клавиши на основной части клавиатуры)
        private int m_d9 = (int)System.Windows.Forms.Keys.D9; // 57 Клавиша 9 (Цифровые клавиши на основной части клавиатуры)
        private int m_a = (int)System.Windows.Forms.Keys.A; // 65 Клавиша A (Буквенные клавиши. Используется латинское обозначение)
        private int m_b = (int)System.Windows.Forms.Keys.B; // 66 Клавиша B (Буквенные клавиши. Используется латинское обозначение)
        private int m_c = (int)System.Windows.Forms.Keys.C; // 67 Клавиша C (Буквенные клавиши. Используется латинское обозначение)
        private int m_d = (int)System.Windows.Forms.Keys.D; // 68 Клавиша D (Буквенные клавиши. Используется латинское обозначение)
        private int m_e = (int)System.Windows.Forms.Keys.E; // 69 Клавиша E (Буквенные клавиши. Используется латинское обозначение)
        private int m_f = (int)System.Windows.Forms.Keys.F; // 70 Клавиша F (Буквенные клавиши. Используется латинское обозначение)
        private int m_g = (int)System.Windows.Forms.Keys.G; // 71 Клавиша G (Буквенные клавиши. Используется латинское обозначение)
        private int m_h = (int)System.Windows.Forms.Keys.H; // 72 Клавиша H (Буквенные клавиши. Используется латинское обозначение)
        private int m_i = (int)System.Windows.Forms.Keys.I; // 73 Клавиша I (Буквенные клавиши. Используется латинское обозначение)
        private int m_j = (int)System.Windows.Forms.Keys.J; // 74 Клавиша J (Буквенные клавиши. Используется латинское обозначение)
        private int m_k = (int)System.Windows.Forms.Keys.K; // 75 Клавиша K (Буквенные клавиши. Используется латинское обозначение)
        private int m_l = (int)System.Windows.Forms.Keys.L; // 76 Клавиша L (Буквенные клавиши. Используется латинское обозначение)
        private int m_m = (int)System.Windows.Forms.Keys.M; // 77 Клавиша M (Буквенные клавиши. Используется латинское обозначение)
        private int m_n = (int)System.Windows.Forms.Keys.N; // 78 Клавиша N (Буквенные клавиши. Используется латинское обозначение)
        private int m_o = (int)System.Windows.Forms.Keys.O; // 79 Клавиша O (Буквенные клавиши. Используется латинское обозначение)
        private int m_p = (int)System.Windows.Forms.Keys.P; // 80 Клавиша P (Буквенные клавиши. Используется латинское обозначение)
        private int m_q = (int)System.Windows.Forms.Keys.Q; // 81 Клавиша Q (Буквенные клавиши. Используется латинское обозначение)
        private int m_r = (int)System.Windows.Forms.Keys.R; // 82 Клавиша R (Буквенные клавиши. Используется латинское обозначение)
        private int m_s = (int)System.Windows.Forms.Keys.S; // 83 Клавиша S (Буквенные клавиши. Используется латинское обозначение)
        private int m_t = (int)System.Windows.Forms.Keys.T; // 84 Клавиша T (Буквенные клавиши. Используется латинское обозначение)
        private int m_u = (int)System.Windows.Forms.Keys.U; // 85 Клавиша U (Буквенные клавиши. Используется латинское обозначение)
        private int m_v = (int)System.Windows.Forms.Keys.V; // 86 Клавиша V (Буквенные клавиши. Используется латинское обозначение)
        private int m_w = (int)System.Windows.Forms.Keys.W; // 87 Клавиша W (Буквенные клавиши. Используется латинское обозначение)
        private int m_x = (int)System.Windows.Forms.Keys.X; // 88 Клавиша X (Буквенные клавиши. Используется латинское обозначение)
        private int m_y = (int)System.Windows.Forms.Keys.Y; // 89 Клавиша Y (Буквенные клавиши. Используется латинское обозначение)
        private int m_z = (int)System.Windows.Forms.Keys.Z; // 90 Клавиша Z (Буквенные клавиши. Используется латинское обозначение)
        private int m_lWin = (int)System.Windows.Forms.Keys.LWin; // 91 Левый ключ логотипа Windows (Microsoft Natural Keyboard).
        private int m_rWin = (int)System.Windows.Forms.Keys.RWin; // 92 Правильный ключ логотипа Windows (Microsoft Natural Keyboard).
        private int m_apps = (int)System.Windows.Forms.Keys.Apps; // 93 Ключ приложения (Microsoft Natural Keyboard).
        private int m_numPad0 = (int)System.Windows.Forms.Keys.NumPad0; // 96 Клавиша 0 (Цифровые клавиши на дополнительной части клавиатуры)
        private int m_numPad1 = (int)System.Windows.Forms.Keys.NumPad1; // 97 Клавиша 1 (Цифровые клавиши на дополнительной части клавиатуры)
        private int m_numPad2 = (int)System.Windows.Forms.Keys.NumPad2; // 98 Клавиша 2 (Цифровые клавиши на дополнительной части клавиатуры)
        private int m_numPad3 = (int)System.Windows.Forms.Keys.NumPad3; // 99 Клавиша 3 (Цифровые клавиши на дополнительной части клавиатуры)
        private int m_numPad4 = (int)System.Windows.Forms.Keys.NumPad4; // 100 Клавиша 4 (Цифровые клавиши на дополнительной части клавиатуры)
        private int m_numPad5 = (int)System.Windows.Forms.Keys.NumPad5; // 101 Клавиша 5 (Цифровые клавиши на дополнительной части клавиатуры)
        private int m_numPad6 = (int)System.Windows.Forms.Keys.NumPad6; // 102 Клавиша 6 (Цифровые клавиши на дополнительной части клавиатуры)
        private int m_numPad7 = (int)System.Windows.Forms.Keys.NumPad7; // 103 Клавиша 7 (Цифровые клавиши на дополнительной части клавиатуры)
        private int m_numPad8 = (int)System.Windows.Forms.Keys.NumPad8; // 104 Клавиша 8 (Цифровые клавиши на дополнительной части клавиатуры)
        private int m_numPad9 = (int)System.Windows.Forms.Keys.NumPad9; // 105 Клавиша 9 (Цифровые клавиши на дополнительной части клавиатуры)
        private int m_multiply = (int)System.Windows.Forms.Keys.Multiply; // 106 Клавиша Multiply
        private int m_add = (int)System.Windows.Forms.Keys.Add; // 107 Клавиша Add
        private int m_separator = (int)System.Windows.Forms.Keys.Separator; // 108 Клавиша Separator
        private int m_subtract = (int)System.Windows.Forms.Keys.Subtract; // 109 Клавиша Subtract
        private int m_decimal = (int)System.Windows.Forms.Keys.Decimal; // 110 Клавиша Decimal
        private int m_divide = (int)System.Windows.Forms.Keys.Divide; // 111 Клавиша Divide
        private int m_f1 = (int)System.Windows.Forms.Keys.F1; // 112 Клавиша F1 (Функциональные клавиши)
        private int m_f2 = (int)System.Windows.Forms.Keys.F2; // 113 Клавиша F2 (Функциональные клавиши)
        private int m_f3 = (int)System.Windows.Forms.Keys.F3; // 114 Клавиша F3 (Функциональные клавиши)
        private int m_f4 = (int)System.Windows.Forms.Keys.F4; // 115 Клавиша F4 (Функциональные клавиши)
        private int m_f5 = (int)System.Windows.Forms.Keys.F5; // 116 Клавиша F5 (Функциональные клавиши)
        private int m_f6 = (int)System.Windows.Forms.Keys.F6; // 117 Клавиша F6 (Функциональные клавиши)
        private int m_f7 = (int)System.Windows.Forms.Keys.F7; // 118 Клавиша F7 (Функциональные клавиши)
        private int m_f8 = (int)System.Windows.Forms.Keys.F8; // 119 Клавиша F8 (Функциональные клавиши)
        private int m_f9 = (int)System.Windows.Forms.Keys.F9; // 120 Клавиша F9 (Функциональные клавиши)
        private int m_f10 = (int)System.Windows.Forms.Keys.F10; // 121 Клавиша F10 (Функциональные клавиши)
        private int m_f11 = (int)System.Windows.Forms.Keys.F11; // 122 Клавиша F11 (Функциональные клавиши)
        private int m_f12 = (int)System.Windows.Forms.Keys.F12; // 123 Клавиша F12 (Функциональные клавиши)
        private int m_f13 = (int)System.Windows.Forms.Keys.F13; // 124 Клавиша F13 (Функциональные клавиши)
        private int m_f14 = (int)System.Windows.Forms.Keys.F14; // 125 Клавиша F14 (Функциональные клавиши)
        private int m_f15 = (int)System.Windows.Forms.Keys.F15; // 126 Клавиша F15 (Функциональные клавиши)
        private int m_f16 = (int)System.Windows.Forms.Keys.F16; // 127 Клавиша F16 (Функциональные клавиши)
        private int m_f17 = (int)System.Windows.Forms.Keys.F17; // 128 Клавиша F17 (Функциональные клавиши)
        private int m_f18 = (int)System.Windows.Forms.Keys.F18; // 129 Клавиша F18 (Функциональные клавиши)
        private int m_f19 = (int)System.Windows.Forms.Keys.F19; // 130 Клавиша F19 (Функциональные клавиши)
        private int m_f20 = (int)System.Windows.Forms.Keys.F20; // 131 Клавиша F20 (Функциональные клавиши)
        private int m_f21 = (int)System.Windows.Forms.Keys.F21; // 132 Клавиша F21 (Функциональные клавиши)
        private int m_f22 = (int)System.Windows.Forms.Keys.F22; // 133 Клавиша F22 (Функциональные клавиши)
        private int m_f23 = (int)System.Windows.Forms.Keys.F23; // 134 Клавиша F23 (Функциональные клавиши)
        private int m_f24 = (int)System.Windows.Forms.Keys.F24; // 135 Клавиша F24 (Функциональные клавиши)
        private int m_numLock = (int)System.Windows.Forms.Keys.NumLock; // 144 Клавиша NUM LOCK.
        private int m_scroll = (int)System.Windows.Forms.Keys.Scroll; // 145 Клавиша SCROLL LOCK.
        private int m_lShiftKey = (int)System.Windows.Forms.Keys.LShiftKey; // 160 Левая клавиша SHIFT.
        private int m_rShiftKey = (int)System.Windows.Forms.Keys.RShiftKey; // 161 Правильный SHIFT-ключ.
        private int m_lControlKey = (int)System.Windows.Forms.Keys.LControlKey; // 162 Левая клавиша CTRL.
        private int m_rControlKey = (int)System.Windows.Forms.Keys.RControlKey; // 163 Правильный CTRL-ключ.
        private int m_lMenu = (int)System.Windows.Forms.Keys.LMenu; // 164 Левая клавиша ALT.
        private int m_rMenu = (int)System.Windows.Forms.Keys.RMenu; // 165 Правильный ключ ALT.
        private int m_browserBack = (int)System.Windows.Forms.Keys.BrowserBack; // 166 Клавиша браузера Назад (Windows 2000 или новее).
        private int m_browserForward = (int)System.Windows.Forms.Keys.BrowserForward; // 167 Клавиша браузера Переадресация (Windows 2000 или новее).
        private int m_browserRefresh = (int)System.Windows.Forms.Keys.BrowserRefresh; // 168 Клавиша браузера Обновить (Windows 2000 или новее).
        private int m_browserStop = (int)System.Windows.Forms.Keys.BrowserStop; // 169 Клавиша браузера Остановить (Windows 2000 или новее).
        private int m_browserSearch = (int)System.Windows.Forms.Keys.BrowserSearch; // 170 Клавиша браузера Поиск (Windows 2000 или новее).
        private int m_browserFavorites = (int)System.Windows.Forms.Keys.BrowserFavorites; // 171 Клавиша браузера Избранное (Windows 2000 или новее).
        private int m_browserHome = (int)System.Windows.Forms.Keys.BrowserHome; // 172 Клавиша браузера Домой (Windows 2000 или новее).
        private int m_volumeMute = (int)System.Windows.Forms.Keys.VolumeMute; // 173 Клавиша отключения звука (Windows 2000 или новее).
        private int m_volumeDown = (int)System.Windows.Forms.Keys.VolumeDown; // 174 Клавиша уменьшения громкости (Windows 2000 или новее).
        private int m_volumeUp = (int)System.Windows.Forms.Keys.VolumeUp; // 175 Клавиша увеличения громкости (Windows 2000 или новее).
        private int m_mediaNextTrack = (int)System.Windows.Forms.Keys.MediaNextTrack; // 176 Клавиша «Следующий трек» (Windows 2000 или более поздняя версия).
        private int m_mediaPreviousTrack = (int)System.Windows.Forms.Keys.MediaPreviousTrack; // 177 Клавиша «Предыдущий трек» для мультимедиа (Windows 2000 или новее).
        private int m_mediaStop = (int)System.Windows.Forms.Keys.MediaStop; // 178 Ключ Media Stop (Windows 2000 или новее).
        private int m_mediaPlayPause = (int)System.Windows.Forms.Keys.MediaPlayPause; // 179 Клавиша Pause Media Play (Windows 2000 или новее).
        private int m_launchMail = (int)System.Windows.Forms.Keys.LaunchMail; // 180 Клавиша Launch Mail (Windows 2000 или новее).
        private int m_selectMedia = (int)System.Windows.Forms.Keys.SelectMedia; // 181 Клавиша Select Media (Windows 2000 или новее).
        private int m_launchApplication1 = (int)System.Windows.Forms.Keys.LaunchApplication1; // 182 Запустить приложение одним ключом (Windows 2000 или новее).
        private int m_launchApplication2 = (int)System.Windows.Forms.Keys.LaunchApplication2; // 183 Дважды нажмите «Запустить приложение» (Windows 2000 или новее).
        private int m_oemSemicolon = (int)System.Windows.Forms.Keys.OemSemicolon; // 186 Ключ OEM Semicolon на стандартной клавиатуре США (Windows 2000 или позже).
        private int m_oemplus = (int)System.Windows.Forms.Keys.Oemplus; // 187 Клавиша OEM Plus на любой клавиатуре страны / региона (Windows 2000 или позже).
        private int m_oemcomma = (int)System.Windows.Forms.Keys.Oemcomma; // 188 Ключ OEM Comma на любой клавиатуре страны / региона (Windows 2000 или позже).
        private int m_oemMinus = (int)System.Windows.Forms.Keys.OemMinus; // 189 Ключ OEM Minus на любой клавиатуре страны / региона (Windows 2000 или позже).
        private int m_oemPeriod = (int)System.Windows.Forms.Keys.OemPeriod; // 190 Ключ OEM Period на любой клавиатуре страны / региона (Windows 2000 или позже).
        private int m_oemQuestion = (int)System.Windows.Forms.Keys.OemQuestion; // 191 Клавиша «Вопросительный знак OEM» на стандартной клавиатуре США (Windows 2000 или позже).
        private int m_oemtilde = (int)System.Windows.Forms.Keys.Oemtilde; // 192 Ключ OEM тильды на стандартной клавиатуре США (Windows 2000 или позже).
        private int m_oemOpenBrackets = (int)System.Windows.Forms.Keys.OemOpenBrackets; // 219 Ключ OEM OpenBracket на стандартной клавиатуре США (Windows 2000 или позже).
        private int m_oemPipe = (int)System.Windows.Forms.Keys.OemPipe; // 220 Ключ OEM Pipe на стандартной клавиатуре США (Windows 2000 или позже).
        private int m_oemCloseBrackets = (int)System.Windows.Forms.Keys.OemCloseBrackets; // 221 Ключ OEM Close Bracket на стандартной клавиатуре США (Windows 2000 или позже).
        private int m_oemQuotes = (int)System.Windows.Forms.Keys.OemQuotes; // 222 Ключ OEM Single / Double quote на стандартной клавиатуре США (Windows 2000 или новее).
        private int m_oem8 = (int)System.Windows.Forms.Keys.Oem8; // 223 OEM specific.
        private int m_oemBackslash = (int)System.Windows.Forms.Keys.OemBackslash; // 226 Кронштейн OEM-углов или клавиша обратного слэша на клавиатуре RT 102 key keboard (Windows 2000 или новее).
        private int m_processKey = (int)System.Windows.Forms.Keys.ProcessKey; // 229 Ключ PROCESS KEY.
        private int m_attn = (int)System.Windows.Forms.Keys.Attn; // 246 Клавиша ATTN
        private int m_crsel = (int)System.Windows.Forms.Keys.Crsel; // 247 Клавиша CRSEL
        private int m_exsel = (int)System.Windows.Forms.Keys.Exsel; // 248 Клавиша EXSEL
        private int m_eraseEof = (int)System.Windows.Forms.Keys.EraseEof; // 249 Клавиша ERASE EOF.
        private int m_play = (int)System.Windows.Forms.Keys.Play; // 250 Клавиша PLAY
        private int m_zoom = (int)System.Windows.Forms.Keys.Zoom; // 251 Клавиша ZOOM
        private int m_noName = (int)System.Windows.Forms.Keys.NoName; // 252 Константа, зарезервированная для использования в будущем.
        private int m_pa1 = (int)System.Windows.Forms.Keys.Pa1; // 253 Клавиша PA1
        private int m_oemClear = (int)System.Windows.Forms.Keys.OemClear; // 254 Клавиша CLEAR
        private int m_keyCode = (int)System.Windows.Forms.Keys.KeyCode; // 65535 Бит-маска для извлечения кода ключа из значения ключа.
        private int m_shift = (int)System.Windows.Forms.Keys.Shift; // 65536 Модификатор SHIFT.
        private int m_control = (int)System.Windows.Forms.Keys.Control; // 131072 Клавиша CTRL
        private int m_alt = (int)System.Windows.Forms.Keys.Alt; // 262144 Клавиша модификатора ALT.

        [ContextProperty("A", "A")]
        public int A
        {
        	get { return m_a; }
        }

        [ContextProperty("Alt", "Alt")]
        public int Alt
        {
        	get { return m_alt; }
        }

        [ContextProperty("Apps", "Apps")]
        public int Apps
        {
        	get { return m_apps; }
        }

        [ContextProperty("Attn", "Attn")]
        public int Attn
        {
        	get { return m_attn; }
        }

        [ContextProperty("B", "B")]
        public int B
        {
        	get { return m_b; }
        }

        [ContextProperty("BrowserBack", "BrowserBack")]
        public int BrowserBack
        {
        	get { return m_browserBack; }
        }

        [ContextProperty("BrowserFavorites", "BrowserFavorites")]
        public int BrowserFavorites
        {
        	get { return m_browserFavorites; }
        }

        [ContextProperty("BrowserForward", "BrowserForward")]
        public int BrowserForward
        {
        	get { return m_browserForward; }
        }

        [ContextProperty("BrowserHome", "BrowserHome")]
        public int BrowserHome
        {
        	get { return m_browserHome; }
        }

        [ContextProperty("BrowserRefresh", "BrowserRefresh")]
        public int BrowserRefresh
        {
        	get { return m_browserRefresh; }
        }

        [ContextProperty("BrowserSearch", "BrowserSearch")]
        public int BrowserSearch
        {
        	get { return m_browserSearch; }
        }

        [ContextProperty("BrowserStop", "BrowserStop")]
        public int BrowserStop
        {
        	get { return m_browserStop; }
        }

        [ContextProperty("C", "C")]
        public int C
        {
        	get { return m_c; }
        }

        [ContextProperty("Capital", "Capital")]
        public int Capital
        {
        	get { return m_capital; }
        }

        [ContextProperty("CapsLock", "CapsLock")]
        public int CapsLock
        {
        	get { return m_capsLock; }
        }

        [ContextProperty("ControlKey", "ControlKey")]
        public int ControlKey
        {
        	get { return m_controlKey; }
        }

        [ContextProperty("Crsel", "Crsel")]
        public int Crsel
        {
        	get { return m_crsel; }
        }

        [ContextProperty("Ctrl", "Control")]
        public int Control
        {
        	get { return m_control; }
        }

        [ContextProperty("D", "D")]
        public int D
        {
        	get { return m_d; }
        }

        [ContextProperty("D0", "D0")]
        public int D0
        {
        	get { return m_d0; }
        }

        [ContextProperty("D1", "D1")]
        public int D1
        {
        	get { return m_d1; }
        }

        [ContextProperty("D2", "D2")]
        public int D2
        {
        	get { return m_d2; }
        }

        [ContextProperty("D3", "D3")]
        public int D3
        {
        	get { return m_d3; }
        }

        [ContextProperty("D4", "D4")]
        public int D4
        {
        	get { return m_d4; }
        }

        [ContextProperty("D5", "D5")]
        public int D5
        {
        	get { return m_d5; }
        }

        [ContextProperty("D6", "D6")]
        public int D6
        {
        	get { return m_d6; }
        }

        [ContextProperty("D7", "D7")]
        public int D7
        {
        	get { return m_d7; }
        }

        [ContextProperty("D8", "D8")]
        public int D8
        {
        	get { return m_d8; }
        }

        [ContextProperty("D9", "D9")]
        public int D9
        {
        	get { return m_d9; }
        }

        [ContextProperty("E", "E")]
        public int E
        {
        	get { return m_e; }
        }

        [ContextProperty("End", "End")]
        public int End
        {
        	get { return m_end; }
        }

        [ContextProperty("Enter", "Enter")]
        public int Enter
        {
        	get { return m_enter; }
        }

        [ContextProperty("EraseEof", "EraseEof")]
        public int EraseEof
        {
        	get { return m_eraseEof; }
        }

        [ContextProperty("Escape", "Escape")]
        public int Escape
        {
        	get { return m_escape; }
        }

        [ContextProperty("Execute", "Execute")]
        public int Execute
        {
        	get { return m_execute; }
        }

        [ContextProperty("Exsel", "Exsel")]
        public int Exsel
        {
        	get { return m_exsel; }
        }

        [ContextProperty("F", "F")]
        public int F
        {
        	get { return m_f; }
        }

        [ContextProperty("F1", "F1")]
        public int F1
        {
        	get { return m_f1; }
        }

        [ContextProperty("F10", "F10")]
        public int F10
        {
        	get { return m_f10; }
        }

        [ContextProperty("F11", "F11")]
        public int F11
        {
        	get { return m_f11; }
        }

        [ContextProperty("F12", "F12")]
        public int F12
        {
        	get { return m_f12; }
        }

        [ContextProperty("F13", "F13")]
        public int F13
        {
        	get { return m_f13; }
        }

        [ContextProperty("F14", "F14")]
        public int F14
        {
        	get { return m_f14; }
        }

        [ContextProperty("F15", "F15")]
        public int F15
        {
        	get { return m_f15; }
        }

        [ContextProperty("F16", "F16")]
        public int F16
        {
        	get { return m_f16; }
        }

        [ContextProperty("F17", "F17")]
        public int F17
        {
        	get { return m_f17; }
        }

        [ContextProperty("F18", "F18")]
        public int F18
        {
        	get { return m_f18; }
        }

        [ContextProperty("F19", "F19")]
        public int F19
        {
        	get { return m_f19; }
        }

        [ContextProperty("F2", "F2")]
        public int F2
        {
        	get { return m_f2; }
        }

        [ContextProperty("F20", "F20")]
        public int F20
        {
        	get { return m_f20; }
        }

        [ContextProperty("F21", "F21")]
        public int F21
        {
        	get { return m_f21; }
        }

        [ContextProperty("F22", "F22")]
        public int F22
        {
        	get { return m_f22; }
        }

        [ContextProperty("F23", "F23")]
        public int F23
        {
        	get { return m_f23; }
        }

        [ContextProperty("F24", "F24")]
        public int F24
        {
        	get { return m_f24; }
        }

        [ContextProperty("F3", "F3")]
        public int F3
        {
        	get { return m_f3; }
        }

        [ContextProperty("F4", "F4")]
        public int F4
        {
        	get { return m_f4; }
        }

        [ContextProperty("F5", "F5")]
        public int F5
        {
        	get { return m_f5; }
        }

        [ContextProperty("F6", "F6")]
        public int F6
        {
        	get { return m_f6; }
        }

        [ContextProperty("F7", "F7")]
        public int F7
        {
        	get { return m_f7; }
        }

        [ContextProperty("F8", "F8")]
        public int F8
        {
        	get { return m_f8; }
        }

        [ContextProperty("F9", "F9")]
        public int F9
        {
        	get { return m_f9; }
        }

        [ContextProperty("FinalMode", "FinalMode")]
        public int FinalMode
        {
        	get { return m_finalMode; }
        }

        [ContextProperty("G", "G")]
        public int G
        {
        	get { return m_g; }
        }

        [ContextProperty("H", "H")]
        public int H
        {
        	get { return m_h; }
        }

        [ContextProperty("HanguelMode", "HanguelMode")]
        public int HanguelMode
        {
        	get { return m_hanguelMode; }
        }

        [ContextProperty("HangulMode", "HangulMode")]
        public int HangulMode
        {
        	get { return m_hangulMode; }
        }

        [ContextProperty("HanjaMode", "HanjaMode")]
        public int HanjaMode
        {
        	get { return m_hanjaMode; }
        }

        [ContextProperty("I", "I")]
        public int I
        {
        	get { return m_i; }
        }

        [ContextProperty("IMEAceept", "IMEAceept")]
        public int IMEAceept
        {
        	get { return m_iMEAceept; }
        }

        [ContextProperty("IMEConvert", "IMEConvert")]
        public int IMEConvert
        {
        	get { return m_iMEConvert; }
        }

        [ContextProperty("IMEModeChange", "IMEModeChange")]
        public int IMEModeChange
        {
        	get { return m_iMEModeChange; }
        }

        [ContextProperty("IMENonconvert", "IMENonconvert")]
        public int IMENonconvert
        {
        	get { return m_iMENonconvert; }
        }

        [ContextProperty("J", "J")]
        public int J
        {
        	get { return m_j; }
        }

        [ContextProperty("JunjaMode", "JunjaMode")]
        public int JunjaMode
        {
        	get { return m_junjaMode; }
        }

        [ContextProperty("K", "K")]
        public int K
        {
        	get { return m_k; }
        }

        [ContextProperty("KanaMode", "KanaMode")]
        public int KanaMode
        {
        	get { return m_kanaMode; }
        }

        [ContextProperty("KanjiMode", "KanjiMode")]
        public int KanjiMode
        {
        	get { return m_kanjiMode; }
        }

        [ContextProperty("KeyCode", "KeyCode")]
        public int KeyCode
        {
        	get { return m_keyCode; }
        }

        [ContextProperty("L", "L")]
        public int L
        {
        	get { return m_l; }
        }

        [ContextProperty("LaunchApplication1", "LaunchApplication1")]
        public int LaunchApplication1
        {
        	get { return m_launchApplication1; }
        }

        [ContextProperty("LaunchApplication2", "LaunchApplication2")]
        public int LaunchApplication2
        {
        	get { return m_launchApplication2; }
        }

        [ContextProperty("LaunchMail", "LaunchMail")]
        public int LaunchMail
        {
        	get { return m_launchMail; }
        }

        [ContextProperty("LControlKey", "LControlKey")]
        public int LControlKey
        {
        	get { return m_lControlKey; }
        }

        [ContextProperty("LineFeed", "LineFeed")]
        public int LineFeed
        {
        	get { return m_lineFeed; }
        }

        [ContextProperty("LMenu", "LMenu")]
        public int LMenu
        {
        	get { return m_lMenu; }
        }

        [ContextProperty("LShiftKey", "LShiftKey")]
        public int LShiftKey
        {
        	get { return m_lShiftKey; }
        }

        [ContextProperty("LWin", "LWin")]
        public int LWin
        {
        	get { return m_lWin; }
        }

        [ContextProperty("M", "M")]
        public int M
        {
        	get { return m_m; }
        }

        [ContextProperty("MediaNextTrack", "MediaNextTrack")]
        public int MediaNextTrack
        {
        	get { return m_mediaNextTrack; }
        }

        [ContextProperty("MediaPlayPause", "MediaPlayPause")]
        public int MediaPlayPause
        {
        	get { return m_mediaPlayPause; }
        }

        [ContextProperty("MediaPreviousTrack", "MediaPreviousTrack")]
        public int MediaPreviousTrack
        {
        	get { return m_mediaPreviousTrack; }
        }

        [ContextProperty("MediaStop", "MediaStop")]
        public int MediaStop
        {
        	get { return m_mediaStop; }
        }

        [ContextProperty("Modifiers", "Modifiers")]
        public int Modifiers
        {
        	get { return m_modifiers; }
        }

        [ContextProperty("Multiply", "Multiply")]
        public int Multiply
        {
        	get { return m_multiply; }
        }

        [ContextProperty("N", "N")]
        public int N
        {
        	get { return m_n; }
        }

        [ContextProperty("Next", "Next")]
        public int Next
        {
        	get { return m_next; }
        }

        [ContextProperty("NoName", "NoName")]
        public int NoName
        {
        	get { return m_noName; }
        }

        [ContextProperty("NumLock", "NumLock")]
        public int NumLock
        {
        	get { return m_numLock; }
        }

        [ContextProperty("NumPad0", "NumPad0")]
        public int NumPad0
        {
        	get { return m_numPad0; }
        }

        [ContextProperty("NumPad1", "NumPad1")]
        public int NumPad1
        {
        	get { return m_numPad1; }
        }

        [ContextProperty("NumPad2", "NumPad2")]
        public int NumPad2
        {
        	get { return m_numPad2; }
        }

        [ContextProperty("NumPad3", "NumPad3")]
        public int NumPad3
        {
        	get { return m_numPad3; }
        }

        [ContextProperty("NumPad4", "NumPad4")]
        public int NumPad4
        {
        	get { return m_numPad4; }
        }

        [ContextProperty("NumPad5", "NumPad5")]
        public int NumPad5
        {
        	get { return m_numPad5; }
        }

        [ContextProperty("NumPad6", "NumPad6")]
        public int NumPad6
        {
        	get { return m_numPad6; }
        }

        [ContextProperty("NumPad7", "NumPad7")]
        public int NumPad7
        {
        	get { return m_numPad7; }
        }

        [ContextProperty("NumPad8", "NumPad8")]
        public int NumPad8
        {
        	get { return m_numPad8; }
        }

        [ContextProperty("NumPad9", "NumPad9")]
        public int NumPad9
        {
        	get { return m_numPad9; }
        }

        [ContextProperty("O", "O")]
        public int O
        {
        	get { return m_o; }
        }

        [ContextProperty("Oem8", "Oem8")]
        public int Oem8
        {
        	get { return m_oem8; }
        }

        [ContextProperty("OemBackslash", "OemBackslash")]
        public int OemBackslash
        {
        	get { return m_oemBackslash; }
        }

        [ContextProperty("OemClear", "OemClear")]
        public int OemClear
        {
        	get { return m_oemClear; }
        }

        [ContextProperty("OemCloseBrackets", "OemCloseBrackets")]
        public int OemCloseBrackets
        {
        	get { return m_oemCloseBrackets; }
        }

        [ContextProperty("Oemcomma", "Oemcomma")]
        public int Oemcomma
        {
        	get { return m_oemcomma; }
        }

        [ContextProperty("OemMinus", "OemMinus")]
        public int OemMinus
        {
        	get { return m_oemMinus; }
        }

        [ContextProperty("OemOpenBrackets", "OemOpenBrackets")]
        public int OemOpenBrackets
        {
        	get { return m_oemOpenBrackets; }
        }

        [ContextProperty("OemPeriod", "OemPeriod")]
        public int OemPeriod
        {
        	get { return m_oemPeriod; }
        }

        [ContextProperty("OemPipe", "OemPipe")]
        public int OemPipe
        {
        	get { return m_oemPipe; }
        }

        [ContextProperty("Oemplus", "Oemplus")]
        public int Oemplus
        {
        	get { return m_oemplus; }
        }

        [ContextProperty("OemQuestion", "OemQuestion")]
        public int OemQuestion
        {
        	get { return m_oemQuestion; }
        }

        [ContextProperty("OemQuotes", "OemQuotes")]
        public int OemQuotes
        {
        	get { return m_oemQuotes; }
        }

        [ContextProperty("OemSemicolon", "OemSemicolon")]
        public int OemSemicolon
        {
        	get { return m_oemSemicolon; }
        }

        [ContextProperty("Oemtilde", "Oemtilde")]
        public int Oemtilde
        {
        	get { return m_oemtilde; }
        }

        [ContextProperty("P", "P")]
        public int P
        {
        	get { return m_p; }
        }

        [ContextProperty("Pa1", "Pa1")]
        public int Pa1
        {
        	get { return m_pa1; }
        }

        [ContextProperty("PageDown", "PageDown")]
        public int PageDown
        {
        	get { return m_pageDown; }
        }

        [ContextProperty("PageUp", "PageUp")]
        public int PageUp
        {
        	get { return m_pageUp; }
        }

        [ContextProperty("Pause", "Pause")]
        public int Pause
        {
        	get { return m_pause; }
        }

        [ContextProperty("Play", "Play")]
        public int Play
        {
        	get { return m_play; }
        }

        [ContextProperty("Print", "Print")]
        public int Print
        {
        	get { return m_print; }
        }

        [ContextProperty("PrintScreen", "PrintScreen")]
        public int PrintScreen
        {
        	get { return m_printScreen; }
        }

        [ContextProperty("Prior", "Prior")]
        public int Prior
        {
        	get { return m_prior; }
        }

        [ContextProperty("ProcessKey", "ProcessKey")]
        public int ProcessKey
        {
        	get { return m_processKey; }
        }

        [ContextProperty("Q", "Q")]
        public int Q
        {
        	get { return m_q; }
        }

        [ContextProperty("R", "R")]
        public int R
        {
        	get { return m_r; }
        }

        [ContextProperty("RControlKey", "RControlKey")]
        public int RControlKey
        {
        	get { return m_rControlKey; }
        }

        [ContextProperty("Return", "Return")]
        public int Return
        {
        	get { return m_return; }
        }

        [ContextProperty("RMenu", "RMenu")]
        public int RMenu
        {
        	get { return m_rMenu; }
        }

        [ContextProperty("RShiftKey", "RShiftKey")]
        public int RShiftKey
        {
        	get { return m_rShiftKey; }
        }

        [ContextProperty("RWin", "RWin")]
        public int RWin
        {
        	get { return m_rWin; }
        }

        [ContextProperty("S", "S")]
        public int S
        {
        	get { return m_s; }
        }

        [ContextProperty("Scroll", "Scroll")]
        public int Scroll
        {
        	get { return m_scroll; }
        }

        [ContextProperty("Select", "Select")]
        public int Select
        {
        	get { return m_select; }
        }

        [ContextProperty("SelectMedia", "SelectMedia")]
        public int SelectMedia
        {
        	get { return m_selectMedia; }
        }

        [ContextProperty("Separator", "Separator")]
        public int Separator
        {
        	get { return m_separator; }
        }

        [ContextProperty("Shift", "Shift")]
        public int Shift
        {
        	get { return m_shift; }
        }

        [ContextProperty("ShiftKey", "ShiftKey")]
        public int ShiftKey
        {
        	get { return m_shiftKey; }
        }

        [ContextProperty("Snapshot", "Snapshot")]
        public int Snapshot
        {
        	get { return m_snapshot; }
        }

        [ContextProperty("Subtract", "Subtract")]
        public int Subtract
        {
        	get { return m_subtract; }
        }

        [ContextProperty("T", "T")]
        public int T
        {
        	get { return m_t; }
        }

        [ContextProperty("Tab", "Tab")]
        public int Tab
        {
        	get { return m_tab; }
        }

        [ContextProperty("U", "U")]
        public int U
        {
        	get { return m_u; }
        }

        [ContextProperty("V", "V")]
        public int V
        {
        	get { return m_v; }
        }

        [ContextProperty("VolumeDown", "VolumeDown")]
        public int VolumeDown
        {
        	get { return m_volumeDown; }
        }

        [ContextProperty("VolumeMute", "VolumeMute")]
        public int VolumeMute
        {
        	get { return m_volumeMute; }
        }

        [ContextProperty("VolumeUp", "VolumeUp")]
        public int VolumeUp
        {
        	get { return m_volumeUp; }
        }

        [ContextProperty("W", "W")]
        public int W
        {
        	get { return m_w; }
        }

        [ContextProperty("X", "X")]
        public int X
        {
        	get { return m_x; }
        }

        [ContextProperty("XButton1", "XButton1")]
        public int XButton1
        {
        	get { return m_xButton1; }
        }

        [ContextProperty("XButton2", "XButton2")]
        public int XButton2
        {
        	get { return m_xButton2; }
        }

        [ContextProperty("Y", "Y")]
        public int Y
        {
        	get { return m_y; }
        }

        [ContextProperty("Z", "Z")]
        public int Z
        {
        	get { return m_z; }
        }

        [ContextProperty("Zoom", "Zoom")]
        public int Zoom
        {
        	get { return m_zoom; }
        }

        [ContextProperty("Вверх", "Up")]
        public int Up
        {
        	get { return m_up; }
        }

        [ContextProperty("Вниз", "Down")]
        public int Down
        {
        	get { return m_down; }
        }

        [ContextProperty("Вставить", "Insert")]
        public int Insert
        {
        	get { return m_insert; }
        }

        [ContextProperty("Деление", "Divide")]
        public int Divide
        {
        	get { return m_divide; }
        }

        [ContextProperty("Десятичное", "Decimal")]
        public int Decimal
        {
        	get { return m_decimal; }
        }

        [ContextProperty("Добавить", "Add")]
        public int Add
        {
        	get { return m_add; }
        }

        [ContextProperty("Домой", "Home")]
        public int Home
        {
        	get { return m_home; }
        }

        [ContextProperty("ЛеваяКнопкаМыши", "LButton")]
        public int LButton
        {
        	get { return m_lButton; }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
        	get { return m_left; }
        }

        [ContextProperty("Меню", "Menu")]
        public int Menu
        {
        	get { return m_menu; }
        }

        [ContextProperty("Назад", "Back")]
        public int Back
        {
        	get { return m_back; }
        }

        [ContextProperty("Отмена", "Cancel")]
        public int Cancel
        {
        	get { return m_cancel; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("Очистить", "Clear")]
        public int Clear
        {
        	get { return m_clear; }
        }

        [ContextProperty("Помощь", "Help")]
        public int Help
        {
        	get { return m_help; }
        }

        [ContextProperty("ПраваяКнопкаМыши", "RButton")]
        public int RButton
        {
        	get { return m_rButton; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
        	get { return m_right; }
        }

        [ContextProperty("Пробел", "Space")]
        public int Space
        {
        	get { return m_space; }
        }

        [ContextProperty("СредняяКнопкаМыши", "MButton")]
        public int MButton
        {
        	get { return m_mButton; }
        }

        [ContextProperty("Удалить", "Delete")]
        public int Delete
        {
        	get { return m_delete; }
        }
    }
}
