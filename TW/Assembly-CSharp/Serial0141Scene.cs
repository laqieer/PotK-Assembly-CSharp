// Decompiled with JetBrains decompiler
// Type: Serial0141Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Serial0141Scene : NGSceneBase
{
  [SerializeField]
  private Serial0141Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Serial0141Scene.\u003ConInitSceneAsync\u003Ec__Iterator5C4()
    {
      \u003C\u003Ef__this = this
    };
  }
}
