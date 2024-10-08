﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PunitiveExpeditionEventGuildReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class PunitiveExpeditionEventGuildReward
  {
    public int ID;
    public int period;
    public int point;
    public int reward_type_id_CommonRewardType;
    public int reward_id;
    public int reward_quantity;
    public string display_text1;
    public string display_text2;
    public string image_name;
    public int alignment;

    public static PunitiveExpeditionEventGuildReward Parse(MasterDataReader reader)
    {
      return new PunitiveExpeditionEventGuildReward()
      {
        ID = reader.ReadInt(),
        period = reader.ReadInt(),
        point = reader.ReadInt(),
        reward_type_id_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_quantity = reader.ReadInt(),
        display_text1 = reader.ReadString(true),
        display_text2 = reader.ReadString(true),
        image_name = reader.ReadString(true),
        alignment = reader.ReadInt()
      };
    }

    public CommonRewardType reward_type_id
    {
      get => (CommonRewardType) this.reward_type_id_CommonRewardType;
    }
  }
}
