using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataBPLotteryGroupID : EXPARecord
    {

        public int Index { get; set; }
        public int PlaceID { get; set; }
        public int UnitID { get; set; }
        public int Value4 { get; set; }
        public int Value5 { get; set; }

        public EXPARecordDataBPLotteryGroupID() { }

        public EXPARecordDataBPLotteryGroupID(byte[] rawRecord) : base(rawRecord)
        {
            Index = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            PlaceID = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            UnitID = BitConverter.ToInt32(rawRecord.Skip(0x8).Take(sizeof(int)).ToArray());
            Value4 = BitConverter.ToInt32(rawRecord.Skip(0xC).Take(sizeof(int)).ToArray());
            Value5 = BitConverter.ToInt32(rawRecord.Skip(0x10).Take(sizeof(int)).ToArray());
        }

        public EXPARecordDataBPLotteryGroupID(JsonObject json) : base(json)
        {
            Index = json["Index"].AsValue().GetValue<int>();
            PlaceID = json["PlaceID"].AsValue().GetValue<int>();
            UnitID = json["UnitID"].AsValue().GetValue<int>();
            Value4 = json["Value4"].AsValue().GetValue<int>();
            Value5 = json["Value5"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Index"] = Index;
            json["PlaceID"] = PlaceID;
            json["UnitID"] = UnitID;
            json["Value4"] = Value4;
            json["Value5"] = Value5;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] ending = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(Index));
            finalList.AddRange(BitConverter.GetBytes(PlaceID));
            finalList.AddRange(BitConverter.GetBytes(UnitID));
            finalList.AddRange(BitConverter.GetBytes(Value4));
            finalList.AddRange(BitConverter.GetBytes(Value5));
            finalList.AddRange(ending);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            return new List<CHNKRecord>();
        }
    }
}
