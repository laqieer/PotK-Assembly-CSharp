// Decompiled with JetBrains decompiler
// Type: Gacha0063Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
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

  public bool CheckGachaPt(GachaModuleGacha gachaData)
  {
    return !this.isSheetPopup && this.GachaCheckFriend(gachaData) && this.ManaGachaCheckUnit() && this.GachaCheckItem();
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
    return (IEnumerator) new Gacha0063Menu.\u003CChargeError\u003Ec__Iterator369()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool GachaCheckFriend(GachaModuleGacha gacha_data)
  {
    if (SMManager.Get<Player>().CheckFrendPoint(gacha_data.payment_amount))
      return true;
    this.StartCoroutine(this.PtError());
    return false;
  }

  [DebuggerHidden]
  private IEnumerator PtError()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Menu.\u003CPtError\u003Ec__Iterator36A()
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

  private bool ManaGachaCheckUnit()
  {
    if (!SMManager.Get<Player>().CheckMaxUnit())
      return true;
    this.StartCoroutine(PopupUtility._999_5_1(true));
    return false;
  }

  private bool GachaCheckItem()
  {
    if (!SMManager.Get<Player>().CheckMaxItem())
      return true;
    this.StartCoroutine(PopupUtility._999_6_1(true));
    return false;
  }

  [DebuggerHidden]
  public IEnumerator CreatePrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Menu.\u003CCreatePrefab\u003Ec__Iterator36B()
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
}
