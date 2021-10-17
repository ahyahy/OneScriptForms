using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class Point
    {
        public ClPoint dll_obj;
        public System.Drawing.Point M_Point;

        public Point(int x = 0, int y = 0)
        {
            M_Point = new System.Drawing.Point(x, y);
        }

        public Point(osf.Point p1)
        {
            M_Point = p1.M_Point;
        }

        public Point(System.Drawing.Point p1)
        {
            M_Point = p1;
        }

        //Свойства============================================================

        public int X
        {
            get { return M_Point.X; }
            set { M_Point.X = value; }
        }

        public int Y
        {
            get { return M_Point.Y; }
            set { M_Point.Y = value; }
        }

        //Методы============================================================

    }

    [ContextClass ("КлТочка", "ClPoint")]
    public class ClPoint : AutoContext<ClPoint>
    {

        public ClPoint(int x, int y)
        {
            Point Point1 = new Point(x, y);
            Point1.dll_obj = this;
            Base_obj = Point1;
        }

        public ClPoint(Point p1)
        {
            Point Point1 = p1;
            Point1.dll_obj = this;
            Base_obj = Point1;
        }
		
        public ClPoint(System.Drawing.Point p1)
        {
            Point Point1 = new Point(p1);
            Point1.dll_obj = this;
            Base_obj = Point1;
        }

        public Point Base_obj;

        //Свойства============================================================

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

        //Методы============================================================

    }
}
