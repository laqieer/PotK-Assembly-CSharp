﻿// Decompiled with JetBrains decompiler
// Type: SM.DisplayPvPHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class DisplayPvPHistory : KeyCompare
  {
    public bool display;

    public DisplayPvPHistory()
    {
    }

    public DisplayPvPHistory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.display = (bool) json[nameof (display)];
    }
  }
}
