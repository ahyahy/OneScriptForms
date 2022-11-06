using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлРежимВыбораДереваЗначений", "ClTreeSelectionMode")]
    public class ClTreeSelectionMode : AutoContext<ClTreeSelectionMode>
    {
        private int m_single = 0; // 0 Можно выбрать только один узел.
        private int m_multi = 1; // 1 Можно выбрать несколько узлов одновременно.
        private int m_multiSameParent = 2; // 2 Можно выбрать несколько узлов одновременно в пределах одного родителя.

        [ContextProperty("Множественный", "Multi")]
        public int Multi
        {
        	get { return m_multi; }
        }

        [ContextProperty("МножественныйДляРодителя", "MultiSameParent")]
        public int MultiSameParent
        {
        	get { return m_multiSameParent; }
        }

        [ContextProperty("Одиночный", "Single")]
        public int Single
        {
        	get { return m_single; }
        }
    }
}
