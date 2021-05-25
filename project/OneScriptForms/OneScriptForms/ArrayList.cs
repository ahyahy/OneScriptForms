using System.Collections;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ArrayListEx : System.Collections.ArrayList
    {
        public osf.ArrayList M_Object;
    }

    public class ArrayList : IEnumerable, IEnumerator
    {
        public ClArrayList dll_obj;
        public System.Collections.IEnumerator Enumerator;
        public ArrayListEx M_ArrayList;

        public ArrayList()
        {
            M_ArrayList = new ArrayListEx();
            M_ArrayList.M_Object = this;
        }

        public ArrayList(System.Collections.ArrayList p1)
        {
            M_ArrayList = (ArrayListEx)p1;
            M_ArrayList.M_Object = this;
        }

        public ArrayList(osf.ArrayList p1)
        {
            M_ArrayList = p1.M_ArrayList;
            M_ArrayList.M_Object = this;
        }

        //Свойства============================================================

        public object Current
        {
            get { return Enumerator.Current; }
        }

        public virtual int Count
        {
            get { return M_ArrayList.Count; }
        }

        public void Reset()
        {
            Enumerator.Reset();
        }

        public object this[int index]
        {
            get { return M_ArrayList[index]; }
            set { M_ArrayList[index] = value; }
        }

        //Методы============================================================

        public object Add(object value)
        {
            M_ArrayList.Add(value);
            System.Windows.Forms.Application.DoEvents();
            return value;
        }

        public void Clear()
        {
            M_ArrayList.Clear();
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            Enumerator = M_ArrayList.GetEnumerator();
            return (System.Collections.IEnumerator)this;
        }

        public int IndexOf(object value)
        {
            return M_ArrayList.IndexOf(value);
        }

        public object Insert(int index, object value)
        {
            M_ArrayList.Insert(index, value);
            return value;
        }

        public bool MoveNext()
        {
            return Enumerator.MoveNext();
        }

        public void Remove(object obj)
        {
            M_ArrayList.Remove(obj);
        }

        public virtual void RemoveAt(int index)
        {
            M_ArrayList.RemoveAt(index);
        }

    }

    [ContextClass ("КлМассивСписок", "ClArrayList")]
    public class ClArrayList : AutoContext<ClArrayList>
    {

        public ClArrayList()
        {
            ArrayList ArrayList1 = new ArrayList();
            ArrayList1.dll_obj = this;
            Base_obj = ArrayList1;
        }
		
        public ClArrayList(ArrayList p1)
        {
            ArrayList ArrayList1 = p1;
            ArrayList1.dll_obj = this;
            Base_obj = ArrayList1;
        }
        
        public ArrayList Base_obj;

        //Свойства============================================================

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //Методы============================================================

        [ContextMethod("Вставить", "Insert")]
        public IValue Insert(int p1, IValue p2)
        {
            return (IValue)Base_obj.Insert(p1, p2);
        }
        
        [ContextMethod("Добавить", "Add")]
        public IValue Add(IValue p1 = null)
        {
            return (IValue)Base_obj.Add(p1);
        }
        
        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(IValue p1)
        {
            return Base_obj.IndexOf(p1);
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

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Установить", "Set")]
        public void Set(int p1, IValue p2)
        {
            Base_obj[p1] = p2;
        }

        [ContextMethod("Элемент", "Item")]
        public IValue Item(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj[p1]);
        }
    }
}
