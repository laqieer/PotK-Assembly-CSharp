// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillTiming
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleskillTiming
  {
    public int ID;
    public int skill_id_BattleskillSkill;
    public int skill_type_BattleskillTimingLogic;

    public static BattleskillTiming Parse(MasterDataReader reader)
    {
      return new BattleskillTiming()
      {
        ID = reader.ReadInt(),
        skill_id_BattleskillSkill = reader.ReadInt(),
        skill_type_BattleskillTimingLogic = reader.ReadInt()
      };
    }

    public BattleskillSkill skill_id
    {
      get
      {
        BattleskillSkill skillId;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_id_BattleskillSkill, out skillId))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_id_BattleskillSkill + "]"));
        return skillId;
      }
    }

    public BattleskillTimingLogic skill_type
    {
      get
      {
        BattleskillTimingLogic skillType;
        if (!MasterData.BattleskillTimingLogic.TryGetValue(this.skill_type_BattleskillTimingLogic, out skillType))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillTimingLogic[" + (object) this.skill_type_BattleskillTimingLogic + "]"));
        return skillType;
      }
    }
  }
}
