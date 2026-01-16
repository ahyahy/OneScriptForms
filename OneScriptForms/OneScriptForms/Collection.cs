using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections.Generic;

namespace osf
{
    public class Collection : Dictionary<string, object>
    {
        public ClCollection dll_obj;
        public Dictionary<string, object> M_Collection;

        public Collection()
        {
            M_Collection = new Dictionary<string, object>();
            OneScriptForms.AddToHashtable(M_Collection, this);
        }

        public Collection(Dictionary<string, object> p1)
        {
            M_Collection = p1;
        }

        public Collection(osf.Collection p1)
        {
            M_Collection = p1.M_Collection;
        }

        public new int Count
        {
            get
            {
                int count = 0;
                foreach (KeyValuePair<string, object> DictionaryEntry in M_Collection)
                {
                    count = count + 1;
                }
                return count;
            }
        }

        public new object this[string index]
        {
            get { return M_Collection[index]; }
        }

        public new System.Collections.IEnumerator GetEnumerator()
        {
            return M_Collection.GetEnumerator();
        }

        public new void Add(string key, object item)
        {
            M_Collection.Add(key, item);
        }

        public new void Remove(string index)
        {
            M_Collection.Remove(index);
        }
    }

    [ContextClass("КлКоллекция", "ClCollection")]
    public class ClCollection : AutoContext<ClCollection>
    {
        public ClCollection()
        {
            Collection Collection1 = new Collection();
            Collection1.dll_obj = this;
            Base_obj = Collection1;
        }

        public ClCollection(Collection p1)
        {
            Collection Collection1 = p1;
            Collection1.dll_obj = this;
            Base_obj = Collection1;
        }

        public Collection Base_obj;

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        [ContextMethod("Добавить", "Add")]
        public void Add(IValue p2, string p1)
        {
            Base_obj.Add(p1, p2);
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(string p1)
        {
            Base_obj.Remove(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public IValue Item(string p1)
        {
            return (IValue)Base_obj[p1];
        }
    }
}
