using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class HatchBrush : Brush
    {
        public ClHatchBrush dll_obj;
        public System.Drawing.Drawing2D.HatchBrush M_HatchBrush;

        public HatchBrush(System.Drawing.Drawing2D.HatchBrush p1)
        {
            M_HatchBrush = p1;
            base.M_Brush = M_HatchBrush;
            OneScriptForms.AddToHashtable(M_HatchBrush, this);
        }

        public HatchBrush(int hatchStyle, osf.Color foreColor, osf.Color backColor = null)
        {
            if (backColor != null)
            {
                M_HatchBrush = new System.Drawing.Drawing2D.HatchBrush((System.Drawing.Drawing2D.HatchStyle)hatchStyle, foreColor.M_Color, backColor.M_Color);
                base.M_Brush = M_HatchBrush;
                OneScriptForms.AddToHashtable(M_HatchBrush, this);
            }
            else
            {
                M_HatchBrush = new System.Drawing.Drawing2D.HatchBrush((System.Drawing.Drawing2D.HatchStyle)hatchStyle, foreColor.M_Color);
                base.M_Brush = M_HatchBrush;
                OneScriptForms.AddToHashtable(M_HatchBrush, this);
            }
        }

        public HatchBrush(osf.HatchBrush p1)
        {
            M_HatchBrush = p1.M_HatchBrush;
            base.M_Brush = M_HatchBrush;
            OneScriptForms.AddToHashtable(M_HatchBrush, this);
        }

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлПрямоугольнаяКисть", "ClHatchBrush")]
    public class ClHatchBrush : AutoContext<ClHatchBrush>
    {

        public ClHatchBrush(int p1, osf.Color p2, osf.Color p3 = null)
        {
            HatchBrush HatchBrush1 = new HatchBrush(p1, p2, p3);
            HatchBrush1.dll_obj = this;
            Base_obj = HatchBrush1;
        }
		
        public ClHatchBrush(HatchBrush p1)
        {
            HatchBrush HatchBrush1 = p1;
            HatchBrush1.dll_obj = this;
            Base_obj = HatchBrush1;
        }

        public HatchBrush Base_obj;

        //Свойства============================================================

        //Методы============================================================

    }
}
