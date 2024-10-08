﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthQuestClearReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

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
