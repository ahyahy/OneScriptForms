using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class ListViewCheckedItemCollection : CollectionBase
    {
        public ClListViewCheckedItemCollection dll_obj;
        public System.Windows.Forms.ListView.CheckedListViewItemCollection M_ListViewCheckedListViewItemCollection;

        public ListViewCheckedItemCollection()
        {
        }

        public ListViewCheckedItemCollection(System.Windows.Forms.ListView.CheckedListViewItemCollection p1)
        {
            M_ListViewCheckedListViewItemCollection = p1;
            base.List = M_ListViewCheckedListViewItemCollection;
        }

        //Свойства============================================================

        public override object Current
        {
            get
            {
                return (object)((ListViewItemEx)Enumerator.Current).M_Object;
            }
        }

        public new osf.ListViewItem this[int index]
        {
            get { return ((ListViewItemEx)M_ListViewCheckedListViewItemCollection[index]).M_Object; }
        }

        //Методы============================================================

    }

    [ContextClass ("КлПомеченныеЭлементыСпискаЭлементов", "ClListViewCheckedItemCollection")]
    public class ClListViewCheckedItemCollection : AutoContext<ClListViewCheckedItemCollection>
    {

        public ClListViewCheckedItemCollection()
        {
            ListViewCheckedItemCollection ListViewCheckedItemCollection1 = new ListViewCheckedItemCollection();
            ListViewCheckedItemCollection1.dll_obj = this;
            Base_obj = ListViewCheckedItemCollection1;
        }
		
        public ClListViewCheckedItemCollection(ListViewCheckedItemCollection p1)
        {
            ListViewCheckedItemCollection ListViewCheckedItemCollection1 = p1;
            ListViewCheckedItemCollection1.dll_obj = this;
            Base_obj = ListViewCheckedItemCollection1;
        }
        
        public ListViewCheckedItemCollection Base_obj;

        //Свойства============================================================

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //Методы============================================================

        [ContextMethod("Элемент", "Item")]
        public ClListViewItem Item(int p1)
        {
            return new ClListViewItem(Base_obj[p1]);
        }
    }
}
