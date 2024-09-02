// Decompiled with JetBrains decompiler
// Type: SM.PlayerEnemyHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
