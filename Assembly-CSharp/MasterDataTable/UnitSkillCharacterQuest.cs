// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillCharacterQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

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

    public static UnitSkillCharacterQuest Parse(MasterDataReader reader) => new UnitSkillCharacterQuest()
    {
      ID = reader.ReadInt(),
      unit_UnitUnit = reader.ReadInt(),
      character_quest_QuestCharacterS = reader.ReadInt(),
      skill_BattleskillSkill = reader.ReadInt(),
      quest_id_for_evolution = reader.ReadInt(),
      skill_after_evolution = reader.ReadInt()
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

    public QuestCharacterS character_quest
    {
      get
      {
        QuestCharacterS questCharacterS;
        if (!MasterData.QuestCharacterS.TryGetValue(this.character_quest_QuestCharacterS, out questCharacterS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCharacterS[" + (object) this.character_quest_QuestCharacterS + "]"));
        return questCharacterS;
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

    public BattleskillSkill skillOfEvolution
    {
      get
      {
        BattleskillSkill battleskillSkill = (BattleskillSkill) null;
        if (this.skill_after_evolution != 0 && !MasterData.BattleskillSkill.TryGetValue(this.skill_after_evolution, out battleskillSkill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_after_evolution + "]"));
        return battleskillSkill;
      }
    }

    public QuestCharacterS evolution_character_quest
    {
      get
      {
        QuestCharacterS questCharacterS = (QuestCharacterS) null;
        if (this.quest_id_for_evolution != 0 && !MasterData.QuestCharacterS.TryGetValue(this.quest_id_for_evolution, out questCharacterS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCharacterS[" + (object) this.quest_id_for_evolution + "]"));
        return questCharacterS;
      }
    }
  }
}
