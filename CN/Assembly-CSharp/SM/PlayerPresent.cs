// Decompiled with JetBrains decompiler
// Type: SM.PlayerPresent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerPresent : KeyCompare
  {
    public int? reward_quantity;
    public int? reward_type_id;
    public string title;
    public DateTime created_at;
    public DateTime? received_at;
    public string message;
    public int id;
    public int? reward_id;
    public bool? isReceivable;

    public PlayerPresent()
    {
    }

    public PlayerPresent(Dictionary<string, object> json)
    {
      this._hasKey = true;
      int? nullable1;
      if (json[nameof (reward_quantity)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (reward_quantity)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.reward_quantity = nullable1;
      int? nullable3;
      if (json[nameof (reward_type_id)] == null)
      {
        nullable3 = new int?();
      }
      else
      {
        long? nullable4 = (long?) json[nameof (reward_type_id)];
        nullable3 = !nullable4.HasValue ? new int?() : new int?((int) nullable4.Value);
      }
      this.reward_type_id = nullable3;
      this.title = (string) json[nameof (title)];
      this.created_at = DateTime.Parse((string) json[nameof (created_at)]);
      this.received_at = json[nameof (received_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (received_at)])) : new DateTime?();
      this.message = (string) json[nameof (message)];
      this._key = (object) (this.id = (int) (long) json[nameof (id)]);
      int? nullable5;
      if (json[nameof (reward_id)] == null)
      {
        nullable5 = new int?();
      }
      else
      {
        long? nullable6 = (long?) json[nameof (reward_id)];
        nullable5 = !nullable6.HasValue ? new int?() : new int?((int) nullable6.Value);
      }
      this.reward_id = nullable5;
    }
  }
}
