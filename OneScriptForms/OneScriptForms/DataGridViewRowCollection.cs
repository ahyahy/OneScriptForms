using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class DataGridViewRowCollection
    {
        public ClDataGridViewRowCollection dll_obj;
        public System.Windows.Forms.DataGridViewRowCollection M_DataGridViewRowCollection;

        public DataGridViewRowCollection()
        {
        }

        public DataGridViewRowCollection(System.Windows.Forms.DataGridViewRowCollection p1)
        {
            M_DataGridViewRowCollection = p1;
        }

        public int Count
        {
            get { return M_DataGridViewRowCollection.Count; }
        }

        public osf.DataGridViewRow this[int p1]
        {
            get { return new osf.DataGridViewRow(M_DataGridViewRowCollection[p1]); }
        }

        public int Add()
        {
            return M_DataGridViewRowCollection.Add();
        }

        public int Add(osf.DataGridViewRow p1)
        {
            return M_DataGridViewRowCollection.Add(p1.M_DataGridViewRow);
        }

        public int AddCopy(int p1)
        {
            return M_DataGridViewRowCollection.AddCopy(p1);
        }

        public void Clear()
        {
            M_DataGridViewRowCollection.Clear();
        }

        public bool Contains(osf.DataGridViewRow p1)
        {
            return M_DataGridViewRowCollection.Contains(p1.M_DataGridViewRow);
        }

        public int IndexOf(osf.DataGridViewRow p1)
        {
            return M_DataGridViewRowCollection.IndexOf(p1.M_DataGridViewRow);
        }

        public void Insert(int index, osf.DataGridViewRow value)
        {
            M_DataGridViewRowCollection.Insert(index, value.M_DataGridViewRow);
        }

        public void Remove(osf.DataGridViewRow p1)
        {
            M_DataGridViewRowCollection.Remove(p1.M_DataGridViewRow);
        }

        public void RemoveAt(int Index)
        {
            M_DataGridViewRowCollection.RemoveAt(Index);
        }
    }

    [ContextClass ("КлСтрокиТаблицы", "ClDataGridViewRowCollection")]
    public class ClDataGridViewRowCollection : AutoContext<ClDataGridViewRowCollection>
    {
        public ClDataGridViewRowCollection()
        {
            DataGridViewRowCollection DataGridViewRowCollection1 = new DataGridViewRowCollection();
            DataGridViewRowCollection1.dll_obj = this;
            Base_obj = DataGridViewRowCollection1;
        }
		
        public ClDataGridViewRowCollection(DataGridViewRowCollection p1)
        {
            DataGridViewRowCollection DataGridViewRowCollection1 = p1;
            DataGridViewRowCollection1.dll_obj = this;
            Base_obj = DataGridViewRowCollection1;
        }
        
        public DataGridViewRowCollection Base_obj;
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Вставить", "Insert")]
        public void Insert(int p1, ClDataGridViewRow p2)
        {
            Base_obj.Insert(p1, p2.Base_obj);
        }

        [ContextMethod("Добавить", "Add")]
        public int Add(ClDataGridViewRow p1 = null)
        {
            if (p1 == null)
            {
                return Base_obj.Add();
            }
            return Base_obj.Add(p1.Base_obj);
        }
        
        [ContextMethod("ДобавитьКопию", "AddCopy")]
        public int AddCopy(int p1)
        {
            return Base_obj.AddCopy(p1);
        }

        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(ClDataGridViewRow p1)
        {
            return Base_obj.IndexOf(p1.Base_obj);
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Содержит", "Contains")]
        public bool Contains(ClDataGridViewRow p1)
        {
            return Base_obj.Contains(p1.Base_obj);
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClDataGridViewRow p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClDataGridViewRow Item(int p1)
        {
            return new ClDataGridViewRow(Base_obj[p1]);
        }
    }
}
