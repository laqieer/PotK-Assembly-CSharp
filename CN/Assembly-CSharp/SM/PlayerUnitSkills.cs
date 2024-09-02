// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnitSkills
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerUnitSkills : KeyCompare
  {
    public int skill_id;
    public int level;

    public PlayerUnitSkills()
    {
    }

    public PlayerUnitSkills(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.skill_id = (int) (long) json[nameof (skill_id)];
      this.level = (int) (long) json[nameof (level)];
    }

    public BattleskillSkill skill => MasterData.BattleskillSkill[this.skill_id];
  }
}
