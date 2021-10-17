using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class ImageFormat
    {
        public ClImageFormat dll_obj;
        public System.Drawing.Imaging.ImageFormat M_ImageFormat;

        public ImageFormat()
        {
            M_ImageFormat = new System.Drawing.Imaging.ImageFormat(System.Guid.Empty);
        }

        public ImageFormat(osf.ImageFormat p1)
        {
            M_ImageFormat = p1.M_ImageFormat;
        }

        public ImageFormat(System.Drawing.Imaging.ImageFormat p1)
        {
            M_ImageFormat = p1;
        }

        //Свойства============================================================

        public osf.ImageFormat Bmp
        {
            get { return new ImageFormat(System.Drawing.Imaging.ImageFormat.Bmp); }
        }

        public osf.ImageFormat Gif
        {
            get { return new ImageFormat(System.Drawing.Imaging.ImageFormat.Gif); }
        }

        public osf.ImageFormat Icon
        {
            get { return new ImageFormat(System.Drawing.Imaging.ImageFormat.Icon); }
        }

        public osf.ImageFormat Jpeg
        {
            get { return new ImageFormat(System.Drawing.Imaging.ImageFormat.Jpeg); }
        }

        public osf.ImageFormat Png
        {
            get { return new ImageFormat(System.Drawing.Imaging.ImageFormat.Png); }
        }

        //Методы============================================================

    }

    [ContextClass ("КлФорматИзображения", "ClImageFormat")]
    public class ClImageFormat : AutoContext<ClImageFormat>
    {

        public ClImageFormat()
        {
            ImageFormat ImageFormat1 = new ImageFormat();
            ImageFormat1.dll_obj = this;
            Base_obj = ImageFormat1;
        }
		
        public ClImageFormat(ImageFormat p1)
        {
            ImageFormat ImageFormat1 = p1;
            ImageFormat1.dll_obj = this;
            Base_obj = ImageFormat1;
        }
        
        public ImageFormat Base_obj;

        //Свойства============================================================

        [ContextProperty("Bmp", "Bmp")]
        public ClImageFormat Bmp
        {
            get { return (ClImageFormat)OneScriptForms.RevertObj(Base_obj.Bmp); }
        }

        [ContextProperty("Gif", "Gif")]
        public ClImageFormat Gif
        {
            get { return (ClImageFormat)OneScriptForms.RevertObj(Base_obj.Gif); }
        }

        [ContextProperty("Icon", "Icon")]
        public ClImageFormat Icon
        {
            get { return (ClImageFormat)OneScriptForms.RevertObj(Base_obj.Icon); }
        }

        [ContextProperty("Jpeg", "Jpeg")]
        public ClImageFormat Jpeg
        {
            get { return (ClImageFormat)OneScriptForms.RevertObj(Base_obj.Jpeg); }
        }

        [ContextProperty("Png", "Png")]
        public ClImageFormat Png
        {
            get { return (ClImageFormat)OneScriptForms.RevertObj(Base_obj.Png); }
        }

        //Методы============================================================

        [ContextMethod("ВСтроку", "ToString")]
        public new string ToString()
        {
            if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3cae-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "[ImageFormat: b96b3cae-0728-11d3-9d7b-0000f81ef32e] Jpeg";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3caa-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "[ImageFormat: b96b3caa-0728-11d3-9d7b-0000f81ef32e] MemoryBMP";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3cab-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "[ImageFormat: b96b3cab-0728-11d3-9d7b-0000f81ef32e] Bmp";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3cb0-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "[ImageFormat: b96b3cb0-0728-11d3-9d7b-0000f81ef32e] Gif";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3caf-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "[ImageFormat: b96b3caf-0728-11d3-9d7b-0000f81ef32e] Png";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3cb1-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "[ImageFormat: b96b3cb1-0728-11d3-9d7b-0000f81ef32e] Tiff";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3cb5-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "[ImageFormat: b96b3cb5-0728-11d3-9d7b-0000f81ef32e] Icon";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3cac-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "emf";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3cb2-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "[ImageFormat: b96b3cac-0728-11d3-9d7b-0000f81ef32e] exif";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3cad-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "[ImageFormat: b96b3cad-0728-11d3-9d7b-0000f81ef32e] wmf";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3cb3 - 0728 - 11d3 - 9d7b - 0000f81ef32e]")
            {
                return "[ImageFormat: b96b3cb3 - 0728 - 11d3 - 9d7b - 0000f81ef32e] pcd";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3cb4-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "[ImageFormat: b96b3cb4-0728-11d3-9d7b-0000f81ef32e] fpx";
            }
            else if (Base_obj.M_ImageFormat.ToString() == "[ImageFormat: b96b3ca9-0728-11d3-9d7b-0000f81ef32e]")
            {
                return "Windows GDI + не может определить формат.";
            }
            return "";
        }
    }
}
