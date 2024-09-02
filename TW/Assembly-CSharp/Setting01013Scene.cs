// Decompiled with JetBrains decompiler
// Type: Setting01013Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Setting01013Scene : NGSceneBase
{
  [SerializeField]
  private Setting01013Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Setting01013Scene.\u003ConInitSceneAsync\u003Ec__Iterator594()
    {
      \u003C\u003Ef__this = this
    };
  }
}
