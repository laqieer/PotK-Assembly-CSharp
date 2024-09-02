// Decompiled with JetBrains decompiler
// Type: SM.PlayerEnemyHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerEnemyHistory : KeyCompare
  {
    public DateTime created_at;
    public int unit_id;
    public int defeat;

    public PlayerEnemyHistory()
    {
    }

    public PlayerEnemyHistory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.created_at = DateTime.Parse((string) json[nameof (created_at)]);
      this.unit_id = (int) (long) json[nameof (unit_id)];
      this.defeat = (int) (long) json[nameof (defeat)];
    }
  }
}
