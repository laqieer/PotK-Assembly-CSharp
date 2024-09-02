// Decompiled with JetBrains decompiler
// Type: Quest002272Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest002272Scene : NGSceneBase
{
  [SerializeField]
  private Quest002272Menu menu;

  public static void ChangeScene(
    bool stack,
    QuestScoreCampaignProgressScore_achivement_rewards achivement_reward,
    int[] achivement_cleard,
    string title,
    int score)
  {
    Quest002272SceneChangeData quest002272SceneChangeData = new Quest002272SceneChangeData(achivement_reward, achivement_cleard, title, score);
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_27_2", (stack ? 1 : 0) != 0, (object) quest002272SceneChangeData);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Quest002272SceneChangeData data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002272Scene.\u003ConStartSceneAsync\u003Ec__Iterator20F()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }
}
