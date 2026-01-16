using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class TextureBrush : Brush
    {
        public ClTextureBrush dll_obj;
        public System.Drawing.TextureBrush M_TextureBrush;

        public TextureBrush(osf.TextureBrush p1)
        {
            M_TextureBrush = p1.M_TextureBrush;
            base.M_Brush = M_TextureBrush;
            OneScriptForms.AddToHashtable(M_TextureBrush, this);
        }

        public TextureBrush(System.Drawing.Image p1)
        {
            M_TextureBrush = new System.Drawing.TextureBrush((System.Drawing.Image)p1);
            base.M_Brush = M_TextureBrush;
            OneScriptForms.AddToHashtable(M_TextureBrush, this);
        }

        public TextureBrush(System.Drawing.TextureBrush p1)
        {
            M_TextureBrush = p1;
            base.M_Brush = M_TextureBrush;
            OneScriptForms.AddToHashtable(M_TextureBrush, this);
        }
    }

    [ContextClass("КлТекстурнаяКисть", "ClTextureBrush")]
    public class ClTextureBrush : AutoContext<ClTextureBrush>
    {
        public ClTextureBrush(Image p1)
        {
            TextureBrush TextureBrush1 = new TextureBrush(p1.M_Image);
            TextureBrush1.dll_obj = this;
            Base_obj = TextureBrush1;
        }

        public ClTextureBrush(TextureBrush p1)
        {
            TextureBrush TextureBrush1 = p1;
            TextureBrush1.dll_obj = this;
            Base_obj = TextureBrush1;
        }

        public TextureBrush Base_obj;

    }
}
