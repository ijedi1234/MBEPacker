using MBEPacker.MBE.CHNK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public abstract class EXPARecord
    {

        public EXPARecord() { }

        public EXPARecord(byte[] rawRecord) { }

        public EXPARecord(JsonObject json) { }

        public static EXPARecord FormatRawRecord(List<int> layout, byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords)
        {
            EXPARecordLayout expaLayout = new EXPARecordLayout(layout);
            switch(expaLayout.LayoutType)
            {
                case (EXPARecordLayoutType.TEXT): return new EXPARecordText(rawRecord, cRecords);
                case (EXPARecordLayoutType.TEXT_DECISION): return new EXPARecordTextDecision(rawRecord, cRecords);
                default: throw new Exception("The packer does not support this layout");
            }
            
        }

        public static int GetExpectedSize(List<int> layout)
        {
            EXPARecordLayout expaLayout = new EXPARecordLayout(layout);
            switch (expaLayout.LayoutType)
            {
                case (EXPARecordLayoutType.TEXT): return new EXPARecordText().GetRawRecord().Length;
                case (EXPARecordLayoutType.TEXT_DECISION): return new EXPARecordTextDecision().GetRawRecord().Length;
                default: throw new Exception("The packer does not support this layout");
            }
        }

        public static EXPARecord BuildRecordFromJson(List<int> layout, JsonObject json)
        {
            EXPARecordLayout expaLayout = new EXPARecordLayout(layout);
            switch (expaLayout.LayoutType)
            {
                case (EXPARecordLayoutType.TEXT): return new EXPARecordText(json);
                case (EXPARecordLayoutType.TEXT_DECISION): return new EXPARecordTextDecision(json);
                default: throw new Exception("The packer does not support this layout");
            }
            return new EXPARecordText(json);
        }

        public virtual byte[] GetRawRecord()
        {
            return new byte[] { };
        }

        public virtual List<CHNKRecord> GenerateChunks()
        {
            return new List<CHNKRecord>();
        }

        public abstract JsonObject GetJson();

    }
}
