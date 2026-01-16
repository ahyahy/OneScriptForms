using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class ListBoxObjectCollection : CollectionBase
    {
        public ClListBoxObjectCollection dll_obj;
        public System.Windows.Forms.ListBox.ObjectCollection M_ListBoxObjectCollection;

        public ListBoxObjectCollection()
        {
        }

        public ListBoxObjectCollection(System.Windows.Forms.ListBox.ObjectCollection p1)
        {
            M_ListBoxObjectCollection = p1;
            base.List = M_ListBoxObjectCollection;
        }

        public new object this[int index]
        {
            get { return M_ListBoxObjectCollection[index]; }
        }

        public override object Current
        {
            get { return Enumerator.Current; }
        }

        public new object Add(object item)
        {
            M_ListBoxObjectCollection.Add(item);
            //System.Windows.Forms.Application.DoEvents();
            return item;
        }

        public new object Insert(int index, object item)
        {
            M_ListBoxObjectCollection.Insert(index, item);
            //System.Windows.Forms.Application.DoEvents();
            return item;
        }

        public new void Remove(object item)
        {
            M_ListBoxObjectCollection.Remove(item);
            //System.Windows.Forms.Application.DoEvents();
        }
    }

    [ContextClass("КлЭлементыПоляСписка", "ClListBoxObjectCollection")]
    public class ClListBoxObjectCollection : AutoContext<ClListBoxObjectCollection>
    {
        public ClListBox M_obj;

        public ClListBoxObjectCollection()
        {
            ListBoxObjectCollection ListBoxObjectCollection1 = new ListBoxObjectCollection();
            ListBoxObjectCollection1.dll_obj = this;
            Base_obj = ListBoxObjectCollection1;
        }

        public ClListBoxObjectCollection(ListBoxObjectCollection p1)
        {
            ListBoxObjectCollection ListBoxObjectCollection1 = p1;
            ListBoxObjectCollection1.dll_obj = this;
            Base_obj = ListBoxObjectCollection1;
        }

        public ListBoxObjectCollection Base_obj;

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        [ContextMethod("Вставить", "Insert")]
        public IValue Insert(int p1, IValue p2)
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
        public IValue Add(IValue p1)
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

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
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
        public IValue Item(int p1, IValue p2 = null)
        {
            ListItem ListItem1 = new ListItem();
            if (p2 != null)
            {
                if (Base_obj[p1].GetType().ToString() == "System.Data.DataRowView")
                {
                    return (IValue)null;
                }
                else if (Base_obj[p1].GetType().ToString() == "osf.ClListBox")
                {
                    return (IValue)null;
                }
                else if (p2.GetType().ToString() == "osf.ClListItem")
                {
                    ListItem ListItem2 = ((dynamic)p2).Base_obj;
                    ListItem1 = (ListItem)Base_obj[p1];
                    ListItem1.Text = ListItem2.Text;
                    ListItem1.Value = ListItem2.Value;
                    ListItem1.ForeColor = ListItem2.ForeColor;
                }
                else
                {
                    string s = "";
                    try
                    {
                        s = p2.GetType().GetCustomAttribute<ContextClassAttribute>().GetName();
                    }
                    catch
                    {
                        s = p2.ToString();
                    }
                    ListItem1 = (ListItem)Base_obj[p1];
                    ListItem1.Text = s;
                    ListItem1.Value = p2;
                }
                M_obj.Base_obj.Invalidate();
                return (IValue)new ClListItem(ListItem1);
            }
            else
            {
                if (Base_obj[p1].GetType().ToString() == "System.Data.DataRowView")
                {
                    DataRowView DataRowView1 = new DataRowView((System.Data.DataRowView)Base_obj[p1]);
                    ListItem1.Text = DataRowView1.get_Item(M_obj.Base_obj.DisplayMember).ToString();
                    ListItem1.Value = DataRowView1.get_Item(M_obj.Base_obj.ValueMember);
                }
                else if (Base_obj[p1].GetType().ToString() == "osf.ListItem")
                {
                    ListItem1 = (ListItem)Base_obj[p1];
                }
                else
                {
                    ListItem1.Text = Base_obj[p1].ToString();
                    ListItem1.Value = Base_obj[p1];
                    ListItem1.ForeColor = ((dynamic)Base_obj[p1]).ForeColor;
                }
                return new ClListItem(ListItem1);
            }
        }
    }
}
