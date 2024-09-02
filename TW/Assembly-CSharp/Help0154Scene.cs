// Decompiled with JetBrains decompiler
// Type: Help0154Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Help0154Scene : NGSceneBase
{
  public Help0154Menu menu;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("help015_4", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0154Scene.\u003ConStartSceneAsync\u003Ec__Iterator5CD()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => this.menu.InitContact(SMManager.Get<Player>());
}
