using System.Collections;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Runtime.CompilerServices;

namespace osf
{
    public class SortedList : IEnumerator
    {
        public ClSortedList dll_obj;
        public IEnumerator Enumerator;
        public System.Collections.SortedList M_SortedList;

        public SortedList()
        {
            Enumerator = null;
            M_SortedList = new System.Collections.SortedList();
        }

        public SortedList(System.Collections.SortedList p1)
        {
            Enumerator = null;
            M_SortedList = (System.Collections.SortedList)p1;
        }

        public int Count
        {
            get { return M_SortedList.Count; }
        }

        public object Current
        {
            get { return Enumerator.Current; }
        }

        public DictionaryEntry get_Item(object key)
        {
            return (DictionaryEntry)M_SortedList[RuntimeHelpers.GetObjectValue(key)];
        }

        public virtual void Reset()
        {
            Enumerator.Reset();
        }

        public void Add(object key, object value)
        {
            M_SortedList.Add(RuntimeHelpers.GetObjectValue(key), RuntimeHelpers.GetObjectValue(value));
        }

        public virtual bool MoveNext()
        {
            return Enumerator.MoveNext();
        }

        public bool ContainsKey(object  p1)
        {
            return M_SortedList.ContainsKey(p1);
        }

        public bool ContainsValue(object  p1)
        {
            return M_SortedList.ContainsValue(p1);
        }

        public object GetByIndex(int index)
        {
            return M_SortedList.GetByIndex(index);
        }

        public virtual IEnumerator GetEnumerator()
        {
            Enumerator = M_SortedList.GetEnumerator();
            return this;
        }

        public void Remove(object key)
        {
            M_SortedList.Remove(RuntimeHelpers.GetObjectValue(key));
            //System.Windows.Forms.Application.DoEvents();
        }
    }

    [ContextClass ("КлСортированныйСписок", "ClSortedList")]
    public class ClSortedList : AutoContext<ClSortedList>
    {
        public ClSortedList()
        {
            SortedList SortedList1 = new SortedList();
            SortedList1.dll_obj = this;
            Base_obj = SortedList1;
        }
		
        public ClSortedList(SortedList p1)
        {
            SortedList SortedList1 = p1;
            SortedList1.dll_obj = this;
            Base_obj = SortedList1;
        }
        
        public SortedList Base_obj;
        
        [ContextProperty("Значения", "Values")]
        public ClArrayList Values
        {
            get
            {
                System.Collections.SortedList SortedList1 = Base_obj.M_SortedList;
                ArrayList ArrayList1 = new ArrayList();
                System.Collections.ICollection Values1 = SortedList1.Values;
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
                System.Collections.SortedList SortedList1 = Base_obj.M_SortedList;
                ArrayList ArrayList1 = new ArrayList();
                System.Collections.ICollection Keys1 = SortedList1.Keys;
                foreach (object key1 in Keys1)
                {
                    ArrayList1.Add(OneScriptForms.RevertObj(key1));
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
        public void Add(object p1, IValue p2)
        {
            Base_obj.Add(p1, p2);
        }
        
        [ContextMethod("ПолучитьПоИндексу", "GetByIndex")]
        public IValue GetByIndex(int p1)
        {
            return (IValue)Base_obj.GetByIndex(p1);
        }

        [ContextMethod("СодержитЗначение", "ContainsValue")]
        public bool ContainsValue(IValue p1)
        {
            return Base_obj.ContainsValue(p1);
        }

        [ContextMethod("СодержитКлюч", "ContainsKey")]
        public bool ContainsKey(object p1)
        {
            return Base_obj.ContainsKey(p1);
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(object p1)
        {
            Base_obj.Remove(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClDictionaryEntry Item(object p1, IValue p2 = null)
        {
            System.Collections.SortedList SortedList1 = Base_obj.M_SortedList;
            if (p2 != null)
            {
                SortedList1[p1] = p2;
            }
            DictionaryEntry DictionaryEntry1 = new DictionaryEntry(p1, SortedList1[p1]);
            return new ClDictionaryEntry(DictionaryEntry1);
        }
    }
}
