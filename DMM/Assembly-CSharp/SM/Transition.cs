﻿// Decompiled with JetBrains decompiler
// Type: SM.Transition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class Transition : KeyCompare
  {
    public string scene_name;
    public int arg1;
    public int arg2;
    public int arg3;
    public int arg4;

    public Transition()
    {
    }

    public Transition(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.scene_name = (string) json[nameof (scene_name)];
      this.arg1 = (int) (long) json[nameof (arg1)];
      this.arg2 = (int) (long) json[nameof (arg2)];
      this.arg3 = (int) (long) json[nameof (arg3)];
      this.arg4 = (int) (long) json[nameof (arg4)];
    }
  }
}
