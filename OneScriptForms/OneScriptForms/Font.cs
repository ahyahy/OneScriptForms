using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class Font
    {
        public ClFont dll_obj;
        public System.Drawing.Font M_Font;

        public Font(osf.Font p1)
        {
            M_Font = p1.M_Font;
            OneScriptForms.AddToHashtable(M_Font, this);
        }

        public Font(string name = null, float size = 0.0f, System.Drawing.FontStyle style = System.Drawing.FontStyle.Regular)
        {
            M_Font = new System.Drawing.Font(name, size, style);
            OneScriptForms.AddToHashtable(M_Font, this);
        }

        public Font(System.Drawing.Font p1)
        {
            M_Font = p1;
            OneScriptForms.AddToHashtable(M_Font, this);
        }

        public int Height
        {
            get { return M_Font.Height; }
        }

        public string Name
        {
            get { return M_Font.Name; }
        }

        public float Size
        {
            get { return M_Font.Size; }
        }

        public int Style
        {
            get { return (int)M_Font.Style; }
        }
    }

    [ContextClass ("КлШрифт", "ClFont")]
    public class ClFont : AutoContext<ClFont>
    {
        public ClFont(string p1 = null, float p2 = 6.0f, int p3 = 0)
        {
            Font Font1 = new Font(p1, p2, (System.Drawing.FontStyle)p3);
            Font1.dll_obj = this;
            Base_obj = Font1;
        }
		
        public ClFont(Font p1)
        {
            Font Font1 = p1;
            Font1.dll_obj = this;
            Base_obj = Font1;
        }

        public Font Base_obj;
        
        [ContextProperty("Высота", "Height")]
        public int Height
        {
            get { return Base_obj.Height; }
        }

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
        }

        [ContextProperty("Размер", "Size")]
        public IValue Size
        {
            get { return ValueFactory.Create((Convert.ToDecimal(Base_obj.Size))); }
        }
        
        [ContextProperty("Стиль", "Style")]
        public int Style
        {
            get { return (int)Base_obj.Style; }
        }
        
    }
}
