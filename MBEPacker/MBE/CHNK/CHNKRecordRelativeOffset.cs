using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBEPacker.MBE.CHNK
{
    public class CHNKRecordRelativeOffset
    {
        public int Offset { get; set; }
        public string Text { get; set; }

        public CHNKRecordRelativeOffset(CHNKRecord record)
        {
            Offset = record.Offset;
            Text = record.Text;
        }

    }
}
