using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewColumnCollection : CollectionBase
    {
        public ClDataGridViewColumnCollection dll_obj;
        public System.Windows.Forms.DataGridViewColumnCollection M_DataGridViewColumnCollection;

        public DataGridViewColumnCollection()
        {
        }

        public DataGridViewColumnCollection(System.Windows.Forms.DataGridViewColumnCollection p1)
        {
            M_DataGridViewColumnCollection = p1;
            base.List = M_DataGridViewColumnCollection;
        }

        public new object this[int index]
        {
            get { return M_DataGridViewColumnCollection[index]; }
        }

        public override object Current
        {
            get { return Enumerator.Current; }
        }

        public int Add(osf.DataGridViewColumn item)
        {
            return M_DataGridViewColumnCollection.Add(item.M_DataGridViewColumn);
        }

        public void Insert(int index, osf.DataGridViewColumn item)
        {
            M_DataGridViewColumnCollection.Insert(index, item.M_DataGridViewColumn);
        }

        public void Remove(osf.DataGridViewColumn p1)
        {
            M_DataGridViewColumnCollection.Remove(p1.M_DataGridViewColumn);
        }
    }

    [ContextClass ("КлКолонкиТаблицы", "ClDataGridViewColumnCollection")]
    public class ClDataGridViewColumnCollection : AutoContext<ClDataGridViewColumnCollection>
    {
        public ClDataGridViewColumnCollection()
        {
            DataGridViewColumnCollection DataGridViewColumnCollection1 = new DataGridViewColumnCollection();
            DataGridViewColumnCollection1.dll_obj = this;
            Base_obj = DataGridViewColumnCollection1;
        }
		
        public ClDataGridViewColumnCollection(DataGridViewColumnCollection p1)
        {
            DataGridViewColumnCollection DataGridViewColumnCollection1 = p1;
            DataGridViewColumnCollection1.dll_obj = this;
            Base_obj = DataGridViewColumnCollection1;
        }
        
        public DataGridViewColumnCollection Base_obj;
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Вставить", "Insert")]
        public void Insert(int p1, IValue p2)
        {
            Base_obj.Insert(p1, ((dynamic)p2).Base_obj);
        }

        [ContextMethod("Добавить", "Add")]
        public int Add(IValue p1)
        {
            return Base_obj.Add(((dynamic)p1).Base_obj);
        }
        
        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Удалить", "Remove")]
        public void Remove(IValue p1)
        {
            Base_obj.Remove(((dynamic)p1).Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public IValue Item(int p1)
        {
            System.Type Type1 = Base_obj[p1].GetType();
            if (Type1 == typeof(System.Windows.Forms.DataGridViewTextBoxColumn))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewTextBoxColumn((System.Windows.Forms.DataGridViewTextBoxColumn)Base_obj[p1]));
            }
            else if (Type1 == typeof(System.Windows.Forms.DataGridViewImageColumn))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewImageColumn((System.Windows.Forms.DataGridViewImageColumn)Base_obj[p1]));
            }
            else if (Type1 == typeof(System.Windows.Forms.DataGridViewButtonColumn))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewButtonColumn((System.Windows.Forms.DataGridViewButtonColumn)Base_obj[p1]));
            }
            else if (Type1 == typeof(System.Windows.Forms.DataGridViewComboBoxColumn))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewComboBoxColumn((System.Windows.Forms.DataGridViewComboBoxColumn)Base_obj[p1]));
            }
            else if (Type1 == typeof(System.Windows.Forms.DataGridViewLinkColumn))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewLinkColumn((System.Windows.Forms.DataGridViewLinkColumn)Base_obj[p1]));
            }
            else if (Type1 == typeof(System.Windows.Forms.DataGridViewCheckBoxColumn))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewCheckBoxColumn((System.Windows.Forms.DataGridViewCheckBoxColumn)Base_obj[p1]));
            }
            return null;
        }
    }
}
