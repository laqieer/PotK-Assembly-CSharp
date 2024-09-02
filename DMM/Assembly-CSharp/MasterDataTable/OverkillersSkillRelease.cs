// Decompiled with JetBrains decompiler
// Type: MasterDataTable.OverkillersSkillRelease
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class OverkillersSkillRelease
  {
    public int ID;
    public int unity_value;
    public int skill_BattleskillSkill;

    public static OverkillersSkillRelease Parse(MasterDataReader reader) => new OverkillersSkillRelease()
    {
      ID = reader.ReadInt(),
      unity_value = reader.ReadInt(),
      skill_BattleskillSkill = reader.ReadInt()
    };

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

    public int same_character_id => this.ID;

    public static OverkillersSkillRelease find(UnitUnit unit)
    {
      OverkillersSkillRelease overkillersSkillRelease;
      return unit != null && unit.exist_overkillers_skill && MasterData.OverkillersSkillRelease.TryGetValue(unit.same_character_id, out overkillersSkillRelease) ? overkillersSkillRelease : (OverkillersSkillRelease) null;
    }
  }
}
