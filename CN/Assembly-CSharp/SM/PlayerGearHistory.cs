// Decompiled with JetBrains decompiler
// Type: SM.PlayerGearHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
