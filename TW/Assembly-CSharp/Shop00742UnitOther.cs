// Decompiled with JetBrains decompiler
// Type: Shop00742UnitOther
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00742UnitOther : Shop00742Unit
{
  [SerializeField]
  protected UILabel TxtFlavor;

  [DebuggerHidden]
  public IEnumerator Initialize(UnitUnit target)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742UnitOther.\u003CInitialize\u003Ec__Iterator4EC()
    {
      target = target,
      \u003C\u0024\u003Etarget = target,
      \u003C\u003Ef__this = this
    };
  }
}
