// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PvpRankingReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class PvpRankingReward
  {
    public int ID;
    public int term_id;
    public int ranking_category_PvpRankingCondition;
    public int reward_type_CommonRewardType;
    public int reward_id;
    public int reward_quantity;
    public string reward_message;

    public static PvpRankingReward Parse(MasterDataReader reader)
    {
      return new PvpRankingReward()
      {
        ID = reader.ReadInt(),
        term_id = reader.ReadInt(),
        ranking_category_PvpRankingCondition = reader.ReadInt(),
        reward_type_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_quantity = reader.ReadInt(),
        reward_message = reader.ReadString(true)
      };
    }

    public PvpRankingCondition ranking_category
    {
      get
      {
        PvpRankingCondition rankingCategory;
        if (!MasterData.PvpRankingCondition.TryGetValue(this.ranking_category_PvpRankingCondition, out rankingCategory))
          Debug.LogError((object) ("Key not Found: MasterData.PvpRankingCondition[" + (object) this.ranking_category_PvpRankingCondition + "]"));
        return rankingCategory;
      }
    }

    public CommonRewardType reward_type => (CommonRewardType) this.reward_type_CommonRewardType;
  }
}
