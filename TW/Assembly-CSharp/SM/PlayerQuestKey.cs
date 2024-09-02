// Decompiled with JetBrains decompiler
// Type: SM.PlayerQuestKey
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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

    public static PlayerQuestKey CreateForKey(int id)
    {
      PlayerQuestKey forKey = new PlayerQuestKey();
      forKey._hasKey = true;
      forKey._key = (object) (forKey.quest_key_id = id);
      return forKey;
    }
  }
}
