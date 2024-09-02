// Decompiled with JetBrains decompiler
// Type: SM.PlayerReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerReward : KeyCompare
  {
    public bool received;
    public int step_id;

    public PlayerReward()
    {
    }

    public PlayerReward(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.received = (bool) json[nameof (received)];
      this.step_id = (int) (long) json[nameof (step_id)];
    }
  }
}
