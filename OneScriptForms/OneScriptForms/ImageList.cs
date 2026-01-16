using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class ImageList
    {
        public ClImageList dll_obj;
        public System.Windows.Forms.ImageList M_ImageList;

        public ImageList()
        {
            M_ImageList = new System.Windows.Forms.ImageList();
            OneScriptForms.AddToHashtable(M_ImageList, this);
        }

        public ImageList(osf.ImageList p1)
        {
            M_ImageList = p1.M_ImageList;
            OneScriptForms.AddToHashtable(M_ImageList, this);
        }

        public ImageList(System.Windows.Forms.ImageList p1)
        {
            M_ImageList = p1;
            OneScriptForms.AddToHashtable(M_ImageList, this);
        }

        public int ColorDepth
        {
            get { return (int)M_ImageList.ColorDepth; }
            set { M_ImageList.ColorDepth = (System.Windows.Forms.ColorDepth)value; }
        }

        public osf.ImageCollection Images
        {
            get { return new ImageCollection(M_ImageList.Images); }
        }

        public osf.Size ImageSize
        {
            get { return new Size(M_ImageList.ImageSize); }
            set { M_ImageList.ImageSize = value.M_Size; }
        }

        public osf.Color TransparentColor
        {
            get { return new Color(M_ImageList.TransparentColor); }
            set { M_ImageList.TransparentColor = value.M_Color; }
        }
    }

    [ContextClass("КлСписокИзображений", "ClImageList")]
    public class ClImageList : AutoContext<ClImageList>
    {
        private ClImageCollection images;

        public ClImageList()
        {
            ImageList ImageList1 = new ImageList();
            ImageList1.dll_obj = this;
            Base_obj = ImageList1;
            images = new ClImageCollection(Base_obj.Images);
        }

        public ClImageList(ImageList p1)
        {
            ImageList ImageList1 = p1;
            ImageList1.dll_obj = this;
            Base_obj = ImageList1;
            images = new ClImageCollection(Base_obj.Images);
        }

        public ImageList Base_obj;

        [ContextProperty("ГлубинаЦвета", "ColorDepth")]
        public int ColorDepth
        {
            get { return (int)Base_obj.ColorDepth; }
            set { Base_obj.ColorDepth = value; }
        }

        [ContextProperty("Изображения", "Images")]
        public ClImageCollection Images
        {
            get { return images; }
        }

        [ContextProperty("РазмерИзображения", "ImageSize")]
        public ClSize ImageSize
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.ImageSize); }
            set { Base_obj.ImageSize = value.Base_obj; }
        }

        [ContextMethod("Изображения", "Images")]
        public ClBitmap Images2(int p1)
        {
            return new ClBitmap(Base_obj.Images[p1]);
        }
    }
}
