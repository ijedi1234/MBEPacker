using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataBattleSkillAct : EXPARecord
    {
        public int Value1 { get; set; }
        public string? Text1 { get; set; }
        public int Value2 { get; set; }
        public string? Text2 { get; set; }
        public int Value3 { get; set; }
        public string? Text3 { get; set; }
        public string? Text4 { get; set; }
        public int Value4 { get; set; }

        public EXPARecordDataBattleSkillAct() : base() { }

        public EXPARecordDataBattleSkillAct(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            Value2 = BitConverter.ToInt32(rawRecord.Skip(0x10).Take(sizeof(int)).ToArray());
            Value3 = BitConverter.ToInt32(rawRecord.Skip(0x20).Take(sizeof(int)).ToArray());
            Value4 = BitConverter.ToInt32(rawRecord.Skip(0x38).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x8: Text1 = cRecord.Text; break;
                    case 0x18: Text2 = cRecord.Text; break;
                    case 0x28: Text3 = cRecord.Text; break;
                    case 0x30: Text4 = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataBattleSkillAct(JsonObject json) : base(json)
        {
            Value1 = json["Value1"].AsValue().GetValue<int>();
            if (json["Text1"] == null) { Text1 = null; } else { Text1 = (string)json["Text1"]; }
            Value2 = json["Value2"].AsValue().GetValue<int>();
            if (json["Text2"] == null) { Text2 = null; } else { Text2 = (string)json["Text2"]; }
            Value3 = json["Value3"].AsValue().GetValue<int>();
            if (json["Text3"] == null) { Text3 = null; } else { Text3 = (string)json["Text3"]; }
            if (json["Text4"] == null) { Text4 = null; } else { Text4 = (string)json["Text4"]; }
            Value4 = json["Value4"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Value1"] = Value1;
            json["Text1"] = Text1;
            json["Value2"] = Value2;
            json["Text2"] = Text2;
            json["Value3"] = Value3;
            json["Text3"] = Text3;
            json["Text4"] = Text4;
            json["Value4"] = Value4;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] intermission = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(Value1));
            finalList.AddRange(intermission);
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value2));
            finalList.AddRange(intermission);
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value3));
            finalList.AddRange(intermission);
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value4));
            finalList.AddRange(intermission);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (Text1 != null) list.Add(new CHNKRecord(Text1, 0x8));
            if (Text2 != null) list.Add(new CHNKRecord(Text2, 0x18));
            if (Text3 != null) list.Add(new CHNKRecord(Text3, 0x28));
            if (Text4 != null) list.Add(new CHNKRecord(Text4, 0x30));
            return list;
        }

    }
}
