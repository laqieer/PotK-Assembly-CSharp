// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleEnemyAcquireSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
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

    public static BattleEnemyAcquireSkill Parse(MasterDataReader reader)
    {
      return new BattleEnemyAcquireSkill()
      {
        ID = reader.ReadInt(),
        group_id = reader.ReadInt(),
        level = reader.ReadInt(),
        skill_level_up_rate = reader.ReadInt(),
        skill_BattleskillSkill = reader.ReadInt()
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
