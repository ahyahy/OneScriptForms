using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class MainMenuEx : System.Windows.Forms.MainMenu
    {
        public osf.MainMenu M_Object;
    }

    public class MainMenu : Menu
    {
        public new ClMainMenu dll_obj;
        public MainMenuEx M_MainMenu;

        public MainMenu()
        {
            M_MainMenu = new MainMenuEx();
            M_MainMenu.M_Object = this;
            base.M_Menu = M_MainMenu;
            System.Windows.Forms.Application.DoEvents();
        }

        public MainMenu(System.Windows.Forms.MainMenu MainMenu)
        {
            M_MainMenu = (MainMenuEx)MainMenu;
            M_MainMenu.M_Object = this;
            base.M_Menu = M_MainMenu;
            System.Windows.Forms.Application.DoEvents();
        }

        public MainMenu(osf.MainMenu p1)
        {
            M_MainMenu = p1.M_MainMenu;
            M_MainMenu.M_Object = this;
            base.M_Menu = M_MainMenu;
            System.Windows.Forms.Application.DoEvents();
        }

        //Свойства============================================================

        //Методы============================================================

        public osf.Form GetForm()
        {
            return (osf.Form)((FormEx)M_MainMenu.GetForm()).M_Object;
        }

    }

    [ContextClass ("КлГлавноеМеню", "ClMainMenu")]
    public class ClMainMenu : AutoContext<ClMainMenu>
    {
        private ClMenuItemCollection menuItems;

        public ClMainMenu()
        {
            MainMenu MainMenu1 = new MainMenu();
            MainMenu1.dll_obj = this;
            Base_obj = MainMenu1;
            menuItems = new ClMenuItemCollection(Base_obj.MenuItems);
        }
		
        public ClMainMenu(MainMenu p1)
        {
            MainMenu MainMenu1 = p1;
            MainMenu1.dll_obj = this;
            Base_obj = MainMenu1;
            menuItems = new ClMenuItemCollection(Base_obj.MenuItems);
        }
        
        public MainMenu Base_obj;

        //Свойства============================================================

        [ContextProperty("ЭлементыМеню", "MenuItems")]
        public ClMenuItemCollection MenuItems
        {
            get { return menuItems; }
        }

        //Методы============================================================

        [ContextMethod("КлонироватьМеню", "CloneMenu")]
        public ClMainMenu CloneMenu()
       {
            MainMenu MainMenu1 = new MainMenu();

            for (int i = 0; i < Base_obj.MenuItems.Count; i++)
            {
                MenuItem CurrentMenuItem1 = Base_obj.MenuItems[i];
                MenuItem MenuItem1 = new MenuItem();

                MenuItem1.Enabled = CurrentMenuItem1.Enabled;
                MenuItem1.Name = CurrentMenuItem1.Name;
                MenuItem1.Index = CurrentMenuItem1.Index;
                MenuItem1.Click = CurrentMenuItem1.Click;
                MenuItem1.Visible = CurrentMenuItem1.Visible;
                MenuItem1.RadioCheck = CurrentMenuItem1.RadioCheck;
                MenuItem1.Checked = CurrentMenuItem1.Checked;
                MenuItem1.MergeOrder = CurrentMenuItem1.MergeOrder;
                MenuItem1.Shortcut = (int)CurrentMenuItem1.Shortcut;
                MenuItem1.Text = CurrentMenuItem1.Text;
                MenuItem1.MergeType = (int)CurrentMenuItem1.MergeType;

                MainMenu1.MenuItems.Add(MenuItem1);
                if (CurrentMenuItem1.MenuItems.Count > 0)
                {
                    BypassMainMenu(MenuItem1, CurrentMenuItem1.MenuItems);
                }
            }
            return new ClMainMenu(MainMenu1);
        }

        public void BypassMainMenu(MenuItem MainMenu, MenuItemCollection MenuItems)
        {
            for (int i = 0; i < MenuItems.Count; i++)
            {
                MenuItem CurrentMenuItem1 = MenuItems[i];
                MenuItem MenuItem1 = new MenuItem();

                MenuItem1.Enabled = CurrentMenuItem1.Enabled;
                MenuItem1.Name = CurrentMenuItem1.Name;
                MenuItem1.Index = CurrentMenuItem1.Index;
                MenuItem1.Click = CurrentMenuItem1.Click;
                MenuItem1.Visible = CurrentMenuItem1.Visible;
                MenuItem1.RadioCheck = CurrentMenuItem1.RadioCheck;
                MenuItem1.Checked = CurrentMenuItem1.Checked;
                MenuItem1.MergeOrder = CurrentMenuItem1.MergeOrder;
                MenuItem1.Shortcut = (int)CurrentMenuItem1.Shortcut;
                MenuItem1.Text = CurrentMenuItem1.Text;
                MenuItem1.MergeType = (int)CurrentMenuItem1.MergeType;

                MainMenu.MenuItems.Add(MenuItem1);
                if (CurrentMenuItem1.MenuItems.Count > 0)
                {
                    BypassMainMenu(MenuItem1, CurrentMenuItem1.MenuItems);
                }
            }
        }
        
        [ContextMethod("ПолучитьГлавноеМеню", "GetMainMenu")]
        public ClMainMenu GetMainMenu()
        {
            return (ClMainMenu)OneScriptForms.RevertObj(Base_obj.GetMainMenu());
        }
        
        [ContextMethod("ПолучитьФорму", "GetForm")]
        public ClForm GetForm()
        {
            return Base_obj.GetForm().dll_obj;
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
    }
}
