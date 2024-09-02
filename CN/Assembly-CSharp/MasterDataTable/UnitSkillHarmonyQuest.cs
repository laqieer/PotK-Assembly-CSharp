// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillHarmonyQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitSkillHarmonyQuest
  {
    public int ID;
    public int character_UnitCharacter;
    public int character_quest_QuestHarmonyS;
    public int skill_BattleskillSkill;

    public static UnitSkillHarmonyQuest Parse(MasterDataReader reader)
    {
      return new UnitSkillHarmonyQuest()
      {
        ID = reader.ReadInt(),
        character_UnitCharacter = reader.ReadInt(),
        character_quest_QuestHarmonyS = reader.ReadInt(),
        skill_BattleskillSkill = reader.ReadInt()
      };
    }

    public UnitCharacter character
    {
      get
      {
        UnitCharacter character;
        if (!MasterData.UnitCharacter.TryGetValue(this.character_UnitCharacter, out character))
          Debug.LogError((object) ("Key not Found: MasterData.UnitCharacter[" + (object) this.character_UnitCharacter + "]"));
        return character;
      }
    }

    public QuestHarmonyS character_quest
    {
      get
      {
        QuestHarmonyS characterQuest;
        if (!MasterData.QuestHarmonyS.TryGetValue(this.character_quest_QuestHarmonyS, out characterQuest))
          Debug.LogError((object) ("Key not Found: MasterData.QuestHarmonyS[" + (object) this.character_quest_QuestHarmonyS + "]"));
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
  }
}
