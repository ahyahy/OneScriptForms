using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class Rectangle
    {
        public ClRectangle dll_obj;
        public System.Drawing.Rectangle M_Rectangle;

        public Rectangle(int x = 0, int y = 0, int width = 0, int height = 0)
        {
            M_Rectangle = new System.Drawing.Rectangle();
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Rectangle(osf.Rectangle p1)
        {
            M_Rectangle = p1.M_Rectangle;
            X = p1.X;
            Y = p1.Y;
            Width = p1.Width;
            Height = p1.Height;
        }

        public Rectangle(System.Drawing.Rectangle p1)
        {
            M_Rectangle = p1;
            X = p1.X;
            Y = p1.Y;
            Width = p1.Width;
            Height = p1.Height;
        }

        //Свойства============================================================

        public int Bottom
        {
            get { return M_Rectangle.Bottom; }
        }

        public int Height
        {
            get { return M_Rectangle.Height; }
            set { M_Rectangle.Height = value; }
        }

        public int Left
        {
            get { return M_Rectangle.Left; }
        }

        public osf.Point Location
        {
            get { return new Point(M_Rectangle.Location); }
            set { M_Rectangle.Location = value.M_Point; }
        }

        public int Right
        {
            get { return M_Rectangle.Right; }
        }

        public osf.Size Size
        {
            get { return new Size(M_Rectangle.Size); }
            set { M_Rectangle.Size = value.M_Size; }
        }

        public int Top
        {
            get { return M_Rectangle.Top; }
        }

        public int Width
        {
            get { return M_Rectangle.Width; }
            set { M_Rectangle.Width = value; }
        }

        public int X
        {
            get { return M_Rectangle.X; }
            set { M_Rectangle.X = value; }
        }

        public int Y
        {
            get { return M_Rectangle.Y; }
            set { M_Rectangle.Y = value; }
        }

        //Методы============================================================

        public osf.Rectangle FromSize(Size Size)
        {
            return new Rectangle(new System.Drawing.Rectangle(0, 0, Size.Width, Size.Height));
        }

    }

    [ContextClass ("КлПрямоугольник", "ClRectangle")]
    public class ClRectangle : AutoContext<ClRectangle>
    {

        public ClRectangle(int x = 0, int y = 0, int width = 0, int height = 0)
        {
            Rectangle Rectangle1 = new Rectangle(x, y, width, height);
            Rectangle1.dll_obj = this;
            Base_obj = Rectangle1;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
		
        public ClRectangle(Rectangle p1)
        {
            Rectangle Rectangle1 = p1;
            Rectangle1.dll_obj = this;
            Base_obj = Rectangle1;
        }

        public Rectangle Base_obj;

        //Свойства============================================================

        [ContextProperty("Верх", "Top")]
        public int Top
        {
            get { return Base_obj.Top; }
        }

        [ContextProperty("Высота", "Height")]
        public int Height
        {
            get { return Base_obj.Height; }
            set { Base_obj.Height = value; }
        }

        [ContextProperty("Игрек", "Y")]
        public int Y
        {
            get { return Base_obj.Y; }
            set { Base_obj.Y = value; }
        }

        [ContextProperty("Икс", "X")]
        public int X
        {
            get { return Base_obj.X; }
            set { Base_obj.X = value; }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
            get { return Base_obj.Left; }
        }

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
            get { return Base_obj.Bottom; }
        }

        [ContextProperty("Положение", "Location")]
        public ClPoint Location
        {
            get { return (ClPoint)OneScriptForms.RevertObj(Base_obj.Location); }
            set { Base_obj.Location = value.Base_obj; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
            get { return Base_obj.Right; }
        }

        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
            set { Base_obj.Size = value.Base_obj; }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
            set { Base_obj.Width = value; }
        }

        //Методы============================================================

    }
}
