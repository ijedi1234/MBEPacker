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
        DATA_FIELD_CHAPTER_SELECT_JUMP_INFO = 8, // data/field_chapter_select.mbe
        DATA_UI_VR_BATTLE_MENU = 9, // data/ui_vr_battle_menu.mbe
        DATA_BATTLE_ID = 10, // data/battle_id.mbe
        DATA_BP_PLACE_ID = 11, // data/bp_vr_battle_st07.mbe
        DATA_BP_PLACE_ID_UI = 12, // data/bp_vr_battle_st07.mbe
        DATA_BP_LOTTERY_GROUP_ID = 13, // data/bp_vr_battle_st07.mbe
        DATA_BP_POSITION = 14, // data/bp_vr_battle_st07.mbe
        DATA_BATTLE_SETTING_UNIT = 15, // data/battle_setting_unit.mbe

        DATA_BATTLE_SETTING_BUILD_TABLE = 16, // data/battle_setting.mbe
        DATA_BATTLE_SETTING_CHARGE_SKILL = 17, // data/battle_setting.mbe
        DATA_BATTLE_SETTING_BUILD = 18, // data/battle_setting.mbe
        DATA_BATTLE_SETTING_PASSIVE_SKILL = 19, // data/battle_setting.mbe
        DATA_BATTLE_SETTING_BATTLE_SKILL = 20, // data/battle_setting.mbe
        DATA_BATTLE_SETTING_BATTLE_SKILL_SET = 21, // data/battle_setting.mbe
        DATA_BATTLE_SETTING_BAD_CONDITION = 22, // data/battle_setting.mbe
        DATA_BATTLE_SETTING_CONDITION_EFFECT = 23, // data/battle_setting.mbe
        DATA_BATTLE_SETTING_RANDOM_CONDITION = 24, // data/battle_setting.mbe
        DATA_BATTLE_SETTING_MAP_SPECIAL_CELL = 25, // data/battle_setting.mbe

        DATA_BATTLE_SKILL_ACT = 26, // data/battle_skill_act.mbe
        DATA_BATTLE_SHIELD_MODE = 27 // data/battle_skill_act.mbe
    }
}
