using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ListViewItemCollection : CollectionBase
    {
        public ClListViewItemCollection dll_obj;
        public System.Windows.Forms.ListView.ListViewItemCollection M_ListViewItemCollection;

        public ListViewItemCollection()
        {
        }

        public ListViewItemCollection(System.Windows.Forms.ListView.ListViewItemCollection p1)
        {
            M_ListViewItemCollection = p1;
            base.List = M_ListViewItemCollection;
        }

        public override object Current
        {
            get { return ((dynamic)Enumerator.Current).M_ListViewItem; }
        }

        public new osf.ListViewItem this[int index]
        {
            get { return ((ListViewItemEx)M_ListViewItemCollection[index]).M_Object; }
        }

        public osf.ListViewItem Insert(int index, ListViewItem item)
        {
            M_ListViewItemCollection.Insert(index, (ListViewItemEx)item.M_ListViewItem);
            return item;
        }

        public new osf.ListViewItem Add(object item)
        {
            if (item is ListViewItem)
            {
                M_ListViewItemCollection.Add((ListViewItemEx)((ListViewItem)item).M_ListViewItem);
                //System.Windows.Forms.Application.DoEvents();
                return (ListViewItem)item;
            }
            ListViewItem ListViewItem1 = new ListViewItem("", -1);
            ListViewItem1.Text = Convert.ToString(item);
            M_ListViewItemCollection.Add((ListViewItemEx)ListViewItem1.M_ListViewItem);
            //System.Windows.Forms.Application.DoEvents();
            return (ListViewItem)ListViewItem1;
        }

        public void Remove(ListViewItem item)
        {
            M_ListViewItemCollection.Remove((System.Windows.Forms.ListViewItem)item.M_ListViewItem);
            //System.Windows.Forms.Application.DoEvents();
        }
    }

    [ContextClass ("КлЭлементыСпискаЭлементов", "ClListViewItemCollection")]
    public class ClListViewItemCollection : AutoContext<ClListViewItemCollection>
    {
        public ClListViewItemCollection()
        {
            ListViewItemCollection ListViewItemCollection1 = new ListViewItemCollection();
            ListViewItemCollection1.dll_obj = this;
            Base_obj = ListViewItemCollection1;
        }
		
        public ClListViewItemCollection(ListViewItemCollection p1)
        {
            ListViewItemCollection ListViewItemCollection1 = p1;
            ListViewItemCollection1.dll_obj = this;
            Base_obj = ListViewItemCollection1;
        }
        
        public ListViewItemCollection Base_obj;
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Вставить", "Insert")]
        public ClListViewItem Insert(int p1, ClListViewItem p2)
        {
            return new ClListViewItem(Base_obj.Insert(p1, p2.Base_obj));
        }

        [ContextMethod("Добавить", "Add")]
        public ClListViewItem Add(IValue p1)
        {
            ListViewItem ListViewItem1 = null;
            if (p1.GetType().ToString() == "osf.ClListViewItem")
            {
                ListViewItem1 = Base_obj.Add(((ClListViewItem)p1).Base_obj);
            }
            else if (p1.SystemType.Name == "Строка")
            {
                ListViewItem1 = Base_obj.Add(p1.ToString());
            }
            else
            {
                return null;
            }
            return new ClListViewItem(ListViewItem1);
        }
        
        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClListViewItem p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClListViewItem Item(int p1, ClListViewItem p2 = null)
        {
            if (p2 != null)
            {
                Base_obj.RemoveAt(p1);
                Base_obj.Insert(p1, p2.Base_obj);
                return new ClListViewItem(Base_obj[p1]);
            }
            else
            {
                return new ClListViewItem(Base_obj[p1]);
            }
        }
    }
}
