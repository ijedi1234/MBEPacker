using MBEPacker.MBE.CHNK;
using MBEPacker.MBE.EXPA.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA
{
    public class EXPATable
    {

        public EXPATableHeader Header { get; set; }
        public List<byte[]> RawRecords { get; set; } = new List<byte[]>();
        public List<EXPARecord> EXPARecords { get; set; } = new List<EXPARecord>();

        public EXPATable(FileStream fStream)
        {
            Header = new EXPATableHeader(fStream);
            for(int i = 0; i < Header.NumRecords; i++)
            {
                byte[] contentBytes = new byte[Header.RecordSize];
                fStream.Read(contentBytes, 0, Header.RecordSize);
                RawRecords.Add(contentBytes);
            }
        }

        public EXPATable(string name, JsonObject json)
        {
            Header = new EXPATableHeader(name, json);
            JsonArray recordsList = json["records"].AsArray();
            foreach(JsonNode jsonRecord in recordsList)
            {
                EXPARecord record = EXPARecord.BuildRecordFromJson(new EXPARecordLayout(Header.Name, Header.RecordLayout), jsonRecord.AsObject());
                EXPARecords.Add(record);
                RawRecords.Add(record.GetRawRecord());
            }
        }

        public void FormatEXPARecords(List<CHNKRecordRelativeOffset> chnkRecords)
        {
            foreach(CHNKRecordRelativeOffset record in chnkRecords)
            {
                record.Offset -= Header.GetSize();
            }
            List<List<CHNKRecordRelativeOffset>> chnkRecordsForExpaRecords = new List<List<CHNKRecordRelativeOffset>>();
            for(int i = 0; i < RawRecords.Count; i++)
            {
                chnkRecordsForExpaRecords.Add(new List<CHNKRecordRelativeOffset>());
            }
            foreach(CHNKRecordRelativeOffset cRecord in chnkRecords)
            {
                int eRecordIndex = cRecord.Offset / Header.RecordSize;
                cRecord.Offset = cRecord.Offset % Header.RecordSize;
                chnkRecordsForExpaRecords[eRecordIndex].Add(cRecord);
            }
            for(int i = 0; i < RawRecords.Count;i++)
            {
                EXPARecord eRecord = EXPARecord.FormatRawRecord(new EXPARecordLayout(Header.Name, Header.RecordLayout), RawRecords[i], chnkRecordsForExpaRecords[i]);
                EXPARecords.Add(eRecord);
            }
        }

        public int GetSize()
        {
            int size = Header.GetSize();
            foreach (byte[] record in RawRecords)
            {
                size += record.Length;
            }
            return size;
        }

        public JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            JsonArray layout = new JsonArray();
            for(int i = 0; i < Header.RecordLayoutCount; i++)
            {
                layout.Add(Header.RecordLayout[i]);
            }
            json["layout"] = layout;
            JsonArray records = new JsonArray();
            for(int i = 0; i < EXPARecords.Count; i++)
            {
                records.Add(EXPARecords[i].GetJson());
            }
            json["records"] = records;
            return json;
        }

        public List<CHNKRecord> GenerateChunks()
        {
            List<CHNKRecord> cRecords = new List<CHNKRecord>();
            for(int i = 0, passedBytes = 0; i < EXPARecords.Count; i++)
            {
                EXPARecord eRecord = EXPARecords[i];
                List<CHNKRecord> generatedRecords = eRecord.GenerateChunks();
                foreach(CHNKRecord record in generatedRecords)
                {
                    record.Offset += passedBytes;
                }
                cRecords.AddRange(generatedRecords);
                passedBytes += eRecord.GetRawRecord().Length;
            }
            foreach(CHNKRecord record in cRecords)
            {
                record.Offset += Header.GetSize();
            }
            return cRecords;
        }

        public void WriteMBE(FileStream fStream)
        {
            Header.WriteMBE(fStream);
            foreach(byte[] record in RawRecords)
            {
                fStream.Write(record, 0, record.Length);
            }
        }
    }
}
