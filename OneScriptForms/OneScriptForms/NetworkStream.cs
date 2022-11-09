using System;
using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлПотокСети", "ClNetworkStream")]
    public class ClNetworkStream : AutoContext<ClNetworkStream>
    {
        public ClNetworkStream(System.Net.Sockets.NetworkStream p1)
        {
            Base_obj = p1;
        }

        public System.Net.Sockets.NetworkStream Base_obj;
        
        [ContextProperty("ВозможностьЗаписи", "CanWrite")]
        public bool CanWrite
        {
            get { return Base_obj.CanWrite; }
        }

        [ContextProperty("ВозможностьЧтения", "CanRead")]
        public bool CanRead
        {
            get { return Base_obj.CanRead; }
        }

        [ContextProperty("ДанныеДоступны", "DataAvailable")]
        public bool DataAvailable
        {
            get { return Base_obj.DataAvailable; }
        }
        
        [ContextMethod("Закрыть", "Close")]
        public void Close()
        {
            Base_obj.Close();
        }
					
        [ContextMethod("Записать", "Write")]
        public void Write(ClArrayList p1, int p2, int p3)
        {
            System.Collections.ArrayList ArrayList1 = p1.Base_obj.M_ArrayList;
            byte[] buffer = new byte[ArrayList1.Count];
            int num = p3 - 1;
            for (int i = 0; i < num; i++)
            {
                buffer[i] = Convert.ToByte(ArrayList1[i + p2]);
            }
            Base_obj.Write(buffer, 0, p3);
        }
        
        [ContextMethod("Прочитать", "Read")]
        public ClArrayList Read(int p1, int p2)
        {
            byte[] buffer = new byte[p2];
            int num1 = Base_obj.Read(buffer, p1, p2);
            ClArrayList ClArrayList1 = new ClArrayList();
            System.Collections.ArrayList ArrayList1 = ClArrayList1.Base_obj.M_ArrayList;
            int num2 = num1 + p1 - 1;
            for (int i = p1; i < num2; i++)
            {
                ArrayList1.Add(buffer[i]);
            }
            return ClArrayList1;
        }
        
        [ContextMethod("ЧитатьБайт", "ReadByte")]
        public int ReadByte()
        {
            return Base_obj.ReadByte();
        }
    }
}
