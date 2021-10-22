namespace osf
{
    public class Brush : System.Drawing.Brush
    {
        public object M_Brush;

        public override object Clone()
        {
            return (System.Drawing.Brush)Clone();
        }
    }
}
