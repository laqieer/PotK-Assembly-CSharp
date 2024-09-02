// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitUnitSupplement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitUnitSupplement
  {
    public int ID;
    public int default_weapon_proficiency_UnitProficiency;
    public int default_shield_proficiency_UnitProficiency;

    public static UnitUnitSupplement Parse(MasterDataReader reader) => new UnitUnitSupplement()
    {
      ID = reader.ReadInt(),
      default_weapon_proficiency_UnitProficiency = reader.ReadInt(),
      default_shield_proficiency_UnitProficiency = reader.ReadInt()
    };

    public UnitProficiency default_weapon_proficiency
    {
      get
      {
        UnitProficiency unitProficiency;
        if (!MasterData.UnitProficiency.TryGetValue(this.default_weapon_proficiency_UnitProficiency, out unitProficiency))
          Debug.LogError((object) ("Key not Found: MasterData.UnitProficiency[" + (object) this.default_weapon_proficiency_UnitProficiency + "]"));
        return unitProficiency;
      }
    }

    public UnitProficiency default_shield_proficiency
    {
      get
      {
        UnitProficiency unitProficiency;
        if (!MasterData.UnitProficiency.TryGetValue(this.default_shield_proficiency_UnitProficiency, out unitProficiency))
          Debug.LogError((object) ("Key not Found: MasterData.UnitProficiency[" + (object) this.default_shield_proficiency_UnitProficiency + "]"));
        return unitProficiency;
      }
    }
  }
}
