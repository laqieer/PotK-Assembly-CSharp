// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillEvolution
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

namespace MasterDataTable
{
  [Serializable]
  public class UnitSkillEvolution
  {
    public int ID;
    public int unit_UnitUnit;
    public int before_skill_BattleskillSkill;
    public int level;
    public int after_skill_BattleskillSkill;

    public static UnitSkillEvolution Parse(MasterDataReader reader) => new UnitSkillEvolution()
    {
      ID = reader.ReadInt(),
      unit_UnitUnit = reader.ReadInt(),
      before_skill_BattleskillSkill = reader.ReadInt(),
      level = reader.ReadInt(),
      after_skill_BattleskillSkill = reader.ReadInt()
    };

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

    public BattleskillSkill before_skill
    {
      get
      {
        BattleskillSkill battleskillSkill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.before_skill_BattleskillSkill, out battleskillSkill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.before_skill_BattleskillSkill + "]"));
        return battleskillSkill;
      }
    }

    public BattleskillSkill after_skill
    {
      get
      {
        BattleskillSkill battleskillSkill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.after_skill_BattleskillSkill, out battleskillSkill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.after_skill_BattleskillSkill + "]"));
        return battleskillSkill;
      }
    }

    public static bool isEvolution(int unitID, int beforeSkillId, int afterSkillId) => ((IEnumerable<UnitSkillEvolution>) MasterData.UnitSkillEvolutionList).Any<UnitSkillEvolution>((Func<UnitSkillEvolution, bool>) (x => x.unit.ID == unitID && x.before_skill.ID == beforeSkillId && x.after_skill.ID == afterSkillId));

    public static UnitSkillEvolution getUnitSkillEvolution(
      int unitID,
      int beforeSkillId,
      int afterSkillId)
    {
      return ((IEnumerable<UnitSkillEvolution>) MasterData.UnitSkillEvolutionList).FirstOrDefault<UnitSkillEvolution>((Func<UnitSkillEvolution, bool>) (x => x.unit.ID == unitID && x.before_skill.ID == beforeSkillId && x.after_skill.ID == afterSkillId));
    }
  }
}
