using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class DataGridViewCellCollection : CollectionBase
    {
        public ClDataGridViewCellCollection dll_obj;
        public System.Windows.Forms.DataGridViewCellCollection M_DataGridViewCellCollection;

        public DataGridViewCellCollection()
        {
        }

        public DataGridViewCellCollection(System.Windows.Forms.DataGridViewCellCollection p1)
        {
            M_DataGridViewCellCollection = p1;
            base.List = M_DataGridViewCellCollection;
        }

        public new object this[int index]
        {
            get { return M_DataGridViewCellCollection[index]; }
        }

        public override object Current
        {
            get { return Enumerator.Current; }
        }

        public int Add(System.Windows.Forms.DataGridViewCell item)
        {
            return M_DataGridViewCellCollection.Add(item);
        }
    }

    [ContextClass ("КлЯчейкиТаблицы", "ClDataGridViewCellCollection")]
    public class ClDataGridViewCellCollection : AutoContext<ClDataGridViewCellCollection>
    {
        public ClDataGridViewCellCollection()
        {
            DataGridViewCellCollection DataGridViewCellCollection1 = new DataGridViewCellCollection();
            DataGridViewCellCollection1.dll_obj = this;
            Base_obj = DataGridViewCellCollection1;
        }
		
        public ClDataGridViewCellCollection(DataGridViewCellCollection p1)
        {
            DataGridViewCellCollection DataGridViewCellCollection1 = p1;
            DataGridViewCellCollection1.dll_obj = this;
            Base_obj = DataGridViewCellCollection1;
        }
        
        public DataGridViewCellCollection Base_obj;
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Элемент", "Item")]
        public IValue Item(int p1)
        {
            System.Type Type1 = Base_obj[p1].GetType();
            if (Type1 == typeof(osf.DataGridViewTextBoxCellEx))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewTextBoxCell((DataGridViewTextBoxCellEx)Base_obj[p1]));
            }
            else if (Type1 == typeof(osf.DataGridViewImageCellEx))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewImageCell((DataGridViewImageCellEx)Base_obj[p1]));
            }
            else if (Type1 == typeof(DataGridViewButtonCellEx))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewButtonCell((DataGridViewButtonCellEx)Base_obj[p1]));
            }
            else if (Type1 == typeof(osf.DataGridViewComboBoxCellEx))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewComboBoxCell((DataGridViewComboBoxCellEx)Base_obj[p1]));
            }
            else if (Type1 == typeof(osf.DataGridViewLinkCellEx))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewLinkCell((DataGridViewLinkCellEx)Base_obj[p1]));
            }
            else if (Type1 == typeof(osf.DataGridViewCheckBoxCellEx))
            {
                return OneScriptForms.RevertObj(new osf.DataGridViewCheckBoxCell((DataGridViewCheckBoxCellEx)Base_obj[p1]));
            }
            dynamic Obj1 = null;
            string str1 = Base_obj[p1].GetType().ToString();
            string str2 = str1.Replace("System.Windows.Forms.", "osf.");
            System.Type Type2 = System.Type.GetType(str2, false, true);
            object[] args1 = { Base_obj[p1] };
            Obj1 = Activator.CreateInstance(Type2, args1);
            return OneScriptForms.RevertObj(Obj1);
        }
    }
}
