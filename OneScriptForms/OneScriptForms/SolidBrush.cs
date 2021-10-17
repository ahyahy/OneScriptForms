using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class SolidBrush : Brush
    {
        public ClSolidBrush dll_obj;
        public System.Drawing.SolidBrush M_SolidBrush;

        public SolidBrush(osf.SolidBrush p1)
        {
            M_SolidBrush = p1.M_SolidBrush;
            base.M_Brush = M_SolidBrush;
            OneScriptForms.AddToHashtable(M_SolidBrush, this);
        }

        public SolidBrush(System.Drawing.Color p1)
        {
            M_SolidBrush = new System.Drawing.SolidBrush(p1);
            base.M_Brush = M_SolidBrush;
            OneScriptForms.AddToHashtable(M_SolidBrush, this);
        }

        public SolidBrush(System.Drawing.SolidBrush p1)
        {
            M_SolidBrush = p1;
            base.M_Brush = M_SolidBrush;
            OneScriptForms.AddToHashtable(M_SolidBrush, this);
        }

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлСплошнаяКисть", "ClSolidBrush")]
    public class ClSolidBrush : AutoContext<ClSolidBrush>
    {

        public ClSolidBrush(Color p1)
        {
            SolidBrush SolidBrush1 = new SolidBrush(p1.M_Color);
            SolidBrush1.dll_obj = this;
            Base_obj = SolidBrush1;
        }

        public SolidBrush Base_obj;

        //Свойства============================================================

        //Методы============================================================

    }
}
