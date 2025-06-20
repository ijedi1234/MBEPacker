using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataFieldChapterSelectJumpInfo : EXPARecord
    {

        public int Value1 { get; set; }
        public int JumpType { get; set; }
        public string? Route { get; set; }
        public int Value3 { get; set; }
        public int StoryProgress { get; set; }
        public int MapID { get; set; }
        public string? Text2 { get; set; }
        public string? Text3 { get; set; }

        public EXPARecordDataFieldChapterSelectJumpInfo() : base() { }

        public EXPARecordDataFieldChapterSelectJumpInfo(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            JumpType = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            Value3 = BitConverter.ToInt32(rawRecord.Skip(0x10).Take(sizeof(int)).ToArray());
            StoryProgress = BitConverter.ToInt32(rawRecord.Skip(0x14).Take(sizeof(int)).ToArray());
            MapID = BitConverter.ToInt32(rawRecord.Skip(0x18).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x8: Route = cRecord.Text; break;
                    case 0x20: Text2 = cRecord.Text; break;
                    case 0x28: Text3 = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataFieldChapterSelectJumpInfo(JsonObject json) : base(json)
        {
            Value1 = json["Value1"].AsValue().GetValue<int>();
            JumpType = json["JumpType"].AsValue().GetValue<int>();
            if (json["Route"] == null) { Route = null; } else { Route = (string)json["Route"]; }
            Value3 = json["Value3"].AsValue().GetValue<int>();
            StoryProgress = json["StoryProgress"].AsValue().GetValue<int>();
            MapID = json["MapID"].AsValue().GetValue<int>();
            if (json["Text2"] == null) { Text2 = null; } else { Text2 = (string)json["Text2"]; }
            if (json["Text3"] == null) { Text3 = null; } else { Text3 = (string)json["Text3"]; }
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Value1"] = Value1;
            json["JumpType"] = JumpType;
            json["Route"] = Route;
            json["Value3"] = Value3;
            json["StoryProgress"] = StoryProgress;
            json["MapID"] = MapID;
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
            finalList.AddRange(BitConverter.GetBytes(JumpType));
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value3));
            finalList.AddRange(BitConverter.GetBytes(StoryProgress));
            finalList.AddRange(BitConverter.GetBytes(MapID));
            finalList.AddRange(intermission);
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (Route != null) list.Add(new CHNKRecord(Route, 0x8));
            if (Text2 != null) list.Add(new CHNKRecord(Text2, 0x20));
            if (Text3 != null) list.Add(new CHNKRecord(Text3, 0x28));
            return list;
        }
    }
}
