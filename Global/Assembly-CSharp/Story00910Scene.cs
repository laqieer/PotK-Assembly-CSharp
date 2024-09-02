// Decompiled with JetBrains decompiler
// Type: Story00910Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Story00910Scene.\u003ConStartSceneAsync\u003Ec__Iterator45F()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => this.menu.EndScene();
}
