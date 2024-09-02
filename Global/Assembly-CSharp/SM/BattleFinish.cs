// Decompiled with JetBrains decompiler
// Type: SM.BattleFinish
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class BattleFinish : KeyCompare
  {
    public PlayerHelper[] battle_helpers;
    public int player_mvp_unit_id;
    public int player_incr_exp;
    public BattleFinishDrop_unit_entities[] drop_unit_entities;
    public PlayerItem[] after_player_gears;
    public Player before_player;
    public int player_incr_money;
    public PlayerUnit[] after_player_units;
    public int incr_friend_point;
    public BattleFinishStage_clear_rewards[] stage_clear_rewards;
    public UnlockQuest[] unlock_quests;
    public BattleFinishDrop_gear_entities[] drop_gear_entities;
    public int[] disappeared_player_gears;
    public QuestScoreBattleFinishContext[] score_campaigns;
    public BattleFinishDrop_supply_entities[] drop_supply_entities;
    public BattleFinishBoost_stage_clear_rewards[] boost_stage_clear_rewards;
    public PlayerMissionHistory[] player_mission_results;
    public BattleFinishPlayer_character_intimates_in_battle[] player_character_intimates_in_battle;
    public PlayerUnit[] before_player_units;
    public PlayerItem[] before_player_gears;

    public BattleFinish()
    {
    }

    public BattleFinish(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
      foreach (object json1 in (List<object>) json[nameof (battle_helpers)])
        playerHelperList.Add(json1 != null ? new PlayerHelper((Dictionary<string, object>) json1) : (PlayerHelper) null);
      this.battle_helpers = playerHelperList.ToArray();
      this.player_mvp_unit_id = (int) (long) json[nameof (player_mvp_unit_id)];
      this.player_incr_exp = (int) (long) json[nameof (player_incr_exp)];
      List<BattleFinishDrop_unit_entities> dropUnitEntitiesList = new List<BattleFinishDrop_unit_entities>();
      foreach (object json2 in (List<object>) json[nameof (drop_unit_entities)])
        dropUnitEntitiesList.Add(json2 != null ? new BattleFinishDrop_unit_entities((Dictionary<string, object>) json2) : (BattleFinishDrop_unit_entities) null);
      this.drop_unit_entities = dropUnitEntitiesList.ToArray();
      List<PlayerItem> playerItemList1 = new List<PlayerItem>();
      foreach (object json3 in (List<object>) json[nameof (after_player_gears)])
        playerItemList1.Add(json3 != null ? new PlayerItem((Dictionary<string, object>) json3) : (PlayerItem) null);
      this.after_player_gears = playerItemList1.ToArray();
      this.before_player = json[nameof (before_player)] != null ? new Player((Dictionary<string, object>) json[nameof (before_player)]) : (Player) null;
      this.player_incr_money = (int) (long) json[nameof (player_incr_money)];
      List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
      foreach (object json4 in (List<object>) json[nameof (after_player_units)])
        playerUnitList1.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
      this.after_player_units = playerUnitList1.ToArray();
      this.incr_friend_point = (int) (long) json[nameof (incr_friend_point)];
      List<BattleFinishStage_clear_rewards> stageClearRewardsList1 = new List<BattleFinishStage_clear_rewards>();
      foreach (object json5 in (List<object>) json[nameof (stage_clear_rewards)])
        stageClearRewardsList1.Add(json5 != null ? new BattleFinishStage_clear_rewards((Dictionary<string, object>) json5) : (BattleFinishStage_clear_rewards) null);
      this.stage_clear_rewards = stageClearRewardsList1.ToArray();
      List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
      foreach (object json6 in (List<object>) json[nameof (unlock_quests)])
        unlockQuestList.Add(json6 != null ? new UnlockQuest((Dictionary<string, object>) json6) : (UnlockQuest) null);
      this.unlock_quests = unlockQuestList.ToArray();
      List<BattleFinishDrop_gear_entities> dropGearEntitiesList = new List<BattleFinishDrop_gear_entities>();
      foreach (object json7 in (List<object>) json[nameof (drop_gear_entities)])
        dropGearEntitiesList.Add(json7 != null ? new BattleFinishDrop_gear_entities((Dictionary<string, object>) json7) : (BattleFinishDrop_gear_entities) null);
      this.drop_gear_entities = dropGearEntitiesList.ToArray();
      this.disappeared_player_gears = ((IEnumerable<object>) json[nameof (disappeared_player_gears)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      List<QuestScoreBattleFinishContext> battleFinishContextList = new List<QuestScoreBattleFinishContext>();
      foreach (object json8 in (List<object>) json[nameof (score_campaigns)])
        battleFinishContextList.Add(json8 != null ? new QuestScoreBattleFinishContext((Dictionary<string, object>) json8) : (QuestScoreBattleFinishContext) null);
      this.score_campaigns = battleFinishContextList.ToArray();
      List<BattleFinishDrop_supply_entities> dropSupplyEntitiesList = new List<BattleFinishDrop_supply_entities>();
      foreach (object json9 in (List<object>) json[nameof (drop_supply_entities)])
        dropSupplyEntitiesList.Add(json9 != null ? new BattleFinishDrop_supply_entities((Dictionary<string, object>) json9) : (BattleFinishDrop_supply_entities) null);
      this.drop_supply_entities = dropSupplyEntitiesList.ToArray();
      List<BattleFinishBoost_stage_clear_rewards> stageClearRewardsList2 = new List<BattleFinishBoost_stage_clear_rewards>();
      foreach (object json10 in (List<object>) json[nameof (boost_stage_clear_rewards)])
        stageClearRewardsList2.Add(json10 != null ? new BattleFinishBoost_stage_clear_rewards((Dictionary<string, object>) json10) : (BattleFinishBoost_stage_clear_rewards) null);
      this.boost_stage_clear_rewards = stageClearRewardsList2.ToArray();
      List<PlayerMissionHistory> playerMissionHistoryList = new List<PlayerMissionHistory>();
      foreach (object json11 in (List<object>) json[nameof (player_mission_results)])
        playerMissionHistoryList.Add(json11 != null ? new PlayerMissionHistory((Dictionary<string, object>) json11) : (PlayerMissionHistory) null);
      this.player_mission_results = playerMissionHistoryList.ToArray();
      List<BattleFinishPlayer_character_intimates_in_battle> intimatesInBattleList = new List<BattleFinishPlayer_character_intimates_in_battle>();
      foreach (object json12 in (List<object>) json[nameof (player_character_intimates_in_battle)])
        intimatesInBattleList.Add(json12 != null ? new BattleFinishPlayer_character_intimates_in_battle((Dictionary<string, object>) json12) : (BattleFinishPlayer_character_intimates_in_battle) null);
      this.player_character_intimates_in_battle = intimatesInBattleList.ToArray();
      List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
      foreach (object json13 in (List<object>) json[nameof (before_player_units)])
        playerUnitList2.Add(json13 != null ? new PlayerUnit((Dictionary<string, object>) json13) : (PlayerUnit) null);
      this.before_player_units = playerUnitList2.ToArray();
      List<PlayerItem> playerItemList2 = new List<PlayerItem>();
      foreach (object json14 in (List<object>) json[nameof (before_player_gears)])
        playerItemList2.Add(json14 != null ? new PlayerItem((Dictionary<string, object>) json14) : (PlayerItem) null);
      this.before_player_gears = playerItemList2.ToArray();
    }
  }
}
