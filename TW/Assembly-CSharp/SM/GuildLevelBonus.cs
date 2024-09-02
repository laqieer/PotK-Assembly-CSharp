// Decompiled with JetBrains decompiler
// Type: SM.GuildLevelBonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GuildLevelBonus : KeyCompare
  {
    public int item;
    public int player_exp;
    public int unit_exp;
    public bool campaign_flag;
    public int money;

    public GuildLevelBonus()
    {
    }

    public GuildLevelBonus(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.item = (int) (long) json[nameof (item)];
      this.player_exp = (int) (long) json[nameof (player_exp)];
      this.unit_exp = (int) (long) json[nameof (unit_exp)];
      this.campaign_flag = (bool) json[nameof (campaign_flag)];
      this.money = (int) (long) json[nameof (money)];
    }
  }
}
