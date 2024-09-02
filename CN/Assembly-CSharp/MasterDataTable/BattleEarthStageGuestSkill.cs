// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleEarthStageGuestSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleEarthStageGuestSkill
  {
    public int ID;
    public int skill_group_id;
    public int skill_BattleskillSkill;
    public int skill_level;

    public static BattleEarthStageGuestSkill Parse(MasterDataReader reader)
    {
      return new BattleEarthStageGuestSkill()
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
