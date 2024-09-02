// Decompiled with JetBrains decompiler
// Type: SM.GachaModuleGacha
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaModuleGacha : KeyCompare
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
    public GachaDescription details;
    public int? remain_count_for_reward;
    public int? daily_limit;
    public int payment_type_id;
    public string button_url;
    public int id;
    public int? max_roll_count;
    public string name;

    public GachaModuleGacha()
    {
    }

    public GachaModuleGacha(Dictionary<string, object> json)
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
      this.details = json[nameof (details)] != null ? new GachaDescription((Dictionary<string, object>) json[nameof (details)]) : (GachaDescription) null;
      int? nullable5;
      if (json[nameof (remain_count_for_reward)] == null)
      {
        nullable5 = new int?();
      }
      else
      {
        long? nullable6 = (long?) json[nameof (remain_count_for_reward)];
        nullable5 = !nullable6.HasValue ? new int?() : new int?((int) nullable6.Value);
      }
      this.remain_count_for_reward = nullable5;
      int? nullable7;
      if (json[nameof (daily_limit)] == null)
      {
        nullable7 = new int?();
      }
      else
      {
        long? nullable8 = (long?) json[nameof (daily_limit)];
        nullable7 = !nullable8.HasValue ? new int?() : new int?((int) nullable8.Value);
      }
      this.daily_limit = nullable7;
      this.payment_type_id = (int) (long) json[nameof (payment_type_id)];
      this.button_url = json[nameof (button_url)] != null ? (string) json[nameof (button_url)] : (string) null;
      this.id = (int) (long) json[nameof (id)];
      int? nullable9;
      if (json[nameof (max_roll_count)] == null)
      {
        nullable9 = new int?();
      }
      else
      {
        long? nullable10 = (long?) json[nameof (max_roll_count)];
        nullable9 = !nullable10.HasValue ? new int?() : new int?((int) nullable10.Value);
      }
      this.max_roll_count = nullable9;
      this.name = (string) json[nameof (name)];
    }
  }
}
