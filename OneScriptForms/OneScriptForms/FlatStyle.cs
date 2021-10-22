using ScriptEngine.Machine.Contexts;
using System.Windows.Forms;

namespace osf
{
    [ContextClass ("КлПлоскийСтиль", "ClFlatStyle")]
    public class ClFlatStyle : AutoContext<ClFlatStyle>
    {
        private int m_flat = (int)(System.Windows.Forms.FlatStyle)FlatStyle.Flat; // 0 Элемент управления выглядит плоским.
        private int m_popup = (int)(System.Windows.Forms.FlatStyle)FlatStyle.Popup; // 1 Элемент управления выглядит плоским, пока указатель мыши перемещается над ним, после чего становится объемным.
        private int m_standard = (int)(System.Windows.Forms.FlatStyle)FlatStyle.Standard; // 2 Элемент управления выглядит объемным.
        private int m_system = (int)(System.Windows.Forms.FlatStyle)FlatStyle.System; // 3 Внешний вид элемента управления определяется операционной системой пользователя.

        [ContextProperty("Всплывающий", "Popup")]
        public int Popup
        {
        	get { return m_popup; }
        }

        [ContextProperty("Плоский", "Flat")]
        public int Flat
        {
        	get { return m_flat; }
        }

        [ContextProperty("Система", "System")]
        public int System
        {
        	get { return m_system; }
        }

        [ContextProperty("Стандартный", "Standard")]
        public int Standard
        {
        	get { return m_standard; }
        }
    }
}
