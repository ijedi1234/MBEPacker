using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public enum EXPARecordLayoutType
    {
        UNKNOWN = 0,
        TEXT = 1, // text/char_name.mbe
        TEXT_DECISION = 2 // text/event_decideselect_message.mbe
    }
}
