﻿// Decompiled with JetBrains decompiler
// Type: SM.GuildInvestScale
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GuildInvestScale : KeyCompare
  {
    public int release_level;
    public int scale;

    public GuildInvestScale()
    {
    }

    public GuildInvestScale(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.release_level = (int) (long) json[nameof (release_level)];
      this.scale = (int) (long) json[nameof (scale)];
    }
  }
}
