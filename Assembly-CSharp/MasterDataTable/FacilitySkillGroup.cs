// Decompiled with JetBrains decompiler
// Type: MasterDataTable.FacilitySkillGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class FacilitySkillGroup
  {
    public int ID;
    public int facility_level_info_FacilityLevel;
    public int skill_BattleskillSkill;

    public static FacilitySkillGroup Parse(MasterDataReader reader) => new FacilitySkillGroup()
    {
      ID = reader.ReadInt(),
      facility_level_info_FacilityLevel = reader.ReadInt(),
      skill_BattleskillSkill = reader.ReadInt()
    };

    public FacilityLevel facility_level_info
    {
      get
      {
        FacilityLevel facilityLevel;
        if (!MasterData.FacilityLevel.TryGetValue(this.facility_level_info_FacilityLevel, out facilityLevel))
          Debug.LogError((object) ("Key not Found: MasterData.FacilityLevel[" + (object) this.facility_level_info_FacilityLevel + "]"));
        return facilityLevel;
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
