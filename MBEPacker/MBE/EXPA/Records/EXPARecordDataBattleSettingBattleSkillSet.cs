using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataBattleSettingBattleSkillSet : EXPARecord
    {
        public static int INDEX_COUNTER = 1;

        public int Index { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
        public int Value4 { get; set; }
        public int Value5 { get; set; }
        public int Value6 { get; set; }
        public int Value7 { get; set; }
        public int Value8 { get; set; }
        public string? Text1 { get; set; }

        public EXPARecordDataBattleSettingBattleSkillSet() : base() { }

        public EXPARecordDataBattleSettingBattleSkillSet(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            Index = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            Value2 = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            Value3 = BitConverter.ToInt32(rawRecord.Skip(0x8).Take(sizeof(int)).ToArray());
            Value4 = BitConverter.ToInt32(rawRecord.Skip(0xC).Take(sizeof(int)).ToArray());
            Value5 = BitConverter.ToInt32(rawRecord.Skip(0x10).Take(sizeof(int)).ToArray());
            Value6 = BitConverter.ToInt32(rawRecord.Skip(0x14).Take(sizeof(int)).ToArray());
            Value7 = BitConverter.ToInt32(rawRecord.Skip(0x18).Take(sizeof(int)).ToArray());
            Value8 = BitConverter.ToInt32(rawRecord.Skip(0x1C).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x20: Text1 = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataBattleSettingBattleSkillSet(JsonObject json) : base(json)
        {
            Index = INDEX_COUNTER; INDEX_COUNTER++;
            Value2 = json["Value2"].AsValue().GetValue<int>();
            Value3 = json["Value3"].AsValue().GetValue<int>();
            Value4 = json["Value4"].AsValue().GetValue<int>();
            Value5 = json["Value5"].AsValue().GetValue<int>();
            Value6 = json["Value6"].AsValue().GetValue<int>();
            Value7 = json["Value7"].AsValue().GetValue<int>();
            Value8 = json["Value8"].AsValue().GetValue<int>();
            if (json["Text1"] == null) { Text1 = null; } else { Text1 = (string)json["Text1"]; }
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Index"] = Index;
            json["Value2"] = Value2;
            json["Value3"] = Value3;
            json["Value4"] = Value4;
            json["Value5"] = Value5;
            json["Value6"] = Value6;
            json["Value7"] = Value7;
            json["Value8"] = Value8;
            json["Text1"] = Text1;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(Index));
            finalList.AddRange(BitConverter.GetBytes(Value2));
            finalList.AddRange(BitConverter.GetBytes(Value3));
            finalList.AddRange(BitConverter.GetBytes(Value4));
            finalList.AddRange(BitConverter.GetBytes(Value5));
            finalList.AddRange(BitConverter.GetBytes(Value6));
            finalList.AddRange(BitConverter.GetBytes(Value7));
            finalList.AddRange(BitConverter.GetBytes(Value8));
            finalList.AddRange(empty8);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (Text1 != null) list.Add(new CHNKRecord(Text1, 0x20));
            return list;
        }
    }
}
