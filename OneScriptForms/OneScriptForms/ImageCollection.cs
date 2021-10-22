using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class ImageCollection : CollectionBase
    {
        public ClImageCollection dll_obj;
        public System.Windows.Forms.ImageList.ImageCollection M_ImageCollection;

        public ImageCollection()
        {
        }

        public ImageCollection(System.Windows.Forms.ImageList.ImageCollection p1)
        {
            M_ImageCollection = p1;
            base.List = M_ImageCollection;
        }

        public override object Current
        {
            get { return new Image((System.Drawing.Image)Enumerator.Current); }
        }

        public new osf.Image this[int p1]
        {
            get { return (Image)new Bitmap((System.Drawing.Bitmap)M_ImageCollection[p1]); }
        }

        public int Add(Image image, Color color = null)
        {
            if (color == null)
            {
                return M_ImageCollection.Add(image.M_Image, System.Drawing.Color.Empty);
            }
            return M_ImageCollection.Add(image.M_Image, color.M_Color);
        }

        public int AddStrip(Image image)
        {
            return M_ImageCollection.AddStrip(image.M_Image);
        }
    }

    [ContextClass ("КлИзображения", "ClImageCollection")]
    public class ClImageCollection : AutoContext<ClImageCollection>
    {
        public ClImageCollection()
        {
            ImageCollection ImageCollection1 = new ImageCollection();
            ImageCollection1.dll_obj = this;
            Base_obj = ImageCollection1;
        }
		
        public ClImageCollection(ImageCollection p1)
        {
            ImageCollection ImageCollection1 = p1;
            ImageCollection1.dll_obj = this;
            Base_obj = ImageCollection1;
        }
        
        public ImageCollection Base_obj;
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }
        
        [ContextMethod("Добавить", "Add")]
        public int Add(ClBitmap p1, ClColor p2 = null)
        {
            int index1 = -1;
            if (p2 != null)
            {
                index1 = Base_obj.Add(p1.Base_obj, p2.Base_obj);
            }
            else
            {
                index1 = Base_obj.Add(p1.Base_obj);
            }
            return index1;
        }
        
        [ContextMethod("ДобавитьПолосу", "AddStrip")]
        public int AddStrip(ClBitmap p1)
        {
            return Base_obj.AddStrip(p1.Base_obj);
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }
					
        [ContextMethod("УдалитьПоИндексу", "RemoveAt")]
        public void RemoveAt(int p1)
        {
            Base_obj.RemoveAt(p1);
        }

        [ContextMethod("Элемент", "Item")]
        public ClBitmap Item(int p1)
        {
            return new ClBitmap(Base_obj[p1]);
        }
    }
}
