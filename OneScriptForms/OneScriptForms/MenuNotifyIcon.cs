using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class MenuNotifyIcon : Menu
    {
        public new ClMenuNotifyIcon dll_obj;
        public ContextMenuEx M_MenuNotifyIcon;
        public string Popup;

        public MenuNotifyIcon()
        {
            M_MenuNotifyIcon = new ContextMenuEx();
            M_MenuNotifyIcon.M_Object = this;
            base.M_Menu = M_MenuNotifyIcon;
            M_MenuNotifyIcon.Popup += M_ContextMenu_Popup;
            Popup = "";
            OneScriptForms.AddToHashtable(M_MenuNotifyIcon, this);
        }

        public MenuNotifyIcon(osf.MenuNotifyIcon p1)
        {
            M_MenuNotifyIcon = p1.M_MenuNotifyIcon;
            M_MenuNotifyIcon.M_Object = this;
            base.M_Menu = M_MenuNotifyIcon;
            M_MenuNotifyIcon.Popup += M_ContextMenu_Popup;
            Popup = "";
            OneScriptForms.AddToHashtable(M_MenuNotifyIcon, this);
        }

        public MenuNotifyIcon(System.Windows.Forms.ContextMenu p1)
        {
            M_MenuNotifyIcon = (ContextMenuEx)p1;
            M_MenuNotifyIcon.M_Object = this;
            base.M_Menu = M_MenuNotifyIcon;
            M_MenuNotifyIcon.Popup += M_ContextMenu_Popup;
            Popup = "";
            OneScriptForms.AddToHashtable(M_MenuNotifyIcon, this);
        }

        public osf.Control SourceControl
        {
            get { return (osf.Control)((dynamic)M_MenuNotifyIcon.SourceControl).M_Object; }
        }

        public void M_ContextMenu_Popup(object sender, System.EventArgs e)
        {
            if (M_MenuNotifyIcon.SourceControl != null)
            {
                foreach (MenuItemEx itemEx in M_MenuNotifyIcon.MenuItems)
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
                ContextMenuPopupEventArgs1.Point = new Point(M_MenuNotifyIcon.SourceControl.PointToClient(System.Windows.Forms.Control.MousePosition));
                OneScriptForms.EventQueue.Add(ContextMenuPopupEventArgs1);
                ClContextMenuPopupEventArgs ClContextMenuPopupEventArgs1 = new ClContextMenuPopupEventArgs(ContextMenuPopupEventArgs1);
            }
        }

        public void Show(System.Windows.Forms.Control p1, System.Drawing.Point p2)
        {
            M_MenuNotifyIcon.Show(p1, p2);
        }
    }

    [ContextClass ("КлМенюЗначкаУведомления", "ClMenuNotifyIcon")]
    public class ClMenuNotifyIcon : AutoContext<ClMenuNotifyIcon>
    {
        private IValue _Popup;
        private bool firstShow;
        private ClMenuItemCollection menuItems;
        private ClNotifyIcon notifyIcon;

        public ClMenuNotifyIcon()
        {
            MenuNotifyIcon MenuNotifyIcon1 = new MenuNotifyIcon();
            MenuNotifyIcon1.dll_obj = this;
            Base_obj = MenuNotifyIcon1;
            firstShow = true;
            notifyIcon = null;
            menuItems = new ClMenuItemCollection(Base_obj.MenuItems);
        }
		
        public void Show(ClUserControl p1, ClPoint p2)
        {
            Base_obj.Show(p1.Base_obj.M_UserControl, p2.Base_obj.M_Point);
        }

        public MenuNotifyIcon Base_obj;
        
        [ContextProperty("ЗначокУведомления", "NotifyIcon")]
        public ClNotifyIcon NotifyIcon
        {
            get { return notifyIcon; }
            set { notifyIcon = value; }
        }
        
        [ContextProperty("ПервыйПоказ", "FirstShow")]
        public bool FirstShow
        {
            get { return firstShow; }
            set { firstShow = value; }
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
        
        [ContextMethod("ПолучитьГлавноеМеню", "GetMainMenu")]
        public ClMainMenu GetMainMenu()
        {
            return (ClMainMenu)OneScriptForms.RevertObj(Base_obj.GetMainMenu());
        }
        
        [ContextMethod("ЭлементМеню", "MenuItem")]
        public ClMenuItem MenuItem(int p1)
        {
            return new ClMenuItem(Base_obj.MenuItems[p1]);
        }
    }
}
