// Decompiled with JetBrains decompiler
// Type: Shop00742UnitOther
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Shop00742UnitOther.\u003CInitialize\u003Ec__Iterator49C()
    {
      target = target,
      \u003C\u0024\u003Etarget = target,
      \u003C\u003Ef__this = this
    };
  }
}
