// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitTransmigrationMaterial
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitTransmigrationMaterial
  {
    public int ID;
    public int pattern_UnitTransmigrationPattern;
    public int material_UnitUnit;

    public static UnitTransmigrationMaterial Parse(MasterDataReader reader) => new UnitTransmigrationMaterial()
    {
      ID = reader.ReadInt(),
      pattern_UnitTransmigrationPattern = reader.ReadInt(),
      material_UnitUnit = reader.ReadInt()
    };

    public UnitTransmigrationPattern pattern
    {
      get
      {
        UnitTransmigrationPattern transmigrationPattern;
        if (!MasterData.UnitTransmigrationPattern.TryGetValue(this.pattern_UnitTransmigrationPattern, out transmigrationPattern))
          Debug.LogError((object) ("Key not Found: MasterData.UnitTransmigrationPattern[" + (object) this.pattern_UnitTransmigrationPattern + "]"));
        return transmigrationPattern;
      }
    }

    public UnitUnit material
    {
      get
      {
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.material_UnitUnit, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.material_UnitUnit + "]"));
        return unitUnit;
      }
    }
  }
}
