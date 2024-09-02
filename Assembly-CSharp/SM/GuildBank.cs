// Decompiled with JetBrains decompiler
// Type: SM.GuildBank
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

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
      foreach (object obj in (List<object>) json[nameof (scales)])
        guildInvestScaleList.Add(obj == null ? (GuildInvestScale) null : new GuildInvestScale((Dictionary<string, object>) obj));
      this.scales = guildInvestScaleList.ToArray();
      this.experience = (int) (long) json[nameof (experience)];
      List<GuildMoneyRate> guildMoneyRateList = new List<GuildMoneyRate>();
      foreach (object obj in (List<object>) json[nameof (tokens)])
        guildMoneyRateList.Add(obj == null ? (GuildMoneyRate) null : new GuildMoneyRate((Dictionary<string, object>) obj));
      this.tokens = guildMoneyRateList.ToArray();
      this.released = (bool) json[nameof (released)];
      this.experience_next = (int) (long) json[nameof (experience_next)];
      this.message = (string) json[nameof (message)];
    }
  }
}
