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
        TEXT_DECISION = 2, // text/event_decideselect_message.mbe
        DATA_EVENT_INFO = 3, // data/event_info_s14_0_00.mbe
        DATA_EVENT_PROGRESS_SET = 4, // data/event_progress_set_s14_0_00.mbe
        DATA_EVENT_PROGRESS_INFO = 5, // data/event_progress_info_s14_0_00.mbe
        DATA_FIELD_DAY_CONDITION = 6, // data/field_day_condition.mbe
        DATA_FIELD_CHAPTER_SELECT = 7, // data/field_chapter_select.mbe
        DATA_FIELD_CHAPTER_SELECT_JUMP_INFO = 8 // data/field_chapter_select.mbe
    }
}
