// Decompiled with JetBrains decompiler
// Type: Quest00210aScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest00210aScene : NGSceneBase
{
  public Quest00210aMenu menu;
  public UIPanel scrollPanel;
  public UIWidget scrollBarWidget;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_10a", stack);
  }

  public static void changeScene(bool stack, Quest00210Menu.Param param)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_10a", (stack ? 1 : 0) != 0, (object) param);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210aScene.\u003ConStartSceneAsync\u003Ec__Iterator17C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Quest00210Menu.Param param)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210aScene.\u003ConStartSceneAsync\u003Ec__Iterator17D()
    {
      param = param,
      \u003C\u0024\u003Eparam = param,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => this.menu.onEndScene();
}
