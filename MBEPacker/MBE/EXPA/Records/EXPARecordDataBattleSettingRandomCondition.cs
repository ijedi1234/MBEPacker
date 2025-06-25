using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataBattleSettingRandomCondition : EXPARecord
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
        public int Value4 { get; set; }

        public EXPARecordDataBattleSettingRandomCondition() : base() { }

        public EXPARecordDataBattleSettingRandomCondition(byte[] rawRecord) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            Value2 = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            Value3 = BitConverter.ToInt32(rawRecord.Skip(0x8).Take(sizeof(int)).ToArray());
            Value4 = BitConverter.ToInt32(rawRecord.Skip(0xC).Take(sizeof(int)).ToArray());
        }

        public EXPARecordDataBattleSettingRandomCondition(JsonObject json) : base(json)
        {
            Value1 = json["Value1"].AsValue().GetValue<int>();
            Value2 = json["Value2"].AsValue().GetValue<int>();
            Value3 = json["Value3"].AsValue().GetValue<int>();
            Value4 = json["Value4"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Value1"] = Value1;
            json["Value2"] = Value2;
            json["Value3"] = Value3;
            json["Value4"] = Value4;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(Value1));
            finalList.AddRange(BitConverter.GetBytes(Value2));
            finalList.AddRange(BitConverter.GetBytes(Value3));
            finalList.AddRange(BitConverter.GetBytes(Value4));
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            return new List<CHNKRecord>();
        }
    }
}
