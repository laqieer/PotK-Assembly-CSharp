// Decompiled with JetBrains decompiler
// Type: SM.PlayerSelectTicketSummary
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class PlayerSelectTicketSummary : KeyCompare
  {
    public PlayerSelectTicketSummaryPlayer_exchange_count_list[] player_exchange_count_list;
    public int ticket_id;
    public int quantity;

    public PlayerSelectTicketSummary()
    {
    }

    public PlayerSelectTicketSummary(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<PlayerSelectTicketSummaryPlayer_exchange_count_list> exchangeCountListList = new List<PlayerSelectTicketSummaryPlayer_exchange_count_list>();
      foreach (object obj in (List<object>) json[nameof (player_exchange_count_list)])
        exchangeCountListList.Add(obj == null ? (PlayerSelectTicketSummaryPlayer_exchange_count_list) null : new PlayerSelectTicketSummaryPlayer_exchange_count_list((Dictionary<string, object>) obj));
      this.player_exchange_count_list = exchangeCountListList.ToArray();
      this.ticket_id = (int) (long) json[nameof (ticket_id)];
      this.quantity = (int) (long) json[nameof (quantity)];
    }
  }
}
