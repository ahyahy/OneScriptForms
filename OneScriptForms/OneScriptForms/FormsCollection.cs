using System.Collections;
using System.Collections.Generic;
using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class FormsCollection : AutoContext<FormsCollection>, ICollectionContext, IEnumerable<ClForm>
    {
        private List<ClForm> _list;

        public FormsCollection()
        {
            _list = new List<ClForm>();
        }

        public void Add(ClForm form)
        {
            _list.Add(form);
        }

        public bool Remove(ClForm form)
        {
            return _list.Remove(form);
        }

        [ContextMethod("Получить", "Get")]
        public ClForm Get(int index)
        {
            return this._list[index];
        }

        [ContextProperty("Количество", "Count")]
        public int CountForm
        {
            get { return _list.Count; }
        }

        public int Count()
        {
            return CountForm;
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<ClForm>)_list).GetEnumerator();
        }

        IEnumerator<ClForm> IEnumerable<ClForm>.GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return (item as ClForm);
            }
        }
    }//endClass
}//endnamespace
