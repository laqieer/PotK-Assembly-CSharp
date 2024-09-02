// Decompiled with JetBrains decompiler
// Type: Bugu00561Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu00561Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtDescription;
  [SerializeField]
  protected UILabel SupplyIntroduction;
  [SerializeField]
  protected UILabel GearIntroduction;
  [SerializeField]
  protected UILabel SupplyOwnednumber;
  [SerializeField]
  protected UILabel GearOwnednumber;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UI2DSprite LinkItem;
  [SerializeField]
  protected GameObject SupplyDetail;
  [SerializeField]
  protected GameObject GearDetail;
  [SerializeField]
  protected GameObject TouchBack;
  [SerializeField]
  protected BoxCollider ibtnBackCollider;
  [SerializeField]
  protected TweenAlpha slc_NewIcon;

  [DebuggerHidden]
  public IEnumerator InitDetailedScreen(GearGear gear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00561Menu.\u003CInitDetailedScreen\u003Ec__Iterator3DC()
    {
      gear = gear,
      \u003C\u0024\u003Egear = gear,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitDetailedScreen(ItemInfo item, bool isNew, bool isScreenTouch)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00561Menu.\u003CInitDetailedScreen\u003Ec__Iterator3DD()
    {
      isScreenTouch = isScreenTouch,
      isNew = isNew,
      item = item,
      \u003C\u0024\u003EisScreenTouch = isScreenTouch,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003Eitem = item,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
