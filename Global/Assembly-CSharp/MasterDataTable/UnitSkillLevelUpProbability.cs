// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillLevelUpProbability
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitSkillLevelUpProbability
  {
    public int ID;
    public int base_level;
    public int material_level;
    public float probability;

    public static UnitSkillLevelUpProbability Parse(MasterDataReader reader)
    {
      return new UnitSkillLevelUpProbability()
      {
        ID = reader.ReadInt(),
        base_level = reader.ReadInt(),
        material_level = reader.ReadInt(),
        probability = reader.ReadFloat()
      };
    }

    public static float Probability(int baseLevel, int materialLevel)
    {
      UnitSkillLevelUpProbability levelUpProbability = ((IEnumerable<UnitSkillLevelUpProbability>) MasterData.UnitSkillLevelUpProbabilityList).Where<UnitSkillLevelUpProbability>((Func<UnitSkillLevelUpProbability, bool>) (x => x.base_level == baseLevel && x.material_level == materialLevel)).FirstOrDefault<UnitSkillLevelUpProbability>();
      return levelUpProbability == null ? 0.0f : levelUpProbability.probability;
    }
  }
}
