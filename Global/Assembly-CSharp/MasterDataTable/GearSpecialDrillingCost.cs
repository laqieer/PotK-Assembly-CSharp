﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearSpecialDrillingCost
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearSpecialDrillingCost
  {
    public int ID;
    public int? rarity_GearRarity;
    public int level;
    public int price;

    public static GearSpecialDrillingCost Parse(MasterDataReader reader)
    {
      return new GearSpecialDrillingCost()
      {
        ID = reader.ReadInt(),
        rarity_GearRarity = reader.ReadIntOrNull(),
        level = reader.ReadInt(),
        price = reader.ReadInt()
      };
    }

    public GearRarity rarity
    {
      get
      {
        if (!this.rarity_GearRarity.HasValue)
          return (GearRarity) null;
        GearRarity rarity;
        if (!MasterData.GearRarity.TryGetValue(this.rarity_GearRarity.Value, out rarity))
          Debug.LogError((object) ("Key not Found: MasterData.GearRarity[" + (object) this.rarity_GearRarity.Value + "]"));
        return rarity;
      }
    }
  }
}
