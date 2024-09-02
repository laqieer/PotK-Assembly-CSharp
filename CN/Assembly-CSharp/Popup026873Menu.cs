// Decompiled with JetBrains decompiler
// Type: Popup026873Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup026873Menu : Popup02610Base
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtDescription1;
  [SerializeField]
  private UILabel txtDescription2;
  [SerializeField]
  private UILabel txtHime;
  [SerializeField]
  private UILabel txtHimeCount;

  public override void Init(WebAPI.Response.PvpBoot pvpInfo, Versus02610Menu menu)
  {
    base.Init(pvpInfo, menu);
    Consts instance = Consts.GetInstance();
    this.txtTitle.SetText(instance.VERSUS_0026873POPUP_TITLE);
    this.txtDescription1.SetText(instance.VERSUS_0026873POPUP_DESCRIPTION1);
    this.txtDescription2.SetText(instance.VERSUS_0026873POPUP_DESCRIPTION2);
    this.txtHimeCount.SetText(Player.Current.coin.ToLocalizeNumberText());
    this.txtHime.SetText(instance.GACHA_99931MENU_DESCRIPTION03);
  }

  public void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    if (Player.Current.CheckKiseki(1))
      Singleton<NGGameDataManager>.GetInstance().StartCoroutine(this.TicketRecovery());
    else
      this.StartCoroutine(this.ShortStoneAlert());
  }

  public override void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  private IEnumerator TicketRecovery()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup026873Menu.\u003CTicketRecovery\u003Ec__Iterator966()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShortStoneAlert()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup026873Menu.\u003CShortStoneAlert\u003Ec__Iterator967 alertCIterator967 = new Popup026873Menu.\u003CShortStoneAlert\u003Ec__Iterator967();
    return (IEnumerator) alertCIterator967;
  }
}
