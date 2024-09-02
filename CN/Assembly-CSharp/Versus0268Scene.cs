// Decompiled with JetBrains decompiler
// Type: Versus0268Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Versus0268Scene : NGSceneBase
{
  [SerializeField]
  private Versus0268Menu menu;
  [SerializeField]
  private GameObject touchToNext;
  private List<ResultMenuBase> sequences;
  private bool toNextSequence;
  private bool isStarted;
  private WebAPI.Response.PvpPlayerFinish pvpInfo;

  public static void ChangeScene()
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_8");
  }

  public static void ChangeScene(bool isDebug)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_8", false, (object) isDebug);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Scene.\u003ConInitSceneAsync\u003Ec__Iterator65E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Scene.\u003ConStartSceneAsync\u003Ec__Iterator65F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool isDebug)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Scene.\u003ConStartSceneAsync\u003Ec__Iterator660()
    {
      isDebug = isDebug,
      \u003C\u0024\u003EisDebug = isDebug,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(WebAPI.Response.PvpPlayerFinish result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Scene.\u003ConStartSceneAsync\u003Ec__Iterator661()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    if (this.isStarted)
      return;
    this.isStarted = true;
    this.StartCoroutine(this.RunMenus());
  }

  public void onStartScene(bool isDebug)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    if (this.isStarted)
      return;
    this.isStarted = true;
    this.StartCoroutine(this.RunMenus());
  }

  [DebuggerHidden]
  private IEnumerator InitMenus(WebAPI.Response.PvpPlayerFinish result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Scene.\u003CInitMenus\u003Ec__Iterator662()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator RunMenus()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Scene.\u003CRunMenus\u003Ec__Iterator663()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void StartTutorial(System.Action finishScene)
  {
    Singleton<TutorialRoot>.GetInstance().ForceShowAdvice("pvp3", (System.Action) (() =>
    {
      Persist.pvpInfo.Data.currentPage = 3;
      Persist.pvpInfo.Flush();
      finishScene();
    }));
  }

  private void FinishScene()
  {
    if (this.pvpInfo.pvp_maintenance)
      this.StartCoroutine(PopupCommon.Show(this.pvpInfo.pvp_maintenance_title, this.pvpInfo.pvp_maintenance_message, (System.Action) (() =>
      {
        NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
        instance.clearStack();
        instance.destroyCurrentScene();
        MypageScene.ChangeScene(false);
      })));
    else if (this.pvpInfo.matching_type == 6)
    {
      Singleton<NGSceneManager>.GetInstance().clearStack();
      Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
      if (this.pvpInfo.rank_aggregate)
        Versus0261Scene.ChangeScene0261(false);
      else
        Versus02610Scene.ChangeScene(false, false);
    }
    else
    {
      Singleton<NGSceneManager>.GetInstance().clearStack();
      Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
      Versus0262Scene.ChangeScene0262(false, Persist.pvpInfo.Data.lastMatchingType);
    }
  }

  [DebuggerHidden]
  private IEnumerator RunPopupMaintenance(WebAPI.Response.PvpPlayerFinish pvpInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Scene.\u003CRunPopupMaintenance\u003Ec__Iterator664()
    {
      pvpInfo = pvpInfo,
      \u003C\u0024\u003EpvpInfo = pvpInfo
    };
  }

  public void IbtnTouchToNext() => this.toNextSequence = true;

  private WebAPI.Response.PvpPlayerFinish ForDebugData(WebAPI.Response.PvpPlayerFinish data)
  {
    bool flag1 = false;
    bool flag2 = false;
    bool UnitProficienciesEffectOn = false;
    bool GearBrokenEffectOn = true;
    bool flag3 = true;
    bool flag4 = true;
    bool flag5 = true;
    bool flag6 = true;
    bool flag7 = false;
    bool flag8 = false;
    Player player1 = SMManager.Get<Player>();
    PlayerUnit[] array1 = ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).Skip<PlayerUnit>(0).Take<PlayerUnit>(5).ToArray<PlayerUnit>();
    PlayerItem[] playerGears = ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.entity_type == MasterDataTable.CommonRewardType.gear)).ToArray<PlayerItem>();
    ((IEnumerable<PlayerUnit>) array1).ForEach<PlayerUnit>((Action<PlayerUnit>) (p =>
    {
      PlayerItem[] array2 = ((IEnumerable<PlayerItem>) playerGears).Where<PlayerItem>((Func<PlayerItem, bool>) (x => MasterData.GearGear[x.entity_id].kind_GearKind == p.unit.initial_gear.kind_GearKind)).ToArray<PlayerItem>();
      try
      {
        PlayerItem playerItem = array2[(int) ((double) Random.value * (double) (array2.Length - 1))];
        p.equip_gear_ids = new int?[1]
        {
          new int?(playerItem.id)
        };
      }
      catch (IndexOutOfRangeException ex)
      {
      }
    }));
    playerGears = ((IEnumerable<PlayerUnit>) array1).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.equippedGear != (PlayerItem) null)).Select<PlayerUnit, PlayerItem>((Func<PlayerUnit, PlayerItem>) (x => ((IEnumerable<PlayerItem>) playerGears).First<PlayerItem>((Func<PlayerItem, bool>) (y => y.id == x.equippedGear.id)))).Distinct<PlayerItem>().ToArray<PlayerItem>();
    Player player2 = player1.Clone();
    PlayerUnit[] array3 = ((IEnumerable<PlayerUnit>) array1).Select<PlayerUnit, PlayerUnit>((Func<PlayerUnit, PlayerUnit>) (x => x.Clone())).ToArray<PlayerUnit>();
    PlayerItem[] array4 = ((IEnumerable<PlayerItem>) playerGears).ToArray<PlayerItem>();
    array1[0].skills = new PlayerUnitSkills[0];
    player2.total_exp += 2000;
    ++player2.level;
    foreach (PlayerUnit playerUnit in array3)
    {
      if (flag1)
      {
        playerUnit.level += 3;
        playerUnit.hp = new PlayerUnitHp()
        {
          level = playerUnit.hp.level + 13,
          compose = playerUnit.hp.compose,
          inheritance = playerUnit.hp.inheritance,
          initial = playerUnit.hp.initial
        };
        playerUnit.strength = new PlayerUnitStrength()
        {
          level = playerUnit.strength.level + 3,
          compose = playerUnit.strength.compose,
          inheritance = playerUnit.strength.inheritance,
          initial = playerUnit.strength.initial
        };
        playerUnit.agility = new PlayerUnitAgility()
        {
          level = playerUnit.agility.level + 3,
          compose = playerUnit.agility.compose,
          inheritance = playerUnit.agility.inheritance,
          initial = playerUnit.agility.initial
        };
        playerUnit.dexterity = new PlayerUnitDexterity()
        {
          level = playerUnit.dexterity.level + 3,
          compose = playerUnit.dexterity.compose,
          inheritance = playerUnit.dexterity.inheritance,
          initial = playerUnit.dexterity.initial
        };
        playerUnit.mind = new PlayerUnitMind()
        {
          level = playerUnit.mind.level + 3,
          compose = playerUnit.mind.compose,
          inheritance = playerUnit.mind.inheritance,
          initial = playerUnit.mind.initial
        };
        playerUnit.lucky = new PlayerUnitLucky()
        {
          level = playerUnit.lucky.level + 3,
          compose = playerUnit.lucky.compose,
          inheritance = playerUnit.lucky.inheritance,
          initial = playerUnit.lucky.initial
        };
      }
    }
    ((IEnumerable<PlayerUnit>) array3).Skip<PlayerUnit>(2).ForEach<PlayerUnit>((Action<PlayerUnit>) (p =>
    {
      PlayerUnit playerUnit = p;
      PlayerUnitGearProficiency[] unitGearProficiencyArray;
      if (UnitProficienciesEffectOn)
        unitGearProficiencyArray = new PlayerUnitGearProficiency[1]
        {
          new PlayerUnitGearProficiency()
          {
            gear_kind_id = p.gear_proficiencies[0].gear_kind_id,
            level = p.gear_proficiencies[0].level + 1
          }
        };
      else
        unitGearProficiencyArray = new PlayerUnitGearProficiency[1]
        {
          new PlayerUnitGearProficiency()
          {
            gear_kind_id = p.gear_proficiencies[0].gear_kind_id,
            level = p.gear_proficiencies[0].level
          }
        };
      playerUnit.gear_proficiencies = unitGearProficiencyArray;
    }));
    foreach (PlayerItem playerItem in array4)
    {
      if (flag2)
        playerItem.gear_level += 3;
    }
    ((IEnumerable<PlayerItem>) array4).ForEach<PlayerItem>((Action<PlayerItem>) (x => x.broken = GearBrokenEffectOn));
    PvPEndPlayer_character_intimates_in_battle[] intimatesInBattleArray1;
    if (flag8)
      intimatesInBattleArray1 = new PvPEndPlayer_character_intimates_in_battle[2]
      {
        new PvPEndPlayer_character_intimates_in_battle()
        {
          character_id = array1[0].unit.character.ID,
          target_character_id = array1[1].unit.character.ID,
          before_level = 1,
          after_level = 2
        },
        new PvPEndPlayer_character_intimates_in_battle()
        {
          character_id = array1[2].unit.character.ID,
          target_character_id = array1[3].unit.character.ID,
          before_level = 3,
          after_level = 4
        }
      };
    else
      intimatesInBattleArray1 = new PvPEndPlayer_character_intimates_in_battle[0];
    PvPEndPlayer_character_intimates_in_battle[] intimatesInBattleArray2 = intimatesInBattleArray1;
    data.gladiators = new PlayerHelper[1]
    {
      new PlayerHelper()
      {
        target_player_id = "6f8fc498-3b1a-41c8-a4db-8291faee22d5",
        target_player_name = Consts.GetInstance().someone_you_know,
        leader_unit = array1[0],
        is_friend = false
      }
    };
    UnlockQuest[] array5 = ((IEnumerable<QuestCharacterS>) MasterData.QuestCharacterSList).Take<QuestCharacterS>(2).Select<QuestCharacterS, UnlockQuest>((Func<QuestCharacterS, UnlockQuest>) (x => new UnlockQuest()
    {
      quest_s_id = x.ID,
      quest_type = 2
    })).ToArray<UnlockQuest>();
    UnlockQuest[] unlockQuestArray = !flag3 ? new UnlockQuest[0] : array5;
    WebAPI.Response.PvpPlayerFinish pvpPlayerFinish1 = data;
    WebAPI.Response.PvpPlayerFinishBonus_rewards[] finishBonusRewardsArray;
    if (flag4)
      finishBonusRewardsArray = new WebAPI.Response.PvpPlayerFinishBonus_rewards[1]
      {
        new WebAPI.Response.PvpPlayerFinishBonus_rewards()
        {
          reward_quantity = 4,
          reward_id = 2,
          reward_type_id = 19
        }
      };
    else
      finishBonusRewardsArray = new WebAPI.Response.PvpPlayerFinishBonus_rewards[0];
    pvpPlayerFinish1.bonus_rewards = finishBonusRewardsArray;
    WebAPI.Response.PvpPlayerFinish pvpPlayerFinish2 = data;
    WebAPI.Response.PvpPlayerFinishCampaign_rewards[] finishCampaignRewardsArray;
    if (flag5)
      finishCampaignRewardsArray = new WebAPI.Response.PvpPlayerFinishCampaign_rewards[1]
      {
        new WebAPI.Response.PvpPlayerFinishCampaign_rewards()
        {
          reward_quantity = 2,
          show_text2 = "debug desuyo-2",
          reward_type_id = 10,
          campaign_id = 1,
          show_title = "debug desuyo-title",
          show_text = "debug desuyo-1",
          reward_id = 0
        }
      };
    else
      finishCampaignRewardsArray = new WebAPI.Response.PvpPlayerFinishCampaign_rewards[0];
    pvpPlayerFinish2.campaign_rewards = finishCampaignRewardsArray;
    WebAPI.Response.PvpPlayerFinish pvpPlayerFinish3 = data;
    WebAPI.Response.PvpPlayerFinishFirst_battle_rewards[] firstBattleRewardsArray;
    if (flag6)
      firstBattleRewardsArray = new WebAPI.Response.PvpPlayerFinishFirst_battle_rewards[1]
      {
        new WebAPI.Response.PvpPlayerFinishFirst_battle_rewards()
        {
          reward_id = 0,
          reward_type_id = 10,
          show_text = Consts.GetInstance().versus0268_3
        }
      };
    else
      firstBattleRewardsArray = new WebAPI.Response.PvpPlayerFinishFirst_battle_rewards[0];
    pvpPlayerFinish3.first_battle_rewards = firstBattleRewardsArray;
    data.campaign_next_rewards = new WebAPI.Response.PvpPlayerFinishCampaign_next_rewards[0];
    data.pvp_class_record = new PvPClassRecord()
    {
      current_season_draw_count = 5,
      current_season_loss_count = 5,
      current_season_win_count = 0,
      pvp_record = new PvPRecord()
      {
        win = 5,
        loss = 4,
        draw = 1
      }
    };
    data.pvp_record = new PvPRecord();
    data.pvp_record_by_friend = new PvPRecord();
    data.player = player2;
    data.pvp_finish = new PvPEnd();
    data.pvp_finish.battle_result = 1;
    data.pvp_finish.after_player_units = array3;
    data.pvp_finish.after_player_gears = array4;
    data.pvp_finish.before_player_units = array1;
    data.pvp_finish.before_player_gears = playerGears;
    data.ranking = 1000;
    data.ranking_pt = 1000000;
    data.pvp_finish.unlock_quests = unlockQuestArray;
    data.is_tutorial = flag7;
    data.matching_type = 6;
    data.current_class = 1;
    data.reward_money = 1111111111;
    data.pvp_finish.player_character_intimates_in_battle = intimatesInBattleArray2;
    return data;
  }
}
