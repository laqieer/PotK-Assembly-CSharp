// Decompiled with JetBrains decompiler
// Type: SM.GuildApplicant
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GuildApplicant : KeyCompare
  {
    public GuildPlayerInfo player;
    public DateTime applied_at;

    public GuildApplicant()
    {
    }

    public GuildApplicant(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player = json[nameof (player)] != null ? new GuildPlayerInfo((Dictionary<string, object>) json[nameof (player)]) : (GuildPlayerInfo) null;
      this.applied_at = DateTime.Parse((string) json[nameof (applied_at)]);
    }
  }
}
