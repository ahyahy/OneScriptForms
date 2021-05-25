namespace osf
{

    public class Brush : System.Drawing.Brush
    {
        public object M_Brush;

        //Свойства============================================================

        //Методы============================================================

        public override object Clone()
        {
            return (System.Drawing.Brush)Clone();
        }

    }

}
