// Decompiled with JetBrains decompiler
// Type: SM.PlayerGearHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerGearHistory : KeyCompare
  {
    public DateTime created_at;
    public int gear_id;

    public PlayerGearHistory()
    {
    }

    public PlayerGearHistory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.created_at = DateTime.Parse((string) json[nameof (created_at)]);
      this.gear_id = (int) (long) json[nameof (gear_id)];
    }
  }
}
