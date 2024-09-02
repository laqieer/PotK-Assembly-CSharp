// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitTransmigrationPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitTransmigrationPattern
  {
    public int ID;
    public int rarity_name_UnitRarity;
    public int price;

    public static UnitTransmigrationPattern Parse(MasterDataReader reader)
    {
      return new UnitTransmigrationPattern()
      {
        ID = reader.ReadInt(),
        rarity_name_UnitRarity = reader.ReadInt(),
        price = reader.ReadInt()
      };
    }

    public UnitRarity rarity_name
    {
      get
      {
        UnitRarity rarityName;
        if (!MasterData.UnitRarity.TryGetValue(this.rarity_name_UnitRarity, out rarityName))
          Debug.LogError((object) ("Key not Found: MasterData.UnitRarity[" + (object) this.rarity_name_UnitRarity + "]"));
        return rarityName;
      }
    }
  }
}
