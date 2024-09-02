// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildEmblemUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildEmblemUnit
  {
    public int ID;
    public string name;
    public string description;
    public int rarity_GuildEmblemRarity;

    public static GuildEmblemUnit Parse(MasterDataReader reader) => new GuildEmblemUnit()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      description = reader.ReadString(true),
      rarity_GuildEmblemRarity = reader.ReadInt()
    };

    public GuildEmblemRarity rarity
    {
      get
      {
        GuildEmblemRarity guildEmblemRarity;
        if (!MasterData.GuildEmblemRarity.TryGetValue(this.rarity_GuildEmblemRarity, out guildEmblemRarity))
          Debug.LogError((object) ("Key not Found: MasterData.GuildEmblemRarity[" + (object) this.rarity_GuildEmblemRarity + "]"));
        return guildEmblemRarity;
      }
    }
  }
}
