using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class MenuItemCollection : CollectionBase
    {
        public ClMenuItemCollection dll_obj;
        public System.Windows.Forms.Menu.MenuItemCollection M_MenuItemCollection;

        public MenuItemCollection()
        {
        }

        public MenuItemCollection(System.Windows.Forms.Menu.MenuItemCollection p1)
        {
            M_MenuItemCollection = p1;
            base.List = M_MenuItemCollection;
        }

        //Свойства============================================================

        public override object Current
        {
            get
            {
                return ((MenuItemEx)Enumerator.Current).M_Object;
            }
        }

        public new osf.MenuItem this[int p1]
        {
            get { return (MenuItem)((MenuItemEx)M_MenuItemCollection[p1]).M_Object; }
        }

        //Методы============================================================

        public osf.MenuItem Add(MenuItem item)
        {
            MenuItem menuItem;
            if (item is MenuItem)
            {
                menuItem = item;
            }
            else
            {
                menuItem = new MenuItem();
            }
            M_MenuItemCollection.Add(menuItem.M_MenuItem);
            System.Windows.Forms.Application.DoEvents();
            return menuItem;
        }

        public bool Contains(osf.MenuItem item)
        {
            return M_MenuItemCollection.Contains((System.Windows.Forms.MenuItem)item.M_MenuItem);
        }

        public int IndexOf(osf.MenuItem item)
        {
            return M_MenuItemCollection.IndexOf((System.Windows.Forms.MenuItem)item.M_MenuItem);
        }

        public object Remove(osf.MenuItem item)
        {
            M_MenuItemCollection.Remove((System.Windows.Forms.MenuItem)item.M_MenuItem);
            return null;
        }

    }

    [ContextClass ("КлЭлементыМеню", "ClMenuItemCollection")]
    public class ClMenuItemCollection : AutoContext<ClMenuItemCollection>
    {

        public ClMenuItemCollection()
        {
            MenuItemCollection MenuItemCollection1 = new MenuItemCollection();
            MenuItemCollection1.dll_obj = this;
            Base_obj = MenuItemCollection1;
        }
		
        public ClMenuItemCollection(MenuItemCollection p1)
        {
            MenuItemCollection MenuItemCollection1 = p1;
            MenuItemCollection1.dll_obj = this;
            Base_obj = MenuItemCollection1;
        }
        
        public MenuItemCollection Base_obj;

        //Свойства============================================================

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //Методы============================================================

        [ContextMethod("Добавить", "Add")]
        public ClMenuItem Add(ClMenuItem p1)
        {
            return Base_obj.Add(p1.Base_obj).dll_obj;
        }
        
        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(ClMenuItem p1)
        {
            return Base_obj.IndexOf(p1.Base_obj);
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("Содержит", "Contains")]
        public bool Contains(ClMenuItem p1)
        {
            return Base_obj.Contains(p1.Base_obj);
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(ClMenuItem p1)
        {
            Base_obj.Remove(p1.Base_obj);
        }

        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClMenuItem Item(int p1)
        {
            return new ClMenuItem(Base_obj[p1]);
        }
    }
}
