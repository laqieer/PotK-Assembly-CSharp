// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillCharacterQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitSkillCharacterQuest
  {
    public int ID;
    public int unit_UnitUnit;
    public int character_quest_QuestCharacterS;
    public int skill_BattleskillSkill;
    public int quest_id_for_evolution;
    public int skill_after_evolution;

    public static UnitSkillCharacterQuest Parse(MasterDataReader reader)
    {
      return new UnitSkillCharacterQuest()
      {
        ID = reader.ReadInt(),
        unit_UnitUnit = reader.ReadInt(),
        character_quest_QuestCharacterS = reader.ReadInt(),
        skill_BattleskillSkill = reader.ReadInt(),
        quest_id_for_evolution = reader.ReadInt(),
        skill_after_evolution = reader.ReadInt()
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

    public QuestCharacterS character_quest
    {
      get
      {
        QuestCharacterS characterQuest;
        if (!MasterData.QuestCharacterS.TryGetValue(this.character_quest_QuestCharacterS, out characterQuest))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCharacterS[" + (object) this.character_quest_QuestCharacterS + "]"));
        return characterQuest;
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

    public BattleskillSkill skillOfEvolution
    {
      get
      {
        BattleskillSkill skillOfEvolution;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_after_evolution, out skillOfEvolution))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_after_evolution + "]"));
        return skillOfEvolution;
      }
    }
  }
}
