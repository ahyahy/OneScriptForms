using System;
using System.Collections;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class DataColumnCollection : ICollection, IEnumerable, IEnumerator
    {
        public ClDataColumnCollection dll_obj;
        public System.Collections.IEnumerator Enumerator;
        public System.Data.DataColumnCollection M_DataColumnCollection;

        public DataColumnCollection(System.Data.DataColumnCollection p1)
        {
            M_DataColumnCollection = p1;
        }

        //Свойства============================================================

        public int Count
        {
            get { return M_DataColumnCollection.Count; }
        }

        public object Current
        {
            get { return (object)((DataColumnEx)((System.Data.DataColumn)Enumerator.Current)).M_Object; }
        }

        public bool IsSynchronized
        {
            get { return M_DataColumnCollection.IsSynchronized; }
        }

        public void Reset()
        {
            Enumerator.Reset();
        }

        public object SyncRoot
        {
            get { return M_DataColumnCollection.SyncRoot; }
        }

        public osf.DataColumn this[object index]
        {
            get
            {
                if (index is string)
                {
                    return new osf.DataColumn(M_DataColumnCollection[Convert.ToString(index)]);
                }
                return new osf.DataColumn(M_DataColumnCollection[Convert.ToInt32(index)]);
            }
            set
            {
            }
        }

        //Методы============================================================

        public osf.DataColumn Add(osf.DataColumn p1)
        {
            M_DataColumnCollection.Add(p1.M_DataColumn);
            System.Windows.Forms.Application.DoEvents();
            return p1;
        }

        public osf.DataColumn AddItem(string p1)
        {
            DataColumn DataColumn1 = new DataColumn(p1);
            M_DataColumnCollection.Add(DataColumn1.M_DataColumn);
            System.Windows.Forms.Application.DoEvents();
            return DataColumn1;
        }

        public void Clear()
        {
            M_DataColumnCollection.Clear();
        }

        public void CopyTo(Array array, int index)
        {
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            Enumerator = M_DataColumnCollection.GetEnumerator();
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            return Enumerator.MoveNext();
        }

        public void Remove(osf.DataColumn p1)
        {
            M_DataColumnCollection.Remove(p1.M_DataColumn);
        }

        public void RemoveAt(int index)
        {
            M_DataColumnCollection.RemoveAt(index);
        }

    }

    [ContextClass ("КлКолонкиДанных", "ClDataColumnCollection")]
    public class ClDataColumnCollection : AutoContext<ClDataColumnCollection>
    {

        public ClDataColumnCollection(DataColumnCollection p1)
        {
            DataColumnCollection DataColumnCollection1 = p1;
            DataColumnCollection1.dll_obj = this;
            Base_obj = DataColumnCollection1;
        }

        public DataColumnCollection Base_obj;

        //Свойства============================================================

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //Методы============================================================

        [ContextMethod("Добавить", "Add")]
        public ClDataColumn Add(ClDataColumn p1)
        {
            return new ClDataColumn(Base_obj.Add(p1.Base_obj));
        }

        [ContextMethod("ДобавитьЭлемент", "AddItem")]
        public ClDataColumn AddItem(string p1)
        {
            return new ClDataColumn(Base_obj.AddItem(p1));
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClDataColumn p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClDataColumn Item(IValue p1)
        {
            if (p1.SystemType.Name == "Число")
            {
                return new ClDataColumn(Base_obj[Convert.ToInt32(p1.AsNumber())]);
            }
            if (p1.SystemType.Name == "Строка")
            {
                return new ClDataColumn(Base_obj[p1.AsString()]);
            }
            return null;
        }
    }
}
