using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлСлияниеМеню", "ClMenuMerge")]
    public class ClMenuMerge : AutoContext<ClMenuMerge>
    {
        private int m_add = (int)System.Windows.Forms.MenuMerge.Add; // 0 Объект <B>ЭлементМеню&nbsp;(MenuItem)</B> добавляется к коллекции объектов <B>ЭлементМеню&nbsp;(MenuItem)</B> в объединенном меню.
        private int m_replace = (int)System.Windows.Forms.MenuMerge.Replace; // 1 Объект <B>ЭлементМеню&nbsp;(MenuItem)</B> заменяет существующий <B>ЭлементМеню&nbsp;(MenuItem)</B> в той же позиции в объединенном меню.
        private int m_mergeItems = (int)System.Windows.Forms.MenuMerge.MergeItems; // 2 Все элементы вложенного меню этого <B>ЭлементМеню&nbsp;(MenuItem)</B> объединяются с соответствующими элементами существующих объектов <B>ЭлементМеню&nbsp;(MenuItem)</B> в той же позиции в объединенном меню.
        private int m_remove = (int)System.Windows.Forms.MenuMerge.Remove; // 3 Объект <B>ЭлементМеню&nbsp;(MenuItem)</B> удаляется из объединенного меню.

        [ContextProperty("Добавить", "Add")]
        public int Add
        {
        	get { return m_add; }
        }

        [ContextProperty("Заменить", "Replace")]
        public int Replace
        {
        	get { return m_replace; }
        }

        [ContextProperty("ОбъединитьМеню", "MergeItems")]
        public int MergeItems
        {
        	get { return m_mergeItems; }
        }

        [ContextProperty("Удалить", "Remove")]
        public int Remove
        {
        	get { return m_remove; }
        }
    }
}
