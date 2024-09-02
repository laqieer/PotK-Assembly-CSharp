// Decompiled with JetBrains decompiler
// Type: DailyMission0272Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0272Scene : NGSceneBase
{
  [SerializeField]
  private DailyMission0272Menu menu;

  public static void ChangeScene0272(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("dailymission027_2", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Scene.\u003ConStartSceneAsync\u003Ec__Iterator686()
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
