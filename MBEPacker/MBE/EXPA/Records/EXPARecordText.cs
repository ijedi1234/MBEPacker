using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordText : EXPARecord
    {

        public int ID { get; set; } = 0;
        public string? Text1 { get; set; }
        public string? Text2 { get; set; }
        public string? Text3 { get; set; }
        public string? Text4 { get; set; }
        public string? Text5 { get; set; }
        public string? Text6 { get; set; }

        public EXPARecordText() : base() { }

        public EXPARecordText(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            ID = BitConverter.ToInt32(rawRecord.Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch(cRecord.Offset)
                {
                    case 0x8: Text1 = cRecord.Text; break;
                    case 0x10: Text2 = cRecord.Text; break;
                    case 0x18: Text3 = cRecord.Text; break;
                    case 0x20: Text4 = cRecord.Text; break;
                    case 0x28: Text5 = cRecord.Text; break;
                    case 0x30: Text6 = cRecord.Text; break;
                }
            }
        }

        public EXPARecordText(JsonObject json) : base(json)
        {
            ID = json["ID"].AsValue().GetValue<int>();
            if (json["Text1"] == null) { Text1 = null; } else { Text1 = (string)json["Text1"]; }
            if (json["Text2"] == null) { Text2 = null; } else { Text2 = (string)json["Text2"]; }
            if (json["Text3"] == null) { Text3 = null; } else { Text3 = (string)json["Text3"]; }
            if (json["Text4"] == null) { Text4 = null; } else { Text4 = (string)json["Text4"]; }
            if (json["Text5"] == null) { Text5 = null; } else { Text5 = (string)json["Text5"]; }
            if (json["Text6"] == null) { Text6 = null; } else { Text6 = (string)json["Text6"]; }
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["ID"] = ID;
            json["Text1"] = Text1;
            json["Text2"] = Text2;
            json["Text3"] = Text3;
            json["Text4"] = Text4;
            json["Text5"] = Text5;
            json["Text6"] = Text6;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] bytesID = BitConverter.GetBytes(ID);
            byte[] intermission = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            List<byte> finalList = bytesID.ToList();
            finalList.AddRange(intermission);
            for(int i = 0; i < 6; i++)
            {
                finalList.AddRange(empty8);
            }
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (Text1 != null) list.Add(new CHNKRecord(Text1, 0x8));
            if (Text2 != null) list.Add(new CHNKRecord(Text2, 0x10));
            if (Text3 != null) list.Add(new CHNKRecord(Text3, 0x18));
            if (Text4 != null) list.Add(new CHNKRecord(Text4, 0x20));
            if (Text5 != null) list.Add(new CHNKRecord(Text5, 0x28));
            if (Text6 != null) list.Add(new CHNKRecord(Text6, 0x30));
            return list;
        }

    }
}
