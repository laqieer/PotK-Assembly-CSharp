// Decompiled with JetBrains decompiler
// Type: Setting0101Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Setting0101Scene : NGSceneBase
{
  [SerializeField]
  private Setting0101Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Setting0101Scene.\u003ConInitSceneAsync\u003Ec__Iterator591()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Setting0101Scene.\u003ConEndSceneAsync\u003Ec__Iterator592()
    {
      \u003C\u003Ef__this = this
    };
  }
}
