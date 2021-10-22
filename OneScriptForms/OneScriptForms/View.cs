using ScriptEngine.Machine.Contexts;
using System.Windows.Forms;

namespace osf
{
    [ContextClass ("КлРежимОтображения", "ClView")]
    public class ClView : AutoContext<ClView>
    {
        private int m_largeIcon = (int)View.LargeIcon; // 0 Каждый элемент отображается в виде полноразмерного значка с меткой под ним.
        private int m_details = (int)View.Details; // 1 Каждый элемент отображается в отдельной строке. Дополнительные сведения о каждом элементе распределены по колонкам.  Крайняя левая колонка содержит небольшой значок и метку, а последующие колонки содержат вложенные элементы.  В колонке отображается заголовок. Пользователь может изменить размер каждой колонки.
        private int m_smallIcon = (int)View.SmallIcon; // 2 Каждый элемент отображается в виде небольшого значка с меткой справа.
        private int m_list = (int)View.List; // 3 Каждый элемент отображается в виде небольшого значка с меткой справа. Элементы располагаются в колонках без заголовков колонок.

        [ContextProperty("БольшойЗначок", "LargeIcon")]
        public int LargeIcon
        {
        	get { return m_largeIcon; }
        }

        [ContextProperty("МаленькийЗначок", "SmallIcon")]
        public int SmallIcon
        {
        	get { return m_smallIcon; }
        }

        [ContextProperty("Подробно", "Details")]
        public int Details
        {
        	get { return m_details; }
        }

        [ContextProperty("Список", "List")]
        public int List
        {
        	get { return m_list; }
        }
    }
}
