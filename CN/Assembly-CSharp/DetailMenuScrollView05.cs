// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollView05
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
