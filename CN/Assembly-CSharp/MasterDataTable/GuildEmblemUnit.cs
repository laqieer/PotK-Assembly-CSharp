// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildEmblemUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GuildEmblemUnit
  {
    public int ID;
    public string name;
    public string description;
    public int rarity_GuildEmblemRarity;

    public static GuildEmblemUnit Parse(MasterDataReader reader)
    {
      return new GuildEmblemUnit()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        description = reader.ReadString(true),
        rarity_GuildEmblemRarity = reader.ReadInt()
      };
    }

    public GuildEmblemRarity rarity
    {
      get
      {
        GuildEmblemRarity rarity;
        if (!MasterData.GuildEmblemRarity.TryGetValue(this.rarity_GuildEmblemRarity, out rarity))
          Debug.LogError((object) ("Key not Found: MasterData.GuildEmblemRarity[" + (object) this.rarity_GuildEmblemRarity + "]"));
        return rarity;
      }
    }
  }
}
