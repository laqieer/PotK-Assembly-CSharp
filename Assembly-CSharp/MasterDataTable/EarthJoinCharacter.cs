// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthJoinCharacter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class EarthJoinCharacter
  {
    public int ID;
    public int join_logic_EarthJoinLogicType;
    public string join_logic_arg;
    public int charctor_UnitCharacter;
    public int unit_UnitUnit;
    public int? gear_GearGear;
    public int experience;
    public int initial_add_hp;
    public int initial_add_strength;
    public int initial_add_intelligence;
    public int initial_add_vitality;
    public int initial_add_mind;
    public int initial_add_agility;
    public int initial_add_dexterity;
    public int initial_add_lucky;

    public static EarthJoinCharacter Parse(MasterDataReader reader) => new EarthJoinCharacter()
    {
      ID = reader.ReadInt(),
      join_logic_EarthJoinLogicType = reader.ReadInt(),
      join_logic_arg = reader.ReadStringOrNull(true),
      charctor_UnitCharacter = reader.ReadInt(),
      unit_UnitUnit = reader.ReadInt(),
      gear_GearGear = reader.ReadIntOrNull(),
      experience = reader.ReadInt(),
      initial_add_hp = reader.ReadInt(),
      initial_add_strength = reader.ReadInt(),
      initial_add_intelligence = reader.ReadInt(),
      initial_add_vitality = reader.ReadInt(),
      initial_add_mind = reader.ReadInt(),
      initial_add_agility = reader.ReadInt(),
      initial_add_dexterity = reader.ReadInt(),
      initial_add_lucky = reader.ReadInt()
    };

    public EarthJoinLogicType join_logic => (EarthJoinLogicType) this.join_logic_EarthJoinLogicType;

    public UnitCharacter charctor
    {
      get
      {
        UnitCharacter unitCharacter;
        if (!MasterData.UnitCharacter.TryGetValue(this.charctor_UnitCharacter, out unitCharacter))
          Debug.LogError((object) ("Key not Found: MasterData.UnitCharacter[" + (object) this.charctor_UnitCharacter + "]"));
        return unitCharacter;
      }
    }

    public UnitUnit unit
    {
      get
      {
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.unit_UnitUnit, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unit_UnitUnit + "]"));
        return unitUnit;
      }
    }

    public GearGear gear
    {
      get
      {
        if (!this.gear_GearGear.HasValue)
          return (GearGear) null;
        GearGear gearGear;
        if (!MasterData.GearGear.TryGetValue(this.gear_GearGear.Value, out gearGear))
          Debug.LogError((object) ("Key not Found: MasterData.GearGear[" + (object) this.gear_GearGear.Value + "]"));
        return gearGear;
      }
    }
  }
}
