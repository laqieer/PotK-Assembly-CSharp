// Decompiled with JetBrains decompiler
// Type: Unit00443indicatorDirection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00443indicatorDirection : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtIntroduction;

  [DebuggerHidden]
  public IEnumerator Init(PlayerItem targetGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00443indicatorDirection.\u003CInit\u003Ec__Iterator2DC()
    {
      targetGear = targetGear,
      \u003C\u0024\u003EtargetGear = targetGear,
      \u003C\u003Ef__this = this
    };
  }

  public void Init(GearGear gear) => this.TxtIntroduction.SetTextLocalize(gear.description);
}
