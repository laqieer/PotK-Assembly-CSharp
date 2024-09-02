// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildRaidGuildDamageRankingRewardExtra
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildRaidGuildDamageRankingRewardExtra
  {
    public int ID;
    public int? period_GuildRaidPeriod;
    public int condition_id_GuildRaidRankingRewardCondition;
    public int reward_type_CommonGuildRewardType;
    public int? reward_id;
    public int reward_quantity;

    public static GuildRaidGuildDamageRankingRewardExtra Parse(
      MasterDataReader reader)
    {
      return new GuildRaidGuildDamageRankingRewardExtra()
      {
        ID = reader.ReadInt(),
        period_GuildRaidPeriod = reader.ReadIntOrNull(),
        condition_id_GuildRaidRankingRewardCondition = reader.ReadInt(),
        reward_type_CommonGuildRewardType = reader.ReadInt(),
        reward_id = reader.ReadIntOrNull(),
        reward_quantity = reader.ReadInt()
      };
    }

    public GuildRaidPeriod period
    {
      get
      {
        if (!this.period_GuildRaidPeriod.HasValue)
          return (GuildRaidPeriod) null;
        GuildRaidPeriod guildRaidPeriod;
        if (!MasterData.GuildRaidPeriod.TryGetValue(this.period_GuildRaidPeriod.Value, out guildRaidPeriod))
          Debug.LogError((object) ("Key not Found: MasterData.GuildRaidPeriod[" + (object) this.period_GuildRaidPeriod.Value + "]"));
        return guildRaidPeriod;
      }
    }

    public GuildRaidRankingRewardCondition condition_id
    {
      get
      {
        GuildRaidRankingRewardCondition rankingRewardCondition;
        if (!MasterData.GuildRaidRankingRewardCondition.TryGetValue(this.condition_id_GuildRaidRankingRewardCondition, out rankingRewardCondition))
          Debug.LogError((object) ("Key not Found: MasterData.GuildRaidRankingRewardCondition[" + (object) this.condition_id_GuildRaidRankingRewardCondition + "]"));
        return rankingRewardCondition;
      }
    }

    public CommonGuildRewardType reward_type => (CommonGuildRewardType) this.reward_type_CommonGuildRewardType;
  }
}
