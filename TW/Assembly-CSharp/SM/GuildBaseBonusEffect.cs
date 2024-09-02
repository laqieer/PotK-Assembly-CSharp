// Decompiled with JetBrains decompiler
// Type: SM.GuildBaseBonusEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class GuildBaseBonusEffect : KeyCompare
  {
    public int _skill;
    public int id;

    public GuildBaseBonusEffect()
    {
    }

    public GuildBaseBonusEffect(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._skill = (int) (long) json[nameof (skill)];
      this.id = (int) (long) json[nameof (id)];
    }

    public BattleskillSkill skill
    {
      get
      {
        if (MasterData.BattleskillSkill.ContainsKey(this._skill))
          return MasterData.BattleskillSkill[this._skill];
        Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this._skill + "]"));
        return (BattleskillSkill) null;
      }
    }
  }
}
