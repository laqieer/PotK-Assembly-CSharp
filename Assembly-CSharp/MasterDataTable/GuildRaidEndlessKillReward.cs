// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildRaidEndlessKillReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildRaidEndlessKillReward
  {
    public int ID;
    public int raid;
    public int entity_type_CommonRewardType;
    public int rewardID;
    public string reward_title;
    public int num;

    public static GuildRaidEndlessKillReward Parse(MasterDataReader reader) => new GuildRaidEndlessKillReward()
    {
      ID = reader.ReadInt(),
      raid = reader.ReadInt(),
      entity_type_CommonRewardType = reader.ReadInt(),
      rewardID = reader.ReadInt(),
      reward_title = reader.ReadString(true),
      num = reader.ReadInt()
    };

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
