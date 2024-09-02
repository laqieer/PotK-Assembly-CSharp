// Decompiled with JetBrains decompiler
// Type: Quest0528Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest0528Scene : NGSceneBase
{
  public Quest0528Menu menu;
  private bool isScript;

  public static void changeScene(bool stack)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("quest052_8", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest0528Scene.\u003ConInitSceneAsync\u003Ec__Iterator60D asyncCIterator60D = new Quest0528Scene.\u003ConInitSceneAsync\u003Ec__Iterator60D();
    return (IEnumerator) asyncCIterator60D;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528Scene.\u003ConStartSceneAsync\u003Ec__Iterator60E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    if (this.isScript)
    {
      Singleton<CommonRoot>.GetInstance().isActiveHeader = false;
      Singleton<CommonRoot>.GetInstance().isActiveFooter = false;
      Singleton<CommonRoot>.GetInstance().isActiveBackground = false;
    }
    else
      Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  [DebuggerHidden]
  private IEnumerator LoadBackGround()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528Scene.\u003CLoadBackGround\u003Ec__Iterator60F()
    {
      \u003C\u003Ef__this = this
    };
  }
}
