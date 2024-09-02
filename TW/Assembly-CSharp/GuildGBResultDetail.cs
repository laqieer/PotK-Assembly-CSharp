// Decompiled with JetBrains decompiler
// Type: GuildGBResultDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
public class GuildGBResultDetail : MonoBehaviour
{
  [SerializeField]
  private GuildGBResultDetail.GuildResult dir_own_guild_result;
  [SerializeField]
  private GuildGBResultDetail.GuildResult dir_enemy_guild_result;
  [SerializeField]
  private GuildGBResultDetail.GuildLevel dir_guild_level_info;
  [SerializeField]
  private UILabel txt_guildcoin_earned;
  [SerializeField]
  private UILabel txt_total_guildcoin;
  [SerializeField]
  private UILabel txt_contribution_earned;
  [SerializeField]
  private UILabel txt_total_contribution;
  private int totalGuildCoin;
  private int earnedGuildCoin;
  private int totalContribution;
  private int earnedContribution;
  [SerializeField]
  private UIButton nextButton;
  private Stack coutineList;
  [SerializeField]
  private GameObject winObj;
  [SerializeField]
  private GameObject loseObj;
  [SerializeField]
  private GameObject drawObj;
  [SerializeField]
  private float numberAnimDuration;

  public void Start()
  {
    this.coutineList = new Stack();
    ((Component) this.nextButton).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator InitiliazeAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    GuildGBResultDetail.\u003CInitiliazeAsync\u003Ec__Iterator73A asyncCIterator73A = new GuildGBResultDetail.\u003CInitiliazeAsync\u003Ec__Iterator73A();
    return (IEnumerator) asyncCIterator73A;
  }

  public void Initialize()
  {
    this.dir_own_guild_result.Initialize("myguild", Random.Range(0, 30).ToString(), Random.Range(0, 1000).ToString());
    this.dir_enemy_guild_result.Initialize("myguild", Random.Range(0, 30).ToString(), Random.Range(0, 1000).ToString());
    this.dir_guild_level_info.Initialize(0, 10, 100, 1);
    this.totalGuildCoin = 100;
    this.earnedGuildCoin = 100;
    this.txt_total_guildcoin.SetTextLocalize(this.totalGuildCoin);
    this.txt_guildcoin_earned.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_BATTLE_RESULT_VALUE_COIN, (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) this.earnedGuildCoin
      }
    }));
    this.totalContribution = 10000;
    this.earnedContribution = 10000000;
    this.txt_contribution_earned.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_BATTLE_RESULT_VALUE_CONTRIBUTION, (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) this.earnedContribution
      }
    }));
    this.txt_total_contribution.SetTextLocalize(this.totalContribution);
  }

  public void Initialize(WebAPI.Response.GvgResult result)
  {
    switch (result.score.battle_status)
    {
      case GvgBattleStatus.win:
        this.winObj.SetActive(true);
        break;
      case GvgBattleStatus.lose:
        this.loseObj.SetActive(true);
        break;
      case GvgBattleStatus.draw:
        this.drawObj.SetActive(true);
        break;
    }
    this.dir_own_guild_result.Initialize(PlayerAffiliation.Current.guild.guild_name, result.score.total_capture_star.ToString(), result.score.total_damage.ToString());
    this.dir_enemy_guild_result.Initialize(result.opponent.guild_name, result.score.opponent_total_capture_star.ToString(), result.score.opponent_total_damage.ToString());
    this.dir_guild_level_info.Initialize(result);
    this.totalGuildCoin = PlayerAffiliation.Current.guild.money - result.score.gain_coin;
    this.earnedGuildCoin = result.score.gain_coin;
    this.txt_total_guildcoin.SetTextLocalize(this.totalGuildCoin);
    this.txt_guildcoin_earned.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_BATTLE_RESULT_VALUE_COIN, (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) this.earnedGuildCoin
      }
    }));
    this.totalContribution = ((IEnumerable<GuildMembership>) PlayerAffiliation.Current.guild.memberships).Single<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == Player.Current.id)).contribution - result.score.gain_contribution;
    this.earnedContribution = result.score.gain_contribution;
    this.txt_contribution_earned.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_BATTLE_RESULT_VALUE_CONTRIBUTION, (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) this.earnedContribution
      }
    }));
    this.txt_total_contribution.SetTextLocalize(this.totalContribution);
  }

  public void CoinStartAnimation()
  {
    this.coutineList.Push((object) this.coutineList.Count);
    this.StartCoroutine(this.RealTimeAddCounter((System.Action) (() => this.coutineList.Pop()), this.txt_total_guildcoin, this.txt_guildcoin_earned, this.totalGuildCoin, this.earnedGuildCoin, _addString: Consts.GetInstance().POPUP_GUILD_BATTLE_RESULT_VALUE_COIN));
  }

  public void ExpStartAnimation()
  {
    this.coutineList.Push((object) this.coutineList.Count);
    this.StartCoroutine(this.dir_guild_level_info.StartAnimation((System.Action) (() => this.coutineList.Pop())));
  }

  public void ContributionStartAnimation()
  {
    this.coutineList.Push((object) this.coutineList.Count);
    this.StartCoroutine(this.RealTimeAddCounter((System.Action) (() => this.coutineList.Pop()), this.txt_total_contribution, this.txt_contribution_earned, this.totalContribution, this.earnedContribution, _addString: Consts.GetInstance().POPUP_GUILD_BATTLE_RESULT_VALUE_CONTRIBUTION));
    ((Component) this.nextButton).gameObject.SetActive(true);
  }

  [DebuggerHidden]
  public IEnumerator RealTimeAddCounter(
    System.Action callback,
    UILabel _baseLabel,
    UILabel _addLabel,
    int _baseValue,
    int _addValue,
    string _baseString = "%(value)s",
    string _addString = "+%(value)s")
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildGBResultDetail.\u003CRealTimeAddCounter\u003Ec__Iterator73B()
    {
      _baseValue = _baseValue,
      _addValue = _addValue,
      _addLabel = _addLabel,
      _addString = _addString,
      _baseLabel = _baseLabel,
      _baseString = _baseString,
      callback = callback,
      \u003C\u0024\u003E_baseValue = _baseValue,
      \u003C\u0024\u003E_addValue = _addValue,
      \u003C\u0024\u003E_addLabel = _addLabel,
      \u003C\u0024\u003E_addString = _addString,
      \u003C\u0024\u003E_baseLabel = _baseLabel,
      \u003C\u0024\u003E_baseString = _baseString,
      \u003C\u0024\u003Ecallback = callback,
      \u003C\u003Ef__this = this
    };
  }

  public void Next()
  {
    if (this.coutineList.Count != 0)
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  [Serializable]
  private class GuildResult
  {
    [SerializeField]
    private UILabel txt_guild_name;
    [SerializeField]
    private UILabel txt_stars_earned;
    [SerializeField]
    private UILabel txt_total_damages;

    public void Initialize(string guildName = "", string startNum = "", string totalDamage = "")
    {
      if (Object.op_Inequality((Object) this.txt_guild_name, (Object) null) && guildName != string.Empty)
        this.txt_guild_name.SetTextLocalize(guildName);
      if (Object.op_Inequality((Object) this.txt_stars_earned, (Object) null) && startNum != string.Empty)
        this.txt_stars_earned.SetTextLocalize(startNum);
      if (!Object.op_Inequality((Object) this.txt_total_damages, (Object) null) || !(totalDamage != string.Empty))
        return;
      this.txt_total_damages.SetTextLocalize(totalDamage);
    }
  }

  [Serializable]
  private class GuildLevel
  {
    [SerializeField]
    private NGTweenGaugeScale slc_gauge_exp;
    [SerializeField]
    private UILabel txt_guild_exp_earned;
    [SerializeField]
    private UILabel txt_guild_exp_for_next_level;
    [SerializeField]
    private UILabel txt_guild_level_num;
    private GameObject levelUpPrefab;
    private GuildImageCache guildImageCache;
    private Guild0282GuildBase guildBaseEffPrefab;
    private Guild0282GuildBase guildBasePrefab;
    private int currentLv;
    private int levelupCnt;
    private float beforeRate;
    private float afterRate;

    public void Initialize(int nowExp, int addExp, int maxExp, int guildLevel)
    {
      this.SetGuildLevelLabel(guildLevel);
      this.slc_gauge_exp.setValue(nowExp, maxExp, false);
      this.txt_guild_exp_earned.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_BATTLE_RESULT_VALUE_EXP, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) addExp
        }
      }));
      this.currentLv = PlayerAffiliation.Current.guild.appearance.level;
      this.levelupCnt = 1;
      this.beforeRate = 0.5f;
      this.afterRate = 0.5f;
    }

    public void Initialize(WebAPI.Response.GvgResult result)
    {
      this.SetGuildLevelLabel(result.before_level);
      if (result.before_experience + result.before_experience_next == 0)
        this.slc_gauge_exp.setValue(0, 1, false);
      else
        this.slc_gauge_exp.setValue(result.before_experience, result.before_experience + result.before_experience_next, false);
      string text = Consts.Format(Consts.GetInstance().POPUP_GUILD_BATTLE_RESULT_VALUE_EXP, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) result.score.gain_experience
        }
      });
      this.SetExperienceNextLabel(PlayerAffiliation.Current.guild.appearance.experience_next);
      this.txt_guild_exp_earned.SetTextLocalize(text);
      this.currentLv = result.before_level;
      this.levelupCnt = PlayerAffiliation.Current.guild.appearance.level - result.before_level;
      this.beforeRate = result.before_experience + result.before_experience_next != 0 ? (float) result.before_experience / (float) (result.before_experience + result.before_experience_next) : 0.0f;
      if (PlayerAffiliation.Current.guild.appearance.experience + PlayerAffiliation.Current.guild.appearance.experience_next == 0)
        this.afterRate = 0.0f;
      else
        this.afterRate = (float) PlayerAffiliation.Current.guild.appearance.experience / (float) (PlayerAffiliation.Current.guild.appearance.experience + PlayerAffiliation.Current.guild.appearance.experience_next);
    }

    private void SetExperienceNextLabel(int expNext)
    {
      this.txt_guild_exp_for_next_level.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_BANK_EXP_NEXT_LEVEL, (IDictionary) new Hashtable()
      {
        {
          (object) "exp",
          (object) expNext
        }
      }));
    }

    private void SetGuildLevelLabel(int level)
    {
      this.txt_guild_level_num.SetTextLocalize(level.ToString());
    }

    [DebuggerHidden]
    public IEnumerator StartAnimation(System.Action callback)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new GuildGBResultDetail.GuildLevel.\u003CStartAnimation\u003Ec__Iterator73C()
      {
        callback = callback,
        \u003C\u0024\u003Ecallback = callback,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator TestStartAnimation(System.Action callback)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new GuildGBResultDetail.GuildLevel.\u003CTestStartAnimation\u003Ec__Iterator73D()
      {
        callback = callback,
        \u003C\u0024\u003Ecallback = callback,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator Levelup(GameObject obj, int count)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new GuildGBResultDetail.GuildLevel.\u003CLevelup\u003Ec__Iterator73E()
      {
        \u003C\u003Ef__this = this
      };
    }
  }
}
