﻿// Decompiled with JetBrains decompiler
// Type: SM.MonthlyPackInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class MonthlyPackInfo : KeyCompare
  {
    public MonthlyPackExtraReward[] extra_rewards;
    public MonthlyPackReward[] rewards;
    public MonthlyPackDescription[] descriptions;
    public PlayerPackStatus player_pack;
    public MonthlyPack pack;

    public MonthlyPackInfo()
    {
    }

    public MonthlyPackInfo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<MonthlyPackExtraReward> monthlyPackExtraRewardList = new List<MonthlyPackExtraReward>();
      foreach (object obj in (List<object>) json[nameof (extra_rewards)])
        monthlyPackExtraRewardList.Add(obj == null ? (MonthlyPackExtraReward) null : new MonthlyPackExtraReward((Dictionary<string, object>) obj));
      this.extra_rewards = monthlyPackExtraRewardList.ToArray();
      List<MonthlyPackReward> monthlyPackRewardList = new List<MonthlyPackReward>();
      foreach (object obj in (List<object>) json[nameof (rewards)])
        monthlyPackRewardList.Add(obj == null ? (MonthlyPackReward) null : new MonthlyPackReward((Dictionary<string, object>) obj));
      this.rewards = monthlyPackRewardList.ToArray();
      List<MonthlyPackDescription> monthlyPackDescriptionList = new List<MonthlyPackDescription>();
      foreach (object obj in (List<object>) json[nameof (descriptions)])
        monthlyPackDescriptionList.Add(obj == null ? (MonthlyPackDescription) null : new MonthlyPackDescription((Dictionary<string, object>) obj));
      this.descriptions = monthlyPackDescriptionList.ToArray();
      this.player_pack = json[nameof (player_pack)] == null ? (PlayerPackStatus) null : new PlayerPackStatus((Dictionary<string, object>) json[nameof (player_pack)]);
      this.pack = json[nameof (pack)] == null ? (MonthlyPack) null : new MonthlyPack((Dictionary<string, object>) json[nameof (pack)]);
    }
  }
}
