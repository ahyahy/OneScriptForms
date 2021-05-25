using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСочетаниеКлавиш", "ClShortcut")]
    public class ClShortcut : AutoContext<ClShortcut>
    {
        private int m_none = (int)System.Windows.Forms.Shortcut.None; // 0 Никакая комбинация клавиш не связана с пунктом меню.
        private int m_ins = (int)System.Windows.Forms.Shortcut.Ins; // 45 Сочетание клавиш INSERT.
        private int m_del = (int)System.Windows.Forms.Shortcut.Del; // 46 Сочетание клавиш DELETE.
        private int m_f1 = (int)System.Windows.Forms.Shortcut.F1; // 112 Сочетание клавиш F1.
        private int m_f2 = (int)System.Windows.Forms.Shortcut.F2; // 113 Сочетание клавиш F2.
        private int m_f3 = (int)System.Windows.Forms.Shortcut.F3; // 114 Сочетание клавиш F3.
        private int m_f4 = (int)System.Windows.Forms.Shortcut.F4; // 115 Сочетание клавиш F4.
        private int m_f5 = (int)System.Windows.Forms.Shortcut.F5; // 116 Сочетание клавиш F5.
        private int m_f6 = (int)System.Windows.Forms.Shortcut.F6; // 117 Сочетание клавиш F6.
        private int m_f7 = (int)System.Windows.Forms.Shortcut.F7; // 118 Сочетание клавиш F7.
        private int m_f8 = (int)System.Windows.Forms.Shortcut.F8; // 119 Сочетание клавиш F8.
        private int m_f9 = (int)System.Windows.Forms.Shortcut.F9; // 120 Сочетание клавиш F9.
        private int m_f10 = (int)System.Windows.Forms.Shortcut.F10; // 121 Сочетание клавиш F10.
        private int m_f11 = (int)System.Windows.Forms.Shortcut.F11; // 122 Сочетание клавиш F11.
        private int m_f12 = (int)System.Windows.Forms.Shortcut.F12; // 123 Сочетание клавиш F12.
        private int m_shiftIns = (int)System.Windows.Forms.Shortcut.ShiftIns; // 65581 Сочетание клавиш SHIFT + INSERT.
        private int m_shiftDel = (int)System.Windows.Forms.Shortcut.ShiftDel; // 65582 Сочетание клавиш SHIFT + DELETE.
        private int m_shiftF1 = (int)System.Windows.Forms.Shortcut.ShiftF1; // 65648 Сочетание клавиш SHIFT + F1.
        private int m_shiftF2 = (int)System.Windows.Forms.Shortcut.ShiftF2; // 65649 Сочетание клавиш SHIFT + F2.
        private int m_shiftF3 = (int)System.Windows.Forms.Shortcut.ShiftF3; // 65650 Сочетание клавиш SHIFT + F3.
        private int m_shiftF4 = (int)System.Windows.Forms.Shortcut.ShiftF4; // 65651 Сочетание клавиш SHIFT + F4.
        private int m_shiftF5 = (int)System.Windows.Forms.Shortcut.ShiftF5; // 65652 Сочетание клавиш SHIFT + F5.
        private int m_shiftF6 = (int)System.Windows.Forms.Shortcut.ShiftF6; // 65653 Сочетание клавиш SHIFT + F6.
        private int m_shiftF7 = (int)System.Windows.Forms.Shortcut.ShiftF7; // 65654 Сочетание клавиш SHIFT + F7.
        private int m_shiftF8 = (int)System.Windows.Forms.Shortcut.ShiftF8; // 65655 Сочетание клавиш SHIFT + F8.
        private int m_shiftF9 = (int)System.Windows.Forms.Shortcut.ShiftF9; // 65656 Сочетание клавиш SHIFT + F9.
        private int m_shiftF10 = (int)System.Windows.Forms.Shortcut.ShiftF10; // 65657 Сочетание клавиш SHIFT + F10.
        private int m_shiftF11 = (int)System.Windows.Forms.Shortcut.ShiftF11; // 65658 Сочетание клавиш SHIFT + F11.
        private int m_shiftF12 = (int)System.Windows.Forms.Shortcut.ShiftF12; // 65659 Сочетание клавиш SHIFT + F12.
        private int m_ctrlIns = (int)System.Windows.Forms.Shortcut.CtrlIns; // 131117 Сочетание клавиш CTRL + INSERT.
        private int m_ctrlDel = (int)System.Windows.Forms.Shortcut.CtrlDel; // 131118 Сочетание клавиш CTRL + DELETE.
        private int m_ctrl0 = (int)System.Windows.Forms.Shortcut.Ctrl0; // 131120 Сочетание клавиш CTRL + 0.
        private int m_ctrl1 = (int)System.Windows.Forms.Shortcut.Ctrl1; // 131121 Сочетание клавиш CTRL + 1.
        private int m_ctrl2 = (int)System.Windows.Forms.Shortcut.Ctrl2; // 131122 Сочетание клавиш CTRL + 2.
        private int m_ctrl3 = (int)System.Windows.Forms.Shortcut.Ctrl3; // 131123 Сочетание клавиш CTRL + 3.
        private int m_ctrl4 = (int)System.Windows.Forms.Shortcut.Ctrl4; // 131124 Сочетание клавиш CTRL + 4.
        private int m_ctrl5 = (int)System.Windows.Forms.Shortcut.Ctrl5; // 131125 Сочетание клавиш CTRL + 5.
        private int m_ctrl6 = (int)System.Windows.Forms.Shortcut.Ctrl6; // 131126 Сочетание клавиш CTRL + 6.
        private int m_ctrl7 = (int)System.Windows.Forms.Shortcut.Ctrl7; // 131127 Сочетание клавиш CTRL + 7.
        private int m_ctrl8 = (int)System.Windows.Forms.Shortcut.Ctrl8; // 131128 Сочетание клавиш CTRL + 8.
        private int m_ctrl9 = (int)System.Windows.Forms.Shortcut.Ctrl9; // 131129 Сочетание клавиш CTRL + 9.
        private int m_ctrlA = (int)System.Windows.Forms.Shortcut.CtrlA; // 131137 Сочетание клавиш CTRL + A.
        private int m_ctrlB = (int)System.Windows.Forms.Shortcut.CtrlB; // 131138 Сочетание клавиш CTRL + B.
        private int m_ctrlC = (int)System.Windows.Forms.Shortcut.CtrlC; // 131139 Сочетание клавиш CTRL + C.
        private int m_ctrlD = (int)System.Windows.Forms.Shortcut.CtrlD; // 131140 Сочетание клавиш CTRL + D.
        private int m_ctrlE = (int)System.Windows.Forms.Shortcut.CtrlE; // 131141 Сочетание клавиш CTRL + E.
        private int m_ctrlF = (int)System.Windows.Forms.Shortcut.CtrlF; // 131142 Сочетание клавиш CTRL + F.
        private int m_ctrlG = (int)System.Windows.Forms.Shortcut.CtrlG; // 131143 Сочетание клавиш CTRL + G.
        private int m_ctrlH = (int)System.Windows.Forms.Shortcut.CtrlH; // 131144 Сочетание клавиш CTRL + H.
        private int m_ctrlI = (int)System.Windows.Forms.Shortcut.CtrlI; // 131145 Сочетание клавиш CTRL + I.
        private int m_ctrlJ = (int)System.Windows.Forms.Shortcut.CtrlJ; // 131146 Сочетание клавиш CTRL + J.
        private int m_ctrlK = (int)System.Windows.Forms.Shortcut.CtrlK; // 131147 Сочетание клавиш CTRL + K.
        private int m_ctrlL = (int)System.Windows.Forms.Shortcut.CtrlL; // 131148 Сочетание клавиш CTRL + L.
        private int m_ctrlM = (int)System.Windows.Forms.Shortcut.CtrlM; // 131149 Сочетание клавиш CTRL + M.
        private int m_ctrlN = (int)System.Windows.Forms.Shortcut.CtrlN; // 131150 Сочетание клавиш CTRL + N.
        private int m_ctrlO = (int)System.Windows.Forms.Shortcut.CtrlO; // 131151 Сочетание клавиш CTRL + O.
        private int m_ctrlP = (int)System.Windows.Forms.Shortcut.CtrlP; // 131152 Сочетание клавиш CTRL + P.
        private int m_ctrlQ = (int)System.Windows.Forms.Shortcut.CtrlQ; // 131153 Сочетание клавиш CTRL + Q.
        private int m_ctrlR = (int)System.Windows.Forms.Shortcut.CtrlR; // 131154 Сочетание клавиш CTRL + R.
        private int m_ctrlS = (int)System.Windows.Forms.Shortcut.CtrlS; // 131155 Сочетание клавиш CTRL + S.
        private int m_ctrlT = (int)System.Windows.Forms.Shortcut.CtrlT; // 131156 Сочетание клавиш CTRL + T.
        private int m_ctrlU = (int)System.Windows.Forms.Shortcut.CtrlU; // 131157 Сочетание клавиш CTRL + U
        private int m_ctrlV = (int)System.Windows.Forms.Shortcut.CtrlV; // 131158 Сочетание клавиш CTRL + V.
        private int m_ctrlW = (int)System.Windows.Forms.Shortcut.CtrlW; // 131159 Сочетание клавиш CTRL + W.
        private int m_ctrlX = (int)System.Windows.Forms.Shortcut.CtrlX; // 131160 Сочетание клавиш CTRL + X.
        private int m_ctrlY = (int)System.Windows.Forms.Shortcut.CtrlY; // 131161 Сочетание клавиш CTRL + Y.
        private int m_ctrlZ = (int)System.Windows.Forms.Shortcut.CtrlZ; // 131162 Сочетание клавиш CTRL + Z.
        private int m_ctrlF1 = (int)System.Windows.Forms.Shortcut.CtrlF1; // 131184 Сочетание клавиш CTRL + F1.
        private int m_ctrlF2 = (int)System.Windows.Forms.Shortcut.CtrlF2; // 131185 Сочетание клавиш CTRL + F2.
        private int m_ctrlF3 = (int)System.Windows.Forms.Shortcut.CtrlF3; // 131186 Сочетание клавиш CTRL + F3.
        private int m_ctrlF4 = (int)System.Windows.Forms.Shortcut.CtrlF4; // 131187 Сочетание клавиш CTRL + F4.
        private int m_ctrlF5 = (int)System.Windows.Forms.Shortcut.CtrlF5; // 131188 Сочетание клавиш CTRL + F5.
        private int m_ctrlF6 = (int)System.Windows.Forms.Shortcut.CtrlF6; // 131189 Сочетание клавиш CTRL + F6.
        private int m_ctrlF7 = (int)System.Windows.Forms.Shortcut.CtrlF7; // 131190 Сочетание клавиш CTRL + F7.
        private int m_ctrlF8 = (int)System.Windows.Forms.Shortcut.CtrlF8; // 131191 Сочетание клавиш CTRL + F8.
        private int m_ctrlF9 = (int)System.Windows.Forms.Shortcut.CtrlF9; // 131192 Сочетание клавиш CTRL + F9.
        private int m_ctrlF10 = (int)System.Windows.Forms.Shortcut.CtrlF10; // 131193 Сочетание клавиш CTRL + F10.
        private int m_ctrlF11 = (int)System.Windows.Forms.Shortcut.CtrlF11; // 131194 Сочетание клавиш CTRL + F11.
        private int m_ctrlF12 = (int)System.Windows.Forms.Shortcut.CtrlF12; // 131195 Сочетание клавиш CTRL + F12.
        private int m_ctrlShift0 = (int)System.Windows.Forms.Shortcut.CtrlShift0; // 196656 Сочетание клавиш CTRL + SHIFT + 0.
        private int m_ctrlShift1 = (int)System.Windows.Forms.Shortcut.CtrlShift1; // 196657 Сочетание клавиш CTRL + SHIFT + 1.
        private int m_ctrlShift2 = (int)System.Windows.Forms.Shortcut.CtrlShift2; // 196658 Сочетание клавиш CTRL + SHIFT + 2.
        private int m_ctrlShift3 = (int)System.Windows.Forms.Shortcut.CtrlShift3; // 196659 Сочетание клавиш CTRL + SHIFT + 3.
        private int m_ctrlShift4 = (int)System.Windows.Forms.Shortcut.CtrlShift4; // 196660 Сочетание клавиш CTRL + SHIFT + 4.
        private int m_ctrlShift5 = (int)System.Windows.Forms.Shortcut.CtrlShift5; // 196661 Сочетание клавиш CTRL + SHIFT + 5.
        private int m_ctrlShift6 = (int)System.Windows.Forms.Shortcut.CtrlShift6; // 196662 Сочетание клавиш CTRL + SHIFT + 6.
        private int m_ctrlShift7 = (int)System.Windows.Forms.Shortcut.CtrlShift7; // 196663 Сочетание клавиш CTRL + SHIFT + 7.
        private int m_ctrlShift8 = (int)System.Windows.Forms.Shortcut.CtrlShift8; // 196664 Сочетание клавиш CTRL + SHIFT + 8.
        private int m_ctrlShift9 = (int)System.Windows.Forms.Shortcut.CtrlShift9; // 196665 Сочетание клавиш CTRL + SHIFT + 9.
        private int m_ctrlShiftA = (int)System.Windows.Forms.Shortcut.CtrlShiftA; // 196673 Сочетание клавиш CTRL + SHIFT + A.
        private int m_ctrlShiftB = (int)System.Windows.Forms.Shortcut.CtrlShiftB; // 196674 Сочетание клавиш CTRL + SHIFT + B.
        private int m_ctrlShiftC = (int)System.Windows.Forms.Shortcut.CtrlShiftC; // 196675 Сочетание клавиш CTRL + SHIFT + C.
        private int m_ctrlShiftD = (int)System.Windows.Forms.Shortcut.CtrlShiftD; // 196676 Сочетание клавиш CTRL + SHIFT + D.
        private int m_ctrlShiftE = (int)System.Windows.Forms.Shortcut.CtrlShiftE; // 196677 Сочетание клавиш CTRL + SHIFT + E.
        private int m_ctrlShiftF = (int)System.Windows.Forms.Shortcut.CtrlShiftF; // 196678 Сочетание клавиш CTRL + SHIFT + F.
        private int m_ctrlShiftG = (int)System.Windows.Forms.Shortcut.CtrlShiftG; // 196679 Сочетание клавиш CTRL + SHIFT + G.
        private int m_ctrlShiftH = (int)System.Windows.Forms.Shortcut.CtrlShiftH; // 196680 Сочетание клавиш CTRL + SHIFT + H.
        private int m_ctrlShiftI = (int)System.Windows.Forms.Shortcut.CtrlShiftI; // 196681 Сочетание клавиш CTRL + SHIFT + I.
        private int m_ctrlShiftJ = (int)System.Windows.Forms.Shortcut.CtrlShiftJ; // 196682 Сочетание клавиш CTRL + SHIFT + J.
        private int m_ctrlShiftK = (int)System.Windows.Forms.Shortcut.CtrlShiftK; // 196683 Сочетание клавиш CTRL + SHIFT + K.
        private int m_ctrlShiftL = (int)System.Windows.Forms.Shortcut.CtrlShiftL; // 196684 Сочетание клавиш CTRL + SHIFT + L.
        private int m_ctrlShiftM = (int)System.Windows.Forms.Shortcut.CtrlShiftM; // 196685 Сочетание клавиш CTRL + SHIFT + M.
        private int m_ctrlShiftN = (int)System.Windows.Forms.Shortcut.CtrlShiftN; // 196686 Сочетание клавиш CTRL + SHIFT + N.
        private int m_ctrlShiftO = (int)System.Windows.Forms.Shortcut.CtrlShiftO; // 196687 Сочетание клавиш CTRL + SHIFT + O.
        private int m_ctrlShiftP = (int)System.Windows.Forms.Shortcut.CtrlShiftP; // 196688 Сочетание клавиш CTRL + SHIFT + P.
        private int m_ctrlShiftQ = (int)System.Windows.Forms.Shortcut.CtrlShiftQ; // 196689 Сочетание клавиш CTRL + SHIFT + Q.
        private int m_ctrlShiftR = (int)System.Windows.Forms.Shortcut.CtrlShiftR; // 196690 Сочетание клавиш CTRL + SHIFT + R.
        private int m_ctrlShiftS = (int)System.Windows.Forms.Shortcut.CtrlShiftS; // 196691 Сочетание клавиш CTRL + SHIFT + S.
        private int m_ctrlShiftT = (int)System.Windows.Forms.Shortcut.CtrlShiftT; // 196692 Сочетание клавиш CTRL + SHIFT + T.
        private int m_ctrlShiftU = (int)System.Windows.Forms.Shortcut.CtrlShiftU; // 196693 Сочетание клавиш CTRL + SHIFT + U.
        private int m_ctrlShiftV = (int)System.Windows.Forms.Shortcut.CtrlShiftV; // 196694 Сочетание клавиш CTRL + SHIFT + V.
        private int m_ctrlShiftW = (int)System.Windows.Forms.Shortcut.CtrlShiftW; // 196695 Сочетание клавиш CTRL + SHIFT + W.
        private int m_ctrlShiftX = (int)System.Windows.Forms.Shortcut.CtrlShiftX; // 196696 Сочетание клавиш CTRL + SHIFT + X.
        private int m_ctrlShiftY = (int)System.Windows.Forms.Shortcut.CtrlShiftY; // 196697 Сочетание клавиш CTRL + SHIFT + Y.
        private int m_ctrlShiftZ = (int)System.Windows.Forms.Shortcut.CtrlShiftZ; // 196698 Сочетание клавиш CTRL + SHIFT + Z.
        private int m_ctrlShiftF1 = (int)System.Windows.Forms.Shortcut.CtrlShiftF1; // 196720 Сочетание клавиш CTRL + SHIFT + F1.
        private int m_ctrlShiftF2 = (int)System.Windows.Forms.Shortcut.CtrlShiftF2; // 196721 Сочетание клавиш CTRL + SHIFT + F2.
        private int m_ctrlShiftF3 = (int)System.Windows.Forms.Shortcut.CtrlShiftF3; // 196722 Сочетание клавиш CTRL + SHIFT + F3.
        private int m_ctrlShiftF4 = (int)System.Windows.Forms.Shortcut.CtrlShiftF4; // 196723 Сочетание клавиш CTRL + SHIFT + F4.
        private int m_ctrlShiftF5 = (int)System.Windows.Forms.Shortcut.CtrlShiftF5; // 196724 Сочетание клавиш CTRL + SHIFT + F5.
        private int m_ctrlShiftF6 = (int)System.Windows.Forms.Shortcut.CtrlShiftF6; // 196725 Сочетание клавиш CTRL + SHIFT + F6.
        private int m_ctrlShiftF7 = (int)System.Windows.Forms.Shortcut.CtrlShiftF7; // 196726 Сочетание клавиш CTRL + SHIFT + F7.
        private int m_ctrlShiftF8 = (int)System.Windows.Forms.Shortcut.CtrlShiftF8; // 196727 Сочетание клавиш CTRL + SHIFT + F8.
        private int m_ctrlShiftF9 = (int)System.Windows.Forms.Shortcut.CtrlShiftF9; // 196728 Сочетание клавиш CTRL + SHIFT + F9.
        private int m_ctrlShiftF10 = (int)System.Windows.Forms.Shortcut.CtrlShiftF10; // 196729 Сочетание клавиш CTRL + SHIFT + F10.
        private int m_ctrlShiftF11 = (int)System.Windows.Forms.Shortcut.CtrlShiftF11; // 196730 Сочетание клавиш CTRL + SHIFT + F11.
        private int m_ctrlShiftF12 = (int)System.Windows.Forms.Shortcut.CtrlShiftF12; // 196731 Сочетание клавиш CTRL + SHIFT + F12.
        private int m_altBksp = (int)System.Windows.Forms.Shortcut.AltBksp; // 262152 Сочетание клавиш ALT + BACKSPACE.
        private int m_alt0 = (int)System.Windows.Forms.Shortcut.Alt0; // 262192 Сочетание клавиш ALT + 0.
        private int m_alt1 = (int)System.Windows.Forms.Shortcut.Alt1; // 262193 Сочетание клавиш ALT + 1.
        private int m_alt2 = (int)System.Windows.Forms.Shortcut.Alt2; // 262194 Сочетание клавиш ALT + 2.
        private int m_alt3 = (int)System.Windows.Forms.Shortcut.Alt3; // 262195 Сочетание клавиш ALT + 3.
        private int m_alt4 = (int)System.Windows.Forms.Shortcut.Alt4; // 262196 Сочетание клавиш ALT + 4.
        private int m_alt5 = (int)System.Windows.Forms.Shortcut.Alt5; // 262197 Сочетание клавиш ALT + 5.
        private int m_alt6 = (int)System.Windows.Forms.Shortcut.Alt6; // 262198 Сочетание клавиш ALT + 6.
        private int m_alt7 = (int)System.Windows.Forms.Shortcut.Alt7; // 262199 Сочетание клавиш ALT + 7.
        private int m_alt8 = (int)System.Windows.Forms.Shortcut.Alt8; // 262200 Сочетание клавиш ALT + 8.
        private int m_alt9 = (int)System.Windows.Forms.Shortcut.Alt9; // 262201 Сочетание клавиш ALT + 9.
        private int m_altF1 = (int)System.Windows.Forms.Shortcut.AltF1; // 262256 Сочетание клавиш ALT + F1.
        private int m_altF2 = (int)System.Windows.Forms.Shortcut.AltF2; // 262257 Сочетание клавиш ALT + F2.
        private int m_altF3 = (int)System.Windows.Forms.Shortcut.AltF3; // 262258 Сочетание клавиш ALT + F3.
        private int m_altF4 = (int)System.Windows.Forms.Shortcut.AltF4; // 262259 Сочетание клавиш ALT + F4.
        private int m_altF5 = (int)System.Windows.Forms.Shortcut.AltF5; // 262260 Сочетание клавиш ALT + F5.
        private int m_altF6 = (int)System.Windows.Forms.Shortcut.AltF6; // 262261 Сочетание клавиш ALT + F6.
        private int m_altF7 = (int)System.Windows.Forms.Shortcut.AltF7; // 262262 Сочетание клавиш ALT + F7.
        private int m_altF8 = (int)System.Windows.Forms.Shortcut.AltF8; // 262263 Сочетание клавиш ALT + F8.
        private int m_altF9 = (int)System.Windows.Forms.Shortcut.AltF9; // 262264 Сочетание клавиш ALT + F9.
        private int m_altF10 = (int)System.Windows.Forms.Shortcut.AltF10; // 262265 Сочетание клавиш ALT + F10.
        private int m_altF11 = (int)System.Windows.Forms.Shortcut.AltF11; // 262266 Сочетание клавиш ALT + F11.
        private int m_altF12 = (int)System.Windows.Forms.Shortcut.AltF12; // 262267 Сочетание клавиш ALT + F12.

        [ContextProperty("Alt0", "Alt0")]
        public int Alt0
        {
        	get { return m_alt0; }
        }

        [ContextProperty("Alt1", "Alt1")]
        public int Alt1
        {
        	get { return m_alt1; }
        }

        [ContextProperty("Alt2", "Alt2")]
        public int Alt2
        {
        	get { return m_alt2; }
        }

        [ContextProperty("Alt3", "Alt3")]
        public int Alt3
        {
        	get { return m_alt3; }
        }

        [ContextProperty("Alt4", "Alt4")]
        public int Alt4
        {
        	get { return m_alt4; }
        }

        [ContextProperty("Alt5", "Alt5")]
        public int Alt5
        {
        	get { return m_alt5; }
        }

        [ContextProperty("Alt6", "Alt6")]
        public int Alt6
        {
        	get { return m_alt6; }
        }

        [ContextProperty("Alt7", "Alt7")]
        public int Alt7
        {
        	get { return m_alt7; }
        }

        [ContextProperty("Alt8", "Alt8")]
        public int Alt8
        {
        	get { return m_alt8; }
        }

        [ContextProperty("Alt9", "Alt9")]
        public int Alt9
        {
        	get { return m_alt9; }
        }

        [ContextProperty("AltBksp", "AltBksp")]
        public int AltBksp
        {
        	get { return m_altBksp; }
        }

        [ContextProperty("AltF1", "AltF1")]
        public int AltF1
        {
        	get { return m_altF1; }
        }

        [ContextProperty("AltF10", "AltF10")]
        public int AltF10
        {
        	get { return m_altF10; }
        }

        [ContextProperty("AltF11", "AltF11")]
        public int AltF11
        {
        	get { return m_altF11; }
        }

        [ContextProperty("AltF12", "AltF12")]
        public int AltF12
        {
        	get { return m_altF12; }
        }

        [ContextProperty("AltF2", "AltF2")]
        public int AltF2
        {
        	get { return m_altF2; }
        }

        [ContextProperty("AltF3", "AltF3")]
        public int AltF3
        {
        	get { return m_altF3; }
        }

        [ContextProperty("AltF4", "AltF4")]
        public int AltF4
        {
        	get { return m_altF4; }
        }

        [ContextProperty("AltF5", "AltF5")]
        public int AltF5
        {
        	get { return m_altF5; }
        }

        [ContextProperty("AltF6", "AltF6")]
        public int AltF6
        {
        	get { return m_altF6; }
        }

        [ContextProperty("AltF7", "AltF7")]
        public int AltF7
        {
        	get { return m_altF7; }
        }

        [ContextProperty("AltF8", "AltF8")]
        public int AltF8
        {
        	get { return m_altF8; }
        }

        [ContextProperty("AltF9", "AltF9")]
        public int AltF9
        {
        	get { return m_altF9; }
        }

        [ContextProperty("Ctrl0", "Ctrl0")]
        public int Ctrl0
        {
        	get { return m_ctrl0; }
        }

        [ContextProperty("Ctrl1", "Ctrl1")]
        public int Ctrl1
        {
        	get { return m_ctrl1; }
        }

        [ContextProperty("Ctrl2", "Ctrl2")]
        public int Ctrl2
        {
        	get { return m_ctrl2; }
        }

        [ContextProperty("Ctrl3", "Ctrl3")]
        public int Ctrl3
        {
        	get { return m_ctrl3; }
        }

        [ContextProperty("Ctrl4", "Ctrl4")]
        public int Ctrl4
        {
        	get { return m_ctrl4; }
        }

        [ContextProperty("Ctrl5", "Ctrl5")]
        public int Ctrl5
        {
        	get { return m_ctrl5; }
        }

        [ContextProperty("Ctrl6", "Ctrl6")]
        public int Ctrl6
        {
        	get { return m_ctrl6; }
        }

        [ContextProperty("Ctrl7", "Ctrl7")]
        public int Ctrl7
        {
        	get { return m_ctrl7; }
        }

        [ContextProperty("Ctrl8", "Ctrl8")]
        public int Ctrl8
        {
        	get { return m_ctrl8; }
        }

        [ContextProperty("Ctrl9", "Ctrl9")]
        public int Ctrl9
        {
        	get { return m_ctrl9; }
        }

        [ContextProperty("CtrlA", "CtrlA")]
        public int CtrlA
        {
        	get { return m_ctrlA; }
        }

        [ContextProperty("CtrlB", "CtrlB")]
        public int CtrlB
        {
        	get { return m_ctrlB; }
        }

        [ContextProperty("CtrlC", "CtrlC")]
        public int CtrlC
        {
        	get { return m_ctrlC; }
        }

        [ContextProperty("CtrlD", "CtrlD")]
        public int CtrlD
        {
        	get { return m_ctrlD; }
        }

        [ContextProperty("CtrlDel", "CtrlDel")]
        public int CtrlDel
        {
        	get { return m_ctrlDel; }
        }

        [ContextProperty("CtrlE", "CtrlE")]
        public int CtrlE
        {
        	get { return m_ctrlE; }
        }

        [ContextProperty("CtrlF", "CtrlF")]
        public int CtrlF
        {
        	get { return m_ctrlF; }
        }

        [ContextProperty("CtrlF1", "CtrlF1")]
        public int CtrlF1
        {
        	get { return m_ctrlF1; }
        }

        [ContextProperty("CtrlF10", "CtrlF10")]
        public int CtrlF10
        {
        	get { return m_ctrlF10; }
        }

        [ContextProperty("CtrlF11", "CtrlF11")]
        public int CtrlF11
        {
        	get { return m_ctrlF11; }
        }

        [ContextProperty("CtrlF12", "CtrlF12")]
        public int CtrlF12
        {
        	get { return m_ctrlF12; }
        }

        [ContextProperty("CtrlF2", "CtrlF2")]
        public int CtrlF2
        {
        	get { return m_ctrlF2; }
        }

        [ContextProperty("CtrlF3", "CtrlF3")]
        public int CtrlF3
        {
        	get { return m_ctrlF3; }
        }

        [ContextProperty("CtrlF4", "CtrlF4")]
        public int CtrlF4
        {
        	get { return m_ctrlF4; }
        }

        [ContextProperty("CtrlF5", "CtrlF5")]
        public int CtrlF5
        {
        	get { return m_ctrlF5; }
        }

        [ContextProperty("CtrlF6", "CtrlF6")]
        public int CtrlF6
        {
        	get { return m_ctrlF6; }
        }

        [ContextProperty("CtrlF7", "CtrlF7")]
        public int CtrlF7
        {
        	get { return m_ctrlF7; }
        }

        [ContextProperty("CtrlF8", "CtrlF8")]
        public int CtrlF8
        {
        	get { return m_ctrlF8; }
        }

        [ContextProperty("CtrlF9", "CtrlF9")]
        public int CtrlF9
        {
        	get { return m_ctrlF9; }
        }

        [ContextProperty("CtrlG", "CtrlG")]
        public int CtrlG
        {
        	get { return m_ctrlG; }
        }

        [ContextProperty("CtrlH", "CtrlH")]
        public int CtrlH
        {
        	get { return m_ctrlH; }
        }

        [ContextProperty("CtrlI", "CtrlI")]
        public int CtrlI
        {
        	get { return m_ctrlI; }
        }

        [ContextProperty("CtrlIns", "CtrlIns")]
        public int CtrlIns
        {
        	get { return m_ctrlIns; }
        }

        [ContextProperty("CtrlJ", "CtrlJ")]
        public int CtrlJ
        {
        	get { return m_ctrlJ; }
        }

        [ContextProperty("CtrlK", "CtrlK")]
        public int CtrlK
        {
        	get { return m_ctrlK; }
        }

        [ContextProperty("CtrlL", "CtrlL")]
        public int CtrlL
        {
        	get { return m_ctrlL; }
        }

        [ContextProperty("CtrlM", "CtrlM")]
        public int CtrlM
        {
        	get { return m_ctrlM; }
        }

        [ContextProperty("CtrlN", "CtrlN")]
        public int CtrlN
        {
        	get { return m_ctrlN; }
        }

        [ContextProperty("CtrlO", "CtrlO")]
        public int CtrlO
        {
        	get { return m_ctrlO; }
        }

        [ContextProperty("CtrlP", "CtrlP")]
        public int CtrlP
        {
        	get { return m_ctrlP; }
        }

        [ContextProperty("CtrlQ", "CtrlQ")]
        public int CtrlQ
        {
        	get { return m_ctrlQ; }
        }

        [ContextProperty("CtrlR", "CtrlR")]
        public int CtrlR
        {
        	get { return m_ctrlR; }
        }

        [ContextProperty("CtrlS", "CtrlS")]
        public int CtrlS
        {
        	get { return m_ctrlS; }
        }

        [ContextProperty("CtrlShift0", "CtrlShift0")]
        public int CtrlShift0
        {
        	get { return m_ctrlShift0; }
        }

        [ContextProperty("CtrlShift1", "CtrlShift1")]
        public int CtrlShift1
        {
        	get { return m_ctrlShift1; }
        }

        [ContextProperty("CtrlShift2", "CtrlShift2")]
        public int CtrlShift2
        {
        	get { return m_ctrlShift2; }
        }

        [ContextProperty("CtrlShift3", "CtrlShift3")]
        public int CtrlShift3
        {
        	get { return m_ctrlShift3; }
        }

        [ContextProperty("CtrlShift4", "CtrlShift4")]
        public int CtrlShift4
        {
        	get { return m_ctrlShift4; }
        }

        [ContextProperty("CtrlShift5", "CtrlShift5")]
        public int CtrlShift5
        {
        	get { return m_ctrlShift5; }
        }

        [ContextProperty("CtrlShift6", "CtrlShift6")]
        public int CtrlShift6
        {
        	get { return m_ctrlShift6; }
        }

        [ContextProperty("CtrlShift7", "CtrlShift7")]
        public int CtrlShift7
        {
        	get { return m_ctrlShift7; }
        }

        [ContextProperty("CtrlShift8", "CtrlShift8")]
        public int CtrlShift8
        {
        	get { return m_ctrlShift8; }
        }

        [ContextProperty("CtrlShift9", "CtrlShift9")]
        public int CtrlShift9
        {
        	get { return m_ctrlShift9; }
        }

        [ContextProperty("CtrlShiftA", "CtrlShiftA")]
        public int CtrlShiftA
        {
        	get { return m_ctrlShiftA; }
        }

        [ContextProperty("CtrlShiftB", "CtrlShiftB")]
        public int CtrlShiftB
        {
        	get { return m_ctrlShiftB; }
        }

        [ContextProperty("CtrlShiftC", "CtrlShiftC")]
        public int CtrlShiftC
        {
        	get { return m_ctrlShiftC; }
        }

        [ContextProperty("CtrlShiftD", "CtrlShiftD")]
        public int CtrlShiftD
        {
        	get { return m_ctrlShiftD; }
        }

        [ContextProperty("CtrlShiftE", "CtrlShiftE")]
        public int CtrlShiftE
        {
        	get { return m_ctrlShiftE; }
        }

        [ContextProperty("CtrlShiftF", "CtrlShiftF")]
        public int CtrlShiftF
        {
        	get { return m_ctrlShiftF; }
        }

        [ContextProperty("CtrlShiftF1", "CtrlShiftF1")]
        public int CtrlShiftF1
        {
        	get { return m_ctrlShiftF1; }
        }

        [ContextProperty("CtrlShiftF10", "CtrlShiftF10")]
        public int CtrlShiftF10
        {
        	get { return m_ctrlShiftF10; }
        }

        [ContextProperty("CtrlShiftF11", "CtrlShiftF11")]
        public int CtrlShiftF11
        {
        	get { return m_ctrlShiftF11; }
        }

        [ContextProperty("CtrlShiftF12", "CtrlShiftF12")]
        public int CtrlShiftF12
        {
        	get { return m_ctrlShiftF12; }
        }

        [ContextProperty("CtrlShiftF2", "CtrlShiftF2")]
        public int CtrlShiftF2
        {
        	get { return m_ctrlShiftF2; }
        }

        [ContextProperty("CtrlShiftF3", "CtrlShiftF3")]
        public int CtrlShiftF3
        {
        	get { return m_ctrlShiftF3; }
        }

        [ContextProperty("CtrlShiftF4", "CtrlShiftF4")]
        public int CtrlShiftF4
        {
        	get { return m_ctrlShiftF4; }
        }

        [ContextProperty("CtrlShiftF5", "CtrlShiftF5")]
        public int CtrlShiftF5
        {
        	get { return m_ctrlShiftF5; }
        }

        [ContextProperty("CtrlShiftF6", "CtrlShiftF6")]
        public int CtrlShiftF6
        {
        	get { return m_ctrlShiftF6; }
        }

        [ContextProperty("CtrlShiftF7", "CtrlShiftF7")]
        public int CtrlShiftF7
        {
        	get { return m_ctrlShiftF7; }
        }

        [ContextProperty("CtrlShiftF8", "CtrlShiftF8")]
        public int CtrlShiftF8
        {
        	get { return m_ctrlShiftF8; }
        }

        [ContextProperty("CtrlShiftF9", "CtrlShiftF9")]
        public int CtrlShiftF9
        {
        	get { return m_ctrlShiftF9; }
        }

        [ContextProperty("CtrlShiftG", "CtrlShiftG")]
        public int CtrlShiftG
        {
        	get { return m_ctrlShiftG; }
        }

        [ContextProperty("CtrlShiftH", "CtrlShiftH")]
        public int CtrlShiftH
        {
        	get { return m_ctrlShiftH; }
        }

        [ContextProperty("CtrlShiftI", "CtrlShiftI")]
        public int CtrlShiftI
        {
        	get { return m_ctrlShiftI; }
        }

        [ContextProperty("CtrlShiftJ", "CtrlShiftJ")]
        public int CtrlShiftJ
        {
        	get { return m_ctrlShiftJ; }
        }

        [ContextProperty("CtrlShiftK", "CtrlShiftK")]
        public int CtrlShiftK
        {
        	get { return m_ctrlShiftK; }
        }

        [ContextProperty("CtrlShiftL", "CtrlShiftL")]
        public int CtrlShiftL
        {
        	get { return m_ctrlShiftL; }
        }

        [ContextProperty("CtrlShiftM", "CtrlShiftM")]
        public int CtrlShiftM
        {
        	get { return m_ctrlShiftM; }
        }

        [ContextProperty("CtrlShiftN", "CtrlShiftN")]
        public int CtrlShiftN
        {
        	get { return m_ctrlShiftN; }
        }

        [ContextProperty("CtrlShiftO", "CtrlShiftO")]
        public int CtrlShiftO
        {
        	get { return m_ctrlShiftO; }
        }

        [ContextProperty("CtrlShiftP", "CtrlShiftP")]
        public int CtrlShiftP
        {
        	get { return m_ctrlShiftP; }
        }

        [ContextProperty("CtrlShiftQ", "CtrlShiftQ")]
        public int CtrlShiftQ
        {
        	get { return m_ctrlShiftQ; }
        }

        [ContextProperty("CtrlShiftR", "CtrlShiftR")]
        public int CtrlShiftR
        {
        	get { return m_ctrlShiftR; }
        }

        [ContextProperty("CtrlShiftS", "CtrlShiftS")]
        public int CtrlShiftS
        {
        	get { return m_ctrlShiftS; }
        }

        [ContextProperty("CtrlShiftT", "CtrlShiftT")]
        public int CtrlShiftT
        {
        	get { return m_ctrlShiftT; }
        }

        [ContextProperty("CtrlShiftU", "CtrlShiftU")]
        public int CtrlShiftU
        {
        	get { return m_ctrlShiftU; }
        }

        [ContextProperty("CtrlShiftV", "CtrlShiftV")]
        public int CtrlShiftV
        {
        	get { return m_ctrlShiftV; }
        }

        [ContextProperty("CtrlShiftW", "CtrlShiftW")]
        public int CtrlShiftW
        {
        	get { return m_ctrlShiftW; }
        }

        [ContextProperty("CtrlShiftX", "CtrlShiftX")]
        public int CtrlShiftX
        {
        	get { return m_ctrlShiftX; }
        }

        [ContextProperty("CtrlShiftY", "CtrlShiftY")]
        public int CtrlShiftY
        {
        	get { return m_ctrlShiftY; }
        }

        [ContextProperty("CtrlShiftZ", "CtrlShiftZ")]
        public int CtrlShiftZ
        {
        	get { return m_ctrlShiftZ; }
        }

        [ContextProperty("CtrlT", "CtrlT")]
        public int CtrlT
        {
        	get { return m_ctrlT; }
        }

        [ContextProperty("CtrlU", "CtrlU")]
        public int CtrlU
        {
        	get { return m_ctrlU; }
        }

        [ContextProperty("CtrlV", "CtrlV")]
        public int CtrlV
        {
        	get { return m_ctrlV; }
        }

        [ContextProperty("CtrlW", "CtrlW")]
        public int CtrlW
        {
        	get { return m_ctrlW; }
        }

        [ContextProperty("CtrlX", "CtrlX")]
        public int CtrlX
        {
        	get { return m_ctrlX; }
        }

        [ContextProperty("CtrlY", "CtrlY")]
        public int CtrlY
        {
        	get { return m_ctrlY; }
        }

        [ContextProperty("CtrlZ", "CtrlZ")]
        public int CtrlZ
        {
        	get { return m_ctrlZ; }
        }

        [ContextProperty("Del", "Del")]
        public int Del
        {
        	get { return m_del; }
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

        [ContextProperty("F2", "F2")]
        public int F2
        {
        	get { return m_f2; }
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

        [ContextProperty("Ins", "Ins")]
        public int Ins
        {
        	get { return m_ins; }
        }

        [ContextProperty("ShiftDel", "ShiftDel")]
        public int ShiftDel
        {
        	get { return m_shiftDel; }
        }

        [ContextProperty("ShiftF1", "ShiftF1")]
        public int ShiftF1
        {
        	get { return m_shiftF1; }
        }

        [ContextProperty("ShiftF10", "ShiftF10")]
        public int ShiftF10
        {
        	get { return m_shiftF10; }
        }

        [ContextProperty("ShiftF11", "ShiftF11")]
        public int ShiftF11
        {
        	get { return m_shiftF11; }
        }

        [ContextProperty("ShiftF12", "ShiftF12")]
        public int ShiftF12
        {
        	get { return m_shiftF12; }
        }

        [ContextProperty("ShiftF2", "ShiftF2")]
        public int ShiftF2
        {
        	get { return m_shiftF2; }
        }

        [ContextProperty("ShiftF3", "ShiftF3")]
        public int ShiftF3
        {
        	get { return m_shiftF3; }
        }

        [ContextProperty("ShiftF4", "ShiftF4")]
        public int ShiftF4
        {
        	get { return m_shiftF4; }
        }

        [ContextProperty("ShiftF5", "ShiftF5")]
        public int ShiftF5
        {
        	get { return m_shiftF5; }
        }

        [ContextProperty("ShiftF6", "ShiftF6")]
        public int ShiftF6
        {
        	get { return m_shiftF6; }
        }

        [ContextProperty("ShiftF7", "ShiftF7")]
        public int ShiftF7
        {
        	get { return m_shiftF7; }
        }

        [ContextProperty("ShiftF8", "ShiftF8")]
        public int ShiftF8
        {
        	get { return m_shiftF8; }
        }

        [ContextProperty("ShiftF9", "ShiftF9")]
        public int ShiftF9
        {
        	get { return m_shiftF9; }
        }

        [ContextProperty("ShiftIns", "ShiftIns")]
        public int ShiftIns
        {
        	get { return m_shiftIns; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

    }
}
