using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class Size
    {
        public ClSize dll_obj;
        public System.Drawing.Size M_Size;

        public Size(int width = 0, int height = 0)
        {
            M_Size = new System.Drawing.Size(width, height);
        }

        public Size(osf.Size p1)
        {
            M_Size = p1.M_Size;
        }

        public Size(System.Drawing.Size p1)
        {
            M_Size = p1;
        }

        public int Height
        {
            get { return M_Size.Height; }
            set { M_Size.Height = value; }
        }

        public int Width
        {
            get { return M_Size.Width; }
            set { M_Size.Width = value; }
        }
    }

    [ContextClass("КлРазмер", "ClSize")]
    public class ClSize : AutoContext<ClSize>
    {
        public ClSize(int width, int height)
        {
            Size Size1 = new Size(width, height);
            Size1.dll_obj = this;
            Base_obj = Size1;
        }

        public ClSize(Size p1)
        {
            Size Size1 = p1;
            Size1.dll_obj = this;
            Base_obj = Size1;
        }

        public ClSize(System.Drawing.Size p1)
        {
            Size Size1 = new Size(p1);
            Size1.dll_obj = this;
            Base_obj = Size1;
        }

        public Size Base_obj;

        [ContextProperty("Высота", "Height")]
        public int Height
        {
            get { return Base_obj.Height; }
            set { Base_obj.Height = value; }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
            set { Base_obj.Width = value; }
        }

    }
}
