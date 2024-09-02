// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearGearSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;

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

    public bool isReleased(PlayerItem gear) => gear != (PlayerItem) null && this.release_rank <= gear.gear_level;

    public bool isReleased(GameCore.ItemInfo gear) => gear != null && this.release_rank <= gear.gearLevel;

    public static GearGearSkill Parse(MasterDataReader reader) => new GearGearSkill()
    {
      ID = reader.ReadInt(),
      gear_GearGear = reader.ReadInt(),
      skill_BattleskillSkill = reader.ReadInt(),
      skill_level = reader.ReadInt(),
      release_rank = reader.ReadInt(),
      skill_group = reader.ReadInt()
    };

    public GearGear gear
    {
      get
      {
        GearGear gearGear;
        if (!MasterData.GearGear.TryGetValue(this.gear_GearGear, out gearGear))
          Debug.LogError((object) ("Key not Found: MasterData.GearGear[" + (object) this.gear_GearGear + "]"));
        return gearGear;
      }
    }

    public BattleskillSkill skill
    {
      get
      {
        BattleskillSkill battleskillSkill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_BattleskillSkill, out battleskillSkill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_BattleskillSkill + "]"));
        return battleskillSkill;
      }
    }
  }
}
