﻿using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataBattleSettingConditionEffect : EXPARecord
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
        public int Value4 { get; set; }
        public int Value5 { get; set; }
        public int Value6 { get; set; }
        public int Value7 { get; set; }
        public int Value8 { get; set; }
        public int Value9 { get; set; }
        public string? Text1 { get; set; }
        public string? Text2 { get; set; }
        public string? Text3 { get; set; }

        public EXPARecordDataBattleSettingConditionEffect() : base() { }

        public EXPARecordDataBattleSettingConditionEffect(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            Value2 = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            Value3 = BitConverter.ToInt32(rawRecord.Skip(0x8).Take(sizeof(int)).ToArray());
            Value4 = BitConverter.ToInt32(rawRecord.Skip(0xC).Take(sizeof(int)).ToArray());
            Value5 = BitConverter.ToInt32(rawRecord.Skip(0x10).Take(sizeof(int)).ToArray());
            Value6 = BitConverter.ToInt32(rawRecord.Skip(0x14).Take(sizeof(int)).ToArray());
            Value7 = BitConverter.ToInt32(rawRecord.Skip(0x18).Take(sizeof(int)).ToArray());
            Value8 = BitConverter.ToInt32(rawRecord.Skip(0x1C).Take(sizeof(int)).ToArray());
            Value9 = BitConverter.ToInt32(rawRecord.Skip(0x20).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x28: Text1 = cRecord.Text; break;
                    case 0x30: Text2 = cRecord.Text; break;
                    case 0x38: Text3 = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataBattleSettingConditionEffect(JsonObject json) : base(json)
        {
            Value1 = json["Value1"].AsValue().GetValue<int>();
            Value2 = json["Value2"].AsValue().GetValue<int>();
            Value3 = json["Value3"].AsValue().GetValue<int>();
            Value4 = json["Value4"].AsValue().GetValue<int>();
            Value5 = json["Value5"].AsValue().GetValue<int>();
            Value6 = json["Value6"].AsValue().GetValue<int>();
            Value7 = json["Value7"].AsValue().GetValue<int>();
            Value8 = json["Value8"].AsValue().GetValue<int>();
            Value9 = json["Value9"].AsValue().GetValue<int>();
            if (json["Text1"] == null) { Text1 = null; } else { Text1 = (string)json["Text1"]; }
            if (json["Text2"] == null) { Text2 = null; } else { Text2 = (string)json["Text2"]; }
            if (json["Text3"] == null) { Text3 = null; } else { Text3 = (string)json["Text3"]; }
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Value1"] = Value1;
            json["Value2"] = Value2;
            json["Value3"] = Value3;
            json["Value4"] = Value4;
            json["Value5"] = Value5;
            json["Value6"] = Value6;
            json["Value7"] = Value7;
            json["Value8"] = Value8;
            json["Value9"] = Value9;
            json["Text1"] = Text1;
            json["Text2"] = Text2;
            json["Text3"] = Text3;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] intermission = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(Value1));
            finalList.AddRange(BitConverter.GetBytes(Value2));
            finalList.AddRange(BitConverter.GetBytes(Value3));
            finalList.AddRange(BitConverter.GetBytes(Value4));
            finalList.AddRange(BitConverter.GetBytes(Value5));
            finalList.AddRange(BitConverter.GetBytes(Value6));
            finalList.AddRange(BitConverter.GetBytes(Value7));
            finalList.AddRange(BitConverter.GetBytes(Value8));
            finalList.AddRange(BitConverter.GetBytes(Value9));
            finalList.AddRange(intermission);
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (Text1 != null) list.Add(new CHNKRecord(Text1, 0x28));
            if (Text2 != null) list.Add(new CHNKRecord(Text2, 0x30));
            if (Text3 != null) list.Add(new CHNKRecord(Text3, 0x38));
            return list;
        }
    }
}
