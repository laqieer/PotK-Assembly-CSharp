// Decompiled with JetBrains decompiler
// Type: SM.UnitTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class UnitTicket : KeyCompare
  {
    public DateTime start_at;
    public string name;
    public string detail;
    public DateTime end_at;
    public bool unit_type_selectable;
    public int cost;
    public UnitTicketUnit_choices[] unit_choices;
    public int id;
    public string description;

    public UnitTicket()
    {
    }

    public UnitTicket(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.start_at = DateTime.Parse((string) json[nameof (start_at)]);
      this.name = (string) json[nameof (name)];
      this.detail = (string) json[nameof (detail)];
      this.end_at = DateTime.Parse((string) json[nameof (end_at)]);
      this.unit_type_selectable = (bool) json[nameof (unit_type_selectable)];
      this.cost = (int) (long) json[nameof (cost)];
      List<UnitTicketUnit_choices> ticketUnitChoicesList = new List<UnitTicketUnit_choices>();
      foreach (object json1 in (List<object>) json[nameof (unit_choices)])
        ticketUnitChoicesList.Add(json1 != null ? new UnitTicketUnit_choices((Dictionary<string, object>) json1) : (UnitTicketUnit_choices) null);
      this.unit_choices = ticketUnitChoicesList.ToArray();
      this.id = (int) (long) json[nameof (id)];
      this.description = (string) json[nameof (description)];
    }
  }
}
