// Decompiled with JetBrains decompiler
// Type: SM.BonusCount
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class BonusCount : KeyCompare
  {
    public int left_count;
    public int activity_id;
    public bool purchaseable;

    public BonusCount()
    {
    }

    public BonusCount(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.left_count = (int) (long) json[nameof (left_count)];
      this.activity_id = (int) (long) json[nameof (activity_id)];
      this.purchaseable = (bool) json[nameof (purchaseable)];
    }
  }
}
