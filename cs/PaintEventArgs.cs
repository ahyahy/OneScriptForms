using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class PaintEventArgs : EventArgs
    {
        public osf.Rectangle ClipRectangle = null;
        public new ClPaintEventArgs dll_obj;
        public osf.Graphics Graphics = null;

        //Свойства============================================================

        //Методы============================================================

    }

    [ContextClass ("КлРисованиеАрг", "ClPaintEventArgs")]
    public class ClPaintEventArgs : AutoContext<ClPaintEventArgs>
    {

        public ClPaintEventArgs()
        {
            PaintEventArgs PaintEventArgs1 = new PaintEventArgs();
            PaintEventArgs1.dll_obj = this;
            Base_obj = PaintEventArgs1;
        }
		
        public ClPaintEventArgs(PaintEventArgs p1)
        {
            PaintEventArgs PaintEventArgs1 = p1;
            PaintEventArgs1.dll_obj = this;
            Base_obj = PaintEventArgs1;
        }
        
        public PaintEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Графика", "Graphics")]
        public ClGraphics Graphics
        {
            get { return new ClGraphics(Base_obj.Graphics); }
        }
        
        [ContextProperty("ПрямоугольникДляРисования", "ClipRectangle")]
        public ClRectangle ClipRectangle
        {
            get { return (ClRectangle)OneScriptForms.RevertObj(Base_obj.ClipRectangle); }
        }

        //Методы============================================================

    }
}
