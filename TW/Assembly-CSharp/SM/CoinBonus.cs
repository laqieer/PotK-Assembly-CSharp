// Decompiled with JetBrains decompiler
// Type: SM.CoinBonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class CoinBonus : KeyCompare
  {
    public bool is_login_bonus;
    public int purchase_limit;
    public DateTime? start_at;
    public int id;
    public DateTime? end_at;

    public CoinBonus()
    {
    }

    public CoinBonus(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.is_login_bonus = (bool) json[nameof (is_login_bonus)];
      this.purchase_limit = (int) (long) json[nameof (purchase_limit)];
      this.start_at = json[nameof (start_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (start_at)])) : new DateTime?();
      this.id = (int) (long) json[nameof (id)];
      this.end_at = json[nameof (end_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (end_at)])) : new DateTime?();
    }
  }
}
