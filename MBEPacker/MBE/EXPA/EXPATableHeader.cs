using MBEPacker.MBE.EXPA.Records;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA
{
    public class EXPATableHeader
    {

        public int NameSize { get; set; }
        public string Name { get; set; }
        public int RecordLayoutCount { get; set; }
        public List<int> RecordLayout { get; set; } = new List<int>();
        public int RecordSize { get; set; }
        public int NumRecords { get; set; }
        public byte[] Padding { get; set; } = new byte[0];

        public EXPATableHeader(FileStream fStream)
        {
            byte[] bytes4 = new byte[sizeof(int)];
            fStream.Read(bytes4, 0, sizeof(int));
            NameSize = BitConverter.ToInt32(bytes4);
            byte[] bytesName = new byte[NameSize];
            fStream.Read(bytesName, 0, NameSize);
            Name = Encoding.UTF8.GetString(bytesName).Trim('\0');
            fStream.Read(bytes4, 0, sizeof(int));
            RecordLayoutCount = BitConverter.ToInt32(bytes4);
            for (int i = 0; i < RecordLayoutCount; i++)
            {
                fStream.Read(bytes4, 0, sizeof(int));
                RecordLayout.Add(BitConverter.ToInt32(bytes4));
            }
            fStream.Read(bytes4, 0, sizeof(int));
            RecordSize = BitConverter.ToInt32(bytes4);
            if (RecordSize % 8 != 0) RecordSize += 8 - (RecordSize % 8);
            fStream.Read(bytes4, 0, sizeof(int));
            NumRecords = BitConverter.ToInt32(bytes4);
            //Ensure 8 alignment for the end of this section
            if (GetSize() % 8 != 0)
            {
                fStream.Read(bytes4, 0, sizeof(int));
                Padding = bytes4;
            }
        }

        public EXPATableHeader(string name, JsonObject json)
        {
            Name = name;
            NameSize = Multiple4Calculator.RoundUp2MultipleOf4(Name.Length, 1);
            RecordLayout = json["layout"].AsArray().Select(i => (int)i).ToList();
            RecordLayoutCount = RecordLayout.Count;
            RecordSize = EXPARecord.GetExpectedSize(RecordLayout);
            NumRecords = json["records"].AsArray().Count;
            if (GetSize() % 8 != 0) Padding = new byte[] { 0, 0, 0, 0 };
        }

        public int GetSize()
        {
            int size = 0x4;
            size += NameSize;
            size += 0x4;
            size += 0x4 * RecordLayout.Count;
            size += 0x4;
            size += 0x4;
            size += Padding.Length;
            return size;
        }

        public void WriteMBE(FileStream fStream)
        {
            fStream.Write(BitConverter.GetBytes(NameSize), 0, 4);
            byte[] nameBytes = new byte[NameSize];
            Buffer.BlockCopy(Encoding.UTF8.GetBytes(Name), 0, nameBytes, 0, Name.Length);
            fStream.Write(nameBytes, 0, NameSize);
            fStream.Write(BitConverter.GetBytes(RecordLayoutCount), 0, 4);
            foreach(int layoutElement in RecordLayout)
            {
                fStream.Write(BitConverter.GetBytes(layoutElement), 0, 4);
            }
            fStream.Write(BitConverter.GetBytes(RecordSize), 0, 4);
            fStream.Write(BitConverter.GetBytes(NumRecords), 0, 4);
            if(Padding.Length == 4)
                fStream.Write(Padding, 0, 4);
        }
    }
}
