using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлПричинаЗакрытия", "ClCloseReason")]
    public class ClCloseReason : AutoContext<ClCloseReason>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.CloseReason.None; // 0 Причина закрытия не была определена или не может быть определена.
        private int m_windowsShutDown = (int)System.Windows.Forms.CloseReason.WindowsShutDown; // 1 Операционная система закрывает все приложения перед завершением работы.
        private int m_mdiFormClosing = (int)System.Windows.Forms.CloseReason.MdiFormClosing; // 2 Родительская форма этой формы многодокументного интерфейса (MDI) закрывается.
        private int m_userClosing = (int)System.Windows.Forms.CloseReason.UserClosing; // 3 Форма закрывается программными способами или с помощью действия пользователя в пользовательском интерфейсе (например нажатием кнопки Закрыть в окне формы, выбором параметра Закрыть в системном меню окна или нажатием сочетания клавиш ALT+F4).
        private int m_taskManagerClosing = (int)System.Windows.Forms.CloseReason.TaskManagerClosing; // 4 Диспетчер задач Microsoft Windows закрывает приложение.
        private int m_formOwnerClosing = (int)System.Windows.Forms.CloseReason.FormOwnerClosing; // 5 Форма-владелец закрывается.
        private int m_applicationExitCall = (int)System.Windows.Forms.CloseReason.ApplicationExitCall; // 6 Был вызван метод Exit() класса Application.

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

        public ClCloseReason()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(ApplicationExitCall));
            _list.Add(ValueFactory.Create(FormOwnerClosing));
            _list.Add(ValueFactory.Create(MdiFormClosing));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(TaskManagerClosing));
            _list.Add(ValueFactory.Create(UserClosing));
            _list.Add(ValueFactory.Create(WindowsShutDown));
        }

        [ContextProperty("Владелец", "FormOwnerClosing")]
        public int FormOwnerClosing
        {
        	get { return m_formOwnerClosing; }
        }

        [ContextProperty("Выход", "ApplicationExitCall")]
        public int ApplicationExitCall
        {
        	get { return m_applicationExitCall; }
        }

        [ContextProperty("Диспетчер", "TaskManagerClosing")]
        public int TaskManagerClosing
        {
        	get { return m_taskManagerClosing; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("Пользователь", "UserClosing")]
        public int UserClosing
        {
        	get { return m_userClosing; }
        }

        [ContextProperty("Система", "WindowsShutDown")]
        public int WindowsShutDown
        {
        	get { return m_windowsShutDown; }
        }

        [ContextProperty("ФормаMDI", "MdiFormClosing")]
        public int MdiFormClosing
        {
        	get { return m_mdiFormClosing; }
        }
    }
}
