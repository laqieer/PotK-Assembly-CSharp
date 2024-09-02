// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitTransmigrationPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitTransmigrationPattern
  {
    public int ID;
    public int rarity_name_UnitRarity;
    public int price;

    public static UnitTransmigrationPattern Parse(MasterDataReader reader) => new UnitTransmigrationPattern()
    {
      ID = reader.ReadInt(),
      rarity_name_UnitRarity = reader.ReadInt(),
      price = reader.ReadInt()
    };

    public UnitRarity rarity_name
    {
      get
      {
        UnitRarity unitRarity;
        if (!MasterData.UnitRarity.TryGetValue(this.rarity_name_UnitRarity, out unitRarity))
          Debug.LogError((object) ("Key not Found: MasterData.UnitRarity[" + (object) this.rarity_name_UnitRarity + "]"));
        return unitRarity;
      }
    }
  }
}
