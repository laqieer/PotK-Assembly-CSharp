// Decompiled with JetBrains decompiler
// Type: SM.GvgStage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GvgStage : KeyCompare
  {
    public int turns;
    public int stage_id;
    public int point;
    public int annihilation_point;
    public int id;

    public GvgStage()
    {
    }

    public GvgStage(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.turns = (int) (long) json[nameof (turns)];
      this.stage_id = (int) (long) json[nameof (stage_id)];
      this.point = (int) (long) json[nameof (point)];
      this.annihilation_point = (int) (long) json[nameof (annihilation_point)];
      this.id = (int) (long) json[nameof (id)];
    }
  }
}
