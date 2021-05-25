using System;
using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class Stream
    {
        public ClStream dll_obj;
        public System.IO.Stream M_Stream;

        public Stream()
        {
            M_Stream = (System.IO.Stream)new System.IO.MemoryStream();
        }

        public Stream(System.IO.Stream p1)
        {
            M_Stream = p1;
        }

        public Stream(osf.Stream p1)
        {
            M_Stream = p1.M_Stream;
        }

        //Свойства============================================================

        public virtual bool CanRead
        {
            get { return M_Stream.CanRead; }
        }

        public virtual bool CanSeek
        {
            get { return M_Stream.CanSeek; }
        }

        public virtual bool CanWrite
        {
            get { return M_Stream.CanWrite; }
        }

        public virtual int Length
        {
            get { return checked((int)M_Stream.Length); }
        }

        public virtual int Position
        {
            get { return checked((int)M_Stream.Position); }
            set { M_Stream.Position = (long)value; }
        }

        public virtual int Seek(int offset, int origin)
        {
            return checked((int)M_Stream.Seek((long)offset, (System.IO.SeekOrigin)origin));
        }

        public virtual void Write(object[] buffer, int offset, int count)
        {
            byte[] Bytes1 = new byte[checked(count)];
            for (int i = 0; i < count; i++)
            {
                Bytes1[i] = Convert.ToByte(buffer[checked(i + offset)]);
            }
            M_Stream.Write(Bytes1, 0, count);
        }

        //Методы============================================================

        public virtual int ReadByte()
        {
            return M_Stream.ReadByte();
        }

        public virtual void Close()
        {
            M_Stream.Close();
        }

        public virtual void Flush()
        {
            M_Stream.Flush();
        }

        public virtual void SetLength(int value)
        {
            M_Stream.SetLength((long)value);
        }

        public virtual void WriteByte(byte value)
        {
            M_Stream.WriteByte(value);
        }

    }

    [ContextClass ("КлПоток", "ClStream")]
    public class ClStream : AutoContext<ClStream>
    {

        public ClStream()
        {
            Stream Stream1 = new Stream();
            Stream1.dll_obj = this;
            Base_obj = Stream1;
        }
		
        public ClStream(Stream p1)
        {
            Stream Stream1 = p1;
            Stream1.dll_obj = this;
            Base_obj = Stream1;
        }
        
        public Stream Base_obj;

        //Свойства============================================================

        [ContextProperty("ВозможностьЗаписи", "CanWrite")]
        public bool CanWrite
        {
            get { return Base_obj.CanWrite; }
        }

        [ContextProperty("ВозможностьПоиска", "CanSeek")]
        public bool CanSeek
        {
            get { return Base_obj.CanSeek; }
        }

        [ContextProperty("ВозможностьЧтения", "CanRead")]
        public bool CanRead
        {
            get { return Base_obj.CanRead; }
        }

        [ContextProperty("Длина", "Length")]
        public int Length
        {
            get { return Base_obj.Length; }
        }

        [ContextProperty("Позиция", "Position")]
        public int Position
        {
            get { return Base_obj.Position; }
            set { Base_obj.Position = value; }
        }

        //Методы============================================================

        [ContextMethod("Закрыть", "Close")]
        public void Close()
        {
            Base_obj.Close();
        }
					
        [ContextMethod("Записать", "Write")]
        public void Write(ClArrayList p1, int p2, int p3)
        {
            ArrayList ArrayList1 = p1.Base_obj;
            int Count1 = ArrayList1.Count;
            object[] objects = new object[Count1];
            for (int i = 0; i < Count1; i++)
            {
                objects[i] = System.Convert.ToByte(ArrayList1[i]);
            }
            Base_obj.Write(objects, p2, p3);
        }
        
        [ContextMethod("ЗаписатьБайт", "WriteByte")]
        public void WriteByte(int p1)
        {
            Base_obj.WriteByte(Convert.ToByte(p1));
        }
        
        [ContextMethod("Найти", "Seek")]
        public int Seek(int p1, int p2)
        {
            return Base_obj.Seek(p1, p2);
        }

        [ContextMethod("Сбросить", "Flush")]
        public void Flush()
        {
            Base_obj.Flush();
        }
					
        [ContextMethod("УстановитьДлину", "SetLength")]
        public void SetLength(int p1)
        {
            Base_obj.SetLength(p1);
        }

        [ContextMethod("ЧитатьБайт", "ReadByte")]
        public int ReadByte()
        {
            return Base_obj.ReadByte();
        }
    }
}
