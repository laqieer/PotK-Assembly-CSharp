﻿// Decompiled with JetBrains decompiler
// Type: SM.BattleFinishDrop_material_unit_entities
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class BattleFinishDrop_material_unit_entities : KeyCompare
  {
    public int reward_quantity;
    public bool is_new;
    public int? reward_id;
    public int reward_type_id;

    public BattleFinishDrop_material_unit_entities()
    {
    }

    public BattleFinishDrop_material_unit_entities(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
      this.is_new = (bool) json[nameof (is_new)];
      int? nullable1;
      if (json[nameof (reward_id)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (reward_id)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.reward_id = nullable1;
      this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
    }
  }
}
