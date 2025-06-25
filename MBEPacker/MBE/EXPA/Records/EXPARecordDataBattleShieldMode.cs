using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataBattleShieldMode : EXPARecord
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }

        public EXPARecordDataBattleShieldMode() : base() { }

        public EXPARecordDataBattleShieldMode(byte[] rawRecord) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            Value2 = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
        }

        public EXPARecordDataBattleShieldMode(JsonObject json) : base(json)
        {
            Value1 = json["Value1"].AsValue().GetValue<int>();
            Value2 = json["Value2"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Value1"] = Value1;
            json["Value2"] = Value2;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(Value1));
            finalList.AddRange(BitConverter.GetBytes(Value2));
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            return new List<CHNKRecord>();
        }
    }
}
