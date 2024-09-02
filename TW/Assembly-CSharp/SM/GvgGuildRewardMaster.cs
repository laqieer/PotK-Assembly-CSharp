// Decompiled with JetBrains decompiler
// Type: SM.GvgGuildRewardMaster
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class GvgGuildRewardMaster : KeyCompare
  {
    public int reward_quantity;
    public int _reward_type;
    public int reward_id;

    public GvgGuildRewardMaster()
    {
    }

    public GvgGuildRewardMaster(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
      this._reward_type = (int) (long) json[nameof (reward_type)];
      this.reward_id = (int) (long) json[nameof (reward_id)];
    }

    public CommonGuildRewardType reward_type
    {
      get
      {
        if (!Enum.IsDefined(typeof (CommonGuildRewardType), (object) this._reward_type))
          Debug.LogError((object) ("Key not Found: MasterDataTable.CommonGuildRewardType[" + (object) this._reward_type + "]"));
        return (CommonGuildRewardType) this._reward_type;
      }
    }
  }
}
