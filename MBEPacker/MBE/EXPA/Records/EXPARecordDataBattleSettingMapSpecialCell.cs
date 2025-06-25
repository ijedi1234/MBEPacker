using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataBattleSettingMapSpecialCell : EXPARecord
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string? Text1 { get; set; }

        public EXPARecordDataBattleSettingMapSpecialCell() : base() { }

        public EXPARecordDataBattleSettingMapSpecialCell(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            Value2 = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x8: Text1 = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataBattleSettingMapSpecialCell(JsonObject json) : base(json)
        {
            Value1 = json["Value1"].AsValue().GetValue<int>();
            Value2 = json["Value2"].AsValue().GetValue<int>();
            if (json["Text1"] == null) { Text1 = null; } else { Text1 = (string)json["Text1"]; }
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Value1"] = Value1;
            json["Value2"] = Value2;
            json["Text1"] = Text1;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(Value1));
            finalList.AddRange(BitConverter.GetBytes(Value2));
            finalList.AddRange(empty8);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (Text1 != null) list.Add(new CHNKRecord(Text1, 0x8));
            return list;
        }
    }
}
