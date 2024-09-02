// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitTypeSettings
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitTypeSettings
  {
    public int ID;
    public int? unit_UnitUnit;
    public int attack_type_GearAttackType;

    public static UnitTypeSettings Parse(MasterDataReader reader) => new UnitTypeSettings()
    {
      ID = reader.ReadInt(),
      unit_UnitUnit = reader.ReadIntOrNull(),
      attack_type_GearAttackType = reader.ReadInt()
    };

    public UnitUnit unit
    {
      get
      {
        if (!this.unit_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.unit_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unit_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }

    public GearAttackType attack_type => (GearAttackType) this.attack_type_GearAttackType;
  }
}
