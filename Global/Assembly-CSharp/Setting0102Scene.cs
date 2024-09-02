// Decompiled with JetBrains decompiler
// Type: Setting0102Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Setting0102Scene : NGSceneBase
{
  [SerializeField]
  private Setting0102Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Setting0102Scene.\u003ConInitSceneAsync\u003Ec__Iterator4A3()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => this.menu.onEndScene();
}
