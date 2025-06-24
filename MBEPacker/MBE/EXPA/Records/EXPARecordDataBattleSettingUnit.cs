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
    public class EXPARecordDataBattleSettingUnit : EXPARecord
    {
        public int ID { get; set; }
        public string? LODFile1 { get; set; }
        public string? LODFile2 { get; set; }
        public string? Text3 { get; set; }
        public string? UnitSize { get; set; }
        public string? Text5 { get; set; }
        public int Value2 { get; set; }
        public int HP { get; set; }
        public int Value4 { get; set; }
        public int Value5 { get; set; }
        public int Value6 { get; set; }
        public int Value7 { get; set; }
        public int Value8 { get; set; }
        public int Value9 { get; set; }
        public string? Text6 { get; set; }
        public int Value10 { get; set; }
        public int Value11 { get; set; }
        public int Value12 { get; set; }
        public int Value13 { get; set; }
        public int PassiveID { get; set; }
        public int Value15 { get; set; }
        public int Value16 { get; set; }
        public int Value17 { get; set; }
        public int Value18 { get; set; }
        public int Value19 { get; set; }
        public int Value20 { get; set; }
        public int Value21 { get; set; }
        public int Value22 { get; set; }
        public int Value23 { get; set; }
        public string? Text7 { get; set; }
        public string? Text8 { get; set; }
        public int Value24 { get; set; }
        public string? Text9 { get; set; }
        public int Value25 { get; set; }
        public int Value26 { get; set; }
        public int Value27 { get; set; }

        public EXPARecordDataBattleSettingUnit() : base() { }

        public EXPARecordDataBattleSettingUnit(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            ID = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            Value2 = BitConverter.ToInt32(rawRecord.Skip(0x30).Take(sizeof(int)).ToArray());
            HP = BitConverter.ToInt32(rawRecord.Skip(0x34).Take(sizeof(int)).ToArray());
            Value4 = BitConverter.ToInt32(rawRecord.Skip(0x38).Take(sizeof(int)).ToArray());
            Value5 = BitConverter.ToInt32(rawRecord.Skip(0x3C).Take(sizeof(int)).ToArray());
            Value6 = BitConverter.ToInt32(rawRecord.Skip(0x40).Take(sizeof(int)).ToArray());
            Value7 = BitConverter.ToInt32(rawRecord.Skip(0x44).Take(sizeof(int)).ToArray());
            Value8 = BitConverter.ToInt32(rawRecord.Skip(0x48).Take(sizeof(int)).ToArray());
            Value9 = BitConverter.ToInt32(rawRecord.Skip(0x4C).Take(sizeof(int)).ToArray());
            Value10 = BitConverter.ToInt32(rawRecord.Skip(0x58).Take(sizeof(int)).ToArray());
            Value11 = BitConverter.ToInt32(rawRecord.Skip(0x5C).Take(sizeof(int)).ToArray());
            Value12 = BitConverter.ToInt32(rawRecord.Skip(0x60).Take(sizeof(int)).ToArray());
            Value13 = BitConverter.ToInt32(rawRecord.Skip(0x64).Take(sizeof(int)).ToArray());
            PassiveID = BitConverter.ToInt32(rawRecord.Skip(0x68).Take(sizeof(int)).ToArray());
            Value15 = BitConverter.ToInt32(rawRecord.Skip(0x6C).Take(sizeof(int)).ToArray());
            Value16 = BitConverter.ToInt32(rawRecord.Skip(0x70).Take(sizeof(int)).ToArray());
            Value17 = BitConverter.ToInt32(rawRecord.Skip(0x74).Take(sizeof(int)).ToArray());
            Value18 = BitConverter.ToInt32(rawRecord.Skip(0x78).Take(sizeof(int)).ToArray());
            Value19 = BitConverter.ToInt32(rawRecord.Skip(0x7C).Take(sizeof(int)).ToArray());
            Value20 = BitConverter.ToInt32(rawRecord.Skip(0x80).Take(sizeof(int)).ToArray());
            Value21 = BitConverter.ToInt32(rawRecord.Skip(0x84).Take(sizeof(int)).ToArray());
            Value22 = BitConverter.ToInt32(rawRecord.Skip(0x88).Take(sizeof(int)).ToArray());
            Value23 = BitConverter.ToInt32(rawRecord.Skip(0x8C).Take(sizeof(int)).ToArray());
            Value24 = BitConverter.ToInt32(rawRecord.Skip(0xA0).Take(sizeof(int)).ToArray());
            Value25 = BitConverter.ToInt32(rawRecord.Skip(0xB0).Take(sizeof(int)).ToArray());
            Value26 = BitConverter.ToInt32(rawRecord.Skip(0xB4).Take(sizeof(int)).ToArray());
            Value27 = BitConverter.ToInt32(rawRecord.Skip(0xB8).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x8: LODFile1 = cRecord.Text; break;
                    case 0x10: LODFile2 = cRecord.Text; break;
                    case 0x18: Text3 = cRecord.Text; break;
                    case 0x20: UnitSize = cRecord.Text; break;
                    case 0x28: Text5 = cRecord.Text; break;
                    case 0x50: Text6 = cRecord.Text; break;
                    case 0x90: Text7 = cRecord.Text; break;
                    case 0x98: Text8 = cRecord.Text; break;
                    case 0xA8: Text9 = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataBattleSettingUnit(JsonObject json) : base(json)
        {
            ID = json["ID"].AsValue().GetValue<int>();
            if (json["LODFile1"] == null) { LODFile1 = null; } else { LODFile1 = (string)json["LODFile1"]; }
            if (json["LODFile2"] == null) { LODFile2 = null; } else { LODFile2 = (string)json["LODFile2"]; }
            if (json["Text3"] == null) { Text3 = null; } else { Text3 = (string)json["Text3"]; }
            if (json["UnitSize"] == null) { UnitSize = null; } else { UnitSize = (string)json["UnitSize"]; }
            if (json["Text5"] == null) { Text5 = null; } else { Text5 = (string)json["Text5"]; }
            Value2 = json["Value2"].AsValue().GetValue<int>();
            HP = json["HP"].AsValue().GetValue<int>();
            Value4 = json["Value4"].AsValue().GetValue<int>();
            Value5 = json["Value5"].AsValue().GetValue<int>();
            Value6 = json["Value6"].AsValue().GetValue<int>();
            Value7 = json["Value7"].AsValue().GetValue<int>();
            Value8 = json["Value8"].AsValue().GetValue<int>();
            Value9 = json["Value9"].AsValue().GetValue<int>();
            if (json["Text6"] == null) { Text6 = null; } else { Text6 = (string)json["Text6"]; }
            Value10 = json["Value10"].AsValue().GetValue<int>();
            Value11 = json["Value11"].AsValue().GetValue<int>();
            Value12 = json["Value12"].AsValue().GetValue<int>();
            Value13 = json["Value13"].AsValue().GetValue<int>();
            PassiveID = json["PassiveID"].AsValue().GetValue<int>();
            Value15 = json["Value15"].AsValue().GetValue<int>();
            Value16 = json["Value16"].AsValue().GetValue<int>();
            Value17 = json["Value17"].AsValue().GetValue<int>();
            Value18 = json["Value18"].AsValue().GetValue<int>();
            Value19 = json["Value19"].AsValue().GetValue<int>();
            Value20 = json["Value20"].AsValue().GetValue<int>();
            Value21 = json["Value21"].AsValue().GetValue<int>();
            Value22 = json["Value22"].AsValue().GetValue<int>();
            Value23 = json["Value23"].AsValue().GetValue<int>();
            if (json["Text7"] == null) { Text7 = null; } else { Text7 = (string)json["Text7"]; }
            if (json["Text8"] == null) { Text8 = null; } else { Text8 = (string)json["Text8"]; }
            Value24 = json["Value24"].AsValue().GetValue<int>();
            if (json["Text9"] == null) { Text9 = null; } else { Text9 = (string)json["Text9"]; }
            Value25 = json["Value25"].AsValue().GetValue<int>();
            Value26 = json["Value26"].AsValue().GetValue<int>();
            Value27 = json["Value27"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["ID"] = ID;
            json["LODFile1"] = LODFile1;
            json["LODFile2"] = LODFile2;
            json["Text3"] = Text3;
            json["UnitSize"] = UnitSize;
            json["Text5"] = Text5;
            json["Value2"] = Value2;
            json["HP"] = HP;
            json["Value4"] = Value4;
            json["Value5"] = Value5;
            json["Value6"] = Value6;
            json["Value7"] = Value7;
            json["Value8"] = Value8;
            json["Value9"] = Value9;
            json["Text6"] = Text6;
            json["Value10"] = Value10;
            json["Value11"] = Value11;
            json["Value12"] = Value12;
            json["Value13"] = Value13;
            json["PassiveID"] = PassiveID;
            json["Value15"] = Value15;
            json["Value16"] = Value16;
            json["Value17"] = Value17;
            json["Value18"] = Value18;
            json["Value19"] = Value19;
            json["Value20"] = Value20;
            json["Value21"] = Value21;
            json["Value22"] = Value22;
            json["Value23"] = Value23;
            json["Text7"] = Text7;
            json["Text8"] = Text8;
            json["Value24"] = Value24;
            json["Text9"] = Text9;
            json["Value25"] = Value25;
            json["Value26"] = Value26;
            json["Value27"] = Value27;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] intermission = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(ID));
            finalList.AddRange(intermission);
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value2));
            finalList.AddRange(BitConverter.GetBytes(HP));
            finalList.AddRange(BitConverter.GetBytes(Value4));
            finalList.AddRange(BitConverter.GetBytes(Value5));
            finalList.AddRange(BitConverter.GetBytes(Value6));
            finalList.AddRange(BitConverter.GetBytes(Value7));
            finalList.AddRange(BitConverter.GetBytes(Value8));
            finalList.AddRange(BitConverter.GetBytes(Value9));
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value10));
            finalList.AddRange(BitConverter.GetBytes(Value11));
            finalList.AddRange(BitConverter.GetBytes(Value12));
            finalList.AddRange(BitConverter.GetBytes(Value13));
            finalList.AddRange(BitConverter.GetBytes(PassiveID));
            finalList.AddRange(BitConverter.GetBytes(Value15));
            finalList.AddRange(BitConverter.GetBytes(Value16));
            finalList.AddRange(BitConverter.GetBytes(Value17));
            finalList.AddRange(BitConverter.GetBytes(Value18));
            finalList.AddRange(BitConverter.GetBytes(Value19));
            finalList.AddRange(BitConverter.GetBytes(Value20));
            finalList.AddRange(BitConverter.GetBytes(Value21));
            finalList.AddRange(BitConverter.GetBytes(Value22));
            finalList.AddRange(BitConverter.GetBytes(Value23));
            finalList.AddRange(empty8);
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value24));
            finalList.AddRange(intermission);
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(Value25));
            finalList.AddRange(BitConverter.GetBytes(Value26));
            finalList.AddRange(BitConverter.GetBytes(Value27));
            finalList.AddRange(intermission);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (LODFile1 != null) list.Add(new CHNKRecord(LODFile1, 0x8));
            if (LODFile2 != null) list.Add(new CHNKRecord(LODFile2, 0x10));
            if (Text3 != null) list.Add(new CHNKRecord(Text3, 0x18));
            if (UnitSize != null) list.Add(new CHNKRecord(UnitSize, 0x20));
            if (Text5 != null) list.Add(new CHNKRecord(Text5, 0x28));
            if (Text6 != null) list.Add(new CHNKRecord(Text6, 0x50));
            if (Text7 != null) list.Add(new CHNKRecord(Text7, 0x90));
            if (Text8 != null) list.Add(new CHNKRecord(Text8, 0x98));
            if (Text9 != null) list.Add(new CHNKRecord(Text9, 0xA8));
            return list;
        }
    }
}
