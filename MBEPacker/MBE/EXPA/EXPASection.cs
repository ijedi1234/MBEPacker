using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA
{
    public class EXPASection
    {

        public EXPAHeader Header { get; set;}
        public List<EXPATable> Tables { get; set; } = new List<EXPATable>();

        public EXPASection(FileStream fStream)
        {
            Header = new EXPAHeader(fStream);
            for(int i = 0; i < Header.NumTables; i++)
            {
                Tables.Add(new EXPATable(fStream));
            }
        }

        public EXPASection(JsonObject json)
        {
            Header = new EXPAHeader(json);
            foreach(KeyValuePair<string, JsonNode?> item in json)
            {
                if (item.Value == null) throw new Exception("Broken json object at: " + item.Key);
                Tables.Add(new EXPATable(item.Key, item.Value.AsObject()));
            }
        }

        public void FormatEXPARecords(CHNKSection chnk)
        {
            List<CHNKRecordRelativeOffset> relativeRecords = chnk.Records.Select(i => new CHNKRecordRelativeOffset(i)).OrderBy(i => i.Offset).ToList();
            foreach (CHNKRecordRelativeOffset record in relativeRecords) { record.Offset -= Header.GetSize(); }
            List<List<CHNKRecordRelativeOffset>> recordsForTable = new List<List<CHNKRecordRelativeOffset>>();
            for(int i = 0; i < Tables.Count; i++)
            {
                recordsForTable.Add(new List<CHNKRecordRelativeOffset>());
            }
            for(int recordIndex = 0; recordIndex < relativeRecords.Count; recordIndex++)
            {
                int prevTableSize = 0, curTableSize = 0;
                for (int tableIndex = 0; tableIndex < Tables.Count; tableIndex++)
                {
                    curTableSize += Tables[tableIndex].GetSize();

                    int offset = relativeRecords[recordIndex].Offset;
                    if (offset >= prevTableSize && offset < curTableSize)
                    {
                        CHNKRecordRelativeOffset record = relativeRecords[recordIndex];
                        record.Offset -= prevTableSize;
                        recordsForTable[tableIndex].Add(record);
                    }

                    prevTableSize = curTableSize;
                }
            }
            for(int i = 0; i < Tables.Count; i++)
            {
                Tables[i].FormatEXPARecords(recordsForTable[i]);
            }
        }

        public JsonObject GetJson()
        {
            JsonObject json = new JsonObject();
            foreach(EXPATable table in Tables)
            {
                json[table.Header.Name] = table.GetJson();
            }
            return json;
        }

        public void WriteMBE(FileStream fStream)
        {
            Header.WriteMBE(fStream);
            foreach(EXPATable table in Tables)
            {
                table.WriteMBE(fStream);
            }
        }

    }
}
