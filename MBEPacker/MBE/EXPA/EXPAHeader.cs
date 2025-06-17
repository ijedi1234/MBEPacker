using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA
{
    public class EXPAHeader
    {

        public string MagicNumber { get; set; } = "EXPA";
        public int NumTables { get; set; }

        public EXPAHeader(FileStream fStream)
        {
            byte[] bytes4 = new byte[sizeof(int)];
            fStream.Read(bytes4, 0, sizeof(int));
            MagicNumber = Encoding.UTF8.GetString(bytes4);
            fStream.Read(bytes4, 0, sizeof(int));
            NumTables = BitConverter.ToInt32(bytes4);
        }

        public EXPAHeader(JsonObject json)
        {
            NumTables = json.Count;
        }

        public int GetSize() { return 0x8; }

        public void WriteMBE(FileStream fStream)
        {
            fStream.Write(Encoding.UTF8.GetBytes(MagicNumber), 0, 4);
            fStream.Write(BitConverter.GetBytes(NumTables), 0, 4);
        }
    }
}
