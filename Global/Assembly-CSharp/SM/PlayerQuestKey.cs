// Decompiled with JetBrains decompiler
// Type: SM.PlayerQuestKey
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerQuestKey : KeyCompare
  {
    public string player_id;
    public int max_quantity;
    public int quest_key_id;
    public int quantity;

    public PlayerQuestKey()
    {
    }

    public PlayerQuestKey(Dictionary<string, object> json)
    {
      this._hasKey = true;
      this.player_id = (string) json[nameof (player_id)];
      this.max_quantity = (int) (long) json[nameof (max_quantity)];
      this._key = (object) (this.quest_key_id = (int) (long) json[nameof (quest_key_id)]);
      this.quantity = (int) (long) json[nameof (quantity)];
    }
  }
}
