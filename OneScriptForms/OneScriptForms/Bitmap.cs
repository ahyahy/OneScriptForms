using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{

    public class Bitmap : Image
    {
        public ClBitmap dll_obj;
        public System.Drawing.Bitmap M_Bitmap;

        public Bitmap(Image p1)
        {
            M_Bitmap = new System.Drawing.Bitmap(p1.M_Image);
            base.M_Image = M_Bitmap;
            OneScriptForms.AddToHashtable(M_Bitmap, this);
        }

        public Bitmap(Image p1, Size p2)
        {
            M_Bitmap = new System.Drawing.Bitmap(p1.M_Image, p2.M_Size);
            base.M_Image = M_Bitmap;
            OneScriptForms.AddToHashtable(M_Bitmap, this);
        }

        public Bitmap(Size p1)
        {
            M_Bitmap = new System.Drawing.Bitmap(p1.Width, p1.Height);
            base.M_Image = M_Bitmap;
            OneScriptForms.AddToHashtable(M_Bitmap, this);
        }

        public Bitmap(Stream p1)
        {
            M_Bitmap = new System.Drawing.Bitmap(p1.M_Stream);
            base.M_Image = M_Bitmap;
            OneScriptForms.AddToHashtable(M_Bitmap, this);
        }

        public Bitmap(System.Drawing.Bitmap p1)
        {
            M_Bitmap = p1;
            base.M_Image = M_Bitmap;
        }

        public Bitmap(System.Drawing.Image p1)
        {
            M_Bitmap = new System.Drawing.Bitmap(p1);
            base.M_Image = M_Bitmap;
            OneScriptForms.AddToHashtable(M_Bitmap, this);
        }

        public Bitmap(osf.Bitmap p1)
        {
            M_Bitmap = p1.M_Bitmap;
            base.M_Image = M_Bitmap;
        }

        public Bitmap(string p1)
        {
            try
            {
                M_Bitmap = new System.Drawing.Bitmap((System.IO.Stream)new System.IO.MemoryStream(Convert.FromBase64String(p1)));
                base.M_Image = M_Bitmap;
            }
            catch
            {
                M_Bitmap = new System.Drawing.Bitmap(p1);
                base.M_Image = M_Bitmap;
            }
            OneScriptForms.AddToHashtable(M_Bitmap, this);
        }

        //Свойства============================================================

        //Методы============================================================

        public osf.Bitmap Clone(float x, float y, float width, float height)
        {
            return new Bitmap(M_Bitmap.Clone(
                new System.Drawing.Rectangle(
                    Convert.ToInt32(x),
                    Convert.ToInt32(y),
                    Convert.ToInt32(width),
                    Convert.ToInt32(height)
                    ), 
                System.Drawing.Imaging.PixelFormat.Undefined)
                );
        }

        public osf.Bitmap FromBase64String(string str)
        {
            return new Bitmap(new System.Drawing.Bitmap((System.IO.Stream)new System.IO.MemoryStream(Convert.FromBase64String(str))));
        }

        public osf.Bitmap FromSize(System.Drawing.Size size)
        {
            return new Bitmap(new System.Drawing.Bitmap(size.Width, size.Height));
        }

        public osf.ArrayList GetBytes(osf.BitmapData p1)
        {
            int num = Math.Abs(p1.M_BitmapData.Stride) * M_Bitmap.Height;
            byte[] Bytes1 = new byte[num];
            System.Runtime.InteropServices.Marshal.Copy(p1.M_BitmapData.Scan0, Bytes1, 0, num);
            ArrayList ArrayList1 = new ArrayList();
            for (int i = 0; i < num; i++)
            {
                ArrayList1.Add(System.Convert.ToInt32(Bytes1[i]));
            }
            return ArrayList1;
        }

        public osf.Color GetPixel(int p1, int p2)
        {
            return new Color(M_Bitmap.GetPixel(p1, p2));
        }

        public osf.BitmapData LockBits()
        {
            osf.Rectangle Rectangle1 = new Rectangle(0, 0, M_Bitmap.Width, M_Bitmap.Height);
            System.Drawing.Imaging.ImageLockMode ImageLockMode1 = System.Drawing.Imaging.ImageLockMode.ReadWrite;
            System.Drawing.Imaging.PixelFormat PixelFormat1 = M_Bitmap.PixelFormat;
            osf.BitmapData BitmapData1 = new BitmapData(M_Bitmap.LockBits(Rectangle1.M_Rectangle, ImageLockMode1, PixelFormat1));
            return BitmapData1;
        }

        public void MakeTransparent(Color p1)
        {
            M_Bitmap.MakeTransparent(p1.M_Color);
        }

        public void SetBytes(osf.BitmapData p1, osf.ArrayList p2)
        {
            int num = p2.M_ArrayList.Count;
            byte[] Bytes1 = new byte[num];
            for (int i = 0; i < num; i++)
            {
                Bytes1[i] = System.Convert.ToByte(p2.M_ArrayList[i].ToString());
            }
            System.Runtime.InteropServices.Marshal.Copy(Bytes1, 0, p1.M_BitmapData.Scan0, num);
        }

        public void SetPixel(int x, int y, osf.Color color)
        {
            M_Bitmap.SetPixel(x, y, color.M_Color);
        }

        public string ToBase64String(ImageFormat format = null)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            if (format != null)
            {
                M_Bitmap.Save((System.IO.Stream)memoryStream, format.M_ImageFormat);
            }
            else
            {
                try
                {
                    M_Bitmap.Save((System.IO.Stream)memoryStream, M_Bitmap.RawFormat);
                }
                catch
                {
                    M_Bitmap.Save((System.IO.Stream)memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
            string base64String = Convert.ToBase64String(memoryStream.ToArray());
            memoryStream.Close();
            return base64String;
        }

        public void UnlockBits(osf.BitmapData p1)
        {
            M_Bitmap.UnlockBits(p1.M_BitmapData);
        }

    }

    [ContextClass ("КлКартинка", "ClBitmap")]
    public class ClBitmap : AutoContext<ClBitmap>
    {

        public ClBitmap(ClSize p1)
        {
            Bitmap Bitmap1 = new Bitmap(p1.Base_obj);
            Bitmap1.dll_obj = this;
            Base_obj = Bitmap1;
        }

        public ClBitmap(Image p1)
        {
            Bitmap Bitmap1 = new Bitmap(p1);
            Bitmap1.dll_obj = this;
            Base_obj = Bitmap1;
        }

        public ClBitmap(Image p1, ClSize p2)
        {
            Bitmap Bitmap1 = new Bitmap(p1, p2.Base_obj);
            Bitmap1.dll_obj = this;
            Base_obj = Bitmap1;
        }

        public ClBitmap(string p1)
        {
            Bitmap Bitmap1 = new Bitmap(p1);
            Bitmap1.dll_obj = this;
            Base_obj = Bitmap1;
        }

        public ClBitmap(ClStream p1)
        {
            Bitmap Bitmap1 = new Bitmap(p1.Base_obj);
            Bitmap1.dll_obj = this;
            Base_obj = Bitmap1;
        }

        public ClBitmap(ClBitmap p1)
        {
            Bitmap Bitmap1 = p1.Base_obj;
            Bitmap1.dll_obj = this;
            Base_obj = Bitmap1;
        }

        public Bitmap Base_obj;

        //Свойства============================================================

        [ContextProperty("Высота", "Height")]
        public int Height
        {
            get { return Base_obj.Height; }
        }

        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
        }

        [ContextProperty("ФорматПикселей", "PixelFormat")]
        public int PixelFormat
        {
            get { return (int)Base_obj.PixelFormat; }
        }

        [ContextProperty("ФорматФайлаИзображения", "RawFormat")]
        public ClImageFormat RawFormat
        {
            get { return (ClImageFormat)OneScriptForms.RevertObj(Base_obj.RawFormat); }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
        }

        //Методы============================================================

        [ContextMethod("Блокировать", "LockBits")]
        public ClBitmapData LockBits()
        {
            return new ClBitmapData(Base_obj.LockBits());
        }

        [ContextMethod("ЗакодироватьВСтроку", "ToBase64String")]
        public string ToBase64String(ClImageFormat p1 = null)
        {
            if (p1 == null)
            {
                return Base_obj.ToBase64String();
            }
            return Base_obj.ToBase64String(p1.Base_obj);
        }
        
        [ContextMethod("Клонировать", "Clone")]
        public ClBitmap Clone(int p1, int p2, int p3, int p4)
        {
            Bitmap Bitmap1 = Base_obj.Clone(Convert.ToSingle(p1), Convert.ToSingle(p2), Convert.ToSingle(p3), Convert.ToSingle(p4));
            return new ClBitmap(Bitmap1);
        }
        
        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
					
        [ContextMethod("ПолучитьБайты", "GetBytes")]
        public ClArrayList GetBytes(ClBitmapData p1)
        {
            return new ClArrayList(Base_obj.GetBytes(p1.Base_obj));
        }

        [ContextMethod("ПолучитьПиксель", "GetPixel")]
        public ClColor GetPixel(int p1, int p2)
        {
            return new ClColor(Base_obj.GetPixel(p1, p2));
        }

        [ContextMethod("Разблокировать", "UnlockBits")]
        public void UnlockBits(ClBitmapData p1)
        {
            Base_obj.UnlockBits(p1.Base_obj);
        }

        [ContextMethod("СделатьПрозрачным", "MakeTransparent")]
        public void MakeTransparent(ClColor p1)
        {
            Base_obj.MakeTransparent(p1.Base_obj);
        }

        [ContextMethod("Сохранить", "Save")]
        public void Save(IValue p1, ClImageFormat p2 = null)
        {
            if (p1.GetType() == typeof(osf.ClStream))
            {
                Base_obj.Save(((ClStream)p1).Base_obj, p2.Base_obj);
            }
            else
            {
                Base_obj.Save(p1.AsString(), p2.Base_obj);
            }
        }

        [ContextMethod("УстановитьБайты", "SetBytes")]
        public void SetBytes(ClBitmapData p1, ClArrayList p2)
        {
            Base_obj.SetBytes(p1.Base_obj, p2.Base_obj);
        }

        [ContextMethod("УстановитьПиксель", "SetPixel")]
        public void SetPixel(int p1, int p2, ClColor p3)
        {
            Base_obj.SetPixel(p1, p2, p3.Base_obj);
        }
    }
}
