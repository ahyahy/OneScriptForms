using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлАвтоРазмерПанелиСтрокиСостояния", "ClStatusBarPanelAutoSize")]
    public class ClStatusBarPanelAutoSize : AutoContext<ClStatusBarPanelAutoSize>
    {
        private int m_none = (int)System.Windows.Forms.StatusBarPanelAutoSize.None; // 1 Размер не изменяется.
        private int m_spring = (int)System.Windows.Forms.StatusBarPanelAutoSize.Spring; // 2 <B>ПанельСтрокиСостояния&nbsp;(StatusBarPanel)</B> разделяет доступное пространство в строке состояния (пространство, не занятое другими панелями, у которых <B>АвтоРазмер&nbsp;(AutoSize)</B> равен свойству <B>Отсутствие&nbsp;(None)</B> или <B>ПоСодержимому&nbsp;(Contents)</B>) с другими панелями, у которых <B>АвтоРазмер&nbsp;(AutoSize)</B> равен свойству <B>Растяжимое&nbsp;(Spring)</B>.
        private int m_contents = (int)System.Windows.Forms.StatusBarPanelAutoSize.Contents; // 3 Ширина определяется его содержимым.

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("ПоСодержимому", "Contents")]
        public int Contents
        {
        	get { return m_contents; }
        }

        [ContextProperty("Растяжимое", "Spring")]
        public int Spring
        {
        	get { return m_spring; }
        }

    }
}
