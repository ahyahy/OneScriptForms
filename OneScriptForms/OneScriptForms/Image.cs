namespace osf
{
    public class Image
    {
        public System.Drawing.Image M_Image;

        public Image()
        {
        }

        public Image(osf.Image p1)
        {
            M_Image = p1.M_Image;
        }

        public Image(Stream stream)
        {
            M_Image = System.Drawing.Image.FromStream((System.IO.Stream)stream.M_Stream);
        }

        public Image(System.Drawing.Image p1)
        {
            M_Image = p1;
        }

        public osf.ImageFormat  RawFormat
        {
            get { return new ImageFormat(M_Image.RawFormat); }
        }

        public int Height
        {
            get { return M_Image.Height; }
        }

        public int PixelFormat
        {
            get { return (int)M_Image.PixelFormat; }
        }

        public osf.Size Size
        {
            get { return new Size(M_Image.Size); }
        }

        public int Width
        {
            get { return M_Image.Width; }
        }

        public object Clone()
        {
            return M_Image.Clone();
        }

        public void Dispose()
        {
            M_Image.Dispose();
        }

        public void Save(Stream p1, ImageFormat p2)
        {
            M_Image.Save(p1.M_Stream, p2.M_ImageFormat);
        }

        public void Save(string p1, ImageFormat p2 = null)
        {
            if (p2 == null)
            {
                M_Image.Save(p1);
            }
            else
            {
                M_Image.Save(p1, p2.M_ImageFormat);
            }
        }
    }
}
