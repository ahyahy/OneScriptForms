using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлРежимРазмераВкладок", "ClTabSizeMode")]
    public class ClTabSizeMode : AutoContext<ClTabSizeMode>
    {
        private int m_normal = (int)System.Windows.Forms.TabSizeMode.Normal; // 0 Ширина каждой вкладки изменяется в соответствии со сведениями, отображаемыми на вкладке, а размер вкладок в строке не настраивается для заполнения во всю ширину контейнерного элемента управления.
        private int m_fillToRight = (int)System.Windows.Forms.TabSizeMode.FillToRight; // 1 Ширина каждой вкладки изменяется таким образом, чтобы каждая строка вкладок заполнила всю ширину контейнерного элемента управления. Это применимо только к элементам управления с более чем одной вкладкой в строке.
        private int m_fixed = (int)System.Windows.Forms.TabSizeMode.Fixed; // 2 Все вкладки в элементе управления имеют одинаковую ширину.

        [ContextProperty("ЗаполнитьВправо", "FillToRight")]
        public int FillToRight
        {
        	get { return m_fillToRight; }
        }

        [ContextProperty("Постоянный", "Fixed")]
        public int Fixed
        {
        	get { return m_fixed; }
        }

        [ContextProperty("Стандартный", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }

    }
}
