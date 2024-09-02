// Decompiled with JetBrains decompiler
// Type: GameCore.BattleInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace GameCore
{
  [Serializable]
  public class BattleInfo
  {
    public bool pvp;
    public bool pvp_restart;
    public string host;
    public int port;
    public string battleToken;
    public bool gvg;
    public GVGSetting gvgSetting;
    public bool isEarthMode;
    public bool isExtraEarthQuest;
    public bool isLoadData;
    public string battleId = string.Empty;
    public int quest_s_id;
    public int quest_loop_count;
    public CommonQuestType quest_type = CommonQuestType.Story;
    private int mStageId = 1;
    public bool isAutoBattleEnable = true;
    public bool isContinueEnable = true;
    public bool isRetreatEnable = true;
    public bool isStoryEnable = true;
    public PlayerHelper helper;
    public int deckIndex;
    public int[] guest_ids = new int[0];
    private int[] mEnemy_ids;
    private Tuple<int, Reward>[] mEnemy_items;
    private PlayerUnit[] mUser_units;
    private PlayerItem[] mUser_items;
    private int[] mUser_enemy_ids;
    private Tuple<int, Reward>[] mUser_enemy_items;
    private int[] mPanel_ids;
    private Tuple<int, Reward>[] mPanel_items;
    public PlayerStoryQuestS storyQuest;
    public PlayerExtraQuestS extraQuest;
    public BattleInfo.WaveInfo[] waveInfos;
    private int mCurrentWave = -1;

    public int stageId
    {
      get => this.mStageId;
      set
      {
        if (this.isWave)
          return;
        this.mStageId = value;
      }
    }

    public BattleStage stage => MasterData.BattleStage[this.stageId];

    public PlayerDeck deck => SMManager.Get<PlayerDeck[]>()[this.deckIndex];

    public PlayerItem[] items => SMManager.Get<PlayerItem[]>().AllBattleSupplies();

    public BattleStageGuest[] Guests
    {
      get
      {
        return this.guest_ids != null ? ((IEnumerable<int>) this.guest_ids).Select<int, BattleStageGuest>((Func<int, BattleStageGuest>) (x => MasterData.BattleStageGuest[x])).ToArray<BattleStageGuest>() : (BattleStageGuest[]) null;
      }
    }

    public BattleEarthStageGuest[] EarthGuests
    {
      get
      {
        return this.guest_ids != null ? ((IEnumerable<int>) this.guest_ids).Select<int, BattleEarthStageGuest>((Func<int, BattleEarthStageGuest>) (x => MasterData.BattleEarthStageGuest[x])).ToArray<BattleEarthStageGuest>() : (BattleEarthStageGuest[]) null;
      }
    }

    public int[] enemy_ids
    {
      get => this.mEnemy_ids;
      set
      {
        if (this.isWave)
          return;
        this.mEnemy_ids = value;
      }
    }

    public BattleStageEnemy[] Enemies
    {
      get
      {
        return this.enemy_ids != null ? ((IEnumerable<int>) this.enemy_ids).Select<int, BattleStageEnemy>((Func<int, BattleStageEnemy>) (x => MasterData.BattleStageEnemy[x])).ToArray<BattleStageEnemy>() : (BattleStageEnemy[]) null;
      }
    }

    public Tuple<int, Reward>[] enemy_items
    {
      get => this.mEnemy_items;
      set
      {
        if (this.isWave)
          return;
        this.mEnemy_items = value;
      }
    }

    public Tuple<int, Reward>[] EnemyItems => this.enemy_items;

    public PlayerUnit[] user_units
    {
      get => this.mUser_units;
      set
      {
        if (this.isWave)
          return;
        this.mUser_units = value;
      }
    }

    public PlayerItem[] user_items
    {
      get => this.mUser_items;
      set
      {
        if (this.isWave)
          return;
        this.mUser_items = value;
      }
    }

    public int[] user_enemy_ids
    {
      get => this.mUser_enemy_ids;
      set
      {
        if (this.isWave)
          return;
        this.mUser_enemy_ids = value;
      }
    }

    public BattleStageUserUnit[] UserEnemies
    {
      get
      {
        return this.user_enemy_ids != null ? ((IEnumerable<int>) this.user_enemy_ids).Select<int, BattleStageUserUnit>((Func<int, BattleStageUserUnit>) (x => MasterData.BattleStageUserUnit[x])).ToArray<BattleStageUserUnit>() : (BattleStageUserUnit[]) null;
      }
    }

    public Tuple<int, Reward>[] user_enemy_items
    {
      get => this.mUser_enemy_items;
      set
      {
        if (this.isWave)
          return;
        this.mUser_enemy_items = value;
      }
    }

    public Tuple<int, Reward>[] UserEnemyItems => this.user_enemy_items;

    public int[] panel_ids
    {
      get => this.mPanel_ids;
      set
      {
        if (this.isWave)
          return;
        this.mPanel_ids = value;
      }
    }

    public BattleStagePanelEvent[] Panels
    {
      get
      {
        return this.panel_ids != null ? ((IEnumerable<int>) this.panel_ids).Select<int, BattleStagePanelEvent>((Func<int, BattleStagePanelEvent>) (x => MasterData.BattleStagePanelEvent[x])).ToArray<BattleStagePanelEvent>() : (BattleStagePanelEvent[]) null;
      }
    }

    public Tuple<int, Reward>[] panel_items
    {
      get => this.mPanel_items;
      set
      {
        if (this.isWave)
          return;
        this.mPanel_items = value;
      }
    }

    public Tuple<int, Reward>[] PanelItems => this.panel_items;

    public PlayerUnit[] pvp_player_units { get; set; }

    public PlayerUnit[] pvp_enemy_units { get; set; }

    public PlayerItem[] pvp_player_items { get; set; }

    public PlayerItem[] pvp_enemy_items { get; set; }

    public PlayerCharacterIntimate[] pvp_player_character_intimates { get; set; }

    public PlayerCharacterIntimate[] pvp_enemy_character_intimates { get; set; }

    public PlayerUnit[] gvg_player_helpers { get; set; }

    public PlayerUnit[] gvg_enemy_helpers { get; set; }

    public int Coin => SMManager.Get<Player>().coin;

    public bool isFirstAllDead
    {
      get
      {
        int? gameOverCount = SMManager.Get<Player>().game_over_count;
        return gameOverCount.GetValueOrDefault() == 0 && gameOverCount.HasValue;
      }
    }

    public bool isExtra => this.extraQuest != null;

    public bool hasMission
    {
      get
      {
        if (this.isExtra)
        {
          foreach (QuestExtraMission questExtraMission in MasterData.QuestExtraMissionList)
          {
            if (questExtraMission.quest_s.ID == this.extraQuest.quest_extra_s.ID)
              return true;
          }
          return false;
        }
        if (this.storyQuest == null)
          return false;
        foreach (QuestStoryMission questStoryMission in MasterData.QuestStoryMissionList)
        {
          if (questStoryMission.quest_s.ID == this.storyQuest.quest_story_s.ID)
            return true;
        }
        return false;
      }
    }

    public Bonus[] pvp_bonus_list { get; set; }

    public string pvp_start_date { get; set; }

    public GuildBaseBonusEffect[] gvg_player_base_bonus_list { get; set; }

    public GuildBaseBonusEffect[] gvg_enemy_base_bonus_list { get; set; }

    public static BattleInfo MakeBattleInfo(
      string battle_uuid,
      CommonQuestType quest_type,
      int quest_s_id,
      int deck_type_id,
      int quest_loop_count,
      int deck_number,
      PlayerHelper helper,
      int[] enemies,
      Tuple<int, int, int, int>[] enemy_items,
      PlayerUnit[] user_units,
      PlayerItem[] user_items,
      int[] user_enemies,
      Tuple<int, int, int, int>[] user_enemy_items,
      int[] panels,
      Tuple<int, int, int, int>[] panel_items,
      int[] guests)
    {
      BattleInfo battleInfo = new BattleInfo();
      battleInfo.pvp = false;
      battleInfo.helper = helper;
      battleInfo.quest_s_id = quest_s_id;
      battleInfo.quest_type = quest_type;
      battleInfo.quest_loop_count = quest_loop_count;
      bool flag1 = false;
      bool flag2 = false;
      switch (quest_type)
      {
        case CommonQuestType.Story:
          battleInfo.storyQuest = ((IEnumerable<PlayerStoryQuestS>) SMManager.Get<PlayerStoryQuestS[]>()).First<PlayerStoryQuestS>((Func<PlayerStoryQuestS, bool>) (x => x.quest_story_s.ID == quest_s_id));
          battleInfo.stageId = battleInfo.storyQuest.quest_story_s.stage.ID;
          flag1 = battleInfo.storyQuest.enable_autobattle;
          flag2 = battleInfo.storyQuest.quest_story_s.disable_continue;
          battleInfo.isEarthMode = false;
          break;
        case CommonQuestType.Character:
          PlayerCharacterQuestS playerCharacterQuestS = ((IEnumerable<PlayerCharacterQuestS>) SMManager.Get<PlayerCharacterQuestS[]>()).First<PlayerCharacterQuestS>((Func<PlayerCharacterQuestS, bool>) (x => x.quest_character_s.ID == quest_s_id));
          battleInfo.stageId = playerCharacterQuestS.quest_character_s.stage.ID;
          flag1 = playerCharacterQuestS.enable_autobattle;
          flag2 = playerCharacterQuestS.quest_character_s.disable_continue;
          battleInfo.isEarthMode = false;
          break;
        case CommonQuestType.Extra:
          battleInfo.extraQuest = ((IEnumerable<PlayerExtraQuestS>) ((IEnumerable<PlayerExtraQuestS>) SMManager.Get<PlayerExtraQuestS[]>()).CheckMasterData().ToArray<PlayerExtraQuestS>()).First<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (x => x.quest_extra_s.ID == quest_s_id));
          battleInfo.stageId = battleInfo.extraQuest.quest_extra_s.stage.ID;
          flag1 = battleInfo.extraQuest.enable_autobattle;
          flag2 = battleInfo.extraQuest.quest_extra_s.disable_continue;
          battleInfo.isEarthMode = false;
          break;
        case CommonQuestType.Harmony:
          PlayerHarmonyQuestS playerHarmonyQuestS = ((IEnumerable<PlayerHarmonyQuestS>) SMManager.Get<PlayerHarmonyQuestS[]>()).First<PlayerHarmonyQuestS>((Func<PlayerHarmonyQuestS, bool>) (x => x.quest_harmony_s.ID == quest_s_id));
          battleInfo.stageId = playerHarmonyQuestS.quest_harmony_s.stage.ID;
          flag1 = playerHarmonyQuestS.enable_autobattle;
          flag2 = playerHarmonyQuestS.quest_harmony_s.disable_continue;
          battleInfo.isEarthMode = false;
          break;
        case CommonQuestType.Earth:
          EarthQuestEpisode earthQuestEpisode = MasterData.EarthQuestEpisode[quest_s_id];
          battleInfo.stageId = earthQuestEpisode.stage.ID;
          flag1 = false;
          flag2 = true;
          battleInfo.isEarthMode = true;
          battleInfo.isExtraEarthQuest = false;
          break;
        case CommonQuestType.EarthExtra:
          EarthExtraQuest earthExtraQuest = MasterData.EarthExtraQuest[quest_s_id];
          battleInfo.stageId = earthExtraQuest.stage.ID;
          flag1 = false;
          flag2 = true;
          battleInfo.isEarthMode = true;
          battleInfo.isExtraEarthQuest = true;
          break;
        default:
          Debug.LogError((object) ("error: " + quest_type.ToString()));
          break;
      }
      battleInfo.deckIndex = ((IEnumerable<PlayerDeck>) SMManager.Get<PlayerDeck[]>()).FirstIndexOrNull<PlayerDeck>((Func<PlayerDeck, bool>) (x => x.deck_type_id == deck_type_id && x.deck_number == deck_number)).Value;
      battleInfo.battleId = battle_uuid;
      battleInfo.guest_ids = guests;
      battleInfo.enemy_ids = enemies;
      battleInfo.enemy_items = ((IEnumerable<Tuple<int, int, int, int>>) enemy_items).Select<Tuple<int, int, int, int>, Tuple<int, Reward>>((Func<Tuple<int, int, int, int>, Tuple<int, Reward>>) (x => Tuple.Create<int, Reward>(x.Item1, new Reward((MasterDataTable.CommonRewardType) x.Item2, x.Item3, x.Item4)))).ToArray<Tuple<int, Reward>>();
      battleInfo.user_units = user_units;
      battleInfo.user_items = user_items;
      battleInfo.user_enemy_ids = user_enemies;
      battleInfo.user_enemy_items = ((IEnumerable<Tuple<int, int, int, int>>) user_enemy_items).Select<Tuple<int, int, int, int>, Tuple<int, Reward>>((Func<Tuple<int, int, int, int>, Tuple<int, Reward>>) (x => Tuple.Create<int, Reward>(x.Item1, new Reward((MasterDataTable.CommonRewardType) x.Item2, x.Item3, x.Item4)))).ToArray<Tuple<int, Reward>>();
      battleInfo.panel_ids = panels;
      battleInfo.panel_items = ((IEnumerable<Tuple<int, int, int, int>>) panel_items).Select<Tuple<int, int, int, int>, Tuple<int, Reward>>((Func<Tuple<int, int, int, int>, Tuple<int, Reward>>) (x => Tuple.Create<int, Reward>(x.Item1, new Reward((MasterDataTable.CommonRewardType) x.Item2, x.Item3, x.Item4)))).ToArray<Tuple<int, Reward>>();
      battleInfo.isContinueEnable = !flag2;
      if (quest_loop_count == 0)
        battleInfo.isAutoBattleEnable = flag1;
      else
        battleInfo.isStoryEnable = false;
      battleInfo.pvp_bonus_list = (Bonus[]) null;
      battleInfo.pvp_start_date = string.Empty;
      battleInfo.gvg_player_base_bonus_list = (GuildBaseBonusEffect[]) null;
      battleInfo.gvg_enemy_base_bonus_list = (GuildBaseBonusEffect[]) null;
      return battleInfo;
    }

    public static BattleInfo MakeBattleInfo(
      string battle_uuid,
      int stage_id,
      PlayerUnit[] player1_units,
      PlayerUnit[] player2_units,
      PlayerItem[] player1_items,
      PlayerItem[] player2_items,
      Bonus[] bonus_list,
      PlayerCharacterIntimate[] player1_character_intimates,
      PlayerCharacterIntimate[] player2_character_intimates,
      DateTime start_time)
    {
      return new BattleInfo()
      {
        pvp = true,
        quest_type = CommonQuestType.PvP,
        stageId = stage_id,
        pvp_player_units = player1_units,
        pvp_enemy_units = player2_units,
        pvp_player_items = player1_items,
        pvp_enemy_items = player2_items,
        pvp_player_character_intimates = player1_character_intimates,
        pvp_enemy_character_intimates = player2_character_intimates,
        isStoryEnable = false,
        isAutoBattleEnable = false,
        pvp_bonus_list = bonus_list,
        gvg_player_base_bonus_list = (GuildBaseBonusEffect[]) null,
        gvg_enemy_base_bonus_list = (GuildBaseBonusEffect[]) null,
        pvp_start_date = string.Format("{0:D2}{1:D2}", (object) start_time.Month, (object) start_time.Day)
      };
    }

    public static BattleInfo MakeGvgBattleInfo(
      string battle_uuid,
      int stage_id,
      PlayerUnit[] player_units,
      PlayerUnit[] enemy_units,
      PlayerUnit[] player_guest_units,
      PlayerUnit[] enemy_guest_units,
      PlayerItem[] player_items,
      PlayerItem[] enemy_items,
      PlayerItem[] player_guest_items,
      PlayerItem[] enemy_guest_items,
      GuildBaseBonusEffect[] player_base_bonus_list,
      GuildBaseBonusEffect[] enemy_base_bonus_list,
      PlayerCharacterIntimate[] player1_character_intimates,
      PlayerCharacterIntimate[] player2_character_intimates,
      DateTime start_time)
    {
      PlayerUnit[] array1 = ((IEnumerable<PlayerUnit>) player_units).Concat<PlayerUnit>((IEnumerable<PlayerUnit>) player_guest_units).ToArray<PlayerUnit>();
      PlayerUnit[] array2 = ((IEnumerable<PlayerUnit>) enemy_units).Concat<PlayerUnit>((IEnumerable<PlayerUnit>) enemy_guest_units).ToArray<PlayerUnit>();
      PlayerItem[] array3 = ((IEnumerable<PlayerItem>) player_items).Concat<PlayerItem>((IEnumerable<PlayerItem>) player_guest_items).ToArray<PlayerItem>();
      PlayerItem[] array4 = ((IEnumerable<PlayerItem>) enemy_items).Concat<PlayerItem>((IEnumerable<PlayerItem>) enemy_guest_items).ToArray<PlayerItem>();
      return new BattleInfo()
      {
        battleId = battle_uuid,
        gvg = true,
        quest_type = CommonQuestType.PvP,
        stageId = stage_id,
        pvp_player_units = array1,
        gvg_player_helpers = player_guest_units,
        pvp_enemy_units = array2,
        gvg_enemy_helpers = enemy_guest_units,
        pvp_player_items = array3,
        pvp_enemy_items = array4,
        pvp_player_character_intimates = player1_character_intimates,
        pvp_enemy_character_intimates = player2_character_intimates,
        isStoryEnable = false,
        isAutoBattleEnable = false,
        pvp_bonus_list = (Bonus[]) null,
        gvg_player_base_bonus_list = player_base_bonus_list,
        gvg_enemy_base_bonus_list = enemy_base_bonus_list,
        pvp_start_date = string.Format("{0:D2}{1:D2}", (object) start_time.Month, (object) start_time.Day)
      };
    }

    public bool isWave => this.waveInfos != null;

    public int currentWave
    {
      get => this.mCurrentWave;
      set
      {
        if (!this.isWave || this.mCurrentWave == value)
          return;
        this.mCurrentWave = value;
        BattleInfo.WaveInfo waveInfo = this.waveInfos[value];
        this.mStageId = waveInfo.stage_id;
        this.mUser_units = waveInfo.user_units;
        this.mUser_items = waveInfo.user_items;
        this.mEnemy_ids = waveInfo.enemy_ids;
        this.mEnemy_items = waveInfo.enemy_items;
        this.mUser_enemy_ids = waveInfo.user_enemy_ids;
        this.mUser_enemy_items = waveInfo.user_enemy_items;
        this.mPanel_ids = waveInfo.panel_ids;
        this.mPanel_items = waveInfo.panel_items;
      }
    }

    public static BattleInfo MakeBattleInfo(
      string battle_uuid,
      CommonQuestType quest_type,
      int quest_s_id,
      int deck_type_id,
      int quest_loop_count,
      int deck_number,
      PlayerHelper helper,
      int[] guests,
      IEnumerable<BattleInfo.Wave> wave)
    {
      BattleInfo battleInfo = new BattleInfo();
      battleInfo.pvp = false;
      battleInfo.helper = helper;
      battleInfo.quest_s_id = quest_s_id;
      battleInfo.quest_type = quest_type;
      battleInfo.quest_loop_count = quest_loop_count;
      battleInfo.waveInfos = wave.Select<BattleInfo.Wave, BattleInfo.WaveInfo>((Func<BattleInfo.Wave, BattleInfo.WaveInfo>) (x => new BattleInfo.WaveInfo(x))).ToArray<BattleInfo.WaveInfo>();
      bool flag1 = false;
      bool flag2 = false;
      switch (quest_type)
      {
        case CommonQuestType.Story:
          battleInfo.storyQuest = ((IEnumerable<PlayerStoryQuestS>) SMManager.Get<PlayerStoryQuestS[]>()).First<PlayerStoryQuestS>((Func<PlayerStoryQuestS, bool>) (x => x.quest_story_s.ID == quest_s_id));
          flag1 = battleInfo.storyQuest.enable_autobattle;
          flag2 = battleInfo.storyQuest.quest_story_s.disable_continue;
          battleInfo.isEarthMode = false;
          break;
        case CommonQuestType.Character:
          PlayerCharacterQuestS playerCharacterQuestS = ((IEnumerable<PlayerCharacterQuestS>) SMManager.Get<PlayerCharacterQuestS[]>()).First<PlayerCharacterQuestS>((Func<PlayerCharacterQuestS, bool>) (x => x.quest_character_s.ID == quest_s_id));
          flag1 = playerCharacterQuestS.enable_autobattle;
          flag2 = playerCharacterQuestS.quest_character_s.disable_continue;
          battleInfo.isEarthMode = false;
          break;
        case CommonQuestType.Extra:
          battleInfo.extraQuest = ((IEnumerable<PlayerExtraQuestS>) ((IEnumerable<PlayerExtraQuestS>) SMManager.Get<PlayerExtraQuestS[]>()).CheckMasterData().ToArray<PlayerExtraQuestS>()).First<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (x => x.quest_extra_s.ID == quest_s_id));
          flag1 = battleInfo.extraQuest.enable_autobattle;
          flag2 = battleInfo.extraQuest.quest_extra_s.disable_continue;
          battleInfo.isEarthMode = false;
          break;
        case CommonQuestType.Harmony:
          PlayerHarmonyQuestS playerHarmonyQuestS = ((IEnumerable<PlayerHarmonyQuestS>) SMManager.Get<PlayerHarmonyQuestS[]>()).First<PlayerHarmonyQuestS>((Func<PlayerHarmonyQuestS, bool>) (x => x.quest_harmony_s.ID == quest_s_id));
          flag1 = playerHarmonyQuestS.enable_autobattle;
          flag2 = playerHarmonyQuestS.quest_harmony_s.disable_continue;
          battleInfo.isEarthMode = false;
          break;
        case CommonQuestType.Earth:
          EarthQuestEpisode earthQuestEpisode = MasterData.EarthQuestEpisode[quest_s_id];
          flag1 = false;
          flag2 = true;
          battleInfo.isEarthMode = true;
          break;
        default:
          Debug.LogError((object) ("error: " + quest_type.ToString()));
          break;
      }
      battleInfo.deckIndex = ((IEnumerable<PlayerDeck>) SMManager.Get<PlayerDeck[]>()).FirstIndexOrNull<PlayerDeck>((Func<PlayerDeck, bool>) (x => x.deck_type_id == deck_type_id && x.deck_number == deck_number)).Value;
      battleInfo.battleId = battle_uuid;
      battleInfo.guest_ids = guests;
      battleInfo.isContinueEnable = !flag2;
      if (quest_loop_count == 0)
        battleInfo.isAutoBattleEnable = flag1;
      else
        battleInfo.isStoryEnable = false;
      battleInfo.pvp_bonus_list = (Bonus[]) null;
      battleInfo.pvp_start_date = string.Empty;
      battleInfo.gvg_player_base_bonus_list = (GuildBaseBonusEffect[]) null;
      battleInfo.gvg_enemy_base_bonus_list = (GuildBaseBonusEffect[]) null;
      return battleInfo;
    }

    public class Wave
    {
      public int stage_id;
      public PlayerUnit[] user_units;
      public PlayerItem[] user_items;
      public int[] enemies;
      public Tuple<int, int, int, int>[] enemy_items;
      public int[] user_enemies;
      public Tuple<int, int, int, int>[] user_enemy_items;
      public int[] panels;
      public Tuple<int, int, int, int>[] panel_items;
    }

    [Serializable]
    public class WaveInfo
    {
      public int stage_id;
      public PlayerUnit[] user_units;
      public PlayerItem[] user_items;
      public int[] enemy_ids;
      public Tuple<int, Reward>[] enemy_items = new Tuple<int, Reward>[0];
      public int[] user_enemy_ids = new int[0];
      public Tuple<int, Reward>[] user_enemy_items = new Tuple<int, Reward>[0];
      public int[] panel_ids = new int[0];
      public Tuple<int, Reward>[] panel_items = new Tuple<int, Reward>[0];

      public WaveInfo(BattleInfo.Wave wave)
      {
        this.stage_id = wave.stage_id;
        this.user_units = wave.user_units;
        this.user_items = wave.user_items;
        this.enemy_ids = wave.enemies;
        this.enemy_items = ((IEnumerable<Tuple<int, int, int, int>>) wave.enemy_items).Select<Tuple<int, int, int, int>, Tuple<int, Reward>>((Func<Tuple<int, int, int, int>, Tuple<int, Reward>>) (x => Tuple.Create<int, Reward>(x.Item1, new Reward((MasterDataTable.CommonRewardType) x.Item2, x.Item3, x.Item4)))).ToArray<Tuple<int, Reward>>();
        this.user_enemy_ids = wave.user_enemies;
        this.user_enemy_items = ((IEnumerable<Tuple<int, int, int, int>>) wave.user_enemy_items).Select<Tuple<int, int, int, int>, Tuple<int, Reward>>((Func<Tuple<int, int, int, int>, Tuple<int, Reward>>) (x => Tuple.Create<int, Reward>(x.Item1, new Reward((MasterDataTable.CommonRewardType) x.Item2, x.Item3, x.Item4)))).ToArray<Tuple<int, Reward>>();
        this.panel_ids = wave.panels;
        this.panel_items = ((IEnumerable<Tuple<int, int, int, int>>) wave.panel_items).Select<Tuple<int, int, int, int>, Tuple<int, Reward>>((Func<Tuple<int, int, int, int>, Tuple<int, Reward>>) (x => Tuple.Create<int, Reward>(x.Item1, new Reward((MasterDataTable.CommonRewardType) x.Item2, x.Item3, x.Item4)))).ToArray<Tuple<int, Reward>>();
      }
    }
  }
}
