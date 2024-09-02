// Decompiled with JetBrains decompiler
// Type: SM.PlayerMaterialUnit
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
  public class PlayerMaterialUnit : KeyCompare
  {
    public string player_id;
    public int id;
    public int _unit;
    public int quantity;

    public PlayerMaterialUnit()
    {
    }

    public PlayerMaterialUnit(Dictionary<string, object> json)
    {
      this._hasKey = true;
      this.player_id = (string) json[nameof (player_id)];
      this._key = (object) (this.id = (int) (long) json[nameof (id)]);
      this._unit = (int) (long) json[nameof (unit)];
      this.quantity = (int) (long) json[nameof (quantity)];
    }

    public UnitUnit unit
    {
      get
      {
        if (MasterData.UnitUnit.ContainsKey(this._unit))
          return MasterData.UnitUnit[this._unit];
        Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this._unit + "]"));
        return (UnitUnit) null;
      }
    }
  }
}
