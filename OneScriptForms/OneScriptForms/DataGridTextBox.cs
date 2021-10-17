using System;
using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class DataGridTextBox : TextBox
    {
        public new ClDataGridTextBox dll_obj;
        public System.Windows.Forms.DataGridTextBox M_DataGridTextBox;

        public DataGridTextBox()
        {
            M_DataGridTextBox = new System.Windows.Forms.DataGridTextBox();
            base.M_Control = M_DataGridTextBox;
        }

        public DataGridTextBox(osf.DataGridTextBox p1)
        {
            M_DataGridTextBox = p1.M_DataGridTextBox;
            base.M_Control = M_DataGridTextBox;
        }

        public DataGridTextBox(System.Windows.Forms.DataGridTextBox p1)
        {
            M_DataGridTextBox = p1;
            base.M_Control = M_DataGridTextBox;
        }

        public DataGridTextBox(System.Windows.Forms.TextBox p1)
        {
            M_DataGridTextBox = (System.Windows.Forms.DataGridTextBox)p1;
            base.M_Control = M_DataGridTextBox;
        }

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлПолеВводаКолонки", "ClDataGridTextBox")]
    public class ClDataGridTextBox : AutoContext<ClDataGridTextBox>
    {
        private ClColor backColor;
        private ClColor foreColor;
        private ClCollection tag = new ClCollection();

        public ClDataGridTextBox()
        {
            DataGridTextBox DataGridTextBox1 = new DataGridTextBox();
            DataGridTextBox1.dll_obj = this;
            Base_obj = DataGridTextBox1;
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
        }
		
        public ClDataGridTextBox(DataGridTextBox p1)
        {
            DataGridTextBox DataGridTextBox1 = p1;
            DataGridTextBox1.dll_obj = this;
            Base_obj = DataGridTextBox1;
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
        }
        
        public DataGridTextBox Base_obj;

        //Свойства============================================================

        [ContextProperty("ВысотаШрифта", "FontHeight")]
        public int FontHeight
        {
            get { return Convert.ToInt32(Base_obj.FontHeight); }
        }
        
        [ContextProperty("ДвойнаяБуферизация", "DoubleBuffered")]
        public bool DoubleBuffered
        {
            get { return Base_obj.DoubleBuffered; }
            set { Base_obj.DoubleBuffered = value; }
        }

        [ContextProperty("ЖирныйШрифт", "FontBold")]
        public bool FontBold
        {
            get { return Base_obj.FontBold; }
            set { Base_obj.FontBold = value; }
        }

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
            set { Base_obj.Name = value; }
        }

        [ContextProperty("ИмяШрифта", "FontName")]
        public string FontName
        {
            get { return Base_obj.FontName; }
            set { Base_obj.FontName = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("ОсновнойЦвет", "ForeColor")]
        public ClColor ForeColor
        {
            get { return foreColor; }
            set 
            {
                foreColor = value;
                Base_obj.ForeColor = value.Base_obj;
            }
        }

        [ContextProperty("РазмерШрифта", "FontSize")]
        public int FontSize
        {
            get { return Convert.ToInt32(Base_obj.FontSize); }
            set { Base_obj.FontSize = value; }
        }
        
        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("ФоновоеИзображение", "BackgroundImage")]
        public ClBitmap BackgroundImage
        {
            get { return new ClBitmap(Base_obj.BackgroundImage); }
            set { Base_obj.BackgroundImage = value.Base_obj; }
        }

        [ContextProperty("ЦветФона", "BackColor")]
        public ClColor BackColor
        {
            get { return backColor; }
            set 
            {
                backColor = value;
                Base_obj.BackColor = value.Base_obj;
            }
        }

        [ContextProperty("Шрифт", "Font")]
        public ClFont Font
        {
            get { return (ClFont)OneScriptForms.RevertObj(Base_obj.Font); }
            set 
            {
                Base_obj.Font = value.Base_obj; 
                Base_obj.Font.dll_obj = value;
            }
        }

        //Методы============================================================

    }
}
