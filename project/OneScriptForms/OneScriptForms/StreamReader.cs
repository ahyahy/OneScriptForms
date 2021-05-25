using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class StreamReader
    {
        public ClStreamReader dll_obj;
        public System.IO.StreamReader M_StreamReader;

        public StreamReader(System.IO.StreamReader p1)
        {
            M_StreamReader = p1;
        }

        public StreamReader(osf.StreamReader p1)
        {
            M_StreamReader = p1.M_StreamReader;
        }

        public StreamReader(string p1)
        {
            M_StreamReader = new System.IO.StreamReader(p1);
        }

        //Свойства============================================================

        //Методы============================================================

        public void Close()
        {
            M_StreamReader.Close();
        }

        public int Peek()
        {
            return M_StreamReader.Peek();
        }

        public string ReadLine()
        {
            return M_StreamReader.ReadLine();
        }

        public string ReadToEnd()
        {
            return M_StreamReader.ReadToEnd();
        }

    }

    [ContextClass ("КлПотокЧтения", "ClStreamReader")]
    public class ClStreamReader : AutoContext<ClStreamReader>
    {

        public ClStreamReader(string p1)
        {
            StreamReader StreamReader1 = new StreamReader(p1);
            StreamReader1.dll_obj = this;
            Base_obj = StreamReader1;
        }
		
        public ClStreamReader(StreamReader p1)
        {
            StreamReader StreamReader1 = p1;
            StreamReader1.dll_obj = this;
            Base_obj = StreamReader1;
        }

        public StreamReader Base_obj;

        //Свойства============================================================

        //Методы============================================================

        [ContextMethod("Заглянуть", "Peek")]
        public int Peek()
        {
            return Base_obj.Peek();
        }

        [ContextMethod("Закрыть", "Close")]
        public void Close()
        {
            Base_obj.Close();
        }
					
        [ContextMethod("ПрочитатьДоКонца", "ReadToEnd")]
        public string ReadToEnd()
        {
            return Base_obj.ReadToEnd();
        }

        [ContextMethod("ПрочитатьСтроку", "ReadLine")]
        public string ReadLine()
        {
            return Base_obj.ReadLine();
        }
    }
}
