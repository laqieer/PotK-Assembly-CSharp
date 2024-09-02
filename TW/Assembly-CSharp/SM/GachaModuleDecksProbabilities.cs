// Decompiled with JetBrains decompiler
// Type: SM.GachaModuleDecksProbabilities
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaModuleDecksProbabilities : KeyCompare
  {
    public int rarity_id;
    public float probability;

    public GachaModuleDecksProbabilities()
    {
    }

    public GachaModuleDecksProbabilities(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.rarity_id = (int) (long) json[nameof (rarity_id)];
      this.probability = (float) (double) json[nameof (probability)];
    }
  }
}
