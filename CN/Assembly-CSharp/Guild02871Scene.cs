// Decompiled with JetBrains decompiler
// Type: Guild02871Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild02871Scene : NGSceneBase
{
  [SerializeField]
  private Guild02871Menu menu;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("guild028_7_1", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02871Scene.\u003ConStartSceneAsync\u003Ec__Iterator722()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => this.menu.Initialize();

  public override void onEndScene()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    DetailController.Release();
  }
}
