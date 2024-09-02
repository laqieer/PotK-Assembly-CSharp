// Decompiled with JetBrains decompiler
// Type: Guild0287Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild0287Scene : NGSceneBase
{
  [SerializeField]
  private Guild0287Menu menu;

  public static void ChangeScene()
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("guild028_7", true);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0287Scene.\u003ConStartSceneAsync\u003Ec__Iterator7D5()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => this.menu.Initialize();

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0287Scene.\u003ConEndSceneAsync\u003Ec__Iterator7D6()
    {
      \u003C\u003Ef__this = this
    };
  }
}
