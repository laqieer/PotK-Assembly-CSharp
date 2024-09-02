// Decompiled with JetBrains decompiler
// Type: Battle01ItemSubject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01ItemSubject : NGBattleMenuBase
{
  [SerializeField]
  private UI2DSprite icon;
  [SerializeField]
  private UILabel txt_name;
  [SerializeField]
  private UILabel txt_description;
  [SerializeField]
  private UILabel txt_amount;
  private ItemIcon itemIcon;
  private BL.Item item;

  private void Awake() => ((Behaviour) this.icon).enabled = false;

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01ItemSubject.\u003ConInitAsync\u003Ec__Iterator707()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doSetIcon(SupplySupply supply)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01ItemSubject.\u003CdoSetIcon\u003Ec__Iterator708()
    {
      supply = supply,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u003Ef__this = this
    };
  }

  public void setItemTargets(BL.Item item, List<BL.Unit> targets)
  {
    this.item = item;
    this.StartCoroutine(this.doSetIcon(item.item));
    this.setText(this.txt_name, item.item.name);
    this.setText(this.txt_description, item.item.description);
    this.setText(this.txt_amount, item.amount);
    Battle01ItemUseSelect[] componentsInChildren = ((Component) this).GetComponentsInChildren<Battle01ItemUseSelect>(true);
    if (componentsInChildren.Length <= 0)
      return;
    componentsInChildren[0].setTargets(targets, true);
  }

  public void useUnit(BL.Unit unit)
  {
    if (this.item == null)
      return;
    this.env.useItem(this.item, unit, this.battleManager.getManager<BattleTimeManager>());
    NGUITools.FindInParents<Battle01SelectNode>(((Component) this).transform).backToTop();
  }
}
