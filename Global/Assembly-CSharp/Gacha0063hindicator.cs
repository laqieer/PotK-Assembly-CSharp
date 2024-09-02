// Decompiled with JetBrains decompiler
// Type: Gacha0063hindicator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Gacha0063hindicator : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtGachaPt;
  [SerializeField]
  protected UILabel TxtGachaTicket;
  public bool update;
  public int imgNumber;
  public List<GachaButton> gachaButton;
  public GachaButton singleGachaButton;
  public GachaButton singleGachaButtonEx;
  private GachaModule gachaModule;

  public GachaModule GachaModule
  {
    get => this.gachaModule;
    set => this.gachaModule = value;
  }

  public Gacha0063Menu Menu { get; set; }

  public virtual void InitGachaModuleGacha(
    Gacha0063Menu gacha0063Menu,
    GachaModule gachaModule,
    DateTime serverTime,
    UIScrollView scrollView)
  {
  }

  public virtual void InitGachaModuleGacha(Gacha0063Menu menu, GachaModuleGacha gacha)
  {
  }

  [DebuggerHidden]
  public virtual IEnumerator Set(GameObject detailPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Gacha0063hindicator.\u003CSet\u003Ec__Iterator378 setCIterator378 = new Gacha0063hindicator.\u003CSet\u003Ec__Iterator378();
    return (IEnumerator) setCIterator378;
  }

  public virtual void PlayAnim()
  {
  }

  public virtual void EndAnim()
  {
  }

  public virtual void IbtnBuyKiseki()
  {
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
