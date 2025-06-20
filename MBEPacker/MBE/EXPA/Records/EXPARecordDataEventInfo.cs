using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataEventInfo : EXPARecord
    {
        public string? RefID1 { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string? RefID2 { get; set; }
        public int Value3 { get; set; }
        public int Value4 { get; set; }
        public string? RefID3 { get; set; }
        public string? RefID4 { get; set; }
        public int Day { get; set; }
        public int Value6 { get; set; }
        public int StoryProgress { get; set; }

        public EXPARecordDataEventInfo() : base() { }

        public EXPARecordDataEventInfo(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x8).Take(sizeof(int)).ToArray());
            Value2 = BitConverter.ToInt32(rawRecord.Skip(0xC).Take(sizeof(int)).ToArray());
            Value3 = BitConverter.ToInt32(rawRecord.Skip(0x18).Take(sizeof(int)).ToArray());
            Value4 = BitConverter.ToInt32(rawRecord.Skip(0x1C).Take(sizeof(int)).ToArray());
            Day = BitConverter.ToInt32(rawRecord.Skip(0x30).Take(sizeof(int)).ToArray());
            Value6 = BitConverter.ToInt32(rawRecord.Skip(0x34).Take(sizeof(int)).ToArray());
            StoryProgress = BitConverter.ToInt32(rawRecord.Skip(0x38).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x0: RefID1 = cRecord.Text; break;
                    case 0x10: RefID2 = cRecord.Text; break;
                    case 0x20: RefID3 = cRecord.Text; break;
                    case 0x28: RefID4 = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataEventInfo(JsonObject json) : base(json)
        {
            if (json["RefID1"] == null) { RefID1 = null; } else { RefID1 = (string)json["RefID1"]; }
            Value1 = json["Value1"].AsValue().GetValue<int>();
            Value2 = json["Value2"].AsValue().GetValue<int>();
            if (json["RefID2"] == null) { RefID2 = null; } else { RefID2 = (string)json["RefID2"]; }
            Value3 = json["Value3"].AsValue().GetValue<int>();
            Value4 = json["Value4"].AsValue().GetValue<int>();
            if (json["RefID3"] == null) { RefID3 = null; } else { RefID3 = (string)json["RefID3"]; }
            if (json["RefID4"] == null) { RefID4 = null; } else { RefID4 = (string)json["RefID4"]; }
            Day = json["Day"].AsValue().GetValue<int>();
            Value6 = json["Value6"].AsValue().GetValue<int>();
            StoryProgress = json["StoryProgress"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["RefID1"] = RefID1;
            json["Value1"] = Value1;
            json["Value2"] = Value2;
            json["RefID2"] = RefID2;
            json["Value3"] = Value3;
            json["Value4"] = Value4;
            json["RefID3"] = RefID3;
            json["RefID4"] = RefID4;
            json["Day"] = Day;
            json["Value6"] = Value6;
            json["StoryProgress"] = StoryProgress;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] bytesID = BitConverter.GetBytes(Value1);
            byte[] ending = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value1));
            finalList.AddRange(BitConverter.GetBytes(Value2));
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value3));
            finalList.AddRange(BitConverter.GetBytes(Value4));
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Day));
            finalList.AddRange(BitConverter.GetBytes(Value6));
            finalList.AddRange(BitConverter.GetBytes(StoryProgress));
            finalList.AddRange(ending);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (RefID1 != null) list.Add(new CHNKRecord(RefID1, 0x0));
            if (RefID2 != null) list.Add(new CHNKRecord(RefID2, 0x10));
            if (RefID3 != null) list.Add(new CHNKRecord(RefID3, 0x20));
            if (RefID4 != null) list.Add(new CHNKRecord(RefID4, 0x28));
            return list;
        }
    }
}
