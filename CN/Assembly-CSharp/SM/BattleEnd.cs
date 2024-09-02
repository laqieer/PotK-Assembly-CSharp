﻿// Decompiled with JetBrains decompiler
// Type: SM.BattleEnd
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class BattleEnd : KeyCompare
  {
    public BattleEndDrop_gear_entities[] drop_gear_entities;
    public int incr_friend_point;
    public int player_incr_exp;
    public BattleEndPlayer_character_intimates_in_battle[] player_character_intimates_in_battle;
    public PlayerItem[] after_player_gears;
    public BattleEndStage_clear_rewards[] stage_clear_rewards;
    public int player_incr_money;
    public BattleEndUnlock_messages[] unlock_messages;
    public BattleEndDrop_material_unit_entities[] drop_material_unit_entities;
    public EventBattleFinish[] events;
    public int player_mvp_unit_id;
    public PlayerHelper[] battle_helpers;
    public BattleEndMission_complete_rewards[] mission_complete_rewards;
    public UnlockQuest[] unlock_quests;
    public int[] disappeared_player_gears;
    public Player before_player;
    public QuestScoreBattleFinishContext[] score_campaigns;
    public BattleEndBoost_stage_clear_rewards[] boost_stage_clear_rewards;
    public PlayerMissionHistory[] player_mission_results;
    public PlayerUnit[] before_player_units;
    public BattleEndDrop_unit_entities[] drop_unit_entities;
    public PlayerItem[] before_player_gears;
    public PlayerUnit[] after_player_units;
    public BattleEndDrop_supply_entities[] drop_supply_entities;
    public UnlockIntimateSkill[] unlock_intimate_skills;
    public BattleEndPlayer_review player_review;

    public BattleEnd()
    {
    }

    public BattleEnd(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<BattleEndDrop_gear_entities> dropGearEntitiesList = new List<BattleEndDrop_gear_entities>();
      foreach (object json1 in (List<object>) json[nameof (drop_gear_entities)])
        dropGearEntitiesList.Add(json1 != null ? new BattleEndDrop_gear_entities((Dictionary<string, object>) json1) : (BattleEndDrop_gear_entities) null);
      this.drop_gear_entities = dropGearEntitiesList.ToArray();
      this.incr_friend_point = (int) (long) json[nameof (incr_friend_point)];
      this.player_incr_exp = (int) (long) json[nameof (player_incr_exp)];
      List<BattleEndPlayer_character_intimates_in_battle> intimatesInBattleList = new List<BattleEndPlayer_character_intimates_in_battle>();
      foreach (object json2 in (List<object>) json[nameof (player_character_intimates_in_battle)])
        intimatesInBattleList.Add(json2 != null ? new BattleEndPlayer_character_intimates_in_battle((Dictionary<string, object>) json2) : (BattleEndPlayer_character_intimates_in_battle) null);
      this.player_character_intimates_in_battle = intimatesInBattleList.ToArray();
      List<PlayerItem> playerItemList1 = new List<PlayerItem>();
      foreach (object json3 in (List<object>) json[nameof (after_player_gears)])
        playerItemList1.Add(json3 != null ? new PlayerItem((Dictionary<string, object>) json3) : (PlayerItem) null);
      this.after_player_gears = playerItemList1.ToArray();
      List<BattleEndStage_clear_rewards> stageClearRewardsList1 = new List<BattleEndStage_clear_rewards>();
      foreach (object json4 in (List<object>) json[nameof (stage_clear_rewards)])
        stageClearRewardsList1.Add(json4 != null ? new BattleEndStage_clear_rewards((Dictionary<string, object>) json4) : (BattleEndStage_clear_rewards) null);
      this.stage_clear_rewards = stageClearRewardsList1.ToArray();
      this.player_incr_money = (int) (long) json[nameof (player_incr_money)];
      List<BattleEndUnlock_messages> endUnlockMessagesList = new List<BattleEndUnlock_messages>();
      foreach (object json5 in (List<object>) json[nameof (unlock_messages)])
        endUnlockMessagesList.Add(json5 != null ? new BattleEndUnlock_messages((Dictionary<string, object>) json5) : (BattleEndUnlock_messages) null);
      this.unlock_messages = endUnlockMessagesList.ToArray();
      List<BattleEndDrop_material_unit_entities> materialUnitEntitiesList = new List<BattleEndDrop_material_unit_entities>();
      foreach (object json6 in (List<object>) json[nameof (drop_material_unit_entities)])
        materialUnitEntitiesList.Add(json6 != null ? new BattleEndDrop_material_unit_entities((Dictionary<string, object>) json6) : (BattleEndDrop_material_unit_entities) null);
      this.drop_material_unit_entities = materialUnitEntitiesList.ToArray();
      List<EventBattleFinish> eventBattleFinishList = new List<EventBattleFinish>();
      foreach (object json7 in (List<object>) json[nameof (events)])
        eventBattleFinishList.Add(json7 != null ? new EventBattleFinish((Dictionary<string, object>) json7) : (EventBattleFinish) null);
      this.events = eventBattleFinishList.ToArray();
      this.player_mvp_unit_id = (int) (long) json[nameof (player_mvp_unit_id)];
      List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
      foreach (object json8 in (List<object>) json[nameof (battle_helpers)])
        playerHelperList.Add(json8 != null ? new PlayerHelper((Dictionary<string, object>) json8) : (PlayerHelper) null);
      this.battle_helpers = playerHelperList.ToArray();
      List<BattleEndMission_complete_rewards> missionCompleteRewardsList = new List<BattleEndMission_complete_rewards>();
      foreach (object json9 in (List<object>) json[nameof (mission_complete_rewards)])
        missionCompleteRewardsList.Add(json9 != null ? new BattleEndMission_complete_rewards((Dictionary<string, object>) json9) : (BattleEndMission_complete_rewards) null);
      this.mission_complete_rewards = missionCompleteRewardsList.ToArray();
      List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
      foreach (object json10 in (List<object>) json[nameof (unlock_quests)])
        unlockQuestList.Add(json10 != null ? new UnlockQuest((Dictionary<string, object>) json10) : (UnlockQuest) null);
      this.unlock_quests = unlockQuestList.ToArray();
      this.disappeared_player_gears = ((IEnumerable<object>) json[nameof (disappeared_player_gears)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      this.before_player = json[nameof (before_player)] != null ? new Player((Dictionary<string, object>) json[nameof (before_player)]) : (Player) null;
      List<QuestScoreBattleFinishContext> battleFinishContextList = new List<QuestScoreBattleFinishContext>();
      foreach (object json11 in (List<object>) json[nameof (score_campaigns)])
        battleFinishContextList.Add(json11 != null ? new QuestScoreBattleFinishContext((Dictionary<string, object>) json11) : (QuestScoreBattleFinishContext) null);
      this.score_campaigns = battleFinishContextList.ToArray();
      List<BattleEndBoost_stage_clear_rewards> stageClearRewardsList2 = new List<BattleEndBoost_stage_clear_rewards>();
      foreach (object json12 in (List<object>) json[nameof (boost_stage_clear_rewards)])
        stageClearRewardsList2.Add(json12 != null ? new BattleEndBoost_stage_clear_rewards((Dictionary<string, object>) json12) : (BattleEndBoost_stage_clear_rewards) null);
      this.boost_stage_clear_rewards = stageClearRewardsList2.ToArray();
      List<PlayerMissionHistory> playerMissionHistoryList = new List<PlayerMissionHistory>();
      foreach (object json13 in (List<object>) json[nameof (player_mission_results)])
        playerMissionHistoryList.Add(json13 != null ? new PlayerMissionHistory((Dictionary<string, object>) json13) : (PlayerMissionHistory) null);
      this.player_mission_results = playerMissionHistoryList.ToArray();
      List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
      foreach (object json14 in (List<object>) json[nameof (before_player_units)])
        playerUnitList1.Add(json14 != null ? new PlayerUnit((Dictionary<string, object>) json14) : (PlayerUnit) null);
      this.before_player_units = playerUnitList1.ToArray();
      List<BattleEndDrop_unit_entities> dropUnitEntitiesList = new List<BattleEndDrop_unit_entities>();
      foreach (object json15 in (List<object>) json[nameof (drop_unit_entities)])
        dropUnitEntitiesList.Add(json15 != null ? new BattleEndDrop_unit_entities((Dictionary<string, object>) json15) : (BattleEndDrop_unit_entities) null);
      this.drop_unit_entities = dropUnitEntitiesList.ToArray();
      List<PlayerItem> playerItemList2 = new List<PlayerItem>();
      foreach (object json16 in (List<object>) json[nameof (before_player_gears)])
        playerItemList2.Add(json16 != null ? new PlayerItem((Dictionary<string, object>) json16) : (PlayerItem) null);
      this.before_player_gears = playerItemList2.ToArray();
      List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
      foreach (object json17 in (List<object>) json[nameof (after_player_units)])
        playerUnitList2.Add(json17 != null ? new PlayerUnit((Dictionary<string, object>) json17) : (PlayerUnit) null);
      this.after_player_units = playerUnitList2.ToArray();
      List<BattleEndDrop_supply_entities> dropSupplyEntitiesList = new List<BattleEndDrop_supply_entities>();
      foreach (object json18 in (List<object>) json[nameof (drop_supply_entities)])
        dropSupplyEntitiesList.Add(json18 != null ? new BattleEndDrop_supply_entities((Dictionary<string, object>) json18) : (BattleEndDrop_supply_entities) null);
      this.drop_supply_entities = dropSupplyEntitiesList.ToArray();
      List<UnlockIntimateSkill> unlockIntimateSkillList = new List<UnlockIntimateSkill>();
      foreach (object json19 in (List<object>) json[nameof (unlock_intimate_skills)])
        unlockIntimateSkillList.Add(json19 != null ? new UnlockIntimateSkill((Dictionary<string, object>) json19) : (UnlockIntimateSkill) null);
      this.unlock_intimate_skills = unlockIntimateSkillList.ToArray();
      this.player_review = json[nameof (player_review)] != null ? new BattleEndPlayer_review((Dictionary<string, object>) json[nameof (player_review)]) : (BattleEndPlayer_review) null;
    }
  }
}
