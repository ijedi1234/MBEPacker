using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordMessage : EXPARecord
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string? Text1 { get; set; }
        public string? Text2 { get; set; }
        public string? Text3 { get; set; }
        public string? Text4 { get; set; }
        public string? Text5 { get; set; }
        public string? Text6 { get; set; }
        public string? Text7 { get; set; }
        public string? Text8 { get; set; }
        public string? Text9 { get; set; }
        public string? Text10 { get; set; }

        public EXPARecordMessage() : base() { }

        public EXPARecordMessage(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            Value2 = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x8: Text1 = cRecord.Text; break;
                    case 0x10: Text2 = cRecord.Text; break;
                    case 0x18: Text3 = cRecord.Text; break;
                    case 0x20: Text4 = cRecord.Text; break;
                    case 0x28: Text5 = cRecord.Text; break;
                    case 0x30: Text6 = cRecord.Text; break;
                    case 0x38: Text7 = cRecord.Text; break;
                    case 0x40: Text8 = cRecord.Text; break;
                    case 0x48: Text9 = cRecord.Text; break;
                    case 0x50: Text10 = cRecord.Text; break;
                }
            }
        }

        public EXPARecordMessage(JsonObject json) : base(json)
        {
            Value1 = json["Value1"].AsValue().GetValue<int>();
            Value2 = json["Value2"].AsValue().GetValue<int>();
            if (json["Text1"] == null) { Text1 = null; } else { Text1 = (string)json["Text1"]; }
            if (json["Text2"] == null) { Text2 = null; } else { Text2 = (string)json["Text2"]; }
            if (json["Text3"] == null) { Text3 = null; } else { Text3 = (string)json["Text3"]; }
            if (json["Text4"] == null) { Text4 = null; } else { Text4 = (string)json["Text4"]; }
            if (json["Text5"] == null) { Text5 = null; } else { Text5 = (string)json["Text5"]; }
            if (json["Text6"] == null) { Text6 = null; } else { Text6 = (string)json["Text6"]; }
            if (json["Text7"] == null) { Text6 = null; } else { Text6 = (string)json["Text7"]; }
            if (json["Text8"] == null) { Text6 = null; } else { Text6 = (string)json["Text8"]; }
            if (json["Text9"] == null) { Text6 = null; } else { Text6 = (string)json["Text9"]; }
            if (json["Text10"] == null) { Text6 = null; } else { Text6 = (string)json["Text10"]; }
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Value1"] = Value1;
            json["Value2"] = Value2;
            json["Text1"] = Text1;
            json["Text2"] = Text2;
            json["Text3"] = Text3;
            json["Text4"] = Text4;
            json["Text5"] = Text5;
            json["Text6"] = Text6;
            json["Text7"] = Text7;
            json["Text8"] = Text8;
            json["Text9"] = Text9;
            json["Text10"] = Text10;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            List<byte> finalList = new List<byte>();
            byte[] intermission = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            finalList.AddRange(BitConverter.GetBytes(Value1));
            finalList.AddRange(BitConverter.GetBytes(Value2));
            for (int i = 0; i < 10; i++)
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
            if (Text7 != null) list.Add(new CHNKRecord(Text7, 0x38));
            if (Text8 != null) list.Add(new CHNKRecord(Text8, 0x40));
            if (Text9 != null) list.Add(new CHNKRecord(Text9, 0x48));
            if (Text10 != null) list.Add(new CHNKRecord(Text10, 0x50));
            return list;
        }

    }
}
