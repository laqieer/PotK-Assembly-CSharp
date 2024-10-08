﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildRaidDamageReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildRaidDamageReward
  {
    public int ID;
    public int entity_type_CommonRewardType;
    public int reward_id;
    public int reward_value;
    public string reward_title;

    public static GuildRaidDamageReward Parse(MasterDataReader reader) => new GuildRaidDamageReward()
    {
      ID = reader.ReadInt(),
      entity_type_CommonRewardType = reader.ReadInt(),
      reward_id = reader.ReadInt(),
      reward_value = reader.ReadInt(),
      reward_title = reader.ReadString(true)
    };

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
