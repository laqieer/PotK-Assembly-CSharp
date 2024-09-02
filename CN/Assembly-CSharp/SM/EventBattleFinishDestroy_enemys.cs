// Decompiled with JetBrains decompiler
// Type: SM.EventBattleFinishDestroy_enemys
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class EventBattleFinishDestroy_enemys : KeyCompare
  {
    public int bonus_point;
    public int point;
    public int unit_id;
    public int destroy_count;

    public EventBattleFinishDestroy_enemys()
    {
    }

    public EventBattleFinishDestroy_enemys(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.bonus_point = (int) (long) json[nameof (bonus_point)];
      this.point = (int) (long) json[nameof (point)];
      this.unit_id = (int) (long) json[nameof (unit_id)];
      this.destroy_count = (int) (long) json[nameof (destroy_count)];
    }
  }
}
