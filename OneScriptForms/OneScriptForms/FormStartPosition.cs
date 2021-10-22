using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлНачальноеПоложениеФормы", "ClFormStartPosition")]
    public class ClFormStartPosition : AutoContext<ClFormStartPosition>
    {
        private int m_manual = (int)System.Windows.Forms.FormStartPosition.Manual; // 0 Положение формы определяется свойством <B>Положение&nbsp;(Location)</B>.
        private int m_centerScreen = (int)System.Windows.Forms.FormStartPosition.CenterScreen; // 1 Форма выравнивается по центру текущего экрана.
        private int m_windowsDefaultLocation = (int)System.Windows.Forms.FormStartPosition.WindowsDefaultLocation; // 2 Форма с заданными размерами размещается в расположении, определенном по умолчанию в Windows.
        private int m_windowsDefaultBounds = (int)System.Windows.Forms.FormStartPosition.WindowsDefaultBounds; // 3 Положение формы и ее границы определены в Windows по умолчанию.
        private int m_centerParent = (int)System.Windows.Forms.FormStartPosition.CenterParent; // 4 Форма выравнивается по центру в границах родительской формы.

        [ContextProperty("Вручную", "Manual")]
        public int Manual
        {
        	get { return m_manual; }
        }

        [ContextProperty("ГраницыОкнаПоУмолчанию", "WindowsDefaultBounds")]
        public int WindowsDefaultBounds
        {
        	get { return m_windowsDefaultBounds; }
        }

        [ContextProperty("ПоложениеОкнаПоУмолчанию", "WindowsDefaultLocation")]
        public int WindowsDefaultLocation
        {
        	get { return m_windowsDefaultLocation; }
        }

        [ContextProperty("ЦентрРодителя", "CenterParent")]
        public int CenterParent
        {
        	get { return m_centerParent; }
        }

        [ContextProperty("ЦентрЭкрана", "CenterScreen")]
        public int CenterScreen
        {
        	get { return m_centerScreen; }
        }
    }
}
