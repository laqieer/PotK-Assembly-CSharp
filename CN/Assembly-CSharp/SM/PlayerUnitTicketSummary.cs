// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnitTicketSummary
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
