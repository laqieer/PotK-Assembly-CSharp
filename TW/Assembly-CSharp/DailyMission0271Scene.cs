// Decompiled with JetBrains decompiler
// Type: DailyMission0271Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271Scene : NGSceneBase
{
  [SerializeField]
  private DailyMission0271Menu menu;

  public static void ChangeScene0271(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("dailymission027_1", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Scene.\u003ConStartSceneAsync\u003Ec__Iterator6CC()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
  }
}
