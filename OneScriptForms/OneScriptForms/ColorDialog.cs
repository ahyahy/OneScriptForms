using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Threading;

namespace osf
{
    public class ColorDialogEx : System.Windows.Forms.ColorDialog
    {
        public osf.ColorDialog M_Object;
    }

    public class ColorDialog : CommonDialog
    {
        public ClColorDialog dll_obj;
        public ColorDialogEx M_ColorDialog;

        public ColorDialog()
        {
            M_ColorDialog = new ColorDialogEx();
            M_ColorDialog.M_Object = this;
            base.M_CommonDialog = M_ColorDialog;
        }

        public ColorDialog(osf.ColorDialog p1)
        {
            M_ColorDialog = p1.M_ColorDialog;
            M_ColorDialog.M_Object = this;
            base.M_CommonDialog = M_ColorDialog;
        }

        public ColorDialog(System.Windows.Forms.ColorDialog p1)
        {
            M_ColorDialog = (ColorDialogEx)p1;
            M_ColorDialog.M_Object = this;
            base.M_CommonDialog = M_ColorDialog;
        }

        public osf.Color Color
        {
            get { return new Color(M_ColorDialog.Color); }
            set { M_ColorDialog.Color = value.M_Color; }
        }
    }

    [ContextClass ("КлДиалогВыбораЦвета", "ClColorDialog")]
    public class ClColorDialog : AutoContext<ClColorDialog>
    {
        private ClColor color;

        public ClColorDialog()
        {
            ColorDialog ColorDialog1 = new ColorDialog();
            ColorDialog1.dll_obj = this;
            Base_obj = ColorDialog1;
            color = new ClColor(Base_obj.Color);
        }
		
        public ClColorDialog(ColorDialog p1)
        {
            ColorDialog ColorDialog1 = p1;
            ColorDialog1.dll_obj = this;
            Base_obj = ColorDialog1;
            color = new ClColor(Base_obj.Color);
        }
        
        public ColorDialog Base_obj;
        
        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }
        
        [ContextProperty("Цвет", "Color")]
        public ClColor Color
        {
            get { return color; }
            set 
            {
                color = value;
                Base_obj.Color = value.Base_obj;
            }
        }
        
        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
					
        [ContextMethod("ПоказатьДиалог", "ShowDialog")]
        public IValue ShowDialog()
        {
            int Res1 = 0;
            var thread = new Thread(() => Res1 = (int)Base_obj.ShowDialog());
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            color = new ClColor(Base_obj.Color);

            return ValueFactory.Create(Res1);
        }
    }
}
