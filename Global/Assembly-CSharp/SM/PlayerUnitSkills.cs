// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnitSkills
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
