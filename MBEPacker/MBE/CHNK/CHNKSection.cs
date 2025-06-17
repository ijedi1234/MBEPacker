using MBEPacker.MBE.EXPA;
using MBEPacker.MBE.EXPA.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBEPacker.MBE.CHNK
{
    public class CHNKSection
    {

        public CHNKHeader Header { get; set; }
        public List<CHNKRecord> Records { get; set; } = new List<CHNKRecord>();

        public CHNKSection(FileStream fStream)
        {
            Header = new CHNKHeader(fStream);
            for(int i = 0; i < Header.NumRecords; i++)
            {
                Records.Add(new CHNKRecord(fStream));
            }
        }

        public CHNKSection(EXPASection expa)
        {
            for (int i = 0, passedBytes = 0; i < expa.Tables.Count; i++)
            {
                EXPATable eTable = expa.Tables[i];
                List<CHNKRecord> generatedRecords = eTable.GenerateChunks();
                foreach (CHNKRecord record in generatedRecords)
                {
                    record.Offset += passedBytes;
                    record.Offset += expa.Header.GetSize();
                }
                Records.AddRange(generatedRecords);
                passedBytes += eTable.GetSize();
            }
            Header = new CHNKHeader(Records.Count);
        }

        public void WriteMBE(FileStream fStream)
        {
            Header.WriteMBE(fStream);
            foreach(CHNKRecord record in Records) { record.WriteMBE(fStream); }
        }
    }
}
