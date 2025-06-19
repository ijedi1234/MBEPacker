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
                case (EXPARecordLayoutType.DATA_EVENT_INFO): return new EXPARecordDataEventInfo(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_SET): return new EXPARecordDataEventProgressSet(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_INFO): return new EXPARecordDataEventProgressInfo(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_FIELD_DAY_CONDITION): return new EXPARecordDataFieldDayCondition(rawRecord, cRecords);
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
                case (EXPARecordLayoutType.DATA_EVENT_INFO): return new EXPARecordDataEventInfo().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_SET): return new EXPARecordDataEventProgressSet().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_INFO): return new EXPARecordDataEventProgressInfo().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_FIELD_DAY_CONDITION): return new EXPARecordDataFieldDayCondition().GetRawRecord().Length;
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
                case (EXPARecordLayoutType.DATA_EVENT_INFO): return new EXPARecordDataEventInfo(json);
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_SET): return new EXPARecordDataEventProgressSet(json);
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_INFO): return new EXPARecordDataEventProgressInfo(json);
                case (EXPARecordLayoutType.DATA_FIELD_DAY_CONDITION): return new EXPARecordDataFieldDayCondition(json);
                default: throw new Exception("The packer does not support this layout");
            }
            return new EXPARecordText(json);
        }

        public abstract byte[] GetRawRecord();
        public abstract List<CHNKRecord> GenerateChunks();
        public abstract JsonObject GetJson();

    }
}
