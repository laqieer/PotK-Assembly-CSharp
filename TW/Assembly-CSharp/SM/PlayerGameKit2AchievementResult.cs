// Decompiled with JetBrains decompiler
// Type: SM.PlayerGameKit2AchievementResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerGameKit2AchievementResult : KeyCompare
  {
    public string achievement_id;
    public float progress;

    public PlayerGameKit2AchievementResult()
    {
    }

    public PlayerGameKit2AchievementResult(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.achievement_id = (string) json[nameof (achievement_id)];
      this.progress = (float) (double) json[nameof (progress)];
    }
  }
}
