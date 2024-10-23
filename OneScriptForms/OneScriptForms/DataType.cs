using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлТипДанных", "ClDataType")]
    public class ClDataType : AutoContext<ClDataType>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_string = 0; // 0 Тип данных <B>Строка</B>.
        private int m_number = 1; // 1 Тип данных <B>Число</B>.
        private int m_boolean = 2; // 2 Тип данных <B>Булево</B>.
        private int m_date = 3; // 3 Тип данных <B>Дата</B>.
        private int m_object = 4; // 4 Тип данных <B>Объект</B>.

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

        public ClDataType()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Boolean));
            _list.Add(ValueFactory.Create(Date));
            _list.Add(ValueFactory.Create(Number));
            _list.Add(ValueFactory.Create(Object));
            _list.Add(ValueFactory.Create(String));
        }

        [ContextProperty("Булево", "Boolean")]
        public int Boolean
        {
        	get { return m_boolean; }
        }

        [ContextProperty("Дата", "Date")]
        public int Date
        {
        	get { return m_date; }
        }

        [ContextProperty("Объект", "Object")]
        public int Object
        {
        	get { return m_object; }
        }

        [ContextProperty("Строка", "String")]
        public int String
        {
        	get { return m_string; }
        }

        [ContextProperty("Число", "Number")]
        public int Number
        {
        	get { return m_number; }
        }
    }
}
