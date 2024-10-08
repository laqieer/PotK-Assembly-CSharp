﻿// Decompiled with JetBrains decompiler
// Type: SM.BeginnerPackInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class BeginnerPackInfo : KeyCompare
  {
    public BeginnerPackReward[] rewards;
    public DateTime? beginner_end_at;
    public BeginnerPackDescription[] descriptions;
    public PlayerPackStatus player_pack;
    public BeginnerPack pack;

    public BeginnerPackInfo()
    {
    }

    public BeginnerPackInfo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<BeginnerPackReward> beginnerPackRewardList = new List<BeginnerPackReward>();
      foreach (object obj in (List<object>) json[nameof (rewards)])
        beginnerPackRewardList.Add(obj == null ? (BeginnerPackReward) null : new BeginnerPackReward((Dictionary<string, object>) obj));
      this.rewards = beginnerPackRewardList.ToArray();
      this.beginner_end_at = json[nameof (beginner_end_at)] == null ? new DateTime?() : new DateTime?(DateTime.Parse((string) json[nameof (beginner_end_at)]));
      List<BeginnerPackDescription> beginnerPackDescriptionList = new List<BeginnerPackDescription>();
      foreach (object obj in (List<object>) json[nameof (descriptions)])
        beginnerPackDescriptionList.Add(obj == null ? (BeginnerPackDescription) null : new BeginnerPackDescription((Dictionary<string, object>) obj));
      this.descriptions = beginnerPackDescriptionList.ToArray();
      this.player_pack = json[nameof (player_pack)] == null ? (PlayerPackStatus) null : new PlayerPackStatus((Dictionary<string, object>) json[nameof (player_pack)]);
      this.pack = json[nameof (pack)] == null ? (BeginnerPack) null : new BeginnerPack((Dictionary<string, object>) json[nameof (pack)]);
    }
  }
}
