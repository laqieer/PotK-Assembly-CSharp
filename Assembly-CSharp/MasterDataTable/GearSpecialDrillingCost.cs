// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearSpecialDrillingCost
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearSpecialDrillingCost
  {
    public int ID;
    public int? rarity_GearRarity;
    public int level;
    public int price;

    public static GearSpecialDrillingCost Parse(MasterDataReader reader) => new GearSpecialDrillingCost()
    {
      ID = reader.ReadInt(),
      rarity_GearRarity = reader.ReadIntOrNull(),
      level = reader.ReadInt(),
      price = reader.ReadInt()
    };

    public GearRarity rarity
    {
      get
      {
        if (!this.rarity_GearRarity.HasValue)
          return (GearRarity) null;
        GearRarity gearRarity;
        if (!MasterData.GearRarity.TryGetValue(this.rarity_GearRarity.Value, out gearRarity))
          Debug.LogError((object) ("Key not Found: MasterData.GearRarity[" + (object) this.rarity_GearRarity.Value + "]"));
        return gearRarity;
      }
    }
  }
}
