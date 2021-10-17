using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ContextMenuEx : System.Windows.Forms.ContextMenu
    {
        public object M_Object;
    }

    public class ContextMenu : Menu
    {
        public new ClContextMenu dll_obj;
        public ContextMenuEx M_ContextMenu;
        public string Popup;

        public ContextMenu()
        {
            M_ContextMenu = new ContextMenuEx();
            M_ContextMenu.M_Object = this;
            base.M_Menu = M_ContextMenu;
            M_ContextMenu.Popup += M_ContextMenu_Popup;
            Popup = "";
        }

        public ContextMenu(osf.ContextMenu p1)
        {
            M_ContextMenu = p1.M_ContextMenu;
            M_ContextMenu.M_Object = this;
            base.M_Menu = M_ContextMenu;
            M_ContextMenu.Popup += M_ContextMenu_Popup;
            Popup = "";
        }

        public ContextMenu(System.Windows.Forms.ContextMenu p1)
        {
            M_ContextMenu = (ContextMenuEx)p1;
            M_ContextMenu.M_Object = this;
            base.M_Menu = M_ContextMenu;
            M_ContextMenu.Popup += M_ContextMenu_Popup;
            Popup = "";
        }

        //Свойства============================================================

        public osf.Control SourceControl
        {
            get { return (osf.Control)((dynamic)M_ContextMenu.SourceControl).M_Object; }
        }

        //Методы============================================================

        public void M_ContextMenu_Popup(object sender, System.EventArgs e)
        {
            if (M_ContextMenu.SourceControl != null)
            {
                foreach (MenuItemEx itemEx in M_ContextMenu.MenuItems)
                {
                    MenuItem item = (MenuItem)itemEx.M_Object;
                    item.M_VisibleSaveState = item.Visible;
                    item.M_MenuItem.Visible = false;
                }
                ContextMenuPopupEventArgs ContextMenuPopupEventArgs1 = new ContextMenuPopupEventArgs();
                ContextMenuPopupEventArgs1.EventString = Popup;
                ContextMenuPopupEventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.Popup;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    ContextMenuPopupEventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    ContextMenuPopupEventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    ContextMenuPopupEventArgs1.Parameter = null;
                }
                ContextMenuPopupEventArgs1.Point = new Point(M_ContextMenu.SourceControl.PointToClient(System.Windows.Forms.Control.MousePosition));
                OneScriptForms.EventQueue.Add(ContextMenuPopupEventArgs1);
                ClContextMenuPopupEventArgs ClContextMenuPopupEventArgs1 = new ClContextMenuPopupEventArgs(ContextMenuPopupEventArgs1);
            }
        }

        public void Show(System.Windows.Forms.Control p1, System.Drawing.Point p2)
        {
            M_ContextMenu.Show(p1, p2);
        }

    }

    [ContextClass ("КлКонтекстноеМеню", "ClContextMenu")]
    public class ClContextMenu : AutoContext<ClContextMenu>
    {
        private IValue _Popup;
        private ClMenuItemCollection menuItems;

        public ClContextMenu()
        {
            ContextMenu ContextMenu1 = new ContextMenu();
            ContextMenu1.dll_obj = this;
            Base_obj = ContextMenu1;
            menuItems = new ClMenuItemCollection(Base_obj.MenuItems);
        }
		
        public ClContextMenu(ContextMenu p1)
        {
            ContextMenu ContextMenu1 = p1;
            ContextMenu1.dll_obj = this;
            Base_obj = ContextMenu1;
            menuItems = new ClMenuItemCollection(Base_obj.MenuItems);
        }
        
        public ContextMenu Base_obj;

        //Свойства============================================================

        [ContextProperty("Источник", "SourceControl")]
        public IValue SourceControl
        {
            get { return OneScriptForms.RevertObj(Base_obj.SourceControl); }
        }
        
        [ContextProperty("ПриПоявлении", "Popup")]
        public IValue Popup
        {
            get
            {
                if (Base_obj.Popup.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Popup;
                }
                else if (Base_obj.Popup.Contains("osf.ClDictionaryEntry"))
                {
                    return _Popup;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Popup);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Popup = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Popup = "ScriptEngine.HostedScript.Library.DelegateAction" + "Popup";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Popup = value;
                    Base_obj.Popup = "osf.ClDictionaryEntry" + "Popup";
                }
                else
                {
                    Base_obj.Popup = value.AsString();
                }
            }
        }
        
        [ContextProperty("ЭлементыМеню", "MenuItems")]
        public ClMenuItemCollection MenuItems
        {
            get { return menuItems; }
        }

        //Методы============================================================

        [ContextMethod("КлонироватьМеню", "CloneMenu")]
        public ClContextMenu CloneMenu()
        {
            ContextMenu ContextMenu1 = new ContextMenu();

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

                ContextMenu1.MenuItems.Add(MenuItem1);
                if (CurrentMenuItem1.MenuItems.Count > 0)
                {
                    BypassContextMenu(MenuItem1, CurrentMenuItem1.MenuItems);
                }
            }
            return new ClContextMenu(ContextMenu1);
        }

        public void BypassContextMenu(MenuItem ContextMenu, MenuItemCollection MenuItems)
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

                ContextMenu.MenuItems.Add(MenuItem1);
                if (CurrentMenuItem1.MenuItems.Count > 0)
                {
                    BypassContextMenu(MenuItem1, CurrentMenuItem1.MenuItems);
                }
            }
        }

        [ContextMethod("Показать", "Show")]
        public void Show(IValue p1, ClPoint p2)
        {
            Control Control1 = (Control)((dynamic)p1).Base_obj;
            Point Point1 = new Point(Control1.ClientRectangle.X + p2.Base_obj.X, Control1.ClientRectangle.Y + p2.Base_obj.Y);
            Point Point2 = Control1.PointToScreen(Point1);
            Cursor Cursor1 = new Cursor();
            Cursor1.Current.Position = Point2;
            Base_obj.Show(Control1.M_Control, Point2.M_Point);
        }
        
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
    }
}
