// Decompiled with JetBrains decompiler
// Type: Quest00210aScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest00210aScene : NGSceneBase
{
  public Quest00210aMenu menu;

  public static void ChangeScene(bool stack, Quest00210Menu.Param param)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_10a", (stack ? 1 : 0) != 0, (object) param);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest00210aScene.\u003ConInitSceneAsync\u003Ec__Iterator1E2 asyncCIterator1E2 = new Quest00210aScene.\u003ConInitSceneAsync\u003Ec__Iterator1E2();
    return (IEnumerator) asyncCIterator1E2;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Quest00210Menu.Param param)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210aScene.\u003ConStartSceneAsync\u003Ec__Iterator1E3()
    {
      param = param,
      \u003C\u0024\u003Eparam = param,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void onStartScene(Quest00210Menu.Param param)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<CommonRoot>.GetInstance().isActiveHeader = true;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = true;
  }

  public override void onEndScene() => this.menu.onEndScene();
}
