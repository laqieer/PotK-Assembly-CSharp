// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnitLeader_skills
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerUnitLeader_skills : KeyCompare
  {
    public int skill_id;
    public int level;

    public PlayerUnitLeader_skills()
    {
    }

    public PlayerUnitLeader_skills(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.skill_id = (int) (long) json[nameof (skill_id)];
      this.level = (int) (long) json[nameof (level)];
    }

    public BattleskillSkill skill => MasterData.BattleskillSkill[this.skill_id];
  }
}
