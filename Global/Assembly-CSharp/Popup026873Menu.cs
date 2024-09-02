﻿// Decompiled with JetBrains decompiler
// Type: Popup026873Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    this.txtTitle.SetText(Consts.Lookup("VERSUS_0026873POPUP_TITLE"));
    this.txtDescription1.SetText(Consts.Lookup("VERSUS_0026873POPUP_DESCRIPTION1"));
    this.txtDescription2.SetText(Consts.Lookup("VERSUS_0026873POPUP_DESCRIPTION2"));
    this.txtHimeCount.SetText(Player.Current.coin.ToLocalizeNumberText());
    this.txtHime.SetText(Consts.Lookup("GACHA_99931MENU_DESCRIPTION03"));
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
    return (IEnumerator) new Popup026873Menu.\u003CTicketRecovery\u003Ec__Iterator7F7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShortStoneAlert()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup026873Menu.\u003CShortStoneAlert\u003Ec__Iterator7F8 alertCIterator7F8 = new Popup026873Menu.\u003CShortStoneAlert\u003Ec__Iterator7F8();
    return (IEnumerator) alertCIterator7F8;
  }
}
