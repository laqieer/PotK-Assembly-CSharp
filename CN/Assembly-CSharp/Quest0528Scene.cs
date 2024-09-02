// Decompiled with JetBrains decompiler
// Type: Quest0528Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest0528Scene : NGSceneBase
{
  public Quest0528Menu menu;
  private bool isScript;
  private bool isInit;

  public static void changeScene(bool stack)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("quest052_8", stack);
  }

  public static void changeScene(bool stack, EarthExtraQuest quest)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("quest052_8", (stack ? 1 : 0) != 0, (object) quest);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest0528Scene.\u003ConInitSceneAsync\u003Ec__Iterator753 asyncCIterator753 = new Quest0528Scene.\u003ConInitSceneAsync\u003Ec__Iterator753();
    return (IEnumerator) asyncCIterator753;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528Scene.\u003ConStartSceneAsync\u003Ec__Iterator754()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(EarthExtraQuest quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528Scene.\u003ConStartSceneAsync\u003Ec__Iterator755()
    {
      quest = quest,
      \u003C\u0024\u003Equest = quest,
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

  public void onStartScene(EarthExtraQuest quest) => this.onStartScene();

  [DebuggerHidden]
  private IEnumerator LoadBackGround()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528Scene.\u003CLoadBackGround\u003Ec__Iterator756()
    {
      \u003C\u003Ef__this = this
    };
  }
}
