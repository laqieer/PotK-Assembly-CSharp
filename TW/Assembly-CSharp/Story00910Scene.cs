// Decompiled with JetBrains decompiler
// Type: Story00910Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00910Scene : NGSceneBase
{
  [SerializeField]
  private Story00910Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00910Scene.\u003ConStartSceneAsync\u003Ec__Iterator552()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => this.menu.EndScene();
}
