using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class Pen
    {
        public ClPen dll_obj;
        public System.Drawing.Pen M_Pen;

        public Pen(osf.Pen p1)
        {
            M_Pen = p1.M_Pen;
            OneScriptForms.AddToHashtable(M_Pen, this);
        }

        public Pen(System.Drawing.Color color, float width = 1f)
        {
            M_Pen = new System.Drawing.Pen(color, width);
            OneScriptForms.AddToHashtable(M_Pen, this);
        }

        public Pen(System.Drawing.Pen p1)
        {
            M_Pen = p1;
            OneScriptForms.AddToHashtable(M_Pen, this);
        }

        //Свойства============================================================

        //Методы============================================================

        public void Dispose()
        {
            M_Pen.Dispose();
        }

    }

    [ContextClass ("КлПеро", "ClPen")]
    public class ClPen : AutoContext<ClPen>
    {

        public ClPen(ClColor p1, float p2 = 1.0f)
        {
            Pen Pen1 = new Pen(p1.Base_obj.M_Color, p2);
            Pen1.dll_obj = this;
            Base_obj = Pen1;
        }
		
        public ClPen(Pen p1)
        {
            Pen Pen1 = p1;
            Pen1.dll_obj = this;
            Base_obj = Pen1;
        }

        public Pen Base_obj;

        //Свойства============================================================

        //Методы============================================================

        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
    }
}
