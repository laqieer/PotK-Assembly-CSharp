// Decompiled with JetBrains decompiler
// Type: SM.GvgWholeRewardMaster
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
  public class GvgWholeRewardMaster : KeyCompare
  {
    public int reward_quantity;
    public string reward_message;
    public int _reward_type;
    public string reward_title;
    public int reward_id;

    public GvgWholeRewardMaster()
    {
    }

    public GvgWholeRewardMaster(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
      this.reward_message = (string) json[nameof (reward_message)];
      this._reward_type = (int) (long) json[nameof (reward_type)];
      this.reward_title = (string) json[nameof (reward_title)];
      this.reward_id = (int) (long) json[nameof (reward_id)];
    }

    public CommonRewardType reward_type
    {
      get
      {
        if (!Enum.IsDefined(typeof (CommonRewardType), (object) this._reward_type))
          Debug.LogError((object) ("Key not Found: MasterDataTable.CommonRewardType[" + (object) this._reward_type + "]"));
        return (CommonRewardType) this._reward_type;
      }
    }
  }
}
