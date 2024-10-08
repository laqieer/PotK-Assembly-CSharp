﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CorpsStageClearReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class CorpsStageClearReward
  {
    public int ID;
    public int stage_id;
    public int entity_type_CommonRewardType;
    public int reward_id;
    public string reward_name;
    public int is_direct;
    public string reward_message;

    public static CorpsStageClearReward Parse(MasterDataReader reader) => new CorpsStageClearReward()
    {
      ID = reader.ReadInt(),
      stage_id = reader.ReadInt(),
      entity_type_CommonRewardType = reader.ReadInt(),
      reward_id = reader.ReadInt(),
      reward_name = reader.ReadStringOrNull(true),
      is_direct = reader.ReadInt(),
      reward_message = reader.ReadStringOrNull(true)
    };

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
