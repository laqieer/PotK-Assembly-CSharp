// Decompiled with JetBrains decompiler
// Type: Versus0261Menu
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
public class Versus0261Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtAttention;
  [SerializeField]
  private UISprite slcExpBoost;
  [SerializeField]
  private UI2DSprite slcCampaign;
  [SerializeField]
  private UIButton buttonBack;
  [SerializeField]
  private UIButton buttonRandom;
  [SerializeField]
  private UIButton buttonFriend;
  [SerializeField]
  private UIButton buttonClassMatch;
  [SerializeField]
  private GameObject classMatchComingSoon;
  [SerializeField]
  private UILabel TxtMatchRemain;
  [SerializeField]
  private UILabel TxtRemain;
  [SerializeField]
  private UI2DSprite slcHeader;
  [SerializeField]
  private UILabel TxtTime;
  [SerializeField]
  private UILabel TxtCondition;
  [SerializeField]
  private UIButton btnRanking;
  [SerializeField]
  private GameObject btnComingSoonRanking;
  public GameObject popup;
  public GameObject popupTextPrefab;
  private WebAPI.Response.PvpBoot pvpInfo;
  [SerializeField]
  private UILabel Debug_nowCondition;
  public int DebugGUI_LeftOffset;
  public int DebugGUI_TopOffset1;
  public GUISkin debugSkin;
  private bool DebugGUI_SceneStart;
  private string DebugGUI_txtChoiceServer = string.Empty;
  private bool DebugGUI_isView;
  public static bool Debug_isIgnoreVersion;
  public static bool isLocal;

  [DebuggerHidden]
  public IEnumerator Initialize(WebAPI.Response.PvpBoot pvpInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0261Menu.\u003CInitialize\u003Ec__Iterator604()
    {
      pvpInfo = pvpInfo,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u003Ef__this = this
    };
  }

  private void OnGUI()
  {
  }

  public void SetSomethingBoost(PvPCampaign[] campaigns)
  {
    ((Component) this.slcExpBoost).gameObject.SetActive(((IEnumerable<PvPCampaign>) campaigns).Any<PvPCampaign>((Func<PvPCampaign, bool>) (x => x.campaign.campaign_type_id == 2)));
  }

  [DebuggerHidden]
  public IEnumerator SetCampaignImage(PvPCampaign[] campaigns)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0261Menu.\u003CSetCampaignImage\u003Ec__Iterator605()
    {
      campaigns = campaigns,
      \u003C\u0024\u003Ecampaigns = campaigns,
      \u003C\u003Ef__this = this
    };
  }

  public void SetText(int remainNum, int limitNum)
  {
    Consts instance = Consts.GetInstance();
    this.txtTitle.SetText(instance.VERSUS_00261TITLE);
    ((Component) this.TxtRemain).gameObject.SetActive(true);
    this.TxtRemain.SetTextLocalize(Consts.Format(instance.VERSUS_00262BONUS, (IDictionary) new Hashtable()
    {
      {
        (object) "cnt",
        (object) remainNum
      }
    }));
    this.txtAttention.SetTextLocalize(Consts.Format(instance.VERSUS_00261ATTENTION, (IDictionary) new Hashtable()
    {
      {
        (object) "cnt",
        (object) limitNum
      }
    }));
    this.SetMatchRemainText();
  }

  private void SetMatchRemainText()
  {
    Player player = SMManager.Get<Player>();
    string text;
    if (this.pvpInfo.rank_aggregate)
    {
      DateTime dateTime = this.pvpInfo.aggregate_finish_time.Value;
      text = Consts.Format(Consts.GetInstance().VERSUS_00261REMAIN_RANK_AGREGATE, (IDictionary) new Hashtable()
      {
        {
          (object) "remainTime",
          (object) this.SetRemainTime(dateTime.Hour, dateTime.Minute)
        }
      });
    }
    else if (player.mp <= 0 && this.pvpInfo.aggregate_finish_time.HasValue && this.pvpInfo.aggregate_finish_time.Value <= player.mp_full_recovery_at)
    {
      DateTime dateTime = this.pvpInfo.matches_finish_time.Value;
      text = Consts.Format(Consts.GetInstance().VERSUS_00261REMAIN_BEFORE_RANK_AGREGATE, (IDictionary) new Hashtable()
      {
        {
          (object) "remainTime",
          (object) this.SetRemainTime(dateTime.Hour, dateTime.Minute)
        }
      });
    }
    else
    {
      DateTime mpFullRecoveryAt = player.mp_full_recovery_at;
      text = Consts.Format(Consts.GetInstance().VERSUS_00261REMAIN_LONG, (IDictionary) new Hashtable()
      {
        {
          (object) "nowCnt",
          (object) player.mp.ToLocalizeNumberText()
        },
        {
          (object) "maxCnt",
          (object) player.mp_max.ToLocalizeNumberText()
        },
        {
          (object) "remainTime",
          (object) this.SetRemainTime(mpFullRecoveryAt.Hour, mpFullRecoveryAt.Minute)
        }
      });
    }
    this.TxtMatchRemain.SetText(text);
  }

  private string SetRemainTime(int hour, int minute)
  {
    Consts instance = Consts.GetInstance();
    return Consts.Format(minute >= 10 ? instance.VERSUS_00261REMAIN_TIME : instance.VERSUS_00261REMAIN_TIME_SUB, (IDictionary) new Hashtable()
    {
      {
        (object) nameof (hour),
        (object) hour.ToLocalizeNumberText()
      },
      {
        (object) nameof (minute),
        (object) minute.ToLocalizeNumberText()
      }
    });
  }

  public void IbtnClassMatch()
  {
    if (this.IsPushAndSet())
      return;
    if (!this.isNowPvp())
    {
      Consts instance = Consts.GetInstance();
      string pvpTitle = instance.pvp_title;
      string pvpStartNotInTime = instance.pvp_START_NOT_IN_TIME;
      this.buttonClassMatch.isEnabled = false;
      this.classMatchComingSoon.SetActive(false);
      PopupManager.Show(pvpTitle, pvpStartNotInTime, (System.Action) (() => { }));
    }
    else
      Versus02610Scene.ChangeScene(true, this.pvpInfo);
  }

  [DebuggerHidden]
  private IEnumerator SetNewPvp()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0261Menu.\u003CSetNewPvp\u003Ec__Iterator606()
    {
      \u003C\u003Ef__this = this
    };
  }

  public bool isNowPvp()
  {
    if (!this.pvpInfo.is_active)
      return false;
    DateTime dateTime = ServerTime.NowAppTimeAddDelta();
    DateTime? dayStartTime = this.pvpInfo.day_start_time;
    DateTime? dayEndTime = this.pvpInfo.day_end_time;
    return dayStartTime.HasValue && dayEndTime.HasValue && (!dayStartTime.HasValue ? 0 : (dateTime >= dayStartTime.Value ? 1 : 0)) != 0 && (!dayEndTime.HasValue ? 0 : (dateTime < dayEndTime.Value ? 1 : 0)) != 0;
  }

  public void IbtnRule()
  {
    if (this.IsPushAndSet())
      return;
    Debug.Log((object) "click IbtnRule");
    this.StartCoroutine(this.showRule());
  }

  [DebuggerHidden]
  private IEnumerator showRule()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0261Menu.\u003CshowRule\u003Ec__Iterator607()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnWarExperience()
  {
    if (this.IsPushAndSet())
      return;
    Debug.Log((object) "click default event IbtnWarExperience");
    Versus02613Scene.ChangeScene(true, this.pvpInfo.pvp_class_record);
  }

  public void IbtnRanking()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ChangeSceneRanking());
  }

  [DebuggerHidden]
  private IEnumerator ChangeSceneRanking()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0261Menu.\u003CChangeSceneRanking\u003Ec__Iterator608()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowAggregatePopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Versus0261Menu.\u003CShowAggregatePopup\u003Ec__Iterator609 popupCIterator609 = new Versus0261Menu.\u003CShowAggregatePopup\u003Ec__Iterator609();
    return (IEnumerator) popupCIterator609;
  }

  [DebuggerHidden]
  public IEnumerator SetHeaderImage(string showUrl)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0261Menu.\u003CSetHeaderImage\u003Ec__Iterator60A()
    {
      showUrl = showUrl,
      \u003C\u0024\u003EshowUrl = showUrl,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnRundomMatch()
  {
    if (this.IsPushAndSet())
      return;
    Versus0262Scene.ChangeScene0262(true, PvpMatchingTypeEnum.normal, this.pvpInfo);
  }

  public void IbtnFriendMatch()
  {
    if (this.IsPushAndSet())
      return;
    Versus0262Scene.ChangeScene0262(true, PvpMatchingTypeEnum.guest, this.pvpInfo);
  }

  public void IbtnMap()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.CreateMapPrefab());
  }

  [DebuggerHidden]
  private IEnumerator CreateMapPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0261Menu.\u003CCreateMapPrefab\u003Ec__Iterator60B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
