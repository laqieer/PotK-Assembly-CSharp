// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStageEnemySkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleStageEnemySkill
  {
    public int ID;
    public int skill_group_id;
    public int skill_BattleskillSkill;
    public int skill_level;

    public static BattleStageEnemySkill Parse(MasterDataReader reader)
    {
      return new BattleStageEnemySkill()
      {
        ID = reader.ReadInt(),
        skill_group_id = reader.ReadInt(),
        skill_BattleskillSkill = reader.ReadInt(),
        skill_level = reader.ReadInt()
      };
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
