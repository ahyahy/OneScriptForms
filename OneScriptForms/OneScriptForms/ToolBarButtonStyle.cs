using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСтильКнопокПанелиИнструментов", "ClToolBarButtonStyle")]
    public class ClToolBarButtonStyle : AutoContext<ClToolBarButtonStyle>
    {
        private int m_pushButton = (int)System.Windows.Forms.ToolBarButtonStyle.PushButton; // 1 Стандартная трехмерная кнопка.
        private int m_toggleButton = (int)System.Windows.Forms.ToolBarButtonStyle.ToggleButton; // 2 Выключатель, который отображается углубленным при щелчке и остается таковым до следующего нажатия на него.
        private int m_separator = (int)System.Windows.Forms.ToolBarButtonStyle.Separator; // 3 Промежуток или линия между кнопками панели инструментов. Внешний вид зависит от значения свойства <B>Оформление&nbsp;(Appearance)</B>.
        private int m_dropDownButton = (int)System.Windows.Forms.ToolBarButtonStyle.DropDownButton; // 4 Раскрывающийся элемент управления отображает меню или окно при нажатии.

        [ContextProperty("КнопкаВыпадающегоСписка", "DropDownButton")]
        public int DropDownButton
        {
        	get { return m_dropDownButton; }
        }

        [ContextProperty("Разделитель", "Separator")]
        public int Separator
        {
        	get { return m_separator; }
        }

        [ContextProperty("СтандартнаяТрехмерная", "PushButton")]
        public int PushButton
        {
        	get { return m_pushButton; }
        }

        [ContextProperty("Тумблер", "ToggleButton")]
        public int ToggleButton
        {
        	get { return m_toggleButton; }
        }
    }
}
