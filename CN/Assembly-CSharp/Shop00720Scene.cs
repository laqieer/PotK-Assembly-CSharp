// Decompiled with JetBrains decompiler
// Type: Shop00720Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Shop00720Scene.\u003ConStartSceneAsync\u003Ec__Iterator45D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Shop00720Scene scene)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Scene.\u003ConStartSceneAsync\u003Ec__Iterator45E()
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
