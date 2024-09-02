// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillHarmonyQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitSkillHarmonyQuest
  {
    public int ID;
    public int character_UnitCharacter;
    public int character_quest_QuestHarmonyS;
    public int skill_BattleskillSkill;

    public static UnitSkillHarmonyQuest Parse(MasterDataReader reader) => new UnitSkillHarmonyQuest()
    {
      ID = reader.ReadInt(),
      character_UnitCharacter = reader.ReadInt(),
      character_quest_QuestHarmonyS = reader.ReadInt(),
      skill_BattleskillSkill = reader.ReadInt()
    };

    public UnitCharacter character
    {
      get
      {
        UnitCharacter unitCharacter;
        if (!MasterData.UnitCharacter.TryGetValue(this.character_UnitCharacter, out unitCharacter))
          Debug.LogError((object) ("Key not Found: MasterData.UnitCharacter[" + (object) this.character_UnitCharacter + "]"));
        return unitCharacter;
      }
    }

    public QuestHarmonyS character_quest
    {
      get
      {
        QuestHarmonyS questHarmonyS;
        if (!MasterData.QuestHarmonyS.TryGetValue(this.character_quest_QuestHarmonyS, out questHarmonyS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestHarmonyS[" + (object) this.character_quest_QuestHarmonyS + "]"));
        return questHarmonyS;
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
