﻿// Decompiled with JetBrains decompiler
// Type: Quest002272Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  private NGxScrollMasonry scroll;

  [DebuggerHidden]
  public IEnumerator Initialize(
    QuestScoreCampaignProgressScore_achivement_rewards achivement_reward,
    int[] achivement_cleard,
    string title,
    int score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002272Menu.\u003CInitialize\u003Ec__Iterator20E()
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

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }
}
