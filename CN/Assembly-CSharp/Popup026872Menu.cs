// Decompiled with JetBrains decompiler
// Type: Popup026872Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup026872Menu : Popup02610Base
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtDescriptionYellow;
  [SerializeField]
  private UILabel txtDescriptionNormal;
  [SerializeField]
  private UIButton btnRareMadal;
  [SerializeField]
  private UIButton btnBattleMadal;

  public override void Init(WebAPI.Response.PvpBoot pvpInfo, Versus02610Menu menu)
  {
    base.Init(pvpInfo, menu);
    Consts instance = Consts.GetInstance();
    this.txtTitle.SetText(instance.VERSUS_0026872POPUP_TITLE);
    this.txtDescriptionYellow.SetText(instance.VERSUS_0026872POPUP_DESCRIPTION1);
    this.txtDescriptionNormal.SetText(instance.VERSUS_0026872POPUP_DESCRIPTION2);
    ((Collider) ((Component) this.btnRareMadal).GetComponent<BoxCollider>()).enabled = pvpInfo.medal_shop_is_available;
    ((Collider) ((Component) this.btnBattleMadal).GetComponent<BoxCollider>()).enabled = pvpInfo.battle_medal_shop_is_available && Player.Current.GetReleaseColosseum();
  }

  public override void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    Singleton<NGGameDataManager>.GetInstance().StartCoroutine(this.Return2688Popup());
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnKiseki()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ExchangeTicketPopup());
  }

  [DebuggerHidden]
  private IEnumerator ExchangeTicketPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup026872Menu.\u003CExchangeTicketPopup\u003Ec__Iterator965()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnRareMedal()
  {
    if (this.IsPushAndSet())
      return;
    Shop00741Scene.changeScene(true);
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnBattleMedal()
  {
    if (this.IsPushAndSet())
      return;
    Shop00743Scene.changeScene(true);
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
