// Decompiled with JetBrains decompiler
// Type: Quest00228Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00228Scene : NGSceneBase
{
  [SerializeField]
  private Quest00228Menu menu;

  public static void ChangeScene(QuestScoreCampaignProgress qscp, bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_28", (stack ? 1 : 0) != 0, (object) qscp);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(QuestScoreCampaignProgress qscp)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00228Scene.\u003ConStartSceneAsync\u003Ec__Iterator212()
    {
      qscp = qscp,
      \u003C\u0024\u003Eqscp = qscp,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => DetailController.Release();
}
