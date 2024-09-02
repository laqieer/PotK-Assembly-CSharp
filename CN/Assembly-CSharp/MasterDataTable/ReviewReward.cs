﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ReviewReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ReviewReward
  {
    public int ID;
    public int quest_type_CommonQuestType;
    public int quest_s_id;
    public int reward_type_CommonRewardType;
    public int reward_id;
    public int reward_quantity;
    public string title;
    public string message;

    public static ReviewReward Parse(MasterDataReader reader)
    {
      return new ReviewReward()
      {
        ID = reader.ReadInt(),
        quest_type_CommonQuestType = reader.ReadInt(),
        quest_s_id = reader.ReadInt(),
        reward_type_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_quantity = reader.ReadInt(),
        title = reader.ReadString(true),
        message = reader.ReadString(true)
      };
    }

    public CommonQuestType quest_type => (CommonQuestType) this.quest_type_CommonQuestType;

    public CommonRewardType reward_type => (CommonRewardType) this.reward_type_CommonRewardType;
  }
}
