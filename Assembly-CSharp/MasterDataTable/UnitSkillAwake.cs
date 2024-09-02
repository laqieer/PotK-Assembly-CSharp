// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillAwake
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitSkillAwake
  {
    public int ID;
    public int character_id;
    public float need_affection;
    public int skill_BattleskillSkill;

    public static UnitSkillAwake Parse(MasterDataReader reader) => new UnitSkillAwake()
    {
      ID = reader.ReadInt(),
      character_id = reader.ReadInt(),
      need_affection = reader.ReadFloat(),
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
  }
}
