// Decompiled with JetBrains decompiler
// Type: SM.SlotModuleSlot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class SlotModuleSlot : KeyCompare
  {
    public int count;
    public int? payment_id;
    public int deck_id;
    public DateTime? start_at;
    public string description;
    public int roll_count;
    public DateTime? end_at;
    public int daily_count;
    public int payment_amount;
    public int? limit;
    public int? daily_limit;
    public int payment_type_id;
    public int id;
    public string name;

    public SlotModuleSlot()
    {
    }

    public SlotModuleSlot(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.count = (int) (long) json[nameof (count)];
      int? nullable1;
      if (json[nameof (payment_id)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (payment_id)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.payment_id = nullable1;
      this.deck_id = (int) (long) json[nameof (deck_id)];
      this.start_at = json[nameof (start_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (start_at)])) : new DateTime?();
      this.description = (string) json[nameof (description)];
      this.roll_count = (int) (long) json[nameof (roll_count)];
      this.end_at = json[nameof (end_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (end_at)])) : new DateTime?();
      this.daily_count = (int) (long) json[nameof (daily_count)];
      this.payment_amount = (int) (long) json[nameof (payment_amount)];
      int? nullable3;
      if (json[nameof (limit)] == null)
      {
        nullable3 = new int?();
      }
      else
      {
        long? nullable4 = (long?) json[nameof (limit)];
        nullable3 = !nullable4.HasValue ? new int?() : new int?((int) nullable4.Value);
      }
      this.limit = nullable3;
      int? nullable5;
      if (json[nameof (daily_limit)] == null)
      {
        nullable5 = new int?();
      }
      else
      {
        long? nullable6 = (long?) json[nameof (daily_limit)];
        nullable5 = !nullable6.HasValue ? new int?() : new int?((int) nullable6.Value);
      }
      this.daily_limit = nullable5;
      this.payment_type_id = (int) (long) json[nameof (payment_type_id)];
      this.id = (int) (long) json[nameof (id)];
      this.name = (string) json[nameof (name)];
    }
  }
}
