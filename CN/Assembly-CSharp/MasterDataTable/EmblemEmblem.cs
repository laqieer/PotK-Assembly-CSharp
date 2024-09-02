// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EmblemEmblem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class EmblemEmblem
  {
    public int ID;
    public string name;
    public string description;
    public int rarity_EmblemRarity;

    public static EmblemEmblem Parse(MasterDataReader reader)
    {
      return new EmblemEmblem()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        description = reader.ReadString(true),
        rarity_EmblemRarity = reader.ReadInt()
      };
    }

    public EmblemRarity rarity
    {
      get
      {
        EmblemRarity rarity;
        if (!MasterData.EmblemRarity.TryGetValue(this.rarity_EmblemRarity, out rarity))
          Debug.LogError((object) ("Key not Found: MasterData.EmblemRarity[" + (object) this.rarity_EmblemRarity + "]"));
        return rarity;
      }
    }
  }
}
