// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildRaidKillRewardSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildRaidKillRewardSet
  {
    public int ID;
    public string kill_reward_id;

    public static GuildRaidKillRewardSet Parse(MasterDataReader reader) => new GuildRaidKillRewardSet()
    {
      ID = reader.ReadInt(),
      kill_reward_id = reader.ReadString(true)
    };
  }
}
