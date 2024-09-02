// Decompiled with JetBrains decompiler
// Type: Versus02610Menu
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
  private UILabel txtName;
  [SerializeField]
  private UILabel txtTotalCE;
  [SerializeField]
  private UI2DSprite slcClassIcon;
  [SerializeField]
  private GameObject[] dirStar;
  [SerializeField]
  private UISprite[] lightStar;
  [SerializeField]
  private UISprite[] grayStar;
  [SerializeField]
  private GameObject dirStarOut5;
  [SerializeField]
  private GameObject dirStarIn5;
  [SerializeField]
  private UISprite starNum00;
  [SerializeField]
  private UISprite starNum01;
  [SerializeField]
  private GameObject dir_bonus;
  [SerializeField]
  private UIScrollView bonus_scroll;
  public GameObject BuffPrefab;
  public GameObject TextBuffPrefab;
  public GameObject popup;
  public GameObject popupTextPrefab;
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
  private bool isPvp;
  private int height;
  private int needHeight;
  private int boxHeight;

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
    return (IEnumerator) new Versus02610Menu.\u003CInit\u003Ec__Iterator618()
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
    return (IEnumerator) new Versus02610Menu.\u003CSetRankingOrSeasonPopup\u003Ec__Iterator619()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator RankingEndPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CRankingEndPopup\u003Ec__Iterator61A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitSeasonEndPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CInitSeasonEndPopup\u003Ec__Iterator61B()
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

  [DebuggerHidden]
  private IEnumerator ChangeSceneRanking()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CChangeSceneRanking\u003Ec__Iterator61C()
    {
      \u003C\u003Ef__this = this
    };
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
    this.txtWin.SetText(this.pvpInfo.pvp_class_record.pvp_record.win.ToLocalizeNumberText());
    this.txtLose.SetText(this.pvpInfo.pvp_class_record.pvp_record.loss.ToLocalizeNumberText());
    this.StartCoroutine(this.SetNewPvp());
    bool flag = Player.Current.IsClassMatchRanking();
    string text1 = !flag || this.pvpInfo.ranking <= 0 ? instance.VERSUS_002610RANKING_DEFAULT : this.pvpInfo.ranking.ToLocalizeNumberText();
    string text2 = !flag ? instance.VERSUS_002610RANKING_DEFAULT : this.pvpInfo.ranking_pt.ToLocalizeNumberText();
    this.txtRanking.SetText(text1);
    this.txtRankPoint.SetText(text2);
    this.txtMatchRemain.SetTextLocalize(this.GetMatchRemainText());
    this.SetTxtCondition(this.txtCondition);
  }

  [DebuggerHidden]
  public IEnumerator SetNewPvp()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CSetNewPvp\u003Ec__Iterator61D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator CreatPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CCreatPrefab\u003Ec__Iterator61E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SetNewBonusDisplay()
  {
    if (this.pvpInfo.bonus != null && this.pvpInfo.bonus.Length != 0)
    {
      Bonus[] array = ((IEnumerable<Bonus>) this.pvpInfo.bonus).Where<Bonus>((Func<Bonus, bool>) (x => x.category != 12)).ToArray<Bonus>();
      if (array.Length == 0)
      {
        this.dir_bonus.gameObject.SetActive(false);
      }
      else
      {
        Dictionary<int, List<Bonus>> dictionary = this.RecominationData(array);
        foreach (int key in dictionary.Keys)
        {
          GameObject gameObject = this.BuffPrefab.Clone(((Component) this.bonus_scroll).transform);
          List<Bonus> bonusList;
          if (dictionary.TryGetValue(key, out bonusList))
          {
            this.height = 0;
            this.InitBuffPopup(gameObject.GetComponent<BuffMenu>(), bonusList, true);
            float num = (float) this.boxHeight + (float) ((this.height + this.needHeight) / 2);
            ((Component) gameObject.transform).transform.localPosition = new Vector3(0.0f, -num, 0.0f);
            this.boxHeight += this.height + this.needHeight;
          }
        }
        this.dir_bonus.gameObject.SetActive(true);
        this.bonus_scroll.ResetPosition();
      }
    }
    else
      this.dir_bonus.gameObject.SetActive(false);
  }

  public Dictionary<int, List<Bonus>> RecominationData(Bonus[] bonusList)
  {
    Dictionary<int, List<Bonus>> dictionary = new Dictionary<int, List<Bonus>>();
    foreach (Bonus bonus in bonusList)
    {
      List<Bonus> bonusList1;
      if (!dictionary.TryGetValue(bonus.groupid, out bonusList1))
      {
        bonusList1 = new List<Bonus>();
        dictionary.Add(bonus.groupid, bonusList1);
      }
      bonusList1.Add(bonus);
    }
    return dictionary;
  }

  public void InitBuffPopup(BuffMenu textBox, List<Bonus> bonusList, bool isPvp = false)
  {
    UISprite box = textBox.box;
    this.isPvp = isPvp;
    foreach (Bonus bonus in bonusList)
      this.SetText(box, bonus, bonusList);
    box.height = this.height + this.needHeight;
    BoxCollider component = ((Component) textBox.box).GetComponent<BoxCollider>();
    component.size = new Vector3((float) box.width, (float) box.height);
    component.center = new Vector3(-8f, 0.0f);
  }

  private void SetText(UISprite box, Bonus data, List<Bonus> bonusList)
  {
    GameObject gameObject = this.TextBuffPrefab.Clone(((Component) box).transform);
    TextBuffBoxPrefab component1 = gameObject.GetComponent<TextBuffBoxPrefab>();
    UILabel component2 = component1.uiDescription.GetComponent<UILabel>();
    string str1 = data.DisplayName(this.isPvp);
    component2.SetText(str1);
    int crlf1 = this.GetCRLF(str1, component2.fontSize, component2.width);
    int num1 = (component2.fontSize + component2.spacingY) * crlf1;
    UILabel component3 = component1.uiTime.GetComponent<UILabel>();
    string str2 = data.RemainingTime();
    component3.SetText(str2);
    int crlf2 = this.GetCRLF(str2, component3.fontSize, component3.width);
    int num2 = (component3.fontSize + component3.spacingY) * crlf2;
    int num3 = num1 < num2 ? num2 : num1;
    float num4 = (float) this.height + (float) (num3 / 2);
    this.needHeight = component2.fontSize + component2.spacingY;
    gameObject.transform.localPosition = new Vector3(0.0f, -num4 + (float) (this.needHeight / 2 * bonusList.Count), 0.0f);
    this.height += num3;
  }

  private int GetCRLF(string s, int fontsize, int panel_width)
  {
    int crlf = Mathf.CeilToInt((float) s.Trim().Length / Mathf.Floor((float) (panel_width / fontsize)));
    if (crlf == 0)
      crlf = 1;
    return crlf;
  }

  private PlayerDeck GetDeck()
  {
    PlayerDeck[] playerDeckArray = SMManager.Get<PlayerDeck[]>();
    if (((IEnumerable<PlayerUnit>) playerDeckArray[Persist.versusDeckOrganized.Data.number].player_units).FirstOrDefault<PlayerUnit>() == (PlayerUnit) null)
    {
      Persist.versusDeckOrganized.Data.number = 0;
      Persist.versusDeckOrganized.Flush();
    }
    return playerDeckArray[Persist.versusDeckOrganized.Data.number];
  }

  [DebuggerHidden]
  private IEnumerator ShowSeasonCloseResult()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CShowSeasonCloseResult\u003Ec__Iterator61F()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnClassReward()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.showClassReward());
  }

  [DebuggerHidden]
  private IEnumerator showClassReward()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CshowClassReward\u003Ec__Iterator620()
    {
      \u003C\u003Ef__this = this
    };
  }

  public Dictionary<int, List<PvpClassReward>> RecominationData(PvpClassReward[] classReward)
  {
    Dictionary<int, List<PvpClassReward>> dictionary = new Dictionary<int, List<PvpClassReward>>();
    foreach (PvpClassReward pvpClassReward in classReward)
    {
      foreach (PvpClassKind pvpClassKind in MasterData.PvpClassKindList)
      {
        if (pvpClassReward.class_kind_PvpClassKind == pvpClassKind.ID)
        {
          List<PvpClassReward> pvpClassRewardList;
          if (!dictionary.TryGetValue(pvpClassKind.icon_id, out pvpClassRewardList))
          {
            pvpClassRewardList = new List<PvpClassReward>();
            dictionary.Add(pvpClassKind.icon_id, pvpClassRewardList);
          }
          pvpClassRewardList.Add(pvpClassReward);
        }
      }
    }
    return dictionary;
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
    Versus02610Menu.\u003CShowMPAlertPopup\u003Ec__Iterator621 popupCIterator621 = new Versus02610Menu.\u003CShowMPAlertPopup\u003Ec__Iterator621();
    return (IEnumerator) popupCIterator621;
  }

  [DebuggerHidden]
  private IEnumerator ShowAggregatePopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Versus02610Menu.\u003CShowAggregatePopup\u003Ec__Iterator622 popupCIterator622 = new Versus02610Menu.\u003CShowAggregatePopup\u003Ec__Iterator622();
    return (IEnumerator) popupCIterator622;
  }

  protected override bool IsMatchingBeginCheck()
  {
    return SMManager.Get<Player>().mp > 0 && !this.pvpInfo.rank_aggregate;
  }

  [DebuggerHidden]
  protected override IEnumerator ErrorMathcingBegin()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CErrorMathcingBegin\u003Ec__Iterator623()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SeasonEndPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CSeasonEndPopup\u003Ec__Iterator624()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SceneUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Menu.\u003CSceneUpdate\u003Ec__Iterator625()
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
