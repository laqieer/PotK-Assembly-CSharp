// Decompiled with JetBrains decompiler
// Type: StoryScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class StoryScene : NGSceneBase
{
  public StoryExecuter executer;

  public static void changeScene009_3(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_3", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryScene.\u003ConInitSceneAsync\u003Ec__Iterator574()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => this.executer.render();
}
