// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitTransmigrationMaterial
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitTransmigrationMaterial
  {
    public int ID;
    public int pattern_UnitTransmigrationPattern;
    public int material_UnitUnit;

    public static UnitTransmigrationMaterial Parse(MasterDataReader reader)
    {
      return new UnitTransmigrationMaterial()
      {
        ID = reader.ReadInt(),
        pattern_UnitTransmigrationPattern = reader.ReadInt(),
        material_UnitUnit = reader.ReadInt()
      };
    }

    public UnitTransmigrationPattern pattern
    {
      get
      {
        UnitTransmigrationPattern pattern;
        if (!MasterData.UnitTransmigrationPattern.TryGetValue(this.pattern_UnitTransmigrationPattern, out pattern))
          Debug.LogError((object) ("Key not Found: MasterData.UnitTransmigrationPattern[" + (object) this.pattern_UnitTransmigrationPattern + "]"));
        return pattern;
      }
    }

    public UnitUnit material
    {
      get
      {
        UnitUnit material;
        if (!MasterData.UnitUnit.TryGetValue(this.material_UnitUnit, out material))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.material_UnitUnit + "]"));
        return material;
      }
    }
  }
}
