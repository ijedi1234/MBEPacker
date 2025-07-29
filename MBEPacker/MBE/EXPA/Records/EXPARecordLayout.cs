using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBEPacker.MBE.EXPA.Records
{
    public class EXPARecordLayout
    {
        public List<int> TwoInts = new List<int>() { 2, 2 };
        public List<int> ThreeInts = new List<int>() { 2, 2, 2 };
        public List<int> FourInts = new List<int>() { 2, 2, 2, 2 };
        public List<int> FiveInts = new List<int>() { 2, 2, 2, 2, 2 };

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
        public List<int> DataBattleSettingUnit = new List<int>() { 2, 8, 8, 8, 8, 8, 2, 2, 2, 2, 2, 2, 2, 2, 8, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 8, 8, 2, 8, 2, 2, 2 };
        public List<int> DataBattleBuild = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public List<int> DataBattleSkill = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 8, 8, 2, 2, 2, 2, 2, 2, 8, 9, 9, 9, 9, 9, 9 };
        public List<int> DataBattleSkillSet = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2, 8 };
        public List<int> DataBattleConditionEffect = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2, 2, 8, 8, 8 };
        public List<int> DataBattleMapSpecialCell = new List<int>() { 2, 2, 8 };
        public List<int> DataBattleSkillAct = new List<int>() { 2, 8, 2, 8, 2, 8, 8, 2 };
        public List<int> Message = new List<int>() { 2, 2, 7, 8, 7, 7, 7, 7, 7, 7, 7, 7 };

        public EXPARecordLayoutType LayoutType { get; private set; }

        public EXPARecordLayout(string tableName, List<int> layout)
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
            else if (layout.SequenceEqual(ThreeInts) && tableName == "PlaceID_UI") LayoutType = EXPARecordLayoutType.DATA_BP_PLACE_ID_UI;
            else if (layout.SequenceEqual(FiveInts) && tableName == "LotteryGroupID") LayoutType = EXPARecordLayoutType.DATA_BP_LOTTERY_GROUP_ID;
            else if (layout.SequenceEqual(DataPosition)) LayoutType = EXPARecordLayoutType.DATA_BP_POSITION;
            else if (layout.SequenceEqual(DataBattleSettingUnit)) LayoutType = EXPARecordLayoutType.DATA_BATTLE_SETTING_UNIT;

            else if (layout.SequenceEqual(FourInts) && tableName == "BattleBuildTable") LayoutType = EXPARecordLayoutType.DATA_BATTLE_SETTING_BUILD_TABLE;
            else if (layout.SequenceEqual(ThreeInts) && tableName == "ChargeSkill") LayoutType = EXPARecordLayoutType.DATA_BATTLE_SETTING_CHARGE_SKILL;
            else if (layout.SequenceEqual(DataBattleBuild)) LayoutType = EXPARecordLayoutType.DATA_BATTLE_SETTING_BUILD;
            else if (layout.SequenceEqual(FiveInts) && tableName == "PassiveSkill") LayoutType = EXPARecordLayoutType.DATA_BATTLE_SETTING_PASSIVE_SKILL;
            else if (layout.SequenceEqual(DataBattleSkill)) LayoutType = EXPARecordLayoutType.DATA_BATTLE_SETTING_BATTLE_SKILL;
            else if (layout.SequenceEqual(DataBattleSkillSet)) LayoutType = EXPARecordLayoutType.DATA_BATTLE_SETTING_BATTLE_SKILL_SET;
            else if (layout.SequenceEqual(ThreeInts) && tableName == "BadCondition") LayoutType = EXPARecordLayoutType.DATA_BATTLE_SETTING_BAD_CONDITION;
            else if (layout.SequenceEqual(DataBattleConditionEffect)) LayoutType = EXPARecordLayoutType.DATA_BATTLE_SETTING_CONDITION_EFFECT;
            else if (layout.SequenceEqual(FourInts) && tableName == "RandomCondition") LayoutType = EXPARecordLayoutType.DATA_BATTLE_SETTING_RANDOM_CONDITION;
            else if (layout.SequenceEqual(DataBattleMapSpecialCell)) LayoutType = EXPARecordLayoutType.DATA_BATTLE_SETTING_MAP_SPECIAL_CELL;

            else if (layout.SequenceEqual(DataBattleSkillAct)) LayoutType = EXPARecordLayoutType.DATA_BATTLE_SKILL_ACT;
            else if (layout.SequenceEqual(TwoInts)) LayoutType = EXPARecordLayoutType.DATA_BATTLE_SHIELD_MODE;

            else if (layout.SequenceEqual(Message)) LayoutType = EXPARecordLayoutType.MESSAGE;
            else LayoutType = EXPARecordLayoutType.UNKNOWN;
        }

    }
}
