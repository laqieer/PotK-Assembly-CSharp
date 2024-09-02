// Decompiled with JetBrains decompiler
// Type: SM.GuildApplicant
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
