using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Threading;

namespace osf
{
    public class FontDialogEx : System.Windows.Forms.FontDialog
    {
        public osf.FontDialog M_Object;
    }

    public class FontDialog : CommonDialog
    {
        public ClFontDialog dll_obj;
        public FontDialogEx M_FontDialog;

        public FontDialog()
        {
            M_FontDialog = new FontDialogEx();
            M_FontDialog.M_Object = this;
            base.M_CommonDialog = M_FontDialog;
        }

        public FontDialog(osf.FontDialog p1)
        {
            M_FontDialog = p1.M_FontDialog;
            M_FontDialog.M_Object = this;
            base.M_CommonDialog = M_FontDialog;
        }

        public FontDialog(System.Windows.Forms.FontDialog p1)
        {
            M_FontDialog = (FontDialogEx)p1;
            M_FontDialog.M_Object = this;
            base.M_CommonDialog = M_FontDialog;
        }

        public osf.Color Color
        {
            get { return new Color(M_FontDialog.Color); }
            set { M_FontDialog.Color = value.M_Color; }
        }

        public osf.Font Font
        {
            get { return new Font(M_FontDialog.Font); }
            set { M_FontDialog.Font = value.M_Font; }
        }

        public bool ShowColor
        {
            get { return M_FontDialog.ShowColor; }
            set { M_FontDialog.ShowColor = value; }
        }
    }

    [ContextClass ("КлДиалогВыбораШрифта", "ClFontDialog")]
    public class ClFontDialog : AutoContext<ClFontDialog>
    {
        private ClFont font;

        public ClFontDialog()
        {
            FontDialog FontDialog1 = new FontDialog();
            FontDialog1.dll_obj = this;
            Base_obj = FontDialog1;
        }
		
        public ClFontDialog(FontDialog p1)
        {
            FontDialog FontDialog1 = p1;
            FontDialog1.dll_obj = this;
            Base_obj = FontDialog1;
        }
        
        public FontDialog Base_obj;
        
        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }
        
        [ContextProperty("Цвет", "Color")]
        public ClColor Color
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Color); }
            set { Base_obj.Color = value.Base_obj; }
        }

        [ContextProperty("Шрифт", "Font")]
        public ClFont Font
        {
            get
            {
                if (font != null)
                {
                    return font;
                }
                return new ClFont(Base_obj.Font);
            }
            set
            {
                font = value;
                Base_obj.Font = value.Base_obj;
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
            var thread = new Thread(() => 
                {
                    Base_obj.ShowColor = true;
                    Res1 = (int)Base_obj.ShowDialog();
                }
            );
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return ValueFactory.Create(Res1);
        }
    }
}
