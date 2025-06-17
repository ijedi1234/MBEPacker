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

        public EXPARecordLayoutType LayoutType { get; private set; }

        public EXPARecordLayout(List<int> layout)
        {
            if (layout.SequenceEqual(Text)) LayoutType = EXPARecordLayoutType.TEXT;
            else if (layout.SequenceEqual(TextDecision)) LayoutType = EXPARecordLayoutType.TEXT_DECISION;
            else LayoutType = EXPARecordLayoutType.UNKNOWN;
        }

    }
}
