using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary1
{
    public enum PacketType {
        Expand = 0,
        Select,
        ConnectEnd,
        setPlus,
        setInfo,
        filesend

    }
    public enum PacketSendERROR {
        정상 = 0,
        에러
    }

    [Serializable]
    public class Packet {
        public int Length;
        public int Type;
        public string nextpath;
        public DirectoryInfo dir;
        public DirectoryInfo[] di;
        public FileInfo[] sfa;
        public string name;
        public string fileType;
        public string locate;
        public int size;
        public DateTime createDay;
        public DateTime modifyDay;
        public DateTime accessDay;

        public string savepath;

        public Packet() {
            this.Length = 0;
            this.Type = 0;
            this.nextpath = "";
            this.dir = null;
            this.di = null;
            this.sfa = null;
            name = "";
            fileType = "";
            size = 0;
            locate = "";
            savepath = "";
        }

        public static byte[] Serialize(Object o) {
            MemoryStream ms = new MemoryStream(1024*4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Desserialize(byte[] bt) {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt) {
                ms.WriteByte(b);
            }
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }


    public class Class1
    {
    }

}
