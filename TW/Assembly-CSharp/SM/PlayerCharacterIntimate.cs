// Decompiled with JetBrains decompiler
// Type: SM.PlayerCharacterIntimate
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
  public class PlayerCharacterIntimate : KeyCompare
  {
    public int exp_next;
    public int level;
    public int max_level;
    public int _target_character;
    public int _character;
    public int total_exp;
    public int exp;
    public int id;

    public PlayerCharacterIntimate()
    {
    }

    public PlayerCharacterIntimate(Dictionary<string, object> json)
    {
      this._hasKey = true;
      this.exp_next = (int) (long) json[nameof (exp_next)];
      this.level = (int) (long) json[nameof (level)];
      this.max_level = (int) (long) json[nameof (max_level)];
      this._target_character = (int) (long) json[nameof (target_character)];
      this._character = (int) (long) json[nameof (character)];
      this.total_exp = (int) (long) json[nameof (total_exp)];
      this.exp = (int) (long) json[nameof (exp)];
      this._key = (object) (this.id = (int) (long) json[nameof (id)]);
    }

    public static PlayerCharacterIntimate CreateForKey(int id)
    {
      PlayerCharacterIntimate forKey = new PlayerCharacterIntimate();
      forKey._hasKey = true;
      forKey._key = (object) (forKey.id = id);
      return forKey;
    }

    public UnitCharacter target_character
    {
      get
      {
        if (MasterData.UnitCharacter.ContainsKey(this._target_character))
          return MasterData.UnitCharacter[this._target_character];
        Debug.LogError((object) ("Key not Found: MasterData.UnitCharacter[" + (object) this._target_character + "]"));
        return (UnitCharacter) null;
      }
    }

    public UnitCharacter character
    {
      get
      {
        if (MasterData.UnitCharacter.ContainsKey(this._character))
          return MasterData.UnitCharacter[this._character];
        Debug.LogError((object) ("Key not Found: MasterData.UnitCharacter[" + (object) this._character + "]"));
        return (UnitCharacter) null;
      }
    }
  }
}
