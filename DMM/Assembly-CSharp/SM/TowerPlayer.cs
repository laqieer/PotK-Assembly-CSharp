﻿// Decompiled with JetBrains decompiler
// Type: SM.TowerPlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class TowerPlayer : KeyCompare
  {
    public int tower_medal;

    public TowerPlayer()
    {
    }

    public TowerPlayer(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.tower_medal = (int) (long) json[nameof (tower_medal)];
    }
  }
}
