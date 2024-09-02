// Decompiled with JetBrains decompiler
// Type: Gacha0063hindicator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  [SerializeField]
  private GameObject newIcon;
  public bool update;
  public int imgNumber;
  public List<GachaButton> gachaButton;
  public GachaButton singleGachaButton;
  public GachaButton singleGachaButtonEx;
  private GachaModule gachaModule;
  public bool IsSetFinsihed;

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
  public virtual IEnumerator Set(
    GameObject detailPopup,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Gacha0063hindicator.\u003CSet\u003Ec__Iterator3F1 setCIterator3F1 = new Gacha0063hindicator.\u003CSet\u003Ec__Iterator3F1();
    return (IEnumerator) setCIterator3F1;
  }

  [DebuggerHidden]
  public IEnumerator SetInBackground(
    GameObject detailPopup,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063hindicator.\u003CSetInBackground\u003Ec__Iterator3F2()
    {
      detailPopup = detailPopup,
      textPrefab = textPrefab,
      spritePrefab = spritePrefab,
      \u003C\u0024\u003EdetailPopup = detailPopup,
      \u003C\u0024\u003EtextPrefab = textPrefab,
      \u003C\u0024\u003EspritePrefab = spritePrefab,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void PlayAnim()
  {
  }

  public virtual void EndAnim()
  {
  }

  public void SetNewIconVisibility(bool isVisible) => this.newIcon.SetActive(isVisible);

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
