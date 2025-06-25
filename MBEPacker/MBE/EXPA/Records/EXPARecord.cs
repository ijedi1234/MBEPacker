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

        public static EXPARecord FormatRawRecord(EXPARecordLayout expaLayout, byte[] rawRecord, List<CHNKRecordRelativeOffset> cRecords)
        {
            switch(expaLayout.LayoutType)
            {
                case (EXPARecordLayoutType.TEXT): return new EXPARecordText(rawRecord, cRecords);
                case (EXPARecordLayoutType.TEXT_DECISION): return new EXPARecordTextDecision(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_EVENT_INFO): return new EXPARecordDataEventInfo(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_SET): return new EXPARecordDataEventProgressSet(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_INFO): return new EXPARecordDataEventProgressInfo(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_FIELD_DAY_CONDITION): return new EXPARecordDataFieldDayCondition(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT): return new EXPARecordDataFieldChapterSelect(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT_JUMP_INFO): return new EXPARecordDataFieldChapterSelectJumpInfo(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_UI_VR_BATTLE_MENU): return new EXPARecordDataUIVRBattleMenu(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_BATTLE_ID): return new EXPARecordDataBattleID(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID): return new EXPARecordDataBPPlaceID(rawRecord);
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID_UI): return new EXPARecordDataBPPlaceIDUI(rawRecord);
                case (EXPARecordLayoutType.DATA_BP_LOTTERY_GROUP_ID): return new EXPARecordDataBPLotteryGroupID(rawRecord);
                case (EXPARecordLayoutType.DATA_BP_POSITION): return new EXPARecordDataBPPosition(rawRecord);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_UNIT): return new EXPARecordDataBattleSettingUnit(rawRecord, cRecords);

                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BUILD_TABLE): return new EXPARecordDataBattleSettingBuildTable(rawRecord);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_CHARGE_SKILL): return new EXPARecordDataBattleSettingChargeSkill(rawRecord);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BUILD): return new EXPARecordDataBattleSettingBuild(rawRecord);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_PASSIVE_SKILL): return new EXPARecordDataBattleSettingPassiveSkill(rawRecord);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BATTLE_SKILL): return new EXPARecordDataBattleSettingBattleSkill(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BATTLE_SKILL_SET): return new EXPARecordDataBattleSettingBattleSkillSet(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BAD_CONDITION): return new EXPARecordDataBattleSettingBadCondition(rawRecord);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_CONDITION_EFFECT): return new EXPARecordDataBattleSettingConditionEffect(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_RANDOM_CONDITION): return new EXPARecordDataBattleSettingRandomCondition(rawRecord);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_MAP_SPECIAL_CELL): return new EXPARecordDataBattleSettingMapSpecialCell(rawRecord, cRecords);
                default: throw new Exception("The packer does not support this layout");
            }
            
        }

        public static int GetExpectedSize(EXPARecordLayout expaLayout)
        {
            switch (expaLayout.LayoutType)
            {
                case (EXPARecordLayoutType.TEXT): return new EXPARecordText().GetRawRecord().Length;
                case (EXPARecordLayoutType.TEXT_DECISION): return new EXPARecordTextDecision().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_EVENT_INFO): return new EXPARecordDataEventInfo().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_SET): return new EXPARecordDataEventProgressSet().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_INFO): return new EXPARecordDataEventProgressInfo().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_FIELD_DAY_CONDITION): return new EXPARecordDataFieldDayCondition().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT): return new EXPARecordDataFieldChapterSelect().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT_JUMP_INFO): return new EXPARecordDataFieldChapterSelectJumpInfo().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_UI_VR_BATTLE_MENU): return new EXPARecordDataUIVRBattleMenu().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_ID): return new EXPARecordDataBattleID().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID): return new EXPARecordDataBPPlaceID().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID_UI): return new EXPARecordDataBPPlaceIDUI().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BP_LOTTERY_GROUP_ID): return new EXPARecordDataBPLotteryGroupID().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BP_POSITION): return new EXPARecordDataBPPosition().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_UNIT): return new EXPARecordDataBattleSettingUnit().GetRawRecord().Length;

                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BUILD_TABLE): return new EXPARecordDataBattleSettingBuildTable().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_CHARGE_SKILL): return new EXPARecordDataBattleSettingChargeSkill().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BUILD): return new EXPARecordDataBattleSettingBuild().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_PASSIVE_SKILL): return new EXPARecordDataBattleSettingPassiveSkill().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BATTLE_SKILL): return new EXPARecordDataBattleSettingBattleSkill().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BATTLE_SKILL_SET): return new EXPARecordDataBattleSettingBattleSkillSet().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BAD_CONDITION): return new EXPARecordDataBattleSettingBadCondition().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_CONDITION_EFFECT): return new EXPARecordDataBattleSettingConditionEffect().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_RANDOM_CONDITION): return new EXPARecordDataBattleSettingRandomCondition().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_MAP_SPECIAL_CELL): return new EXPARecordDataBattleSettingMapSpecialCell().GetRawRecord().Length;
                default: throw new Exception("The packer does not support this layout");
            }
        }

        public static EXPARecord BuildRecordFromJson(EXPARecordLayout expaLayout, JsonObject json)
        {
            switch (expaLayout.LayoutType)
            {
                case (EXPARecordLayoutType.TEXT): return new EXPARecordText(json);
                case (EXPARecordLayoutType.TEXT_DECISION): return new EXPARecordTextDecision(json);
                case (EXPARecordLayoutType.DATA_EVENT_INFO): return new EXPARecordDataEventInfo(json);
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_SET): return new EXPARecordDataEventProgressSet(json);
                case (EXPARecordLayoutType.DATA_EVENT_PROGRESS_INFO): return new EXPARecordDataEventProgressInfo(json);
                case (EXPARecordLayoutType.DATA_FIELD_DAY_CONDITION): return new EXPARecordDataFieldDayCondition(json);
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT): return new EXPARecordDataFieldChapterSelect(json);
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT_JUMP_INFO): return new EXPARecordDataFieldChapterSelectJumpInfo(json);
                case (EXPARecordLayoutType.DATA_UI_VR_BATTLE_MENU): return new EXPARecordDataUIVRBattleMenu(json);
                case (EXPARecordLayoutType.DATA_BATTLE_ID): return new EXPARecordDataBattleID(json);
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID): return new EXPARecordDataBPPlaceID(json);
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID_UI): return new EXPARecordDataBPPlaceIDUI(json);
                case (EXPARecordLayoutType.DATA_BP_LOTTERY_GROUP_ID): return new EXPARecordDataBPLotteryGroupID(json);
                case (EXPARecordLayoutType.DATA_BP_POSITION): return new EXPARecordDataBPPosition(json);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_UNIT): return new EXPARecordDataBattleSettingUnit(json);

                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BUILD_TABLE): return new EXPARecordDataBattleSettingBuildTable(json);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_CHARGE_SKILL): return new EXPARecordDataBattleSettingChargeSkill(json);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BUILD): return new EXPARecordDataBattleSettingBuild(json);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_PASSIVE_SKILL): return new EXPARecordDataBattleSettingPassiveSkill(json);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BATTLE_SKILL): return new EXPARecordDataBattleSettingBattleSkill(json);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BATTLE_SKILL_SET): return new EXPARecordDataBattleSettingBattleSkillSet(json);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_BAD_CONDITION): return new EXPARecordDataBattleSettingBadCondition(json);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_CONDITION_EFFECT): return new EXPARecordDataBattleSettingConditionEffect(json);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_RANDOM_CONDITION): return new EXPARecordDataBattleSettingRandomCondition(json);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_MAP_SPECIAL_CELL): return new EXPARecordDataBattleSettingMapSpecialCell(json);
                default: throw new Exception("The packer does not support this layout");
            }
        }

        public abstract byte[] GetRawRecord();
        public abstract List<CHNKRecord> GenerateChunks();
        public abstract JsonObject GetJson();

    }
}
