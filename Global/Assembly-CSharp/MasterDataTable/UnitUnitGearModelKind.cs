// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitUnitGearModelKind
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitUnitGearModelKind
  {
    public int ID;
    public int unit_UnitUnit;
    public int gear_model_kind_GearModelKind;
    public string duel_animator_controller_name;
    public string winning_animator_controller_name;
    public int is_left_hand_weapon;

    public static UnitUnitGearModelKind Parse(MasterDataReader reader)
    {
      return new UnitUnitGearModelKind()
      {
        ID = reader.ReadInt(),
        unit_UnitUnit = reader.ReadInt(),
        gear_model_kind_GearModelKind = reader.ReadInt(),
        duel_animator_controller_name = reader.ReadString(true),
        winning_animator_controller_name = reader.ReadString(true),
        is_left_hand_weapon = reader.ReadInt()
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

    public GearModelKind gear_model_kind
    {
      get
      {
        GearModelKind gearModelKind;
        if (!MasterData.GearModelKind.TryGetValue(this.gear_model_kind_GearModelKind, out gearModelKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearModelKind[" + (object) this.gear_model_kind_GearModelKind + "]"));
        return gearModelKind;
      }
    }
  }
}
