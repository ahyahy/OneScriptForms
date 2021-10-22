using System.Collections;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class HashTable : IEnumerable, IEnumerator
    {
        public ClHashTable dll_obj;
        public System.Collections.IEnumerator Enumerator;
        public System.Collections.Hashtable M_HashTable;

        public HashTable()
        {
            M_HashTable = new System.Collections.Hashtable();
            OneScriptForms.AddToHashtable(M_HashTable, this);
        }

        public HashTable(osf.HashTable p1)
        {
            M_HashTable = p1.M_HashTable;
            OneScriptForms.AddToHashtable(M_HashTable, this);
        }

        public HashTable(System.Collections.Hashtable p1)
        {
            M_HashTable = p1;
            OneScriptForms.AddToHashtable(M_HashTable, this);
        }

        public int Count
        {
            get { return M_HashTable.Count; }
        }

        public object Current
        {
            get { return Enumerator.Current; }
        }

        public object get_Item(object key)
        {
            return M_HashTable[key];
        }

        public void Reset()
        {
            Enumerator.Reset();
        }

        public void set_Item(object key, object value)
        {
            M_HashTable[key] = value;
        }

        public void Add(object key, object value)
        {
            M_HashTable.Add(key, value);
            System.Windows.Forms.Application.DoEvents();
        }

        public void Clear()
        {
            M_HashTable.Clear();
            System.Windows.Forms.Application.DoEvents();
        }

        public IEnumerator GetEnumerator()
        {
            Enumerator = M_HashTable.GetEnumerator();
            return (System.Collections.IEnumerator)this;
        }

        public bool MoveNext()
        {
            return Enumerator.MoveNext();
        }

        public void Remove(object key)
        {
            M_HashTable.Remove(key);
            System.Windows.Forms.Application.DoEvents();
        }

        public void Set(object key, object value)
        {
            M_HashTable[key] = value;
            System.Windows.Forms.Application.DoEvents();
        }
    }

    [ContextClass ("КлХэшТаблица", "ClHashTable")]
    public class ClHashTable : AutoContext<ClHashTable>
    {
        public ClHashTable()
        {
            HashTable HashTable1 = new HashTable();
            HashTable1.dll_obj = this;
            Base_obj = HashTable1;
        }
		
        public ClHashTable(HashTable p1)
        {
            HashTable HashTable1 = p1;
            HashTable1.dll_obj = this;
            Base_obj = HashTable1;
        }
        
        public HashTable Base_obj;
        
        [ContextProperty("Значения", "Values")]
        public ClArrayList Values
        {
            get
            {
                System.Collections.Hashtable Hashtable1 = (System.Collections.Hashtable)Base_obj.M_HashTable;
                osf.ArrayList ArrayList1 = new osf.ArrayList();
                System.Collections.ICollection Values1 = Hashtable1.Values;
                foreach (IValue val1 in Values1)
                {
                    ArrayList1.Add(val1);
                }
                return new ClArrayList(ArrayList1);
            }
        }

        [ContextProperty("Ключи", "Keys")]
        public ClArrayList Keys
        {
            get
            {
                System.Collections.Hashtable Hashtable1 = (System.Collections.Hashtable)Base_obj.M_HashTable;
                osf.ArrayList ArrayList1 = new osf.ArrayList();
                System.Collections.ICollection Keys1 = Hashtable1.Keys;
                foreach (IValue key1 in Keys1)
                {
                    ArrayList1.Add(key1);
                }
                return new ClArrayList(ArrayList1);
            }
        }

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Добавить", "Add")]
        public void Add(IValue p1, IValue p2)
        {
            Base_obj.Add(p1, p2);
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Удалить", "Remove")]
        public void Remove(IValue p1)
        {
            Base_obj.Remove(p1);
        }

        [ContextMethod("Установить", "Set")]
        public void Set(IValue p1, IValue p2)
        {
            Base_obj.Set(p1, p2);
        }

        [ContextMethod("Элемент", "Item")]
        public IValue Item(IValue p1)
        {
            return (IValue)Base_obj.get_Item(p1);
        }
    }
}
