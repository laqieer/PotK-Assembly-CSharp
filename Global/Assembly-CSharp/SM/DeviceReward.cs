// Decompiled with JetBrains decompiler
// Type: SM.DeviceReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class DeviceReward : KeyCompare
  {
    public int reward_quantity;
    public string display_message;
    public string display_title;
    public int reward_type_id;
    public int? reward_id;

    public DeviceReward()
    {
    }

    public DeviceReward(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
      this.display_message = json[nameof (display_message)] != null ? (string) json[nameof (display_message)] : (string) null;
      this.display_title = json[nameof (display_title)] != null ? (string) json[nameof (display_title)] : (string) null;
      this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
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
    }
  }
}
