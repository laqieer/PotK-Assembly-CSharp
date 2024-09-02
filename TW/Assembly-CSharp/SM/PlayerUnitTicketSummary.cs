// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnitTicketSummary
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerUnitTicketSummary : KeyCompare
  {
    public UnitTicket unit_ticket;
    public int quantity;

    public PlayerUnitTicketSummary()
    {
    }

    public PlayerUnitTicketSummary(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.unit_ticket = json[nameof (unit_ticket)] != null ? new UnitTicket((Dictionary<string, object>) json[nameof (unit_ticket)]) : (UnitTicket) null;
      this.quantity = (int) (long) json[nameof (quantity)];
    }
  }
}
