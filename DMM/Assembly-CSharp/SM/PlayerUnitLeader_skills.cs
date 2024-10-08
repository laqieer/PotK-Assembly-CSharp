﻿// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnitLeader_skills
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class PlayerUnitLeader_skills : KeyCompare
  {
    public int skill_id;
    public int level;

    public BattleskillSkill skill => MasterData.BattleskillSkill[this.skill_id];

    public PlayerUnitLeader_skills()
    {
    }

    public PlayerUnitLeader_skills(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.skill_id = (int) (long) json[nameof (skill_id)];
      this.level = (int) (long) json[nameof (level)];
    }
  }
}
