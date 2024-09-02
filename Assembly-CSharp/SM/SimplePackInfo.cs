// Decompiled with JetBrains decompiler
// Type: SM.SimplePackInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class SimplePackInfo : KeyCompare
  {
    public SimplePackReward[] rewards;
    public SimplePackDescription[] descriptions;
    public PlayerPackStatus player_pack;
    public SimplePack pack;

    public SimplePackInfo()
    {
    }

    public SimplePackInfo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<SimplePackReward> simplePackRewardList = new List<SimplePackReward>();
      foreach (object obj in (List<object>) json[nameof (rewards)])
        simplePackRewardList.Add(obj == null ? (SimplePackReward) null : new SimplePackReward((Dictionary<string, object>) obj));
      this.rewards = simplePackRewardList.ToArray();
      List<SimplePackDescription> simplePackDescriptionList = new List<SimplePackDescription>();
      foreach (object obj in (List<object>) json[nameof (descriptions)])
        simplePackDescriptionList.Add(obj == null ? (SimplePackDescription) null : new SimplePackDescription((Dictionary<string, object>) obj));
      this.descriptions = simplePackDescriptionList.ToArray();
      this.player_pack = json[nameof (player_pack)] == null ? (PlayerPackStatus) null : new PlayerPackStatus((Dictionary<string, object>) json[nameof (player_pack)]);
      this.pack = json[nameof (pack)] == null ? (SimplePack) null : new SimplePack((Dictionary<string, object>) json[nameof (pack)]);
    }
  }
}
