using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordLayout
    {

        private List<int> Text = new List<int>() { 2, 7, 7, 7, 7, 7, 7 };
        private List<int> TextDecision = new List<int>() { 8, 7, 7, 7, 7, 7, 7 };
        private List<int> DataEventInfo = new List<int>() { 8, 2, 2, 8, 2, 2, 8, 8, 2, 2, 2};
        private List<int> DataEventProgressSet = new List<int>() { 2, 2, 2, 2, 2, 9, 2, 2, 8, 8, 2, 2, 9, 2 };
        private List<int> DataEventProgressInfo = new List<int>() { 8, 2, 8, 2, 2, 2, 2, 8, 2, 2 };
        private List<int> DataFieldDayCondition = new List<int>() { 2, 2, 2, 2, 8, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };

        public EXPARecordLayoutType LayoutType { get; private set; }

        public EXPARecordLayout(List<int> layout)
        {
            if (layout.SequenceEqual(Text)) LayoutType = EXPARecordLayoutType.TEXT;
            else if (layout.SequenceEqual(TextDecision)) LayoutType = EXPARecordLayoutType.TEXT_DECISION;
            else if (layout.SequenceEqual(DataEventInfo)) LayoutType = EXPARecordLayoutType.DATA_EVENT_INFO;
            else if (layout.SequenceEqual(DataEventProgressSet)) LayoutType = EXPARecordLayoutType.DATA_EVENT_PROGRESS_SET;
            else if (layout.SequenceEqual(DataEventProgressInfo)) LayoutType = EXPARecordLayoutType.DATA_EVENT_PROGRESS_INFO;
            else if (layout.SequenceEqual(DataFieldDayCondition)) LayoutType = EXPARecordLayoutType.DATA_FIELD_DAY_CONDITION;
            else LayoutType = EXPARecordLayoutType.UNKNOWN;
        }

    }
}
