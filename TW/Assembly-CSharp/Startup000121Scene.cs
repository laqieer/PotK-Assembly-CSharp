// Decompiled with JetBrains decompiler
// Type: Startup000121Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup000121Scene : NGSceneBase
{
  public Startup000121Menu menu;
  [SerializeField]
  private UIPanel newsPanel;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup000121Scene.\u003ConInitSceneAsync\u003Ec__Iterator1A2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup000121Scene.\u003ConStartSceneAsync\u003Ec__Iterator1A3()
    {
      \u003C\u003Ef__this = this
    };
  }
}
