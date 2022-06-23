using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class DataGridViewComboBoxCellObjectCollection
    {
        public ClDataGridViewComboBoxCellObjectCollection dll_obj;
        public System.Windows.Forms.DataGridViewComboBoxCell.ObjectCollection M_DataGridViewComboBoxCellObjectCollection;

        public DataGridViewComboBoxCellObjectCollection()
        {
        }

        public DataGridViewComboBoxCellObjectCollection(System.Windows.Forms.DataGridViewComboBoxCell.ObjectCollection p1)
        {
            M_DataGridViewComboBoxCellObjectCollection = p1;
        }

        public int Count
        {
            get { return M_DataGridViewComboBoxCellObjectCollection.Count; }
        }

        public object this[int p1]
        {
            get { return M_DataGridViewComboBoxCellObjectCollection[p1]; }
        }

        public int Add(object p1)
        {
            return M_DataGridViewComboBoxCellObjectCollection.Add(p1);
        }

        public void Clear()
        {
            M_DataGridViewComboBoxCellObjectCollection.Clear();
        }

        public bool Contains(object p1)
        {
            return M_DataGridViewComboBoxCellObjectCollection.Contains(p1);
        }

        public int IndexOf(object p1)
        {
            return M_DataGridViewComboBoxCellObjectCollection.IndexOf(p1);
        }

        public void Insert(int index, object value)
        {
            M_DataGridViewComboBoxCellObjectCollection.Insert(index, value);
        }

        public void Remove(object p1)
        {
            M_DataGridViewComboBoxCellObjectCollection.Remove(p1);
        }

        public void RemoveAt(int Index)
        {
            M_DataGridViewComboBoxCellObjectCollection.RemoveAt(Index);
        }
    }

    [ContextClass ("КлЭлементыПоляВыбораЯчейки", "ClDataGridViewComboBoxCellObjectCollection")]
    public class ClDataGridViewComboBoxCellObjectCollection : AutoContext<ClDataGridViewComboBoxCellObjectCollection>
    {
        public ClDataGridViewComboBoxCellObjectCollection()
        {
            DataGridViewComboBoxCellObjectCollection DataGridViewComboBoxCellObjectCollection1 = new DataGridViewComboBoxCellObjectCollection();
            DataGridViewComboBoxCellObjectCollection1.dll_obj = this;
            Base_obj = DataGridViewComboBoxCellObjectCollection1;
        }
		
        public ClDataGridViewComboBoxCellObjectCollection(DataGridViewComboBoxCellObjectCollection p1)
        {
            DataGridViewComboBoxCellObjectCollection DataGridViewComboBoxCellObjectCollection1 = p1;
            DataGridViewComboBoxCellObjectCollection1.dll_obj = this;
            Base_obj = DataGridViewComboBoxCellObjectCollection1;
        }
        
        public DataGridViewComboBoxCellObjectCollection Base_obj;
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Вставить", "Insert")]
        public ClListItem Insert(int p1, IValue p2)
        {
            osf.ClListItem p3 = new ClListItem();
            if (p2.GetType().ToString().Contains("osf.ClListItem"))
            {
                p3.Base_obj = ((osf.ClListItem)p2).Base_obj;
            }
            else
            {
                p3.Base_obj = new ListItem(p2.ToString(), p2);
            }
            Base_obj.Insert(p1, p3.Base_obj);
            return p3;
        }

        [ContextMethod("Добавить", "Add")]
        public ClListItem Add(IValue p1)
        {
            osf.ClListItem p2;
            if (p1.GetType().ToString().Contains("osf.ClListItem"))
            {
                p2 = new ClListItem(((osf.ClListItem)p1).Base_obj);
            }
            else
            {
                string s = "";
                try
                {
                    s = p1.GetType().GetCustomAttribute<ContextClassAttribute>().GetName();
                }
                catch
                {
                    s = p1.ToString();
                }
                p2 = new ClListItem(new ListItem(s, p1));
            }
            Base_obj.Add(p2.Base_obj);
            return p2;
        }
        
        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(ClListItem p1)
        {
            return Base_obj.IndexOf(p1.Base_obj);
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Содержит", "Contains")]
        public bool Contains(ClListItem p1)
        {
            return Base_obj.Contains(p1.Base_obj);
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClListItem p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public IValue Item(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj[p1]);
        }
    }
}
