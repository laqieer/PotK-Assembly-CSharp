﻿// Decompiled with JetBrains decompiler
// Type: SM.GvgGuildRewardMaster
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class GvgGuildRewardMaster : KeyCompare
  {
    public int reward_quantity;
    public int _reward_type;
    public int reward_id;

    public CommonGuildRewardType reward_type
    {
      get
      {
        if (!Enum.IsDefined(typeof (CommonGuildRewardType), (object) this._reward_type))
          Debug.LogError((object) ("Key not Found: MasterDataTable.CommonGuildRewardType[" + (object) this._reward_type + "]"));
        return (CommonGuildRewardType) this._reward_type;
      }
    }

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
  }
}
