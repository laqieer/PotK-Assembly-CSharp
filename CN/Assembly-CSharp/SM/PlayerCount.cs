// Decompiled with JetBrains decompiler
// Type: SM.PlayerCount
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerCount : KeyCompare
  {
    public int count;
    public int activity_id;
    public int type_id;

    public PlayerCount()
    {
    }

    public PlayerCount(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.count = (int) (long) json[nameof (count)];
      this.activity_id = (int) (long) json[nameof (activity_id)];
      this.type_id = (int) (long) json[nameof (type_id)];
    }
  }
}
