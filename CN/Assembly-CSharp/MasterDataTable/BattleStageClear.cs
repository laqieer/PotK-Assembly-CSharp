﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStageClear
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleStageClear
  {
    public int ID;
    public int reward_group_id;
    public int only_first;
    public int entity_type_CommonRewardType;
    public int reward_id;
    public string reward_message;

    public static BattleStageClear Parse(MasterDataReader reader)
    {
      return new BattleStageClear()
      {
        ID = reader.ReadInt(),
        reward_group_id = reader.ReadInt(),
        only_first = reader.ReadInt(),
        entity_type_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_message = reader.ReadString(true)
      };
    }

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
