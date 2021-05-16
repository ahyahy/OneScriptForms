using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class BitmapData
    {
        public ClBitmapData dll_obj;
        public System.Drawing.Imaging.BitmapData M_BitmapData;

        public BitmapData(System.Drawing.Imaging.BitmapData p1)
        {
            M_BitmapData = p1;
            OneScriptForms.AddToHashtable(M_BitmapData, this);
        }

        public BitmapData(osf.BitmapData p1)
        {
            M_BitmapData = p1.M_BitmapData;
            OneScriptForms.AddToHashtable(M_BitmapData, this);
        }

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлАтрибутыКартинки", "ClBitmapData")]
    public class ClBitmapData : AutoContext<ClBitmapData>
    {

        public ClBitmapData(BitmapData p1)
        {
            BitmapData BitmapData1 = p1;
            BitmapData1.dll_obj = this;
            Base_obj = BitmapData1;
        }

        public BitmapData Base_obj;

        //Свойства============================================================

        //Методы============================================================

    }
}
