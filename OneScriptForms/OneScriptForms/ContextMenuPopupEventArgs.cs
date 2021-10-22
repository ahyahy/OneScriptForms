using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ContextMenuPopupEventArgs : EventArgs
    {
        public new ClContextMenuPopupEventArgs dll_obj;
        public osf.Point Point;

        public override bool PostEvent()
        {
            if (Sender.GetType() == typeof(osf.MenuNotifyIcon))
            {
                MenuNotifyIcon MenuNotifyIcon1 = (MenuNotifyIcon)Sender;
                foreach (MenuItem item in MenuNotifyIcon1.MenuItems)
                {
                    item.Visible = item.M_VisibleSaveState;
                }
                MenuNotifyIcon1.M_MenuNotifyIcon.Popup -= MenuNotifyIcon1.M_ContextMenu_Popup;
                MenuNotifyIcon1.Show((System.Windows.Forms.Control)MenuNotifyIcon1.M_MenuNotifyIcon.SourceControl, Point.M_Point);
                MenuNotifyIcon1.M_MenuNotifyIcon.Popup += MenuNotifyIcon1.M_ContextMenu_Popup;

            }
            else
            {
                ContextMenu ContextMenu1 = (ContextMenu)Sender;
                foreach (MenuItem item in ContextMenu1.MenuItems)
                {
                    item.Visible = item.M_VisibleSaveState;
                }
                ContextMenu1.M_ContextMenu.Popup -= ContextMenu1.M_ContextMenu_Popup;
                ContextMenu1.Show((System.Windows.Forms.Control)ContextMenu1.M_ContextMenu.SourceControl, Point.M_Point);
                ContextMenu1.M_ContextMenu.Popup += ContextMenu1.M_ContextMenu_Popup;
            }
            return true;
        }
    }

    [ContextClass ("КлКонтекстноеМенюПриПоявленииАрг", "ClContextMenuPopupEventArgs")]
    public class ClContextMenuPopupEventArgs : AutoContext<ClContextMenuPopupEventArgs>
    {
        public ClContextMenuPopupEventArgs()
        {
            ContextMenuPopupEventArgs ContextMenuPopupEventArgs1 = new ContextMenuPopupEventArgs();
            ContextMenuPopupEventArgs1.dll_obj = this;
            Base_obj = ContextMenuPopupEventArgs1;
        }
		
        public ClContextMenuPopupEventArgs(ContextMenuPopupEventArgs p1)
        {
            ContextMenuPopupEventArgs ContextMenuPopupEventArgs1 = p1;
            ContextMenuPopupEventArgs1.dll_obj = this;
            Base_obj = ContextMenuPopupEventArgs1;
        }
        
        public ContextMenuPopupEventArgs Base_obj;
        
        [ContextProperty("Отправитель", "Sender")]
        public IValue Sender
        {
            get { return OneScriptForms.RevertObj(Base_obj.Sender); }
        }
        
        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter
        {
            get { return (IValue)Base_obj.Parameter; }
        }

        [ContextProperty("Точка", "Point")]
        public ClPoint Point
        {
            get { return (ClPoint)OneScriptForms.RevertObj(Base_obj.Point); }
        }
        
    }
}
