// Decompiled with JetBrains decompiler
// Type: Battle01Item
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01Item : NGBattleMenuBase
{
  [SerializeField]
  protected UI2DSprite item;
  [SerializeField]
  protected UILabel txt_Item_name;
  [SerializeField]
  protected UILabel txt_Item_amount;
  private BL.BattleModified<BL.Item> modified;
  private ItemIcon itemIcon;

  private void Awake() => ((Behaviour) this.item).enabled = false;

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01Item.\u003ConInitAsync\u003Ec__Iterator704()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doSetIcon(SupplySupply supply)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01Item.\u003CdoSetIcon\u003Ec__Iterator705()
    {
      supply = supply,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u003Ef__this = this
    };
  }

  protected override void LateUpdate_Battle()
  {
    if (this.modified == null || !this.modified.isChangedOnce())
      return;
    BL.Item obj = this.modified.value;
    this.StartCoroutine(this.doSetIcon(obj.item));
    this.setText(this.txt_Item_name, obj.item.name);
    this.setText(this.txt_Item_amount, "×" + (object) obj.amount);
  }

  public void setItem(BL.Item item) => this.modified = BL.Observe<BL.Item>(item);

  public BL.Item getItem() => this.modified.value;
}
