// Decompiled with JetBrains decompiler
// Type: Guild02871Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Guild02871Scene.\u003ConStartSceneAsync\u003Ec__Iterator7D9()
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
