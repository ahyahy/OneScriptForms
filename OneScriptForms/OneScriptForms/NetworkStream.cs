using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System;
using ScriptEngine.HostedScript.Library.Binary;
using System.Threading.Tasks;
using osf;

namespace osfMultiTcp
{
    [ContextClass("ТсПотокСети", "TsNetworkStream")]
    public class TsNetworkStream : AutoContext<TsNetworkStream>
    {
        public TsNetworkStream(System.Net.Sockets.NetworkStream p1)
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
        public void Write(IValue p1, int p2, int p3)
        {
            if (Utils.IsType<BinaryDataBuffer>(p1))
            {
                Base_obj.Write(((BinaryDataBuffer)p1).Bytes, 0, p3);
            }
            else
            {
                System.Collections.ArrayList ArrayList1 = ((ClArrayList)p1).Base_obj.M_ArrayList;
                byte[] buffer = new byte[ArrayList1.Count];
                int num = p3 - 1;
                for (int i = 0; i < num; i++)
                {
                    buffer[i] = Convert.ToByte(ArrayList1[i + p2]);
                }
                Base_obj.Write(buffer, 0, p3);
            }
        }

        [ContextMethod("Прочитать", "Read")]
        public ClArrayList Read(int p1, int p2)
        {
            byte[] buffer = new byte[p2];
            Base_obj.Read(buffer, p1, p2);
            ClArrayList ClArrayList1 = new ClArrayList();
            System.Collections.ArrayList ArrayList1 = ClArrayList1.Base_obj.M_ArrayList;
            for (int i = 0; i < buffer.Length; i++)
            {
                ArrayList1.Add(buffer[i]);
            }
            return ClArrayList1;
        }

        [ContextMethod("ПрочитатьВБуферДвоичныхДанных", "ReadToBinaryDataBuffer")]
        public BinaryDataBuffer ReadToBinaryDataBuffer()
        {
            BinaryDataBuffer bdb = ReadToBDB().Result;
            return bdb;
        }

        public Task<BinaryDataBuffer> ReadToBDB()
        {
            return ReadToBuffer();
        }

        public async Task<BinaryDataBuffer> ReadToBuffer()
        {
            BinaryDataBuffer bdb = new BinaryDataBuffer(new byte[0]);
            byte[] Buffer = new byte[1024];
            while (true)
            {
                int bytes = await this.Base_obj.ReadAsync(Buffer, 0, Buffer.Length);
                if (bytes > 0)
                {
                    bdb = bdb.Concat((new BinaryDataBuffer(Buffer)).Read(0, bytes));
                    return bdb;
                }
                return bdb;
            }
        }

        [ContextMethod("ЧитатьБайт", "ReadByte")]
        public int ReadByte()
        {
            return Base_obj.ReadByte();
        }
    }
}
