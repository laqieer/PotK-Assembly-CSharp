// Decompiled with JetBrains decompiler
// Type: StoryScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new StoryScene.\u003ConInitSceneAsync\u003Ec__Iterator481()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => this.executer.render();
}
