// Decompiled with JetBrains decompiler
// Type: SM.GuildBank
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GuildBank : KeyCompare
  {
    public bool available;
    public int level;
    public int money;
    public GuildInvestScale[] scales;
    public int experience;
    public GuildMoneyRate[] tokens;
    public bool released;
    public int experience_next;
    public string message;

    public GuildBank()
    {
    }

    public GuildBank(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.available = (bool) json[nameof (available)];
      this.level = (int) (long) json[nameof (level)];
      this.money = (int) (long) json[nameof (money)];
      List<GuildInvestScale> guildInvestScaleList = new List<GuildInvestScale>();
      foreach (object json1 in (List<object>) json[nameof (scales)])
        guildInvestScaleList.Add(json1 != null ? new GuildInvestScale((Dictionary<string, object>) json1) : (GuildInvestScale) null);
      this.scales = guildInvestScaleList.ToArray();
      this.experience = (int) (long) json[nameof (experience)];
      List<GuildMoneyRate> guildMoneyRateList = new List<GuildMoneyRate>();
      foreach (object json2 in (List<object>) json[nameof (tokens)])
        guildMoneyRateList.Add(json2 != null ? new GuildMoneyRate((Dictionary<string, object>) json2) : (GuildMoneyRate) null);
      this.tokens = guildMoneyRateList.ToArray();
      this.released = (bool) json[nameof (released)];
      this.experience_next = (int) (long) json[nameof (experience_next)];
      this.message = (string) json[nameof (message)];
    }
  }
}
