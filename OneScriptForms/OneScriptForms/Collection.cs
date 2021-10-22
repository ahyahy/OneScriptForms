using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class Collection : System.Collections.IEnumerable
    {
        public ClCollection dll_obj;
        public Microsoft.VisualBasic.Collection M_Collection;

        public Collection()
        {
            M_Collection = new Microsoft.VisualBasic.Collection();
            OneScriptForms.AddToHashtable(M_Collection, this);
        }

        public Collection(Microsoft.VisualBasic.Collection p1)
        {
            M_Collection = p1;
        }

        public Collection(osf.Collection p1)
        {
            M_Collection = p1.M_Collection;
        }

        public int Count
        {
            get { return M_Collection.Count; }
        }

        public object this[object index]
        {
            get
            {
                if (index is int)
                {
                    return M_Collection[checked(Convert.ToInt32(index) + 1)];
                }
                if (index is string)
                {
                    return M_Collection[Convert.ToString(index)];
                }
                return M_Collection[index];
            }
        }

        public void Add(object item, string key = null)
        {
            M_Collection.Add(item, key);
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return M_Collection.GetEnumerator();
        }

        public void Remove(object index)
        {
            if (index is int)
            {
                M_Collection.Remove(checked(Convert.ToInt32(index) + 1));
            }
            else if (index is string)
            {
                M_Collection.Remove(checked(Convert.ToString(index)));
            }
        }
    }

    [ContextClass ("КлКоллекция", "ClCollection")]
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
        public void Add(IValue p1, string p2 = null)
        {
            Base_obj.Add(p1, p2);
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(IValue p1)
        {
            if (p1.SystemType.Name == "Строка")
            {
                Base_obj.Remove(p1.AsString());
            }
            else if (p1.SystemType.Name == "Число")
            {
                Base_obj.Remove(Convert.ToInt32(p1.AsNumber()));
            }
        }

        [ContextMethod("Элемент", "Item")]
        public IValue Item(IValue p1)
        {
            if (p1.SystemType.Name == "Строка")
            {
                return (IValue)Base_obj[p1.AsString()];
            }
            else if (p1.SystemType.Name == "Число")
            {
                return (IValue)Base_obj[Convert.ToInt32(p1.AsNumber())];
            }
            return null;
        }
    }
}
