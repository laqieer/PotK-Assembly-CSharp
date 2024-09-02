// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollView05
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using UnityEngine;

#nullable disable
public class DetailMenuScrollView05 : DetailMenuScrollViewBase
{
  [SerializeField]
  protected UILabel TxtIntroduction;

  public override bool Init(PlayerUnit playerUnit)
  {
    ((Component) this).gameObject.SetActive(true);
    this.Set(playerUnit.unit);
    return true;
  }

  public void Set(UnitUnit unit) => this.TxtIntroduction.SetTextLocalize(unit.description);
}
