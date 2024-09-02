// Decompiled with JetBrains decompiler
// Type: SM.PlayerBingo2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerBingo2 : KeyCompare
  {
    public int _bingo;
    public PlayerBingo2Complete_reward_groups[] complete_reward_groups;
    public string url;
    public PlayerBingo2Panel[] player_bingo2_panel;
    public PlayerBingo2Selected_reward_group selected_reward_group;
    public bool is_end;

    public PlayerBingo2()
    {
    }

    public PlayerBingo2(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._bingo = (int) (long) json[nameof (bingo)];
      List<PlayerBingo2Complete_reward_groups> completeRewardGroupsList = new List<PlayerBingo2Complete_reward_groups>();
      foreach (object json1 in (List<object>) json[nameof (complete_reward_groups)])
        completeRewardGroupsList.Add(json1 != null ? new PlayerBingo2Complete_reward_groups((Dictionary<string, object>) json1) : (PlayerBingo2Complete_reward_groups) null);
      this.complete_reward_groups = completeRewardGroupsList.ToArray();
      this.url = (string) json[nameof (url)];
      List<PlayerBingo2Panel> playerBingo2PanelList = new List<PlayerBingo2Panel>();
      foreach (object json2 in (List<object>) json[nameof (player_bingo2_panel)])
        playerBingo2PanelList.Add(json2 != null ? new PlayerBingo2Panel((Dictionary<string, object>) json2) : (PlayerBingo2Panel) null);
      this.player_bingo2_panel = playerBingo2PanelList.ToArray();
      this.selected_reward_group = json[nameof (selected_reward_group)] != null ? new PlayerBingo2Selected_reward_group((Dictionary<string, object>) json[nameof (selected_reward_group)]) : (PlayerBingo2Selected_reward_group) null;
      this.is_end = (bool) json[nameof (is_end)];
    }

    public Bingo2Bingo bingo
    {
      get
      {
        if (!MasterData.Bingo2Bingo.ContainsKey(this._bingo))
          Debug.LogError((object) ("Key not Found: MasterData.Bingo2Bingo[" + (object) this._bingo + "]"));
        return MasterData.Bingo2Bingo[this._bingo];
      }
    }
  }
}
