using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataEventProgressSet : EXPARecord
    {

        public int Value1 { get; set; }
        public int Day { get; set; }
        public int Value3 { get; set; }
        public int Value4 { get; set; }
        public int Value5 { get; set; }
        public int SmallValue1 { get; set; }
        public int CharID { get; set; }
        public int Value7 { get; set; }
        public string? RefID1 { get; set; }
        public string? RefID2 { get; set; }
        public int Value8 { get; set; }
        public int Value9 { get; set; }
        public int SmallValue2 { get; set; }
        public int Value10 { get; set; }

        public EXPARecordDataEventProgressSet() : base() { }

        public EXPARecordDataEventProgressSet(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            Day = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            Value3 = BitConverter.ToInt32(rawRecord.Skip(0x8).Take(sizeof(int)).ToArray());
            Value4 = BitConverter.ToInt32(rawRecord.Skip(0xC).Take(sizeof(int)).ToArray());
            Value5 = BitConverter.ToInt32(rawRecord.Skip(0x10).Take(sizeof(int)).ToArray());
            SmallValue1 = BitConverter.ToInt32(rawRecord.Skip(0x14).Take(sizeof(int)).ToArray());
            CharID = BitConverter.ToInt32(rawRecord.Skip(0x18).Take(sizeof(int)).ToArray());
            Value7 = BitConverter.ToInt32(rawRecord.Skip(0x1C).Take(sizeof(int)).ToArray());
            Value8 = BitConverter.ToInt32(rawRecord.Skip(0x30).Take(sizeof(int)).ToArray());
            Value9 = BitConverter.ToInt32(rawRecord.Skip(0x34).Take(sizeof(int)).ToArray());
            SmallValue2 = BitConverter.ToInt32(rawRecord.Skip(0x38).Take(sizeof(int)).ToArray());
            Value10 = BitConverter.ToInt32(rawRecord.Skip(0x3C).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x20: RefID1 = cRecord.Text; break;
                    case 0x28: RefID2 = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataEventProgressSet(JsonObject json) : base(json)
        {
            Value1 = json["Value1"].AsValue().GetValue<int>();
            Day = json["Day"].AsValue().GetValue<int>();
            Value3 = json["Value3"].AsValue().GetValue<int>();
            Value4 = json["Value4"].AsValue().GetValue<int>();
            Value5 = json["Value5"].AsValue().GetValue<int>();
            SmallValue1 = json["SmallValue1"].AsValue().GetValue<int>();
            CharID = json["CharID"].AsValue().GetValue<int>();
            Value7 = json["Value7"].AsValue().GetValue<int>();
            if (json["RefID1"] == null) { RefID1 = null; } else { RefID1 = (string)json["RefID1"]; }
            if (json["RefID2"] == null) { RefID2 = null; } else { RefID2 = (string)json["RefID2"]; }
            Value8 = json["Value8"].AsValue().GetValue<int>();
            Value9 = json["Value9"].AsValue().GetValue<int>();
            SmallValue2 = json["SmallValue2"].AsValue().GetValue<int>();
            Value10 = json["Value10"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Value1"] = Value1;
            json["Day"] = Day;
            json["Value3"] = Value3;
            json["Value4"] = Value4;
            json["Value5"] = Value5;
            json["SmallValue1"] = SmallValue1;
            json["CharID"] = CharID;
            json["Value7"] = Value7;
            json["RefID1"] = RefID1;
            json["RefID2"] = RefID2;
            json["Value8"] = Value8;
            json["Value9"] = Value9;
            json["SmallValue2"] = SmallValue2;
            json["Value10"] = Value10;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] ending = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(Value1));
            finalList.AddRange(BitConverter.GetBytes(Day));
            finalList.AddRange(BitConverter.GetBytes(Value3));
            finalList.AddRange(BitConverter.GetBytes(Value4));
            finalList.AddRange(BitConverter.GetBytes(Value5));
            finalList.AddRange(BitConverter.GetBytes(SmallValue1));
            finalList.AddRange(BitConverter.GetBytes(CharID));
            finalList.AddRange(BitConverter.GetBytes(Value7));
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value8));
            finalList.AddRange(BitConverter.GetBytes(Value9));
            finalList.AddRange(BitConverter.GetBytes(SmallValue2));
            finalList.AddRange(BitConverter.GetBytes(Value10));
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (RefID1 != null) list.Add(new CHNKRecord(RefID1, 0x20));
            if (RefID2 != null) list.Add(new CHNKRecord(RefID2, 0x28));
            return list;
        }

    }
}
