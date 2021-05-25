using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлВыравниваниеВСпискеЭлементов", "ClListViewAlignment")]
    public class ClListViewAlignment : AutoContext<ClListViewAlignment>
    {
        private int m_default = (int)System.Windows.Forms.ListViewAlignment.Default; // 0 Когда пользователь перемещает элемент, он остается там, куда его положили.
        private int m_left = (int)System.Windows.Forms.ListViewAlignment.Left; // 1 Выравнивание элементов по левому краю.
        private int m_top = (int)System.Windows.Forms.ListViewAlignment.Top; // 2 Выравнивание элементов по верхнему краю.
        private int m_snapToGrid = (int)System.Windows.Forms.ListViewAlignment.SnapToGrid; // 5 Элементы выравниваются по невидимой сетке в элементе управления. Когда пользователь перемещает элемент, он перемещается к ближайшей точке пересечения сетки.

        [ContextProperty("Верх", "Top")]
        public int Top
        {
        	get { return m_top; }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
        	get { return m_left; }
        }

        [ContextProperty("ПоСетке", "SnapToGrid")]
        public int SnapToGrid
        {
        	get { return m_snapToGrid; }
        }

        [ContextProperty("ПоУмолчанию", "Default")]
        public int Default
        {
        	get { return m_default; }
        }

    }
}
