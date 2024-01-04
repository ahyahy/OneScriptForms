using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлДень", "ClDay")]
    public class ClDay : AutoContext<ClDay>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_monday = (int)System.Windows.Forms.Day.Monday; // 0 День: понедельник.
        private int m_tuesday = (int)System.Windows.Forms.Day.Tuesday; // 1 День: вторник.
        private int m_wednesday = (int)System.Windows.Forms.Day.Wednesday; // 2 День: среда.
        private int m_thursday = (int)System.Windows.Forms.Day.Thursday; // 3 День: четверг.
        private int m_friday = (int)System.Windows.Forms.Day.Friday; // 4 День: пятница.
        private int m_saturday = (int)System.Windows.Forms.Day.Saturday; // 5 День: суббота.
        private int m_sunday = (int)System.Windows.Forms.Day.Sunday; // 6 День: воскресенье.
        private int m_default = (int)System.Windows.Forms.Day.Default; // 7 День недели, используемый по умолчанию, определенный приложением.

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

        internal ClDay()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Default));
            _list.Add(ValueFactory.Create(Friday));
            _list.Add(ValueFactory.Create(Monday));
            _list.Add(ValueFactory.Create(Saturday));
            _list.Add(ValueFactory.Create(Sunday));
            _list.Add(ValueFactory.Create(Thursday));
            _list.Add(ValueFactory.Create(Tuesday));
            _list.Add(ValueFactory.Create(Wednesday));
        }

        [ContextProperty("Воскресенье", "Sunday")]
        public int Sunday
        {
        	get { return m_sunday; }
        }

        [ContextProperty("Вторник", "Tuesday")]
        public int Tuesday
        {
        	get { return m_tuesday; }
        }

        [ContextProperty("Понедельник", "Monday")]
        public int Monday
        {
        	get { return m_monday; }
        }

        [ContextProperty("ПоУмолчанию", "Default")]
        public int Default
        {
        	get { return m_default; }
        }

        [ContextProperty("Пятница", "Friday")]
        public int Friday
        {
        	get { return m_friday; }
        }

        [ContextProperty("Среда", "Wednesday")]
        public int Wednesday
        {
        	get { return m_wednesday; }
        }

        [ContextProperty("Суббота", "Saturday")]
        public int Saturday
        {
        	get { return m_saturday; }
        }

        [ContextProperty("Четверг", "Thursday")]
        public int Thursday
        {
        	get { return m_thursday; }
        }
    }
}
