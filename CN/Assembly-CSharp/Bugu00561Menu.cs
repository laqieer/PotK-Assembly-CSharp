// Decompiled with JetBrains decompiler
// Type: Bugu00561Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
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
    return (IEnumerator) new Bugu00561Menu.\u003CInitDetailedScreen\u003Ec__Iterator3B1()
    {
      gear = gear,
      \u003C\u0024\u003Egear = gear,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitDetailedScreen(PlayerItem item, bool isNew, bool isScreenTouch)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00561Menu.\u003CInitDetailedScreen\u003Ec__Iterator3B2()
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

  private int SearchQuantity(PlayerItem item)
  {
    PlayerItem[] playerItemArray = SMManager.Get<PlayerItem[]>();
    int num = 0;
    if (item.gear != null)
    {
      foreach (PlayerItem playerItem in playerItemArray)
      {
        if (playerItem.gear != null && playerItem.gear.ID == item.gear.ID)
          num += playerItem.quantity;
      }
    }
    else
    {
      foreach (PlayerItem playerItem in playerItemArray)
      {
        if (playerItem.supply != null && playerItem.supply.ID == item.supply.ID)
          num += playerItem.quantity;
      }
    }
    Debug.LogWarning((object) ("Quantity:" + (object) num));
    return num;
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
