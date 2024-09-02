// Decompiled with JetBrains decompiler
// Type: Versus02612Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Versus02612Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScrollMasonry Scroll;
  [SerializeField]
  private UILabel txtClassName;
  [SerializeField]
  private UISprite slcRankGaugeBlue;
  [SerializeField]
  private UISprite slcRankGaugeGreen;
  [SerializeField]
  private UISprite slcRankGaugeYellow;
  [SerializeField]
  private UISprite slcRankGaugeRed;

  [DebuggerHidden]
  public IEnumerator Init(int id, int best_class)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612Menu.\u003CInit\u003Ec__Iterator675()
    {
      id = id,
      best_class = best_class,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Ebest_class = best_class,
      \u003C\u003Ef__this = this
    };
  }

  private Dictionary<PvpClassRewardTypeEnum, List<PvpClassReward>> SetRewardsListOrder(int id)
  {
    return ((IEnumerable<PvpClassReward>) MasterData.PvpClassRewardList).Where<PvpClassReward>((Func<PvpClassReward, bool>) (x => x.class_kind.ID == id)).GroupBy<PvpClassReward, PvpClassRewardTypeEnum>((Func<PvpClassReward, PvpClassRewardTypeEnum>) (x => x.class_reward_type)).ToDictionary<IGrouping<PvpClassRewardTypeEnum, PvpClassReward>, PvpClassRewardTypeEnum, List<PvpClassReward>>((Func<IGrouping<PvpClassRewardTypeEnum, PvpClassReward>, PvpClassRewardTypeEnum>) (x => x.Key), (Func<IGrouping<PvpClassRewardTypeEnum, PvpClassReward>, List<PvpClassReward>>) (y => y.ToList<PvpClassReward>()));
  }

  private void SetRankGauge(PvpClassKind c)
  {
    int width = this.slcRankGaugeRed.width;
    int num = 10;
    this.slcRankGaugeBlue.width = (c.stay_point - 1) * width / num;
    this.slcRankGaugeGreen.width = (c.up_point - 1) * width / num;
    this.slcRankGaugeYellow.width = (c.title_point - 1) * width / num;
    ((Component) this.slcRankGaugeBlue).gameObject.SetActive(c.stay_point > 0);
    ((Component) this.slcRankGaugeGreen).gameObject.SetActive(c.up_point - c.stay_point > 0);
    ((Component) this.slcRankGaugeYellow).gameObject.SetActive(c.title_point - c.up_point > 0);
    ((Component) this.slcRankGaugeRed).gameObject.SetActive(true);
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
