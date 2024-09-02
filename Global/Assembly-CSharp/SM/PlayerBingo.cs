// Decompiled with JetBrains decompiler
// Type: SM.PlayerBingo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerBingo : KeyCompare
  {
    public bool is_end;
    public PlayerBingoPanel[] player_bingo_panel;
    public int selected_group_reward_id;
    public int id;
    public int bingo_id;

    public PlayerBingo()
    {
    }

    public PlayerBingo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.is_end = (bool) json[nameof (is_end)];
      List<PlayerBingoPanel> playerBingoPanelList = new List<PlayerBingoPanel>();
      foreach (object json1 in (List<object>) json[nameof (player_bingo_panel)])
        playerBingoPanelList.Add(json1 != null ? new PlayerBingoPanel((Dictionary<string, object>) json1) : (PlayerBingoPanel) null);
      this.player_bingo_panel = playerBingoPanelList.ToArray();
      this.selected_group_reward_id = (int) (long) json[nameof (selected_group_reward_id)];
      this.id = (int) (long) json[nameof (id)];
      this.bingo_id = (int) (long) json[nameof (bingo_id)];
    }
  }
}
