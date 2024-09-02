// Decompiled with JetBrains decompiler
// Type: Versus0268Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus0268Menu : ResultMenuBase
{
  [SerializeField]
  protected UILabel TxtSubTitle;
  [SerializeField]
  protected UILabel TxtAttention1;
  [SerializeField]
  protected UILabel TxtAttentionNum;
  [SerializeField]
  protected UILabel TxtCharaEXP26;
  [SerializeField]
  protected UILabel TxtRemain;
  [SerializeField]
  protected UILabel TxtRemainNum;
  [SerializeField]
  private GameObject DirTitle;
  [SerializeField]
  private GameObject[] Campaing;
  [SerializeField]
  private GameObject DirBottomMessage;
  [SerializeField]
  private GameObject DirRecord;
  [SerializeField]
  private GameObject DirClassRecord;
  [SerializeField]
  private GameObject[] DirBattleResult;
  [SerializeField]
  private GameObject DirClassUnitExp;
  [SerializeField]
  private GameObject[] DirClassUnit;
  [SerializeField]
  private GameObject ClassCampaing;
  private Versus0268Menu.PvpParam param;
  private WebAPI.Response.PvpPlayerFinish info;
  private GameObject TotalWinRewardPrefab;
  private GameObject NewEmblemRewardPrefab;
  private GameObject FirstBattleRewardPrefab;
  private GameObject CampaingPrefab1;
  private GameObject CampaingPrefab2;
  private GameObject CampaingPrefab3;
  private List<PvPEndPlayer_character_intimates_in_battle> intimates = new List<PvPEndPlayer_character_intimates_in_battle>();

  [DebuggerHidden]
  public override IEnumerator Init(WebAPI.Response.PvpPlayerFinish info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Menu.\u003CInit\u003Ec__Iterator5A0()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  private void SetParam() => this.param = new Versus0268Menu.PvpParam(this.info);

  public void SetActiveObj()
  {
    this.TxtSubTitle.SetText(this.param.title);
    this.DirBottomMessage.SetActive(false);
    this.DirRecord.SetActive(false);
    this.DirClassRecord.SetActive(false);
    this.DirUnitExp.SetActive(false);
    this.ClassCampaing.SetActive(false);
    this.DirClassUnitExp.SetActive(false);
    ((IEnumerable<GameObject>) this.DirClassUnit).ForEach<GameObject>((Action<GameObject>) (x => x.gameObject.SetActive(false)));
    this.DirTitle.SetActive(false);
    ((IEnumerable<GameObject>) this.Campaing).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    ((IEnumerable<GameObject>) this.DirBattleResult).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    if (!this.param.isClassMatch)
      return;
    this.Campaing[0] = this.ClassCampaing;
    this.DirUnitExp = this.DirClassUnitExp;
    this.DirUnit = this.DirClassUnit;
  }

  [DebuggerHidden]
  private IEnumerator SetPrefabs()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Menu.\u003CSetPrefabs\u003Ec__Iterator5A1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Menu.\u003CRun\u003Ec__Iterator5A2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Versus0268Menu.\u003COnFinish\u003Ec__Iterator5A3 finishCIterator5A3 = new Versus0268Menu.\u003COnFinish\u003Ec__Iterator5A3();
    return (IEnumerator) finishCIterator5A3;
  }

  [DebuggerHidden]
  private IEnumerator InitObjects()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Menu.\u003CInitObjects\u003Ec__Iterator5A4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowRecord()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Menu.\u003CShowRecord\u003Ec__Iterator5A5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowTitleEXP()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Menu.\u003CShowTitleEXP\u003Ec__Iterator5A6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowAnotherPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Menu.\u003CShowAnotherPopup\u003Ec__Iterator5A7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator PvpCharacterIntimatesPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Menu.\u003CPvpCharacterIntimatesPopup\u003Ec__Iterator5A8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowFirstBattlePopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Menu.\u003CShowFirstBattlePopup\u003Ec__Iterator5A9()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowBottomMessage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268Menu.\u003CShowBottomMessage\u003Ec__Iterator5AA()
    {
      \u003C\u003Ef__this = this
    };
  }

  public class PvpParam
  {
    public Versus0268Menu.PvpParam.BonusReward[] bonus_rewards;
    public bool is_battle;
    public Bonus[] bonus;
    public PlayerHelper[] gladiators;
    public int win;
    public int draw;
    public int lose;
    public int season_win;
    public int season_draw;
    public int season_lose;
    public Player player;
    public bool target_player_is_friend;
    public bool is_first_battle;
    public bool isClassMatch;
    public string title;
    public Versus0268Menu.PvpParam.CampaignReward[] campaign_rewards;
    public Versus0268Menu.PvpParam.CampaignNextReward[] campaign_next_rewards;
    public Versus0268Menu.PvpParam.FirstBattleReward[] first_battle_rewards;

    public PvpParam(WebAPI.Response.PvpPlayerFinish finish)
    {
      int length1 = finish.bonus_rewards.Length;
      this.bonus_rewards = new Versus0268Menu.PvpParam.BonusReward[length1];
      for (int index = 0; index < length1; ++index)
      {
        if (this.bonus_rewards[index] == null)
          this.bonus_rewards[index] = new Versus0268Menu.PvpParam.BonusReward(finish.bonus_rewards[index]);
        else
          this.bonus_rewards[index].SetInfo(finish.bonus_rewards[index]);
      }
      int length2 = finish.campaign_rewards.Length;
      this.campaign_rewards = new Versus0268Menu.PvpParam.CampaignReward[length2];
      for (int index = 0; index < length2; ++index)
        this.campaign_rewards[index] = new Versus0268Menu.PvpParam.CampaignReward(finish.campaign_rewards[index]);
      int length3 = finish.campaign_next_rewards.Length;
      this.campaign_next_rewards = new Versus0268Menu.PvpParam.CampaignNextReward[length3];
      for (int index = 0; index < length3; ++index)
        this.campaign_next_rewards[index] = new Versus0268Menu.PvpParam.CampaignNextReward(finish.campaign_next_rewards[index]);
      int length4 = finish.first_battle_rewards.Length;
      this.first_battle_rewards = new Versus0268Menu.PvpParam.FirstBattleReward[length4];
      for (int index = 0; index < length4; ++index)
        this.first_battle_rewards[index] = new Versus0268Menu.PvpParam.FirstBattleReward(finish.first_battle_rewards[index]);
      this.is_battle = finish.is_battle;
      this.bonus = finish.bonus;
      this.gladiators = finish.gladiators;
      this.player = finish.player;
      this.target_player_is_friend = finish.target_player_is_friend;
      this.isClassMatch = finish.matching_type == 6;
      if (this.isClassMatch)
      {
        this.title = Consts.Lookup("VERSUS_002610TITLE");
        this.season_win = finish.pvp_class_record.current_season_win_count;
        this.season_lose = finish.pvp_class_record.current_season_loss_count;
        this.season_draw = finish.pvp_class_record.current_season_draw_count;
        this.win = finish.pvp_class_record.pvp_record.win;
        this.lose = finish.pvp_class_record.pvp_record.loss;
        this.draw = finish.pvp_class_record.pvp_record.draw;
      }
      else
      {
        bool flag = finish.matching_type == 1 || finish.matching_type == 2 || finish.matching_type == 3;
        this.title = !flag ? Consts.Lookup("VERSUS_00262TITLE_FRIEND") : Consts.Lookup("VERSUS_00262TITLE_RANDOM");
        this.win = !flag ? finish.pvp_record_by_friend.win : finish.pvp_record.win;
        this.lose = !flag ? finish.pvp_record_by_friend.loss : finish.pvp_record.loss;
        this.draw = !flag ? finish.pvp_record_by_friend.draw : finish.pvp_record.draw;
      }
    }

    public class BonusReward
    {
      public int reward_quantity;
      public int reward_type_id;
      public int reward_id;

      public BonusReward(
        WebAPI.Response.PvpPlayerFinishBonus_rewards reward)
      {
        this.SetInfo(reward);
      }

      public void SetInfo(
        WebAPI.Response.PvpPlayerFinishBonus_rewards reward)
      {
        this.reward_quantity = reward.reward_quantity;
        this.reward_type_id = reward.reward_type_id;
        this.reward_id = reward.reward_id;
      }
    }

    public class CampaignReward
    {
      public int reward_quantity;
      public string show_text2;
      public int reward_type_id;
      public int campaign_id;
      public string show_title;
      public string show_text;
      public int reward_id;

      public CampaignReward(
        WebAPI.Response.PvpPlayerFinishCampaign_rewards reward)
      {
        this.SetInfo(reward);
      }

      public void SetInfo(
        WebAPI.Response.PvpPlayerFinishCampaign_rewards reward)
      {
        this.reward_quantity = reward.reward_quantity;
        this.show_text2 = reward.show_text2;
        this.reward_type_id = reward.reward_type_id;
        this.campaign_id = reward.campaign_id;
        this.show_title = reward.show_title;
        this.show_text = reward.show_text;
        this.reward_id = reward.reward_id;
      }
    }

    public class CampaignNextReward
    {
      public string next_reward_title;
      public int campaign_id;
      public string next_reward_text;

      public CampaignNextReward(
        WebAPI.Response.PvpPlayerFinishCampaign_next_rewards reward)
      {
        this.SetInfo(reward);
      }

      public void SetInfo(
        WebAPI.Response.PvpPlayerFinishCampaign_next_rewards reward)
      {
        this.next_reward_title = reward.next_reward_title;
        this.campaign_id = reward.campaign_id;
        this.next_reward_text = reward.next_reward_text;
      }
    }

    public class FirstBattleReward
    {
      public int reward_type_id;
      public int reward_id;
      public string show_text;

      public FirstBattleReward(
        WebAPI.Response.PvpPlayerFinishFirst_battle_rewards reward)
      {
        this.SetInfo(reward);
      }

      public void SetInfo(
        WebAPI.Response.PvpPlayerFinishFirst_battle_rewards reward)
      {
        this.reward_type_id = reward.reward_type_id;
        this.reward_id = reward.reward_id;
        this.show_text = reward.show_text;
      }
    }
  }

  private delegate IEnumerator Runner();
}
