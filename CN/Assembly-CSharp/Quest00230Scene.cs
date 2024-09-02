// Decompiled with JetBrains decompiler
// Type: Quest00230Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00230Scene : NGSceneBase
{
  [SerializeField]
  private Quest00230Menu menu;

  public static void ChangeScene(bool stack, int period_id)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_30", (stack ? 1 : 0) != 0, (object) period_id);
  }

  public static void ChangeScene(bool stack, EventInfo eventInfo)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_30", (stack ? 1 : 0) != 0, (object) eventInfo);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(EventInfo eventInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00230Scene.\u003ConStartSceneAsync\u003Ec__Iterator261()
    {
      eventInfo = eventInfo,
      \u003C\u0024\u003EeventInfo = eventInfo,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int period_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00230Scene.\u003ConStartSceneAsync\u003Ec__Iterator262()
    {
      period_id = period_id,
      \u003C\u0024\u003Eperiod_id = period_id,
      \u003C\u003Ef__this = this
    };
  }
}
