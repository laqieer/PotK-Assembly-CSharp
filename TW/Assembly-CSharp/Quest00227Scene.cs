// Decompiled with JetBrains decompiler
// Type: Quest00227Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00227Scene : NGSceneBase
{
  [SerializeField]
  private Quest00227Menu menu;

  public static void ChangeScene(QuestScoreCampaignProgress qscp, bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_27", (stack ? 1 : 0) != 0, (object) qscp);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(QuestScoreCampaignProgress qscp)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00227Scene.\u003ConStartSceneAsync\u003Ec__Iterator282()
    {
      qscp = qscp,
      \u003C\u0024\u003Eqscp = qscp,
      \u003C\u003Ef__this = this
    };
  }
}
