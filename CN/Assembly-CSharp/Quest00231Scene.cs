// Decompiled with JetBrains decompiler
// Type: Quest00231Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00231Scene : NGSceneBase
{
  [SerializeField]
  private Quest00231Menu menu;

  public static void ChangeScene(
    WebAPI.Response.EventTop eventInfo,
    PunitiveExpeditionEventReward[] rewardList,
    bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_31", (stack ? 1 : 0) != 0, (object) eventInfo, (object) rewardList);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    WebAPI.Response.EventTop eventInfo,
    PunitiveExpeditionEventReward[] rewardList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00231Scene.\u003ConStartSceneAsync\u003Ec__Iterator264()
    {
      eventInfo = eventInfo,
      rewardList = rewardList,
      \u003C\u0024\u003EeventInfo = eventInfo,
      \u003C\u0024\u003ErewardList = rewardList,
      \u003C\u003Ef__this = this
    };
  }
}
