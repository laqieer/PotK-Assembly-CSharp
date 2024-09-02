﻿// Decompiled with JetBrains decompiler
// Type: SM.GachaModuleNewentity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaModuleNewentity : KeyCompare
  {
    public int reward_quantity;
    public int view_priority;
    public int id;
    public int reward_id;
    public int reward_type_id;

    public GachaModuleNewentity()
    {
    }

    public GachaModuleNewentity(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
      this.view_priority = (int) (long) json[nameof (view_priority)];
      this.id = (int) (long) json[nameof (id)];
      this.reward_id = (int) (long) json[nameof (reward_id)];
      this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
    }
  }
}
