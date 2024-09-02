// Decompiled with JetBrains decompiler
// Type: SM.PlayerMissionHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerMissionHistory : KeyCompare
  {
    public int mission_id;
    public int story_category;
    public string reward_title;
    public bool is_clear;

    public PlayerMissionHistory()
    {
    }

    public PlayerMissionHistory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.mission_id = (int) (long) json[nameof (mission_id)];
      this.story_category = (int) (long) json[nameof (story_category)];
      this.reward_title = json[nameof (reward_title)] != null ? (string) json[nameof (reward_title)] : (string) null;
      this.is_clear = (bool) json[nameof (is_clear)];
    }
  }
}
