// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthQuestClearReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class EarthQuestClearReward
  {
    public int ID;
    public int? episode_EarthQuestEpisode;
    public int reward_type_CommonRewardType;
    public int? reward_id;
    public int quantity;

    public static EarthQuestClearReward Parse(MasterDataReader reader)
    {
      return new EarthQuestClearReward()
      {
        ID = reader.ReadInt(),
        episode_EarthQuestEpisode = reader.ReadIntOrNull(),
        reward_type_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadIntOrNull(),
        quantity = reader.ReadInt()
      };
    }

    public EarthQuestEpisode episode
    {
      get
      {
        if (!this.episode_EarthQuestEpisode.HasValue)
          return (EarthQuestEpisode) null;
        EarthQuestEpisode episode;
        if (!MasterData.EarthQuestEpisode.TryGetValue(this.episode_EarthQuestEpisode.Value, out episode))
          Debug.LogError((object) ("Key not Found: MasterData.EarthQuestEpisode[" + (object) this.episode_EarthQuestEpisode.Value + "]"));
        return episode;
      }
    }

    public CommonRewardType reward_type => (CommonRewardType) this.reward_type_CommonRewardType;
  }
}
