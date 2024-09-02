// Decompiled with JetBrains decompiler
// Type: SM.PlayerClear_daily_mission_ids
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerClear_daily_mission_ids : KeyCompare
  {
    public string date;
    public int?[] mission_ids;

    public PlayerClear_daily_mission_ids()
    {
    }

    public PlayerClear_daily_mission_ids(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.date = (string) json[nameof (date)];
      this.mission_ids = ((IEnumerable<object>) json[nameof (mission_ids)]).Select<object, int?>((Func<object, int?>) (s =>
      {
        long? nullable = (long?) s;
        return nullable.HasValue ? new int?((int) nullable.Value) : new int?();
      })).ToArray<int?>();
    }
  }
}
