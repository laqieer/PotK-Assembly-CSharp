// Decompiled with JetBrains decompiler
// Type: SM.PlayerBingo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;

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
      foreach (object obj in (List<object>) json[nameof (player_bingo_panel)])
        playerBingoPanelList.Add(obj == null ? (PlayerBingoPanel) null : new PlayerBingoPanel((Dictionary<string, object>) obj));
      this.player_bingo_panel = playerBingoPanelList.ToArray();
      this.selected_group_reward_id = (int) (long) json[nameof (selected_group_reward_id)];
      this.id = (int) (long) json[nameof (id)];
      this.bingo_id = (int) (long) json[nameof (bingo_id)];
    }

    public BingoBingo bingo
    {
      get
      {
        BingoBingo bingoBingo = (BingoBingo) null;
        MasterData.BingoBingo.TryGetValue(this.bingo_id, out bingoBingo);
        return bingoBingo;
      }
    }
  }
}
