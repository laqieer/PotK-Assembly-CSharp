// Decompiled with JetBrains decompiler
// Type: SM.PlayerBingo2Panel
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
  public class PlayerBingo2Panel : KeyCompare
  {
    public int count;
    public int _panel;
    public bool is_received;
    public PlayerBingo2PanelReward_entities[] reward_entities;
    public bool can_receive;

    public PlayerBingo2Panel()
    {
    }

    public PlayerBingo2Panel(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.count = (int) (long) json[nameof (count)];
      this._panel = (int) (long) json[nameof (panel)];
      this.is_received = (bool) json[nameof (is_received)];
      List<PlayerBingo2PanelReward_entities> panelRewardEntitiesList = new List<PlayerBingo2PanelReward_entities>();
      foreach (object json1 in (List<object>) json[nameof (reward_entities)])
        panelRewardEntitiesList.Add(json1 != null ? new PlayerBingo2PanelReward_entities((Dictionary<string, object>) json1) : (PlayerBingo2PanelReward_entities) null);
      this.reward_entities = panelRewardEntitiesList.ToArray();
      this.can_receive = (bool) json[nameof (can_receive)];
    }

    public Bingo2Panel panel
    {
      get
      {
        if (!MasterData.Bingo2Panel.ContainsKey(this._panel))
          Debug.LogError((object) ("Key not Found: MasterData.Bingo2Panel[" + (object) this._panel + "]"));
        return MasterData.Bingo2Panel[this._panel];
      }
    }
  }
}
