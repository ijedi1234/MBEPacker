using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataBPPosition : EXPARecord
    {
        public int Index { get; set; }
        public byte[] Tiles { get; set; } = new byte[80];

        public EXPARecordDataBPPosition() { }

        public EXPARecordDataBPPosition(byte[] rawRecord) : base(rawRecord)
        {
            Index = BitConverter.ToInt32(rawRecord.Take(sizeof(int)).ToArray());
            Tiles = rawRecord.Skip(0x4).Take(rawRecord.Length - 8).ToArray();
        }

        public EXPARecordDataBPPosition(JsonObject json) : base(json)
        {
            Index = json["Index"].AsValue().GetValue<int>();
            Tiles = json["Tiles"].AsArray().Select(i => (byte)i).ToArray();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Index"] = Index;
            JsonArray jsonArray = new JsonArray();
            foreach (byte tile in Tiles) jsonArray.Add(tile);
            json["Tiles"] = jsonArray;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] ending = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(Index));
            finalList.AddRange(Tiles);
            finalList.AddRange(ending);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            return new List<CHNKRecord>();
        }
    }
}
