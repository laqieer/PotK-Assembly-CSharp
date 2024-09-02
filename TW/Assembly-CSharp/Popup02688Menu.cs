// Decompiled with JetBrains decompiler
// Type: Popup02688Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02688Menu : Popup02610Base
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtClassName;
  [SerializeField]
  private UILabel txtDraw;
  [SerializeField]
  private UILabel txtWin;
  [SerializeField]
  private UILabel txtLose;
  [SerializeField]
  private UILabel txtConfirmCheck;
  [SerializeField]
  private UILabel txtConfirmCheck2;
  [SerializeField]
  private UILabel txtBattleCount;
  [SerializeField]
  private UILabel txtRemaining;
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
  private Transform dirParent;
  [SerializeField]
  private UIButton ExpendButton;
  [SerializeField]
  private UIButton ContinueButton;

  [DebuggerHidden]
  public override IEnumerator InitCoroutine(WebAPI.Response.PvpBoot pvpInfo, Versus02610Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02688Menu.\u003CInitCoroutine\u003Ec__IteratorA41()
    {
      pvpInfo = pvpInfo,
      menu = menu,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  private void isActiveLeftButton(PvpClassKind c)
  {
    int remainingMatches = this.pvpInfo.season_remaining_matches;
    if (remainingMatches > 0)
    {
      ((Component) this.ContinueButton).gameObject.SetActive(true);
      ((Component) this.ExpendButton).gameObject.SetActive(false);
      this.isActiveLeftButton(c, remainingMatches, this.ContinueButton);
      this.txtConfirmCheck2.SetText(!this.ContinueButton.isEnabled ? Consts.GetInstance().VERSUS_002688POPUP_CONFIRMCHECK3 : Consts.GetInstance().VERSUS_002688POPUP_CONFIRMCHECK2);
    }
    else
    {
      ((Component) this.ContinueButton).gameObject.SetActive(false);
      ((Component) this.ExpendButton).gameObject.SetActive(true);
      this.isActiveLeftButton(c, remainingMatches, this.ExpendButton);
      this.txtConfirmCheck2.SetText(Consts.GetInstance().VERSUS_002688POPUP_CONFIRMCHECK1);
    }
  }

  private void isActiveLeftButton(PvpClassKind c, int remaing_match, UIButton LeftButton)
  {
    bool flag = false;
    int currentSeasonWinCount = this.pvpInfo.pvp_class_record.current_season_win_count;
    int num = currentSeasonWinCount + this.pvpInfo.remaining_addition_matches + remaing_match;
    PvpClassKind.Condition condition = c.ClassCondition(currentSeasonWinCount);
    if (condition != PvpClassKind.Condition.TITLE_TOPCLASS && condition != PvpClassKind.Condition.TITLE)
    {
      if (condition == PvpClassKind.Condition.UP && num >= c.title_point)
        flag = true;
      else if ((condition == PvpClassKind.Condition.STAY_TOPCLASS || condition == PvpClassKind.Condition.STAY) && num >= c.up_point)
        flag = true;
      else if (condition == PvpClassKind.Condition.DOWN && num >= c.stay_point)
        flag = true;
    }
    LeftButton.isEnabled = flag;
  }

  public void IbtnConfirm()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGGameDataManager>.GetInstance().StartCoroutine(this.SeasonClose());
  }

  public void IbtnExtend()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGGameDataManager>.GetInstance().StartCoroutine(this.ExtendPopup());
  }

  public void IbtnContinue()
  {
    if (this.IsPushAndSet())
      return;
    Versus02610Menu.IsContinue = true;
    this.menu.isEnableSeasonFinishButton(false);
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  [DebuggerHidden]
  private IEnumerator ExtendPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02688Menu.\u003CExtendPopup\u003Ec__IteratorA42()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SeasonClose()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02688Menu.\u003CSeasonClose\u003Ec__IteratorA43()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

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
  private IEnumerator CreateClassChange()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02688Menu.\u003CCreateClassChange\u003Ec__IteratorA44()
    {
      \u003C\u003Ef__this = this
    };
  }
}
