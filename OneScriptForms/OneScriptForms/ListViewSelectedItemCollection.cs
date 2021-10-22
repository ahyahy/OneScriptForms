using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class ListViewSelectedItemCollection : CollectionBase
    {
        public ClListViewSelectedItemCollection dll_obj;
        public System.Windows.Forms.ListView.SelectedListViewItemCollection M_SelectedListViewItemCollection;

        public ListViewSelectedItemCollection(System.Windows.Forms.ListView.SelectedListViewItemCollection p1)
        {
            M_SelectedListViewItemCollection = p1;
            base.List = M_SelectedListViewItemCollection;
        }

        public override object Current
        {
            get { return (object)((ListViewItemEx)Enumerator.Current).M_Object; }
        }

        public new osf.ListViewItem this[int index]
        {
            get { return ((ListViewItemEx)M_SelectedListViewItemCollection[index]).M_Object; }
        }

        public bool Contains(ListViewItem item)
        {
            return M_SelectedListViewItemCollection.Contains((System.Windows.Forms.ListViewItem)item.M_ListViewItem);
        }
    }

    [ContextClass ("КлВыбранныеЭлементыСпискаЭлементов", "ClListViewSelectedItemCollection")]
    public class ClListViewSelectedItemCollection : AutoContext<ClListViewSelectedItemCollection>
    {
        public ClListViewSelectedItemCollection(ListViewSelectedItemCollection p1)
        {
            ListViewSelectedItemCollection ListViewSelectedItemCollection1 = p1;
            ListViewSelectedItemCollection1.dll_obj = this;
            Base_obj = ListViewSelectedItemCollection1;
        }

        public ListViewSelectedItemCollection Base_obj;
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Содержит", "Contains")]
        public bool Contains(ClListViewItem p1)
        {
            return Base_obj.Contains(p1.Base_obj);
        }

        [ContextMethod("Элемент", "Item")]
        public ClListViewItem Item(int p1)
        {
            return new ClListViewItem(Base_obj[p1]);
        }
    }
}
