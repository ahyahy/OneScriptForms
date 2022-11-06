using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class StatusBarPanelEx : System.Windows.Forms.StatusBarPanel
    {
        public osf.StatusBarPanel M_Object;
    }

    public class StatusBarPanel : Component
    {
        public ClStatusBarPanel dll_obj;
        public StatusBarPanelEx M_StatusBarPanel;

        public StatusBarPanel(osf.StatusBarPanel p1)
        {
            M_StatusBarPanel = p1.M_StatusBarPanel;
            M_StatusBarPanel.M_Object = this;
            base.M_Component = M_StatusBarPanel;
        }

        public StatusBarPanel(string text = null)
        {
            M_StatusBarPanel = new StatusBarPanelEx();
            M_StatusBarPanel.M_Object = this;
            base.M_Component = M_StatusBarPanel;
            if (text != null)
            {
                M_StatusBarPanel.Text = text;
            }
        }

        public StatusBarPanel(System.Windows.Forms.StatusBarPanel p1)
        {
            M_StatusBarPanel = (StatusBarPanelEx)p1;
            M_StatusBarPanel.M_Object = this;
            base.M_Component = M_StatusBarPanel;
        }

        public int AutoSize
        {
            get { return (int)M_StatusBarPanel.AutoSize; }
            set { M_StatusBarPanel.AutoSize = (System.Windows.Forms.StatusBarPanelAutoSize)value; }
        }

        public int BorderStyle
        {
            get { return (int)M_StatusBarPanel.BorderStyle; }
            set { M_StatusBarPanel.BorderStyle = (System.Windows.Forms.StatusBarPanelBorderStyle)value; }
        }

        public osf.Icon Icon
        {
            get { return new Icon(M_StatusBarPanel.Icon); }
            set { M_StatusBarPanel.Icon = (System.Drawing.Icon)value.M_Icon; }
        }

        public int MinWidth
        {
            get { return M_StatusBarPanel.MinWidth; }
            set { M_StatusBarPanel.MinWidth = value; }
        }

        public string Text
        {
            get { return M_StatusBarPanel.Text; }
            set { M_StatusBarPanel.Text = value; }
        }

        public int Width
        {
            get { return M_StatusBarPanel.Width; }
            set { M_StatusBarPanel.Width = value; }
        }
    }

    [ContextClass ("КлПанельСтрокиСостояния", "ClStatusBarPanel")]
    public class ClStatusBarPanel : AutoContext<ClStatusBarPanel>
    {
        public ClIcon icon;

        public ClStatusBarPanel()
        {
            StatusBarPanel StatusBarPanel1 = new StatusBarPanel();
            StatusBarPanel1.dll_obj = this;
            Base_obj = StatusBarPanel1;
        }
		
        public ClStatusBarPanel(StatusBarPanel p1)
        {
            StatusBarPanel StatusBarPanel1 = p1;
            StatusBarPanel1.dll_obj = this;
            Base_obj = StatusBarPanel1;
        }
        
        public StatusBarPanel Base_obj;
        
        [ContextProperty("АвтоРазмер", "AutoSize")]
        public int AutoSize
        {
            get { return (int)Base_obj.AutoSize; }
            set { Base_obj.AutoSize = value; }
        }

        [ContextProperty("Значок", "Icon")]
        public ClIcon Icon
        {
            get { return icon; }
            set 
            {
                icon = value;
                Base_obj.Icon = value.Base_obj;
            }
        }
        
        [ContextProperty("МинимальнаяШирина", "MinWidth")]
        public int MinWidth
        {
            get { return Base_obj.MinWidth; }
            set { Base_obj.MinWidth = value; }
        }

        [ContextProperty("СтильГраницы", "BorderStyle")]
        public int BorderStyle
        {
            get { return (int)Base_obj.BorderStyle; }
            set { Base_obj.BorderStyle = value; }
        }

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }
        
        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
            set { Base_obj.Width = value; }
        }
        
        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
    }
}
