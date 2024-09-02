// Decompiled with JetBrains decompiler
// Type: MasterDataTable.Bingo2CompleteRewardEntity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class Bingo2CompleteRewardEntity
  {
    public int ID;
    public int reward_group_id_Bingo2CompleteRewardGroup;
    public int reward_type_id_CommonRewardType;
    public int? reward_id;
    public int? reward_quantity;

    public static Bingo2CompleteRewardEntity Parse(MasterDataReader reader)
    {
      return new Bingo2CompleteRewardEntity()
      {
        ID = reader.ReadInt(),
        reward_group_id_Bingo2CompleteRewardGroup = reader.ReadInt(),
        reward_type_id_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadIntOrNull(),
        reward_quantity = reader.ReadIntOrNull()
      };
    }

    public Bingo2CompleteRewardGroup reward_group_id
    {
      get
      {
        Bingo2CompleteRewardGroup rewardGroupId;
        if (!MasterData.Bingo2CompleteRewardGroup.TryGetValue(this.reward_group_id_Bingo2CompleteRewardGroup, out rewardGroupId))
          Debug.LogError((object) ("Key not Found: MasterData.Bingo2CompleteRewardGroup[" + (object) this.reward_group_id_Bingo2CompleteRewardGroup + "]"));
        return rewardGroupId;
      }
    }

    public CommonRewardType reward_type_id
    {
      get => (CommonRewardType) this.reward_type_id_CommonRewardType;
    }
  }
}
