using System;
using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class Icon
    {
        public ClIcon dll_obj;
        public System.Drawing.Icon M_Icon;

        public Icon(Bitmap bitmap)
        {
            M_Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)bitmap.M_Bitmap).GetHicon());
            OneScriptForms.AddToHashtable(M_Icon, this);
        }

        public Icon(System.Drawing.Icon p1)
        {
            M_Icon = p1;
            OneScriptForms.AddToHashtable(M_Icon, this);
        }

        public Icon(osf.Icon p1)
        {
            M_Icon = p1.M_Icon;
            OneScriptForms.AddToHashtable(M_Icon, this);
        }

        public Icon(string p1)
        {
            M_Icon = null;
            try
            {
                System.Drawing.Bitmap Bitmap = new System.Drawing.Bitmap((System.IO.Stream)new System.IO.MemoryStream(Convert.FromBase64String(p1)));
                IntPtr Hicon = Bitmap.GetHicon();
                System.Drawing.Icon Icon1 = System.Drawing.Icon.FromHandle(Hicon);
                M_Icon = Icon1;
            }
            catch
            {
            }
            try
            {
                M_Icon = new System.Drawing.Icon((System.IO.Stream)new System.IO.MemoryStream(Convert.FromBase64String(p1)));
            }
            catch
            {
            }
            if (M_Icon == null)
            {
                M_Icon = new System.Drawing.Icon(p1);
            }
            OneScriptForms.AddToHashtable(M_Icon, this);
        }

        public Icon(string p1, int p2)
        {
            M_Icon = ExtractIconClass.GetIconFromExeDll(p2, p1);
            OneScriptForms.AddToHashtable(M_Icon, this);
        }

        //Свойства============================================================

        public int Height
        {
            get { return M_Icon.Height; }
        }

        public osf.Size Size
        {
            get { return new Size(M_Icon.Size); }
        }

        public int Width
        {
            get { return M_Icon.Width; }
        }

        //Методы============================================================

        public osf.Bitmap ToBitmap()
        {
            return new Bitmap(M_Icon.ToBitmap());
        }

    }

    [ContextClass ("КлЗначок", "ClIcon")]
    public class ClIcon : AutoContext<ClIcon>
    {

    public ClIcon(string p1)
        {
            Icon Icon1 = new Icon(p1);
            Icon1.dll_obj = this;
            Base_obj = Icon1;
        }

        public ClIcon(string p1, int p2)
        {
            Icon Icon1 = new Icon(p1, p2);
            Icon1.dll_obj = this;
            Base_obj = Icon1;
        }

        public ClIcon(Icon p1)
        {
            Icon Icon1 = p1;
            Icon1.dll_obj = this;
            Base_obj = Icon1;
        }

        public Icon Base_obj;

        //Свойства============================================================

        [ContextProperty("Высота", "Height")]
        public int Height
        {
            get { return Base_obj.Height; }
        }

        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
        }

        //Методы============================================================

        [ContextMethod("ВКартинку", "ToBitmap")]
        public ClBitmap ToBitmap()
        {
            return new ClBitmap(Base_obj.ToBitmap());
        }
    }
}
