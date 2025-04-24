using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class MessageBox
    {
        public int Buttons;
        public ClMessageBox dll_obj;
        public int Icon;
        public string Text;
        public string Title;

        public MessageBox()
        {
            Text = null;
            Title = null;
            Buttons = (int)System.Windows.Forms.MessageBoxButtons.OK;
            Icon = (int)System.Windows.Forms.MessageBoxIcon.None;
        }

        public int Show(string text = null, string title = null, int buttons = (int)System.Windows.Forms.MessageBoxButtons.OK, int icon = (int)System.Windows.Forms.MessageBoxIcon.None)
        {
            if (text == null)
            {
                text = Text;
            }
            if (title == null)
            {
                title = Title;
            }
            if (buttons == (int)System.Windows.Forms.MessageBoxButtons.OK)
            {
                buttons = Buttons;
            }
            if (icon == (int)System.Windows.Forms.MessageBoxIcon.None)
            {
                icon = Icon;
            }
            return (int)System.Windows.Forms.MessageBox.Show(text, title, (System.Windows.Forms.MessageBoxButtons)buttons, (System.Windows.Forms.MessageBoxIcon)icon);
        }
    }

    [ContextClass ("КлОкноСообщений", "ClMessageBox")]
    public class ClMessageBox : AutoContext<ClMessageBox>
    {
        public ClMessageBox()
        {
            MessageBox MessageBox1 = new MessageBox();
            MessageBox1.dll_obj = this;
            Base_obj = MessageBox1;
        }
		
        public ClMessageBox(MessageBox p1)
        {
            MessageBox MessageBox1 = p1;
            MessageBox1.dll_obj = this;
            Base_obj = MessageBox1;
        }
        
        public MessageBox Base_obj;
        
        [ContextProperty("Заголовок", "Title")]
        public string Title
        {
            get { return Base_obj.Title; }
            set { Base_obj.Title = value; }
        }

        [ContextProperty("Значок", "Icon")]
        public int Icon
        {
            get { return (int)Base_obj.Icon; }
            set { Base_obj.Icon = value; }
        }

        [ContextProperty("Кнопки", "Buttons")]
        public int Buttons
        {
            get { return (int)Base_obj.Buttons; }
            set { Base_obj.Buttons = value; }
        }

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }
        
        [ContextMethod("Показать", "Show")]
        public int Show(string text = null, string title = null, int buttons = 0, int icon = 0)
        {
            return Base_obj.Show(text, title, buttons, icon);
        }
    }
}
