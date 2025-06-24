using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataBPPlaceID : EXPARecord
    {

        public int PlaceID { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
        public int LotteryID { get; set; }
        public int TurnBeginMove { get; set; }
        public int TurnsReinforce { get; set; }
        public int DefendID { get; set; }

        public EXPARecordDataBPPlaceID() { }

        public EXPARecordDataBPPlaceID(byte[] rawRecord) : base(rawRecord)
        {
            PlaceID = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            Value2 = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            Value3 = BitConverter.ToInt32(rawRecord.Skip(0x8).Take(sizeof(int)).ToArray());
            LotteryID = BitConverter.ToInt32(rawRecord.Skip(0xC).Take(sizeof(int)).ToArray());
            TurnBeginMove = BitConverter.ToInt32(rawRecord.Skip(0x10).Take(sizeof(int)).ToArray());
            TurnsReinforce = BitConverter.ToInt32(rawRecord.Skip(0x14).Take(sizeof(int)).ToArray());
            DefendID = BitConverter.ToInt32(rawRecord.Skip(0x18).Take(sizeof(int)).ToArray());
        }

        public EXPARecordDataBPPlaceID(JsonObject json) : base(json)
        {
            PlaceID = json["PlaceID"].AsValue().GetValue<int>();
            Value2 = json["Value2"].AsValue().GetValue<int>();
            Value3 = json["Value3"].AsValue().GetValue<int>();
            LotteryID = json["LotteryID"].AsValue().GetValue<int>();
            TurnBeginMove = json["TurnBeginMove"].AsValue().GetValue<int>();
            TurnsReinforce = json["TurnsReinforce"].AsValue().GetValue<int>();
            DefendID = json["DefendID"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["PlaceID"] = PlaceID;
            json["Value2"] = Value2;
            json["Value3"] = Value3;
            json["LotteryID"] = LotteryID;
            json["TurnBeginMove"] = TurnBeginMove;
            json["TurnsReinforce"] = TurnsReinforce;
            json["DefendID"] = DefendID;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] ending = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(PlaceID));
            finalList.AddRange(BitConverter.GetBytes(Value2));
            finalList.AddRange(BitConverter.GetBytes(Value3));
            finalList.AddRange(BitConverter.GetBytes(LotteryID));
            finalList.AddRange(BitConverter.GetBytes(TurnBeginMove));
            finalList.AddRange(BitConverter.GetBytes(TurnsReinforce));
            finalList.AddRange(BitConverter.GetBytes(DefendID));
            finalList.AddRange(ending);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            return new List<CHNKRecord>();
        }
    }
}
