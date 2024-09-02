// Decompiled with JetBrains decompiler
// Type: SM.PlayershipSchema
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayershipSchema : KeyCompare
  {
    public int _leader_unit_unit;
    public string player_name;
    public int _leader_unit_unit_type;
    public int player_level;
    public string player_id;
    public int player_emblem_id;
    public int leader_unit_id;
    public int leader_unit_level;

    public PlayershipSchema()
    {
    }

    public PlayershipSchema(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._leader_unit_unit = (int) (long) json[nameof (leader_unit_unit)];
      this.player_name = (string) json[nameof (player_name)];
      this._leader_unit_unit_type = (int) (long) json[nameof (leader_unit_unit_type)];
      this.player_level = (int) (long) json[nameof (player_level)];
      this.player_id = (string) json[nameof (player_id)];
      this.player_emblem_id = (int) (long) json[nameof (player_emblem_id)];
      this.leader_unit_id = (int) (long) json[nameof (leader_unit_id)];
      this.leader_unit_level = (int) (long) json[nameof (leader_unit_level)];
    }

    public UnitUnit leader_unit_unit
    {
      get
      {
        if (!MasterData.UnitUnit.ContainsKey(this._leader_unit_unit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this._leader_unit_unit + "]"));
        return MasterData.UnitUnit[this._leader_unit_unit];
      }
    }

    public MasterDataTable.UnitType leader_unit_unit_type
    {
      get
      {
        if (!MasterData.UnitType.ContainsKey(this._leader_unit_unit_type))
          Debug.LogError((object) ("Key not Found: MasterData.UnitType[" + (object) this._leader_unit_unit_type + "]"));
        return MasterData.UnitType[this._leader_unit_unit_type];
      }
    }
  }
}
