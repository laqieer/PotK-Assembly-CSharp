// Decompiled with JetBrains decompiler
// Type: Shop00720Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Shop00720Scene.\u003ConStartSceneAsync\u003Ec__Iterator4A5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Shop00720Scene scene)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Scene.\u003ConStartSceneAsync\u003Ec__Iterator4A6()
    {
      scene = scene,
      \u003C\u0024\u003Escene = scene,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    Debug.Log((object) "★★★ onStartScene ★★★");
    this.Menu.Ready();
  }

  public override void onSceneInitialized() => Debug.Log((object) "★★★ onSceneInitialized ★★★");

  public override void onEndScene()
  {
    Debug.Log((object) "★★★ onEndScene ★★★");
    this.Menu.DestroyEffect();
  }
}
