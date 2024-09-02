// Decompiled with JetBrains decompiler
// Type: DailyMission02712Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission02712Scene : NGSceneBase
{
  [SerializeField]
  private DailyMission02712Menu menu;

  public static void ChangeScene02712(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("dailymission027_1_2", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712Scene.\u003ConStartSceneAsync\u003Ec__Iterator5DC()
    {
      \u003C\u003Ef__this = this
    };
  }
}
