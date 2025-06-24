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
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT): return new EXPARecordDataFieldChapterSelect(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT_JUMP_INFO): return new EXPARecordDataFieldChapterSelectJumpInfo(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_UI_VR_BATTLE_MENU): return new EXPARecordDataUIVRBattleMenu(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_BATTLE_ID): return new EXPARecordDataBattleID(rawRecord, cRecords);
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID): return new EXPARecordDataBPPlaceID(rawRecord);
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID_UI): return new EXPARecordDataBPPlaceIDUI(rawRecord);
                case (EXPARecordLayoutType.DATA_BP_LOTTERY_GROUP_ID): return new EXPARecordDataBPLotteryGroupID(rawRecord);
                case (EXPARecordLayoutType.DATA_BP_POSITION): return new EXPARecordDataBPPosition(rawRecord);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_UNIT): return new EXPARecordDataBattleSettingUnit(rawRecord, cRecords);
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
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT): return new EXPARecordDataFieldChapterSelect().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT_JUMP_INFO): return new EXPARecordDataFieldChapterSelectJumpInfo().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_UI_VR_BATTLE_MENU): return new EXPARecordDataUIVRBattleMenu().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_ID): return new EXPARecordDataBattleID().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID): return new EXPARecordDataBPPlaceID().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID_UI): return new EXPARecordDataBPPlaceIDUI().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BP_LOTTERY_GROUP_ID): return new EXPARecordDataBPLotteryGroupID().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BP_POSITION): return new EXPARecordDataBPPosition().GetRawRecord().Length;
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_UNIT): return new EXPARecordDataBattleSettingUnit().GetRawRecord().Length;
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
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT): return new EXPARecordDataFieldChapterSelect(json);
                case (EXPARecordLayoutType.DATA_FIELD_CHAPTER_SELECT_JUMP_INFO): return new EXPARecordDataFieldChapterSelectJumpInfo(json);
                case (EXPARecordLayoutType.DATA_UI_VR_BATTLE_MENU): return new EXPARecordDataUIVRBattleMenu(json);
                case (EXPARecordLayoutType.DATA_BATTLE_ID): return new EXPARecordDataBattleID(json);
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID): return new EXPARecordDataBPPlaceID(json);
                case (EXPARecordLayoutType.DATA_BP_PLACE_ID_UI): return new EXPARecordDataBPPlaceIDUI(json);
                case (EXPARecordLayoutType.DATA_BP_LOTTERY_GROUP_ID): return new EXPARecordDataBPLotteryGroupID(json);
                case (EXPARecordLayoutType.DATA_BP_POSITION): return new EXPARecordDataBPPosition(json);
                case (EXPARecordLayoutType.DATA_BATTLE_SETTING_UNIT): return new EXPARecordDataBattleSettingUnit(json);
                default: throw new Exception("The packer does not support this layout");
            }
            return new EXPARecordText(json);
        }

        public abstract byte[] GetRawRecord();
        public abstract List<CHNKRecord> GenerateChunks();
        public abstract JsonObject GetJson();

    }
}
