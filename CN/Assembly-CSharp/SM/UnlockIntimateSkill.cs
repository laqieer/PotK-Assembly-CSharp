// Decompiled with JetBrains decompiler
// Type: SM.UnlockIntimateSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class UnlockIntimateSkill : KeyCompare
  {
    public int skill_id;
    public int unit_id;

    public UnlockIntimateSkill()
    {
    }

    public UnlockIntimateSkill(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.skill_id = (int) (long) json[nameof (skill_id)];
      this.unit_id = (int) (long) json[nameof (unit_id)];
    }
  }
}
