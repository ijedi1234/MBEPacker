using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataBattleID : EXPARecord
    {

        public int ID { get; set; }
        public int MapID { get; set; }
        public int PlayerMovesFirst { get; set; }
        public int Value4 { get; set; }
        public string? BPFile { get; set; }
        public string? LuaFile { get; set; }
        public int Value5 { get; set; }
        public int Win1ID { get; set; }
        public int Lose1ID { get; set; }
        public int Win2ID { get; set; }
        public int Lose2ID { get; set; }
        public int Win3ID { get; set; }
        public int Lose3ID { get; set; }
        public int Win4ID { get; set; }
        public int Lose4ID { get; set; }
        public int DontShowResults { get; set; }
        public int Value15 { get; set; }
        public int Value16 { get; set; }
        public int Value17 { get; set; }
        public int Value18 { get; set; }
        public int Value19 { get; set; }
        public int BPGain { get; set; }
        public int ExplFlag { get; set; }
        public int Value22 { get; set; }
        public int AP { get; set; }
        public int Value24 { get; set; }
        public int Value25 { get; set; }
        public int Value26 { get; set; }
        public int Value27 { get; set; }


        public EXPARecordDataBattleID() { }

        public EXPARecordDataBattleID(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            ID = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            MapID = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            PlayerMovesFirst = BitConverter.ToInt32(rawRecord.Skip(0x8).Take(sizeof(int)).ToArray());
            Value4 = BitConverter.ToInt32(rawRecord.Skip(0xC).Take(sizeof(int)).ToArray());
            Value5 = BitConverter.ToInt32(rawRecord.Skip(0x20).Take(sizeof(int)).ToArray());
            Win1ID = BitConverter.ToInt32(rawRecord.Skip(0x24).Take(sizeof(int)).ToArray());
            Lose1ID = BitConverter.ToInt32(rawRecord.Skip(0x28).Take(sizeof(int)).ToArray());
            Win2ID = BitConverter.ToInt32(rawRecord.Skip(0x2C).Take(sizeof(int)).ToArray());
            Lose2ID = BitConverter.ToInt32(rawRecord.Skip(0x30).Take(sizeof(int)).ToArray());
            Win3ID = BitConverter.ToInt32(rawRecord.Skip(0x34).Take(sizeof(int)).ToArray());
            Lose3ID = BitConverter.ToInt32(rawRecord.Skip(0x38).Take(sizeof(int)).ToArray());
            Win4ID = BitConverter.ToInt32(rawRecord.Skip(0x3C).Take(sizeof(int)).ToArray());
            Lose4ID = BitConverter.ToInt32(rawRecord.Skip(0x40).Take(sizeof(int)).ToArray());
            DontShowResults = BitConverter.ToInt32(rawRecord.Skip(0x44).Take(sizeof(int)).ToArray());
            Value15 = BitConverter.ToInt32(rawRecord.Skip(0x48).Take(sizeof(int)).ToArray());
            Value16 = BitConverter.ToInt32(rawRecord.Skip(0x4C).Take(sizeof(int)).ToArray());
            Value17 = BitConverter.ToInt32(rawRecord.Skip(0x50).Take(sizeof(int)).ToArray());
            Value18 = BitConverter.ToInt32(rawRecord.Skip(0x54).Take(sizeof(int)).ToArray());
            Value19 = BitConverter.ToInt32(rawRecord.Skip(0x58).Take(sizeof(int)).ToArray());
            BPGain = BitConverter.ToInt32(rawRecord.Skip(0x5C).Take(sizeof(int)).ToArray());
            ExplFlag = BitConverter.ToInt32(rawRecord.Skip(0x60).Take(sizeof(int)).ToArray());
            Value22 = BitConverter.ToInt32(rawRecord.Skip(0x64).Take(sizeof(int)).ToArray());
            AP = BitConverter.ToInt32(rawRecord.Skip(0x68).Take(sizeof(int)).ToArray());
            Value24 = BitConverter.ToInt32(rawRecord.Skip(0x6C).Take(sizeof(int)).ToArray());
            Value25 = BitConverter.ToInt32(rawRecord.Skip(0x70).Take(sizeof(int)).ToArray());
            Value26 = BitConverter.ToInt32(rawRecord.Skip(0x74).Take(sizeof(int)).ToArray());
            Value27 = BitConverter.ToInt32(rawRecord.Skip(0x78).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x10: BPFile = cRecord.Text; break;
                    case 0x18: LuaFile = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataBattleID(JsonObject json) : base(json)
        {
            ID = json["ID"].AsValue().GetValue<int>();
            MapID = json["MapID"].AsValue().GetValue<int>();
            PlayerMovesFirst = json["PlayerMovesFirst"].AsValue().GetValue<int>();
            Value4 = json["Value4"].AsValue().GetValue<int>();
            if (json["BPFile"] == null) { BPFile = null; } else { BPFile = (string)json["BPFile"]; }
            if (json["LuaFile"] == null) { LuaFile = null; } else { LuaFile = (string)json["LuaFile"]; }
            Value5 = json["Value5"].AsValue().GetValue<int>();
            Win1ID = json["Win1ID"].AsValue().GetValue<int>();
            Lose1ID = json["Lose1ID"].AsValue().GetValue<int>();
            Win2ID = json["Win2ID"].AsValue().GetValue<int>();
            Lose2ID = json["Lose2ID"].AsValue().GetValue<int>();
            Win3ID = json["Win3ID"].AsValue().GetValue<int>();
            Lose3ID = json["Lose3ID"].AsValue().GetValue<int>();
            Win4ID = json["Win4ID"].AsValue().GetValue<int>();
            Lose4ID = json["Lose4ID"].AsValue().GetValue<int>();
            DontShowResults = json["DontShowResults"].AsValue().GetValue<int>();
            Value15 = json["Value15"].AsValue().GetValue<int>();
            Value16 = json["Value16"].AsValue().GetValue<int>();
            Value17 = json["Value17"].AsValue().GetValue<int>();
            Value18 = json["Value18"].AsValue().GetValue<int>();
            Value19 = json["Value19"].AsValue().GetValue<int>();
            BPGain = json["BPGain"].AsValue().GetValue<int>();
            ExplFlag = json["ExplFlag"].AsValue().GetValue<int>();
            Value22 = json["Value22"].AsValue().GetValue<int>();
            AP = json["AP"].AsValue().GetValue<int>();
            Value24 = json["Value24"].AsValue().GetValue<int>();
            Value25 = json["Value25"].AsValue().GetValue<int>();
            Value26 = json["Value26"].AsValue().GetValue<int>();
            Value27 = json["Value27"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["ID"] = ID;
            json["MapID"] = MapID;
            json["PlayerMovesFirst"] = PlayerMovesFirst;
            json["Value4"] = Value4;
            json["BPFile"] = BPFile;
            json["LuaFile"] = LuaFile;
            json["Value5"] = Value5;
            json["Win1ID"] = Win1ID;
            json["Lose1ID"] = Lose1ID;
            json["Win2ID"] = Win2ID;
            json["Lose2ID"] = Lose2ID;
            json["Win3ID"] = Win3ID;
            json["Lose3ID"] = Lose3ID;
            json["Win4ID"] = Win4ID;
            json["Lose4ID"] = Lose4ID;
            json["DontShowResults"] = DontShowResults;
            json["Value15"] = Value15;
            json["Value16"] = Value16;
            json["Value17"] = Value17;
            json["Value18"] = Value18;
            json["Value19"] = Value19;
            json["BPGain"] = BPGain;
            json["ExplFlag"] = ExplFlag;
            json["Value22"] = Value22;
            json["AP"] = AP;
            json["Value24"] = Value24;
            json["Value25"] = Value25;
            json["Value26"] = Value26;
            json["Value27"] = Value27;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] ending = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(ID));
            finalList.AddRange(BitConverter.GetBytes(MapID));
            finalList.AddRange(BitConverter.GetBytes(PlayerMovesFirst));
            finalList.AddRange(BitConverter.GetBytes(Value4));
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value5));
            finalList.AddRange(BitConverter.GetBytes(Win1ID));
            finalList.AddRange(BitConverter.GetBytes(Lose1ID));
            finalList.AddRange(BitConverter.GetBytes(Win2ID));
            finalList.AddRange(BitConverter.GetBytes(Lose2ID));
            finalList.AddRange(BitConverter.GetBytes(Win3ID));
            finalList.AddRange(BitConverter.GetBytes(Lose3ID));
            finalList.AddRange(BitConverter.GetBytes(Win4ID));
            finalList.AddRange(BitConverter.GetBytes(Lose4ID));
            finalList.AddRange(BitConverter.GetBytes(DontShowResults));
            finalList.AddRange(BitConverter.GetBytes(Value15));
            finalList.AddRange(BitConverter.GetBytes(Value16));
            finalList.AddRange(BitConverter.GetBytes(Value17));
            finalList.AddRange(BitConverter.GetBytes(Value18));
            finalList.AddRange(BitConverter.GetBytes(Value19));
            finalList.AddRange(BitConverter.GetBytes(BPGain));
            finalList.AddRange(BitConverter.GetBytes(ExplFlag));
            finalList.AddRange(BitConverter.GetBytes(Value22));
            finalList.AddRange(BitConverter.GetBytes(AP));
            finalList.AddRange(BitConverter.GetBytes(Value24));
            finalList.AddRange(BitConverter.GetBytes(Value25));
            finalList.AddRange(BitConverter.GetBytes(Value26));
            finalList.AddRange(BitConverter.GetBytes(Value27));
            finalList.AddRange(ending);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (BPFile != null) list.Add(new CHNKRecord(BPFile, 0x10));
            if (LuaFile != null) list.Add(new CHNKRecord(LuaFile, 0x18));
            return list;
        }

    }
}
