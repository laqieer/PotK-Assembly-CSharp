// Decompiled with JetBrains decompiler
// Type: SM.EnemyTopInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class EnemyTopInfo : KeyCompare
  {
    public int unit_id;
    public int min_point;

    public EnemyTopInfo()
    {
    }

    public EnemyTopInfo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.unit_id = (int) (long) json[nameof (unit_id)];
      this.min_point = (int) (long) json[nameof (min_point)];
    }
  }
}
