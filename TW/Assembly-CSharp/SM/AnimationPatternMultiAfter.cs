// Decompiled with JetBrains decompiler
// Type: SM.AnimationPatternMultiAfter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class AnimationPatternMultiAfter : KeyCompare
  {
    public string effect_gem_color_3rd;
    public string effect_gem_color_4th;
    public string effect_gem_color_1st;
    public string effect_type;
    public string effect_gem_color_2nd;
    public bool effect_brilliant;

    public AnimationPatternMultiAfter()
    {
    }

    public AnimationPatternMultiAfter(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.effect_gem_color_3rd = (string) json[nameof (effect_gem_color_3rd)];
      this.effect_gem_color_4th = (string) json[nameof (effect_gem_color_4th)];
      this.effect_gem_color_1st = (string) json[nameof (effect_gem_color_1st)];
      this.effect_type = (string) json[nameof (effect_type)];
      this.effect_gem_color_2nd = (string) json[nameof (effect_gem_color_2nd)];
      this.effect_brilliant = (bool) json[nameof (effect_brilliant)];
    }
  }
}
