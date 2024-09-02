// Decompiled with JetBrains decompiler
// Type: Unit00443indicatorDirection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00443indicatorDirection : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtIntroduction;

  [DebuggerHidden]
  public IEnumerator Init(ItemInfo targetGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00443indicatorDirection.\u003CInit\u003Ec__Iterator31C()
    {
      targetGear = targetGear,
      \u003C\u0024\u003EtargetGear = targetGear,
      \u003C\u003Ef__this = this
    };
  }

  public void Init(GearGear gear) => this.TxtIntroduction.SetTextLocalize(gear.description);
}
