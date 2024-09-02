// Decompiled with JetBrains decompiler
// Type: Shop00720Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00720Scene : NGSceneBase
{
  [SerializeField]
  private Shop00720Menu Menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Scene.\u003ConStartSceneAsync\u003Ec__Iterator3D9()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Shop00720Scene scene)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Scene.\u003ConStartSceneAsync\u003Ec__Iterator3DA()
    {
      scene = scene,
      \u003C\u0024\u003Escene = scene,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => this.Menu.Ready();

  public override void onSceneInitialized()
  {
  }

  public override void onEndScene() => this.Menu.DestroyEffect();
}
