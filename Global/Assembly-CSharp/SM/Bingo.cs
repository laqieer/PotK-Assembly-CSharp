// Decompiled with JetBrains decompiler
// Type: SM.Bingo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class Bingo : KeyCompare
  {
    public int cleared_bingo_id;
    public int complete_reward_group_id;
    public int id;
    public string name;

    public Bingo()
    {
    }

    public Bingo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.cleared_bingo_id = (int) (long) json[nameof (cleared_bingo_id)];
      this.complete_reward_group_id = (int) (long) json[nameof (complete_reward_group_id)];
      this.id = (int) (long) json[nameof (id)];
      this.name = (string) json[nameof (name)];
    }
  }
}
