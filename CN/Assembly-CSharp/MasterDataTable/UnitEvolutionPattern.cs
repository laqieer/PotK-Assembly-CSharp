// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitEvolutionPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitEvolutionPattern
  {
    public int ID;
    public int unit_UnitUnit;
    public int target_unit_UnitUnit;
    public int threshold_level;
    public int money;

    public static UnitEvolutionPattern Parse(MasterDataReader reader)
    {
      return new UnitEvolutionPattern()
      {
        ID = reader.ReadInt(),
        unit_UnitUnit = reader.ReadInt(),
        target_unit_UnitUnit = reader.ReadInt(),
        threshold_level = reader.ReadInt(),
        money = reader.ReadInt()
      };
    }

    public UnitUnit unit
    {
      get
      {
        UnitUnit unit;
        if (!MasterData.UnitUnit.TryGetValue(this.unit_UnitUnit, out unit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unit_UnitUnit + "]"));
        return unit;
      }
    }

    public UnitUnit target_unit
    {
      get
      {
        UnitUnit targetUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.target_unit_UnitUnit, out targetUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.target_unit_UnitUnit + "]"));
        return targetUnit;
      }
    }
  }
}
