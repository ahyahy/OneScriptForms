using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлНачальноеПоложениеФормы", "ClFormStartPosition")]
    public class ClFormStartPosition : AutoContext<ClFormStartPosition>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_manual = (int)System.Windows.Forms.FormStartPosition.Manual; // 0 Положение формы определяется свойством <B>Положение&nbsp;(Location)</B>.
        private int m_centerScreen = (int)System.Windows.Forms.FormStartPosition.CenterScreen; // 1 Форма выравнивается по центру текущего экрана.
        private int m_windowsDefaultLocation = (int)System.Windows.Forms.FormStartPosition.WindowsDefaultLocation; // 2 Форма с заданными размерами размещается в расположении, определенном по умолчанию в Windows.
        private int m_windowsDefaultBounds = (int)System.Windows.Forms.FormStartPosition.WindowsDefaultBounds; // 3 Положение формы и ее границы определены в Windows по умолчанию.
        private int m_centerParent = (int)System.Windows.Forms.FormStartPosition.CenterParent; // 4 Форма выравнивается по центру в границах родительской формы.

        private List<IValue> _list;

        public int Count()
        {
            return _list.Count;
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IValue>)_list).GetEnumerator();
        }

        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return (item as IValue);
            }
        }

        public ClFormStartPosition()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(CenterParent));
            _list.Add(ValueFactory.Create(CenterScreen));
            _list.Add(ValueFactory.Create(Manual));
            _list.Add(ValueFactory.Create(WindowsDefaultBounds));
            _list.Add(ValueFactory.Create(WindowsDefaultLocation));
        }

        [ContextProperty("Вручную", "Manual")]
        public int Manual
        {
        	get { return m_manual; }
        }

        [ContextProperty("ГраницыОкнаПоУмолчанию", "WindowsDefaultBounds")]
        public int WindowsDefaultBounds
        {
        	get { return m_windowsDefaultBounds; }
        }

        [ContextProperty("ПоложениеОкнаПоУмолчанию", "WindowsDefaultLocation")]
        public int WindowsDefaultLocation
        {
        	get { return m_windowsDefaultLocation; }
        }

        [ContextProperty("ЦентрРодителя", "CenterParent")]
        public int CenterParent
        {
        	get { return m_centerParent; }
        }

        [ContextProperty("ЦентрЭкрана", "CenterScreen")]
        public int CenterScreen
        {
        	get { return m_centerScreen; }
        }
    }
}
