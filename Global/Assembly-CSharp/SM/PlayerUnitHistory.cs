// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnitHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerUnitHistory : KeyCompare
  {
    public int?[] skill_ids;
    public int broken;
    public DateTime created_at;
    public int unit_id;
    public int defeat;

    public PlayerUnitHistory()
    {
    }

    public PlayerUnitHistory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.skill_ids = ((IEnumerable<object>) json[nameof (skill_ids)]).Select<object, int?>((Func<object, int?>) (s =>
      {
        long? nullable = (long?) s;
        return nullable.HasValue ? new int?((int) nullable.Value) : new int?();
      })).ToArray<int?>();
      this.broken = (int) (long) json[nameof (broken)];
      this.created_at = DateTime.Parse((string) json[nameof (created_at)]);
      this.unit_id = (int) (long) json[nameof (unit_id)];
      this.defeat = (int) (long) json[nameof (defeat)];
    }

    public bool HasEvolutionUnitSkill(UnitUnit unit)
    {
      return ((IEnumerable<UnitSkillEvolution>) MasterData.UnitSkillEvolutionList).Where<UnitSkillEvolution>((Func<UnitSkillEvolution, bool>) (x => x.unit.ID == unit.ID)).Select<UnitSkillEvolution, int>((Func<UnitSkillEvolution, int>) (x => x.ID)).Any<int>((Func<int, bool>) (x => ((IEnumerable<int?>) this.skill_ids).Contains<int?>(new int?(x))));
    }

    public bool HasEvolutionCharacterSkill(UnitUnit unit)
    {
      foreach (BattleskillSkill battleskillSkill in ((IEnumerable<UnitSkillCharacterQuest>) MasterData.UnitSkillCharacterQuestList).Where<UnitSkillCharacterQuest>((Func<UnitSkillCharacterQuest, bool>) (x => x.unit.ID == unit.ID && x.skill_after_evolution > 0)).Select<UnitSkillCharacterQuest, BattleskillSkill>((Func<UnitSkillCharacterQuest, BattleskillSkill>) (x => x.skillOfEvolution)).ToList<BattleskillSkill>())
      {
        if (((IEnumerable<int?>) this.skill_ids).Contains<int?>(new int?(battleskillSkill.ID)))
          return true;
      }
      return false;
    }
  }
}
