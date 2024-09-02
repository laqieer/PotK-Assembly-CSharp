// Decompiled with JetBrains decompiler
// Type: SM.PlayerGameKitLeaderboard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerGameKitLeaderboard : KeyCompare
  {
    public string leaderboard_id;
    public int score;

    public PlayerGameKitLeaderboard()
    {
    }

    public PlayerGameKitLeaderboard(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.leaderboard_id = (string) json[nameof (leaderboard_id)];
      this.score = (int) (long) json[nameof (score)];
    }
  }
}
