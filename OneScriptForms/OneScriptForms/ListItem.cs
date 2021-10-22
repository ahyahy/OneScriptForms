using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class ListItem
    {
        public ClListItem dll_obj;
        private System.Drawing.Color M_ForeColor;
        private string M_Text;
        private object M_Value;

        public ListItem(osf.ListItem p1)
        {
            M_ForeColor = p1.M_ForeColor;
            M_Text = p1.M_Text;
            M_Value = p1.M_Value;
            OneScriptForms.AddToHashtable(this, this);
        }

        public ListItem(string text = null, object value = null)
        {
            M_ForeColor = new System.Drawing.Color();
            M_Text = text;
            M_Value = value;
            OneScriptForms.AddToHashtable(this, this);
        }

        public osf.Color ForeColor
        {
            get { return new Color(M_ForeColor); }
            set
            {
                M_ForeColor = value.M_Color;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public string Text
        {
            get
            {
                if (M_Text != null)
                {
                    return M_Text;
                }
                if (M_Value != null)
                {
                    return Convert.ToString(M_Value);
                }
                return "";
            }
            set
            {
                M_Text = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public object Value
        {
            get
            {
                if (M_Value != null)
                {
                    return M_Value;
                }
                if (M_Text != null)
                {
                    return M_Text;
                }
                return "";
            }
            set
            {
                M_Value = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public override string ToString()
        {
            return Text;
        }
    }

    [ContextClass ("КлЭлементСписка", "ClListItem")]
    public class ClListItem : AutoContext<ClListItem>
    {
        private ClColor foreColor;

        public ClListItem(string p1 = null, IValue p2 = null)
        {
            dynamic p3 = p2;
            if (p2 != null)
            {
                if (p2.GetType().ToString().Contains("osf."))
                {
                    p3 = ((dynamic)p2).Base_obj;
                }
            }
            ListItem ListItem1 = new ListItem(p1, p3);
            ListItem1.dll_obj = this;
            Base_obj = ListItem1;
            foreColor = new ClColor(Base_obj.ForeColor);
        }
		
        public ClListItem(ListItem p1)
        {
            ListItem ListItem1 = p1;
            ListItem1.dll_obj = this;
            Base_obj = ListItem1;
            foreColor = new ClColor(Base_obj.ForeColor);
        }

        public ListItem Base_obj;
        
        [ContextProperty("Значение", "Value")]
        public IValue Value
        {
            get
            {
                if (Base_obj.Value.GetType().ToString() == "ScriptEngine.Machine.SimpleConstantValue")
                {
                    if (((IValue)Base_obj.Value).SystemType.Name == "Число")
                    {
                        return (IValue)Base_obj.Value;
                    }
                }
                return OneScriptForms.RevertObj(Base_obj.Value);
            }
            set { Base_obj.Value = value; }
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

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }
        
        [ContextMethod("ВСтроку", "ToString")]
        public new string ToString()
        {
            return Base_obj.ToString();
        }
    }
}
