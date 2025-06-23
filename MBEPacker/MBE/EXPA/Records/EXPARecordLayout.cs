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
        private List<int> DataFieldChapterSelect = new List<int>() { 2, 2, 2, 2, 2, 8, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        private List<int> DataFieldChapterSelectJumpInfo = new List<int>() { 2, 2, 8, 2, 2, 2, 8, 8 };
        private List<int> DataUIVRBattleMenu = new List<int>() { 2, 2, 2, 2, 2, 2, 8, 2 };
        public List<int> DataBattleID = new List<int>() { 2, 2, 2, 2, 8, 8, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 9, 9, 9 };
        public List<int> DataPlaceID = new List<int>() { 2, 2, 2, 2, 2, 2, 2 };
        public List<int> DataPlaceIDUI = new List<int>() { 2, 2, 2 };
        public List<int> DataLotteryGroupID = new List<int>() { 2, 2, 2, 2, 2 };
        public List<int> DataPosition = new List<int>() 
        { 2,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4
        };

        public EXPARecordLayoutType LayoutType { get; private set; }

        public EXPARecordLayout(List<int> layout)
        {
            if (layout.SequenceEqual(Text)) LayoutType = EXPARecordLayoutType.TEXT;
            else if (layout.SequenceEqual(TextDecision)) LayoutType = EXPARecordLayoutType.TEXT_DECISION;
            else if (layout.SequenceEqual(DataEventInfo)) LayoutType = EXPARecordLayoutType.DATA_EVENT_INFO;
            else if (layout.SequenceEqual(DataEventProgressSet)) LayoutType = EXPARecordLayoutType.DATA_EVENT_PROGRESS_SET;
            else if (layout.SequenceEqual(DataEventProgressInfo)) LayoutType = EXPARecordLayoutType.DATA_EVENT_PROGRESS_INFO;
            else if (layout.SequenceEqual(DataFieldDayCondition)) LayoutType = EXPARecordLayoutType.DATA_FIELD_DAY_CONDITION;
            else if (layout.SequenceEqual(DataFieldChapterSelect)) LayoutType = EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT;
            else if (layout.SequenceEqual(DataFieldChapterSelectJumpInfo)) LayoutType = EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT_JUMP_INFO;
            else if (layout.SequenceEqual(DataUIVRBattleMenu)) LayoutType = EXPARecordLayoutType.DATA_UI_VR_BATTLE_MENU;
            else if (layout.SequenceEqual(DataBattleID)) LayoutType = EXPARecordLayoutType.DATA_BATTLE_ID;
            else if (layout.SequenceEqual(DataPlaceID)) LayoutType = EXPARecordLayoutType.DATA_BP_PLACE_ID;
            else if (layout.SequenceEqual(DataPlaceIDUI)) LayoutType = EXPARecordLayoutType.DATA_BP_PLACE_ID_UI;
            else if (layout.SequenceEqual(DataLotteryGroupID)) LayoutType = EXPARecordLayoutType.DATA_BP_LOTTERY_GROUP_ID;
            else if (layout.SequenceEqual(DataPosition)) LayoutType = EXPARecordLayoutType.DATA_BP_POSITION;
            else LayoutType = EXPARecordLayoutType.UNKNOWN;
        }

    }
}
