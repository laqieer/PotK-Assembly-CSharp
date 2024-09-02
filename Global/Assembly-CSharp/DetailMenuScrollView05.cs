// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollView05
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
