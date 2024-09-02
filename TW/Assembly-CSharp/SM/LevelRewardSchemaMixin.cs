// Decompiled with JetBrains decompiler
// Type: SM.LevelRewardSchemaMixin
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class LevelRewardSchemaMixin : KeyCompare
  {
    public int reward_quantity;
    public string reward_message;
    public string reward_title;
    public int? reward_id;
    public int reward_type_id;

    public LevelRewardSchemaMixin()
    {
    }

    public LevelRewardSchemaMixin(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
      this.reward_message = json[nameof (reward_message)] != null ? (string) json[nameof (reward_message)] : (string) null;
      this.reward_title = json[nameof (reward_title)] != null ? (string) json[nameof (reward_title)] : (string) null;
      int? nullable1;
      if (json[nameof (reward_id)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (reward_id)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.reward_id = nullable1;
      this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
    }
  }
}
