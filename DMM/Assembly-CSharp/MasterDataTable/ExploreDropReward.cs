﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ExploreDropReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class ExploreDropReward
  {
    public int ID;
    public int reward_type_CommonRewardType;
    public int reward_id;
    public int reward_quantity;
    public string reward_title;
    public string reward_message;

    public static ExploreDropReward Parse(MasterDataReader reader) => new ExploreDropReward()
    {
      ID = reader.ReadInt(),
      reward_type_CommonRewardType = reader.ReadInt(),
      reward_id = reader.ReadInt(),
      reward_quantity = reader.ReadInt(),
      reward_title = reader.ReadString(true),
      reward_message = reader.ReadString(true)
    };

    public CommonRewardType reward_type => (CommonRewardType) this.reward_type_CommonRewardType;
  }
}
