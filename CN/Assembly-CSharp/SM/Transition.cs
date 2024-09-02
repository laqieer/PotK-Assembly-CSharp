// Decompiled with JetBrains decompiler
// Type: SM.Transition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
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
