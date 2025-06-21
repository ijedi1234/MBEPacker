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
        public string? LuaFile { get; set; }
        public int Value1 { get; set; }
        public int MapID { get; set; }
        public string? BGOverlay { get; set; }
        public int DayConditionKey { get; set; }
        public int Value4 { get; set; }
        public string? ProgSetFile { get; set; }
        public string? ProgInfoFile { get; set; }
        public int Day { get; set; }
        public int TimeOfDay { get; set; }
        public int StoryProgress { get; set; }

        public EXPARecordDataEventInfo() : base() { }

        public EXPARecordDataEventInfo(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x8).Take(sizeof(int)).ToArray());
            MapID = BitConverter.ToInt32(rawRecord.Skip(0xC).Take(sizeof(int)).ToArray());
            DayConditionKey = BitConverter.ToInt32(rawRecord.Skip(0x18).Take(sizeof(int)).ToArray());
            Value4 = BitConverter.ToInt32(rawRecord.Skip(0x1C).Take(sizeof(int)).ToArray());
            Day = BitConverter.ToInt32(rawRecord.Skip(0x30).Take(sizeof(int)).ToArray());
            TimeOfDay = BitConverter.ToInt32(rawRecord.Skip(0x34).Take(sizeof(int)).ToArray());
            StoryProgress = BitConverter.ToInt32(rawRecord.Skip(0x38).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x0: LuaFile = cRecord.Text; break;
                    case 0x10: BGOverlay = cRecord.Text; break;
                    case 0x20: ProgSetFile = cRecord.Text; break;
                    case 0x28: ProgInfoFile = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataEventInfo(JsonObject json) : base(json)
        {
            if (json["LuaFile"] == null) { LuaFile = null; } else { LuaFile = (string)json["LuaFile"]; }
            Value1 = json["Value1"].AsValue().GetValue<int>();
            MapID = json["MapID"].AsValue().GetValue<int>();
            if (json["BGOverlay"] == null) { BGOverlay = null; } else { BGOverlay = (string)json["BGOverlay"]; }
            DayConditionKey = json["DayConditionKey"].AsValue().GetValue<int>();
            Value4 = json["Value4"].AsValue().GetValue<int>();
            if (json["ProgSetFile"] == null) { ProgSetFile = null; } else { ProgSetFile = (string)json["ProgSetFile"]; }
            if (json["ProgInfoFile"] == null) { ProgInfoFile = null; } else { ProgInfoFile = (string)json["ProgInfoFile"]; }
            Day = json["Day"].AsValue().GetValue<int>();
            TimeOfDay = json["TimeOfDay"].AsValue().GetValue<int>();
            StoryProgress = json["StoryProgress"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["LuaFile"] = LuaFile;
            json["Value1"] = Value1;
            json["MapID"] = MapID;
            json["BGOverlay"] = BGOverlay;
            json["DayConditionKey"] = DayConditionKey;
            json["Value4"] = Value4;
            json["ProgSetFile"] = ProgSetFile;
            json["ProgInfoFile"] = ProgInfoFile;
            json["Day"] = Day;
            json["TimeOfDay"] = TimeOfDay;
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
            finalList.AddRange(BitConverter.GetBytes(MapID));
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(DayConditionKey));
            finalList.AddRange(BitConverter.GetBytes(Value4));
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Day));
            finalList.AddRange(BitConverter.GetBytes(TimeOfDay));
            finalList.AddRange(BitConverter.GetBytes(StoryProgress));
            finalList.AddRange(ending);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (LuaFile != null) list.Add(new CHNKRecord(LuaFile, 0x0));
            if (BGOverlay != null) list.Add(new CHNKRecord(BGOverlay, 0x10));
            if (ProgSetFile != null) list.Add(new CHNKRecord(ProgSetFile, 0x20));
            if (ProgInfoFile != null) list.Add(new CHNKRecord(ProgInfoFile, 0x28));
            return list;
        }
    }
}
