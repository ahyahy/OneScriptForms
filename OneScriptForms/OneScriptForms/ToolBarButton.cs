using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class ToolBarButtonEx : System.Windows.Forms.ToolBarButton
    {
        public osf.ToolBarButton M_Object;
    }

    public class ToolBarButton
    {
        public ClToolBarButton dll_obj;
        public ToolBarButtonEx M_ToolBarButton;

        public ToolBarButton(osf.ToolBarButton p1)
        {
            M_ToolBarButton = p1.M_ToolBarButton;
            M_ToolBarButton.M_Object = this;
        }

        public ToolBarButton(string text = null)
        {
            M_ToolBarButton = new ToolBarButtonEx();
            M_ToolBarButton.M_Object = this;
            M_ToolBarButton.Text = text;
        }

        public ToolBarButton(System.Windows.Forms.ToolBarButton p1)
        {
            M_ToolBarButton = (ToolBarButtonEx)p1;
            M_ToolBarButton.M_Object = this;
        }

        public osf.ContextMenu DropDownMenu
        {
            get { return (ContextMenu)((ContextMenuEx)M_ToolBarButton.DropDownMenu).M_Object; }
            set { M_ToolBarButton.DropDownMenu = value.M_ContextMenu; }
        }

        public bool Enabled
        {
            get { return M_ToolBarButton.Enabled; }
            set
            {
                M_ToolBarButton.Enabled = value;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public int ImageIndex
        {
            get { return M_ToolBarButton.ImageIndex; }
            set { M_ToolBarButton.ImageIndex = value; }
        }

        public bool PartialPush
        {
            get { return M_ToolBarButton.PartialPush; }
            set { M_ToolBarButton.PartialPush = value; }
        }

        public bool Pushed
        {
            get { return M_ToolBarButton.Pushed; }
            set { M_ToolBarButton.Pushed = value; }
        }

        public osf.Rectangle Rectangle
        {
            get { return new Rectangle(M_ToolBarButton.Rectangle); }
        }

        public int Style
        {
            get { return (int)M_ToolBarButton.Style; }
            set { M_ToolBarButton.Style = (System.Windows.Forms.ToolBarButtonStyle)value; }
        }

        public object Tag
        {
            get { return M_ToolBarButton.Tag; }
            set { M_ToolBarButton.Tag = value; }
        }

        public string Text
        {
            get { return M_ToolBarButton.Text; }
            set { M_ToolBarButton.Text = value; }
        }

        public string ToolTipText
        {
            get { return M_ToolBarButton.ToolTipText; }
            set { M_ToolBarButton.ToolTipText = value; }
        }

        public bool Visible
        {
            get { return M_ToolBarButton.Visible; }
            set { M_ToolBarButton.Visible = value; }
        }
    }

    [ContextClass ("КлКнопкаПанелиИнструментов", "ClToolBarButton")]
    public class ClToolBarButton : AutoContext<ClToolBarButton>
    {
        private ClCollection tag = new ClCollection();

        public ClToolBarButton(string p1 = null)
        {
            ToolBarButton ToolBarButton1 = new ToolBarButton(p1);
            ToolBarButton1.dll_obj = this;
            Base_obj = ToolBarButton1;
        }
		
        public ClToolBarButton(ToolBarButton p1)
        {
            ToolBarButton ToolBarButton1 = p1;
            ToolBarButton1.dll_obj = this;
            Base_obj = ToolBarButton1;
        }

        public ToolBarButton Base_obj;
        
        [ContextProperty("ВыпадающееМеню", "DropDownMenu")]
        public ClContextMenu DropDownMenu
        {
            get { return (ClContextMenu)OneScriptForms.RevertObj(Base_obj.DropDownMenu); }
            set { Base_obj.DropDownMenu = value.Base_obj; }
        }

        [ContextProperty("Доступность", "Enabled")]
        public bool Enabled
        {
            get { return Base_obj.Enabled; }
            set { Base_obj.Enabled = value; }
        }

        [ContextProperty("ИндексИзображения", "ImageIndex")]
        public int ImageIndex
        {
            get { return Base_obj.ImageIndex; }
            set { Base_obj.ImageIndex = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("Нажата", "Pushed")]
        public bool Pushed
        {
            get { return Base_obj.Pushed; }
            set { Base_obj.Pushed = value; }
        }

        [ContextProperty("НейтральноеПоложение", "PartialPush")]
        public bool PartialPush
        {
            get { return Base_obj.PartialPush; }
            set { Base_obj.PartialPush = value; }
        }

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
        }

        [ContextProperty("Прямоугольник", "Rectangle")]
        public ClRectangle Rectangle
        {
            get { return (ClRectangle)OneScriptForms.RevertObj(Base_obj.Rectangle); }
        }

        [ContextProperty("Стиль", "Style")]
        public int Style
        {
            get { return (int)Base_obj.Style; }
            set { Base_obj.Style = value; }
        }

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("ТекстПодсказки", "ToolTipText")]
        public string ToolTipText
        {
            get { return Base_obj.ToolTipText; }
            set { Base_obj.ToolTipText = value; }
        }
        
    }
}
