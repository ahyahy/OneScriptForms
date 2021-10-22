using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлАктивацияЭлемента", "ClItemActivation")]
    public class ClItemActivation : AutoContext<ClItemActivation>
    {
        private int m_standard = (int)System.Windows.Forms.ItemActivation.Standard; // 0 Активация двойным щелчком. Без обратной связи при перемещении пользователем указателя мыши над элементом.
        private int m_oneClick = (int)System.Windows.Forms.ItemActivation.OneClick; // 1 Активация одним щелчком. Курсор изменяется на указатель курсора в виде руки и изменяется цвет текста элемента при перемещении пользователем указателя мыши над элементом.
        private int m_twoClick = (int)System.Windows.Forms.ItemActivation.TwoClick; // 2 Пользователь должен щелкнуть элемент дважды, чтобы активировать его. Это отличается от стандартного двойного щелчка, поскольку между щелчками может пройти некоторое время. Изменяется цвет текста элемента при перемещении пользователем указателя мыши над элементом.

        [ContextProperty("ДваНажатия", "TwoClick")]
        public int TwoClick
        {
        	get { return m_twoClick; }
        }

        [ContextProperty("ОдноНажатие", "OneClick")]
        public int OneClick
        {
        	get { return m_oneClick; }
        }

        [ContextProperty("Стандартная", "Standard")]
        public int Standard
        {
        	get { return m_standard; }
        }
    }
}
