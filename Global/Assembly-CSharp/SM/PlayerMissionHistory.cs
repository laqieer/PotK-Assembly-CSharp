// Decompiled with JetBrains decompiler
// Type: SM.PlayerMissionHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    public bool is_clear;

    public PlayerMissionHistory()
    {
    }

    public PlayerMissionHistory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.mission_id = (int) (long) json[nameof (mission_id)];
      this.story_category = (int) (long) json[nameof (story_category)];
      this.is_clear = (bool) json[nameof (is_clear)];
    }
  }
}
