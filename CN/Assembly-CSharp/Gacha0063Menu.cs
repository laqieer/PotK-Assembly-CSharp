// Decompiled with JetBrains decompiler
// Type: Gacha0063Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Gacha0063Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtGachaPt;
  [SerializeField]
  protected UILabel TxtGachaTicket;
  public Gacha0063Scene scene;
  public GameObject gachaChargePrefab;
  public GameObject gachaTicketPopupPrefab;
  public GameObject gachaChargeErrorPrefab;
  public GameObject gachaPtErrorPrefab;
  public GameObject gachaUnitErrorPrefab;
  public GameObject gachaItemErrorPrefab;
  public GameObject popup;
  public GameObject popupTextPrefab;
  public GameObject buyKisekiPrefab;
  public GameObject popupPrefab0079;
  public GameObject popupSheet;
  public CommonElementIcon commonElementIcon;
  public bool sceneChangeStop;
  public bool coroutineEnd;
  public bool isSheetPopup;

  public bool CheckGachaCharge(GachaModuleGacha gachaData)
  {
    return !this.isSheetPopup && this.GachaCheckCrystal(gachaData) && this.GachaCheckUnit();
  }

  public bool CheckGachaPt(GachaModuleGacha gachaData, int play_num = 1, bool isTryAgain = false)
  {
    return !this.isSheetPopup && this.GachaCheckFriend(gachaData, play_num) && this.ManaGachaCheckUnit(isTryAgain) && this.GachaCheckItem(isTryAgain);
  }

  public bool CheckGachaTicket(GachaModuleGacha gacha_data)
  {
    return !this.isSheetPopup && this.GachaCheckUnit() && this.GachaCheckItem();
  }

  private bool GachaCheckCrystal(GachaModuleGacha gachaData)
  {
    if (SMManager.Get<Player>().CheckKiseki(gachaData.payment_amount))
      return true;
    this.StartCoroutine(this.ChargeError());
    return false;
  }

  [DebuggerHidden]
  private IEnumerator ChargeError()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Menu.\u003CChargeError\u003Ec__Iterator3E2()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool GachaCheckFriend(GachaModuleGacha gacha_data, int play_num = 1)
  {
    if (SMManager.Get<Player>().CheckFrendPoint(gacha_data.payment_amount * play_num))
      return true;
    this.StartCoroutine(this.PtError());
    return false;
  }

  [DebuggerHidden]
  private IEnumerator PtError()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Menu.\u003CPtError\u003Ec__Iterator3E3()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool GachaCheckUnit()
  {
    if (!SMManager.Get<Player>().CheckCapMaxUnit())
      return true;
    this.StartCoroutine(PopupUtility._999_5_1(true));
    return false;
  }

  private bool ManaGachaCheckUnit(bool isTryAgain = false)
  {
    if (!SMManager.Get<Player>().CheckMaxUnit())
      return true;
    this.StartCoroutine(PopupUtility._999_5_1(true, isTryAgain));
    return false;
  }

  private bool GachaCheckItem(bool isTryAgain = false)
  {
    if (!SMManager.Get<Player>().CheckMaxItem())
      return true;
    this.StartCoroutine(PopupUtility._999_6_1(true, isTryAgain));
    return false;
  }

  [DebuggerHidden]
  public IEnumerator CreatePrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Menu.\u003CCreatePrefab\u003Ec__Iterator3E4()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
  }

  public virtual void IbtnBuyKiseki()
  {
    if (this.IsPushAndSet())
      return;
    PopupUtility.BuyKiseki();
  }

  public virtual void IbtnGachaCharge()
  {
  }

  public virtual void IbtnGachaPt01()
  {
  }

  public virtual void IbtnGachaPt02()
  {
  }

  public virtual void IbtnGachaTicket01()
  {
  }

  public virtual void IbtnGachaTicket02()
  {
  }

  public virtual void IbtnGetList01()
  {
  }

  public virtual void IbtnGetList02()
  {
  }

  public virtual void IbtnUnitlist()
  {
  }

  public void IbtnGachaHistory()
  {
    Future<WebAPI.Response.Gachahistory> history = WebAPI.Gachahistory();
    history.RunOn<WebAPI.Response.Gachahistory>((MonoBehaviour) this, (Action<WebAPI.Response.Gachahistory>) (_ =>
    {
      string description = string.Empty;
      foreach (WebAPI.Response.GachahistoryUnits unit in history.Result.units)
        description = description + unit.time + "\r\n" + unit.gacha_history + "\r\n\n";
      Singleton<PopupManager>.GetInstance().openAlert(this.popup).GetComponent<Help0153Menu>().InitHelpPopup(Consts.GetInstance().GACHA_HISTORY_TITLE, description, this.popupTextPrefab);
    }));
  }
}
