// Decompiled with JetBrains decompiler
// Type: SM.GvgReinforcement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GvgReinforcement : KeyCompare
  {
    public PlayerUnit player_unit;
    public PlayerItem[] player_gears;

    public GvgReinforcement()
    {
    }

    public GvgReinforcement(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player_unit = json[nameof (player_unit)] != null ? new PlayerUnit((Dictionary<string, object>) json[nameof (player_unit)]) : (PlayerUnit) null;
      List<PlayerItem> playerItemList = new List<PlayerItem>();
      foreach (object json1 in (List<object>) json[nameof (player_gears)])
        playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
      this.player_gears = playerItemList.ToArray();
    }
  }
}
