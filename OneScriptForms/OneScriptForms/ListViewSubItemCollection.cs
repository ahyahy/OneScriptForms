using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ListViewSubItemCollection : CollectionBase
    {
        public ClListViewSubItemCollection dll_obj;
        public System.Windows.Forms.ListViewItem.ListViewSubItemCollection M_ListViewSubItemCollection;

        public ListViewSubItemCollection()
        {
        }

        public ListViewSubItemCollection(System.Windows.Forms.ListViewItem.ListViewSubItemCollection p1)
        {
            M_ListViewSubItemCollection = p1;
            base.List = M_ListViewSubItemCollection;
        }

        public override object Current
        {
            get { return ((dynamic)Enumerator.Current).M_ListViewSubItem; }
        }

        public new osf.ListViewSubItem this[int index]
        {
            get { return new ListViewSubItem(M_ListViewSubItemCollection[index]); }
        }

        public osf.ListViewSubItem Insert(int index, ListViewSubItem p1)
        {
            M_ListViewSubItemCollection.Insert(index, (System.Windows.Forms.ListViewItem.ListViewSubItem)p1.M_ListViewSubItem);
            return p1;
        }

        public new osf.ListViewSubItem Add(object item)
        {
            if (item is ListViewSubItem)
            {
                M_ListViewSubItemCollection.Add((((ListViewSubItem)item).M_ListViewSubItem));
                //System.Windows.Forms.Application.DoEvents();
                return (ListViewSubItem)item;
            }
            ListViewSubItem ListViewSubItem1 = new ListViewSubItem("");
            ListViewSubItem1.Text = Convert.ToString(item);
            M_ListViewSubItemCollection.Add(ListViewSubItem1.M_ListViewSubItem);
            //System.Windows.Forms.Application.DoEvents();
            return (ListViewSubItem)ListViewSubItem1;
        }
    }

    [ContextClass("КлПодэлементыСпискаЭлементов", "ClListViewSubItemCollection")]
    public class ClListViewSubItemCollection : AutoContext<ClListViewSubItemCollection>
    {
        public ClListViewSubItemCollection()
        {
            ListViewSubItemCollection ListViewSubItemCollection1 = new ListViewSubItemCollection();
            ListViewSubItemCollection1.dll_obj = this;
            Base_obj = ListViewSubItemCollection1;
        }

        public ClListViewSubItemCollection(ListViewSubItemCollection p1)
        {
            ListViewSubItemCollection ListViewSubItemCollection1 = p1;
            ListViewSubItemCollection1.dll_obj = this;
            Base_obj = ListViewSubItemCollection1;
        }

        public ListViewSubItemCollection Base_obj;

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        [ContextMethod("Вставить", "Insert")]
        public ClListViewSubItem Insert(int p1, ClListViewSubItem p2)
        {
            return (ClListViewSubItem)OneScriptForms.RevertObj(Base_obj.Insert(p1, p2.Base_obj));
        }

        [ContextMethod("Добавить", "Add")]
        public ClListViewSubItem Add(IValue p1)
        {
            ListViewSubItem ListViewSubItem1 = null;
            if (p1.GetType().ToString() == "osf.ClListViewSubItem")
            {
                ListViewSubItem1 = Base_obj.Add(((ClListViewSubItem)p1).Base_obj);
            }
            else if (p1.SystemType.Name == "Строка")
            {
                ListViewSubItem1 = Base_obj.Add(p1.ToString());
            }
            else
            {
                return null;
            }
            return new ClListViewSubItem(ListViewSubItem1);
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClListViewSubItem Item(int p1, ClListViewSubItem p2 = null)
        {
            if (p2 != null)
            {
                Base_obj.RemoveAt(p1);
                Base_obj.Insert(p1, p2.Base_obj);
                return p2;
            }
            else
            {
                return new ClListViewSubItem(Base_obj[p1]);
            }
        }
    }
}
