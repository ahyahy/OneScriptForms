using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections.Generic;
using System.Collections;

namespace osf
{
    public class Dictionary : IEnumerable, IEnumerator
    {
        public ClDictionary dll_obj;
        public System.Collections.IEnumerator Enumerator;
        public System.Collections.Generic.Dictionary<object, object> M_Dictionary;

        public Dictionary()
        {
            M_Dictionary = new System.Collections.Generic.Dictionary<object, object>();
            OneScriptForms.AddToHashtable(M_Dictionary, this);
        }

        public Dictionary(Dictionary<object, object> p1)
        {
            M_Dictionary = p1;
        }

        public Dictionary(osf.Dictionary p1)
        {
            M_Dictionary = p1.M_Dictionary;
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (KeyValuePair<object, object> DictionaryEntry in M_Dictionary)
                {
                    count = count + 1;
                }
                return count;
            }
        }

        public object Current
        {
            get { return Enumerator.Current; }
        }

        public object get_Item(object key)
        {
            return M_Dictionary[key];
        }

        public void Reset()
        {
            Enumerator.Reset();
        }

        public void Add(object key, object value)
        {
            M_Dictionary.Add(key, value);
        }

        public void Clear()
        {
            M_Dictionary.Clear();
        }

        public bool ContainsKey(object p1)
        {
            return M_Dictionary.ContainsKey(p1);
        }

        public bool ContainsValue(object p1)
        {
            return M_Dictionary.ContainsValue(p1);
        }

        public IEnumerator GetEnumerator()
        {
            Enumerator = M_Dictionary.GetEnumerator();
            return (System.Collections.IEnumerator)this;
        }

        public bool MoveNext()
        {
            return Enumerator.MoveNext();
        }

        public void Remove(object key)
        {
            M_Dictionary.Remove(key);
        }

        public void Set(object key, object value)
        {
            M_Dictionary[key] = value;
        }
    }

    [ContextClass ("КлСловарь", "ClDictionary")]
    public class ClDictionary : AutoContext<ClDictionary>
    {
        public ClDictionary()
        {
            Dictionary Dictionary1 = new Dictionary();
            Dictionary1.dll_obj = this;
            Base_obj = Dictionary1;
        }
		
        public ClDictionary(Dictionary p1)
        {
            Dictionary Dictionary1 = p1;
            Dictionary1.dll_obj = this;
            Base_obj = Dictionary1;
        }
        
        public Dictionary Base_obj;
        
        [ContextProperty("Значения", "Values")]
        public ClArrayList Values
        {
            get
            {
                System.Collections.Generic.Dictionary<object, object> Dictionary1 = (System.Collections.Generic.Dictionary<object, object>)Base_obj.M_Dictionary;
                osf.ArrayList ArrayList1 = new osf.ArrayList();
                System.Collections.ICollection Values1 = Dictionary1.Values;
                foreach (dynamic val1 in Values1)
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
                System.Collections.Generic.Dictionary<object, object> Dictionary1 = (System.Collections.Generic.Dictionary<object, object>)Base_obj.M_Dictionary;
                osf.ArrayList ArrayList1 = new osf.ArrayList();
                System.Collections.ICollection Keys1 = Dictionary1.Keys;
                foreach (dynamic key1 in Keys1)
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
            Base_obj.Add(OneScriptForms.DefineTypeIValue(p1), OneScriptForms.DefineTypeIValue(p2));
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("СодержитЗначение", "ContainsValue")]
        public bool ContainsValue(object p1)
        {
            return Base_obj.ContainsValue(OneScriptForms.DefineTypeIValue(p1));
        }

        [ContextMethod("СодержитКлюч", "ContainsKey")]
        public bool ContainsKey(object p1)
        {
            return Base_obj.ContainsKey(OneScriptForms.DefineTypeIValue(p1));
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(object p1)
        {
            Base_obj.Remove(OneScriptForms.DefineTypeIValue(p1));
        }

        [ContextMethod("Установить", "Set")]
        public void Set(IValue p1, IValue p2)
        {
            Base_obj.Set(OneScriptForms.DefineTypeIValue(p1), OneScriptForms.DefineTypeIValue(p2));
        }

        [ContextMethod("Элемент", "Item")]
        public IValue Item(IValue p1)
        {
            return (IValue)ValueFactory.Create(Base_obj.get_Item(OneScriptForms.DefineTypeIValue(p1)));
        }
    }
}
