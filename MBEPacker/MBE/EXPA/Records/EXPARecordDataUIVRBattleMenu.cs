using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataUIVRBattleMenu : EXPARecord
    {

        public int Value1 { get; set; }
        public int BattleID { get; set; }
        public int Value3 { get; set; }
        public int Difficulty { get; set; }
        public int Value5 { get; set; }
        public int Value6 { get; set; }
        public string? Text1 { get; set; }
        public int Value7 { get; set; }

        public EXPARecordDataUIVRBattleMenu() { }

        public EXPARecordDataUIVRBattleMenu(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            BattleID = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            Value3 = BitConverter.ToInt32(rawRecord.Skip(0x8).Take(sizeof(int)).ToArray());
            Difficulty = BitConverter.ToInt32(rawRecord.Skip(0xC).Take(sizeof(int)).ToArray());
            Value5 = BitConverter.ToInt32(rawRecord.Skip(0x10).Take(sizeof(int)).ToArray());
            Value6 = BitConverter.ToInt32(rawRecord.Skip(0x14).Take(sizeof(int)).ToArray());
            Value7 = BitConverter.ToInt32(rawRecord.Skip(0x20).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x18: Text1 = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataUIVRBattleMenu(JsonObject json) : base(json)
        {
            Value1 = json["Value1"].AsValue().GetValue<int>();
            BattleID = json["BattleID"].AsValue().GetValue<int>();
            Value3 = json["Value3"].AsValue().GetValue<int>();
            Difficulty = json["Difficulty"].AsValue().GetValue<int>();
            Value5 = json["Value5"].AsValue().GetValue<int>();
            Value6 = json["Value6"].AsValue().GetValue<int>();
            if (json["Text1"] == null) { Text1 = null; } else { Text1 = (string)json["Text1"]; }
            Value7 = json["Value7"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Value1"] = Value1;
            json["BattleID"] = BattleID;
            json["Value3"] = Value3;
            json["Difficulty"] = Difficulty;
            json["Value5"] = Value5;
            json["Value6"] = Value6;
            json["Text1"] = Text1;
            json["Value7"] = Value7;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] ending = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(Value1));
            finalList.AddRange(BitConverter.GetBytes(BattleID));
            finalList.AddRange(BitConverter.GetBytes(Value3));
            finalList.AddRange(BitConverter.GetBytes(Difficulty));
            finalList.AddRange(BitConverter.GetBytes(Value5));
            finalList.AddRange(BitConverter.GetBytes(Value6));
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value7));
            finalList.AddRange(ending);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (Text1 != null) list.Add(new CHNKRecord(Text1, 0x18));
            return list;
        }

    }
}
