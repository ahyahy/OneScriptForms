using System;
using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class ListBoxSelectedIndexCollection : CollectionBase
    {
        public ClListBoxSelectedIndexCollection dll_obj;
        public System.Windows.Forms.ListBox.SelectedIndexCollection M_ListBoxSelectedIndexCollection;

        public ListBoxSelectedIndexCollection()
        {
        }

        public ListBoxSelectedIndexCollection(System.Windows.Forms.ListBox.SelectedIndexCollection p1)
        {
            M_ListBoxSelectedIndexCollection = p1;
            base.List = M_ListBoxSelectedIndexCollection;
        }

        //Свойства============================================================

        public new int this[int index]
        {
            get { return M_ListBoxSelectedIndexCollection[index]; }
        }

        public override object Current
        {
            get { return Enumerator.Current; }
        }

        //Методы============================================================

        public override bool Contains(object value)
        {
            return M_ListBoxSelectedIndexCollection.Contains(Convert.ToInt32(value));
        }

        public override int IndexOf(object value)
        {
            return M_ListBoxSelectedIndexCollection.IndexOf(Convert.ToInt32(value));
        }

        public override void Clear()
        {
        }

        public new void Insert(int index, object item)
        {
        }

    }

    [ContextClass ("КлИндексыВыбранныхПоляСписка", "ClListBoxSelectedIndexCollection")]
    public class ClListBoxSelectedIndexCollection : AutoContext<ClListBoxSelectedIndexCollection>
    {

        public ClListBoxSelectedIndexCollection()
        {
            ListBoxSelectedIndexCollection ListBoxSelectedIndexCollection1 = new ListBoxSelectedIndexCollection();
            ListBoxSelectedIndexCollection1.dll_obj = this;
            Base_obj = ListBoxSelectedIndexCollection1;
        }
		
        public ClListBoxSelectedIndexCollection(ListBoxSelectedIndexCollection p1)
        {
            ListBoxSelectedIndexCollection ListBoxSelectedIndexCollection1 = p1;
            ListBoxSelectedIndexCollection1.dll_obj = this;
            Base_obj = ListBoxSelectedIndexCollection1;
        }
        
        public ListBoxSelectedIndexCollection Base_obj;

        //Свойства============================================================

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //Методы============================================================

        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(int p1)
        {
            return Base_obj.IndexOf(p1);
        }

        [ContextMethod("Содержит", "Contains")]
        public bool Contains(int p1)
        {
            return Base_obj.Contains(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public int Item(int p1)
        {
            return Base_obj[p1];
        }
    }
}
