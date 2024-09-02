// Decompiled with JetBrains decompiler
// Type: SM.GvgCandidate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GvgCandidate : KeyCompare
  {
    public PlayerUnit player_unit;
    public string player_name;
    public int player_level;
    public string using_player_id;
    public string player_id;
    public int player_emblem_id;

    public GvgCandidate()
    {
    }

    public GvgCandidate(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player_unit = json[nameof (player_unit)] != null ? new PlayerUnit((Dictionary<string, object>) json[nameof (player_unit)]) : (PlayerUnit) null;
      this.player_name = (string) json[nameof (player_name)];
      this.player_level = (int) (long) json[nameof (player_level)];
      this.using_player_id = json[nameof (using_player_id)] != null ? (string) json[nameof (using_player_id)] : (string) null;
      this.player_id = (string) json[nameof (player_id)];
      this.player_emblem_id = (int) (long) json[nameof (player_emblem_id)];
    }
  }
}
