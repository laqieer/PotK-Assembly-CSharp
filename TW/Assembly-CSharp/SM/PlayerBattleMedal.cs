// Decompiled with JetBrains decompiler
// Type: SM.PlayerBattleMedal
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerBattleMedal : KeyCompare
  {
    public int count;
    public DateTime? end_at;

    public PlayerBattleMedal()
    {
    }

    public PlayerBattleMedal(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.count = (int) (long) json[nameof (count)];
      this.end_at = json[nameof (end_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (end_at)])) : new DateTime?();
    }
  }
}
