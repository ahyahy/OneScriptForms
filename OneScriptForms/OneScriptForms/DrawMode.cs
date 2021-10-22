using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлРежимРисования", "ClDrawMode")]
    public class ClDrawMode : AutoContext<ClDrawMode>
    {
        private int m_normal = (int)System.Windows.Forms.DrawMode.Normal; // 0 Рисование всех элементов в элементе управления выполняется операционной системой, и все элементы имеют одинаковый размер.
        private int m_ownerDrawFixed = (int)System.Windows.Forms.DrawMode.OwnerDrawFixed; // 1 Рисование всех элементов в элементе управления выполняется вручную, и все элементы имеют одинаковый размер.
        private int m_ownerDrawVariable = (int)System.Windows.Forms.DrawMode.OwnerDrawVariable; // 2 Рисование всех элементов в элементе управления выполняется вручную, и размер их может быть разным.

        [ContextProperty("ВручнуюПеременный", "OwnerDrawVariable")]
        public int OwnerDrawVariable
        {
        	get { return m_ownerDrawVariable; }
        }

        [ContextProperty("ВручнуюФиксированный", "OwnerDrawFixed")]
        public int OwnerDrawFixed
        {
        	get { return m_ownerDrawFixed; }
        }

        [ContextProperty("Стандартный", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }
    }
}
