// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearGearSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearGearSkill
  {
    public int ID;
    public int gear_GearGear;
    public int skill_BattleskillSkill;
    public int skill_level;
    public int release_rank;
    public int skill_group;

    public bool isReleased(PlayerItem gear)
    {
      if (this.release_rank <= gear.gear_level)
        return true;
      return gear.gear_level_unlimit > 0 && this.release_rank < 5 + gear.gear_level_unlimit;
    }

    public static GearGearSkill Parse(MasterDataReader reader)
    {
      return new GearGearSkill()
      {
        ID = reader.ReadInt(),
        gear_GearGear = reader.ReadInt(),
        skill_BattleskillSkill = reader.ReadInt(),
        skill_level = reader.ReadInt(),
        release_rank = reader.ReadInt(),
        skill_group = reader.ReadInt()
      };
    }

    public GearGear gear
    {
      get
      {
        GearGear gear;
        if (!MasterData.GearGear.TryGetValue(this.gear_GearGear, out gear))
          Debug.LogError((object) ("Key not Found: MasterData.GearGear[" + (object) this.gear_GearGear + "]"));
        return gear;
      }
    }

    public BattleskillSkill skill
    {
      get
      {
        BattleskillSkill skill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_BattleskillSkill, out skill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_BattleskillSkill + "]"));
        return skill;
      }
    }
  }
}
