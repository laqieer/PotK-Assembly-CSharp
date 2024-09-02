// Decompiled with JetBrains decompiler
// Type: Quest002272Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest002272Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtTotalPoint;
  [SerializeField]
  private UILabel txtTotalTxt;
  [SerializeField]
  private NGxScrollMasonry scroll;

  [DebuggerHidden]
  public IEnumerator Initialize(
    QuestScoreCampaignProgressScore_achivement_rewards achivement_reward,
    int[] achivement_cleard,
    string title,
    int score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002272Menu.\u003CInitialize\u003Ec__Iterator250()
    {
      title = title,
      score = score,
      achivement_reward = achivement_reward,
      achivement_cleard = achivement_cleard,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Escore = score,
      \u003C\u0024\u003Eachivement_reward = achivement_reward,
      \u003C\u0024\u003Eachivement_cleard = achivement_cleard,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Initialize(QuestScoreTotalReward[] rewards, string title, int score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002272Menu.\u003CInitialize\u003Ec__Iterator251()
    {
      title = title,
      score = score,
      rewards = rewards,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Escore = score,
      \u003C\u0024\u003Erewards = rewards,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }
}
