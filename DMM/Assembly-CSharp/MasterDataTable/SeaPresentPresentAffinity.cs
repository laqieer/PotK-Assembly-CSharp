// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SeaPresentPresentAffinity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

namespace MasterDataTable
{
  [Serializable]
  public class SeaPresentPresentAffinity
  {
    public int ID;
    public int? same_character_id_UnitUnit;
    public int? character_id;
    public int gear_id;
    public int affinity_SeaPresentAffinity;

    public static SeaPresentPresentAffinity Parse(MasterDataReader reader) => new SeaPresentPresentAffinity()
    {
      ID = reader.ReadInt(),
      same_character_id_UnitUnit = reader.ReadIntOrNull(),
      character_id = reader.ReadIntOrNull(),
      gear_id = reader.ReadInt(),
      affinity_SeaPresentAffinity = reader.ReadInt()
    };

    public UnitUnit same_character_id
    {
      get
      {
        if (!this.same_character_id_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.same_character_id_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.same_character_id_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }

    public SeaPresentAffinity affinity
    {
      get
      {
        SeaPresentAffinity seaPresentAffinity;
        if (!MasterData.SeaPresentAffinity.TryGetValue(this.affinity_SeaPresentAffinity, out seaPresentAffinity))
          Debug.LogError((object) ("Key not Found: MasterData.SeaPresentAffinity[" + (object) this.affinity_SeaPresentAffinity + "]"));
        return seaPresentAffinity;
      }
    }

    public static SeaPresentPresentAffinity GetSeaPresentPresentAffnity(
      UnitUnit unit,
      int gearID)
    {
      return ((IEnumerable<SeaPresentPresentAffinity>) MasterData.SeaPresentPresentAffinityList).FirstOrDefault<SeaPresentPresentAffinity>((Func<SeaPresentPresentAffinity, bool>) (x => x.same_character_id_UnitUnit.HasValue && x.same_character_id_UnitUnit.Value == unit.same_character_id && x.gear_id == gearID)) ?? ((IEnumerable<SeaPresentPresentAffinity>) MasterData.SeaPresentPresentAffinityList).FirstOrDefault<SeaPresentPresentAffinity>((Func<SeaPresentPresentAffinity, bool>) (x => x.character_id.HasValue && x.character_id.Value == unit.character.ID && x.gear_id == gearID));
    }
  }
}
