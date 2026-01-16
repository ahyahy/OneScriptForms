using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class Encoding
    {
        public ClEncoding dll_obj;
        public System.Text.Encoding M_Encoding;

        private Encoding(osf.Encoding p1)
        {
            M_Encoding = p1.M_Encoding;
        }

        private Encoding(System.Text.Encoding p1)
        {
            M_Encoding = p1;
        }

        public Encoding()
        {
            M_Encoding = System.Text.Encoding.Default;
        }

        public osf.Encoding ASCII
        {
            get { return new Encoding(System.Text.Encoding.ASCII); }
        }

        public osf.Encoding BigEndianUnicode
        {
            get { return new Encoding(System.Text.Encoding.BigEndianUnicode); }
        }

        public string BodyName
        {
            get { return M_Encoding.BodyName; }
        }

        public osf.Encoding ByDefault
        {
            get { return new Encoding(System.Text.Encoding.Default); }
        }

        public string EncodingName
        {
            get { return M_Encoding.EncodingName; }
        }

        public string HeaderName
        {
            get { return M_Encoding.HeaderName; }
        }

        public osf.Encoding Unicode
        {
            get { return new Encoding(System.Text.Encoding.Unicode); }
        }

        public osf.Encoding UTF7
        {
            get { return new Encoding(System.Text.Encoding.UTF7); }
        }

        public osf.Encoding UTF8
        {
            get { return new Encoding(System.Text.Encoding.UTF8); }
        }

        public string WebName
        {
            get { return M_Encoding.WebName; }
        }

        public int WindowsCodePage
        {
            get { return M_Encoding.WindowsCodePage; }
        }

        public int GetByteCount(string sText)
        {
            return M_Encoding.GetByteCount(sText);
        }

        public osf.Encoding GetEncoding(int p1)
        {
            return new Encoding(System.Text.Encoding.GetEncoding(p1));
        }
    }

    [ContextClass("КлКодировка", "ClEncoding")]
    public class ClEncoding : AutoContext<ClEncoding>
    {
        public ClEncoding()
        {
            Encoding Encoding1 = new Encoding();
            Encoding1.dll_obj = this;
            Base_obj = Encoding1;
        }

        public ClEncoding(Encoding p1)
        {
            Encoding Encoding1 = p1;
            Encoding1.dll_obj = this;
            Base_obj = Encoding1;
        }

        public Encoding Base_obj;

        [ContextProperty("ASCII", "ASCII")]
        public ClEncoding ASCII
        {
            get { return (ClEncoding)OneScriptForms.RevertObj(Base_obj.ASCII); }
        }

        [ContextProperty("UTF7", "UTF7")]
        public ClEncoding UTF7
        {
            get { return (ClEncoding)OneScriptForms.RevertObj(Base_obj.UTF7); }
        }

        [ContextProperty("UTF8", "UTF8")]
        public ClEncoding UTF8
        {
            get { return (ClEncoding)OneScriptForms.RevertObj(Base_obj.UTF8); }
        }

        [ContextProperty("ИмяWeb", "WebName")]
        public string WebName
        {
            get { return Base_obj.WebName; }
        }

        [ContextProperty("ИмяЗаголовка", "HeaderName")]
        public string HeaderName
        {
            get { return Base_obj.HeaderName; }
        }

        [ContextProperty("ИмяКодировки", "EncodingName")]
        public string EncodingName
        {
            get { return Base_obj.EncodingName; }
        }

        [ContextProperty("ИмяТела", "BodyName")]
        public string BodyName
        {
            get { return Base_obj.BodyName; }
        }

        [ContextProperty("КодоваяСтраница", "WindowsCodePage")]
        public int WindowsCodePage
        {
            get { return Base_obj.WindowsCodePage; }
        }

        [ContextProperty("ОбратнаяUTF16", "BigEndianUnicode")]
        public ClEncoding BigEndianUnicode
        {
            get { return (ClEncoding)OneScriptForms.RevertObj(Base_obj.BigEndianUnicode); }
        }

        [ContextProperty("ПоУмолчанию", "ByDefault")]
        public ClEncoding ByDefault
        {
            get { return (ClEncoding)OneScriptForms.RevertObj(Base_obj.ByDefault); }
        }

        [ContextProperty("Юникод", "Unicode")]
        public ClEncoding Unicode
        {
            get { return (ClEncoding)OneScriptForms.RevertObj(Base_obj.Unicode); }
        }

        [ContextMethod("КоличествоБайтов", "GetByteCount")]
        public int GetByteCount(string p1)
        {
            return Base_obj.GetByteCount(p1);
        }

        [ContextMethod("ПолучитьБайты", "GetBytes")]
        public ClArrayList GetBytes(string p1)
        {
            ClArrayList ClArrayList1 = new ClArrayList();
            byte[] Bytes1 = Base_obj.M_Encoding.GetBytes(p1);
            for (int i = 0; i < Bytes1.Length; i++)
            {
                ClArrayList1.Base_obj.Add(Bytes1[i]);
            }
            return ClArrayList1;
        }

        [ContextMethod("ПолучитьКодировку", "GetEncoding")]
        public ClEncoding GetEncoding(int p1)
        {
            return new ClEncoding(Base_obj.GetEncoding(p1));
        }

        [ContextMethod("ПолучитьСтроку", "GetString")]
        public string GetString(ClArrayList p1)
        {
            System.Collections.ArrayList ArrayList1 = p1.Base_obj.M_ArrayList;
            byte[] Bytes1 = new byte[checked(ArrayList1.Count + 2)];

            for (int i = 0; i < ArrayList1.Count; i++)
            {
                Bytes1[i] = System.Convert.ToByte(System.Convert.ToInt32(ArrayList1[i].ToString()));
            }
            string str1 = Base_obj.M_Encoding.GetString(Bytes1);
            if ((BodyName == "utf-16") || (BodyName == "utf-16BE"))
            {
                return Base_obj.M_Encoding.GetString(Bytes1).Substring(0, str1.Length - 1);
            }
            else if ((BodyName == "us-ascii") || (BodyName == "utf-7") || (BodyName == "utf-8"))
            {
                return Base_obj.M_Encoding.GetString(Bytes1).Substring(0, str1.Length - 2);
            }
            return str1;
        }

        [ContextMethod("Преобразовать", "Convert")]
        public ClArrayList Convert(ClEncoding p1, ClEncoding p2, ClArrayList p3)
        {
            System.Collections.ArrayList ArrayList1 = p3.Base_obj.M_ArrayList;
            byte[] Bytes1 = new byte[checked(ArrayList1.Count + 2)];
            for (int i = 0; i < ArrayList1.Count; i++)
            {
                Bytes1[i] = System.Convert.ToByte(ArrayList1[i]);
            }
            byte[] Array1 = System.Text.Encoding.Convert(p1.Base_obj.M_Encoding, p2.Base_obj.M_Encoding, Bytes1);
            object[] objArray = new object[checked(Array1.Length + 1)];
            for (int i = 0; i < Array1.Length; i++)
            {
                objArray[i] = (object)Array1[i];
            }
            ClArrayList ClArrayList2 = new ClArrayList();
            int Length1 = objArray.Length - 1;
            if ((p1.BodyName == "utf-16") || (p1.BodyName == "utf-16BE"))
            {
                if ((p2.BodyName == "utf-16") || (p2.BodyName == "utf-16BE"))
                {
                    Length1 = objArray.Length - 3;
                }
                else if ((p2.BodyName == "us-ascii") || (p2.BodyName == "utf-7") || (p2.BodyName == "utf-8"))
                {
                    Length1 = objArray.Length - 2;
                }
            }
            else if ((p1.BodyName == "us-ascii") || (p1.BodyName == "utf-7") || (p1.BodyName == "utf-8"))
            {
                if ((p2.BodyName == "utf-16") || (p2.BodyName == "utf-16BE"))
                {
                    Length1 = objArray.Length - 5;
                }
                else if ((p2.BodyName == "us-ascii") || (p2.BodyName == "utf-7") || (p2.BodyName == "utf-8"))
                {
                    Length1 = objArray.Length - 3;
                }
            }
            for (int i = 0; i < Length1; i++)
            {
                ClArrayList2.Base_obj.Add(objArray[i]);
            }
            return ClArrayList2;
        }
    }
}
