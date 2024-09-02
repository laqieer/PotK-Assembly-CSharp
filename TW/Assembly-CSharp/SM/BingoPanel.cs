// Decompiled with JetBrains decompiler
// Type: SM.BingoPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class BingoPanel : KeyCompare
  {
    public int panel_id;
    public int reward_group_id;
    public int id;
    public string name;
    public int bingo_id;

    public BingoPanel()
    {
    }

    public BingoPanel(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.panel_id = (int) (long) json[nameof (panel_id)];
      this.reward_group_id = (int) (long) json[nameof (reward_group_id)];
      this.id = (int) (long) json[nameof (id)];
      this.name = (string) json[nameof (name)];
      this.bingo_id = (int) (long) json[nameof (bingo_id)];
    }
  }
}
