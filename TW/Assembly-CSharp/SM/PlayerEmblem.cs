// Decompiled with JetBrains decompiler
// Type: SM.PlayerEmblem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerEmblem : KeyCompare
  {
    public DateTime created_at;
    public int emblem_id;
    public bool is_new;

    public PlayerEmblem()
    {
    }

    public PlayerEmblem(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.created_at = DateTime.Parse((string) json[nameof (created_at)]);
      this.emblem_id = (int) (long) json[nameof (emblem_id)];
      this.is_new = (bool) json[nameof (is_new)];
    }
  }
}
