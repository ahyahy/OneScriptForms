using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ListBoxSelectedObjectCollection : CollectionBase
    {
        public ClListBoxSelectedObjectCollection dll_obj;
        public System.Windows.Forms.ListBox.SelectedObjectCollection M_ListBoxSelectedObjectCollection;

        public ListBoxSelectedObjectCollection(System.Windows.Forms.ListBox.SelectedObjectCollection p1)
        {
            M_ListBoxSelectedObjectCollection = p1;
            base.List = M_ListBoxSelectedObjectCollection;
        }

        public new object this[int index]
        {
            get { return M_ListBoxSelectedObjectCollection[index]; }
            set { M_ListBoxSelectedObjectCollection[index] = value; }
        }

        public override object Current
        {
            get { return Enumerator.Current; }
        }

        public override bool Contains(object value)
        {
            return M_ListBoxSelectedObjectCollection.Contains(value);
        }

        public override int IndexOf(object value)
        {
            return M_ListBoxSelectedObjectCollection.IndexOf(value);
        }

        public override void Clear()
        {
        }

        public new void Insert(int index, object item)
        {
        }
    }

    [ContextClass("КлВыбранныеЭлементыПоляСписка", "ClListBoxSelectedObjectCollection")]
    public class ClListBoxSelectedObjectCollection : AutoContext<ClListBoxSelectedObjectCollection>
    {
        public ClListBox M_obj;

        public ClListBoxSelectedObjectCollection(ListBoxSelectedObjectCollection p1, ClListBox p2)
        {
            ListBoxSelectedObjectCollection ListBoxSelectedObjectCollection1 = p1;
            ListBoxSelectedObjectCollection1.dll_obj = this;
            Base_obj = ListBoxSelectedObjectCollection1;
            M_obj = p2;
        }

        public ListBoxSelectedObjectCollection Base_obj;

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(IValue p1)
        {
            for (int i = 0; i < Base_obj.Count; i++)
            {
                if (Base_obj[i].ToString() == p1.AsString())
                {
                    return i;
                }
            }
            return Base_obj.IndexOf(p1.AsString());
        }

        [ContextMethod("Содержит", "Contains")]
        public bool Contains(IValue p1)
        {
            foreach (object o in Base_obj)
            {
                if (o.ToString() == p1.AsString())
                {
                    return true;
                }
            }
            return false;
        }

        [ContextMethod("Элемент", "Item")]
        public IValue Item(int p1)
        {
            ListItem ListItem1 = new ListItem();
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
            }
            return new ClListItem(ListItem1);
        }
    }
}
