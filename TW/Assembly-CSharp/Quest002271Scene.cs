// Decompiled with JetBrains decompiler
// Type: Quest002271Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest002271Scene : NGSceneBase
{
  [SerializeField]
  private Quest002271Menu menu;

  public static void ChangeScene(
    bool stack,
    QuestScoreCampaignProgress progress,
    string title,
    int rank)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_27_1", (stack ? 1 : 0) != 0, (object) progress, (object) title, (object) rank);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(QuestScoreCampaignProgress progress, string title, int rank)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002271Scene.\u003ConStartSceneAsync\u003Ec__Iterator284()
    {
      progress = progress,
      title = title,
      rank = rank,
      \u003C\u0024\u003Eprogress = progress,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Erank = rank,
      \u003C\u003Ef__this = this
    };
  }
}
