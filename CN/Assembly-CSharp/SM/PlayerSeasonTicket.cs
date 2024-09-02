// Decompiled with JetBrains decompiler
// Type: SM.PlayerSeasonTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerSeasonTicket : KeyCompare
  {
    public string player_id;
    public int max_quantity;
    public int season_ticket_id;
    public int quantity;

    public PlayerSeasonTicket()
    {
    }

    public PlayerSeasonTicket(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player_id = (string) json[nameof (player_id)];
      this.max_quantity = (int) (long) json[nameof (max_quantity)];
      this.season_ticket_id = (int) (long) json[nameof (season_ticket_id)];
      this.quantity = (int) (long) json[nameof (quantity)];
    }
  }
}
