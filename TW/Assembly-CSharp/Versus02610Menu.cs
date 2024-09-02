// Decompiled with JetBrains decompiler
// Type: Versus02610Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02610Menu : Versus026MatchBase
{
  [SerializeField]
  private UILabel txtClassName;
  [SerializeField]
  private UILabel txtDraw;
  [SerializeField]
  private UILabel txtWin;
  [SerializeField]
  private UILabel txtLose;
  [SerializeField]
  private UILabel txtRanking;
  [SerializeField]
  private UILabel txtMatchRemain;
  [SerializeField]
  private UILabel txtRankPoint;
  [SerializeField]
  private UILabel txtCondition;
  [SerializeField]
  private UISprite slcRankGaugeBlue;
  [SerializeField]
  private UISprite slcRankGaugeGreen;
  [SerializeField]
  private UISprite slcRankGaugeYellow;
  [SerializeField]
  private UISprite slcRankGaugeRed;
  [SerializeField]
  private UISprite slcRankGaugeNow;
  [SerializeField]
  private GameObject objEffectParent;
  [SerializeField]
  private UIButton btnSeasonFinish;
  [SerializeField]
  private UIButton btnRanking;
  [SerializeField]
  private GameObject btnComingSoonRanking;
  private static readonly int PVP_TUTORIAL_CLASS_MATCH_END_PAGE = 200;
  private static bool isContinue;
  private bool isUpdate;
  private bool isPlayingEffect;

  public static bool IsContinue
  {
    set => Versus02610Menu.isContinue = value;
  }

  public Transform GetEffectParent => this.objEffectParent.transform;

  public bool IsUpdate => this.isUpdate;

  public WebAPI.Response.PvpBoot UpdatePvpInfo => this.pvpInfo;

  public void SetPlayingEffect(bool isPlay) => this.isPlayingEffect = isPlay;

  [DebuggerHidden]
  public override IEnumerator Init(PvpMatchingTypeEnum type, WebAPI.Response.PvpBoot pvpInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CInit\u003Ec__Iterator665()
    {
      type = type,
      pvpInfo = pvpInfo,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetRankingOrSeasonPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CSetRankingOrSeasonPopup\u003Ec__Iterator666()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator RankingEndPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CRankingEndPopup\u003Ec__Iterator667()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitSeasonEndPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CInitSeasonEndPopup\u003Ec__Iterator668()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void IbtnWarExperience()
  {
    if (this.IsPushAndSet())
      return;
    base.IbtnWarExperience();
    Versus02613Scene.ChangeScene(true, this.pvpInfo.pvp_class_record);
  }

  public void IbtnClassInfo()
  {
    if (this.IsPushAndSet())
      return;
    Debug.Log((object) "===ChangeScene 2612");
    Versus02611Scene.ChangeScene(true, this.pvpInfo);
  }

  public void IbtnRanking()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ChangeSceneRanking());
  }

  public void IbtnSeasonFinish()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.SeasonEndPopup());
  }

  protected override string SetRoomKey(string key) => base.SetRoomKey(key);

  private void InitializeDisplay()
  {
    Consts instance = Consts.GetInstance();
    this.txtTitle.SetText(instance.VERSUS_002610TITLE);
    this.txtClassName.SetText(MasterData.PvpClassKind[this.pvpInfo.current_class].name);
    this.txtDraw.SetText(this.pvpInfo.pvp_class_record.current_season_draw_count.ToLocalizeNumberText());
    this.txtWin.SetText(this.pvpInfo.pvp_class_record.current_season_win_count.ToLocalizeNumberText());
    this.txtLose.SetText(this.pvpInfo.pvp_class_record.current_season_loss_count.ToLocalizeNumberText());
    bool flag = Player.Current.IsClassMatchRanking();
    string text1 = !flag || this.pvpInfo.ranking <= 0 ? instance.VERSUS_002610RANKING_DEFAULT : this.pvpInfo.ranking.ToLocalizeNumberText();
    string text2 = !flag ? instance.VERSUS_002610RANKING_DEFAULT : this.pvpInfo.ranking_pt.ToLocalizeNumberText();
    this.txtRanking.SetText(text1);
    this.txtRankPoint.SetText(text2);
    ((Component) this.btnRanking).gameObject.SetActive(flag);
    this.btnComingSoonRanking.gameObject.SetActive(!flag);
    this.btnRanking.isEnabled = Player.Current.IsClassMatchShowRanking();
    this.txtMatchRemain.SetTextLocalize(this.GetMatchRemainText());
    this.SetTxtCondition(this.txtCondition);
    this.SetRankGauge();
  }

  private string GetMatchRemainText()
  {
    Player player = SMManager.Get<Player>();
    return Consts.Format(Consts.GetInstance().VERSUS_00261REMAIN_LONG, (IDictionary) new Hashtable()
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
        (object) this.SetRemainTime(player.mp_full_recovery_at.Hour, player.mp_full_recovery_at.Minute)
      }
    });
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

  private void SetTxtCondition(UILabel l)
  {
    PvpClassKind pvpClassKind = MasterData.PvpClassKind[this.pvpInfo.current_class];
    int currentSeasonWinCount = this.pvpInfo.pvp_class_record.current_season_win_count;
    PvpClassKind.Condition condition1 = pvpClassKind.ClassCondition(currentSeasonWinCount);
    PvpClassKind.Condition condition2 = pvpClassKind.NextCondition(condition1);
    Consts instance = Consts.GetInstance();
    switch (condition2)
    {
      case PvpClassKind.Condition.STAY:
      case PvpClassKind.Condition.STAY_TOPCLASS:
        Color color1 = Color32.op_Implicit(new Color32((byte) 10, (byte) 223, (byte) 29, byte.MaxValue));
        l.color = color1;
        l.SetText(Consts.Format(instance.VERSUS_002610CONDITION_DOWN, (IDictionary) new Hashtable()
        {
          {
            (object) "win",
            (object) (pvpClassKind.stay_point - currentSeasonWinCount).ToLocalizeNumberText()
          }
        }));
        break;
      case PvpClassKind.Condition.UP:
        Color color2 = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, (byte) 0, byte.MaxValue));
        l.color = color2;
        l.SetText(Consts.Format(instance.VERSUS_002610CONDITION_STAY, (IDictionary) new Hashtable()
        {
          {
            (object) "win",
            (object) (pvpClassKind.up_point - currentSeasonWinCount).ToLocalizeNumberText()
          }
        }));
        break;
      case PvpClassKind.Condition.TITLE:
      case PvpClassKind.Condition.TITLE_TOPCLASS:
        if (condition1 == PvpClassKind.Condition.TITLE || condition1 == PvpClassKind.Condition.TITLE_TOPCLASS)
        {
          Color color3 = Color32.op_Implicit(new Color32(byte.MaxValue, (byte) 105, (byte) 0, byte.MaxValue));
          l.color = color3;
          l.SetText(instance.VERSUS_002610CONDITION_TITLE);
          break;
        }
        Color color4 = Color32.op_Implicit(new Color32(byte.MaxValue, (byte) 105, (byte) 0, byte.MaxValue));
        l.color = color4;
        l.SetText(Consts.Format(instance.VERSUS_002610CONDITION_UP, (IDictionary) new Hashtable()
        {
          {
            (object) "win",
            (object) (pvpClassKind.title_point - currentSeasonWinCount).ToLocalizeNumberText()
          }
        }));
        break;
    }
  }

  private void SetRankGauge()
  {
    int width = this.slcRankGaugeRed.width;
    int num = 10;
    PvpClassKind pvpClassKind = MasterData.PvpClassKind[this.pvpInfo.current_class];
    this.slcRankGaugeBlue.width = (pvpClassKind.stay_point - 1) * width / num;
    this.slcRankGaugeGreen.width = (pvpClassKind.up_point - 1) * width / num;
    this.slcRankGaugeYellow.width = (pvpClassKind.title_point - 1) * width / num;
    ((Component) this.slcRankGaugeBlue).gameObject.SetActive(pvpClassKind.stay_point > 0);
    ((Component) this.slcRankGaugeGreen).gameObject.SetActive(pvpClassKind.up_point - pvpClassKind.stay_point > 0);
    ((Component) this.slcRankGaugeYellow).gameObject.SetActive(pvpClassKind.title_point - pvpClassKind.up_point > 0);
    ((Component) this.slcRankGaugeRed).gameObject.SetActive(true);
    ((Component) this.slcRankGaugeNow).transform.localPosition = new Vector3(((Component) this.slcRankGaugeRed).transform.localPosition.x + (float) (Mathf.Clamp(this.pvpInfo.pvp_class_record.current_season_win_count, 0, num) * width / num), ((Component) this.slcRankGaugeNow).transform.localPosition.y);
  }

  [DebuggerHidden]
  private IEnumerator ShowMPAlertPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Versus02610Menu.\u003CShowMPAlertPopup\u003Ec__Iterator669 popupCIterator669 = new Versus02610Menu.\u003CShowMPAlertPopup\u003Ec__Iterator669();
    return (IEnumerator) popupCIterator669;
  }

  [DebuggerHidden]
  private IEnumerator ShowAggregatePopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Versus02610Menu.\u003CShowAggregatePopup\u003Ec__Iterator66A popupCIterator66A = new Versus02610Menu.\u003CShowAggregatePopup\u003Ec__Iterator66A();
    return (IEnumerator) popupCIterator66A;
  }

  protected override bool IsMatchingBeginCheck()
  {
    return SMManager.Get<Player>().mp > 0 && !this.pvpInfo.rank_aggregate;
  }

  [DebuggerHidden]
  protected override IEnumerator ErrorMathcingBegin()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CErrorMathcingBegin\u003Ec__Iterator66B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SeasonEndPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CSeasonEndPopup\u003Ec__Iterator66C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ChangeSceneRanking()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CChangeSceneRanking\u003Ec__Iterator66D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SceneUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CSceneUpdate\u003Ec__Iterator66E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void isEnableSeasonFinishButton(bool isEnable)
  {
    ((Component) this.btnSeasonFinish).gameObject.SetActive(isEnable);
    ((Component) this.btnBreakRepair).gameObject.SetActive(!isEnable);
    ((Component) this.btnStartMatch).gameObject.SetActive(!isEnable);
    if (isEnable)
      return;
    this.SetMatchButton();
  }

  public void StartSceneUpdate(System.Action act = null)
  {
    this.StartCoroutine(this.SceneUpdate());
    if (act == null)
      return;
    act();
  }

  public override void onBackButton()
  {
    if (this.isPlayingEffect)
      return;
    this.IbtnBack();
  }
}
