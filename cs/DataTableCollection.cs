using System;
using System.Collections;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class DataTableCollection : ICollection, IEnumerable, IEnumerator
    {
        public ClDataTableCollection dll_obj;
        private System.Collections.IEnumerator Enumerator;
        public System.Data.DataTableCollection M_DataTableCollection;

        public DataTableCollection(System.Data.DataTableCollection p1)
        {
            M_DataTableCollection = p1;
        }

        //Свойства============================================================

        public int Count
        {
            get { return M_DataTableCollection.Count; }
        }

        public object Current
        {
            get { return ((DataTableEx)(System.Data.DataTable)Enumerator.Current).M_Object; }
        }

        public bool IsSynchronized
        {
            get { return M_DataTableCollection.IsSynchronized; }
        }

        public void Reset()
        {
            Enumerator.Reset();
        }

        public object SyncRoot
        {
            get { return M_DataTableCollection.SyncRoot; }
        }

        public osf.DataTable this[object p1]
        {
            get
            {
                if (p1 is int)
                {
                    return ((DataTableEx)M_DataTableCollection[(int)p1]).M_Object;
                }
                return ((DataTableEx)M_DataTableCollection[(string)p1]).M_Object;
            }
        }

        //Методы============================================================

        public osf.DataTable Add(osf.DataTable p1 = null)
        {
            if (p1 == null)
            {
                return new DataTable(M_DataTableCollection.Add());
            }
            M_DataTableCollection.Add(p1.M_DataTable);
            return p1;
        }

        public void CopyTo(Array array, int index)
        {
        }

        public IEnumerator GetEnumerator()
        {
            Enumerator = M_DataTableCollection.GetEnumerator();
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            return Enumerator.MoveNext();
        }

        public void Remove(object p1)
        {
            if (p1 is DataTable)
            {
                M_DataTableCollection.Remove(((DataTable)p1).M_DataTable);
            }
            else
            {
                M_DataTableCollection.Remove(Convert.ToString(p1));
            }
            System.Windows.Forms.Application.DoEvents();
        }

        public void RemoveAt(int p1)
        {
            M_DataTableCollection.RemoveAt(p1);
        }

    }

    [ContextClass ("КлТаблицыДанных", "ClDataTableCollection")]
    public class ClDataTableCollection : AutoContext<ClDataTableCollection>
    {

        public ClDataTableCollection(DataTableCollection p1)
        {
            DataTableCollection DataTableCollection1 = p1;
            DataTableCollection1.dll_obj = this;
            Base_obj = DataTableCollection1;
        }

        public DataTableCollection Base_obj;

        //Свойства============================================================

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //Методы============================================================

        [ContextMethod("Добавить", "Add")]
        public ClDataTable Add(ClDataTable p1)
        {
            return (ClDataTable)OneScriptForms.RevertObj(Base_obj.Add(p1.Base_obj));
        }
        
        [ContextMethod("Удалить", "Remove")]
        public void Remove(IValue p1)
        {
            if (p1.SystemType.Name == "Строка")
            {
                Base_obj.Remove(p1.AsString());
            }
            else
            {
                Base_obj.Remove(((dynamic)p1).Base_obj);
            }
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClDataTable Item(IValue p1)
        {
            ClDataTable ClDataTable1 = new ClDataTable();
            if (p1.SystemType.Name == "Строка")
            {
                return new ClDataTable(Base_obj[p1.AsString()]);
            }
            else if (p1.SystemType.Name == "Число")
            {
                return new ClDataTable(Base_obj[Convert.ToInt32(p1.AsNumber())]);
            }
            else
            {
                return null;
            }
        }
    }
}
