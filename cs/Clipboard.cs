using System;
using ScriptEngine.Machine.Contexts;
using System.Windows.Forms;
using System.Threading;

namespace osf
{
    [ContextClass ("КлБуферОбмена", "ClClipboard")]
    public class ClClipboard : AutoContext<ClClipboard>
    {

        //Свойства============================================================

        //Методы============================================================

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            var thread = new Thread(() => Clipboard.Clear());
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        
        [ContextMethod("ПолучитьИзображение", "GetImage")]
        public ClBitmap GetImage()
        {
            ClBitmap ClBitmap1 = null;
            var thread = new Thread(() =>
                {
                    if (Clipboard.ContainsImage())
                    {
                        Bitmap Bitmap1 = new Bitmap((System.Drawing.Image)Clipboard.GetImage());
                        ClBitmap1 = new ClBitmap(Bitmap1);
                    }
                }
            );
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return ClBitmap1;
        }
        
        [ContextMethod("ПолучитьТекст", "GetText")]
        public string GetText()
        {
            string str1 = null;
            var thread = new Thread(() => 
                {
                    IDataObject dataObject = Clipboard.GetDataObject();
                    if (dataObject.GetDataPresent(DataFormats.UnicodeText))
                    {
                        str1 = (String)dataObject.GetData(DataFormats.UnicodeText);
                    }
                }
            );
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return str1;
        }
        
        [ContextMethod("УстановитьИзображение", "SetImage")]
        public void SetImage(ClBitmap bitmap)
        {
            var data = new DataObject();
            data.SetData(DataFormats.Bitmap, true, ((System.Drawing.Image)(bitmap.Base_obj.M_Image)));
            var thread = new Thread(() => Clipboard.SetDataObject(data, true));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
        
        [ContextMethod("УстановитьТекст", "SetText")]
        public void SetText(string text)
        {
            var data = new DataObject();
            data.SetData(DataFormats.UnicodeText, true, text);
            var thread = new Thread(() => Clipboard.SetDataObject(data, true));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
}
