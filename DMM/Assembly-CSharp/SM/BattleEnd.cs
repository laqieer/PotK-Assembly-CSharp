// Decompiled with JetBrains decompiler
// Type: SM.BattleEnd
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

namespace SM
{
  [Serializable]
  public class BattleEnd : KeyCompare
  {
    public int player_mvp_unit_id;
    public BattleEndGain_trust_info[] gain_trust_info;
    public BattleEndDrop_gear_entities[] drop_gear_entities;
    public BattleEndDrop_unit_type_ticket_entities[] drop_unit_type_ticket_entities;
    public int incr_friend_point;
    public int player_incr_exp;
    public BattleEndPlayer_character_intimates_in_battle[] player_character_intimates_in_battle;
    public PlayerItem[] after_player_gears;
    public BattleEndStage_clear_rewards[] stage_clear_rewards;
    public long player_incr_money;
    public BattleEndDrop_common_ticket_entities[] drop_common_ticket_entities;
    public BattleEndUnlock_messages[] unlock_messages;
    public BattleEndDrop_material_unit_entities[] drop_material_unit_entities;
    public EventBattleFinish[] events;
    public int deck_number;
    public BattleEndGet_sea_album_piece_counts[] get_sea_album_piece_counts;
    public int deck_type_id;
    public PlayerHelper[] battle_helpers;
    public BattleEndMission_complete_rewards[] mission_complete_rewards;
    public BattleEndDrop_unit_ticket_entities[] drop_unit_ticket_entities;
    public UnlockQuest[] unlock_quests;
    public int[] disappeared_player_gears;
    public int[] gettable_piece_same_character_ids;
    public Player before_player;
    public QuestScoreBattleFinishContext[] score_campaigns;
    public BattleEndBoost_stage_clear_rewards[] boost_stage_clear_rewards;
    public PlayerMissionHistory[] player_mission_results;
    public PlayerUnit[] before_player_units;
    public int[] receive_sea_album_ids;
    public BattleEndDrop_material_gear_entities[] drop_material_gear_entities;
    public BattleEndDrop_unit_entities[] drop_unit_entities;
    public PlayerItem[] before_player_gears;
    public PlayerUnit[] after_player_units;
    public BattleEndTrust_upper_limit[] trust_upper_limit;
    public BattleEndDrop_quest_key_entities[] drop_quest_key_entities;
    public BattleEndDrop_supply_entities[] drop_supply_entities;
    public UnlockIntimateSkill[] unlock_intimate_skills;
    public BattleEndDrop_gacha_ticket_entities[] drop_gacha_ticket_entities;
    public BattleEndPlayer_review player_review;

    public BattleEnd()
    {
    }

    public BattleEnd(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player_mvp_unit_id = (int) (long) json[nameof (player_mvp_unit_id)];
      List<BattleEndGain_trust_info> endGainTrustInfoList = new List<BattleEndGain_trust_info>();
      foreach (object obj in (List<object>) json[nameof (gain_trust_info)])
        endGainTrustInfoList.Add(obj == null ? (BattleEndGain_trust_info) null : new BattleEndGain_trust_info((Dictionary<string, object>) obj));
      this.gain_trust_info = endGainTrustInfoList.ToArray();
      List<BattleEndDrop_gear_entities> dropGearEntitiesList = new List<BattleEndDrop_gear_entities>();
      foreach (object obj in (List<object>) json[nameof (drop_gear_entities)])
        dropGearEntitiesList.Add(obj == null ? (BattleEndDrop_gear_entities) null : new BattleEndDrop_gear_entities((Dictionary<string, object>) obj));
      this.drop_gear_entities = dropGearEntitiesList.ToArray();
      List<BattleEndDrop_unit_type_ticket_entities> typeTicketEntitiesList = new List<BattleEndDrop_unit_type_ticket_entities>();
      foreach (object obj in (List<object>) json[nameof (drop_unit_type_ticket_entities)])
        typeTicketEntitiesList.Add(obj == null ? (BattleEndDrop_unit_type_ticket_entities) null : new BattleEndDrop_unit_type_ticket_entities((Dictionary<string, object>) obj));
      this.drop_unit_type_ticket_entities = typeTicketEntitiesList.ToArray();
      this.incr_friend_point = (int) (long) json[nameof (incr_friend_point)];
      this.player_incr_exp = (int) (long) json[nameof (player_incr_exp)];
      List<BattleEndPlayer_character_intimates_in_battle> intimatesInBattleList = new List<BattleEndPlayer_character_intimates_in_battle>();
      foreach (object obj in (List<object>) json[nameof (player_character_intimates_in_battle)])
        intimatesInBattleList.Add(obj == null ? (BattleEndPlayer_character_intimates_in_battle) null : new BattleEndPlayer_character_intimates_in_battle((Dictionary<string, object>) obj));
      this.player_character_intimates_in_battle = intimatesInBattleList.ToArray();
      List<PlayerItem> playerItemList1 = new List<PlayerItem>();
      foreach (object obj in (List<object>) json[nameof (after_player_gears)])
        playerItemList1.Add(obj == null ? (PlayerItem) null : new PlayerItem((Dictionary<string, object>) obj));
      this.after_player_gears = playerItemList1.ToArray();
      List<BattleEndStage_clear_rewards> stageClearRewardsList1 = new List<BattleEndStage_clear_rewards>();
      foreach (object obj in (List<object>) json[nameof (stage_clear_rewards)])
        stageClearRewardsList1.Add(obj == null ? (BattleEndStage_clear_rewards) null : new BattleEndStage_clear_rewards((Dictionary<string, object>) obj));
      this.stage_clear_rewards = stageClearRewardsList1.ToArray();
      this.player_incr_money = (long) json[nameof (player_incr_money)];
      List<BattleEndDrop_common_ticket_entities> commonTicketEntitiesList = new List<BattleEndDrop_common_ticket_entities>();
      foreach (object obj in (List<object>) json[nameof (drop_common_ticket_entities)])
        commonTicketEntitiesList.Add(obj == null ? (BattleEndDrop_common_ticket_entities) null : new BattleEndDrop_common_ticket_entities((Dictionary<string, object>) obj));
      this.drop_common_ticket_entities = commonTicketEntitiesList.ToArray();
      List<BattleEndUnlock_messages> endUnlockMessagesList = new List<BattleEndUnlock_messages>();
      foreach (object obj in (List<object>) json[nameof (unlock_messages)])
        endUnlockMessagesList.Add(obj == null ? (BattleEndUnlock_messages) null : new BattleEndUnlock_messages((Dictionary<string, object>) obj));
      this.unlock_messages = endUnlockMessagesList.ToArray();
      List<BattleEndDrop_material_unit_entities> materialUnitEntitiesList = new List<BattleEndDrop_material_unit_entities>();
      foreach (object obj in (List<object>) json[nameof (drop_material_unit_entities)])
        materialUnitEntitiesList.Add(obj == null ? (BattleEndDrop_material_unit_entities) null : new BattleEndDrop_material_unit_entities((Dictionary<string, object>) obj));
      this.drop_material_unit_entities = materialUnitEntitiesList.ToArray();
      List<EventBattleFinish> eventBattleFinishList = new List<EventBattleFinish>();
      foreach (object obj in (List<object>) json[nameof (events)])
        eventBattleFinishList.Add(obj == null ? (EventBattleFinish) null : new EventBattleFinish((Dictionary<string, object>) obj));
      this.events = eventBattleFinishList.ToArray();
      this.deck_number = (int) (long) json[nameof (deck_number)];
      List<BattleEndGet_sea_album_piece_counts> albumPieceCountsList = new List<BattleEndGet_sea_album_piece_counts>();
      foreach (object obj in (List<object>) json[nameof (get_sea_album_piece_counts)])
        albumPieceCountsList.Add(obj == null ? (BattleEndGet_sea_album_piece_counts) null : new BattleEndGet_sea_album_piece_counts((Dictionary<string, object>) obj));
      this.get_sea_album_piece_counts = albumPieceCountsList.ToArray();
      this.deck_type_id = (int) (long) json[nameof (deck_type_id)];
      List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
      foreach (object obj in (List<object>) json[nameof (battle_helpers)])
        playerHelperList.Add(obj == null ? (PlayerHelper) null : new PlayerHelper((Dictionary<string, object>) obj));
      this.battle_helpers = playerHelperList.ToArray();
      List<BattleEndMission_complete_rewards> missionCompleteRewardsList = new List<BattleEndMission_complete_rewards>();
      foreach (object obj in (List<object>) json[nameof (mission_complete_rewards)])
        missionCompleteRewardsList.Add(obj == null ? (BattleEndMission_complete_rewards) null : new BattleEndMission_complete_rewards((Dictionary<string, object>) obj));
      this.mission_complete_rewards = missionCompleteRewardsList.ToArray();
      List<BattleEndDrop_unit_ticket_entities> unitTicketEntitiesList = new List<BattleEndDrop_unit_ticket_entities>();
      foreach (object obj in (List<object>) json[nameof (drop_unit_ticket_entities)])
        unitTicketEntitiesList.Add(obj == null ? (BattleEndDrop_unit_ticket_entities) null : new BattleEndDrop_unit_ticket_entities((Dictionary<string, object>) obj));
      this.drop_unit_ticket_entities = unitTicketEntitiesList.ToArray();
      List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
      foreach (object obj in (List<object>) json[nameof (unlock_quests)])
        unlockQuestList.Add(obj == null ? (UnlockQuest) null : new UnlockQuest((Dictionary<string, object>) obj));
      this.unlock_quests = unlockQuestList.ToArray();
      this.disappeared_player_gears = ((IEnumerable<object>) json[nameof (disappeared_player_gears)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      this.gettable_piece_same_character_ids = ((IEnumerable<object>) json[nameof (gettable_piece_same_character_ids)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      this.before_player = json[nameof (before_player)] == null ? (Player) null : new Player((Dictionary<string, object>) json[nameof (before_player)]);
      List<QuestScoreBattleFinishContext> battleFinishContextList = new List<QuestScoreBattleFinishContext>();
      foreach (object obj in (List<object>) json[nameof (score_campaigns)])
        battleFinishContextList.Add(obj == null ? (QuestScoreBattleFinishContext) null : new QuestScoreBattleFinishContext((Dictionary<string, object>) obj));
      this.score_campaigns = battleFinishContextList.ToArray();
      List<BattleEndBoost_stage_clear_rewards> stageClearRewardsList2 = new List<BattleEndBoost_stage_clear_rewards>();
      foreach (object obj in (List<object>) json[nameof (boost_stage_clear_rewards)])
        stageClearRewardsList2.Add(obj == null ? (BattleEndBoost_stage_clear_rewards) null : new BattleEndBoost_stage_clear_rewards((Dictionary<string, object>) obj));
      this.boost_stage_clear_rewards = stageClearRewardsList2.ToArray();
      List<PlayerMissionHistory> playerMissionHistoryList = new List<PlayerMissionHistory>();
      foreach (object obj in (List<object>) json[nameof (player_mission_results)])
        playerMissionHistoryList.Add(obj == null ? (PlayerMissionHistory) null : new PlayerMissionHistory((Dictionary<string, object>) obj));
      this.player_mission_results = playerMissionHistoryList.ToArray();
      List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
      foreach (object obj in (List<object>) json[nameof (before_player_units)])
        playerUnitList1.Add(obj == null ? (PlayerUnit) null : new PlayerUnit((Dictionary<string, object>) obj));
      this.before_player_units = playerUnitList1.ToArray();
      this.receive_sea_album_ids = ((IEnumerable<object>) json[nameof (receive_sea_album_ids)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      List<BattleEndDrop_material_gear_entities> materialGearEntitiesList = new List<BattleEndDrop_material_gear_entities>();
      foreach (object obj in (List<object>) json[nameof (drop_material_gear_entities)])
        materialGearEntitiesList.Add(obj == null ? (BattleEndDrop_material_gear_entities) null : new BattleEndDrop_material_gear_entities((Dictionary<string, object>) obj));
      this.drop_material_gear_entities = materialGearEntitiesList.ToArray();
      List<BattleEndDrop_unit_entities> dropUnitEntitiesList = new List<BattleEndDrop_unit_entities>();
      foreach (object obj in (List<object>) json[nameof (drop_unit_entities)])
        dropUnitEntitiesList.Add(obj == null ? (BattleEndDrop_unit_entities) null : new BattleEndDrop_unit_entities((Dictionary<string, object>) obj));
      this.drop_unit_entities = dropUnitEntitiesList.ToArray();
      List<PlayerItem> playerItemList2 = new List<PlayerItem>();
      foreach (object obj in (List<object>) json[nameof (before_player_gears)])
        playerItemList2.Add(obj == null ? (PlayerItem) null : new PlayerItem((Dictionary<string, object>) obj));
      this.before_player_gears = playerItemList2.ToArray();
      List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
      foreach (object obj in (List<object>) json[nameof (after_player_units)])
        playerUnitList2.Add(obj == null ? (PlayerUnit) null : new PlayerUnit((Dictionary<string, object>) obj));
      this.after_player_units = playerUnitList2.ToArray();
      List<BattleEndTrust_upper_limit> endTrustUpperLimitList = new List<BattleEndTrust_upper_limit>();
      foreach (object obj in (List<object>) json[nameof (trust_upper_limit)])
        endTrustUpperLimitList.Add(obj == null ? (BattleEndTrust_upper_limit) null : new BattleEndTrust_upper_limit((Dictionary<string, object>) obj));
      this.trust_upper_limit = endTrustUpperLimitList.ToArray();
      List<BattleEndDrop_quest_key_entities> questKeyEntitiesList = new List<BattleEndDrop_quest_key_entities>();
      foreach (object obj in (List<object>) json[nameof (drop_quest_key_entities)])
        questKeyEntitiesList.Add(obj == null ? (BattleEndDrop_quest_key_entities) null : new BattleEndDrop_quest_key_entities((Dictionary<string, object>) obj));
      this.drop_quest_key_entities = questKeyEntitiesList.ToArray();
      List<BattleEndDrop_supply_entities> dropSupplyEntitiesList = new List<BattleEndDrop_supply_entities>();
      foreach (object obj in (List<object>) json[nameof (drop_supply_entities)])
        dropSupplyEntitiesList.Add(obj == null ? (BattleEndDrop_supply_entities) null : new BattleEndDrop_supply_entities((Dictionary<string, object>) obj));
      this.drop_supply_entities = dropSupplyEntitiesList.ToArray();
      List<UnlockIntimateSkill> unlockIntimateSkillList = new List<UnlockIntimateSkill>();
      foreach (object obj in (List<object>) json[nameof (unlock_intimate_skills)])
        unlockIntimateSkillList.Add(obj == null ? (UnlockIntimateSkill) null : new UnlockIntimateSkill((Dictionary<string, object>) obj));
      this.unlock_intimate_skills = unlockIntimateSkillList.ToArray();
      List<BattleEndDrop_gacha_ticket_entities> gachaTicketEntitiesList = new List<BattleEndDrop_gacha_ticket_entities>();
      foreach (object obj in (List<object>) json[nameof (drop_gacha_ticket_entities)])
        gachaTicketEntitiesList.Add(obj == null ? (BattleEndDrop_gacha_ticket_entities) null : new BattleEndDrop_gacha_ticket_entities((Dictionary<string, object>) obj));
      this.drop_gacha_ticket_entities = gachaTicketEntitiesList.ToArray();
      this.player_review = json[nameof (player_review)] == null ? (BattleEndPlayer_review) null : new BattleEndPlayer_review((Dictionary<string, object>) json[nameof (player_review)]);
    }
  }
}
