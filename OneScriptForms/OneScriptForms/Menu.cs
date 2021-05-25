using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class Menu
    {
        public ClMenu dll_obj;
        public System.Windows.Forms.Menu M_Menu;

        //Свойства============================================================

        public osf.MenuItem get_MenuItem(int index)
        {
            return (MenuItem)((MenuItemEx)M_Menu.MenuItems[index]).M_Object;
        }

        public osf.MenuItemCollection MenuItems
        {
            get { return new MenuItemCollection(M_Menu.MenuItems); }
        }

        //Методы============================================================

        public MainMenu GetMainMenu()
        {
            try
            {
                return ((MainMenuEx)M_Menu.GetMainMenu()).M_Object;
            }
            catch
            {
                return null;
            }
        }

        public osf.MenuItem MenuItems2(int p1)
        {
            return MenuItems[p1];
        }

    }

    [ContextClass ("КлМеню", "ClMenu")]
    public class ClMenu : AutoContext<ClMenu>
    {
        private ClMenuItemCollection menuItems;

        public ClMenu()
        {
            Menu Menu1 = new Menu();
            Menu1.dll_obj = this;
            Base_obj = Menu1;
            menuItems = new ClMenuItemCollection(Base_obj.MenuItems);
        }
		
        public ClMenu(Menu p1)
        {
            Menu Menu1 = p1;
            Menu1.dll_obj = this;
            Base_obj = Menu1;
            menuItems = new ClMenuItemCollection(Base_obj.MenuItems);
        }
        
        public Menu Base_obj;

        //Свойства============================================================

        [ContextProperty("ЭлементыМеню", "MenuItems")]
        public ClMenuItemCollection MenuItems
        {
            get { return menuItems; }
        }

        //Методы============================================================

        [ContextMethod("ПолучитьГлавноеМеню", "GetMainMenu")]
        public ClMainMenu GetMainMenu()
        {
            return (ClMainMenu)OneScriptForms.RevertObj(Base_obj.GetMainMenu());
        }
        
        [ContextMethod("СлитьМеню", "MergeMenu")]
        public void MergeMenu(IValue p1)
        {
            string p1_type = OneScriptForms.RevertObj(p1).GetType().ToString();
            if ((p1_type == "osf.ClMainMenu") || (p1_type == "osf.ClContextMenu"))
            {
                dynamic Menu2 = p1;
                for (int i = 0; i < Menu2.MenuItems.Count; i++)
                {
                    ClMenuItem ClMenuItem1 = (ClMenuItem)MenuItems.Item(i);
                    int MergeOrder1 = ClMenuItem1.MergeOrder;
                    ClMenuItem ClMenuItem2 = (ClMenuItem)Menu2.MenuItems.Item(i);
                    int MergeType2 = ClMenuItem2.MergeType;
                    int MergeOrder2 = ClMenuItem2.MergeOrder;
                    ClMenuItem new_MenuItem = ClMenuItem2.CloneMenu();
                    if (MergeOrder1 == MergeOrder2)
                    {
                        if (MergeType2 == 0)//Добавить (Add)
                        {
                            MenuItems.Add(new_MenuItem);
                        }
                        if (MergeType2 == 1)//Заменить (Replace)
                        {
                            MenuItems.Add(new_MenuItem);
                            MenuItems.RemoveAt(i);
                            new_MenuItem.Index = i;
                        }
                        if (MergeType2 == 2)//ОбъединитьМеню (MergeItems)
                        {
                            MenuItems.Add(new_MenuItem);
                            new_MenuItem.Index = i + 1;
                        }
                        if (MergeType2 == 3)//Удалить (Remove)
                        {
                        }
                    }
                    else
                    {
                        MenuItems.Add(new_MenuItem);
                    }
                }
                //теперь нужно пройти по объединенному меню и построить рейтинг на основании текущего индекса меню и MergeOrder
                //рейтинг = индексМеню + (MergeOrder * 100000)
                //перестраиваем меню согласно рейтинга
                //заполняем СортированныйСписок. Ключом будет рейтинг, значением будет MenuItem
                //очищаем Menu и заполняем его из СортированныйСписок
                ClSortedList ClSortedList1 = new ClSortedList();
                for (int i = 0; i < MenuItems.Count; i++)
                {
                    ClMenuItem ClMenuItem1 = (ClMenuItem)MenuItems.Item(i);
                    int rating = ClMenuItem1.Index + (ClMenuItem1.MergeOrder * 100000);
                    ClSortedList1.Add(rating, ClMenuItem1.CloneMenu());
                }
                MenuItems.Clear();
                ClArrayList ClArrayList1 = ClSortedList1.Keys;
                for (int i = 0; i < ClArrayList1.Count; i++)
                {
                    int key1 = Convert.ToInt32(ClArrayList1.Item(i).AsNumber());
                    MenuItems.Add((ClMenuItem)ClSortedList1.Item(key1).Value);
                }
            }
        }
        
        [ContextMethod("ЭлементМеню", "MenuItem")]
        public ClMenuItem MenuItem(int p1)
        {
            return new ClMenuItem(Base_obj.MenuItems[p1]);
        }
        
        [ContextMethod("ЭлементыМеню", "MenuItems")]
        public ClMenuItem MenuItems2(int p1)
        {
            return (ClMenuItem)OneScriptForms.RevertObj(Base_obj.MenuItems[p1]);
        }
    }
}
