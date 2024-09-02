// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleEnemyAcquireSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleEnemyAcquireSkill
  {
    public int ID;
    public int group_id;
    public int level;
    public int skill_level_up_rate;
    public int skill_BattleskillSkill;

    public static BattleEnemyAcquireSkill Parse(MasterDataReader reader) => new BattleEnemyAcquireSkill()
    {
      ID = reader.ReadInt(),
      group_id = reader.ReadInt(),
      level = reader.ReadInt(),
      skill_level_up_rate = reader.ReadInt(),
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
