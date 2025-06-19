using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordDataFieldDayCondition : EXPARecord
    {

        public int Value1 { get; set; }
        public int Day { get; set; }
        public int TimeOfDay { get; set; }
        public int Value4 { get; set; }
        public string? Route { get; set; }
        public int StatusTakumi { get; set; }
        public int StatusTakemaru { get; set; }
        public int StatusHiruko { get; set; }
        public int StatusDarumi { get; set; }
        public int StatusEito { get; set; }
        public int StatusTsubasa { get; set; }
        public int StatusGaku { get; set; }
        public int StatusIma { get; set; }
        public int StatusKako { get; set; }
        public int StatusShouma { get; set; }
        public int StatusNozomi { get; set; }
        public int StatusKurara { get; set; }
        public int StatusKyoshika { get; set; }
        public int StatusYugamu { get; set; }
        public int StatusMoko { get; set; }
        public int StatusEva { get; set; }
        public int StatusShion { get; set; }
        public int StatusSirei { get; set; }
        public int StatusNigou { get; set; }

        public EXPARecordDataFieldDayCondition() { }

        public EXPARecordDataFieldDayCondition(byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords) : base(rawRecord)
        {
            Value1 = BitConverter.ToInt32(rawRecord.Skip(0x0).Take(sizeof(int)).ToArray());
            Day = BitConverter.ToInt32(rawRecord.Skip(0x4).Take(sizeof(int)).ToArray());
            TimeOfDay = BitConverter.ToInt32(rawRecord.Skip(0x8).Take(sizeof(int)).ToArray());
            Value4 = BitConverter.ToInt32(rawRecord.Skip(0xC).Take(sizeof(int)).ToArray());
            StatusTakumi = BitConverter.ToInt32(rawRecord.Skip(0x18).Take(sizeof(int)).ToArray());
            StatusTakemaru = BitConverter.ToInt32(rawRecord.Skip(0x1C).Take(sizeof(int)).ToArray());
            StatusHiruko = BitConverter.ToInt32(rawRecord.Skip(0x20).Take(sizeof(int)).ToArray());
            StatusDarumi = BitConverter.ToInt32(rawRecord.Skip(0x24).Take(sizeof(int)).ToArray());
            StatusEito = BitConverter.ToInt32(rawRecord.Skip(0x28).Take(sizeof(int)).ToArray());
            StatusTsubasa = BitConverter.ToInt32(rawRecord.Skip(0x2C).Take(sizeof(int)).ToArray());
            StatusGaku = BitConverter.ToInt32(rawRecord.Skip(0x30).Take(sizeof(int)).ToArray());
            StatusIma = BitConverter.ToInt32(rawRecord.Skip(0x34).Take(sizeof(int)).ToArray());
            StatusKako = BitConverter.ToInt32(rawRecord.Skip(0x38).Take(sizeof(int)).ToArray());
            StatusShouma = BitConverter.ToInt32(rawRecord.Skip(0x3C).Take(sizeof(int)).ToArray());
            StatusNozomi = BitConverter.ToInt32(rawRecord.Skip(0x40).Take(sizeof(int)).ToArray());
            StatusKurara = BitConverter.ToInt32(rawRecord.Skip(0x44).Take(sizeof(int)).ToArray());
            StatusKyoshika = BitConverter.ToInt32(rawRecord.Skip(0x48).Take(sizeof(int)).ToArray());
            StatusYugamu = BitConverter.ToInt32(rawRecord.Skip(0x4C).Take(sizeof(int)).ToArray());
            StatusMoko = BitConverter.ToInt32(rawRecord.Skip(0x50).Take(sizeof(int)).ToArray());
            StatusEva = BitConverter.ToInt32(rawRecord.Skip(0x54).Take(sizeof(int)).ToArray());
            StatusShion = BitConverter.ToInt32(rawRecord.Skip(0x58).Take(sizeof(int)).ToArray());
            StatusSirei = BitConverter.ToInt32(rawRecord.Skip(0x5C).Take(sizeof(int)).ToArray());
            StatusNigou = BitConverter.ToInt32(rawRecord.Skip(0x60).Take(sizeof(int)).ToArray());
            foreach (CHNKRecordRelativeOffset cRecord in cRecords)
            {
                switch (cRecord.Offset)
                {
                    case 0x10: Route = cRecord.Text; break;
                }
            }
        }

        public EXPARecordDataFieldDayCondition(JsonObject json) : base(json)
        {
            Value1 = json["Value1"].AsValue().GetValue<int>();
            Day = json["Day"].AsValue().GetValue<int>();
            TimeOfDay = json["TimeOfDay"].AsValue().GetValue<int>();
            Value4 = json["Value4"].AsValue().GetValue<int>();
            if (json["Route"] == null) { Route = null; } else { Route = (string)json["Route"]; }
            StatusTakumi = json["StatusTakumi"].AsValue().GetValue<int>();
            StatusTakemaru = json["StatusTakemaru"].AsValue().GetValue<int>();
            StatusHiruko = json["StatusHiruko"].AsValue().GetValue<int>();
            StatusDarumi = json["StatusDarumi"].AsValue().GetValue<int>();
            StatusEito = json["StatusEito"].AsValue().GetValue<int>();
            StatusTsubasa = json["StatusTsubasa"].AsValue().GetValue<int>();
            StatusGaku = json["StatusGaku"].AsValue().GetValue<int>();
            StatusIma = json["StatusIma"].AsValue().GetValue<int>();
            StatusKako = json["StatusKako"].AsValue().GetValue<int>();
            StatusShouma = json["StatusShouma"].AsValue().GetValue<int>();
            StatusNozomi = json["StatusNozomi"].AsValue().GetValue<int>();
            StatusKurara = json["StatusKurara"].AsValue().GetValue<int>();
            StatusKyoshika = json["StatusKyoshika"].AsValue().GetValue<int>();
            StatusYugamu = json["StatusYugamu"].AsValue().GetValue<int>();
            StatusMoko = json["StatusMoko"].AsValue().GetValue<int>();
            StatusEva = json["StatusEva"].AsValue().GetValue<int>();
            StatusShion = json["StatusShion"].AsValue().GetValue<int>();
            StatusSirei = json["StatusSirei"].AsValue().GetValue<int>();
            StatusNigou = json["StatusNigou"].AsValue().GetValue<int>();
        }

        public override JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            json["Value1"] = Value1;
            json["Day"] = Day;
            json["TimeOfDay"] = TimeOfDay;
            json["Value4"] = Value4;
            json["Route"] = Route;
            json["StatusTakumi"] = StatusTakumi;
            json["StatusTakemaru"] = StatusTakemaru;
            json["StatusHiruko"] = StatusHiruko;
            json["StatusDarumi"] = StatusDarumi;
            json["StatusEito"] = StatusEito;
            json["StatusTsubasa"] = StatusTsubasa;
            json["StatusGaku"] = StatusGaku;
            json["StatusIma"] = StatusIma;
            json["StatusKako"] = StatusKako;
            json["StatusShouma"] = StatusShouma;
            json["StatusNozomi"] = StatusNozomi;
            json["StatusKurara"] = StatusKurara;
            json["StatusKyoshika"] = StatusKyoshika;
            json["StatusYugamu"] = StatusYugamu;
            json["StatusMoko"] = StatusMoko;
            json["StatusEva"] = StatusEva;
            json["StatusShion"] = StatusShion;
            json["StatusSirei"] = StatusSirei;
            json["StatusNigou"] = StatusNigou;
            return json;
        }

        public override byte[] GetRawRecord()
        {
            byte[] intermission = new byte[] { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] empty8 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            List<byte> finalList = new List<byte>();
            finalList.AddRange(BitConverter.GetBytes(Value1));
            finalList.AddRange(BitConverter.GetBytes(Day));
            finalList.AddRange(BitConverter.GetBytes(TimeOfDay));
            finalList.AddRange(BitConverter.GetBytes(Value4));
            finalList.AddRange(empty8);
            finalList.AddRange(BitConverter.GetBytes(StatusTakumi));
            finalList.AddRange(BitConverter.GetBytes(StatusTakemaru));
            finalList.AddRange(BitConverter.GetBytes(StatusHiruko));
            finalList.AddRange(BitConverter.GetBytes(StatusDarumi));
            finalList.AddRange(BitConverter.GetBytes(StatusEito));
            finalList.AddRange(BitConverter.GetBytes(StatusTsubasa));
            finalList.AddRange(BitConverter.GetBytes(StatusGaku));
            finalList.AddRange(BitConverter.GetBytes(StatusIma));
            finalList.AddRange(BitConverter.GetBytes(StatusKako));
            finalList.AddRange(BitConverter.GetBytes(StatusShouma));
            finalList.AddRange(BitConverter.GetBytes(StatusNozomi));
            finalList.AddRange(BitConverter.GetBytes(StatusKurara));
            finalList.AddRange(BitConverter.GetBytes(StatusKyoshika));
            finalList.AddRange(BitConverter.GetBytes(StatusYugamu));
            finalList.AddRange(BitConverter.GetBytes(StatusMoko));
            finalList.AddRange(BitConverter.GetBytes(StatusEva));
            finalList.AddRange(BitConverter.GetBytes(StatusShion));
            finalList.AddRange(BitConverter.GetBytes(StatusSirei));
            finalList.AddRange(BitConverter.GetBytes(StatusNigou));
            finalList.AddRange(intermission);
            return finalList.ToArray();
        }

        public override List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> list = new List<CHNKRecord>();
            if (Route != null) list.Add(new CHNKRecord(Route, 0x10));
            return list;
        }

    }
}
