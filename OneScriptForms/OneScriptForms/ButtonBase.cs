namespace osf
{

    public class ButtonBase : Control
    {
        private osf.Bitmap image;
        private System.Windows.Forms.ButtonBase m_ButtonBase;

        public ButtonBase()
        {
        }

        //Свойства============================================================

        public int FlatStyle
        {
            get { return (int)M_ButtonBase.FlatStyle; }
            set { M_ButtonBase.FlatStyle = (System.Windows.Forms.FlatStyle)value; }
        }

        public osf.Bitmap Image
        {
            get { return image; }
            set
            {
                image = value;
                M_ButtonBase.Image = value.M_Image;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int ImageAlign
        {
            get { return (int)M_ButtonBase.ImageAlign; }
            set { M_ButtonBase.ImageAlign = (System.Drawing.ContentAlignment)value; }
        }

        public int ImageIndex
        {
            get { return M_ButtonBase.ImageIndex; }
            set { M_ButtonBase.ImageIndex = value; }
        }

        public osf.ImageList ImageList
        {
            get { return new ImageList(M_ButtonBase.ImageList); }
            set { M_ButtonBase.ImageList = value.M_ImageList; }
        }

        public System.Windows.Forms.ButtonBase M_ButtonBase
        {
            get { return m_ButtonBase; }
            set
            {
                m_ButtonBase = value;
                base.M_Control = m_ButtonBase;
            }
        }

        public int TextAlign
        {
            get { return (int)M_ButtonBase.TextAlign; }
            set { M_ButtonBase.TextAlign = (System.Drawing.ContentAlignment)value; }
        }

        //Методы============================================================

    }

}
