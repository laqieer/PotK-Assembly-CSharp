// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthQuestClearReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

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

    public static EarthQuestClearReward Parse(MasterDataReader reader) => new EarthQuestClearReward()
    {
      ID = reader.ReadInt(),
      episode_EarthQuestEpisode = reader.ReadIntOrNull(),
      reward_type_CommonRewardType = reader.ReadInt(),
      reward_id = reader.ReadIntOrNull(),
      quantity = reader.ReadInt()
    };

    public EarthQuestEpisode episode
    {
      get
      {
        if (!this.episode_EarthQuestEpisode.HasValue)
          return (EarthQuestEpisode) null;
        EarthQuestEpisode earthQuestEpisode;
        if (!MasterData.EarthQuestEpisode.TryGetValue(this.episode_EarthQuestEpisode.Value, out earthQuestEpisode))
          Debug.LogError((object) ("Key not Found: MasterData.EarthQuestEpisode[" + (object) this.episode_EarthQuestEpisode.Value + "]"));
        return earthQuestEpisode;
      }
    }

    public CommonRewardType reward_type => (CommonRewardType) this.reward_type_CommonRewardType;
  }
}
