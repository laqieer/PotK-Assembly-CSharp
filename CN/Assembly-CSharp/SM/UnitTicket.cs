// Decompiled with JetBrains decompiler
// Type: SM.UnitTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class UnitTicket : KeyCompare
  {
    public DateTime start_at;
    public string description;
    public DateTime end_at;
    public bool unit_type_selectable;
    public int cost;
    public int id;
    public UnitTicketUnit_choices[] unit_choices;

    public UnitTicket()
    {
    }

    public UnitTicket(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.start_at = DateTime.Parse((string) json[nameof (start_at)]);
      this.description = (string) json[nameof (description)];
      this.end_at = DateTime.Parse((string) json[nameof (end_at)]);
      this.unit_type_selectable = (bool) json[nameof (unit_type_selectable)];
      this.cost = (int) (long) json[nameof (cost)];
      this.id = (int) (long) json[nameof (id)];
      List<UnitTicketUnit_choices> ticketUnitChoicesList = new List<UnitTicketUnit_choices>();
      foreach (object json1 in (List<object>) json[nameof (unit_choices)])
        ticketUnitChoicesList.Add(json1 != null ? new UnitTicketUnit_choices((Dictionary<string, object>) json1) : (UnitTicketUnit_choices) null);
      this.unit_choices = ticketUnitChoicesList.ToArray();
    }
  }
}
